<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CajaCierreForm.aspx.cs" Inherits="slnPresentacion.CajaCierreForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


h1 {
  margin-bottom: 20px;
  padding-bottom: 9px;
  border-bottom: 1px solid #eee;
}

.h1,h1{font-size:2.5rem}.h1,.h2,.h3,.h4,.h5,.h6,h1,h2,h3,h4,h5,h6{margin-bottom:.5rem;font-family:inherit;font-weight:500;line-height:1.1;color:inherit}h1,h2,h3,h4,h5,h6{margin-top:0;margin-bottom:.5rem}
h1,h2,h3,h4,h5,h6{font-family:"Segoe UI",Arial,sans-serif;font-weight:400;margin:10px 0}
h1{font-size:36px}*,::after,::before{box-sizing:inherit}*,::after,::before{text-shadow:none!important;box-shadow:none!important}*,*:before,*:after{box-sizing:inherit}
table{border-collapse:collapse}
.placeholders {
  padding-bottom: 3rem;
}

.text-center{text-align:center!important}.row{display:-ms-flexbox;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;margin-right:-15px;margin-left:-15px}article,aside,dialog,figcaption,figure,footer,header,hgroup,main,nav,section{display:block}
article,aside,details,figcaption,figure,footer,header,main,menu,nav,section,summary{display:block}
.col-sm-10{-ms-flex:0 0 83.333333%;flex:0 0 83.333333%;max-width:83.333333%}.col-10{-ms-flex:0 0 83.333333%;flex:0 0 83.333333%;max-width:83.333333%}.col,.col-1,.col-10,.col-11,.col-12,.col-2,.col-3,.col-4,.col-5,.col-6,.col-7,.col-8,.col-9,.col-auto,.col-lg,.col-lg-1,.col-lg-10,.col-lg-11,.col-lg-12,.col-lg-2,.col-lg-3,.col-lg-4,.col-lg-5,.col-lg-6,.col-lg-7,.col-lg-8,.col-lg-9,.col-lg-auto,.col-md,.col-md-1,.col-md-10,.col-md-11,.col-md-12,.col-md-2,.col-md-3,.col-md-4,.col-md-5,.col-md-6,.col-md-7,.col-md-8,.col-md-9,.col-md-auto,.col-sm,.col-sm-1,.col-sm-10,.col-sm-11,.col-sm-12,.col-sm-2,.col-sm-3,.col-sm-4,.col-sm-5,.col-sm-6,.col-sm-7,.col-sm-8,.col-sm-9,.col-sm-auto,.col-xl,.col-xl-1,.col-xl-10,.col-xl-11,.col-xl-12,.col-xl-2,.col-xl-3,.col-xl-4,.col-xl-5,.col-xl-6,.col-xl-7,.col-xl-8,.col-xl-9,.col-xl-auto{position:relative;width:100%;min-height:1px;padding-right:15px;padding-left:15px;
            top: 0px;
            left: 0px;
        }label{display:inline-block;margin-bottom:.5rem}[role=button],a,area,button,input,label,select,summary,textarea{-ms-touch-action:manipulation;touch-action:manipulation}button,input{overflow:visible}button,input,optgroup,select,textarea{margin:0;font-family:inherit;font-size:inherit;line-height:inherit}
button,input{overflow:visible}
button,input,select,textarea{font:inherit;margin:0}.btn-primary{color:#fff;background-color:#007bff;border-color:#007bff}.btn{display:inline-block;font-weight:400;text-align:center;white-space:nowrap;vertical-align:middle;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;border:1px solid transparent;padding:.5rem .75rem;font-size:1rem;line-height:1.25;border-radius:.25rem;transition:all .15s ease-in-out}[type=reset],[type=submit],button,html [type=button]{-webkit-appearance:button}
button,html [type=button],[type=reset],[type=submit]{-webkit-appearance:button}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cierre de caja</h1>
    <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
        </div>
    </section>
        Total de ventas <br />
    <asp:TextBox ID="txtVentas" runat="server" Width="213px"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo de ventas obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
    <br />
        Total de monto gravado<br />
    <asp:TextBox ID="txtGravado" runat="server" Width="212px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo de monto gravado obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        Total de monto excento<br />
    <asp:TextBox ID="txtExento" runat="server" Width="213px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo de monto excento obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        Total en dolares<br />
    <asp:TextBox ID="txtDolares" runat="server" Width="209px"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo de  total  en dolares obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        Total en colones<br />
    <asp:TextBox ID="txtColones" runat="server" Width="210px"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo de total de colones obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        Total en euros<br />
    <asp:TextBox ID="txtEuros" runat="server" Width="211px"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo de  total en euros obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        Total en tarjetas<br />
        <asp:TextBox ID="txtTarjetas" runat="server" Width="206px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Campo de  total en tarjetas obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        Total de las ventas por fecha<br />
        <asp:TextBox ID="txtVentasFecha" runat="server" Width="203px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Campo de ventas por fecha obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        Total de ventas por departamento<br />
        <asp:TextBox ID="txtDepartamento" runat="server" Width="199px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Campo de ventas  por departamento obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnReporte" runat="server" Text="Reporte" />
&nbsp;<br />
        <br />
    <br />
    <br />
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
        <br />
    
    </div>
    </form>
    <p>
&nbsp;</p>
</body>
</html>
