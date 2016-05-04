using Intense.Presentation;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using MonumentApp.Pages;
using MonumentApp.Presentation;

namespace MonumentApp
{
    public sealed partial class Shell : UserControl
    {
        public Shell()
        {
            this.InitializeComponent();

            var vm = new ShellViewModel();
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Forside", PageType = typeof(WelcomePage) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Opret Monument", PageType = typeof(OpretMonumentPage) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Monument", PageType = typeof(MonumentPage) });
            vm.TopItems.Add(new NavigationItem { Icon = "", DisplayName = "Opret Skade", PageType = typeof(SkadePage) });

            vm.BottomItems.Add(new NavigationItem { Icon = "", DisplayName = "Indstillinger", PageType = typeof(SettingsPage) });

            // select the first top item
            vm.SelectedItem = vm.TopItems.First();

            this.ViewModel = vm;
        }

        public ShellViewModel ViewModel { get; private set; }

        public Frame RootFrame
        {
            get
            {
                return this.Frame;
            }
        }
    }
}
