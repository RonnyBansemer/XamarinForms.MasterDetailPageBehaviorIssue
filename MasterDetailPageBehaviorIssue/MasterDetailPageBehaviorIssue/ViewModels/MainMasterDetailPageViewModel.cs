using System;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using MasterDetailPageBehaviorIssue.Views;

namespace MasterDetailPageBehaviorIssue.ViewModels
{
   public class MainMasterDetailPageViewModel : ViewModelBase
   {
      public MainMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
      {
      }

      public bool IsPresented { get; set; }

      public MasterBehavior MasterBehavior { get; set; } = MasterBehavior.Popover;

      DelegateCommand<string> _navigateCommand;
      public DelegateCommand<string> NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(OnNavigateExecuted));

      async void OnNavigateExecuted(string target)
      {
         var targetUri = string.Empty;
         var targetBehavior = MasterBehavior;
         var targetPresented = false;

         if (string.Equals(target, "popover", StringComparison.OrdinalIgnoreCase))
         {
            targetUri = $"{nameof(NavigationPage)}/{nameof(PopoverPage)}";
            targetBehavior = MasterBehavior.Popover;
            targetPresented = false;
         }
         else if (string.Equals(target, "split", StringComparison.OrdinalIgnoreCase))
         {
            targetUri = $"{nameof(NavigationPage)}/{nameof(SplitPage)}";
            targetBehavior = MasterBehavior.Split;
            targetPresented = true;
         }

         if (string.IsNullOrEmpty(targetUri))
            return;

         await NavigationService.NavigateAsync(targetUri);

         MasterBehavior = targetBehavior;
         IsPresented = targetPresented;
      }
   }
}
