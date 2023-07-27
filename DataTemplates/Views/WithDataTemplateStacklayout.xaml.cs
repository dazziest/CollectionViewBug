using DataTemplates.ViewModels;

namespace DataTemplates.Views;

public partial class WithDataTemplateStacklayout : ContentPage
{
	public WithDataTemplateStacklayout()
	{
		InitializeComponent();

        BindingContext = new GroupedAnimalsViewModel();
    }
}
