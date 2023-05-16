using Microsoft.EntityFrameworkCore;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class PaymentTermRepository : IPaymentTermRepository
    {
        private readonly ApplicationDbContext context;

        public PaymentTermRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public List<PaymentTerm> GetAllPaymentTerms()
        {
            return context.PaymentTerms.ToList();
        }

        public PaymentTerm GetPaymentTermById(int PaymentTermId)
        {
            return context.PaymentTerms.Find(PaymentTermId);
        }

        public void InsertPaymentTerm(PaymentTerm paymentTerm)
        {
            context.PaymentTerms.Add(paymentTerm);
            context.SaveChanges();
        }


        public void UpdatePaymentTerm(PaymentTerm paymentTerm)
        {
            context.Entry(paymentTerm).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletePaymentTerm(int PaymentTermId)
        {
            PaymentTerm paymentTerm = context.PaymentTerms.Find(PaymentTermId);
            context.PaymentTerms.Remove(paymentTerm);
            context.SaveChanges();
        }

       
        
    }
}
