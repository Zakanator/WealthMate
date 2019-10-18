﻿using System;
using System.Collections.ObjectModel;

namespace WealthMate.Models
{
    public class Portfolio
    {
        public ObservableCollection<OwnedAsset> OwnedAssets { get; }
        public  float CurrentTotal { get; set; }
        public float TotalReturn { get; set; }
        public float PrincipalTotal { get; set; }
        public float TotalReturnRate { get; set; }
        public float ReturnGoal { get; set; }
        public float ReturnGoalProgress { get; set; }
        public bool PositiveTotal { get; set; }             //Flag for view trigger purposes

        public Portfolio()
        {
            OwnedAssets = new ObservableCollection<OwnedAsset>();
            ReturnGoal = 0;
            UpdatePortfolio();
        }

        public Portfolio(float returnGoal)
        {
            OwnedAssets = new ObservableCollection<OwnedAsset>();
            ReturnGoal = returnGoal;
            UpdatePortfolio();
        }

        public void AddAsset(OwnedAsset asset)                      //adds asset to portfolio and instantly updates its values
        {
            this.OwnedAssets.Add(asset);
            UpdatePortfolio();
        }

        public void RemoveAsset(OwnedAsset asset)                   //removes asset from portfolio and instantly updates its values
        {
            this.OwnedAssets.Remove(asset);
            UpdatePortfolio();
        }

        public void UpdatePortfolio()
        {
            CalculateUpdatedPortfolioTotals();
            CalculateTotalReturn();

            if(ReturnGoal != 0)
                ReturnGoalProgress = (TotalReturn / ReturnGoal) * 100;       //Updates how close the return value is to reaching its return goal
        }

        private void CalculateTotalReturn()
        {
            TotalReturnRate = ((CurrentTotal - PrincipalTotal) / PrincipalTotal) * 100;

            if (TotalReturnRate > 0f)                                       //Flag for XAML code (green or red colours)
                PositiveTotal = true;
            else
                PositiveTotal = false;
        }

        private void CalculateUpdatedPortfolioTotals()
        {
            CurrentTotal = 0;                                   //sets values to zero so totals can be calculated again
            PrincipalTotal = 0;
            TotalReturn = 0;
            TotalReturnRate = 0;

            foreach (OwnedAsset asset in OwnedAssets)
            {
                asset.UpdateOwnedAsset();                       //Iterates through each owned asset and makes sure its updated before calculating
                CurrentTotal += asset.CurrentValue;
                PrincipalTotal += asset.PrincipalValue;
                TotalReturn += asset.TotalReturn;
            }
        }
    }

}