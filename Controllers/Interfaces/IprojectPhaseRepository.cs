using PMISBLayer.DTO;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IProjectPhaseRepository
    {
        public List<ProjectPhase> GetAllProjectPhase();

        public List<Project> GetAllProjectPhases(string userId);

        public ProjectPhase GetProjectPhaseById(int ProjectPhaseId);

        public void InsertProjectPhase(ProjectPhase projectphase);

        public void UpdateProjectPhase(ProjectPhase projectphase);

        public void DeleteProjectPhase(int ProjectPhaseId);
        //public List<ProjectPhase> GetAllProjectPhasesByProjId(int ProjectId);
        public List<ProjectPhaseDTO> GetAllProjectPhasesByProjId(int ProjectId);
    }
}
