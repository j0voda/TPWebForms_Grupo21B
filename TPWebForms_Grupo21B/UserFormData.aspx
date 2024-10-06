<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserFormData.aspx.cs" Inherits="TPWebForms_Grupo21B.UserFormData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Completá el formulario con tus datos.</h1>
            <asp:Label ID="lblVoucher" runat="server" Text=""></asp:Label>
        </section>

        <asp:Label runat="server" CssClass="control-label mb-1" AssociatedControlID="dni">DNI: </asp:Label>
        <asp:TextBox ID="dni" runat="server" MaxLength="8" CssClass="form-control" ClientIDMode="Static" placeholder="99999999" OnTextChanged="dni_TextChanged" AutoPostBack="true"></asp:TextBox>
        <asp:Label runat="server" ID="dniError" CssClass="invalid-feedback"></asp:Label>

        <br/>

        <div class="row">
            <div class="col-3">
                <asp:Label runat="server" CssClass="control-label mb-1" AssociatedControlID="name">Nombre: </asp:Label>
                <asp:TextBox ID="name" runat="server" CssClass="form-control" ClientIDMode="Static" MaxLength="30" OnTextChanged="name_TextChanged"></asp:TextBox>
                <asp:Label runat="server" ID="nameError" CssClass="invalid-feedback"></asp:Label>
            </div>

            <div class="col-3">
                <asp:Label runat="server" CssClass="control-label mb-1" AssociatedControlID="surname">Apellido: </asp:Label>
                <asp:TextBox ID="surname" runat="server" CssClass="form-control" ClientIDMode="Static" MaxLength="30"></asp:TextBox>
                <asp:Label runat="server" ID="surnameError" CssClass="invalid-feedback"></asp:Label>
            </div>

            <div class="col-3">
                <asp:Label runat="server" CssClass="control-label mb-1" AssociatedControlID="email">Email: </asp:Label>
                <asp:TextBox ID="email" runat="server" CssClass="form-control" ClientIDMode="Static" AutoCompleteType="Email" MaxLength="30"></asp:TextBox><!--placeholder="email@email.com"-->
                <asp:Label runat="server" ID="emailError" CssClass="invalid-feedback"></asp:Label>
            </div>
        </div>

        <br/>

        <div class="row">
            <div class="col-3">
                <asp:Label runat="server" CssClass="control-label mb-1" AssociatedControlID="address">Dirección: </asp:Label>
                <asp:TextBox runat="server" ID="address" Width="100%" CssClass="form-control" ClientIDMode="Static" placeholder="Calle 123" MaxLength="30"></asp:TextBox>
                <asp:Label runat="server" ID="addressError" CssClass="invalid-feedback"></asp:Label>
            </div>

            <div class="col-3">
                <asp:Label runat="server" CssClass="control-label mb-1" AssociatedControlID="city">Ciudad: </asp:Label>
                <asp:TextBox ID="city" runat="server" CssClass="form-control" ClientIDMode="Static" MaxLength="30"></asp:TextBox>
                <asp:Label runat="server" ID="cityError" CssClass="invalid-feedback"></asp:Label>
            </div>

            <div class="col-2">
                <asp:Label runat="server" CssClass="control-label mb-1" AssociatedControlID="cp">Código Postal: </asp:Label>
                <asp:TextBox ID="cp" runat="server" CssClass="form-control" MaxLength="4" ClientIDMode="Static" placeholder="9999"></asp:TextBox>
                <asp:Label runat="server" ID="cpError" CssClass="invalid-feedback"></asp:Label>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-4">
                <asp:CheckBox runat="server" ID="accept" Text="&nbsp; He leído y acepto los términos y condiciones." TextAlign="Right" OnCheckedChanged="accept_CheckedChanged"/>
                <asp:Label runat="server" ID="acceptError" CssClass="invalid-feedback"></asp:Label>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-2">
                <asp:Button ID="btnSubmit" runat="server" Text="Participar" CssClass="btn btn-primary mt-2" OnClick="btnSubmit_Click"/>
            </div>
        </div>
    </main>
</asp:Content>
