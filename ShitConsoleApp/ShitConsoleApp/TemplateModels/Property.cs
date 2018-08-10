using System;
using System.Collections.Generic;
using System.Text;

namespace ShitConsoleApp.TemplateModels
{
    public class Property
    {
        public Property(string name, string type, Relation relation = Relation.Optional, string displayName = "")
        {
            Name = name;
            DisplayName = displayName;
            Relation = relation;
            Type = type;
        }

        public string Name { get; }

        public string DisplayName { get; }

        public Relation Relation { get; }

        public string Type { get; }

    }
}
