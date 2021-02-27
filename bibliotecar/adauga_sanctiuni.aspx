<%@ Page Title="" Language="C#" MasterPageFile="~/bibliotecar/bibliotecar.Master" AutoEventWireup="true" CodeBehind="adauga_sanctiuni.aspx.cs" Inherits="Biblioteca.bibliotecar.adauga_sanctiuni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Adaugă/Modifică sancțiuni</strong>
                        </div>
                        <div class="card-body">
                       
                          <div id="pay-invoice">
                              <div class="card-body">
                                 
                                  
                                  <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">   
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Adaugă/Modifică sancțiuni (lei)</label>
                                          <asp:TextBox ID="sanctiune" runat="server" class="form-control"></asp:TextBox>
                                      </div>                                                                         
                                      <div>
                                       
                                          <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Adaugă" OnClick="b1_Click"/>
                                      </div>                                    
                                  </form>
                              </div>
                          </div>

                        </div>
                    </div>

                  </div>


</asp:Content>
