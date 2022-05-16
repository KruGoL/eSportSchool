using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using eSportSchool.Facade;

namespace eSportSchool.Pages.Extensions {
    public static class ShowTableHtml
    {
        public static IHtmlContent ShowTable<TModel, TView>(
            this IHtmlHelper<TModel> h, IList<TView>? items ,string? imgPath = null)
                where TModel : IIndexModel<TView> where TView : UniqueView {
            var s = htmlStrings(h, items , imgPath);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel, TView>(IHtmlHelper<TModel> h, IList<TView>? items , string? imgPath = null)
            where TModel : IIndexModel<TView> where TView : UniqueView {
            var m = h.ViewData.Model;
            var l = new List<object> {
                new HtmlString("<table class=\"table\">"),
                new HtmlString("<thead>"),
                new HtmlString("<tr>")
            };
            foreach (var name in m.IndexColumns) {
                l.Add(new HtmlString("<td>"));               
                l.Add(h.MyTabHdr(m.DisplayName(name)));
                l.Add(new HtmlString("</td>"));
            }
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</tr>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            foreach (var item in items ?? new List<TView>()) {
                l.Add(new HtmlString("<tr>"));
                foreach (var name in m.IndexColumns) {
                    l.Add(new HtmlString("<td>"));
                    var val = m.GetValue(name, item)?.ToString();
                    if (isImg(val))
                    {                            
                        l.Add(new HtmlString($"<img class=\"rounded mx - auto d - block\""));
                        l.Add(new HtmlString($"src =\"img/{imgPath}/{val}\""));
                        l.Add(new HtmlString($"width =\"100\""));
                        l.Add(new HtmlString($"height =\"125\""));
                        l.Add(new HtmlString($"asp - append - version =\"true\""));
                        l.Add(new HtmlString($"asp -append-version=\"true\" />"));
                    }
                    else l.Add(h.Raw(m.GetValue(name, item)));                                                                                
                    l.Add(new HtmlString("</td>"));
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
        private static bool isImg (string? str)
        {
            if(str?.Length > 4)
            {
                string s = str.Substring(str.Length - 4);
                if (s == ".jpg" || s == ".png")
                {
                    return true;
                }
            }
            return false;
        }
    }
}





