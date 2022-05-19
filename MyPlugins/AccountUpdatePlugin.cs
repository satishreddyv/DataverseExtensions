using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace MyPlugins
{
    public class AccountUpdatePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // To trace logs
            ITracingService tracingService =
                (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            tracingService.Trace("We are running contact post create");

            IPluginExecutionContext context = (IPluginExecutionContext)
           serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Obtain the organization service reference which you will need for  
            // web service calls.  
            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService svc = serviceFactory.CreateOrganizationService(context.UserId);

            // Retrieve the record which user is working on....
            if (context.InputParameters.Contains("Target") &&
               context.InputParameters["Target"] is Entity)
            {
                Entity account = (Entity)context.InputParameters["Target"];

                ////Get Phone number
                //string phone = account.Attributes["telephone1"].ToString();

                //// Fax
                //string fax = account.Attributes["fax"].ToString();

                ColumnSet columnSet = new ColumnSet();
                columnSet.AddColumn("telephone1");
                columnSet.AddColumn("fax");
                // columnSet.AddColumns(new string[] { "telephone1", "fax" });

                //  Entity accountWithMoreAttributes = svc.Retrieve("account", account.Id, columnSet);

                // Using Pre-entity Image
                Entity accountPreImage = context.PreEntityImages["PreImage"];

                if (!accountPreImage.Attributes.Contains("telephone1") && !accountPreImage.Attributes.Contains("fax"))
                {
                    throw new InvalidPluginExecutionException("Either Phone or Fax is mandatory");
                }
            }
        }
    }
}
