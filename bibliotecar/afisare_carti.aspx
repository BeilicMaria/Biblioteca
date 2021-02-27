<%@ Page Title="" Language="C#" MasterPageFile="~/bibliotecar/bibliotecar.Master" AutoEventWireup="true" CodeBehind="afisare_carti.aspx.cs" Inherits="Biblioteca.bibliotecar.afisare_carti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
     <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Cărți Disponibile</strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                     <table class="table" id="example">
                              <thead class="thead-dark">
                                <tr>
                                  <th scope="col">Coperta</th>
                                  <th scope="col">Titlu</th>                                  
                                  <th scope="col">PDF</th>
                                  <th scope="col">Video</th>
                                  <th scope="col">Autor</th>
                                  <th scope="col">ISBN</th>
                                  <th scope="col">Cantitate</th>
                                  <th scope="col">Editare</th>
                                  <th scope="col">Ștergere</th>
                                </tr>
                              </thead>
                               <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                     <tr>
                                  <td><img src="<%#Eval("coperta_carte") %>" height="100" width="60" /></td>
                                  <td><%#Eval("titlu_carte") %></td>
                                  <td><%#Eval("pdf_carte") %>  <br /> <%#verificapdf(Eval("pdf_carte"),Eval("id")) %></td>
                                  <td><%#Eval("video_carte") %> <br /> <%#verificavideo(Eval("video_carte"),Eval("id")) %></td>
                                  <td><%#Eval("autor_carte") %></td>
                                  <td><%#Eval("isbn_carte") %></td>
                                  <td><%#Eval("cantitate_carte") %></td>
                                  <td><a href="modifica_carte.aspx?id=<%#Eval("id") %>">Modifică</a></td>
                                  <td><a href="sterge.aspx?id2=<%#Eval("id") %>">Șterge</a></td>

                                </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                     </tbody>
                            </table>
                                </FooterTemplate>
                            </asp:Repeater>
                           
                              <tbody>
                        </div>
                    </div>
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
