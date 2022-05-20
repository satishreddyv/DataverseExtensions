using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace CustomWorkflows
{

    public class TaskCreate : CodeActivity
    {
        [Input("Task Subject")]
        public InArgument<string> TaskSubject { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            //Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            //Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            Entity task = new Entity("task");
            task["subject"] = TaskSubject.Get(executionContext);
            task["regardingobjectid"] = new EntityReference("account", context.PrimaryEntityId);

            service.Create(task);
        
        }
    }
}
