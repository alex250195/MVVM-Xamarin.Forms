//using Android.Media;
using MVVM.DataBase;
using MVVM.Model;
using MVVM.View;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private Usuario usuario;

        private Repository<Usuario> repositorioUsuario;

        public LoginViewModel()
        {
            Usuario = new Usuario();

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

        public bool EnableLogin
        {
            get
            {
                //if (string.IsNullOrEmpty(Usuario.Login))
                //    return false;
                return true;
            }
        }

        private ICommand loginCommand;

        private ICommand cadastroCommand;

        private ICommand codigoCommand;

        private ICommand mediaCommand;

        public ICommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new Command(Login));
            }
        }

        public ICommand CadastroCommand
        {
            get
            {
                return cadastroCommand ?? (cadastroCommand = new Command(Cadastro));
            }
        }

        public ICommand CodigoCommand
        {
            get
            {
                return codigoCommand ?? (codigoCommand = new Command(CodigoBarra));
            }
        }

        public ICommand MediaCommand
        {
            get
            {
                return mediaCommand ?? (mediaCommand = new Command<Xamarin.Forms.Image>(Media));
            }
        }

        public async void Login()
        {
            if(string.IsNullOrEmpty(Usuario.Senha) || string.IsNullOrEmpty(Usuario.Login))
            {
                await Dialog.AlertAsync("Atenção", "Preencha todos os campos!", "Ok");
                return;
            }

            try
            {
                var usu = repositorioUsuario.GetFirstBySpcification<Usuario>(c => c.Login == Usuario.Login && c.Senha == Usuario.Senha);

                if(usu != null)
                {
                    HomePage home = new HomePage();
                    await PushAsync(home);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                await Dialog.AlertAsync("Atenção", "Usuário e/ou senha inválido(s)", "Ok");
            }
        }

        public async void Cadastro()
        {
            CadastrarPage cadastrar = new CadastrarPage();
            await PushAsync(cadastrar);
        }

        public async void CodigoBarra()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
                Codigo = result.Text;
        }
        
        public async void Media(Xamarin.Forms.Image Image1)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Dialog.AlertAsync("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "icon.png"
            });

            if (file == null)
                return;

            await Dialog.AlertAsync("File Location", file.Path, "OK");

            Image1.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }        

        private string codigo;

        public string Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;

                if (codigo == null)
                    return;

                OnPropertyChanged("Codigo");
            }
        }
    }
}
