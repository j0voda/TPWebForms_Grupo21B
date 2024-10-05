using acceso_datos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebForms_Grupo21B
{
    public partial class SelectPrize : System.Web.UI.Page
    {

        private Voucher voucher;
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack) return;

            if (Session["voucher"] == null)
            {
                Response.Redirect("Default.aspx", true);
            }

            string voucherCode = Session["voucher"].ToString();

            VoucherBussiness voucherBussiness = new VoucherBussiness();

            Voucher search = new Voucher();
            search.Codigo = voucherCode;

            Voucher v = voucherBussiness.getOne(search);

            if (v == null || v.Used) {
                Response.Redirect("Default.aspx", true);
            }

            voucher = v;

            ItemBussiness itemBussiness = new ItemBussiness();

            this.Articulos = itemBussiness.getAll();
        }
    }
}