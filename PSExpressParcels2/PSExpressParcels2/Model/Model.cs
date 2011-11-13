using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PSExpressParcels2.Model
{
        public class Job: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public ObservableCollection<Parcel> Parcels { get; set; }

            private int id; 
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

            private DateTime assignTime;
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

            private DateTime bookTime;
            public DateTime BookTime
            {
                get { return bookTime; }
                set
                {
                    if (bookTime != value)
                    {
                        bookTime = value;
                        RaisePropertyChanged("BookTime");
                    }
                }
            }

            private Customer customer;
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

            private int drivedId;
            public int DriverId
            {
                get { return drivedId; }
                set
                {
                    if (drivedId != value)
                    {
                        drivedId = value;
                        RaisePropertyChanged("DriverId");
                    }
                }
            }

            private JobStatus jobStatus;
            public JobStatus JobStatus
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

            private string pickupArea;
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

            private string pickupFrom;
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

            private DateTime? pickupTime;
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
            
            /// <summary>
            /// raise property changed event
            /// </summary>
            /// <param name="property"></param>
            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

        } 

        public enum JobStatus
        {
            Open,
            Assigned,
            Closed,
            PickedUp
        }

        public class Parcel: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private DateTime deliverTime;
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

            private string deliverTo;
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

            private int id;
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

            private string picname;
            public string Pickname
            {
                get { return picname; }
                set
                {
                    if (picname != value)
                    {
                        picname = value;
                        RaisePropertyChanged("Pickname");
                    }
                }
            }

            private string remarks;
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
            
            private string sizeClass;
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



            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                
            }
        }

        public class Customer
        {
            public int Id { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public string Phone { get; set; }
        }
}