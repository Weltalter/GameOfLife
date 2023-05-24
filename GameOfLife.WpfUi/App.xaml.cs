using System;
using System.Windows;
using GameOfLife.Domain;
using GameOfLife.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace GameOfLife.WpfUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ////private readonly ServiceProvider _serviceProvider;

        ////public App()
        ////{
        ////    var serviceCollection = new ServiceCollection();
        ////    ConfigureServices(serviceCollection);

        ////    _serviceProvider = serviceCollection.BuildServiceProvider();
        ////}

        ////private void ConfigureServices(IServiceCollection services)
        ////{
        ////    services.AddSingleton<MainWindow>();
        ////}

        ////private void App_OnStartup(object sender, StartupEventArgs e)
        ////{
        ////    var mainWindow = _serviceProvider.GetService<MainWindow>();
        ////    mainWindow.Show();
        ////}
        ///

        public App()
        {
            Init();
            /* Some other initialization stuff */
        }

        public IServiceProvider Container { get; private set; }

        void Init()
        {
            var host = Host
              .CreateDefaultBuilder()
              .ConfigureServices(services =>
              {
                  services.UseMicrosoftDependencyResolver();
                  var resolver = Locator.CurrentMutable;
                  resolver.InitializeSplat();
                  resolver.InitializeReactiveUI();

                  // Configure our local services and access the host configuration
                  ConfigureServices(services);
              })
              .UseEnvironment(Environments.Development)
              .Build();

            // Since MS DI container is a different type,
            // we need to re-register the built container with Splat again
            Container = host.Services;
            Container.UseMicrosoftDependencyResolver();
        }

        void ConfigureServices(IServiceCollection services)
        {
            // register your personal services here, for example
            //services.AddSingleton<MainViewModel>(); //Implements IScreen

            // this passes IScreen resolution through to the previous viewmodel registration.
            // this is to prevent multiple instances by mistake.
            //services.AddSingleton<IScreen, MainViewModel>(x => x.GetRequiredService<MainViewModel>());

            services.AddSingleton<IViewFor<MainViewModel>, MainWindow>();
            services.AddSingleton<IViewFor<ClassicGameGridViewModel>, ClassicGameGridView>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ClassicGame>(s => ClassicGame.Default);
            services.AddSingleton<ClassicGameRules>(s => ClassicGameRules.Instance);

            //alternatively search assembly for `IRoutedViewFor` implementations
            //see https://reactiveui.net/docs/handbook/routing to learn more about routing in RxUI
            //services.AddTransient<IViewFor<SecondaryViewModel>, SecondaryPage>();
            //services.AddTransient<SecondaryViewModel>();
        }
    }
}
