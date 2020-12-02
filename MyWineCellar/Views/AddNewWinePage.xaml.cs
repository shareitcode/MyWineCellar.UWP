using Microsoft.Xaml.Interactions.Core;
using Microsoft.Xaml.Interactivity;
using MyWineCellar.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar.Views
{
	internal sealed partial class AddNewWinePage : Page
	{
		private AddNewWineViewModel AddNewWineViewModel { get; } = new AddNewWineViewModel();

		public AddNewWinePage()
		{
			this.InitializeComponent();
			this.DataContext = this.AddNewWineViewModel;
			this.SetBehaviorsForUsersControls();
		}

		private void SetBehaviorsForUsersControls()
		{
			this.SetBehaviorsForProducerTextBox();
			this.SetBehaviorsForCountryTextBox();
		}

		private void SetBehaviorsForProducerTextBox() => Interaction.SetBehaviors(this.TextBoxProducer, new BehaviorCollection
			{
				new EventTriggerBehavior
				{
					EventName = "LostFocus",
					Actions =
						{
							new InvokeCommandAction
							{
								Command = this.AddNewWineViewModel.CheckProducerValidityCommand
							}
						}
				}
			});

		private void SetBehaviorsForCountryTextBox() => Interaction.SetBehaviors(this.TextBoxCountry, new BehaviorCollection
			{
				new EventTriggerBehavior
				{
					EventName = "LostFocus",
					Actions =
						{
							new InvokeCommandAction
							{
								Command = this.AddNewWineViewModel.CheckProducerValidityCommand
							}
						}
				}
			});
	}
}