using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMISAppLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    [Authorize]
    public class ProjectController : Controller

    {
        private readonly IProjectPhaseRepository projectPhaseRepo;
        private readonly IProjectStatusRepository projectStatusRepo;
        private readonly IProjectTypeRepository projectTypeRepo;
        private readonly IProjectRepository projectRepo;
        private readonly IMapper mapper;

        public ProjectController(IProjectRepository projectRepo, IProjectTypeRepository projectTypeRepo, IProjectStatusRepository projectStatusRepo, IProjectPhaseRepository projectPhaseRepo, IMapper mapper)
        {
            this.projectRepo = projectRepo;
            this.projectTypeRepo = projectTypeRepo;
            this.projectStatusRepo = projectStatusRepo;
            this.projectPhaseRepo = projectPhaseRepo;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
           
            
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                //List<Project> projects = projectRepo.GetAllProjects();
                List<Project> projects = projectRepo.GetProjectManagerProjects(userId).ToList();
                return View(projects);
            

   
        }


        public IActionResult CreateProject()
        {
            try
            {
                ViewBag.ProjectTypes = projectTypeRepo.GetAllProjectTypes();
                ViewBag.ProjectStatuses = projectStatusRepo.GetAllProjectStatuses();
                return View();
            }

            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
           
        }

        [HttpPost]
        public IActionResult InsertProject(InsertProjectDTO projectDTO)
        {
           
                var project = mapper.Map<Project>(projectDTO);
                //Project project = new Project();

                //project.ProjectName = projectDTO.ProjectName;
                //project.StartDate = projectDTO.StartDate;
                //project.EndDate = projectDTO.EndDate;
                //project.ContractAmount = projectDTO.ContractAmount;
                //project.ProjectStatusId = projectDTO.ProjectStatusId;
                //project.ProjectTypeId = projectDTO.ProjectTypeId;
                project.ContractFileName = projectDTO.ContractFile.FileName;
                project.ContractFileType = projectDTO.ContractFile.ContentType;
                project.ProjectManagerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                if (projectDTO.ContractFile.Length > 0)
                {
                    Stream st = projectDTO.ContractFile.OpenReadStream();
                    using (BinaryReader br = new BinaryReader(st))
                    {
                        var byteFile = br.ReadBytes((int)st.Length);         //Array of bytes
                        project.ContractFile = byteFile;

                        projectRepo.InsertProject(project);
                    }

                }
                return RedirectToAction("Index");
            

          /*  catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }*/
            

            
        }

        public FileStreamResult ViewContract(int ProjectId)       //client side => Browser      //stream => open connection between backend & client side
        {
           
            var project = projectRepo.GetProject(ProjectId);

            Stream stream = new MemoryStream(project.ContractFile); //array of bytes

            return new FileStreamResult(stream, project.ContractFileType);  //pdf => download
        }

        public IActionResult Edit(int id)
        {
            
            Project project = projectRepo.GetProject(id);
            return View(project);

        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {

            projectRepo.UpdateProject(project);


            return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {

            Project project = projectRepo.GetProject(id);
            return View(project);
        }



        [HttpPost]
        public IActionResult DeleteConfirmed(int ProjectId)
        {
            try
            {
                //Project project = projectRepo.GetProject(id);
                projectRepo.DeleteProject(ProjectId);

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {

            Project project = projectRepo.GetProject(id);
            return View(project);
        }

    }

}
