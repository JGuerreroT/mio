<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_reporte.aspx.cs" Inherits="AdministradorSeguros.Reportes.frm_reporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer Width="800" Height="600" ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
        </div>
    </form> 
</body>
</html>
