using MyWineCellar.Helpers;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar.Controls
{
    public sealed partial class ComboBoxValidator : UserControl
    {
        public string Header
        {
            get => (string)this.GetValue(HeaderProperty);
            set => this.SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ComboBoxValidator), new PropertyMetadata(default(string)));

        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<string>), typeof(ComboBoxValidator), new PropertyMetadata(default(string)));

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(ComboBoxValidator), new PropertyMetadata(default(int)));

        public bool IsValidate
        {
            get => (bool)this.GetValue(IsValidateProperty);
            set => this.SetValue(IsValidateProperty, value);
        }

        public static readonly DependencyProperty IsValidateProperty =
                DependencyProperty.Register("IsValidate", typeof(bool), typeof(ComboBoxValidator), new PropertyMetadata(default(bool)));

        public ComboBoxValidator() => this.InitializeComponent();

        private void ComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is ComboBox senderAsCombobox)
            {
                if (senderAsCombobox.SelectedIndex == 0)
                {
                    this.TextBlock.Visibility = Visibility.Visible;
                    senderAsCombobox.BorderBrush = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000");
                    this.IsValidate = false;
                }
                else
                {
                    this.TextBlock.Visibility = Visibility.Collapsed;
                    senderAsCombobox.BorderBrush = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
                    this.IsValidate = true;
                }
            }
        }
    }
}