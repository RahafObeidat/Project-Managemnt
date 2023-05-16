using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IProjectTypeRepository
    {
        public List<ProjectType> GetAllProjectTypes();
    }
}
