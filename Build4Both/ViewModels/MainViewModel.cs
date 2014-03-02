using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
#if WINDOWS_PHONE
using Build4Both.Resources;
#endif
using Build4Both.PCL.Models;
using Build4Both.PCL.Services;
using System.Windows.Input;

namespace Build4Both.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<Snapshot>(
                new SnapshotService().GetSnapshots());
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<Snapshot> Items 
        { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }
#if WINDOWS_PHONE
        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }
#endif
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.IsDataLoaded = true;
        }

        private ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                _SaveCommand = _SaveCommand ?? new RelayCommand(SaveCommandInternal);
                return _SaveCommand;
            }
        }
        private void SaveCommandInternal()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}