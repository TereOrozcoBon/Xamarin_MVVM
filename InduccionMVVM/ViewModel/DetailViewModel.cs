using System;
namespace InduccionMVVM.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        public DetailViewModel(ProductItemViewModel product)
        {
            Product = product;
        }

        ProductItemViewModel _Product;

        public ProductItemViewModel Product
        {
            get { return _Product; }
            set
            {
                _Product = value;
                RaisePropertyChanged();
            }
        }
    }
}
