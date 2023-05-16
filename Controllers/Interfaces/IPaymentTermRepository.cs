using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IPaymentTermRepository
    {
        public List<PaymentTerm> GetAllPaymentTerms();

        public PaymentTerm GetPaymentTermById(int PaymentTermId);

        public void InsertPaymentTerm(PaymentTerm paymentTerm);

        public void UpdatePaymentTerm(PaymentTerm paymentTerm);

        public void DeletePaymentTerm(int PaymentTermId);

       
    }
}
