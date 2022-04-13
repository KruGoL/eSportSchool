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
    public static class ShowTableHtml {
        public static IHtmlContent ShowTable<TModel, TView>(this IHtmlHelper<TModel> h, IList<TView>? items)
                where TModel : IIndexModel<TView> where TView : UniqueView {
            var s = htmlStrings(h, items);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel, TView>(IHtmlHelper<TModel> h, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : UniqueView {
            var m = h.ViewData.Model;
            var l = new List<object>();
            l.Add(new HtmlString("<table class=\"table\">"));
            l.Add(new HtmlString("<thead>"));
            l.Add(new HtmlString("<tr>"));
            foreach (var name in m.IndexColumns) {
                l.Add(new HtmlString("<th>"));
                l.Add(h.MyTabHdr(name));
                l.Add(new HtmlString("</th>"));
            }
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</tr>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            foreach (var item in items ?? new List<TView>()) {
                l.Add(new HtmlString("<tr>"));
                foreach (var name in m.IndexColumns) {
                    l.Add(new HtmlString("<th>"));
                    l.Add(h.Raw(m.GetValue(name, item)));
                    l.Add(new HtmlString("</th>"));
                }
                l.Add(new HtmlString("<td>"));
                l.Add(h.ItemButtons(item.Id));
                l.Add(new HtmlString("</td>"));
                l.Add(new HtmlString("</tr>"));
            }
            l.Add(new HtmlString("</tbody>"));
            l.Add(new HtmlString("</table>"));
            return l;
        }
    }
}
