using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace MyPlugins
{
    public class ContactPreCreate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {

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
                Entity contactRecord = (Entity)context.InputParameters["Target"];

                // From here, you can add your custom code.

                string lastname = contactRecord.Attributes["lastname"].ToString();

                if(lastname.Length >= 20)
                {
                    throw new InvalidPluginExecutionException("Lastname length should be less than 20 char");
                }
            }
        }
    }
}
