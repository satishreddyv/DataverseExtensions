using System;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using OAuth username and password
            string connectionString = @"AuthType=OAuth;
  Username=satish@audacitybikes.onmicrosoft.com;
  Password=Pearl@123;
  Url=https://org7ae2e893.crm.dynamics.com/;
  AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;
  RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            ServiceClient service = new ServiceClient(connectionString);

            // Creating account using Early bound classes
            Account account1 = new Account();
            account1.Name = "Test ac";
            account1.EMailAddress1 = "";
            account1.Revenue = new Money(1000);
            account1.IndustryCode = account_industrycode.Consulting;

            // Creating account - Late bound
            Entity account3 = new Entity("account");
            account3["name"] = "test acc 3";
            account3["industrycode"] = new OptionSetValue(7);


            Account account2 = new Account()
            {
                EMailAddress1 = "",
                Name = ""
            };



            //// Create contact record programatically
            //Entity contact = new Entity("contact");
            //contact["lastname"] = "Smith (console app)";
            //Guid contactGuid = service.Create(contact);

            //// Create account
            //Entity acc = new Entity("account");
            //acc["name"] = "Test Acc";
            //Guid accGuid = service.Create(acc);


            //// Create custom entity record
            //Entity req = new Entity("new_expenserequest");
            //acc["new_name"] = "Test req";
            //Guid reqGuid = service.Create(req);

            // Pull contacts
            // Many ways to pull data
            // 1. Use QueryExpression
            // 2. Use QuerByAttribute
            // 3. Use Fetchxml (faster), supports aggregate functions.
            // 4. Use Linq


            // Method 1: Using QueryExpression
            //select firstname,lastname from contact where attname =value
            //QueryExpression query = new QueryExpression("contact");
            //query.ColumnSet.AddColumn("fullname");
            ////  query.Criteria.AddCondition("")


            // Method 2: Using QueryByAttribute
            //QueryByAttribute query = new QueryByAttribute("contact");
            //query.ColumnSet = new ColumnSet(new string[] { "fullname"});
            //query.AddAttributeValue("fullname", "test");

            // Metho 3: Using Fetch XML

            //            string xmlQuery = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
            //  <entity name='systemuser'>
            //    <attribute name='fullname' />
            //    <attribute name='title' />
            //    <attribute name='address1_telephone1' />
            //    <attribute name='businessunitid' />
            //    <attribute name='positionid' />
            //    <attribute name='systemuserid' />
            //    <order attribute='fullname' descending='false' />
            //    <filter type='and'>
            //      <condition attribute='isdisabled' operator='eq' value='0' />
            //      <condition attribute='accessmode' operator='ne' value='3' />
            //      <condition attribute='accessmode' operator='ne' value='5' />
            //    </filter>
            //  </entity>
            //</fetch>";
            //            EntityCollection collection = service.RetrieveMultiple(new FetchExpression(xmlQuery));

            //   4. LINQ

            using (var serviceContext = new OrganizationServiceContext(service))
            {
                //var collection = from item in serviceContext.CreateQuery("contact")
                //              where item["createdon"] as DateTime? > DateTime.Now.AddDays(-10)  
                //              select item["fullname"];

                var collection = from contact in serviceContext.CreateQuery("contact")
                                 join account in serviceContext.CreateQuery("account")
                                 on contact["contactid"] equals account["primarycontactid"]
                                 select new
                                 {
                                     fullname = contact["fullname"],
                                     accountname = account["name"]
                                 };

                Console.WriteLine(collection.ToList().Count);

                foreach (var item in collection)
                {

                    Console.WriteLine(item.fullname + " " + item.accountname);
                }

            }
        }
    }
}
