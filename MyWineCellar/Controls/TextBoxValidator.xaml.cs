using MyWineCellar.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar.Controls
{
	public sealed partial class TextBoxValidator : UserControl
	{
		public string Header
		{
			get => (string)this.GetValue(HeaderProperty);
			set => this.SetValue(HeaderProperty, value);
		}

		public static readonly DependencyProperty HeaderProperty =
			DependencyProperty.Register("Header", typeof(string), typeof(TextBoxValidator), new PropertyMetadata(default(string)));

		public string PlaceholderText
		{
			get => (string)this.GetValue(PlaceholderTextTextProperty);
			set => this.SetValue(PlaceholderTextTextProperty, value);
		}

		public static readonly DependencyProperty PlaceholderTextTextProperty =
			DependencyProperty.Register("PlaceholderTextText", typeof(string), typeof(TextBoxValidator), new PropertyMetadata(default(string)));

		public string Text
		{
			get => (string)this.GetValue(TextProperty);
			set => this.SetValue(TextProperty, value);
		}

		public static readonly DependencyProperty TextProperty =
				DependencyProperty.Register("Text", typeof(string), typeof(TextBoxValidator), new PropertyMetadata(default(string)));

		public string InputScope
		{
			get => (string)this.GetValue(InputScopeProperty);
			set => this.SetValue(InputScopeProperty, value);
		}

		public static readonly DependencyProperty InputScopeProperty =
			DependencyProperty.Register("InputScope", typeof(string), typeof(TextBoxValidator), new PropertyMetadata(default(string)));

		public bool IsValidate
		{
			get => (bool)this.GetValue(IsValidateProperty);
			set => this.SetValue(IsValidateProperty, value);
		}

		public static readonly DependencyProperty IsValidateProperty =
				DependencyProperty.Register("IsValidate", typeof(bool), typeof(TextBoxValidator), new PropertyMetadata(default(bool)));

		public TextBoxValidator() => this.InitializeComponent();

		private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
		{
			if (sender is TextBox senderAsString)
			{
				if (string.IsNullOrEmpty(senderAsString.Text))
				{
					this.TextBlock.Visibility = Visibility.Visible;
					this.TextBox.BorderBrush = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000");
					this.IsValidate = false;
				}
				else
				{
					this.TextBlock.Visibility = Visibility.Collapsed;
					this.TextBox.BorderBrush = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
					this.IsValidate = true;
				}
			}
		}
	}
}