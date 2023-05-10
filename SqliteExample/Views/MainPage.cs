namespace SqliteExample.Views
{
		internal class MainPageState
		{
				public string CountText { get; set; } = "Current count: 0";
		}

		internal class MainPage : Component<MainPageState>
		{
				int count = 0;

				public override VisualNode Render() => new ContentPage ()
				{
							new VerticalStackLayout()
							{
								new Label("Hello, World!").HCenter()
														  .Style(AppStyle("MauiLabel"))
														  .FontSize(32)
														  .Set(MC.SemanticProperties.HeadingLevelProperty, SemanticHeadingLevel.Level1),
								new Label("Welcome to .NET Multi-platform App UI").HCenter()
																				  .Style(AppStyle("MauiLabel"))
																				  .FontSize(18)
																				  .Set(MC.SemanticProperties.DescriptionProperty, "Welcome to dot net Multi platform App U I")
																				  .Set(MC.SemanticProperties.HeadingLevelProperty, SemanticHeadingLevel.Level1),
								new Label(State.CountText).HCenter()
														  .Style(AppStyle("MauiLabel"))
														  .FontAttributes(MC.FontAttributes.Bold)
														  .FontSize(18),
								new Button("Click me").HCenter()
													  .Style(AppStyle("PrimaryAction"))
													  .OnClicked(IncrementCount)
													  .Set(MC.SemanticProperties.HintProperty, "Counts the number of times you click"),
								new Image("dotnet_bot.png").WidthRequest(310)
														   .HeightRequest(250)
														   .HCenter()
														   .Set(MC.SemanticProperties.DescriptionProperty, "Cute dot net bot waving hi to you!")
							}.VCenter()
							 .Padding(30)
							 .Spacing(25)
				};

				private void IncrementCount()
				{
						count++;
						SetState (s => s.CountText = $"Current count: {count}");
						Services.GetService<ISemanticScreenReader> ()?.Announce (State.CountText);
				}
		}
}
