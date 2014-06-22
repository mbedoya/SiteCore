using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace BusinessWorkflow
{

    public sealed class CreateCampaignActivity : CodeActivity
    {
        // Defina un argumento de entrada de actividad de tipo string
        public InArgument<string> Text { get; set; }

        // Si la actividad devuelve un valor, se debe derivar de CodeActivity<TResult>
        // y devolver el valor desde el método Execute.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtenga el valor de tiempo de ejecución del argumento de entrada Text
            string text = context.GetValue(this.Text);
        }
    }
}
