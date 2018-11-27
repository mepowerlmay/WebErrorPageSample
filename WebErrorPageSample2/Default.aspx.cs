using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebErrorPageSample2
{
    public partial class dedault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int A = 0;
            int B = 1;

            var reuslt = B / A;
        }
    }
}