using PGPMob.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PGPMob.ViewModels
{
    public class AutenticacaoViewModel : BaseViewModel
    {
        readonly IPGPMobApiService pgpMobApiService;


        public AutenticacaoViewModel(IPGPMobApiService _pgpMobApiService)
        {
            this.pgpMobApiService = _pgpMobApiService;
            LoginCommand = new Command(ExecuteLoginCommand);
            UserName = "admin";
            Password = "drika07";
        }
        
        public Command LoginCommand { get; }

        private async void ExecuteLoginCommand()
        {

            bool isLoginSuccess = false;
            if (IsBusy)
                return;

            IsBusy = true;
        //    LoginCommand.ChangeCanExecute();

            try
            {
                var usuario = await pgpMobApiService.PostValidaUsuario(this.username, this.password);
                isLoginSuccess = usuario != null;
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            catch (System.Net.WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
          //      LoginCommand.ChangeCanExecute();
            }

            if (isLoginSuccess)
            {
                await PushAsync<MainViewModel>();
                if (Device.OS == TargetPlatform.Android)
                    Application.Current.MainPage = new PGPMob.Views.MainPage();
            }
            else
            {
                await DisplayAlert("Erro Autenticação", "Por favor tente novamente", "Ok");
            }
        }


        string username = string.Empty;
        public string UserName
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
    }
}

