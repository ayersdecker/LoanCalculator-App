using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    public class ScheduleModel
    {
        // Properties
        public double LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public bool IsBiWeekly { get; set; }
        
        // Calculated Properties
        public List<PaymentModel> Payments { get { return GeneratePayments(); } }
        public double NumberOfPayments => Payments.Count;
        public double MonthlyPayment => Payments.Sum(x => x.PaymentAmount) / Payments.Count;
        public double TotalInterestPaid => Payments.Sum(x => x.InterestPaid);
        public double TotalPrincipalPaid => Payments.Sum(x => x.PrincipalPaid);
        public double TotalPaid => TotalInterestPaid + TotalPrincipalPaid;

        // Constructor
        public ScheduleModel(double loanAmount, double interestRate, int loanTerm, bool isBiWeekly)
        {
            LoanAmount = loanAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
            IsBiWeekly = isBiWeekly;
        }

        // Method
        public List<PaymentModel> GeneratePayments()
        {
            List<PaymentModel> payments = new List<PaymentModel>();

            // MATH GOES HERE
            //FOMULA: M = P * r/(1-(1+r)^-n          M = monthly payments
            //                                       P = Principal
            //                                       n = number of payments (loan year total * 12)
            //                                       r = monthly interest rate (Interest Rate/total payments)
            //                                       

            MonthlyPayment = (LoanAmount * InterestRate) / (1 - (Math.Pow(1 + ((InterestRate / 100) / 12), NumberOfPayments * -1)));

            return Payments;
        }

    }
}
