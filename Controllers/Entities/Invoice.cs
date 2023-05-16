using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string InvoiceTitle { get; set; }

        public DateTime InvoiceDate { get; set; }

        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }


        //[ForeignKey("ProjectId")]
        //public Project Project { get; set; }  
        //public int? ProjectId { get; set; }
    }


}
