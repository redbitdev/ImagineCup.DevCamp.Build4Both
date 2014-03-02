using Build4Both.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


#if !WINDOWS_PHONE
using Windows.UI.Xaml;
namespace Build4Both.WindowsStore
#else
namespace Build4Both
#endif
{
    public partial class App : Application
    {
        private static MainViewModel viewModel = null;

        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new MainViewModel();
               
                return viewModel;
            }
        }
    }
}
