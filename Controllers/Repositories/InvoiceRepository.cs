using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.DTO;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public InvoiceRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<Invoice> GetAllInvoices()
        {
            return context.Invoices.ToList();
        }

        public Invoice GetInvoiceById(int InvoiceId)
        {
            return context.Invoices.Find(InvoiceId);
        }


        public List<InvoicePaymentTermsDTO> GetInvoiceByProjectId(int ProjectId)
        {
           
            List<Invoice> invoiceList= new List<Invoice>()  ;
            Invoice invc = new Invoice();
            List<InvoicePaymentTermsDTO> IPT = new List<InvoicePaymentTermsDTO>();

            var q = from wi in context.Invoices
                    join wz in context.InvoicePaymentTerms on wi.InvoiceId equals wz.InvoiceId
                    join p in context.PaymentTerms on wz.PaymentTermId equals p.PaymentTermId
                    join d in context.Deliverables on p.DeliverableId equals d.DeliverableId
                    join c in context.ProjectPhases on d.ProjectPhaseId equals c.ProjectPhaseId
                    join f in context.Projects on c.ProjectId equals f.ProjectId
                    where c.ProjectId == ProjectId
                    select new { ProjectName = f.ProjectName,
                    ProjectId=f.ProjectId,
                    ProjectAmount=f.ContractAmount,
                   invoiceId = wi.InvoiceId,
                   invoiceName = wi.InvoiceTitle,
                   invoiceDate=wi.InvoiceDate
                    };
           // InvoicePaymentTermsDTO ipt = new InvoicePaymentTermsDTO();
            foreach (var item in q)
            {
                InvoicePaymentTermsDTO ipt = new InvoicePaymentTermsDTO();
                ipt.ProjectId = item.ProjectId;
                ipt.ProjectName=item.ProjectName;
                ipt.ContractAmount = item.ProjectAmount;
                ipt.InvoiceId = item.invoiceId;
                ipt.InvoiceTitle = item.invoiceName;
                ipt.InvoiceDate = item.invoiceDate;
                
                IPT.Add(ipt);
            }
            var x = q.ToList();
            return IPT;
        }

      
        public void InsertInvoice(Invoice invoice, List<int> listOfPaymentTermsID)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            InvoicePaymentTerm invoicePaymentTerm = new InvoicePaymentTerm();
            foreach (var item in listOfPaymentTermsID)
            {
                invoicePaymentTerm.InvoiceId = invoice.InvoiceId;
                invoicePaymentTerm.PaymentTermId = item;
                context.InvoicePaymentTerms.Add(invoicePaymentTerm);
                context.SaveChanges();
            }

        }
        public void UpdateInvoice(Invoice invoice)
        {
            context.Entry(invoice).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteInvoice(int InvoiceId)
        {
            Invoice invoice = context.Invoices.Find(InvoiceId);
            context.Invoices.Remove(invoice);
            context.SaveChanges();
        }



        public List<InvoicePaymentTermsDTO> GetAllPaymentTermsByProjId(int ProjectId, int DeliverableId)
        {

            List<PaymentTerm> paymentTerms = new List<PaymentTerm>();
            // Project project = new Project();

            List<InvoicePaymentTermsDTO> invoicePaymentTermsDTO = new List<InvoicePaymentTermsDTO>();
            try
            {
               
                List<ProjectPhase> pp;
                if (DeliverableId == 0)
                {
                    pp = context.ProjectPhases.Include(c => c.Deliverables).ThenInclude(x => x.PaymentTerms)
                        .Where(x => x.ProjectId == ProjectId).OrderBy(x => x.ProjectPhaseId).ToList();
                    foreach (var item in pp)
                    {
                        foreach (var item1 in item.Deliverables)
                        {
                            foreach (var item2 in item1.PaymentTerms)
                            {
                                paymentTerms.Add(item2);

                            }

                        }


                    }
                }
                else
                {
                    var deliverables = context.Deliverables.Include(x => x.PaymentTerms)
              .Where(x => x.DeliverableId == DeliverableId).OrderBy(x => x.ProjectPhaseId).ToList();

                    foreach (var item1 in deliverables)
                    {
                        foreach (var item2 in item1.PaymentTerms)
                        {
                            paymentTerms.Add(item2);

                        }

                    }
                }

                
                var proj = mapper.Map<List<PaymentTerm>, List<InvoicePaymentTermsDTO>>(paymentTerms);



                invoicePaymentTermsDTO = proj.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return invoicePaymentTermsDTO;
            //return context.ProjectPhases.Where(x => x.ProjectPhaseId == ProjectPhaseId).ToList();
        }

        public List<InvoicePaymentTermsDTO> GetAllPaymentTermsByinvoiceId(int ProjectId, int InvoiceId)
        {

            List<PaymentTerm> paymentTerms = new List<PaymentTerm>();


            List<Invoice> invoiceList = new List<Invoice>();
            Invoice invc = new Invoice();
            List<InvoicePaymentTermsDTO> IPT = new List<InvoicePaymentTermsDTO>();

            try
            {
                


                List<ProjectPhase> pp;
                if (InvoiceId == 0)
                {
                    pp = context.ProjectPhases.Include(c => c.Deliverables).ThenInclude(x => x.PaymentTerms)
                        .Where(x => x.ProjectId == ProjectId).OrderBy(x => x.ProjectPhaseId).ToList();
                    foreach (var item in pp)
                    {
                        foreach (var item1 in item.Deliverables)
                        {
                            foreach (var item2 in item1.PaymentTerms)
                            {
                                paymentTerms.Add(item2);

                            }

                        }


                    }
                }
                else
                {

                    var q = from wi in context.Invoices
                            join wz in context.InvoicePaymentTerms on wi.InvoiceId equals wz.InvoiceId
                            join p in context.PaymentTerms on wz.PaymentTermId equals p.PaymentTermId
                            join d in context.Deliverables on p.DeliverableId equals d.DeliverableId
                            join c in context.ProjectPhases on d.ProjectPhaseId equals c.ProjectPhaseId
                            join f in context.Projects on c.ProjectId equals f.ProjectId
                            where wi.InvoiceId == InvoiceId
                            select new
                            {
                                ProjectName = f.ProjectName,
                                ProjectId = f.ProjectId,
                                ProjectAmount = f.ContractAmount,
                                invoiceId = wi.InvoiceId,
                                invoiceName = wi.InvoiceTitle,
                                invoiceDate = wi.InvoiceDate,
                                iptlst=wz.PaymentTerm
                            };

                    foreach (var item in q)
                    {
                        InvoicePaymentTermsDTO ipt = new InvoicePaymentTermsDTO();
                        ipt.ProjectId = item.ProjectId;
                        ipt.ProjectName = item.ProjectName;
                        ipt.ContractAmount = item.ProjectAmount;
                        ipt.InvoiceId = item.invoiceId;
                        ipt.InvoiceTitle = item.invoiceName;
                        ipt.InvoiceDate = item.invoiceDate;
                        ipt.iptlst = item.iptlst;
                    
                       
                        IPT.Add(ipt);
                    }

                }
            
            }
            catch (Exception)
            {

                throw;
            }

            return IPT;
            //return context.ProjectPhases.Where(x => x.ProjectPhaseId == ProjectPhaseId).ToList();
        }

        public List<InvoicePaymentTermsDTO> GetNotPaidPaymentTerms(int ProjectId, int DeliverableId)
        {

            List<InvoicePaymentTerm> invoicePaymentTerms = new List<InvoicePaymentTerm>();
            // Project project = new Project();

            List<InvoicePaymentTermsDTO> invoicePaymentTermsDTO = new List<InvoicePaymentTermsDTO>();
            try
            {



                List<ProjectPhase> pp;
                if (DeliverableId == 0)
                {
                    pp = context.ProjectPhases.Include(c => c.Deliverables).ThenInclude(x => x.PaymentTerms).ThenInclude(x => x.InvoicePaymentTerms)
                        .Where(x => x.ProjectId == ProjectId).OrderBy(x => x.ProjectPhaseId).ToList();
                    foreach (var item in pp)
                    {
                        foreach (var item1 in item.Deliverables)
                        {
                            foreach (var item2 in item1.PaymentTerms)
                            {
                                foreach (var item3 in item2.InvoicePaymentTerms)
                                {
                                    invoicePaymentTerms.Add(item3);
                                }

                            }

                        }


                    }
                }
                else
                {
                    var deliverables = context.Deliverables.Include(x => x.PaymentTerms).ThenInclude(x => x.InvoicePaymentTerms)
              .Where(x => x.DeliverableId == DeliverableId).OrderBy(x => x.ProjectPhaseId).ToList();

                    foreach (var item1 in deliverables)
                    {
                        foreach (var item2 in item1.PaymentTerms)
                        {
                            foreach (var item3 in item2.InvoicePaymentTerms)
                            {
                                invoicePaymentTerms.Add(item3);
                            }


                        }

                    }
                }


                var proj = mapper.Map<List<InvoicePaymentTerm>, List<InvoicePaymentTermsDTO>>(invoicePaymentTerms);


                invoicePaymentTermsDTO = proj.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return invoicePaymentTermsDTO;
           
        }

    }
}
