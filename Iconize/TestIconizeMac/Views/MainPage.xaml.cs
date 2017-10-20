using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormsPlugin.Iconize;

namespace TestIconizeMac.Views
{
    public partial class MainPage : IconTabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            Children.Add(new ViewA());
            Children.Add(new ViewB());
            Children.Add(new ViewC());
        }
    }
}
