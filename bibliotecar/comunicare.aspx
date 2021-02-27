<%@ Page Title="" Language="C#" MasterPageFile="~/bibliotecar/bibliotecar.Master" AutoEventWireup="true" CodeBehind="comunicare.aspx.cs" Inherits="Biblioteca.bibliotecar.comunicare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="row" style="margin: 10px;">
        <div class="col-lg-12" style="height: 400px; border-style: solid; border-width: 1px; background-color: white; overflow: auto" id="msgarea"></div>
        <div class="col-lg-12" style="height: 80px; border-style: solid; border-width: 1px; background-color: white; margin-top: 5px">
            <div class="col-lg-11">
                <br />
                <input type="text" id="t1" class="form-control">
            </div>
            <div class="col-lg-1">
                <br />
                <input type="button" id="b1" class="btn btn-success" value="Trimite" onclick="send_message();" />
            </div>
        </div>
    </div>
    <script type="text/javascript">

        //functie trimite mesaj
        var utilizator = getUrlVars()["utilizator"];
        function send_message() {
            var xmlhttp = new XMLHttpRequest(); //obiect nou de tip  XMLHttpRequest
            xmlhttp.onreadystatechange = function () { // eveniment declansat de schimbarea readyState 
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) { //readyState tine statusul XMLHttpRequest care se schimba de la 0 la 4 ( 0: request not initialized
                    //1: server connection established
                    //2: request received
                    //3: processing request
                    //4: request finished and response is ready)
                    var theDiv = document.getElementById("msgarea");
                    var x = document.createElement("P");
                    var t = document.createTextNode("bibliotecar:" + document.getElementById("t1").value); //variabila t contine mesajul de la bibliotecar, folosim textnode pentru paragrafe  
                    x.appendChild(t); //anexeaza nodul in documentul creat 
                    theDiv.appendChild(x); //anexeaza documentul in msgarea
                    var y = document.createElement("HR");
                    theDiv.appendChild(y);
                    theDiv.scrollTop = theDiv.scrollHeight;
                    document.getElementById("t1").value = "";
                }
            };
            xmlhttp.open("GET", "mesaje_trimise_de_bibliotecar.aspx?utilizator=" + utilizator + "&msg=" + document.getElementById("t1").value, true); //specifica tipul cererii, locatia si daca este asincron/sincron
            xmlhttp.send(); //trimite o cerere la server 
        }
        //functie incarca mesaje 
        function load_messages() {
            var xmlhttp = new XMLHttpRequest(); //obiect nou de tip  XMLHttpRequest
            xmlhttp.onreadystatechange = function () { // eveniment declansat de schimbarea readyState 
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) { //readyState tine statusul XMLHttpRequest care se schimba de la 0 la 4
                    document.getElementById("msgarea").innerHTML = xmlhttp.responseText; //returneaza data sub forma de string 
                }
            };
            xmlhttp.open("GET", "incarca_mesaje.aspx?utilizator=" + utilizator, true); //specifica tipul cererii, locatia si daca este asincron/sincron
            xmlhttp.send(); //trimite o cerere la server 
        }
        load_messages();
        //functie actualizare mesaje
        function add_inside_new_message() {
            var xmlhttp = new XMLHttpRequest(); //obiect nou de tip  XMLHttpRequest
            xmlhttp.onreadystatechange = function () { // eveniment declansat de schimbarea readyState 
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) { //readyState tine statusul XMLHttpRequest care se schimba de la 0 la 4
                    if (xmlhttp.responseText != "0") { //verifica daca string-ul rezultat este 0
                        var strArray = xmlhttp.responseText.split("||abcd||"); //obtinem un vector prin impartirea string ului
                        for (var i = 0; i < strArray.length; i++) { //actualizarea chat ului
                            var theDiv = document.getElementById("msgarea");
                            var x = document.createElement("P");
                            var t = document.createTextNode(strArray[i]);
                            x.appendChild(t);
                            theDiv.appendChild(x);
                            var y = document.createElement("HR");
                            theDiv.appendChild(y);
                            theDiv.scrollTop = theDiv.scrollHeight;


                        }
                    }

                }
            };
            xmlhttp.open("GET", "incarca_mesaje_noi.aspx?utilizator=" + utilizator, true);  //specifica tipul cererii, locatia si daca este asincron/sincron
            xmlhttp.send(); //trimite o cerere la server 
        }

        //mesajele apar la 10 secunde 
        setInterval(function () { 
            add_inside_new_message();
        }, 10000);

        //functia returneaza parametrii din pagina ceruta cu separarea in componente mai usor de procesat (parse)
        function getUrlVars() {
            var vars = {};
            var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
                vars[key] = value;
            });
            return vars;
        }

    </script>
</asp:Content>
