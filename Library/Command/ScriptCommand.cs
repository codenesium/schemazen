using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SchemaZen.Library.Command {
	public class ScriptCommand : BaseCommand {

		public void Execute(Dictionary<string, string> namesAndSchemas, string dataTablesPattern, string dataTablesExcludePattern,
			string tableHint, List<string> filteredTypes) {
			if (!Overwrite && Directory.Exists(ScriptDir)) {
				var message = $"{ScriptDir} already exists - you must set overwrite to true";
				throw new InvalidOperationException(message);
			}

			var db = CreateDatabase(filteredTypes);

			_logger.Trace( "Loading database schema...");
			db.Load();
			_logger.Trace( "Database schema loaded.");

			foreach (var nameAndSchema in namesAndSchemas) {
				AddDataTable(db, nameAndSchema.Key, nameAndSchema.Value);
			}

			if (!string.IsNullOrEmpty(dataTablesPattern) || !string.IsNullOrEmpty(dataTablesExcludePattern)) {
				var tables = db.FindTablesRegEx(dataTablesPattern, dataTablesExcludePattern);
				foreach (var t in tables.Where(t => !db.DataTables.Contains(t))) {
					db.DataTables.Add(t);
				}
			}

			db.ScriptToDir(tableHint);

			_logger.Info( $"{Environment.NewLine}Snapshot successfully created at {db.Dir}");
			var routinesWithWarnings = db.Routines.Select(r => new {
				Routine = r,
				Warnings = r.Warnings().ToList()
			}).Where(r => r.Warnings.Any()).ToList();
			if (routinesWithWarnings.Any()) {
				_logger.Info( "With the following warnings:");
				foreach (
					var warning in
						routinesWithWarnings.SelectMany(
							r =>
								r.Warnings.Select(
									w => $"- {r.Routine.RoutineType} [{r.Routine.Owner}].[{r.Routine.Name}]: {w}"))) {
					_logger.Warn( warning);
				}
			}
		}
	}
}
