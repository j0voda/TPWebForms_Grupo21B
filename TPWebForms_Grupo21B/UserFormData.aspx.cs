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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void accept_CheckedChanged(object sender, EventArgs e)
        {
            //Hola
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            validateDni();
            validateName();
            validateSurname();
            validateEmail();
            validateAddress();
            validateCity();
            validateCP();
            validateAccept();

            labelResults.Text = dni.Text + " " + name.Text + " " + surname.Text;
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

        private void validateName()
        {
            string nametxt = this.name.Text.Trim();

            if (string.IsNullOrEmpty(nametxt))
            {
                this.name.CssClass = addIsInvalidClass(this.name.CssClass);
                this.nameError.Text = "Debe completar el campo.";
            }
            else if (nametxt.Any(char.IsDigit) || !nametxt.All(char.IsLetter))
            {
                this.name.CssClass = addIsInvalidClass(this.name.CssClass);
                this.nameError.Text = "Ingrese solo letras.";
            }else
            {
                this.name.CssClass = removeIsInvalidClass(this.name.CssClass);
            }
        }

        private void validateSurname()
        {
            string surnametxt = this.surname.Text.Trim();

            if (string.IsNullOrEmpty(surnametxt))
            {
                this.surname.CssClass = addIsInvalidClass(this.surname.CssClass);
                this.surnameError.Text = "Debe completar el campo.";
            }
            else if (surnametxt.Any(char.IsDigit) || !surnametxt.All(char.IsLetter))
            {
                this.surname.CssClass = addIsInvalidClass(this.surname.CssClass);
                this.surnameError.Text = "Ingrese solo letras.";
            }
            else
            {
                this.surname.CssClass = removeIsInvalidClass(this.surname.CssClass);
            }
        }

        private void validateEmail()
        {
            var trimmedEmail = this.email.Text.Trim();
            var email = new EmailAddressAttribute();

            if (string.IsNullOrEmpty(trimmedEmail))
            {
                this.email.CssClass = addIsInvalidClass(this.email.CssClass);
                this.emailError.Text = "Debe completar el campo.";
            }else if (!email.IsValid(trimmedEmail))
            {
                this.email.CssClass = addIsInvalidClass(this.email.CssClass);
                this.emailError.Text = "Email no válido.";
            }
            else
            {
                this.email.CssClass = removeIsInvalidClass(this.email.CssClass);
            }
        }

        private void validateAddress()
        {
            string address = this.address.Text.Trim();

            if (string.IsNullOrEmpty(address))
            {
                this.address.CssClass = addIsInvalidClass(this.address.CssClass);
                this.addressError.Text = "Debe completar el campo.";
            }else if (address.Any(ch => !char.IsLetterOrDigit(ch) && ch != ' '))
            {
                this.address.CssClass = addIsInvalidClass(this.address.CssClass);
                this.addressError.Text = "Dirección no válida.";
            }
            else
            {
                this.address.CssClass = removeIsInvalidClass(this.address.CssClass);
            }
        }

        private void validateCity()
        {
            string cityTxt = this.city.Text.Trim();

            if (string.IsNullOrEmpty(cityTxt))
            {
                this.city.CssClass = addIsInvalidClass(this.city.CssClass);
                this.cityError.Text = "Debe completar el campo.";
            }
            else if (cityTxt.Any(char.IsDigit))
            {
                this.city.CssClass = addIsInvalidClass(this.city.CssClass);
                this.cityError.Text = "Ciudad no válida.";
            }
            else
            {
                this.city.CssClass = removeIsInvalidClass(this.city.CssClass);
            }
        }

        private void validateCP()
        {
            string cpTxt = this.cp.Text.Trim();

            if (string.IsNullOrEmpty(cpTxt))
            {
                this.cp.CssClass = addIsInvalidClass(this.cp.CssClass);
                this.cpError.Text = "Debe completar el campo.";
            }
            else if (!cpTxt.All(char.IsDigit) || cpTxt.Length < 4)
            {
                this.cp.CssClass = addIsInvalidClass(this.cp.CssClass);
                this.cpError.Text = "Código postal no válido.";
            }
            else
            {
                this.cp.CssClass = removeIsInvalidClass(this.cp.CssClass);
            }
        }

        private void validateAccept()
        {
            if (!this.accept.Checked)
            {
                this.accept.CssClass = addIsInvalidClass(this.accept.CssClass);
                this.acceptError.Text = "Debe aceptar los términos y condiciones.";
            }
            else
            {
                this.accept.CssClass = removeIsInvalidClass(this.accept.CssClass);
            }
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

                string body = "Su registro para la promoción del grupo 21 B ha sido realizada con éxito. ¡Gracias!.";
                MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(email, nombreCompleto));
                message.Subject = "Registro exitoso.";
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