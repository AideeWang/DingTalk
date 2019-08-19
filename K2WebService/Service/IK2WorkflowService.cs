using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using K2Application.Common;

namespace K2WebService.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IK2WorkflowService
    {

        [OperationContract]
        void StartProcessInstance(string WorkflowTypeName, Dictionary<string, object> dicDataFields, string ApplyUserInfo);
        [OperationContract]
        List<ApprovalWorklistItem> GetCurrentUserWorkListItem(string ApprovalUser);
        [OperationContract]
        void ApprovalProcessInstance(string SN, Dictionary<string, object> dicDataFields, string ApprovalUserInfo);
        [OperationContract]
        string GetProcessInstanceApprovalHistory(string SN, string ApprovalUserId);
        [OperationContract]
        string GetCurrentUserCompletedWorkListItem(string ApprovalUser);
        // TODO: 在此添加您的服务操作
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    //[DataContract]
    //[DataMember]

}
