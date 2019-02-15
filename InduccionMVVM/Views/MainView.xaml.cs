using System;
using System.Collections.Generic;

using Xamarin.Forms;
using InduccionMVVM.ViewModel;
using System.Threading.Tasks;

namespace InduccionMVVM.Views
{
    public partial class MainView : ContentPage
    {
        MainViewModel _vm;

        public MainView()
        {
            InitializeComponent();

            this.listProducts.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                var product = (ProductItemViewModel)e.SelectedItem;

                var detailViewModel = new DetailViewModel(product);
                var detailView = new DetailView(detailViewModel);

                this.Navigation.PushAsync(detailView); //va al detalle


            };

            _vm = new MainViewModel();
            BindingContext = _vm;

            Task.Run(async () =>
            {
                //ejecuta lo que hay en la VM (lo que hay en el init)
                //que lo que trae allà es la llamada a la api, se trae todos los productos LoadDAta
                //lo fija en productList
                //lo manda a la interfaz
                await _vm.Init();

            });



        }

        /*
        void ListProducts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var product = (ProductItemViewModel)e.SelectedItem;

            //var detailViewModel = new DetailViewModel(product);
            //var detailView = new DetailView(product);

            //this.Navigation.PushAsync(detailView); //va al detalle

            _vm = new MainViewModel();
            BindingContext = _vm;

            Task.Run(async () =>
            {
                //ejecuta lo que hay en la VM (lo que hay en el init)
                //que lo que trae allà es la llamada a la api, se trae todos los productos LoadDAta
                //lo fija en productList
                //lo manda a la interfaz
                await _vm.Init();

            });
        }*/

    }
}
