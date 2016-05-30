using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MonumentApp.Hjaelpeklasser
{
    public static class Navigate
    {
        public static void To(Type type)
        {
            Frame frame = ((Window.Current.Content as Shell).RootFrame as Frame);
           frame.Navigate(type);
        }
    }
}
