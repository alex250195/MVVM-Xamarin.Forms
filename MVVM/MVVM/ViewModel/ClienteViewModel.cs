using MVVM.DataBase;
using MVVM.Model;
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
    public class ClienteViewModel : BaseViewModel
    {
        private Cliente cliente;

        private Repository<Cliente> repositorioCliente;

        public ClienteViewModel()
        {
            cliente = new Cliente();

            repositorioCliente = new Repository<Cliente>();

            Atualizar();
        }

        public void Atualizar()
        {
            ClienteList = repositorioCliente.GetAll<Cliente>().ToList();
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

        private List<Cliente> clienteList;

        public List<Cliente> ClienteList
        {
            get
            {
                return clienteList;
            }
            set
            {
                clienteList = value;
                OnPropertyChanged("ClienteList");
            }
        }

        //public List<Cliente> CarregarListView()
        //{
        //    List<Cliente> cliente = new List<Cliente>();

        //    var dados = repositorioCliente.GetAll<Cliente>();

        //    foreach (var item in dados)
        //    {
        //        cliente.Add(item);
        //    }

        //    return cliente;
        //}

        private ICommand editarCommand;

        public ICommand EditarCommand
        {
            get
            {
                return editarCommand ?? (editarCommand = new Command(EditarCliente));
            }
        }

        public async void EditarCliente()
        {
            try
            {
                EditarClientePage edita = new EditarClientePage(Cliente);
                await PushModalAsync(edita);
            }
            catch (Exception ex)
            {
                await Dialog.AlertAsync(ex.Message, "Erro", "Ok");
            }
        }

        private ICommand cadastrarCommand;

        public ICommand CadastrarCommand
        {
            get
            {
                return cadastrarCommand ?? (cadastrarCommand = new Command(CadastrarCliente));
            }
        }

        public async void CadastrarCliente()
        {
            try
            {
                repositorioCliente.Insert<Cliente>(Cliente);

                await Dialog.AlertAsync("Alerta", "Cadastro efetuado com sucesso!", "Ok");

                Atualizar();
            }
            catch
            {
                await Dialog.AlertAsync("Atenção", "Usuário e/ou senha inválido(s)", "Ok");

            }
        }
    }
}
