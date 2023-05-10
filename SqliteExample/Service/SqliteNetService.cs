
using Microsoft.Maui.Storage;
using SQLite;
using SqliteExample.Model;
using System.IO;

namespace SqliteExample.Service
{
		public class SqliteUtils
		{
				public static string DatabaseFilePath
				{
						get
						{
								// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
								// (they don't want non-user-generated data in Documents)
								var libraryPath = FileSystem.AppDataDirectory;
								return Path.Combine (libraryPath, "abc.db3");
						}
				}
				public static readonly SQLite.SQLiteOpenFlags Flags =
				   // open the database in read/write mode
				   SQLite.SQLiteOpenFlags.ReadWrite |
				   // create the database if it doesn't exist
				   SQLite.SQLiteOpenFlags.Create |
				   // enable multi-threaded database access
				   SQLite.SQLiteOpenFlags.SharedCache;
		}

		public class SqliteNetService 
		{
				SQLiteConnection Database;
				public SqliteNetService()
				{
						if (Database is not null)
								return;
						Database = new SQLiteConnection (SqliteUtils.DatabaseFilePath);

						Database.CreateTable<TodoItemModel> ();
				}
				//public void Insert(DayModel day) => Database.InsertOrReplace (day);

				public void Insert(TodoItemModel todo)
				{
						if (todo.id == 0)
						{
								Database.Insert (todo);
								return;
						}
						Database.Update (todo);
				}

				//public void Delete(DayModel day) => Database.Delete (day);

				public void Delete(TodoItemModel todo) => Database.Delete (todo);

				public List<TodoItemModel> Get()
				{
						return Database.Table<TodoItemModel> ().ToList ();
				}
		}
}
