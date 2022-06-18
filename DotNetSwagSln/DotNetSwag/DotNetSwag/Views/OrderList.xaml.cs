using DotNetSwag.Models;
using DotNetSwag.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DotNetSwag
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderList : ContentPage
    {
        public OrderList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            OrderDetailsDatabase database = OrderDetailsDatabase.Instance;
            detailsView.ItemsSource = database.GetOrder();
        }
        private async void detailsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new OrderDetailsPage
                {
                    BindingContext = e.SelectedItem as OrderDetails
                });
            }
        }
    }
}