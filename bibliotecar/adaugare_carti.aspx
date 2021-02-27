<%@ Page Title="" Language="C#" MasterPageFile="~/bibliotecar/bibliotecar.Master" AutoEventWireup="true" CodeBehind="adaugare_carti.aspx.cs" Inherits="Biblioteca.bibliotecar.adaugare_carti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

<div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Adaugă Cărți Noi</strong>
                        </div>
                        <div class="card-body">                      
                          <div id="pi">
                              <div class="card-body">                                                                  
                                  <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">   
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Titlu</label>
                                          <asp:TextBox ID="titlu" runat="server" class="form-control"></asp:TextBox>
                                      </div>

                                       <div class="form-group">
                                          <label for="" class="control-label mb-1">Copertă</label>
                                          <asp:FileUpload ID="f1" runat="server" class="form-control" />
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">PDF</label>
                                          <asp:FileUpload ID="f2" runat="server" class="form-control" />
                                      </div>
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Video</label>
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
                                          <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Adaugă" OnClick="b1_Click"/>
                                      </div>
                                       <div class="alert alert-success" id="msg" runat="server" style="margin-top:10px; display:none">
                                         <strong>Cartea a fost adăugată cu succes!</strong>
                                    </div>
                                  </form>
                              </div>
                          </div>
                        </div>
                    </div>
                  </div>
</asp:Content>
