using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{


    public class ProjectTypeRepository : IProjectTypeRepository
    {
        private readonly ApplicationDbContext context;

        public ProjectTypeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ProjectType> GetAllProjectTypes()
        {
            return context.ProjectTypes.ToList();
        }

       
    }
}
