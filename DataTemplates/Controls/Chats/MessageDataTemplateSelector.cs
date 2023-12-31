﻿using System;
using DataTemplates.Models;

namespace DataTemplates.Controls.Chats;

public class MessageDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate ValidTemplate = new DataTemplate(() => new ReceivedMessage(new MessageText()));

    public DataTemplate InvalidTemplate = new DataTemplate(() => new SentMessage(new MessageText()));

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var left = ((Animal)item).Left;

        if (!left)
            return InvalidTemplate;
        else
            return ValidTemplate;
    }
}

