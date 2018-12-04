using Prism.Navigation;
using Xamarin.Forms;
using MasterDetailPageBehaviorIssue.Controls;
using MasterDetailPageBehaviorIssue.ViewModels;

namespace MasterDetailPageBehaviorIssue.Views
{
   public partial class MainMasterDetailPage : MyMasterDetailPage, IMasterDetailPageOptions
   {
      public MainMasterDetailPage()
      {
         InitializeComponent();
      }

      public bool IsPresentedAfterNavigation => (BindingContext as MainMasterDetailPageViewModel)?.IsPresented ?? IsPresented;
   }
}
