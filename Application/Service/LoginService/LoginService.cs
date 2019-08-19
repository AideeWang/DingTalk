using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Domain.DingTalkSync.DTO;
using Domain.DingTalkSync.Repository;
using Application.ToDTO;

namespace Application.Service
{
    public class LoginService : BaseDingTalkService, ILoginService
    {
        IUserSyncRepository userSyncRepository = ServiceLoader.LoadService<IUserSyncRepository>();
        ICCHR_EmployeeRepository cCHR_EmployeeRepository = ServiceLoader.LoadService<ICCHR_EmployeeRepository>();
        ICCHR_EmployeePositionRoleRepository cCHR_EmployeePositionRoleRepository = ServiceLoader.LoadService<ICCHR_EmployeePositionRoleRepository>();
        ICCHR_PositionRepository cCHR_PositionRepository = ServiceLoader.LoadService<ICCHR_PositionRepository>();
        ICCHR_DepartmentRepository cCHR_DepartmentRepository = ServiceLoader.LoadService<ICCHR_DepartmentRepository>();
        /// <summary>
        /// 获取用户DingDingId
        /// 请求方式：GET（HTTPS）
        /// 请求地址：https://oapi.dingtalk.com/user/getuserinfo?access_token=access_token&code=code
        /// </summary>
        /// <param name="Code"></param>
        public DingUserIdResponse GetUserId(string Code)
        {
            Dictionary<string, string> RequestDic = GetAccessTokenToDic();
            RequestDic.Add("code", Code);
            string Result = BaseGetApi("user/getuserinfo", RequestDic);
            var Response = Result.ToObject<DingUserIdResponse>();
            return Response;
        }

        /// <summary>
        /// 获取员工信息（包括合同信息）
        /// </summary>
        /// <param name="DingUserId"></param>
        /// <returns></returns>
        public EmployeeInfoResponse GetEmployeeInfo(string DingUserId)
        {
            EmployeeInfoResponse response = new EmployeeInfoResponse();
            var userSync = userSyncRepository.Get(DingUserId);
            if (userSync != null)
            {
                var cCHR_Employee = cCHR_EmployeeRepository.GetCCHR_Employee(userSync.EmpID);
                response = cCHR_Employee.ToDTO();
                response.DingUserID = DingUserId;
                //response.SigningType = cCHR_Employee.InCompanyDate.AddYears(10) < DateTime.Now?"无固定":"普通";//签约类型

                var PositionRole = cCHR_EmployeePositionRoleRepository.GetCCHR_EmployeePositionRole(cCHR_Employee.EmpID);

                var Position = cCHR_PositionRepository.Get(PositionRole.PositionID);
                var Department = cCHR_DepartmentRepository.GetCCHR_Department(Position.DeptID);
                response.DeptID = Department.DeptID;
                response.DeptName = Department.DeptName;
                response.DeptFullName = Department.FullName;
                response.PositionID = Position.PositionID;
                response.PositionName = PositionRole.PositionName;

            }
            return response;
        }

        /// <summary>
        /// 获取员工信息（包括合同信息）
        /// </summary>
        /// <param name="DingUserId"></param>
        /// <returns></returns>
        public EmployeeInfoResponse GetEmployeeInfoByEmpID(string EmpID)
        {
            EmployeeInfoResponse response = new EmployeeInfoResponse();
            var cCHR_Employee = cCHR_EmployeeRepository.GetCCHR_Employee(EmpID);
                //response.DingUserID = DingUserId;
                response = cCHR_Employee.ToDTO();
                //response.SigningType = cCHR_Employee.InCompanyDate.AddYears(10) < DateTime.Now?"无固定":"普通";//签约类型
                response.DingUserID = userSyncRepository.GetUserSyncByEmpID(response.EmpID).UserID;
                var PositionRole = cCHR_EmployeePositionRoleRepository.GetCCHR_EmployeePositionRole(cCHR_Employee.EmpID);

                var Position = cCHR_PositionRepository.Get(PositionRole.PositionID);
                var Department = cCHR_DepartmentRepository.GetCCHR_Department(Position.DeptID);
                response.DeptID = Department.DeptID;
                response.DeptName = Department.DeptName;
                response.DeptFullName = Department.FullName;
                response.PositionID = Position.PositionID;
                response.PositionName = PositionRole.PositionName;
            return response;
        }

        public EmployeeInfoResponse GetCCHR_EmployeeByDomainAccount(string DomainAccount)
        {
            EmployeeInfoResponse response = new EmployeeInfoResponse();
            var cCHR_Employee = cCHR_EmployeeRepository.GetCCHR_EmployeeByDomainAccount(DomainAccount);
            //response.DingUserID = DingUserId;
            response = cCHR_Employee.ToDTO();
            response.DingUserID = userSyncRepository.GetUserSyncByEmpID(response.EmpID).UserID;
            //response.SigningType = cCHR_Employee.InCompanyDate.AddYears(10) < DateTime.Now?"无固定":"普通";//签约类型

            var PositionRole = cCHR_EmployeePositionRoleRepository.GetCCHR_EmployeePositionRole(cCHR_Employee.EmpID);

            var Position = cCHR_PositionRepository.Get(PositionRole.PositionID);
            var Department = cCHR_DepartmentRepository.GetCCHR_Department(Position.DeptID);
            response.DeptID = Department.DeptID;
            response.DeptName = Department.DeptName;
            response.DeptFullName = Department.FullName;
            response.PositionID = Position.PositionID;
            response.PositionName = PositionRole.PositionName;
            return response;
        }
    }
}
