using MVVM.DataBase;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM.ViewModel
{
    public class EditarClienteViewModel : BaseViewModel
    {
        private Cliente cliente;

        private Repository<Cliente> repositorio;
        public EditarClienteViewModel(Cliente cliente)
        {
            repositorio = new Repository<Cliente>();

            this.cliente = cliente;
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;

                if (cliente == null)
                    return;

                OnPropertyChanged("Cliente");
            }
        }

        private ICommand editaCommand;

        public ICommand EditarCommand
        {
            get
            {
                return editaCommand ?? (editaCommand = new Command(EditarCliente));
            }
        }

        public async void EditarCliente()
        {
            try
            {
                repositorio.Update<Cliente>(Cliente);

                PopModalAsync();
            }
            catch (Exception ex)
            {
                await Dialog.AlertAsync(ex.Message, "Erro", "Ok");
            }
        }
    }
}
