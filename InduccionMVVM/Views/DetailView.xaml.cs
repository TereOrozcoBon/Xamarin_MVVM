using System;
using System.Collections.Generic;

using Xamarin.Forms;
using InduccionMVVM.ViewModel;


namespace InduccionMVVM.Views
{
    public partial class DetailView : ContentPage
    {
        //public DetailView(ProductItemViewModel product)
        public DetailView(DetailViewModel detailvm)
        {
            InitializeComponent();
            this.BindingContext = detailvm; //hace el enlace de la vistamodelo desde esta vista
            //this.BindingContext = product;
        }
    }
}
