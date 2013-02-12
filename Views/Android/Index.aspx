<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Index</title>
    <script type="text/javascript" src="../../Scripts/jquery-1.8.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            setInterval(Load, 2500);
            Load();
        });
        function Save() {
            var data2 = document.getElementById("Text2").value;
            $.post("../../Android/SaveData", { "data": data2 },
             function (data) {
                 if (data == "Saved") {
                     document.getElementById("Text2").value = "Saved";
                 }
             });
        }
        function Load() {
            var xmlhttp;
            if (window.XMLHttpRequest) { xmlhttp = new XMLHttpRequest(); } else { xmlhttp = new ActiveXObject("Microsoft.XMLHTTP"); }

            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById("Text1").value = xmlhttp.responseText;
                }
            }
            xmlhttp.open("GET", "../../Android/LoadData/", true);
            xmlhttp.send();

        }
    </script>
    <style type="text/css">
        #Text1
        {
            width: 280px;
        }
        #Text2
        {
            width: 280px;
        }
    </style>
</head>
<body>
    <div>
        
        <input id="Text1" type="text" /></div>
         <div>
        
        <input id="Button2" type="button" value="Save"  onclick="Save();"/>&nbsp;&nbsp;
        <input id="Text2" type="text" /></div>
</body>
</html>
