using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVC_Proje.Web.TagHelpers
{

    //kullanmak istediğim isimle 
    [HtmlTargetElement("imgth")]
    public class imageThumbnailTagHelper:TagHelper
    {

        public string ImageSrc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            output.Attributes.SetAttribute("src", ImageSrc);

            string style = $"width: {200}px; height: {200}px;";
            output.Attributes.SetAttribute("style", style);
        }
    }
}
