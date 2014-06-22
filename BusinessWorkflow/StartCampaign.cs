using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using BusinessManager.Business;
using BusinessManager.Models;

namespace BusinessWorkflow
{

    public sealed class StartCampaign : CodeActivity
    {
        // Defina un argumento de entrada de actividad de tipo string
        public InArgument<int> CampaignID { get; set; }

        public OutArgument<int> WorkflowID { get; set; }

        // Si la actividad devuelve un valor, se debe derivar de CodeActivity<TResult>
        // y devolver el valor desde el método Execute.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtenga el valor de tiempo de ejecución del argumento de entrada Text
            int campaignID = context.GetValue(this.CampaignID);

            //CampaignDataModel model = null; // CampaignBO.GetInstance().Get(campaignID);
            //if(model.DateStarted != DateTime.MinValue)
            //{
            //    throw new Exception("Campaign already started");
            //}
            //model.DateStarted = DateTime.Now;
            ////CampaignBO.GetInstance().Update(model);

            context.SetValue(WorkflowID, 1);
        }
    }
}
