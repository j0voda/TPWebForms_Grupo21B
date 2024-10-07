<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Success.aspx.cs" Inherits="TPWebForms_Grupo21B.Success" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">¡Registro completado con éxito!</h1>
            <p class="lead">Puede cerrar la página o cargar otro código.</p>
        </section>

        <div class="row">
            <div class="col-2">
                <asp:Button ID="btnSubmit" runat="server" Text="Cargar nuevo código" CssClass="btn btn-primary mt-2" OnClick="btnSubmit_Click"/>
            </div>
        </div>
    </main>
</asp:Content>