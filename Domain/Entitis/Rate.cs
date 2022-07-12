using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitis
{
    [Table("Rates")]
    public class Rate : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public decimal RateValue { get; set; }

        public Rate()
        {

        }

        public Rate(int id, string currencycode, DateTime effectivedate, decimal value)
        {
            Id = id;
            CurrencyCode = currencycode;
            EffectiveDate = effectivedate;
            RateValue = value;
        }
    }
}
