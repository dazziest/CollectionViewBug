using System;
using DataTemplates.Models;

namespace DataTemplates.Controls.Chats;

public class AnimalTemplateSelector: DataTemplateSelector
{
    public DataTemplate ValidTemplate { get; set; }

    public DataTemplate InvalidTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var left = ((Animal)item).Left;

        if (!left)
            return InvalidTemplate;
        else
            return ValidTemplate;
    }
}

