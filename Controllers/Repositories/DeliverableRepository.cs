using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;

using PMISBLayer.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMISAppLayer.DTOs;
using AutoMapper;

namespace PMISBLayer.Repositories
{
    public class DeliverableRepository : IDeliverableRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public DeliverableRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;

            this.mapper = mapper;
       
        }

        public Deliverable GetDeliverable(int DeliverableId)
        {
            return context.Deliverables.SingleOrDefault(x => x.DeliverableId == DeliverableId);
        }


        public List<ProjectPhase> GetAllDeliverables(string DeliverableId)
        {
            return context.ProjectPhases.Include(x => x.Deliverables).Include(ph=>ph.Phase).ToList();
        }

        public void InsertDeliverable(Deliverable deliverable)
        {
            context.Deliverables.Add(deliverable);
            context.SaveChanges();
        }

        public void DeleteDeliverable(int DeliverableId)
        {
            Deliverable deliverable = context.Deliverables.Find(DeliverableId);
            context.Deliverables.Remove(deliverable);
            context.SaveChanges();
        }
        public void UpdateDeliverable(Deliverable deliverable)
        {
            context.Entry(deliverable).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Deliverable GetDeliverableById(int DeliverableId)
        {
            return context.Deliverables.Find(DeliverableId);
        }

        public List<Deliverable> Deliverables()
        {
            throw new NotImplementedException();
        }

       
        public List<DeliverableDTO> GetDeliverablesByPhaseId(int ProjectPhaseId)
        {

            List<Deliverable> projectPhaseDeliver = new List<Deliverable>();
            Project project = new Project();

            List<DeliverableDTO> projectPhaseDTO = new List<DeliverableDTO>();
            try
            {
                projectPhaseDeliver = context.Deliverables.Include(x => x.ProjectPhase).Where(x => x.ProjectPhaseId == ProjectPhaseId).OrderBy(x => x.DeliverableId).ToList();



                var proj = mapper.Map<List<Deliverable>, List<DeliverableDTO>>(projectPhaseDeliver);



                projectPhaseDTO = proj.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return projectPhaseDTO;
          
        }


    }
}
