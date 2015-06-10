<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="tynasProject.Page.Posts" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #main {
            width:80%;
            margin-left:auto;
            margin-right:auto;
            margin-bottom:50px;
            margin-top:20px;
            height:870px;
            background-color:orange  ;
            border-radius:20px;
            box-shadow: 0 0 12px 1px #999 inset;
        }

        #logotop {
            width:100%;
            margin-left:auto;
            margin-right:auto;
            height:150px;
            border-radius:20px;            
             background-color:orange  ;
            border-radius:20px ;
        }
        img {
border-radius: 20px 20px 0px 0px;
-moz-border-radius:  20px 20px 0px 0px;
-webkit-border-radius:  20px 20px 0px 0px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div id ="main">
             <div id="logotop" >               
                 <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl="~/images/Page/Logo.png" Width="100%" />
               
             </div>
         </div>
    </form>
    </body>
  
</html>
