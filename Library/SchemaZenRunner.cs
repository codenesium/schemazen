using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NLog;
using SchemaZen.Library.Command;
using SchemaZen.Library.Models;

namespace SchemaZen.Library
{
    /// <summary>
    /// Creates an instance of the SchemaZenRunner class.
    /// This class is the publicly consumable interface for this library to 
    /// be used from a nuget package.
    /// </summary>
    public class SchemaZenRunner
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        protected string DataTables { get; set; }
        protected string FilterTypes { get; set; }
        protected string DataTablesPattern { get; set; }
        protected string DataTablesExcludePattern { get; set; }
        protected string TableHint { get; set; }

        public ExecutionResponse DeploySnapshot(string connectionString, string scriptDir, bool overwrite, bool azureMode)
        {
            try
            {
                connectionString.Should().NotBeNullOrWhiteSpace();
                scriptDir.Should().NotBeNullOrWhiteSpace();

                if (!Directory.Exists(scriptDir))
                {
                    throw new DirectoryNotFoundException($"The script directory does not exist. Directory={scriptDir}");
                }

                var createCommand = new CreateCommand
                {
                    ConnectionString = connectionString,
                    ScriptDir = scriptDir,
                    Overwrite = azureMode
                };

                createCommand.Execute(@"c:\tmp\database", overwrite);
                return new ExecutionResponse(true);
            }
            catch (BatchSqlFileException ex)
            {
                _logger.Info($"{Environment.NewLine}Create completed with the following errors:");
                string errors = string.Empty;
                foreach (var exception in ex.Exceptions)
                {
                    errors += $"- {exception.FileName.Replace("/", "\\")} (Line {exception.LineNumber}):";
                    errors += $" {exception.Message}";
                }
                _logger.Error(errors);
                return new ExecutionResponse(false, errors, ex);
            }
            catch (SqlFileException ex)
            {
                string errors = $@"{Environment.NewLine}An unexpected SQL error occurred while executing scripts, and the process wasn't completed.
                                   {ex.FileName.Replace("/", "\\")} (Line {ex.LineNumber}):";

                _logger.Info(errors);
                _logger.Error(ex.Message);
                return new ExecutionResponse(false, errors, ex);
            }
            catch (Exception ex)
            {
                return new ExecutionResponse(false, "", ex);
            }

        }
        public ExecutionResponse CreateSnapshot(string connectionString, string scriptDir, bool overwrite)
        {
            try
            {
                connectionString.Should().NotBeNullOrWhiteSpace();
                scriptDir.Should().NotBeNullOrWhiteSpace();

                var scriptCommand = new ScriptCommand
                {
                    ConnectionString = connectionString,
                    ScriptDir = scriptDir,
                    Overwrite = overwrite
                };

                var filteredTypes = HandleFilteredTypes();
                var namesAndSchemas = HandleDataTables(DataTables);

                scriptCommand.Execute(namesAndSchemas, DataTablesPattern, DataTablesExcludePattern, TableHint, filteredTypes);
                return new ExecutionResponse(true);
            }
            catch (Exception ex)
            {
                return new ExecutionResponse(false, "", ex);
            }
        }

        private List<string> HandleFilteredTypes()
        {
            var filteredTypes = FilterTypes?.Split(',').ToList() ?? new List<string>();

            var anyInvalidType = false;
            foreach (var filterType in filteredTypes)
            {
                if (!Database.Dirs.Contains(filterType))
                {
                    _logger.Warn($"{filterType} is not a valid type.");
                    anyInvalidType = true;
                }
            }

            if (anyInvalidType)
            {
                _logger.Warn($"Valid types: {Database.ValidTypes}");
            }

            return filteredTypes;
        }

        private Dictionary<string, string> HandleDataTables(string tableNames)
        {
            var dataTables = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(tableNames))
                return dataTables;

            foreach (var value in tableNames.Split(','))
            {
                var schema = "dbo";
                var name = value;
                if (value.Contains("."))
                {
                    schema = value.Split('.')[0];
                    name = value.Split('.')[1];
                }

                dataTables[name] = schema;
            }

            return dataTables;
        }

    }
}
