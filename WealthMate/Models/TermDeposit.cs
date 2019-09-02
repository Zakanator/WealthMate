﻿namespace WealthMate.Models
{
    public class TermDeposit
    {
        public string Provider { get; set; }
        public string CreditRating { get; set; }
        public float MinDeposit { get; set; }
        public float MaxDeposit { get; set; }
        public float LengthInMonths { get; set; }
        public float InterestRate { get; set; }
        public float InfiniteMaxDeposit; // for term deposits with no max deposit
        public float NoMinimumDeposit; // for term deposits with no min deposit
        
        public TermDeposit(string provider, string creditRating, float minDeposit, float maxDeposit, float length, float interestRate)
        {
            Provider = provider;
            CreditRating = creditRating;
            MinDeposit = minDeposit;
            MaxDeposit = maxDeposit;
            LengthInMonths = length;
            InterestRate = interestRate;
        }

        // default for owned term deposit
        public TermDeposit(TermDeposit termDeposit, float amountInvested, float interestDecision)
        { }

        public TermDeposit OwnedTermDeposit(TermDeposit pTermDeposit, float amountInvested, float interestDecision)
        {
            TermDeposit ownedTermDeposit = new TermDeposit(pTermDeposit, amountInvested, interestDecision);

            return ownedTermDeposit;
        }

        public void viewTermDeposits()
        {
            // GUI aspect to view the list of term deposits
        }


        public string toString()
        {
             return Provider+"; "+CreditRating+"; "+MinDeposit+"; "+MaxDeposit+"; "+LengthInMonths+"; "+InterestRate;
        }  


        // Gwen: calculate the returns of the owned term deposit - will this be in this class? 
        // Also we should have incremental calculation e.g. if the user checks 3 months into their 6 month term. 
           
        public double calculateReturns()
        {
            /* double depositReturns = 0.0;
            switch (termDeposit.LengthInMonths)
            {
                case 3:
                    double newRate = interestDecision / 90;
                    break;
                case 6:
                    double newRate = interestDecision / 120;
                    break;
                case 9:
                    double newRate = interestDecision / 270;
                    break;
                case 12:
                    double newRate = interestDecision / 365;
                    break;
                case 18:
                    double newRate = interestDecision / 485;
                    break;
                case 24:
                    double newRate = interestDecision / 730;
                    break;
            }
            depositReturns = newRate * amountInvested;
            return depositReturns; */
        }
    }
}






            // will copy into the database
       /* public List<TermDeposit> termDepositList()
        {
            List<TermDeposit> termDeposits = new List<TermDeposit>();

            termDeposits.Add(new TermDeposit("ANZ", 10000.00, InfiniteMaxDeposit, 3, 2.20));
            termDeposits.Add(new TermDeposit("ANZ", 10000.00, InfiniteMaxDeposit, 6, 2.90));
            termDeposits.Add(new TermDeposit("ANZ", 10000.00, InfiniteMaxDeposit, 9, 2.80));
            termDeposits.Add(new TermDeposit("ANZ", 10000.00, InfiniteMaxDeposit, 12, 2.80));
            termDeposits.Add(new TermDeposit("ASB", 5000.00, 9999.00, 1, 2.00));
            termDeposits.Add(new TermDeposit("ASB", 10000.00, 49999.00, 1, 2.75));
            termDeposits.Add(new TermDeposit("BNZ", 2000.00, 4999.00, 1, 2.80));
            termDeposits.Add(new TermDeposit("Asset Finance", 500, InfiniteMaxDeposit, 1, 3.60));
            termDeposits.Add(new TermDeposit("China Construction Bank", 100000.00, 5000000.00, 1, 2.70));
            termDeposits.Add(new TermDeposit("Co-operative Bank", 2000.00, 9999.00, 1, 2.60));
            termDeposits.Add(new TermDeposit("Co-operative Bank", 10000.00, 49999.00, 1, 2.70));
            termDeposits.Add(new TermDeposit("Co-operative Bank", 50000.00, InfiniteMaxDeposit, 1, 2.70));
            termDeposits.Add(new TermDeposit("Co-operative Bank", 5000.00, InfiniteMaxDeposit, 1, 2.75));
            termDeposits.Add(new TermDeposit("FE Investments", 5000.00, InfiniteMaxDeposit, 1, 4.40));
            termDeposits.Add(new TermDeposit("First Credit Union", 500.00, 9999.00, 1, 3.50));
            termDeposits.Add(new TermDeposit("First Credit Union", 10000.00, 49999.00, 1, 3.50));
            termDeposits.Add(new TermDeposit("First Credit Union", 50000.00, InfiniteMaxDeposit, 1, 3.50));
            termDeposits.Add(new TermDeposit("General Finance", 5000.00, 100000.00, 1, 4.65));
            termDeposits.Add(new TermDeposit("Heartland Bank", 1000.00, InfiniteMaxDeposit, 1, 3.05));
            termDeposits.Add(new TermDeposit("Heretaunga Building Society", 1.00, InfiniteMaxDeposit, 3.60));
            termDeposits.Add(new TermDeposit("HSBC Premier", NoMinimumDeposit, 9999.00, 1, 1.20));
            termDeposits.Add(new TermDeposit("HSBC Premier", 10000.00, 99999.00, 1, 2.20));
            termDeposits.Add(new TermDeposit("HSBC Premier", 100000.00, InfiniteMaxDeposit, 1, 2.40));
            termDeposits.Add(new TermDeposit("Kiwibank", 1000.00, 4999.00, 1, 2.00));
            termDeposits.Add(new TermDeposit("Kiwibank", 5000.00, 9999.00, 1, 2.65));
            termDeposits.Add(new TermDeposit("Kiwibank", 10000.00, 49999.00, 1, 2.75));
            termDeposits.Add(new TermDeposit("Kiwibank", 50000.00, 5000000.00, 1, 2.75));
            termDeposits.Add(new TermDeposit("Kookmin - NZ", 5000.00, 9999.00, 1, 3.20));
            termDeposits.Add(new TermDeposit("Kookmin - NZ", 10000.00, 49999.00, 1, 3.30));
            termDeposits.Add(new TermDeposit("Kookmin - NZ", 50000.00, 99999.00, 1, 3.40));
            termDeposits.Add(new TermDeposit("Kookmin - NZ", 100000.00, InfiniteMaxDeposit, 1, 3.50));
            termDeposits.Add(new TermDeposit("Liberty", 5000.00, 19999.00, 1, 3.60));
            termDeposits.Add(new TermDeposit("Liberty", 20000.00, 99999.00, 1, 3.85));
            termDeposits.Add(new TermDeposit("Liberty", 100000.00, InfiniteMaxDeposit, 1, 4.25));
            termDeposits.Add(new TermDeposit("Napier Building Society", 5000.00, InfiniteMaxDeposit, 1, null));
            termDeposits.Add(new TermDeposit("Nelson Building Society", 5000.00, 250000, 1, 3.20));
            termDeposits.Add(new TermDeposit("NZCU Auckland", 500.00, 9999.00, 1, 2.90));
            termDeposits.Add(new TermDeposit("NZCU Auckland", 10000.00, 500000, 1, 3.10));
            termDeposits.Add(new TermDeposit("NZCU Baywide", 1000.00, 1000000.00, 1, 3.25));
            termDeposits.Add(new TermDeposit("NZCU South", 500.00, 4999.00, 1, 2.25));
            termDeposits.Add(new TermDeposit("NZCU South", 5000.00, 500000.00, 1, 3.25));
            termDeposits.Add(new TermDeposit("Public Trust", 5000.00, 9999.00, 1, 1.00));
            termDeposits.Add(new TermDeposit("Public Trust", 10000.00, 249999.00, 1, 1.00));
            termDeposits.Add(new TermDeposit("Public Trust", 50000.00, 9999.00, 1, 1.00));
            termDeposits.Add(new TermDeposit("Public Trust", 250000.00, InfiniteMaxDeposit, 1, 1.00));
            termDeposits.Add(new TermDeposit("Rabobank", 1000.00, InfiniteMaxDeposit, 1, 2.95));
            termDeposits.Add(new TermDeposit("SBS Bank", 1000.00, 250000.00, 1, 2.75));
            termDeposits.Add(new TermDeposit("TSB Bank", 5000.00, 9999.00, 1, 2.65));
            termDeposits.Add(new TermDeposit("TSB Bank", 10000.00, 25000.00, 1, 2.75));
            termDeposits.Add(new TermDeposit("Wairarapa Bldg Socy", 500.00, 1999.00, 1, 1.50));
            termDeposits.Add(new TermDeposit("Wairarapa Bldg Socy", 2000.00, 4999.00, 1, 2.30));
            termDeposits.Add(new TermDeposit("Wairarapa Bldg Socy", 5000.00, InfiniteMaxDeposit, 1, 3.10));
            termDeposits.Add(new TermDeposit("Westpac", 5000.00, 5000000.00, 1, 2.75));
            termDeposits.Add(new TermDeposit());
            termDeposits.Add(new TermDeposit());

            return termDeposits;
        } */

