using System.ComponentModel;
using PSExpressParcels2.Model;

namespace PSExpressParcels2.ViewModels
{
    public class ParcelViewModel : INotifyPropertyChanged
    {


        private Parcel parcel;
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


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }

         
    }
}