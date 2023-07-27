using DataTemplates.ViewModels;

namespace DataTemplates;

public partial class WithDataTemplatePage : ContentPage
{
    public WithDataTemplatePage()
    {
        InitializeComponent();

        BindingContext = new GroupedAnimalsViewModel();
    }
}

