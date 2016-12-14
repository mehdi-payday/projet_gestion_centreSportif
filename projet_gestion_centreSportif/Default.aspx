<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="projet_gestion_centreSportif._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <div id="myCarousel" class="row carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
            <li data-target="#myCarousel" data-slide-to="3"></li>
            <li data-target="#myCarousel" data-slide-to="4"></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img runat="server" src="~/Content/Images/About/carousel1.jpg" alt="Chania">
            </div>
            <div class="item">
                <img runat="server" src="~/Content/Images/About/carousel2.jpg" alt="Flower">
            </div>
            <div class="item">
                <img runat="server" src="~/Content/Images/About/carousel3.jpg" alt="Flower">
            </div>
            <div class="item">
                <img runat="server" src="~/Content/Images/About/carousel4.jpg" alt="Flower">
            </div>
        </div>
    
        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <div class="row">
        <h1>Centre Sportif Claude Robillard</h1>
        <p class="lead">Nous offrons toutes sortes d'activités!</p>
        <p><a runat="server" href="~/About" class="btn btn-primary btn-lg">En savoir plus &raquo;</a></p>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('.carousel').carousel({
            interval: 3000,
            pause: "false"
        });
    });
</script>
</asp:Content>
