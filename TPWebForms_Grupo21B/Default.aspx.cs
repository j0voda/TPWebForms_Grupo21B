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

        public bool HasError = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Inicio";
            this.HasError = Request.QueryString["error"] != null;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string voucherCode = this.code.Text;

            if (voucherCode == null || voucherCode.Length == 0)
            {
                updateErrors("El código es de ingreso obligatorio.");
                return;
            }

            VoucherBussiness voucherBussiness = new VoucherBussiness();

            Voucher search = new Voucher();
            search.Codigo = voucherCode;

            Voucher v = voucherBussiness.getOne(search);

            if (v == null)
            {
                updateErrors("No se encontró un voucher asociado.");
                return;
            }

            if (v.Used)
            {
                updateErrors("El voucher ya a sido usado.");
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
                updateErrors("El código es de ingreso obligatorio.");
            }
            else
            {
                updateErrors();
            }
        }

        private void updateErrors(string error = null)
        {
            if (error != null)
            {
                this.code.CssClass = addIsInvalidClass(this.code.CssClass);
                this.lblError.Text = error;
            }
            else
            {
                this.code.CssClass = removeIsInvalidClass(this.code.CssClass);
            }
        }

        private string addIsInvalidClass(string classes)
        {
            if (!classes.Contains("is-valid")) return classes + " is-invalid";

            return classes;
        }

        private string removeIsInvalidClass(string classes)
        {
            return classes.Replace("is-invalid", "");
        }
    }
}