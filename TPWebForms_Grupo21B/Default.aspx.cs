using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using acceso_datos;
using dominio;

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
                this.code.CssClass = this.code.CssClass + " is-invalid";
                this.lblError.Text = "El código es de ingreso obligatorio.";
                return;
            }

            VoucherBussiness voucherBussiness = new VoucherBussiness();

            Voucher search = new Voucher();
            search.Codigo = voucherCode;

            Voucher v = voucherBussiness.getOne(search);

            if (v == null)
            {
                this.code.CssClass = this.code.CssClass + " is-invalid";
                this.lblError.Text = "No se encontró un voucher asociado.";
                return;
            }

            if (v.Used)
            {
                this.code.CssClass = this.code.CssClass + " is-invalid";
                this.lblError.Text = "El voucher ya a sido usado.";
                return;
            }

            Session.Add("voucher", v.Codigo);

            Response.Redirect("SelectPrize.aspx");
        }

        protected void code_TextChanged(object sender, EventArgs e)
        {

            string voucherCode = this.code.Text;

            if (voucherCode == null || voucherCode.Length == 0)
            {
                this.code.CssClass = this.code.CssClass + " is-invalid";
                this.lblError.Text = "El código es de ingreso obligatorio.";
            }
            else
            {
                this.code.CssClass = this.code.CssClass.Replace("is-invalid", "");
            }
        }
    }
}