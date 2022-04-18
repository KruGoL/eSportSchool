using eSportSchool.Facade;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSportSchool.Pages.Extensions {
    public static class ItemButtonsHtml {
        public static IHtmlContent ItemButtons<TModel>(
            this IHtmlHelper<TModel> h, string id) {
            var s = htmlStrings(h, id);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel>(IHtmlHelper<TModel> h, string id) {
            var l = new List<object>();
            l.Add(h.MyBtn("Edit", id));
            l.Add(new HtmlString("&nbsp;"));
            l.Add(h.MyBtn("Details", id));
            l.Add(new HtmlString("&nbsp;"));
            l.Add(h.MyBtn("Delete", id));
            return l;
        }
    }
}
