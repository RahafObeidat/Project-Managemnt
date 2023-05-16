using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTOs
{
    public class CreateInvoiceDTO
    {
        public int ProjectId { get; set; }
        public int DeliverableId { get; set; }
        public int ProjectPhaseId { get; set; }
        
        public string InvoiceTitle { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        public List<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
        public List<int> PaymentTermId { get; set; }
    }
}
