﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace WealthMate.ViewModels
{
    public class TermDepositConverter : IValueConverter
    {

        // Convert to currency format else return N/A
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null ? "N/A" : $"{value:C0}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}