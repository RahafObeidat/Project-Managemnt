using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTOs
{
    public class CreateProjectPhaseDTO
    {
        public string ProjectName { get; set; }

        public int ProjectPhaseId { get; set; }

        [Required(ErrorMessage = "Project Name is Required")]
        public int ProjectId { get; set; }     

        [Required(ErrorMessage = "Phase Name is Required")]
        public int PhaseId { get; set; }

        //[ProjectPhaseStartDate]
        public DateTime StartDate { get; set; }

       
        public DateTime EndDate { get; set; }

        public DateTime DateTime { get; set; }

    }
}
