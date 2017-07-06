using PGPMob.Models;
using PGPMob.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PGPMob
{
    public partial class App : Application, ILoginManager
    { 
        public static Models.Usuario UsuarioAutenticado { get; set; }
        public App()
        {
            InitializeComponent();
            
            if (UsuarioAutenticado == null)
                MainPage = new NavigationPage(new PGPMob.Views.AutenticacaoPage());
            else
                MainPage = new NavigationPage(new PGPMob.Views.MainPage());
        }

        #region ILoginManager implementation

        public void ShowRootPage()
        {
            new MainPage();
        }

        public void LogOut()
        {
            UsuarioAutenticado = null;
            new AutenticacaoPage();
        }

        #endregion

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
