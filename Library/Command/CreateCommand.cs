using System;
using System.Diagnostics;
using System.IO;
using NLog;

namespace SchemaZen.Library.Command {
	public class CreateCommand : BaseCommand {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public void Execute(string databaseFilesPath, bool azureMode) {
			var db = CreateDatabase();
			if (!Directory.Exists(db.Dir)) {
				throw new FileNotFoundException($"Snapshot dir {db.Dir} does not exist.");
			}

			if (!Overwrite && (DBHelper.DbExists(db.Connection))) {
				var msg = $"{Server} {DbName} already exists - use overwrite property if you want to drop it";
				throw new InvalidOperationException(msg);
			}

			db.CreateFromDir(Overwrite, azureMode, databaseFilesPath);
			_logger.Info( $"{Environment.NewLine}Database created successfully.");
		}
	}
}
