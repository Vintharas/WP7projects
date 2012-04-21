using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PSExpressParcels2.Model;

namespace PSExpressParcels2.ViewModels
{
    public class JobListViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<JobDetailsViewModel> jobs;
        public ObservableCollection<JobDetailsViewModel> Jobs
        {
            get { return jobs; }
            set
            {
                if (jobs != value)
                {
                    jobs = value;
                    RaisePropertyChanged("Jobs");
                }
            }
        }

        private JobDetailsViewModel selectedJob;
        public JobDetailsViewModel SelectedJob
        {
            get { return selectedJob; }
            set
            {
                if (selectedJob != value)
                {
                    selectedJob = value;
                    RaisePropertyChanged("SelectedJob");
                }
            }
        }

        public void LoadData()
        {
            Jobs = new ObservableCollection<JobDetailsViewModel>
                       {
                           new JobDetailsViewModel
                               {
                                   Job = new Job
                                             {
                                                 Id=1,
                                                 JobStatus = (byte)JobStatus.Open,
                                                 BookTime = new DateTime(2011, 01, 02),
                                                 Customer = new Customer{Id=1, FName="John", LName = "Doe", Phone="555-555555"},
                                                 DriverId = 1,
                                                 PickupArea = "Upper East Side",
                                                 PickupFrom = "73 York Street apt5b",
                                                 PickupTime = null,
                                                 Parcels = new ObservableCollection<Parcel>
                                                               {
                                                                   new Parcel {Id=1, SizeClass = "SMALL", DeliverTo = "26 Bowery Street"},
                                                                   new Parcel {Id=2, SizeClass = "MEDIUM", DeliverTo = "26 Bowert Street"}
                                                               }
                                             }
                               },
                            new JobDetailsViewModel
                                {
                                    Job = new Job
                                             {
                                                 Id=2,
                                                 JobStatus = (byte)JobStatus.Open,
                                                 BookTime = new DateTime(2011, 01, 02),
                                                 Customer = new Customer{Id=1, FName="John", LName = "Doe", Phone="555-555555"},
                                                 DriverId = 1,
                                                 PickupArea = "Brooklyn",
                                                 PickupFrom = "15 Hedgehog Street #14",
                                                 PickupTime = null,
                                                 Parcels = new ObservableCollection<Parcel>
                                                               {
                                                                   new Parcel {Id=1, SizeClass = "LARGE", DeliverTo = "26 Street"},
                                                                   new Parcel {Id=2, SizeClass = "MEDIUM", DeliverTo = "26 Street"}
                                                               }
                                             }
                                }
                       };
            
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propname)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }
}