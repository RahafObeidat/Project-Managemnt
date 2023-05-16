using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IPhaseRepository
    {

        public List<Phase> GetAllProjectPhases();


        public ProjectPhase GetAllPhasesById(int PhaseId);

        public void UpdatePhase(Phase phase);



    }
}

