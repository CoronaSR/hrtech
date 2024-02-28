using HR_Tech_App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HR_Tech_App.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}