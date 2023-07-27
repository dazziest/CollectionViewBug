using System;
namespace DataTemplates.Models;

public class Animal
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Details { get; set; }
    public string ImageUrl { get; set; }
    public bool Left { get; set; }

    public override string ToString()
    {
        return Name;
    }
}

