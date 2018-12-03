using Prism;
using Prism.Ioc;
using MasterDetailPageBehaviorIssue.Views;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace MasterDetailPageBehaviorIssue
{
   public partial class App
   {
      public App() : this(null) { }

      public App(IPlatformInitializer initializer) : base(initializer) { }

      protected override async void OnInitialized()
      {
         InitializeComponent();

         await NavigationService.NavigateAsync($"/{nameof(MainMasterDetailPage)}/{nameof(NavigationPage)}/{nameof(PopoverPage)}");
      }

      protected override void RegisterTypes(IContainerRegistry containerRegistry)
      {
         containerRegistry.RegisterForNavigation<NavigationPage>();
         containerRegistry.RegisterForNavigation<MainMasterDetailPage>();
         containerRegistry.RegisterForNavigation<PopoverPage>();
         containerRegistry.RegisterForNavigation<SplitPage>();
      }
   }
}
