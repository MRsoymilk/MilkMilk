using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Markdig;
using Markdig.SyntaxHighlighting;

namespace MilkMilk.Internal
{
    public class MarkdownTagHelper : TagHelper
    {
        private readonly MarkdownPipeline pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSyntaxHighlighting()
                .Build();
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            var markdown = content.GetContent();
            if (markdown == "")
            {
                Console.WriteLine("markdown is null");
            }
            else
            {
                var html = Parse(markdown);
                output.Content.SetHtmlContent(html);
            }
            
            base.Process(context, output);
        }
        public string Parse(string markdown)
        {
            markdown = markdown.Trim();
            string html = Markdown.ToHtml(markdown, pipeline);
            html = html.Replace("```", "");
            html.Trim();
            return html;
        }
    }
}
