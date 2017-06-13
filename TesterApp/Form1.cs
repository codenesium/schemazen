using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchemaZen.Library;
using SchemaZen.Library.Command;
using SchemaZen.Library.Models;

namespace TesterApp
{
    public partial class Form1 : Form
    {
        Logger _logger;
        protected string DataTables { get; set; }
        protected string FilterTypes { get; set; }
        protected string DataTablesPattern { get; set; }
        protected string DataTablesExcludePattern { get; set; }
        protected string TableHint { get; set; }
        public Form1()
        {
            InitializeComponent();
            _logger = new Logger(true);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
          
          
            var scriptCommand = new ScriptCommand
            {
                ConnectionString = textBoxConnectionString.Text,
                ScriptDir = textBoxDestinationDirectory.Text,
                Logger = _logger,
                Overwrite = true
            };

            var filteredTypes = HandleFilteredTypes();
            var namesAndSchemas = HandleDataTables(DataTables);

            try
            {
                scriptCommand.Execute(namesAndSchemas, DataTablesPattern, DataTablesExcludePattern, TableHint, filteredTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    _logger.Log(TraceLevel.Warning, $"{filterType} is not a valid type.");
                    anyInvalidType = true;
                }
            }

            if (anyInvalidType)
            {
                _logger.Log(TraceLevel.Warning, $"Valid types: {Database.ValidTypes}");
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeploySnapshot_Click(object sender, EventArgs e)
        {
            var createCommand = new CreateCommand
            {
                ConnectionString = textBoxConnectionString.Text,
                ScriptDir = textBoxDestinationDirectory.Text,
                Logger = _logger,
                Overwrite = true
            };
            try
            {
                createCommand.Execute(@"c:\tmp\database", true);
            }
            catch (BatchSqlFileException ex)
            {
                _logger.Log(TraceLevel.Info, $"{Environment.NewLine}Create completed with the following errors:");
                foreach (var exception in ex.Exceptions)
                {
                    _logger.Log(TraceLevel.Info, $"- {exception.FileName.Replace("/", "\\")} (Line {exception.LineNumber}):");
                    _logger.Log(TraceLevel.Error, $" {exception.Message}");
                }
            }
            catch (SqlFileException ex)
            {
                _logger.Log(TraceLevel.Info, $@"{Environment.NewLine}An unexpected SQL error occurred while executing scripts, and the process wasn't completed.
{ex.FileName.Replace("/", "\\")} (Line {ex.LineNumber}):");
                _logger.Log(TraceLevel.Error, ex.Message);
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }
    }
}
