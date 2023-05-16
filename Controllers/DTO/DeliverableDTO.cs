using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTOs
{
    public class DeliverableDTO
    {
        public int ProjectPhaseId { get; set; }

        public int PhaseId { get; set; }

        //public string PhaseName { get; set; }

        public int DeliverableId { get; set; }      //FK

        public string DeliverableDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

     

    }
}
