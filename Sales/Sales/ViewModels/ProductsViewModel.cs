namespace Sales.ViewModels
{
    using Common.Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        //atributo privado para el item que se va actualizar.'"

        private ApiService apiService;
        private ObservableCollection<Product> products;
        private bool isRefreshing;


        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {

            this.IsRefreshing = true;

            var response = await this.apiService.GetList<Product>("https://salesapisam.azurewebsites.net", "/api", "/Products");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("FUCKING ERROR", response.Message, "OK");
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
            this.IsRefreshing = false;

        }

        public ICommand RefreshCommand
        {
            get
            {
                return this.refreshCommand;
            }
        }





    }
}
