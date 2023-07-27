using System.ComponentModel;
using System.Windows.Input;
using DataTemplates.ViewModels;

namespace DataTemplates;

public partial class WithDataTemplateSelectorPage : ContentPage
{
    public ICommand MessageActionMenuCommand { get; }
    public ICommand MessageActionCommand { get; }
    public ICommand MessageTapCommand { get; }
    public ICommand ClearMessageActionMenuCommand { get; }
    public ICommand MessageActionCopyCommand { get; }
    public ICommand MessageActionReplyCommand { get; }
    public ICommand MessageActionMessageInfoCommand { get; }
    public ICommand NavigateToParentMessageIdCommand { get; }
    public ICommand MessageReplyCommand { get; }

    public WithDataTemplateSelectorPage()
	{
        MessageActionMenuCommand = new Command(() => { });

        MessageReplyCommand = new Command(() => { });

        MessageActionCommand = new Command(() => { });

        MessageTapCommand = new Command(() => { });

        ClearMessageActionMenuCommand = new Command(() => { });

        MessageActionCopyCommand = new Command(() => { });

        MessageActionReplyCommand = new Command(() => { });

        MessageActionMessageInfoCommand = new Command(() => { });

        NavigateToParentMessageIdCommand = new Command(() => { });

        InitializeComponent();

        BindingContext = new GroupedAnimalsViewModel();
    }
}