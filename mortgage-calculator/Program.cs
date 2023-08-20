using System;
using System.Collections.Generic;

namespace MortgageProgram
{
    class Mortgage
    {
        static double purchasePrice, marketValue, downPayment, yearlyHOAFees, annualInterestRate, monthlyIncome;
        static int loanTermLength;

        // Needed computed values
        static bool needsInsurance, loanApproval;
        static double loanInsurance, totalLoan, escrow, monthlyPayment;
        static void Main(string[] args)
        {
            inputs(); //Step 1

            totalLoan = CalculateTotalLoan();
            monthlyPayment = CalculateMonthlyPayments();

            display();
        }
        // Display info
        static void display()
        {
            if (!loanApproval)
            {
                Console.WriteLine("You should look into a better job, larger down payment, or a cheaper home... Goodbye!");
                return;
            }
            Console.WriteLine($"Approved!\n Your loan for {totalLoan} will come out to a monthly cost of ${monthlyPayment}. ");
        }

        // Calculate Loan Amount
        static double CalculateTotalLoan()
        {
            // declare local variables
            double homeDebt = purchasePrice - downPayment, fees, totalLoanAmount, equity;

            fees = (0.01 * homeDebt) + 2500;
            totalLoanAmount = homeDebt + fees;

            // Calculates equity for step 3
            equity = marketValue - totalLoanAmount;

            // Checks and calculates loanInsurance for step 4 & 5
            needsInsurance = equity < (marketValue * 0.1);
            loanInsurance = needsInsurance ? (0.01 * totalLoanAmount) / 12 : 0;

            return totalLoanAmount;
        }
        
        // Calculate Equity Percentage and Value 
        static double CalculateMonthlyPayments()
        {
            double r = (annualInterestRate / 100) / 12, monthlyPayment, monthlyHOA, totalMonthlyPayment, propertyTax, homeOwnersInsurance;
            int n = 12 * loanTermLength; // n is the number of payments over the loan life

            monthlyPayment = totalLoan * (r) * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1);
            
            // Step 6 for the escrow
            propertyTax = marketValue * 0.0125 / 12;
            homeOwnersInsurance = marketValue * 0.0075 / 12;
            monthlyHOA = yearlyHOAFees / 12;
            escrow = propertyTax + monthlyHOA + homeOwnersInsurance;

            // Step 7 calculate the monthly payment
            totalMonthlyPayment = monthlyPayment + loanInsurance + escrow;

            // Step 8 for loan approval
            loanApproval = (totalMonthlyPayment <= (monthlyIncome * .25) );

            return totalMonthlyPayment;
        }
        static void inputs()
        {
            purchasePrice = validInput("Purchase Price");
            marketValue = validInput("Market Value");
            downPayment = validInput("Down Payment");
            yearlyHOAFees = validInput("Yearly HOA Fees");
            annualInterestRate = validInput("Annual Interest Rate");
            monthlyIncome = validInput("Monthly Income", "from your job?");
            loanTermLength = (int)validInput("Length of loan", "in years?");
        }

