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
    public class CadastrarViewModel : BaseViewModel
    {
        private Usuario usuario;
        private Repository<Usuario> repositorioUsuario;

        public CadastrarViewModel()
        {
            usuario = new Usuario();

            repositorioUsuario = new Repository<Usuario>();
        }

        public Usuario Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;

                if (usuario == null)
                    return;

                OnPropertyChanged("Usuario");
            }
        }

        private ICommand cadastroCommand;

        public ICommand CadastroCommand
        {
            get
            {
                return cadastroCommand ?? (cadastroCommand = new Command(Cadastro));
            }
        }

        public async void Cadastro()
        {
            if (Validar())
            {
                repositorioUsuario.Insert<Usuario>(Usuario);

                await Dialog.AlertAsync("Alerta", "Cadastro efetuado com sucesso!", "Ok");

                await PopAsync();

                LoginPage login = new LoginPage();
                await PushAsync(login);
            }
            else
            {
                await Dialog.AlertAsync("Alerta", "Erro ao efetuar o cadastro!", "Ok");
            }
        }

        public bool Validar()
        {
            //if (string.IsNullOrEmpty(Usuario.Sexo))
            //    return false;
            //if (string.IsNullOrEmpty(Usuario.Nascimento.ToString()))
            //    return false;
            //if (string.IsNullOrEmpty(Usuario.Telefone))
            //    return false;
            //if (string.IsNullOrEmpty(Usuario.Email))
            //    return false;

            return true;
        }
    }
}
