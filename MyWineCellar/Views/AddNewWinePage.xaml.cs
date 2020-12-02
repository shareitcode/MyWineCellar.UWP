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
			this.SetBehaviorsForRegionTextBox();
			this.SetBehaviorsForAppellationTextBox();
			this.SetBehaviorsForParcelTextBox();
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
								Command = this.AddNewWineViewModel.CheckCountryValidityCommand
							}
						}
				}
			});

		private void SetBehaviorsForRegionTextBox() => Interaction.SetBehaviors(this.TextBoxRegion, new BehaviorCollection
		{
				new EventTriggerBehavior
				{
						EventName = "LostFocus",
						Actions =
						{
								new InvokeCommandAction
								{
										Command = this.AddNewWineViewModel.CheckRegionValidityCommand
								}
						}
				}
		});

		private void SetBehaviorsForAppellationTextBox() => Interaction.SetBehaviors(this.TextBoxApellation, new BehaviorCollection
		{
				new EventTriggerBehavior
				{
						EventName = "LostFocus",
						Actions =
						{
								new InvokeCommandAction
								{
										Command = this.AddNewWineViewModel.CheckAppellationValidityCommand
								}
						}
				}
		});

		private void SetBehaviorsForParcelTextBox() => Interaction.SetBehaviors(this.TextBoxParcelle, new BehaviorCollection
		{
				new EventTriggerBehavior
				{
						EventName = "LostFocus",
						Actions =
						{
								new InvokeCommandAction
								{
										Command = this.AddNewWineViewModel.CheckParcelValidityCommand
								}
						}
				}
		});
	}
}