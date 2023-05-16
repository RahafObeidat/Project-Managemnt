using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext context;     

        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Project> GetAllProjects()
        {
            return context.Projects.ToList();
        }

        public Project GetProject(int ProjectId)
        {
            return context.Projects.SingleOrDefault(x => x.ProjectId == ProjectId);
        }

        public List<Project> GetProjectManagerProjects(string ProjectManagerId)
        {
            var b = context.Projects.ToList();
           // var a = context.Projects.Where(x => x.ProjectManagerId == ProjectManagerId).ToList();
            return b;
        }

        public void InsertProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
        }

        public void DeleteProject(int ProjectId)
        {
            Project project = context.Projects.Find(ProjectId);
            if (project != null)
            {
                context.Projects.Remove(project);
                context.SaveChanges();
            }
        }
        public void UpdateProject(Project project)
        {
           
            context.Projects.Update(project);
            context.SaveChanges();
        }

      
    }
}
