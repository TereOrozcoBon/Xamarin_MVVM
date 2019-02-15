using System;
namespace InduccionMVVM.ViewModel
{
    public class ProductItemViewModel : BaseViewModel
    {
        public ProductItemViewModel()
        {
        }

        int _Id;
        string _Name;
        DateTime _CreateDate;
        Decimal _Price;
        string _PathImg;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                RaisePropertyChanged();
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged();
            }
        }
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                _CreateDate = value;
                RaisePropertyChanged();
            }
        }

        public Decimal Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                RaisePropertyChanged();
            }
        }
        public string PathImg
        {
            get { return _PathImg; }
            set
            {
                _PathImg = value;
                RaisePropertyChanged();
            }
        }


    }
}
