using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebForms_Grupo21B
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string voucherCode = this.code.Text;

            if (voucherCode == null || voucherCode.Length == 0)
            {
                return;
            }
        }

        protected void code_TextChanged(object sender, EventArgs e)
        {

            string voucherCode = this.code.Text;

            if (voucherCode == null || voucherCode.Length == 0)
            {
                this.code.CssClass = this.code.CssClass + " is-invalid";
            }
            else
            {
                this.code.CssClass = this.code.CssClass.Replace("is-invalid", "");
            }
        }
    }
}