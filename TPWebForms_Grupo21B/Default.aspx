<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebForms_Grupo21B._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Canjea tu premio de forma sensilla</h1>
            <p class="lead">Simplemente completa con el código de tu voucher y recibe el premio que quieras</p>
        </section>

        <asp:Label runat="server" CssClass="control-label mb-1" AssociatedControlID="code">Introducí el código de tu voucher</asp:Label>
        <asp:TextBox ID="code" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="XXXXXXXXXXXXXXXXXXXXX" OnTextChanged="code_TextChanged" AutoPostBack="true"></asp:TextBox>

        <asp:Button ID="btnNext" runat="server" Text="Siguiente" CssClass="btn btn-primary mt-2" OnClick="btnNext_Click" />
    </main>

</asp:Content>
