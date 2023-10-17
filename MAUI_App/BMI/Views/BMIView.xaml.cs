using BMI.ViewModels;

namespace BMI.Views;

public partial class BMIView : ContentPage
{
	public BMIView()
	{
		InitializeComponent();
		BindingContext = new BMIViewModel();
	}
}