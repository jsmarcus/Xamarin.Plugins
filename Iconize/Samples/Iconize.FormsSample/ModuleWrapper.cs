using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Iconize;
using Xamarin.Forms;

namespace Iconize.FormsSample
{
    public class ModuleWrapper : INotifyPropertyChanged
    {
        #region Commands

        private Command _menuItemClick;
        public Command MenuItemClick => _menuItemClick ?? (_menuItemClick = new Command(ExecuteMenuClick));

        #endregion Commands

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Members

        private IIconModule _module;

        #endregion Members

        #region Properties

        public ICollection<IIcon> Characters => _module.Characters;

        public String FontFamily => _module.FontFamily;

        private Boolean _visibleTest = false;
        public Boolean VisibleTest
        {
            get
            {
                return _visibleTest;
            }
            set
            {
                _visibleTest = value;
                NotifyPropertyChanged();
            }
        }

        #endregion Properties

        public ModuleWrapper(IIconModule module)
        {
            _module = module;
        }

        public void ExecuteMenuClick()
        {
            VisibleTest = !VisibleTest;
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "") => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);
    }
}