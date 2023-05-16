using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.DTO;

using PMISBLayer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper;

namespace PMISBLayer.Repositories
{
    public class ProjectPhaseRepository : IProjectPhaseRepository
    {
        private readonly ApplicationDbContext context;

        private readonly IMapper mapper;

        public ProjectPhaseRepository(ApplicationDbContext context ,IMapper mapper)
        {
            this.context = context;

            this.mapper = mapper;
        }

        public List<ProjectPhase> GetAllProjectPhase()
        {
            return context.ProjectPhases.ToList();
        }

        public List<Project> GetAllProjectPhases(string userId)
        {
            return context.Projects.Include(x => x.ProjectPhases).ThenInclude(y => y.Phase).ToList();
            //return context.ProjectPhases.Where(x => x.ProjectPhaseId == ProjectPhaseId).ToList();
        }

        public ProjectPhase GetProjectPhaseById(int ProjectPhaseId)
        {
            return context.ProjectPhases.SingleOrDefault(x => x.ProjectPhaseId == ProjectPhaseId);
        }
        public void InsertProjectPhase(ProjectPhase projectphase)
        {
            context.ProjectPhases.Add(projectphase);
            context.SaveChanges();
        }

        public void DeleteProjectPhase(int ProjectPhaseId)
        {

            ProjectPhase projectphase = context.ProjectPhases.Find(ProjectPhaseId);

            if (projectphase != null)
            {
                context.ProjectPhases.Remove(projectphase);
                context.SaveChanges();
            }

        }
        public void UpdateProjectPhase(ProjectPhase projectphase)
        {
            context.ProjectPhases.Update(projectphase);
            context.SaveChanges();
        }



        public List<ProjectPhaseDTO> GetAllProjectPhasesByProjId(int ProjectId)
        {

            List<ProjectPhase> projectPhase = new List<ProjectPhase>();
            Project project = new Project();

            List<ProjectPhaseDTO> projectPhaseDTO = new List<ProjectPhaseDTO>();
            try
            {
                projectPhase = context.ProjectPhases.Include(x=>x.Phase).Where(x => x.ProjectId == ProjectId).OrderBy(x => x.PhaseId).ToList();



                var proj = mapper.Map<List<ProjectPhase>, List<ProjectPhaseDTO>>(projectPhase);



                projectPhaseDTO = proj.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return projectPhaseDTO;
            //return context.ProjectPhases.Where(x => x.ProjectPhaseId == ProjectPhaseId).ToList();
        }

    }
}
