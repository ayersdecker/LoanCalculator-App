using LoanCalculator.Models;

namespace LoanCalculator.Views;

public partial class ScheduleView : ContentPage
{
	public ScheduleModel ScheduleModel;
	public ScheduleView(ScheduleModel schedule)
	{
		InitializeComponent();
		// Binding
		ScheduleModel = schedule;
		PaymentCollection.ItemsSource = ScheduleModel.Payments;
	}

    private void Back_Clicked(object sender, EventArgs e)
    {
		// Go back to the main page
		Navigation.PushAsync(new MainPage(), false);
    }
}