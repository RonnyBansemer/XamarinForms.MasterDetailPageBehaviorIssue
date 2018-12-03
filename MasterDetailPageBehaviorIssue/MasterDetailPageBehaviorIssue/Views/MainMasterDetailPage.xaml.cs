using Prism.Navigation;
using Xamarin.Forms;
using MasterDetailPageBehaviorIssue.ViewModels;

namespace MasterDetailPageBehaviorIssue.Views
{
   public partial class MainMasterDetailPage : MasterDetailPage, IMasterDetailPageOptions
   {
      public MainMasterDetailPage()
      {
         InitializeComponent();
      }

      public bool IsPresentedAfterNavigation => BindingContext != null && CanChangeIsPresented ? (BindingContext as MainMasterDetailPageViewModel).IsPresented : IsPresented;
   }
}