        static double validInput(string data, string endingStatement = "of your home?")
            {
                try 
                {
                    Console.Write($"What is your {data} {endingStatement}  ");
                    
                    double result = double.Parse(Console.ReadLine());
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"That is not a valid input... {ex.Message} \n&*^%@#T$ Try again for {data}!\n");
                    return validInput(data, endingStatement);
                }
            }
    }
    /* incoming SUDO
    ************ STEP 1 ANALYZE THE PROBLEM ***************************
    -Can calculate loan payments for fixed-rate loans.              (totalLoan double)

    -Can calculate loans for terms of 15 or 30 years.               (15 or 30 bool)

    -Can determine the total loan value as the result of the home’s purchase price, the amount of down payment, and an origination fee of one percent added to the initial loan amount. Additionally, a fee of $2500 for approximate taxes and closing costs on the sale should be included in the total loan amount.
                                                                    (totalLoan takes in purchasePrice | downPayment | originationFee (1% or 1.01 of Loan) | closingTaxesAndCosts ($2500) (included on end for totalLoan))

    -Can display the equity percentage and value of the home owned by the buyer at inception based on purchase price, market value of home and down payment values.
                                                                    (input: purchasePrice | marketValue | downPayment ) (Calculations: equityPercentage | equityValue) (Display: equityPercentage | equityValue)

    -Loan insurance will be required on any loan where the total equity at inception is less than 10% of the current market value of the home (for example, buyer is opening a $450,000 loan but only paying $32,000 in a down payment, and the total market value of the home is $429,500, then the buyer needs to cover the 20,500 deficit between loan amount and home value, plus cover at least 10% of the total loan (45,000), so at least $65,500 down (10% + deficit in home value vs.Â loan value) would be required to avoid paying Loan Insurance).
                                                                    (Input: purchasePrice | marketValue | downPayment ) (Calculate: deficit (diff loanAmount homeValue) | minimumDownPayment ) (Display: "Loan Insurance is (not) required" )

    -The calculation for loan insurance is 1 percent of the initial loan value per year, split into equal payments per year.
    Additional amounts are gathered for yearly HOA fees, this should be calculated for a monthly total based on the yearly fee divided per payment period, and then added to the base payment.
                                                                    (loanInsurance (if required) 1% initial loan value per year / 12)

    -Additional amounts are gathered for Escrow (insurance and taxes). Assume property tax is 1.25 percent yearly split into monthly payments and homeowners insurance is 0.75 percent yearly split into monthly payments, both based off of the current market value of the home at the time of loan inception. As with HOA fees, compute a payment per term period (most likely - monthly) and then add that payment to the total monthly payment value
                                                                    (Escrow (propertyTax | homeownerInsurance))

    -Can determine if the payment is >= 25% of the buyer’s monthly income and use that value to recommend approving or denying the loan. Deny when >=25%, otherwise approve.
                                                                    (Input: monthlyIncome) (Calculation: loanApproval (Deny >= 25% loan) ) (Display: "Approval or Deny" )

    -When the recommendation is to deny, display messages to suggest Placing more money down and Look at buying a more affordable home.
                                                                    if Deny(Display: "try a higher down payment or more affordable home")

    -Monthly payments should have the following attributes
    {
        Base Amount for the loan (principle and interest)
        Escrow amount:
        Homeowner’s Insurance
        Property Tax (1.1% of total home value by year, collected monthly)
        HOA Fees (if any, by year, collected monthly)
        Loan Insurance (if applicable), at 1% of the initial loan value per year
        Hint: You will need to correctly determine the loan amount as described above, based on inputs, so you must start by collecting the correct information. The   instructor will expect your program to take the information and calculate the loan amount, not just take the loan amount directly.
    }

    */

    /**************************STEP 2 DESIGN A SOLUTION************************************
    Step 1: Inputs -
    (double) purchasePrice
    (double) marketValue
    (double) downPayment
    (double) yearlyHOAFee
    (double) annualInterestRate
    (double) monthlyIncome 
    (int) loanTermLength

    STEP 2: Calculate Loan Amount
    (double) totalLoan = CalculateTotalLoan(purchasePrice, downPayment);

    STEP 3: Calculate Equity Percentage and Value
    (double) equityPercentage = CalculateEquityPercentage(downPayment, marketValue);
    (double) equityValue = CalculateEquityValue(downPayment, marketValue);

    STEP 4: Check Loan Insurance Requirement
    (bool) loanInsuranceRequired = CheckLoanInsuranceRequirement(equityPercentage, totalLoan, marketValue);

    STEP 5: Calculate Loan Insurance Amount
    (double) loanInsuranceAmount = CalculateLoanInsuranceAmount(totalLoan);

    STEP 6: Calculate Escrow Amounts
    (double) escrowAmount = CalculateEscrowAmount(marketValue);

    STEP 7: Calculate Total Monthly Payment
    (double) totalMonthlyPayment = CalculateTotalMonthlyPayment(totalLoan, annualInterestRate, yearlyHOAFee, loanInsuranceAmount, escrowAmount);

    STEP 8: Determine Loan Approval
    (string) loanApprovalStatus = DetermineLoanApproval(totalMonthlyPayment, monthlyIncome);

    STEP 9: Display - 
    Display equityPercent, equityValue, loanInsuranceRequired, loanApprovalStatus

    */
}
