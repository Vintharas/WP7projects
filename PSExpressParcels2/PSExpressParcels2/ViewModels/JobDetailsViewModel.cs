using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PSExpressParcels2;
using PSExpressParcels2.Helpers;
using PSExpressParcels2.Model;


namespace PSExpressParcels2.ViewModels
{
    public class JobDetailsViewModel :INotifyPropertyChanged
    {
        public ICommand AssignCommand { get; set; }
        public ICommand PickupCommand { get; set; }

        public JobDetailsViewModel()
        {
            AssignCommand = new RelayCommand(AssignJob);
            PickupCommand = new RelayCommand(MarkJobAsPickedUp);
        }
        void AssignJob()
        {
            Job.JobStatus = JobStatus.Assigned;
            Job.AssignTime = DateTime.Now;
            Job.DriverId = 1000;
        }

        void MarkJobAsPickedUp()
        {
            Job.JobStatus = JobStatus.PickedUp;
            Job.PickupTime = DateTime.Now;
        }

        private Job job;
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

        
        public ObservableCollection<ParcelViewModel> Parcels
        {
            get
            {
                return
                    Job.Parcels.Select(x => new ParcelViewModel {Parcel = x}).ToObservableCollection<ParcelViewModel>();
            }
        }

        private ParcelViewModel selectedParcel;
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




        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }

         
    }
}