using System;
using System.Text;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder htmlStringBuilder = new StringBuilder();
            for (int index = 1; index <= pagingInfo.TotalPages; index++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(index));
                tag.InnerHtml = index.ToString();
                if (index == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }

                htmlStringBuilder.Append(tag.ToString() + "  ");
            }

            return MvcHtmlString.Create(htmlStringBuilder.ToString());
        }
    }
}