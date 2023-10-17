using BMI.Views;

namespace BMI
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY1NTI0NUAzMjMyMmUzMDJlMzBSck5USS93bER5VUltdlNsU2U1czFvTEV6U3hWZUxRdEV5WXZURnRlcThJPQ==");
            InitializeComponent();

            MainPage = new BMIView();
        }
    }
}