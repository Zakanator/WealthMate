﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WealthMate.Views
{
    [DesignTimeVisible(false)]
    public partial class FinancialPage : TabbedPage
    {
        public FinancialPage()
        {
            InitializeComponent();

            NavBarLayout.Children.Add(
                NavBarTitle,
                // Center the text of the titleview
                new Rectangle(0.5, 0.5, 0.9, 1),
                AbsoluteLayoutFlags.All
            );
        }
    }
}