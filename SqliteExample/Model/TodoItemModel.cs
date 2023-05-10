using SQLite;

namespace SqliteExample.Model
{
		[Table("TodoTable")]
		public class TodoItemModel
		{
				[PrimaryKey, AutoIncrement]
				public int id { get; set; }
				public string Text { get; set; }
		}
}
