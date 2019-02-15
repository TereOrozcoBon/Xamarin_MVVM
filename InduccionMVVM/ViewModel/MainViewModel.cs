using System;
using InduccionMVVM.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace InduccionMVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        readonly iApiService _service;
        List<ProductItemViewModel> _ProductList;
        String _SearchText;
        ICommand _SearchByName;
    //    ICommand _AllProducts;

        public MainViewModel(iApiService service = null) //=null que puede ir opcional vacío
        {
            //si no viene instanciado en el contrsucturo , se crea con la dependencia del servicio
            _service = service ?? DependencyService.Get<iApiService>(); //== si viene nulo, Dependencia del servicio, instanciar

            //dependencia del servicio, significa:
            //hacer la implementación de los métodos de la interfaz, dentro de cada plataforma(Andoris y iOs)  (ejemplo de phone word)
            //aquì lo estamos haciendo en la librerìa de xamarin forms, no en las plataformas;
            //asi ya no es neceasrio moverle a los còdigos en la plataformas; no se hancen funciones propias de las plat, como los intent;
            //sòlo es ejecución y consumo de información
        }

        public async Task Init()
        {
            await LoadData(); //lo primero a ejecutar, para traer la info de la API
        }


        //GET SET:
        public List<ProductItemViewModel> ProductList
        {
            get
            {
                return _ProductList;
            }
            set
            {
                _ProductList = value;
                RaisePropertyChanged();
            }

        }

        public string SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                _SearchText = value;
                RaisePropertyChanged();
            }

        }

        public ICommand SearchByName
        {
            get
            {
                return _SearchByName ?? (_SearchByName = new Command(
                    async () => await ExecuteSearchByNameCommand() //esta es una tarea que hace la invocación por el await
                ));
            }
        }


        public ICommand AllProducts
        {
            get
            {
                return new Command(
                    async () => await ExecuteSearchAllProducts()
                );
            }
        }





        //TASKS (llamadas a API):

        private async Task LoadData(string filter = null)
        {
            IsBusy = true;

            //llamada a la api

            var result = await _service.GetProducts(filter);


            if(result != null)
            {
                //este ProductList  es el que està en lavista como items_source
                ProductList = (from p in result
                               select new ProductItemViewModel
                               {
                                   Id = p.id,
                                   Name = p.Name,
                                   CreateDate = p.CreateDate,
                                   Price = p.Price,
                                   PathImg = p.PathImg
                               }).ToList();
            }


            IsBusy = false;
        }


        public async Task ExecuteSearchByNameCommand()
        {
            await LoadData(SearchText);
        }


        public async Task ExecuteSearchAllProducts()
        {
            this.SearchText = String.Empty;
            await LoadData();
        }



    }
}
