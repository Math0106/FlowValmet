using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Web.UI;
using System.Globalization;
using System.Threading;

namespace FlowValmet.Controllers
{
    public class GunaLocalizationHelper
    {
        //public  void ApplyLocalizationToGunaControls(Control container)
        //{


        //    // Primeiro, processar todos os Guna2TextBox diretamente no container
        //    foreach (var gunaTextBox in container.Controls.OfType<Guna2TextBox>())
        //    {
        //        if (!string.IsNullOrEmpty(gunaTextBox.Name))
        //        {
        //            string resourceKey = $"{gunaTextBox.Name}Placeholder";
        //            gunaTextBox.PlaceholderText = Properties.Resources.ResourceManager.GetString(resourceKey);
        //        }
        //    }

        
        public void ProcessGunaTextBox(Guna2TextBox gunaTextBox)
        {
            if (!string.IsNullOrEmpty(gunaTextBox.Name))
            {
                string resourceKey = $"{gunaTextBox.Name}Placeholder";
                gunaTextBox.PlaceholderText = Properties.Resources.ResourceManager.GetString(resourceKey);
            }
        }




    }
}
