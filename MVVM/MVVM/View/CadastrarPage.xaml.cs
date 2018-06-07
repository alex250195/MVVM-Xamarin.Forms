using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MVVM.View
{
    public partial class CadastrarPage : ContentPage
    {
        public CadastrarPage()
        {
            InitializeComponent();

            BindingContext = new CadastrarViewModel();
        }
    }
}
