<%@ Page Title="" Language="C#" MasterPageFile="~/bibliotecar/bibliotecar.Master" AutoEventWireup="true" CodeBehind="modifica_carte.aspx.cs" Inherits="Biblioteca.bibliotecar.modifica_carte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

<div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Modificare cărți</strong>
                        </div>
                        <div class="card-body">
                       
                          <div id="pay-invoice">
                              <div class="card-body">
                                 
                                  
                                  <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">   
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Titlu</label>
                                          <asp:TextBox ID="titlu" runat="server" class="form-control"></asp:TextBox>
                                      </div>

                                       <div class="form-group">
                                          <label for="" class="control-label mb-1">Copertă</label><br />
                                           <asp:Label ID="copertacarte" runat="server" Text=""></asp:Label>
                                          <asp:FileUpload ID="f1" runat="server" class="form-control" />
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">PDF</label><br />
                                            <asp:Label ID="pdfcarte" runat="server" Text=""></asp:Label>
                                          <asp:FileUpload ID="f2" runat="server" class="form-control" />
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Video</label><br />
                                          <asp:Label ID="videocarte" runat="server" Text=""></asp:Label>
                                          <asp:FileUpload ID="f3" runat="server" class="form-control" />
                                      </div>
                                       <div class="form-group">
                                          <label for="" class="control-label mb-1">Autor</label>
                                          <asp:TextBox ID="autor" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                       <div class="form-group">
                                          <label for="" class="control-label mb-1">ISBN</label>
                                          <asp:TextBox ID="isbn" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                       <div class="form-group">
                                          <label for="" class="control-label mb-1">Cantitate</label>
                                          <asp:TextBox ID="cantitate" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                     
                                    
                                      <div>
                                       
                                          <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Modifică" OnClick="b1_Click"/>
                                      </div>
                                      
                                  </form>
                              </div>
                          </div>

                        </div>
                    </div>

                  </div>

</asp:Content>
