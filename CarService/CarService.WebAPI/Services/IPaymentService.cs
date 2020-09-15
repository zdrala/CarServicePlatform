using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IPaymentService
    {
        Data.Model.Payments Insert(PaymentInsertRequest req);
        List<Data.Model.Payments> Get(PaymentSearchRequest req);
    }
}
