using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace LoanCalculator.Models
{
    
    public class ScheduleModel
    {
        PropertyChangedEventHandler PropertyChanged;

        // Properties
        public double LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public bool IsBiWeekly { get; set; }

        public double MonthlyPayment { get; set; }
       


        double monthlyPayment;


        // Calculated Properties
        public List<PaymentModel> Payments { get; set; }

        //public double NumberOfPayments => Payments.Count;
        //MonthlyPayment = monthlyPayment;//=> Payments.Sum(x => x.PaymentAmount) / Payments.Count;
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

            // Payment Count
            int totalPayments;
            int paymentYearCount = IsBiWeekly ? 26 : 12;
            if(IsBiWeekly)
            {
                LoanTerm = LoanTerm / 2;
                totalPayments = paymentYearCount * LoanTerm;
            }
            else
            {
                totalPayments = paymentYearCount * LoanTerm;
            }
            


            // Principle
            double principle = LoanAmount;
            //double principleTal = principle / totalPayments;
            double principleLeft = principle;


            //step 1. What is the Interest Rate in decimal form?
            //          ans. Interest Rate/100 (e.g., 3.2/100 = .032)
                        double interestRate = InterestRate / 100;

            //step 2. What is the monthly interest rate?
            //          ans. Interest Rate/number of payments in year (e.g., .032/12 = .0026667)
                        double monthlyIntRate = interestRate / paymentYearCount;


            // MATH GOES HERE

            // FORMULA:  M = P * [r(1+r)^n] / [(1+r)^n-1]        M = monthly payments
            //                                                   P = Principal
            //                                                   n = number of payments 
            //                                                   r = monthly interest rate 


            //                         MONTHLY PAYMENT MATH

            //      step 1:
                            double formulaNumerator = 1 + monthlyIntRate;
                            formulaNumerator = Math.Pow(formulaNumerator, totalPayments);
                            formulaNumerator = monthlyIntRate * formulaNumerator;

            //      step 2:
                            double formulaDenominator = 1 + monthlyIntRate;
                            formulaDenominator = Math.Pow(formulaDenominator, totalPayments);
                            formulaDenominator = formulaDenominator - 1;

            //      step 3:
                           monthlyPayment = LoanAmount * (formulaNumerator/formulaDenominator);
                           MonthlyPayment = monthlyPayment;



            //What is the Monthly Interest Payment?
            //          ans. Loan Amount(Principle that is left) * Monthly Interest Rate
                        double monthlyIntPayment = principleLeft * monthlyIntRate;

            //What is the amount of the monthly payment that goes towards principal?
            //          ans. Monthly Payment - monthlyIntPayment
                        double currentMonthPrincPaid = monthlyPayment - monthlyIntPayment;

            //What is the remaining principle after a payment:
            //          ans. The Balance that is Left minus the current month's payment on the principal
                        //principleLeft = principleLeft - currentMonthPrincPaid;


            //What is the total interest paid to date?
            //          ans. Add each monthly payment on the interest
                        double totalIntToDate = monthlyIntPayment;//continues to add in a loop

            
            // Generate Each Payment
            for(int i = 0; i < totalPayments; i++)
            {
                double startingBalance = principleLeft;
                monthlyIntPayment = principleLeft * monthlyIntRate;
                currentMonthPrincPaid = monthlyPayment - monthlyIntPayment;
                totalIntToDate += monthlyIntPayment;
                

                
                payments.Add(new PaymentModel(i+1, monthlyPayment, monthlyIntPayment, currentMonthPrincPaid,startingBalance, principleLeft));

                principleLeft = principleLeft - currentMonthPrincPaid;
            }

            return payments;
        }

    }
}
