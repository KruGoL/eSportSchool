using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Facade.Party
{
    public sealed class CurrencyView : IsoNamedView {
        [Required][DisplayName("ISO three letter code")] public new string? Code { get; set; }
        [DisplayName("English name")] public new string? Name { get; set; }
        [DisplayName("Native name")] public new string? Description { get; set; }
    }

    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData>
    {
        protected override Currency toEntity(CurrencyData d) => new(d);
    }
}
