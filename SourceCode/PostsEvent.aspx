<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostsEvent.aspx.cs" Inherits="PostsEvent" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <FCKeditorV2:FCKeditor ID="FCKeditor1" BasePath="~/fckeditor/" runat="server"></FCKeditorV2:FCKeditor>
    </div>
    </form>
</body>
</html>

