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

         if (string.Equals(target, "popover", StringComparison.OrdinalIgnoreCase))
         {
            targetUri = $"{nameof(NavigationPage)}/{nameof(PopoverPage)}";
            targetBehavior = MasterBehavior.Popover;
         }
         else if (string.Equals(target, "split", StringComparison.OrdinalIgnoreCase))
         {
            targetUri = $"{nameof(NavigationPage)}/{nameof(SplitPage)}";
            targetBehavior = MasterBehavior.Split;
         }

         if (string.IsNullOrEmpty(targetUri))
            return;

         MasterBehavior = targetBehavior;

         await NavigationService.NavigateAsync(targetUri);
      }
   }
}
