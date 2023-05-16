using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories 
{
    public class PhaseRepository : IPhaseRepository
    {
        private readonly ApplicationDbContext context;

        public PhaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Phase> GetAllProjectPhases()
        {
            return context.Phases.ToList();
        }

        public ProjectPhase GetAllPhasesById(int PhaseId)
        {
            return context.ProjectPhases.SingleOrDefault(x => x.PhaseId == PhaseId);
        }

        public void UpdatePhase(Phase phase)
        {
            context.Phases.Update(phase);
            context.SaveChanges();
        }

    }
}
