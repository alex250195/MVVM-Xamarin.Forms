using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MVVM.View
{
    public partial class EditarClientePage : ContentPage
    {
        public EditarClientePage(Cliente cliente)
        {
            InitializeComponent();

            BindingContext = new EditarClienteViewModel(cliente);
        }
    }
}
