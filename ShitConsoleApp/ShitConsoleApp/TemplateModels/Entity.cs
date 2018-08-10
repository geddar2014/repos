using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ShitConsoleApp.TemplateModels
{
    public class Entity
    {
        private string _tableName;
        private string _classDisplayName;
        private string _classDisplayNameShort;
        private string _classDisplayNameLowerShort;

        public string Namespace { get; }

        public string ClassName { get; }

        public KeyType Key { get; }

        public string TableName
        {
            get => string.IsNullOrWhiteSpace(_tableName) ? ClassName + "Set" : _tableName;
            private set => _tableName = value;
        }

        public string ClassDisplayName
        {
            get => string.IsNullOrWhiteSpace(_classDisplayName) ? "" : _classDisplayName;
            private set => _classDisplayName = value ?? "";
        }

        public string ClassDisplayNameShort
        {
            get => string.IsNullOrWhiteSpace(_classDisplayNameShort) ? "" : _classDisplayNameShort;
            private set => _classDisplayNameShort = value ?? "";
        }

        public string ClassDisplayNameLowerShort
        {
            get => string.IsNullOrWhiteSpace(_classDisplayNameLowerShort) ? "" : _classDisplayNameLowerShort;
            private set => _classDisplayNameLowerShort = value ?? "";
        }

        public List<Property> Props { get; }

        public Entity(string nameSpace, string className, KeyType keyType = KeyType.Long,
            List<Property> props = null, string tableName = null, string classDisplayName = null,
            string classDisplayNameShort = null, string classDisplayNameLowerShort = null)

        {
            Namespace = nameSpace;
            ClassName = className;
            Key = keyType;
            TableName = tableName;
            ClassDisplayName = classDisplayName;
            ClassDisplayNameShort = classDisplayNameShort;
            ClassDisplayNameLowerShort = classDisplayNameLowerShort;
            Props = props ?? new List<Property>();
        }
    }
}
