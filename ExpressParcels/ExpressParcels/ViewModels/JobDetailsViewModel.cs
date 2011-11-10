using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ExpressParcels.Helpers;
using ExpressParcels.Model;

namespace ExpressParcels.ViewModels
{
    public class JobDetailsViewModel : INotifyPropertyChanged
    {


        public Job Job
        {
            get { return job; }
            set
            {
                if (job != value)
                {
                    job = value;
                    RaisePropertyChanged("Job");
                }
            }
        }
        private Job job;

        public ObservableCollection<ParcelViewModel> Parcels { get
        {
            return Job.Parcels.Select(p => new ParcelViewModel {Parcel = p})
                .ToObservableCollection<ParcelViewModel>();
        } }

        public ParcelViewModel SelectedParcel
        {
            get { return selectedParcel; }
            set
            {
                if (selectedParcel != value)
                {
                    selectedParcel = value;
                    RaisePropertyChanged("SelectedParcel");
                }
            }
        }
        private ParcelViewModel selectedParcel;

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