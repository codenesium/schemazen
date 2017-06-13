using System;
using System.Diagnostics;
using System.IO;
using ManyConsole;
using NLog;
using SchemaZen.Library;
using SchemaZen.Library.Command;
using SchemaZen.Library.Models;

namespace SchemaZen.console {
	public class Create : BaseCommand {
		private static Logger _logger = LogManager.GetCurrentClassLogger();
		public Create()
			: base(
				"Create", "Create the specified database from scripts.") { }

		public override int Run(string[] remainingArguments) {

			var createCommand = new CreateCommand {
				ConnectionString = ConnectionString,
				DbName = DbName,
				Pass = Pass,
				ScriptDir = ScriptDir,
				Server = Server,
				User = User,
				Overwrite = Overwrite
			};

			try {
				createCommand.Execute(DatabaseFilesPath, false);
			} catch (BatchSqlFileException ex) {
				_logger.Info($"{Environment.NewLine}Create completed with the following errors:");
				foreach (var e in ex.Exceptions) {
					_logger.Info($"- {e.FileName.Replace("/", "\\")} (Line {e.LineNumber}):");
					_logger.Error($" {e.Message}");
				}
				return -1;
			} catch (SqlFileException ex) {
				_logger.Info($@"{Environment.NewLine}An unexpected SQL error occurred while executing scripts, and the process wasn't completed.
{ex.FileName.Replace("/", "\\")} (Line {ex.LineNumber}):");
				_logger.Error( ex.Message);
				return -1;
			} catch (Exception ex) {
				throw new ConsoleHelpAsException(ex.Message);
			}
			return 0;
		}
	}
}
