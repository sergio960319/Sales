namespace Sales.ViewModels
{
    using Common.Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        //atributo privado para el item que se va actualizar.'"
        private ObservableCollection<Product> products;
        private ApiService apiService;

        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }

        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
           var response = await this.apiService.GetList<Product>( "https://salesapisam.azurewebsites.net","/api" ,"/Products");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("FUCKING ERROR" , response.Message, "OK");
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);




        }



    }
}
