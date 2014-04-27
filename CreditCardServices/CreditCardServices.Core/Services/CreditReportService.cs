using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardServices.Core.Models;

namespace CreditCardServices.Core.Services
{
    public class CreditReportService : ICreditReportService
    {
        public CreditReport CheckCreditHistory(CreditReportRequest request)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICreditReportService
    {
        CreditReport CheckCreditHistory(CreditReportRequest request);
    }
}
