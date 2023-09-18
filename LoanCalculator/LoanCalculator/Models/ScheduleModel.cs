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
        public int NumberOfPayments => Payments.Count;
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

            return Payments;
        }

    }
}
