using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace InduccionMVVM.Views
{
    public partial class ProductTemplate : ContentView //se usa ContentView cuando se va a embeber el XAML como template de una lista  
        //el CONTENT_PAGE puedes igual, embeber un Template y tmbn tener la interfaz
    {
        public ProductTemplate()
        {
            InitializeComponent();
        }
    }
}
