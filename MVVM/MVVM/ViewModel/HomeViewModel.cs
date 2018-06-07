using MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private ICommand clienteCommand;

        public ICommand ClienteCommand
        {
            get
            {
                return clienteCommand ?? (clienteCommand = new Command(ClienteMet));
            }
        }

        public async void ClienteMet()
        {
            ClientPage cliente = new ClientPage();
            await PushAsync(cliente);
        }
    }
}
