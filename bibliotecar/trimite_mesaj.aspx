﻿<%@ Page Title="" Language="C#" MasterPageFile="~/bibliotecar/bibliotecar.Master" AutoEventWireup="true" CodeBehind="trimite_mesaj.aspx.cs" Inherits="Biblioteca.bibliotecar.trimite_mesaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">


      <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
<div class="container-fluid" style="background-color:white; padding:20px">
<asp:Repeater ID="r1" runat="server">

    <HeaderTemplate>
        <table class="table table-bordered" id="example">
            <thead>
            <tr>
                <th>Imagine de profil</th>
                <th>Prenume</th>
                <th>Nume</th>
                <th>Număr de înregistrare</th>
                <th>Utilizator</th>
                <th>Email</th>
                <th>Contact</th>
                <th>Status</th>  
                <th>Mesaj</th>
                
                
            </tr>
        </thead>
<tbody>
    </HeaderTemplate>


    <ItemTemplate>
        <tr>
            <td><img src="../<%#Eval("imagine_student") %>"" height="100" width="75" /></td>
            <td><%#Eval("prenume") %></td>
            <td> <%#Eval("nume") %></td>
            <td><%#Eval("numar") %></td>
            <td><%#Eval("utilizator") %></td>
            <td><%#Eval("email") %></td>
            <td><%#Eval("contact") %></td>
            <td><%#Eval("aprobat") %></td>
            <td><a href="comunicare.aspx?utilizator=<%#Eval("utilizator") %>">Trimite Mesaj</a></td>
           
        </tr>

    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
    </div>
     <script type="text/javascript">
         $(document).ready(function () {
             $('#example').DataTable(
                 {
                     "pagingType": "full_numbers"
                 });
         });
    </script>
</asp:Content>
