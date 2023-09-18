using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    public class PaymentModel
    {
        // Properties
        public int PaymentNumber { get; set; }
        public double PaymentAmount { get; set; }
        public double InterestPaid { get; set; }
        public double PrincipalPaid { get; set; }
        public double StartBalance { get; set; }
        public double NewBalance { get; set; }

        // Constructor
        public PaymentModel(int paymentNumber, double paymentAmount, double interestPaid, double principalPaid, double startBalance, double newBalance)
        {
            PaymentNumber = paymentNumber;
            PaymentAmount = paymentAmount;
            InterestPaid = interestPaid;
            PrincipalPaid = principalPaid;
            StartBalance = startBalance;
            NewBalance = newBalance;
        }

    }
}
