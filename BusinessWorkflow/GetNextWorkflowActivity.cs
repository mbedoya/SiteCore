using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BusinessManager.Business;
using BusinessManager.Models;

namespace BusinessWorkflow
{

    public sealed class GetNextWorkflowActivity : CodeActivity
    {
        // Defina un argumento de entrada de actividad de tipo string
        public InArgument<int> WorkflowID { get; set; }

        //public OutArgument<ActivityDataModel> Activity { get; set; }

        // Si la actividad devuelve un valor, se debe derivar de CodeActivity<TResult>
        // y devolver el valor desde el método Execute.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtenga el valor de tiempo de ejecución del argumento de entrada Text
            int workflowID = context.GetValue(this.WorkflowID);

            //ActivityDataModel nextActivity = null;//WorkflowBO.GetInstance().GetNextWorkflowActivity(workflowID);
            //context.SetValue(Activity, nextActivity);
        }
    }
}
