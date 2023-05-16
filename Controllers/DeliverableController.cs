using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMISAppLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;


namespace PMISAppLayer.Controllers
{
    public class DeliverableController : Controller
    {
        private readonly IPhaseRepository phaseRepo;
        private readonly IProjectPhaseRepository projectphaseRepo;
        private readonly IDeliverableRepository deliverableRepo;
        private readonly IProjectRepository projectRepo;


        public DeliverableController(IDeliverableRepository deliverableRepo, IProjectPhaseRepository projectphaseRepo, IPhaseRepository phaseRepo, IProjectRepository projectRepo)
        {
            this.deliverableRepo = deliverableRepo;
            this.projectphaseRepo = projectphaseRepo;
            this.projectRepo = projectRepo;
            this.phaseRepo = phaseRepo;
        }

      
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ProjectPhase> projectPhases = deliverableRepo.GetAllDeliverables(userId);
            return View(projectPhases);
          

           
        }

       
        public IActionResult Details(int Id)
        {
            Deliverable deliverable = deliverableRepo.GetDeliverableById(Id);
            return View(deliverable);
        }
        
        public IActionResult Create()
        {
            ViewBag.Projects = projectRepo.GetAllProjects();



            ViewBag.Phases = phaseRepo.GetAllProjectPhases();
            ViewBag.ProjectPhases = projectphaseRepo.GetAllProjectPhase();
           
          
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDeliverableDTO deliverableDTO)
        {
            Deliverable deliverable = new Deliverable();

            //deliverable.PhaseId = deliverableDTO.PhaseId;
            deliverable.ProjectPhaseId = deliverableDTO.ProjectPhaseId;
            deliverable.DeliverableId = deliverableDTO.DeliverableId;
            deliverable.DeliverableDescription = deliverableDTO.DeliverableDescription;
            deliverable.StartDate = deliverableDTO.StartDate;
            deliverable.EndDate = deliverableDTO.EndDate;
           

            //if (ModelState.IsValid)
            //{
                  deliverableRepo.InsertDeliverable(deliverable);
                
            //}
            return RedirectToAction("Index");
           
        }

        // GET: Deliverable/Edit/5
        public IActionResult Edit(int Id)
        {
            
            Deliverable deliverable = deliverableRepo.GetDeliverableById(Id);
            return View(deliverable);

        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Deliverable deliverable)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    deliverableRepo.UpdateDeliverable(deliverable);

                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }

            return RedirectToAction("Index");
            
           
        }
       
        public IActionResult Delete(int Id)
        {
          
            Deliverable deliverable = deliverableRepo.GetDeliverableById(Id);
            return View(deliverable);
        }
    
        

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int DeliverableId)
        {
            try
            {
                Deliverable deliverable= deliverableRepo.GetDeliverableById(DeliverableId);
                deliverableRepo.DeleteDeliverable(DeliverableId);
              
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
            
            
        
    }


}




