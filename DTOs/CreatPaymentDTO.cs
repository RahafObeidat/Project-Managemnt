using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTOs
{
    public class CreatPaymentDTO
    {
        public string PaymentTermTitle{ get; set; }

        public decimal PaymentTermAmount { get; set; }

        public int DeliverableId { get; set; }

    }
}
