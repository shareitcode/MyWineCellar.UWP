﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar
{
    public sealed class NavigationHelper
    {
        private NavigationHelper() { }

        public static Type GetNavigateTo(NavigationViewItem item)
        {
            return (Type)item.GetValue(NavigateToProperty);
        }

        public static void SetNavigateTo(NavigationViewItem item, Type value)
        {
            item.SetValue(NavigateToProperty, value);
        }

        public static readonly DependencyProperty NavigateToProperty = DependencyProperty.RegisterAttached("NavigateTo", typeof(Type), typeof(NavigationHelper), new PropertyMetadata(null));
    }
}