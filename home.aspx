<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Biblioteca.home" %>

<!doctype html>
<head> 
    <title>Bibliotecă</title>
</head>
<body class="bg-dark" style="background-color:cornsilk">
     <div class="p-5 text-white has-bg-img">
                    <img src="/bibliotecar/images/rsz_1rsz_22.jpg"  class="bg-img" alt="Background Image" style="position:absolute; top:185px; left: 10px;" >
                

        <div class="container" >
            <div class="bg"></div>


            <div class="login-content">
                     <center> <h1 style="color:black; font-family:'Courier New'; ">Bibliotecă</h1> </center> 

                </div>
                <div class="login-form" style="background-color:wheat">
                    <form id="f1" runat="server">
      <br />
                       <center> <asp:Button ID="b1" runat="server" Text="Bibliotecar" BackColor="#996633" class="btn btn-success btn-flat m-b-30 m-t-30" OnClick="b1_Click" > </asp:Button><br /></center>
                        <br />
                       <center>  <asp:Button ID="b2" runat="server" Text="Student" BackColor="#996633" class="btn btn-success btn-flat m-b-30 m-t-30" OnClick="b2_Click" Width="80px" > </asp:Button><br /> </center>
                        <br />

                       
                        
                    </form>
                </div>
                 
        </div>
          </div>

</body>

