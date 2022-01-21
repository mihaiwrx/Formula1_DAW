using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.DTOs
{
    public class SelectItemDto
    {
        public SelectItemDto() { }
        public SelectItemDto(object value, string label)
        {
            Label = label;
            Value = value;
        }
        public SelectItemDto(object value, string label, string styleClass)
        {
            Label = label;
            Value = value;
            StyleClass = styleClass;
        }

        public string Label { get; set; }
        public object Value { get; set; }
        public string StyleClass { get; set; }
    }
}
