<%@ Page Title="" Language="C#" MasterPageFile="~/bibliotecar/bibliotecar.Master" AutoEventWireup="true" CodeBehind="imprumut_carti.aspx.cs" Inherits="Biblioteca.bibliotecar.imprumut_carti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Împrumut Cărți</strong>
                        </div>
                        <div class="card-body">
                       
                          <div id="pay-invoice">
                              <div class="card-body">                                  
                                  <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">   
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Număr de înregistrare</label>
                                          <asp:DropDownList ID="nrinr" runat="server" class="form-control"></asp:DropDownList>
                                      </div>
                                       <div class="form-group">
                                          <label for="" class="control-label mb-1">ISBN</label>
                                        <asp:DropDownList ID="isbn" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="isbn_SelectedIndexChanged"></asp:DropDownList>
                                      </div>
                                      <div class="form-group">
                                          <asp:Image ID="i1" runat="server" Height="150" Width="100" /><br />
                                          <asp:Label ID="numecarte" runat="server"></asp:Label><br />
                                           <asp:Label ID="instoc" runat="server"></asp:Label><br />
                                      </div>                                     
                                      <div>                                       
                                          <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Împrumută cărți" OnClick="b1_Click" />
                                      </div>                                      
                                  </form>
                              </div>
                          </div>
                        </div>
                    </div>
                  </div>
</asp:Content>
