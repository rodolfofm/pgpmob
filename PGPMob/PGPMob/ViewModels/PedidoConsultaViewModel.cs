using PGPMob.Models;
using PGPMob.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PGPMob.ViewModels
{
    public class PedidoConsultaViewModel : BaseViewModel
    {
        readonly IPGPMobApiService pgpMobApiService;
        public PedidoConsultaViewModel(IPGPMobApiService _pgpMobApiService)
        {
            this.pgpMobApiService = _pgpMobApiService;
            SearchResults = new ObservableCollection<Pedido>();
            SearchCommand = new Command(ExecuteConsultaCommand, CanExecuteConsultaCommand);
            ShowPedidoCommand = new Command<Pedido>(ExecuteShowContentCommand);

        }

        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                SetProperty(ref _searchTerm, value);
                SearchCommand.ChangeCanExecute();
                SearchResults.Clear();
            }
        }

        public Command SearchCommand { get; }

        public ObservableCollection<Pedido> SearchResults { get; }

        public Command<Pedido> ShowPedidoCommand { get; }

        private async void ExecuteShowContentCommand(Pedido pedido)
        {
            //await PushAsync<ContentWebViewModel>(content);
        }

        private bool CanExecuteConsultaCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }

        private async void ExecuteConsultaCommand()
        {
            var searchResults = await pgpMobApiService.PostConsultaPedidoAsync(SearchTerm);

            SearchResults.Clear();
            if (searchResults == null)
            {
                await DisplayAlert("MonkeyHub", "Nenhum resultado encontrado.", "Ok");
                return;
            }

            foreach (var searchResult in searchResults)
            {
                SearchResults.Add(searchResult);
            }
        }
    }
}
