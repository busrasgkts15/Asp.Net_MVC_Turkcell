using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVC_Proje.Web.TagHelpers
{
    public class ItalicTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<i>");

            output.PostContent.SetHtmlContent("</i>");



        }
    }
}
