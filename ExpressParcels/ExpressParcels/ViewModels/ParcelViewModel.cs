using System.ComponentModel;
using ExpressParcels.Model;

namespace ExpressParcels.ViewModels
{
    public class ParcelViewModel : INotifyPropertyChanged
    {

        public Parcel Parcel
        {
            get { return parcel; }
            set
            {
                if (parcel != value)
                {
                    parcel = value;
                    RaisePropertyChanged("Parcel");
                }
            }
        }
        private Parcel parcel;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion   
    }
}