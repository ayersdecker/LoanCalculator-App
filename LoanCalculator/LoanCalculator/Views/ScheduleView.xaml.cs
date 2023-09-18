using LoanCalculator.Models;

namespace LoanCalculator.Views;

public partial class ScheduleView : ContentPage
{
	public ScheduleView(ScheduleModel schedule)
	{
		InitializeComponent();
		PaymentCollection.ItemsSource = schedule.Payments;
	}
}