using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

       

        public int ProjectTypeId { get; set; }      //FK

        public ProjectType ProjectType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProjectStatusId { get; set; } //FK

        public ProjectStatus ProjectStatus { get; set; }

        public List<ProjectPhase> ProjectPhases{ get; set; }

        public decimal ContractAmount { get; set; }

        public string ContractFileName { get; set; }       //++to save file in data base

        public string ContractFileType { get; set; }      // "      "          "

        public byte[] ContractFile { get; set; }         // "        "      "

        public string ProjectManagerId { get; set; }

        public ProjectManager ProjectManager { get; set; }

        //public List<Invoice> invoices { get; set; }


    }
}
