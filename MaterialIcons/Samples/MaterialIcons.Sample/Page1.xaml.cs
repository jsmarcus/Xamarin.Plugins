using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using MaterialIcon = MaterialIcons.FormsPlugin.Abstractions.MaterialIcons;

namespace MaterialIcons.Sample
{
    public class IconModel : INotifyPropertyChanged
    {
        private MaterialIcon _icon;
        public MaterialIcon Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public partial class Page1 : ContentPage
    {
        List<IconModel> icons = new List<IconModel>
        {
            new IconModel { Icon = MaterialIcon.ic_3d_rotation }
        };

        public Page1()
        {
            InitializeComponent();

            BindingList.ItemsSource = icons;
        }
    }
}
