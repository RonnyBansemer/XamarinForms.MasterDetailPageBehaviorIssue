using System;
using Xamarin.Forms;

namespace MasterDetailPageBehaviorIssue.Controls
{
   public class MyMasterDetailPage : MasterDetailPage
   {
      public MyMasterDetailPage()
      {
         PropertyChanged += MyMasterDetailPage_PropertyChanged;
      }

      void MyMasterDetailPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
      {
         // dirty hack, but it works...
         if (e.PropertyName == MasterBehaviorProperty.PropertyName)
         {
            if (!CanChangeIsPresented)
               CanChangeIsPresented = true;
         }
      }
   }
}
