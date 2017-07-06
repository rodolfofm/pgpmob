using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PGPMob.Views
{
    public partial class MenuPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MenuPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MenuPageItem>();
            masterPageItems.Add(new MenuPageItem
            {
                Title = "Consulta Pedido",
                IconSource = "contacts.png",
                TargetType = typeof(PedidoConsultaPage)
            });
            masterPageItems.Add(new MenuPageItem
            {
                Title = "Lista Entrega",
                IconSource = "todo.png",
                //TargetType = typeof(TodoListPage)
            });

            listView.ItemsSource = masterPageItems;
        }
        
    }
    public class MenuPageItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}
