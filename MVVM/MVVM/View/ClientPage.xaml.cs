using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MVVM.View
{
    public partial class ClientPage : ContentPage
    {
        public ClientPage()
        {
            InitializeComponent();

            BindingContext = new ClienteViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as ClienteViewModel).Atualizar();
        }
    }
}
