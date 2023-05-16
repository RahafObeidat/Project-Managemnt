using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ProjectStatusRepository : IProjectStatusRepository
    {
        private readonly ApplicationDbContext context;

        public ProjectStatusRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ProjectStatus> GetAllProjectStatuses()
        {
            return context.ProjectStatuses.ToList();

        }
    }
}
