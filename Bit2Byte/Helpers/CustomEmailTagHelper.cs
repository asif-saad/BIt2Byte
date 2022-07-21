using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bit2Byte.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {


        public string MyEmail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("email", "email-address");
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
            output.Content.SetContent("Email Us");
        }
    }
}
