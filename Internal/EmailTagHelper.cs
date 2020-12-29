using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkMilk.Internal
{
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // base.Process(context, output);
            output.TagName = "a";
            var address = "codermrsoymilk@gmail.com";
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }
    }
}
