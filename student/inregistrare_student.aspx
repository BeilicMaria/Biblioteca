<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inregistrare_student.aspx.cs" Inherits="Biblioteca.student.inregistrare_student" %>

<!doctype html>
<!--[if gt IE 8]><!--> <html class="no-js" lang=""> <!--<![endif]-->
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Înregistrare Student</title>
    <meta name="description" content="Bibliotecă">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="assets/css/normalize.css">
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/font-awesome.min.css">
    <link rel="stylesheet" href="assets/css/themify-icons.css">
    <link rel="stylesheet" href="assets/css/flag-icon.min.css">
    <link rel="stylesheet" href="assets/css/cs-skin-elastic.css">
    <!-- <link rel="stylesheet" href="assets/css/bootstrap-select.less"> -->
    <link rel="stylesheet" href="assets/scss/style.css">
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>
    <!-- <script type="text/javascript" src="https://cdn.jsdelivr.net/html5shiv/3.7.3/html5shiv.min.js"></script> -->
</head>
<body class="bg-dark">
    <div class="sufee-login d-flex align-content-center flex-wrap">
        <div class="container">
            <div class="login-content">
                <div class="login-logo">                 
                </div>
                <div class="login-form">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <label>Prenume</label>                          
                            <asp:TextBox ID="prenume" runat="server"  class="form-control" placeholder="Prenume"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Nume</label>
                           <asp:TextBox ID="nume" runat="server"  class="form-control" placeholder="Nume"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Număr de înregistrare</label>
                             <asp:TextBox ID="nrinregistrare" runat="server"  class="form-control" placeholder="Număr de înregistrare"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>Utilizator</label>
                             <asp:TextBox ID="utilizator" runat="server"  class="form-control" placeholder="Utilizator"></asp:TextBox>
                        </div>

                         <div class="form-group">
                            <label>Parola</label>
                             <asp:TextBox ID="parola" runat="server"  class="form-control" placeholder="Parola" TextMode="Password"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>Email</label>
                             <asp:TextBox ID="email" runat="server"  class="form-control" placeholder="Email"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>Contact</label>
                             <asp:TextBox ID="contact" runat="server"  class="form-control" placeholder="Contact"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>Imagine de profil</label>
                            <asp:FileUpload ID="f1" runat="server" /> 
                        </div>                         
                        <div class="form-group">                           
                           <div id="ReCaptchContainer"></div>
                            <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                        </div> 
                        <asp:Button ID="b1" runat="server" class="btn btn-primary btn-flat m-b-30 m-t-30" Text="Înregistrează-te" OnClick="b1_Click" />                                              
                    </form>
                </div>
            </div>
        </div>
    </div>
    
    <!-- test de încercare pentru a distinge oamenii și roboții. -->

    <script src="https://www.google.com/recaptcha/api.js?onload=renderRecaptcha&render=explicit" async defer></script>
    <script type="text/javascript">
        var your_site_key = '6LfaDsQZAAAAANxtwpvUu5emqRxlpD6hE1nd-8IC';
        var renderRecaptcha = function () {
            grecaptcha.render('ReCaptchContainer', {
                'sitekey': '6LfaDsQZAAAAANxtwpvUu5emqRxlpD6hE1nd-8IC',
                'callback': reCaptchaCallback,
                theme: 'light', //light or dark
                type: 'image',// image or audio
                size: 'normal'//normal or compact
            });
        };
        var reCaptchaCallback = function (response) {
            if (response !== '') {
                document.getElementById('lblMessage1').innerHTML = "";
            }
        };
       </script>
    <script src="assets/js/vendor/jquery-2.1.4.min.js"></script>
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/main.js"></script>


</body>
</html>
