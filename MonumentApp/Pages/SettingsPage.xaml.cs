﻿using System;
using Windows.UI.Xaml.Controls;
using MonumentApp.Presentation;

namespace MonumentApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();

            this.ViewModel = new SettingsViewModel();
        }

        public SettingsViewModel ViewModel { get; }
    }
}
