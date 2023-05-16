using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMISAppLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    public class PaymentTermController : Controller
    {

        private readonly IDeliverableRepository deliverableRepo;
        //private readonly IProjectPhaseRepository projectphaseRepo;
        private readonly IProjectRepository projectRepo;
        private readonly IPaymentTermRepository paymentTermRepo;


        public PaymentTermController(IPaymentTermRepository paymentTermRepo, IDeliverableRepository deliverableRepo, IProjectRepository projectRepo)
        {
            this.paymentTermRepo = paymentTermRepo;
            this.deliverableRepo = deliverableRepo;
            this.projectRepo = projectRepo; 
        }


        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var paymentterms = paymentTermRepo.GetAllPaymentTerms();
                return View(paymentterms);
            }

            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }


        public IActionResult Details(int PaymentTermId)
        {
            PaymentTerm paymentTerm = paymentTermRepo.GetPaymentTermById(PaymentTermId);
            return View(paymentTerm);
        }


        public IActionResult Create()
        {

            ViewBag.Projects = projectRepo.GetAllProjects();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatPaymentDTO paymentTermdto)
        {
            try
            {

                PaymentTerm paymentTerm = new PaymentTerm();

                paymentTerm.PaymentTermTitle = paymentTermdto.PaymentTermTitle;
                paymentTerm.PaymentTermAmount = paymentTermdto.PaymentTermAmount;
                paymentTerm.DeliverableId = paymentTermdto.DeliverableId;

                if (ModelState.IsValid)
                {
                    paymentTermRepo.InsertPaymentTerm(paymentTerm);
                }
               
            }
           
                catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return RedirectToAction("Index");
           
        }


        public IActionResult Edit(int Id)
        {

            PaymentTerm paymentTerm = paymentTermRepo.GetPaymentTermById(Id);
            return View(paymentTerm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PaymentTerm paymentTerm)
        {


            //try
            //{
            if (ModelState.IsValid)
            {
                paymentTermRepo.UpdatePaymentTerm(paymentTerm);

            }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.error = ex.Message;
            //    return View();
            //}

            return RedirectToAction("Index");


        }
        public IActionResult Delete(int Id)
        {

            PaymentTerm paymentTerm = paymentTermRepo.GetPaymentTermById(Id);
            return View(paymentTerm);
        }



        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int PaymentTermId)
        {
            try
            {
                PaymentTerm paymentTerm = paymentTermRepo.GetPaymentTermById(PaymentTermId);
                paymentTermRepo.DeletePaymentTerm(PaymentTermId);

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetDeliverablesByPhaseId(int ProjectPhaseId)
        {
            var x = deliverableRepo.GetDeliverablesByPhaseId(ProjectPhaseId);
            return Json(x);
        }



    }
}