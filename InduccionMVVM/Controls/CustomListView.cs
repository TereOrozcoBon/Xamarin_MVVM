using System;
using Xamarin.Forms;
using System.Windows.Input;



///* === CLASE REUTILIZABLE ===
/// QUE FUNCIONA EN UN LISTADO DE LISTVIWE Y QUE QUEREMOS ENLAZAR A UNA PAGINA DETALLE
/// Esta clase se usa cuando damos click en el listado de una lista;
/// ese elemento nos retornará ALGO;
/// no está casado con algun modelo, por lo tanto, es genéricoç
/// 

/// 
/// 
namespace InduccionMVVM.Controls
{
    public class CustomListView : ListView
    {
        public CustomListView()
        {
            this.ItemTapped += this.OnItemTapped;
        }



        /// <summary>
        /// /// La PROPIEDAD que retorna, es ENLAZABLE a un evento click de un elemento {binding}
        /// 
        /// </summary>
        public static readonly BindableProperty ItemClickCommandProperty =
            BindableProperty.Create<CustomListView, ICommand>(
                p => p.ItemClickCommand, default(ICommand));


        /// <summary>
        /// este ItemClickCommand se va a poder enlazar a un COMANDO (asi como tmbn se hacen bindings a MODELOS
        /// ESte se va  a poder enlazar a un BOTÒN, o bien a un elemento del LISTVIEW
        /// </summary>
        /// <value>The item click command.</value>
        public ICommand ItemClickCommand
        {
            get { return (ICommand)GetValue(ItemClickCommandProperty); }
            set { SetValue(ItemClickCommandProperty, value); }
        }


        /// <summary>
        /// Ejecuta cuando hace el llamado al comando;
        /// valida si se puede realizar o no la acción
        /// Regresará un objeto, que tampoco se casa a ningùn modelo
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
            {
                this.ItemClickCommand.Execute(e.Item);
            }

            this.SelectedItem = null;
        }

    }
}
