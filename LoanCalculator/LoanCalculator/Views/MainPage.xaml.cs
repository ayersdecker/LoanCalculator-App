﻿

using LoanCalculator.Models;
using LoanCalculator.Views;

namespace LoanCalculator;

public partial class MainPage : ContentPage
{
    // The loan period is set by the radio buttons
    public int LoanPeriod = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void MonthToggle_Toggled(object sender, ToggledEventArgs e)
    {
        // Change the label based on the toggle
		MonthLabel.Text = MonthToggle.IsToggled ? "Monthly" : "Bi-Weekly";
    }

    private void CreateButton_Clicked(object sender, EventArgs e)
    {
        // Get the values from the form
        double loanAmount = double.Parse(LoanAmount.Text);
        double interestRate = double.Parse(InterestRate.Text);
        int loanPeriod = LoanPeriod;
        bool monthly = MonthToggle.IsToggled;

        // Build a ScheduleModel object and pass it to the ScheduleView
        ScheduleModel schedule = new ScheduleModel(loanAmount, interestRate, loanPeriod, monthly);
        Navigation.PushAsync(new ScheduleView(schedule), false);
    }

    private void ClearForm(object sender, EventArgs e)
    {
        // Clear the form
        LoanAmount.Text = string.Empty;
        InterestRate.Text = string.Empty;
        MonthToggle.IsToggled = false;
        Payment.Text = string.Empty;
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Set the loan period based on the radio button that was checked
        LoanPeriod = (int)((RadioButton)sender).Value;
    }
}

