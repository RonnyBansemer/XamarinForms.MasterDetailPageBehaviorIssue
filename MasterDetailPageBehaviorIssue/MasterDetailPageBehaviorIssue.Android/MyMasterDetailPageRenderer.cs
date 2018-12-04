using System.Reflection;
using Android.Content;
using MasterDetailPageBehaviorIssue.Controls;
using MasterDetailPageBehaviorIssue.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MyMasterDetailPage), typeof(MyMasterDetailPageRenderer))]
namespace MasterDetailPageBehaviorIssue.Droid
{
   public class MyMasterDetailPageRenderer : MasterDetailPageRenderer
   {
      readonly MethodInfo updateMethod;

      public MyMasterDetailPageRenderer(Context context) : base(context)
      {
         updateMethod = typeof(MasterDetailPageRenderer).GetMethod("UpdateSplitViewLayout", BindingFlags.NonPublic | BindingFlags.Instance);
      }

      protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
      {
         base.OnElementChanged(oldElement, newElement);

         if (oldElement != null)
            oldElement.PropertyChanged -= HandlePropertyChanged;

         newElement.PropertyChanged += HandlePropertyChanged;
      }

      void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
      {
         if (e.PropertyName == MasterDetailPage.MasterBehaviorProperty.PropertyName)
         {
            updateMethod?.Invoke(this, null);
         }
      }
   }
}
