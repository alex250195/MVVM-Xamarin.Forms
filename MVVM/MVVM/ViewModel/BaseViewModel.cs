using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            Dialog = UserDialogs.Instance;
        }

        public IUserDialogs Dialog { get; set; }


        public async Task PushModalAsync(Page page)
        {
            if (App.Navigation != null)
                await App.Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (App.Navigation != null)
                await App.Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (App.Navigation != null)
                await App.Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            if (App.Navigation != null)
                await App.Navigation.PopAsync();
        }

        public void RemoveStackPages(Page exceptedPage = null)
        {
            var existingPages = App.Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page != null && page == exceptedPage)
                    continue;

                App.Navigation.RemovePage(page);
            }
        }

        #region INotifyPropertyChanging implementation

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
