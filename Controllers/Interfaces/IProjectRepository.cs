using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IProjectRepository
    {
        public List<Project> GetAllProjects();

        public List<Project> GetProjectManagerProjects(string ProjectManagerId);  //++

        public Project GetProject(int ProjectId);

        public void InsertProject(Project project);

        public void UpdateProject(Project project);

        public void DeleteProject(int ProjectId);


    }
}
