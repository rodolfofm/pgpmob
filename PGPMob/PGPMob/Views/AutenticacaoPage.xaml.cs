using PGPMob.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PGPMob.Views
{
    public partial class AutenticacaoPage : ContentPage
    {
        public AutenticacaoPage()
        {
            InitializeComponent();
            var pgpMobApiService = DependencyService.Get<Services.IPGPMobApiService>();
            BindingContext = new AutenticacaoViewModel(pgpMobApiService);
        }
    }
}
