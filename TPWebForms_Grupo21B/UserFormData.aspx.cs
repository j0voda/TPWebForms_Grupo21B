using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using acceso_datos;
using dominio;

namespace TPWebForms_Grupo21B
{
    public partial class UserFormData : System.Web.UI.Page
    {

        private string voucherCode;
        private Articulo item;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["voucher"] == null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                Session.Add("newuser", true);

                voucherCode = Session["voucher"].ToString();

                string itemCode = Request.QueryString["item"];

                if (itemCode == null)
                {
                    Response.Redirect($"Default.aspx?error=Ocurrió un error inesperado");
                    return;
                }

                ItemBussiness itemB = new ItemBussiness();
                Articulo art = itemB.getOneByCode(itemCode);

                if (art == null)
                {
                    Response.Redirect($"Default.aspx?error=Ocurrió un error inesperado");
                    return;
                }

                this.item = art;
            }
        }

        protected void accept_CheckedChanged(object sender, EventArgs e)
        {
            //Hola
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateDni() &&
                validateName() &&
                validateSurname() &&
                validateEmail() &&
                validateAddress() &&
                validateCity() &&
                validateCP() &&
                validateAccept())
            {
                try
                {
                    int id = 0;

                    if ((bool)Session["newuser"])
                    {
                        ClientBussiness clientBussiness = new ClientBussiness();
                        Cliente cnew = new Cliente();
                        cnew.Documento = this.dni.Text.Trim();
                        cnew.Nombre = this.name.Text.Trim();
                        cnew.Apellido = this.surname.Text.Trim();
                        cnew.Email = this.email.Text.Trim();
                        cnew.Direccion = this.address.Text.Trim();
                        cnew.Ciudad = this.city.Text.Trim();
                        cnew.CodigoPostal = Convert.ToInt32(this.cp.Text.Trim());

                        id = clientBussiness.saveOne(cnew);
                        if(id <= 0)
                        { 
                           throw new Exception("Error al insertar nuevo cliente");
                        }

                        VoucherBussiness voucherB = new VoucherBussiness();


                        Voucher v = new Voucher();
                        v.Codigo = this.voucherCode;
                        v = voucherB.getOne(v);
                    
                        if (v.Codigo != this.voucherCode)
                        {
                            throw new Exception("Voucher no encontrado");
                        }

                        v.FechaCanje = new DateTime();
                        v.Cliente = new Cliente();
                        v.Cliente.Id = id;

                        v.Articulo = this.item;

                        voucherB.updateOne(v);
                    }

                    // Enviar mail..
                    this.sendMail(this.email.Text.Trim(), this.name.Text.Trim() + " " + this.surname.Text.Trim());

                    // Redirect a pantalla de Éxito en lugar de home
                    Response.Redirect("Success.aspx", false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Response.Redirect($"Default.aspx?error={ex.Message}");
                }
            }
        }

        protected void name_TextChanged(object sender, EventArgs e)
        {
            
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

        private bool validateDni()
        {
            bool valid = true;
            string dnitxt = this.dni.Text.Trim();

            if (string.IsNullOrEmpty(dnitxt))
            {
                this.dni.CssClass = addIsInvalidClass(this.name.CssClass);
                this.dniError.Text = "Debe completar el campo.";
                valid = false;
            }
            else if (!dnitxt.All(char.IsDigit) || dnitxt.Length < 8)
            {
                this.dni.CssClass = addIsInvalidClass(this.dni.CssClass);
                this.dniError.Text = "Ingrese 8 caracteres (solo números).";
                valid = false;   
            }else
            {
                this.dni.CssClass = removeIsInvalidClass(this.dni.CssClass);
            }

            return valid;
        }

        private bool validateName()
        {
            bool valid = true;
            string nametxt = this.name.Text.Trim();

            if (string.IsNullOrEmpty(nametxt))
            {
                this.name.CssClass = addIsInvalidClass(this.name.CssClass);
                this.nameError.Text = "Debe completar el campo.";
                valid = false;
            }
            else if (nametxt.Any(char.IsDigit) || !nametxt.All(char.IsLetter))
            {
                this.name.CssClass = addIsInvalidClass(this.name.CssClass);
                this.nameError.Text = "Ingrese solo letras.";
                valid = false;
            }else
            {
                this.name.CssClass = removeIsInvalidClass(this.name.CssClass);
            }

            return valid;
        }

        private bool validateSurname()
        {
            bool valid = true;
            string surnametxt = this.surname.Text.Trim();

            if (string.IsNullOrEmpty(surnametxt))
            {
                this.surname.CssClass = addIsInvalidClass(this.surname.CssClass);
                this.surnameError.Text = "Debe completar el campo.";
                valid = false;
            }
            else if (surnametxt.Any(char.IsDigit) || !surnametxt.All(char.IsLetter))
            {
                this.surname.CssClass = addIsInvalidClass(this.surname.CssClass);
                this.surnameError.Text = "Ingrese solo letras.";
                valid = false;
            }
            else
            {
                this.surname.CssClass = removeIsInvalidClass(this.surname.CssClass);
            }

            return valid;
        }

        private bool validateEmail()
        {
            bool valid = true;
            var trimmedEmail = this.email.Text.Trim();
            var email = new EmailAddressAttribute();

            if (string.IsNullOrEmpty(trimmedEmail))
            {
                this.email.CssClass = addIsInvalidClass(this.email.CssClass);
                this.emailError.Text = "Debe completar el campo.";
                valid = false;
            }else if (!email.IsValid(trimmedEmail))
            {
                this.email.CssClass = addIsInvalidClass(this.email.CssClass);
                this.emailError.Text = "Email no válido.";
                valid = false;
            }
            else
            {
                this.email.CssClass = removeIsInvalidClass(this.email.CssClass);
            }

            return valid;
        }

        private bool validateAddress()
        {
            bool valid = true;
            string address = this.address.Text.Trim();

            if (string.IsNullOrEmpty(address))
            {
                this.address.CssClass = addIsInvalidClass(this.address.CssClass);
                this.addressError.Text = "Debe completar el campo.";
                valid = false;
            }else if (address.Any(ch => !char.IsLetterOrDigit(ch) && ch != ' '))
            {
                this.address.CssClass = addIsInvalidClass(this.address.CssClass);
                this.addressError.Text = "Dirección no válida.";
                valid = false;
            }
            else
            {
                this.address.CssClass = removeIsInvalidClass(this.address.CssClass);
            }
            return valid;
        }

        private bool validateCity()
        {
            bool valid = true;
            string cityTxt = this.city.Text.Trim();

            if (string.IsNullOrEmpty(cityTxt))
            {
                this.city.CssClass = addIsInvalidClass(this.city.CssClass);
                this.cityError.Text = "Debe completar el campo.";
                valid = false;
            }
            else if (cityTxt.Any(char.IsDigit))
            {
                this.city.CssClass = addIsInvalidClass(this.city.CssClass);
                this.cityError.Text = "Ciudad no válida.";
                valid = false;
            }
            else
            {
                this.city.CssClass = removeIsInvalidClass(this.city.CssClass);
            }
            return valid;
        }

        private bool validateCP()
        {
            bool valid = true;
            string cpTxt = this.cp.Text.Trim();

            if (string.IsNullOrEmpty(cpTxt))
            {
                this.cp.CssClass = addIsInvalidClass(this.cp.CssClass);
                this.cpError.Text = "Debe completar el campo.";
                valid = false;
            }
            else if (!cpTxt.All(char.IsDigit) || cpTxt.Length < 4)
            {
                this.cp.CssClass = addIsInvalidClass(this.cp.CssClass);
                this.cpError.Text = "Código postal no válido.";
                valid = false;
            }
            else
            {
                this.cp.CssClass = removeIsInvalidClass(this.cp.CssClass);
            }
            return valid;
        }

        private bool validateAccept()
        {
            bool valid = true;
            if (!this.accept.Checked)
            {
                this.accept.CssClass = addIsInvalidClass(this.accept.CssClass);
                this.acceptError.Text = "Debe aceptar los términos y condiciones.";
                valid = false;
            }
            else
            {
                this.accept.CssClass = removeIsInvalidClass(this.accept.CssClass);
            }
            return valid;
        }

        private void sendMail(string email, string nombreCompleto)
        {
            try
            {
                var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
                var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
                var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
                var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

                string body = $"Canjeaste el producto {item.Marca} - {item.Nombre} a través del codigo {voucherCode}. ¡Que lo disfrutes!";
                MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(email, nombreCompleto));
                message.Subject = "Promo voucher - Registro exitoso.";
                message.IsBodyHtml = true;
                message.Body = body;

                var client = new SmtpClient();
                client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
                client.Host = smtpHost;
                client.EnableSsl = true;
                client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw (new Exception("Error al enviar email."));
            }
        }

        protected void dni_TextChanged(object sender, EventArgs e)
        {
            if (validateDni())
            {
                ClientBussiness clientBussiness = new ClientBussiness();
                Cliente search = new Cliente();
                search.Documento = this.dni.Text;

                Cliente c = clientBussiness.getOne(search);

                if (c != null)
                {
                    // Definimos que no hay que guardar este cliente porque ya existe
                    Session.Add("newuser", false);

                    this.name.Text = c.Nombre;
                    this.surname.Text = c.Apellido;
                    this.email.Text = c.Email;
                    this.address.Text = c.Direccion;
                    this.city.Text = c.Ciudad;
                    this.cp.Text = c.CodigoPostal.ToString();
                }

            }
        }
    }
}