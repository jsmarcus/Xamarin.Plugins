using System;
using System.Collections.Generic;
using Plugin.Iconize;
using Xamarin.Forms;

namespace Iconize.FormsSample
{
    public class ModuleWrapper
    {
        private IIconModule _module;

        public ICollection<IIcon> Characters => _module.Characters;

        public String FontFamily => _module.FontFamily;

        private Command _menuItemClick;
        public Command MenuItemClick => _menuItemClick ?? (_menuItemClick = new Command(ExecuteMenuClick));

        public ModuleWrapper(IIconModule module)
        {
            _module = module;
        }

        public async void ExecuteMenuClick()
        {
            await Application.Current.MainPage.DisplayAlert("MenuItem Clicked", $"Current font: {_module.FontFamily}", "Ok");
        }
    }
}
