using System;


namespace InduccionMVVM.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Esta clase es BASE; 
        /// utiliza INotifyPropertyChanged permite intercambiar:
        /// MODELO --> VISTA MODELO : datos // con el SET
        /// VISTA MODELO --> VISTA: los enlaces o {bindigns} //con el GET
        /// 
        /// comprende tambièn de un modelo
        /// ésta clase se implementa en los MAIN VIEW como base, para que sea reutilizado
        /// de lo contrario se tendrìa que implementar la interface INotifyPropertyChanged en cada uno de los main view
        /// </summary>



        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;



        /// <summary>
        /// Raises the property changed. PErmite Pêrmite la comunicación entre las 3 capas
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {

            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                RaisePropertyChanged();
            }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                RaisePropertyChanged();
            }
        }

    }
}
