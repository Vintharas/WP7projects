using System.ComponentModel;

namespace ExpressParcels.ViewModels
{
    public class JobListViewModel : INotifyPropertyChanged
    {
        
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