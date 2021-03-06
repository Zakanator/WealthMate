﻿using Syncfusion.SfNumericTextBox.XForms;
using WealthMate.Models;
using WealthMate.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Generic;

namespace WealthMate.Views.Markets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDepositListPage
    {
        private int _compoundRate;
        private string _assetName;
        private DateTime _purchaseDate;
        private float _principalValue;
        private float _interestRate;
        private float _length;
        private float _returnGoal; 

        private SearchBar _searchBar;
        private TermDeposit TermDeposit { get; set; }
        public ObservableCollection<TermDeposit> TDList { get; set; }

        public TermDepositListPage()
        {
            TDList = new ObservableCollection<TermDeposit>();
            LoadTermDeposits();
            InitializeComponent();          
        }

        private async void LoadTermDeposits()
        {
            await DataService.FetchTermDepositsAsync();
            TDList = DataService.TermDeposits;
            TermDepositList.ItemsSource = TDList;
        }

        //clears TDList list and re-adds assets to collection
        //this is required due to the return type of OrderBy and OrderByDescending methods
        private void SortList(IEnumerable<TermDeposit> linqResults)
        {
            var observableC = new ObservableCollection<TermDeposit>(linqResults);
            TDList.Clear();

            foreach (var termD in observableC)
            {
                TDList.Add(termD);
            }
        }

        private void DatePicker_Clicked(object sender, EventArgs e)
        {
            Date.IsOpen = !Date.IsOpen;
        }

        public void UpdatePurchaseDate()
        {
            var selectedItem = Date.SelectedItem as ObservableCollection<object>;

            var month = selectedItem?[0].ToString();
            var monthInt = 0;

            switch (month)
            {
                case "Jan":
                    monthInt = 1;
                    break;
                case "Feb":
                    monthInt = 2;
                    break;
                case "Mar":
                    monthInt = 3;
                    break;
                case "Apr":
                    monthInt = 4;
                    break;
                case "May":
                    monthInt = 5;
                    break;
                case "Jun":
                    monthInt = 6;
                    break;
                case "Jul":
                    monthInt = 7;
                    break;
                case "Aug":
                    monthInt = 8;
                    break;
                case "Sep":
                    monthInt = 9;
                    break;
                case "Oct":
                    monthInt = 10;
                    break;
                case "Nov":
                    monthInt = 11;
                    break;
                case "Dec":
                    monthInt = 12;
                    break;
            }

            if (selectedItem != null)
            {
                var day = selectedItem[1].ToString();
                var dayInt = int.Parse(day);

                var year = selectedItem[2].ToString();
                var yearInt = int.Parse(year);

                _purchaseDate = new DateTime(yearInt, monthInt, dayInt);
            }
        }

        // Sorts StockList list according to picker value upon picker index value changing
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;

            if (picker.SelectedIndex == 0)
            {
                SortList(TDList.OrderBy(termD => termD.Provider));
            }
            else if (picker.SelectedIndex == 1)
            {
                SortList(TDList.OrderByDescending(termD => termD.InterestRate));
            }
            else if (picker.SelectedIndex == 2)
            {
                SortList(TDList.OrderBy(termD => termD.MinDeposit));
            }
            else if (picker.SelectedIndex == 3)
            {
                SortList(TDList.OrderBy(termD => termD.LengthInMonths));
            }
        }

        // Search bar functionality

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            _searchBar = sender as SearchBar;

            if (TermDepositList.DataSource != null)
            {
                // Filters the data source
                TermDepositList.DataSource.Filter = FilterTDeposits;
                TermDepositList.DataSource.RefreshFilter();
            }
        }

        // Filtering the list view as text changes within the search bar
        private bool FilterTDeposits(object obj)
        {
            if (_searchBar?.Text == null)
            {
                return true;
            }

            return obj is TermDeposit termD && (termD.Provider.ToLower().Contains(_searchBar.Text.ToLower()));
        }

        // Handles a term deposit being clicked from the term deposit page
        private void TermDepositClicked(object sender, ItemTappedEventArgs e)
        {
            TermDeposit = (TermDeposit)e.ItemData;
            _assetName = TermDeposit.Provider;
            _interestRate = TermDeposit.InterestRate / 100;
            _length = (float)(TermDeposit.LengthInMonths / 0.5);

            AddTDForm.IsOpen = true;
        }

        // Handles when the "Add" button inside the pop-up is clicked to initiate adding the term deposit to the users profile
        private void AddInPopupClicked(object sender, System.EventArgs e)
        {
            if (_principalValue <= 0.0f)
                DisplayAlert(null, "Please enter purchase price!", "OK");
            else
            {
                UpdatePurchaseDate();
                OwnedAsset oa = new OwnedAsset(_assetName, _purchaseDate, "Term Deposit", _principalValue, _interestRate, _length, _compoundRate, 0, _returnGoal);
                ((App)Application.Current).User.Portfolio.AddAsset(oa);
                AddTDForm.IsOpen = false;
            }
        }

        //Handles the "Amount Purchased" field in the term deposit popup being changed by the user
        private void Handle_InvestAmountChanged(object sender, ValueEventArgs e)
        {
            float.TryParse(e.Value.ToString(), out var value);
            _principalValue = value;
        }

        private void Handle_GoalAmountChanged(object sender, ValueEventArgs e)
        {
            float.TryParse(e.Value.ToString(), out var value);
            _returnGoal = value;
        }

        private void Picker_CompoundRateChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                switch (selectedIndex)
                {
                    case 0:
                        _compoundRate = 1;
                        break;
                    case 1:
                        _compoundRate = 2;
                        break;
                    case 2:
                        _compoundRate = 4;
                        break;
                    case 3:
                        _compoundRate = 12;
                        break;
                    default:
                        _compoundRate = 0;
                        break;
                }
            }
        }


    }
}