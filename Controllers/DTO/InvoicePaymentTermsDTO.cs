using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISBLayer.DTO
{
    public class InvoicePaymentTermsDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal ContractAmount { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceTitle { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<int> PaymentTermIds { get; set; }

        public string PaymentTermTitle { get; set; }
        public int PaymentTermId { get; set; }
        public int PaymentTermAmount { get; set; }
        public decimal sumPaymentTermAmount { get; set; }
        public PaymentTerm iptlst { get; set; }



    }
}
