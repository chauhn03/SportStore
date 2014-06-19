using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder htmlStringBuilder = new StringBuilder();
            for (int index = 1; index <= pagingInfo.TotalPages; index++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", pageUrl(index));
                tagBuilder.InnerHtml = index.ToString();
                if (index == pagingInfo.CurrentPage)
                {
                    tagBuilder.AddCssClass("selected");
                }

                htmlStringBuilder.Append(tagBuilder.ToString() + "  ");
            }
            return MvcHtmlString.Create(htmlStringBuilder.ToString());
        }
    }
}