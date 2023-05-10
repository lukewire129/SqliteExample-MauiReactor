using Microsoft.Extensions.Logging;

namespace SqliteExample
{
		public static partial class MauiProgram
		{
				public static MauiApp CreateMauiApp()
				{
						var builder = MauiApp.CreateBuilder ();
						builder.UseMauiReactorApp<MainPage> (app =>
							   {
									   app.AddResource ("Resources/Colors.xaml");
									   app.AddResource ("Resources/Styles.xaml");
									   app.AddResource ("Resources/AppStyles.xaml");

									   app.SetWindowsSpecificAssectDirectory ("Assets");
							   })
#if DEBUG
                   .EnableMauiReactorHotReload()
#endif
							   .ConfigureFonts (fonts =>
							   {
									   fonts.AddFont ("OpenSans-Regular.ttf", "OpenSansRegular");
									   fonts.AddFont ("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
							   });

						builder.Services.AddSingleton (SemanticScreenReader.Default);

#if DEBUG
            builder.Logging.AddDebug();
#endif

						return builder.Build ();
				}
		}
}
