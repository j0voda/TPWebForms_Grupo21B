<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SelectPrize.aspx.cs" Inherits="TPWebForms_Grupo21B.SelectPrize" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2 class="mb-4">Selecciona el premio que quieras!!!</h2>
        <div class="row row-cols-3 gap-2">
            <% foreach (dominio.Articulo item in Articulos)
                { %>
            <div class="card p-2" style="width: 30%; height: 450px; justify-content: space-between" data-id="<%: item.Codigo %>">
                <div id="<%:item.Codigo %>-carousel" class="carousel slide h-50 card-header">
                    <div class="carousel-indicators">
                        <%
                            for (int i = 0; i < item.Urls.Count; i++)
                            {
                        %>
                        <button type="button" data-bs-target="#<%:item.Codigo %>-carousel" data-bs-slide-to="<%: i %>" class="<%: i == 0 ? "active" : "" %> border border-2" aria-current="true" aria-label="Slide <%: i %>"></button>
                        <% } %>
                    </div>
                    <div class="carousel-inner h-100">
                        <%
                            for (int i = 0; i < item.Urls.Count; i++)
                            {
                        %>
                        <div class="carousel-item h-100 <%: i == 0 ? "active" : "" %>">
                            <img src="<%:item.Urls[i].Url %>" class="d-block h-100 w-100" alt="<%#Eval("Nombre") %>-imagen" style="object-fit: contain">
                        </div>
                        <% } %>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#<%:item.Codigo %>-carousel" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#<%:item.Codigo %>-carousel" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
                <div class="card-body d-flex flex-column align-items-start">
                    <h5 class="card-title"><%: item.Nombre %></h5>
                    <p class="card-text flex-grow-1"><%: item.Descripcion %></p>
                    <a href="UserFormData.aspx?item=<%: item.Codigo %>" class="btn btn-primary">Elegi este</a>
                </div>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>
