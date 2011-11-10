using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ExpressParcels.Model
{
    public class Job : INotifyPropertyChanged
    {
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        private int id;
        
        public DateTime BookTime
        {
            get { return bookTime; }
            set
            {
                if (bookTime != value)
                {
                    bookTime = value;
                    RaisePropertyChanged("bookTime");
                }
            }
        }
        private DateTime bookTime;
        
        public DateTime AssignTime
        {
            get { return assignTime; }
            set
            {
                if (assignTime != value)
                {
                    assignTime = value;
                    RaisePropertyChanged("AssignTime");
                }
            }
        }
        private DateTime assignTime;

        public Customer Customer
        {
            get { return customer; }
            set
            {
                if (customer != value)
                {
                    customer = value;
                    RaisePropertyChanged("Customer");
                }
            }
        }
        private Customer customer;

        public int DriverId
        {
            get { return driverId; }
            set
            {
                if (driverId != value)
                {
                    driverId = value;
                    RaisePropertyChanged("DriverId");
                }
            }
        }
        private int driverId;

        public byte JobStatus
        {
            get { return jobStatus; }
            set
            {
                if (jobStatus != value)
                {
                    jobStatus = value;
                    RaisePropertyChanged("JobStatus");
                }
            }
        }
        private byte jobStatus;

        public string PickupArea
        {
            get { return pickupArea; }
            set
            {
                if (pickupArea != value)
                {
                    pickupArea = value;
                    RaisePropertyChanged("PickupArea");
                }
            }
        }
        private string pickupArea;

        public string PickupFrom
        {
            get { return pickupFrom; }
            set
            {
                if (pickupFrom != value)
                {
                    pickupFrom = value;
                    RaisePropertyChanged("PickupFrom");
                }
            }
        }
        private string pickupFrom;

        public DateTime? PickupTime
        {
            get { return pickupTime; }
            set
            {
                if (pickupTime != value)
                {
                    pickupTime = value;
                    RaisePropertyChanged("PickupTime");
                }
            }
        }
        private DateTime? pickupTime;

        public ObservableCollection<Parcel> Parcels { get; set; }

        private void RaisePropertyChanged(string s)
        {
            throw new System.NotImplementedException();
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Parcel : INotifyPropertyChanged
    {
        public int Id
        {
            get
            {
                return Id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        private int id;

        public string DeliverTo
        {
            get { return deliverTo; }
            set
            {
                if (deliverTo != value)
                {
                    deliverTo = value;
                    RaisePropertyChanged("DeliverTo");
                }
            }
        }
        private string deliverTo;

        public DateTime DeliverTime
        {
            get { return deliverTime; }
            set
            {
                if (deliverTime != value)
                {
                    deliverTime = value;
                    RaisePropertyChanged("DeliverTime");
                }
            }
        }
        private DateTime deliverTime;

        public string Picname
        {
            get { return picname; }
            set
            {
                if (picname != value)
                {
                    picname = value;
                    RaisePropertyChanged("Picname");
                }
            }
        }
        private string picname;

        public string Remarks
        {
            get { return remarks; }
            set
            {
                if (remarks != value)
                {
                    remarks = value;
                    RaisePropertyChanged("Remarks");
                }
            }
        }
        private string remarks;

        public string SizeClass
        {
            get { return sizeClass; }
            set
            {
                if (sizeClass != value)
                {
                    sizeClass = value;
                    RaisePropertyChanged("SizeClass");
                }
            }
        }
        private string sizeClass;

        private void RaisePropertyChanged(string s)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}