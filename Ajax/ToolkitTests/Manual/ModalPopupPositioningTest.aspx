<%@ Page Language="C#" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ModalPopup Positioning test</title>
    <style type="text/css" >
        .modalBackground 
        {
             	background-color:Gray;
	filter:alpha(opacity=70);
	opacity:0.7;  
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="scriptMan1"></ajaxToolkit:ToolkitScriptManager>
    <div>
        <!-- Absolutely positioned parent-->
        <asp:Panel runat="Server" ID="panel1" style="left:100px;top:200px" BackColor="Yellow" >
            <div id="absoluteDiv" style="position:absolute;left:200px;top:300px;background-color:Green">
                position:absolute;left:200px;top:300px;background-color:Green
                <asp:Panel runat="Server" ID="absolutePanel" BackColor="AliceBlue" style="display:none">
                    Absolute Hello World Center
                    Absolute Hello World 
                    Absolute Hello World 
                    Absolute Hello World 
                    Absolute Hello World
                    <asp:Button runat="Server" ID="okAbsolutePanel" Text="OK absolutePanel" />
                </asp:Panel>
                <asp:Button runat="server" ID="absolutelyCenteredButton" Text="Absolute Centered in absolute parent"/>
                <ajaxToolkit:ModalPopupExtender runat="Server" ID="absolutelyCentered"
                     TargetControlID="absolutelyCenteredButton" PopupControlID="absolutePanel"
                     BackgroundCssClass="modalBackground" OkControlID="okAbsolutePanel" />
                <asp:Panel runat="Server" ID="absolutePanelXY" BackColor="Azure" style="display:none">
                    Absolute Hello World X 50 and Y 100 set 
                    Absolute Hello World X and Y set<br />
                    Absolute Hello World X and Y set<br />
                    Absolute Hello World X and Y set
                    Absolute Hello World X and Y set
                    <asp:Button runat="Server" ID="okAbsolutePanelXY" Text="OK absolutePanel XY" />
                </asp:Panel>                     
                <asp:Button runat="server" ID="absolutelyCenteredXYButton" Text="Absolute X Y in absolute parent"/>
                <ajaxToolkit:ModalPopupExtender runat="Server" ID="absolutelyCenteredXY"
                     TargetControlID="absolutelyCenteredXYButton" PopupControlID="absolutePanelXY"
                     BackgroundCssClass="modalBackground" OkControlID="okAbsolutePanelXY" X="50" Y="100" />
                                         
                <div style="position:relative;left:450px;top:450px;background-color:Maroon;width:300px;height:300px">
                    position:relative;left:450px;top:450px;<br />background-color:Maroon;width:400px;height:300px
                    <asp:Panel runat="Server" ID="relativePanel" BackColor="AliceBlue" style="display:none;background-color:Lime" >
                    Relative Hello World Center
                    Relative Hello World 
                    Relative Hello World 
                    Relative Hello World 
                    Relative Hello World
                    <asp:Button runat="Server" ID="okRelative" Text="OK relativePanel" />
                    </asp:Panel>
                    <asp:Button runat="server" ID="relativelyCenteredButton" Text="Relative Centered in absolute parent"/>
                    <ajaxToolkit:ModalPopupExtender runat="Server" ID="ModalPopupExtender1"
                         TargetControlID="relativelyCenteredButton" PopupControlID="relativePanel"
                         BackgroundCssClass="modalBackground" OkControlID="okRelative" />
                    <asp:Panel runat="Server" ID="relativePanelXY" BackColor="Azure" style="display:none">
                        Relative Hello World X 200 and Y 200 set 
                        Relative Hello World X and Y set
                        Relative Hello World X and Y set
                        Relative Hello World X and Y set
                        Relative Hello World X and Y set
                         <asp:Button runat="Server" ID="okRelativeXY" Text="OK relativePanel XY " />
                    </asp:Panel>                     
                    <asp:Button runat="server" ID="relativelyCenteredXY" Text="Relatively XY in absolute parent"/>
                    <ajaxToolkit:ModalPopupExtender runat="Server" ID="ModalPopupExtender2"
                         TargetControlID="relativelyCenteredXY" PopupControlID="relativePanelXY"
                         BackgroundCssClass="modalBackground" OkControlID="okRelativeXY" X="200" Y="200" />
            </div>
            </div>
            
        </asp:Panel>
        <!-- Relatively positioned parent-->
        <asp:Panel runat="Server" ID="panel2" BackColor="Blue" >
            <div style="position:relative;left:400px;top:400px;background-color:Gray;width:200px;height:300px">
                    position:relative;left:400px;top:400px;background-color:Gray;width:200px;height:300px
                    <asp:Panel runat="Server" ID="relativePanel1" BackColor="BlueViolet" style="display:none;background-color:Lime" >
                    Relative Hello World Center - Not very centered in IE6
                    Relative Hello World 
                    Relative Hello World 
                    Relative Hello World 
                    Relative Hello World
                    <asp:Button runat="Server" ID="okRelative1" Text="OK relativePanel" />
                    </asp:Panel>
                    <asp:Button runat="server" ID="relativelyCenteredButton1" Text="Relative Centered in relative parent"/>
                    <ajaxToolkit:ModalPopupExtender runat="Server" ID="ModalPopupExtender5"
                         TargetControlID="relativelyCenteredButton1" PopupControlID="relativePanel1"
                         BackgroundCssClass="modalBackground" OkControlID="okRelative1" />
                    <asp:Panel runat="Server" ID="relativePanelXY1" BackColor="Azure" style="display:none">
                        Relative Hello World X 300 and Y set 300
                        Relative Hello World X and Y set
                        Relative Hello World X and Y set
                        Relative Hello World X and Y set
                        Relative Hello World X and Y set
                         <asp:Button runat="Server" ID="okRelativeXY1" Text="OK relativePanel XY" />
                    </asp:Panel>                     
                    <asp:Button runat="server" ID="relativelyCenteredXY1" Text="Relative XY in relative parent"/>
                    <ajaxToolkit:ModalPopupExtender runat="Server" ID="ModalPopupExtender6"
                         TargetControlID="relativelyCenteredXY1" PopupControlID="relativePanelXY1"
                         BackgroundCssClass="modalBackground" OkControlID="okRelativeXY1" X="300" Y="300" />
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
