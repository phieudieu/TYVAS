<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="tynasProject.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <base href="/"> <!-- For html5 mode -->
    <title>Nhóm Bác Ái tình Yêu Và Ánh Sáng</title>
</head>
<body>
  <link rel="import" href="template/header_import.html">
    <div class="contentview container" ng-view>
        <div class="margin-top100">
            <div class="loading-bar">
                <span></span>
                <p class="text-center">Loading ...</p>
            </div>
        </div>
    </div>
  <link rel="import" href="template/footer_import.html">

</body>
</html>
