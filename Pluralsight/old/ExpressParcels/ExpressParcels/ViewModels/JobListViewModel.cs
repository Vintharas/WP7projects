using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ExpressParcels.Model;

namespace ExpressParcels.ViewModels
{
    public class JobListViewModel : INotifyPropertyChanged
    {
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
        private ObservableCollection<JobDetailsViewModel> jobs;

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
        private JobDetailsViewModel selectedJob;
        
        /// <summary>
        /// Test data
        /// </summary>
        public void LoadData()
        {
            Jobs = new ObservableCollection<JobDetailsViewModel>
            {
                new JobDetailsViewModel
                    {
                        Job = new Job
                            {
                                Id = 1,
                                JobStatus = (byte)JobStatus.Open,
                                BookTime = new DateTime(2011, 01, 02),
                                Customer = new Customer{Id=1, FirstName = "John", LastName = "Doe", Phone="755232323"},
                                DriverId = 10,
                                PickupArea = "Upper East Side",
                                PickupFrom = "73 York Street apt5b",
                                PickupTime = null,
                                Parcels = new ObservableCollection<Parcel>
                                              {
                                                  new Parcel {Id=1, SizeClass = "SMALL", DeliverTo="26 Bowert Street", DeliverTime = new DateTime(2011, 01, 03, 10, 30, 0), Picname = "John Doe", Remarks="None"},
                                                  new Parcel {Id=2, SizeClass = "SMALL", DeliverTo="26 Bowert Street", DeliverTime = new DateTime(2011, 01, 03, 10, 30, 0), Picname = "John Doe", Remarks="None"}
                                              }
                            }
                    }
            };
        }

        #region INotifyPropertyChanged
		
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyname)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion    
    }
}