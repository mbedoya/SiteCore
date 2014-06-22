using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BusinessManager.Business;
using BusinessManager.Models;

namespace BusinessWorkflow
{

    public sealed class CreateCampaign : CodeActivity
    {
        // Defina un argumento de entrada de actividad de tipo string
        public InArgument<int> WorkflowID { get; set; }
        public InArgument<string> Name { get; set; }        

        public OutArgument<int> CampaignID { get; set; }

        // Si la actividad devuelve un valor, se debe derivar de CodeActivity<TResult>
        // y devolver el valor desde el método Execute.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtenga el valor de tiempo de ejecución del argumento de entrada Text
            string name = context.GetValue(this.Name);
            int workflowID = context.GetValue(this.WorkflowID);            

            //CampaignDataModel model = new CampaignDataModel();
            //model.Name = name;
            //model.WorkflowID = workflowID;
            //CampaignBO.GetInstance().Create(model);
        }
    }
}
