using PMISAppLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IDeliverableRepository
    {
        public List<ProjectPhase> GetAllDeliverables(string DeliverableId);

        public Deliverable GetDeliverableById(int Deliverable);

        public void InsertDeliverable(Deliverable deliverable);

        public void UpdateDeliverable(Deliverable deliverable);

        public void DeleteDeliverable(int DeliverableId);


        public List<DeliverableDTO> GetDeliverablesByPhaseId(int ProjectPhaseId);





    }
}
