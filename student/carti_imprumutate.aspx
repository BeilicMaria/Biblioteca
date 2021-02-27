<%@ Page Title="" Language="C#" MasterPageFile="~/student/student.Master" AutoEventWireup="true" CodeBehind="carti_imprumutate.aspx.cs" Inherits="Biblioteca.student.carti_imprumutate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

     <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Cărțile mele</h1>
                </div>
            </div>
        </div>

    </div>

    <div class="container-fluid" style="min-height:500px; background-color:white">
       <asp:DataList ID="d1" runat="server">
           <HeaderTemplate>
               <table class="table table-bordered">
                   <tr>
                       <th>Număr inregistrare</th>
                       <th>ISBN</th>
                       <th>Data împrumut</th>
                       <th>Data returnare (aproximativă)</th>
                       <th>Utilizator</th>
                       <th>Returnată?</th>
                       <th>Data returnare</th>
                       <th>Întârziere</th>
                       <th>Sancțiuni (lei)</th>
                   </tr>
           </HeaderTemplate>
           <ItemTemplate>
               <tr> 
                   <td><%#Eval("numar_inregistrare_student") %></td>
                   <td><%#Eval("isbn_carte") %></td>
                   <td><%#Eval("data_imprumut") %></td>
                   <td><%#Eval("data_returnare_aproximativa") %></td>
                   <td><%#Eval("utilizator_student") %></td>
                   <td><%#Eval("este_returnata") %></td>
                   <td><%#Eval("data_returnare") %></td>
                   <td><%#Eval("zile_intarziere") %></td>  
                   <th><%#Eval("sanctiune")%></th>
               </tr>
           </ItemTemplate>
           <FooterTemplate>
               </table>
           </FooterTemplate>
       </asp:DataList>
    </div>

    
</asp:Content>
