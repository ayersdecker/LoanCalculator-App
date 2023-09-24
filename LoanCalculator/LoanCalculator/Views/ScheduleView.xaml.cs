using LoanCalculator.Models;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

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
        //MauiContext.Current.RequestedOrientation = DisplayOrientation.Landscape;
		//DeviceDisplay.Current.MainDisplayInfo.Orientation
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
		// Go back to the main page
		Navigation.PushAsync(new MainPage(), false);
    }
}