using GalaSoft.MvvmLight;
using citylist.Model;
using citylist.Helper;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace citylist.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }
        private List<BaseInfo> _province;
        public List<BaseInfo> Province
        {
            get
            {
                return _province;
            }

            set
            {
                if (_province == value)
                {
                    return;
                }

                _province = value;
                RaisePropertyChanged("Province");
            }
        }

        private List<BaseInfo> _city;
        public List<BaseInfo> City
        {
            get
            {
                return _city;
            }

            set
            {
                if (_city == value)
                {
                    return;
                }

                _city = value;
                RaisePropertyChanged("City");
            }
        }
        private List<BaseInfo> _citynext;
        public List<BaseInfo> CityNext
        {
            get
            {
                return _citynext;
            }

            set
            {
                if (_citynext == value)
                {
                    return;
                }

                _citynext = value;
                RaisePropertyChanged("CityNext");
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;

                    Province = new DataItem().ProvinceItem();

                    GetCity = new RelayCommand<BaseInfo>((x) => ExecuteGetCity(x));
                    GetCityNext = new RelayCommand<BaseInfo>((x) => ExecuteGetCityNext(x));
                    ShowMessage = new RelayCommand<string>((x) => ExecuteShowMessage(x));
                });
        }
        public RelayCommand<BaseInfo> GetCity { get; private set; }
        private object ExecuteGetCity(BaseInfo baseinfo)
        {
            if (baseinfo != null)
            {
                a = baseinfo;
                City = new DataItem().CityItem(baseinfo.Name);
            }
            return null;
        }

        public RelayCommand<BaseInfo> GetCityNext { get; private set; }
        private object ExecuteGetCityNext(BaseInfo baseinfo)
        {
            if (baseinfo != null)
            {
                b = baseinfo;
                CityNext = new DataItem().CityNextItem(baseinfo.Id);
            }
            return null;
        }

        public RelayCommand<string> ShowMessage { get; private set; }
        private object ExecuteShowMessage(string str)
        {
            //if (baseinfo != null)
            //{
            //    c = baseinfo;

               System.Windows.MessageBox.Show("AA");
            //}
            return null;
        }
        public BaseInfo a { get; set; }
        public BaseInfo b { get; set; }
        public BaseInfo c { get; set; }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}