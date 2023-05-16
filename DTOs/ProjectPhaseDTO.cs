using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
//using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PMISBLayer.DTOs
{
    public class ProjectPhaseDTO //: ProjectPhase
    {
        public int ProjectPhaseId { get; set; }
     

      
        public Phase Phase { get; set; }





        public int ProjectId { get; set; }
       // public List<Project> Projects { get; set; }

      
        public string ProjectName { get; set; }
        public int ProjectTypeId { get; set; }

        
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }

        public List<ProjectPhase> ProjectPhases { get; set; }
        public int PhaseId { get; set; }


      //  public List<Attachments> ProjectAttachments { get; set; }//test
       /// public List<IFormFile> AttachmentFile { get; set; }

        public string ProjectManagerId { get; set; }
      //  public ProjectManager ProjectManager { get; set; }
    }
}
