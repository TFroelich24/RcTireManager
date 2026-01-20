using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using RcTireManager.Interfaces.Logic;
using RcTireManager.Interfaces.Viewmodels;
using RcTireManager.Viewmodels;

namespace RcTireManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddSingleton<IViewModelHome, ViewModelHome>();
            builder.Services.AddSingleton<ILogicHome, LogicHome>();
            
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();            
            builder.Logging.AddDebug();
#endif            
           
            MauiApp app = builder.Build();
            SetReferenceToLogics(app);
            return app;
        }  

        static void SetReferenceToLogics(MauiApp app)
        {
            app.Services.GetRequiredService<IViewModelHome>().SetReferenceToBusinessLogic(app.Services.GetRequiredService<ILogicHome>());
        }
    }
}
