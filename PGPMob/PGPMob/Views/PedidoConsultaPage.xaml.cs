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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidoConsultaPage : ContentPage
    {
        public PedidoConsultaPage()
        {
            InitializeComponent();
            var pgpMobApiService = DependencyService.Get<Services.IPGPMobApiService>();
            BindingContext = new PedidoConsultaViewModel(pgpMobApiService);

        }
        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                //ViewModel.ShowPedidoCommand.Execute(e.SelectedItem);
            }
        }
    }
}
