using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalMetodologiasWeb
{
    public class ResultPage: Page
    {
        protected void ValidateResponse<T>(Result<T> result, Label label)
        {
            if (!result.Ok)
            {
                label.Text = result.Message;
            }
            label.Visible = result.Ok;
        }
    }
}