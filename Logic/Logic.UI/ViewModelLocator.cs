
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Logic.UI.ViewModel;

namespace UI.Desktop.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
              
            }
            else
            {
                // Create run time view services and models
                
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ContactOverviewVM>();
            SimpleIoc.Default.Register<NewContactVM>();
            SimpleIoc.Default.Register<EditContactVM>();
            SimpleIoc.Default.Register<MultipleDeleteVM>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public ContactOverviewVM ContactOverviewVM => ServiceLocator.Current.GetInstance<ContactOverviewVM>();
        public NewContactVM NewContactVM => ServiceLocator.Current.GetInstance<NewContactVM>();
        public EditContactVM EditContactVM => ServiceLocator.Current.GetInstance<EditContactVM>();
        public MultipleDeleteVM MultipleDeleteVM => ServiceLocator.Current.GetInstance<MultipleDeleteVM>();



        public static void Cleanup()
        {
            
        }
    }
}