using Domain.DingTalkSync.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface ILoginService
    {
        DingUserIdResponse GetUserId(string Code);

        EmployeeInfoResponse GetEmployeeInfo(string DingUserId);
        EmployeeInfoResponse GetEmployeeInfoByEmpID(string EmpID);
        EmployeeInfoResponse GetCCHR_EmployeeByDomainAccount(string DomainAccount);
    }
}
