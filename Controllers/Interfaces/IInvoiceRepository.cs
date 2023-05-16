using PMISBLayer.DTO;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IInvoiceRepository
    {
        public List<Invoice> GetAllInvoices();

        public Invoice GetInvoiceById(int InvoiceId);

        public void InsertInvoice(Invoice invoice, List<int> listOfPaymentTermsID);

        public void UpdateInvoice(Invoice invoice);

        public void DeleteInvoice(int InvoiceId);

        public List<InvoicePaymentTermsDTO> GetInvoiceByProjectId(int ProjectId);

        public List<InvoicePaymentTermsDTO> GetAllPaymentTermsByProjId(int ProjectId, int DeliverableId);
        public List<InvoicePaymentTermsDTO> GetNotPaidPaymentTerms(int ProjectId, int DeliverableId);
        public List<InvoicePaymentTermsDTO> GetAllPaymentTermsByinvoiceId(int ProjectId, int InvoiceId);
    }
}
