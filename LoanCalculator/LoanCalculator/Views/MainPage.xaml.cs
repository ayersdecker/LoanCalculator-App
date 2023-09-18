namespace LoanCalculator;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void MonthToggle_Toggled(object sender, ToggledEventArgs e)
    {
		MonthLabel.Text = MonthToggle.IsToggled ? "Monthly" : "Bi-Monthly";
    }
}

