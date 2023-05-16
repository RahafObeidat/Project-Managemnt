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
    public class InvoiceController : Controller
    {
        private readonly IProjectRepository projectRepo;
        private readonly IInvoiceRepository invoiceRepo;


        public InvoiceController(IInvoiceRepository invoiceRepo, IProjectRepository projectRepo)
        {
            this.invoiceRepo = invoiceRepo;
            this.projectRepo = projectRepo;
        }


        public IActionResult Index()
        {
            try
            {
                ViewBag.Projects = projectRepo.GetAllProjects();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var invoices = invoiceRepo.GetAllInvoices();
                return View(invoices);
            }

            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        public JsonResult GetAllPaymentTermsByProjId(int ProjectId,int DeliverableId)
        {
           var x = invoiceRepo.GetAllPaymentTermsByProjId(ProjectId, DeliverableId);
            return Json(x);
        }

        public JsonResult GetNotPaidPaymentTerms(int ProjectId, int DeliverableId)
        {
            var x = invoiceRepo.GetNotPaidPaymentTerms(ProjectId, DeliverableId);
            return Json(x);
        }

        public IActionResult PrintInvoice(int InvoiceId, int ProjectId)
        {
            //try
            //{
            ViewBag.Projects = projectRepo.GetProject(ProjectId);
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
              var invoices = invoiceRepo.GetAllInvoices();
            ViewBag.invoice = invoiceRepo.GetInvoiceById(InvoiceId);
            ViewBag.invoice1 = invoiceRepo.GetAllPaymentTermsByinvoiceId(ProjectId, InvoiceId);

           
            //    return View(invoices);
            //}

            //catch (Exception ex)
            //{
            //    ViewBag.error = ex.Message;
            //    return View();
            //}
            return View();
        }

        
        public JsonResult GetInvoiceByProjectId(int Id)
        {
            var invoicelist = invoiceRepo.GetInvoiceByProjectId(Id);
            return Json(invoicelist);
            // View(invoice);
        }



        public IActionResult Details(int Id)
        {
            Invoice invoice = invoiceRepo.GetInvoiceById(Id);
            return View(invoice);
        }


        public IActionResult Create()
        {
            ViewBag.Projects = projectRepo.GetAllProjects();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateInvoiceDTO invoiceDTO)
        {
            try
            {
                Invoice invoice = new Invoice();
              
                invoice.InvoiceTitle = invoiceDTO.InvoiceTitle;
                invoice.InvoiceDate = invoiceDTO.InvoiceDate;
                invoice.InvoicePaymentTerms = invoiceDTO.InvoicePaymentTerms;
                var listOfPaymentTermsID = invoiceDTO.PaymentTermId;



                if (ModelState.IsValid)
                {
                    invoiceRepo.InsertInvoice(invoice, listOfPaymentTermsID);
                   
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

            Invoice invoice = invoiceRepo.GetInvoiceById(Id);
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Invoice invoice)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    invoiceRepo.UpdateInvoice(invoice);

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

            Invoice invoice = invoiceRepo.GetInvoiceById(Id);
            return View(invoice);
        }



        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int InvoiceId)
        {
            try
            {
                Invoice invoice = invoiceRepo.GetInvoiceById(InvoiceId);
                invoiceRepo.DeleteInvoice(InvoiceId);

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



























