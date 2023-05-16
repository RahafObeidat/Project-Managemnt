using Microsoft.AspNetCore.Mvc;
using PMISAppLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using PMISBLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    public class ProjectPhaseController : Controller
    {

        private readonly IProjectPhaseRepository projectphaseRepo;
        private readonly IProjectRepository projectRepo;
        private readonly IPhaseRepository phaseRepo;


        public ProjectPhaseController(IProjectPhaseRepository projectphaseRepo, IProjectRepository projectRepo, IPhaseRepository phaseRepo)
        {
            this.projectphaseRepo = projectphaseRepo;
            this.projectRepo = projectRepo;
            this.phaseRepo = phaseRepo;
        }


        public IActionResult Index()
        {
            
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                List<Project> projectphases = projectphaseRepo.GetAllProjectPhases(userId);

                //var projectphases = projectphaseRepo.GetAllProjectPhases(userId);
                return View(projectphases);
            

            
        }


        public IActionResult Details(int Id)
        {
            ProjectPhase projectphase = projectphaseRepo.GetProjectPhaseById(Id);
            return View(projectphase);
        }


        public IActionResult Create()
        {
            ViewBag.Projects = projectRepo.GetAllProjects();
            ViewBag.Phases = phaseRepo.GetAllProjectPhases();
           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProjectPhaseDTO projectphaseDTO)
        {
            ProjectPhase projectphase = new ProjectPhase();

            projectphase.PhaseId = projectphaseDTO.PhaseId;
            projectphase.ProjectId = projectphaseDTO.ProjectId;
            //projectphase.ProjectPhaseId = projectphaseDTO.ProjectPhaseId;
            projectphase.StartTime = projectphaseDTO.StartDate;
            projectphase.dateTime = projectphaseDTO.EndDate;
           
            
            projectphaseRepo.InsertProjectPhase(projectphase);

            
            return RedirectToAction("Index");
          
        }
        //public JsonResult GetPhasesByProjectId(int projectId)
        //{
        //    var AllPhases = phaseRepo.GetAllProjectPhases();
        //    var projectPhases = phaseRepo.GetAllProjectPhaseByP(projectId);
        //    foreach (var pp in projectPhases)
        //    {
        //        if (AllPhases.Select(x => x.Id).contains(pp.PhaseId))
        //        {
        //            AllPhases.Remove(pp.Phase);
        //        }
        //    }
        //    var project = projectRepo.GetProject(ProjectId);
        //    ProjectPhaseDTO projectPhaseDTO = new ProjectPhaseDTO()
        //    {
        //        Phases = AllPhases,
        //        ProjectStartDate = project.StartDate,
        //        ProjectEndDate = project.EndDate
        //    };
        //    return new JsonResult(projectPhaseDTO);

        //}


        public IActionResult Edit(int Id)
        {
            ViewBag.Phases = phaseRepo.GetAllProjectPhases();
            ProjectPhase projectphase = projectphaseRepo.GetProjectPhaseById(Id);
            return View(projectphase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProjectPhase projectphase)
        { 
            projectphaseRepo.UpdateProjectPhase(projectphase);
            //phaseRepo.UpdatePhase(phase);

                
            return RedirectToAction("Index");


        }
        public IActionResult Delete(int Id)
        {

            ProjectPhase projectphase = projectphaseRepo.GetProjectPhaseById(Id);
            return View(projectphase);
        }



        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ProjectPhaseId)
        {
            try
            {
                ProjectPhase projectphase = projectphaseRepo.GetProjectPhaseById(ProjectPhaseId);
                projectphaseRepo.DeleteProjectPhase(ProjectPhaseId);

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }



        public JsonResult GetAllProjectPhasesByProjId(int ProjectId)
        {
            var x = projectphaseRepo.GetAllProjectPhasesByProjId(ProjectId);
            return Json(x);
        }


    }









    //if (id == null)
    //{
    //    return NotFound();
    //}

    //var deliverables = await _context.Deliverables
    //    .Include(d => d.ProjectPhase)
    //    .FirstOrDefaultAsync(m => m.DeliverableId == id);
    //if (deliverables == null)
    //{
    //    return NotFound();
    //}

    //return View(deliverables);

    // POST: Deliverable/Delete/5

}
    //private readonly IProjectPhaseRepository projectPhaseRepo;
    //private readonly IProjectRepository projectRepo;
    //private readonly IPhaseRepository phaseRepo;

    //public ProjectPhasesController(IProjectPhaseRepository projectPhaseRepo, IProjectRepository projectRepo, IPhaseRepository phaseRepo)
    //{
    //    this.projectPhaseRepo = projectPhaseRepo;
    //    this.projectRepo = projectRepo;
    //    this.phaseRepo = phaseRepo;

    //}

    //public IActionResult Index()
    //{
    //    try
    //    {
    //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //        var projectphases = projectPhaseRepo.GetAllProjectPhases(userId);
    //        return View(projectphases);
    //    }

    //    catch (Exception ex)
    //    {
    //        ViewBag.error = ex.Message;
    //        return View();
    //    }

    //}

    //public JsonResult GetPhasesByProjectId (int projectId)
    //{
    //    var AllPhases = phaseRepo.GetAllPhases();
    //    var projectPhases = projectPhaseRepo.GetAllProjectPhasesByP(projectId);
    //    foreach(var pp in projectPhases)
    //    {
    //        if(AllPhases.Select(x=> x.Id).contains(pp.PhaseId))
    //        {
    //            AllPhases.Remove(pp.Phase);
    //        }
    //    }
    //    var project = projectRepo.GetProject(ProjectId);
    //    ProjectPhaseDTO projectPhaseDTO = new ProjectPhaseDTO()
    //    {
    //        Phases = AllPhases,
    //        ProjectStartDate = project.StartDate,
    //        ProjectEndDate = project.EndDate
    //    };
    //    return new JsonResult(projectPhaseDTO);

    //}

    //public IActionResult NewProjectPhase(CreatProjectPhaseDTO projectPhase)
    //{
    //    try
    //    {
    //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //        ViewBag.Projects = projectRepo.GetProjectManagerProjects(userId);
    //        return View();
    //    }

    //    catch (Exception ex)
    //    {
    //        ViewBag.error = ex.Message;
    //        return View();
    //    }
    //}


