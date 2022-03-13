using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Demo.Core.MvcUI.TagHelpers
{
    //custom sayfalama icin kullanacagımı taghelper yapısıdır. html içerisinde bu yapı kullanılacaktır...mırat
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }

        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        [HtmlAttributeName("current-category")]
        public int GetCurrentCategory { get; set; }

        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='pagination'>");
            for (int i = 1; i < PageCount; i++)
            {
                stringBuilder.AppendFormat("<li class='{0}'>", i == CurrentPage ? "active" : "");
                stringBuilder.AppendFormat("<a href='/product/index?page={0}&category={1}'>{2}>", i, GetCurrentCategory, i);
                stringBuilder.Append("</li>");


            }
            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }



    }
}
