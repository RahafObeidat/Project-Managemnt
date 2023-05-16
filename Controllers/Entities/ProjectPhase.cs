using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
    public class ProjectPhase
    {
        public int ProjectPhaseId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int PhaseId { get; set; }
        public Phase Phase { get; set; }

        public DateTime StartTime { get; set; }

        //public DateTime EndTime { get; set; }

        public DateTime dateTime { get; set; }

        public List<Deliverable> Deliverables { get; set; }






    }
}
