using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wsei.Lab7.TagHelpers
{
    [HtmlTargetElement("alert")]
    public class AlertTagHelper : TagHelper
    {
        public string Color { get; set; }
        public string Type { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var className = "alert";
            var color = (Color == null) ? "primary" : Color;
            className += (Type == null) ? " alert-primary" : $" alert-{Type}";

            output.TagName = "div";
            output.Attributes.Add("class", className);
            output.Attributes.Add("color", color);
        }
    }
}
