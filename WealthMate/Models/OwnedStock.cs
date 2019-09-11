﻿using System;

namespace WealthMate.Models
{
    public class OwnedStock : OwnedAsset
    {
        private float _dayReturn;
        private float _dayReturnRate;
        private float _principalValue;
        private float _currentValue;
        private float _currentPrice;
        private float _priceClose;

        public Stock Stock { get; set; }
        public float PurchasedPrice { get; set; }
        public float SharesPurchased { get; set; }
        public float CurrentPrice
        {
            get => _currentPrice;
            set => _currentPrice = Stock.CurrentPrice;
        }
        public float PriceClose
        {
            get => _priceClose;
            set => _priceClose = Stock.PriceClose;
        }
        // Setter should be using value keyword
        // Currently can not set these properties
        public float DayReturn
        {
            get => _dayReturn;
            set => _dayReturn = _currentValue - (_currentPrice * SharesPurchased);
        }

        // Setter should be using value keyword
        // Redundant parentheses
        public float DayReturnRate
        {
            get => _dayReturnRate;
            set => _dayReturnRate = (_dayReturn / _principalValue) * 100;
        }

        // Setter should be using value keyword
        public override float PrincipalValue //total price paid
        {
            get => _principalValue;
            set => _principalValue = PurchasedPrice * SharesPurchased;
        }

        // Setter should be using value keyword
        public override float CurrentValue
        {
            get => _currentValue;
            set => _currentValue = _currentPrice * SharesPurchased;
        }

        // Unnecessary use of base class as nothing is being used from it and first parameter is passing companyname for AssetName
        public OwnedStock(Stock stock, DateTime purchaseDate, float purchasedPrice, float sharesPurchased) : base(stock.CompanyName, purchaseDate, "stock", 0, 0, 0, 0, 0)
        {
            PurchasedPrice = purchasedPrice;
            SharesPurchased = sharesPurchased;
            Stock = stock;
            DayReturn = DayReturn;
            DayReturnRate = DayReturnRate;
        }
    }
}