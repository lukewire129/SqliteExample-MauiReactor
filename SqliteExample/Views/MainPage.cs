using MauiReactor;
using SqliteExample.Model;
using SqliteExample.Service;
using System.Collections.ObjectModel;

namespace SqliteExample.Views
{
		internal class MainPageState
		{
				public ObservableCollection<TodoItemModel> todo;
				public string inputText;
		}

		internal class MainPage : Component<MainPageState>
		{
				private SqliteNetService _sqliteNetService;
				public MainPage()
				{
						_sqliteNetService = Services.GetRequiredService<SqliteNetService> ();
						SetState (s => s.todo = new ObservableCollection<TodoItemModel> (this._sqliteNetService.Get ()));
				}

				public override VisualNode Render() => new ContentPage ()
				{
						new VStack()
						{
								new HStack()
								{
										new Entry()
										  .WidthRequest(265)
										  .Placeholder("Input Text!")
										  .Text(State.inputText)
										  .OnTextChanged((e)=>
										  {
												  State.inputText =e;
										  }),
										new Button("Insert")
										  .OnClicked(()=>
										  {
												  this._sqliteNetService.Insert(new TodoItemModel()
												  {
														  Text = State.inputText
												  });
												  SetState (s => s.todo = new ObservableCollection<TodoItemModel>(this._sqliteNetService.Get()));
												  SetState(s=>s.inputText = null);
										  })
								},

								new CollectionView()
								.ItemsSource(State.todo, TodoObject)
								.GridRow(2),
						}
						 .Padding(30)

				};

				public VisualNode TodoObject(TodoItemModel todo)
				{
						return new Border ()
						{
								new Grid ()
								{
										new Label(todo.Text)
											  .HStart()
											  .VCenter(),
										new Button("삭제")
											  .HEnd()
											  .OnClicked(()=>
											  {
													  this._sqliteNetService.Delete(State.todo.FirstOrDefault(x=>x.id == todo.id));
													  SetState (s => s.todo = new ObservableCollection<TodoItemModel>(this._sqliteNetService.Get()));
											  }),
								}
						}
						.StrokeThickness (0.5)
						.HeightRequest (50);
				}
		}
}
