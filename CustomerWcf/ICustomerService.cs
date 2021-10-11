using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.ServiceModel.Web;

namespace CustomerWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
       // [WebInvoke(
       //     Method = "GET",
       //     RequestFormat = WebMessageFormat.Json,
       //     ResponseFormat = WebMessageFormat.Json,
       //     UriTemplate = "GetAllCustomer"
       //     )]
        List<Customer> GetAllCustomer();


        [OperationContract]
       // [WebInvoke(
       //    Method = "POST",
       //     RequestFormat = WebMessageFormat.Json,
       //     ResponseFormat = WebMessageFormat.Json,
       //     UriTemplate = "InsertCustomer"
       //     )]
        Customer InsertCustomer(Customer c);

        [OperationContract]
       // [WebInvoke(
       //    Method = "DELETE",
       //    RequestFormat = WebMessageFormat.Json,
       //    ResponseFormat = WebMessageFormat.Json,
       //    UriTemplate = "DeleteCustomer/{id}"
       //   )]
        string DeleteCustomer(string id);


        [OperationContract]
       // [WebInvoke(
       //     Method = "GET",
       //     RequestFormat = WebMessageFormat.Json,
       //     ResponseFormat = WebMessageFormat.Json,
       //     UriTemplate = "GetCustomerById/{id}"
       //     )]
        List<Customer> GetCustomerById(string id);


        [OperationContract]
       // [WebInvoke(
       //   Method = "PUT",
       //   RequestFormat = WebMessageFormat.Json,
       //   ResponseFormat = WebMessageFormat.Json,
       //   UriTemplate = "/UpdateCustomer"
       //  )]
        Customer UpdateCustomer(Customer c);
    }
}
