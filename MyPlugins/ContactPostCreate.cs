using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace MyPlugins
{
    public class ContactPostCreate : IPlugin
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
                Entity contactRecord = (Entity)context.InputParameters["Target"];

                tracingService.Trace("contact guid is" + contactRecord.Id);

                // Create a task for this contact
                // Create in-memory object 
                Entity task = new Entity("task");
                task.Attributes.Add("subject", "A task from Plugin");
                // OR
                task["description"] = "Sample desc";
                task["regardingobjectid"] = new EntityReference("contact", contactRecord.Id);

                // Call organization web service to create task record in database
                Guid taskGuid = svc.Create(task);

                tracingService.Trace("task guid is" + taskGuid);

            }
        }
    }
}
