using DataTemplates.ViewModels;

namespace DataTemplates;

public partial class WithDataTemplateSelectorPage : ContentPage
{
	public WithDataTemplateSelectorPage()
	{
		InitializeComponent();

        BindingContext = new GroupedAnimalsViewModel();
    }
}