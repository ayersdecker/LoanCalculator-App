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
        public List<PaymentModel> Payments { get; set; }

        //public double NumberOfPayments => Payments.Count;
        public double MonthlyPayment => Payments.Sum(x => x.PaymentAmount) / Payments.Count;
        //public double TotalInterestPaid => Payments.Sum(x => x.InterestPaid);
        //public double TotalPrincipalPaid => Payments.Sum(x => x.PrincipalPaid);
       // public double TotalPaid => TotalInterestPaid + TotalPrincipalPaid;

        // Constructor
        public ScheduleModel(double loanAmount, double interestRate, int loanTerm, bool isBiWeekly)
        {
            LoanAmount = loanAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
            IsBiWeekly = isBiWeekly;
            Payments = GeneratePayments();
        }

        // Method
        public List<PaymentModel> GeneratePayments()
        {
            List<PaymentModel> payments = new List<PaymentModel>();

            // MATH GOES HERE
            // FOMULA: M = P * r/(1-(1+r)^-n          M = monthly payments
            //                                       P = Principal
            //                                       n = number of payments (loan year total * 12)
            //                                       r = monthly interest rate (Interest Rate/total payments)
            //
            // MonthlyPayment = (LoanAmount * InterestRate) / (1 - (Math.Pow(1 + ((InterestRate / 100) / 12), NumberOfPayments * -1)));

            int paymentYearCount = IsBiWeekly ? 26 : 12;
            int totalPayments = paymentYearCount * LoanTerm;

            double principle = LoanAmount;
            double principleTal = principle / totalPayments;
            double principleLeft = principle;

            double interestTotal = InterestRate * LoanAmount;
            double interestTal = interestTotal / totalPayments;
            double interestLeft = interestTotal;

            double totalToPay = interestTotal + LoanAmount;
            double totalLeft = totalToPay;
            double totalTal = totalToPay;

            double averagePayment = totalToPay / totalPayments;
            
            for(int i = 0; i < totalPayments; i++)
            {
                principleLeft = principleLeft - principleTal;
                interestLeft = interestLeft - interestTal;
                totalLeft = totalLeft - totalTal;
                payments.Add(new PaymentModel(i+1, averagePayment, interestTotal - interestLeft, averagePayment - interestTal, totalLeft + averagePayment, totalLeft));
            }

            return payments;
        }

    }
}
