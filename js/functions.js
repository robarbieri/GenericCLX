<!--
    var blnMenu = true;

	String.prototype.trim  = trim;	
	String.prototype.ltrim = ltrim;	
	String.prototype.rtrim = rtrim;	 

	var gIntRegisters = 0;
	var gStrFieldSortAux = "";
	
	function trim()	
	{
	var sStr = this.ltrim();
	sStr = sStr.rtrim();
	return sStr;
	}	 
	
	function ltrim()	
	{	
	var sRegExp = /^\s+/;
	var sStr = this.replace(sRegExp,'');
	return sStr;
	}	 
	
	function rtrim()
	{
	var sRegExp = /\s+$/;
	var sStr = this.replace(sRegExp,'');
	return sStr;
	}

	function replace(str,oq,por)
	{
		while (str.indexOf(oq) > -1)
			str = str.replace(oq,por);

		return(str);
	}
		
	function justNumber()
	{	
		if ( !(event.keyCode>47 && event.keyCode<58) && (event.keyCode != 13) && event.keyCode != 45)
			event.keyCode=0;
	} 	
	
	function justNumberFloat()
	{	
		if (!(event.keyCode>47 && event.keyCode<58 ) && event.keyCode!=44 && event.keyCode != 45)
			event.keyCode=0;	
	}
	
	function justDate(){
		if (!(event.keyCode>47 && event.keyCode<58) && (event.keyCode != 47) && (event.keyCode != 45) ){
			event.keyCode=0;
		}
	}
	
	function justPhone(){
		if (!(event.keyCode>47 && event.keyCode<58) && !(event.keyCode == 40 || event.keyCode == 41 || event.keyCode == 45))
			event.keyCode=0;
	}
	
	function justCEP(){
		if (!(event.keyCode>47 && event.keyCode<58) && !(event.keyCode == 45))
			event.keyCode=0;
	}

	function redirect(p_strPath){
		window.location.href = p_strPath;
	}	

	function paintLine(p_objTr, p_blnFlag){
		if(p_blnFlag){
			p_objTr.style.backgroundColor = "#C2DAC2";
			p_objTr.style.color = "#9C1D1D";
		}else{
			p_objTr.style.backgroundColor = "";
			p_objTr.style.color = "#000000";
		}
	}
	
	function paintLineForeColor(p_objTr, p_blnFlag, p_strColor){
		if(p_blnFlag){
			p_objTr.style.backgroundColor = "#C2DAC2";
			p_objTr.style.color = "#9C1D1D";
		}else{
			p_objTr.style.backgroundColor = "";
			p_objTr.style.color = p_strColor;
		}
	}

	function enterSubmit(){
		if(window.event.keyCode == 13){
			verifyForm();
		}
	}

	function maximize(){
		top.window.moveTo(0,0);

		if (document.all)
			top.window.resizeTo(screen.availWidth,screen.availHeight);
		else if (document.layers||document.getElementById){
			if (top.window.outerHeight < screen.availHeight||top.window.outerWidth < screen.availWidth){
				top.window.outerHeight = screen.availHeight;
				top.window.outerWidth = screen.availWidth;
			}
		}
	}
	
	function showWindow(p_blnShow){
		if(p_blnShow){
			window.tdWindow.style.display = "";
			window.tdMenu.style.display = "none";
		}else{
			window.tdWindow.style.display = "none";
			window.tdMenu.style.display = "";		
		}
	}	

	function selectMenu(p_objTD,p_blnLight){
		if(p_blnLight){
			p_objTD.style.color = "#9C1D1D";
		}else{
			p_objTD.style.color = "";
		}
	}

	function refreshXSL(p_strFieldSort, p_strFieldType){
	    if(window.tagXML.innerHTML.trim() != ""){
		    var objXSL = new ActiveXObject("Msxml2.DOMDocument");
		    objXSL.async = false;
		    var strXSL = tagXSL.xml;
		    var strXSLOrder = "ascending";
		    var intPositionFieldSort = strXSL.indexOf("<xsl:sort select=\"");
    		
		    var strXSLSort = strXSL.slice(intPositionFieldSort, strXSL.indexOf("/>",intPositionFieldSort) + 2);

		    if(p_strFieldSort == undefined)
			    gStrFieldSortAux = "";
		    else if(gStrFieldSortAux == p_strFieldSort){
			    strXSLOrder = (strXSLSort.indexOf('order="ascending"') != -1) ? "descending" : "ascending";
			    gStrFieldSortAux = p_strFieldSort;
		    }else
			    gStrFieldSortAux = p_strFieldSort;

		    if(p_strFieldType == undefined)
			    p_strFieldType = "text";

		    strXSL = replace(strXSL, strXSLSort, "<xsl:sort select=\"@" + p_strFieldSort + "\" data-type=\"" + p_strFieldType + "\" order=\"" + strXSLOrder + "\"/>");
		    strXSL = replace(strXSL, '<?xml version="1.0"?>', '<?xml version="1.0" encoding="ISO-8859-1"?>');
    		
		    strXSL = "<XML ID='tagXSL'>" + strXSL + "</XML>";
    		
		    window.divXSL.innerHTML = strXSL;
    		
		    objXSL.loadXML(tagXSL.xml);

		    window.tdAll.innerHTML = tagXML.transformNode(objXSL);
    		
		    gIntRegisters = tagXML.childNodes[1].childNodes.length;
		    
		    if(gIntRegisters == 0)
			    window.trAlert.style.display = "";
		}
	}

	function refreshXSLGeneric(p_strNameXml, p_objDisplay){
		var objXSL = new ActiveXObject("Msxml2.DOMDocument");
		objXSL.async = false;
		objXSL.loadXML(window["tagXSL" + p_strNameXml].xml);
		p_objDisplay.innerHTML = window["tagXML" + p_strNameXml].transformNode(objXSL);
	}	
	
	function refreshLst(p_objLst, p_strArrLst){
		var arrLst = p_strArrLst.split(",");

		for(var i = 0; i < arrLst.length; i++){
			for(var w = 0; w < p_objLst.length; w++){
				if(p_objLst[w].value == arrLst[i]){
					p_objLst[w].selected = true;
				}
			}
		}
	}
	
	function takeOffLst(p_objLst){
		for(var i = 0; i < p_objLst.length; i++){
			p_objLst[i].selected = false;
		}
	}	

	function openCloseDivPopup(p_objDIV){
		if(p_objDIV.style.display == "none"){
			p_objDIV.style.display = "";
			p_objDIV.zIndex = 0;
			p_objDIV.style.top = 300;
			p_objDIV.style.left = 500;
		}else{
			p_objDIV.style.display = "none";
			window.spnStatusRefresh.innerText = "0";
			document.forms[0].submit();
		}
	}	
	
	function convertFloat(p_strValue){
		return (p_strValue.toString().indexOf(",") != -1) ? parseFloat(replace(replace(p_strValue,".",""),",",".")) : parseFloat(p_strValue);
	}
	
	function convertFloatBrazil(p_strValue){
		return (p_strValue.toString().indexOf(".") != -1) ? replace(replace(p_strValue.toString(),",",""),".",",") : p_strValue;
	}

	function convertFloatShowInTextBox(p_strValue){
		return replace(p_strValue.toString(),".","");
	}
	
	function selectedAllChecks(p_objTbl, p_intColl, p_blnSelected){
		if(p_objTbl.tHead != null)
			p_objTbl.tHead.childNodes[1].childNodes[p_intColl].firstChild.checked = p_blnSelected;

		for(var i = 0; i < p_objTbl.tBodies[0].childNodes.length; i++){
			if(p_objTbl.tBodies[0].childNodes[i].childNodes[p_intColl] != null)
				if(p_objTbl.tBodies[0].childNodes[i].childNodes[p_intColl].firstChild.type == "checkbox")
					p_objTbl.tBodies[0].childNodes[i].childNodes[p_intColl].firstChild.checked = p_blnSelected;
		}
	}
	
	function returnSmallDate(){
		var datDate = new Date();
		
		var datDay = datDate.getDate();
		var datMonth = datDate.getMonth() + 1;
		var datYear = datDate.getFullYear();

		document.getElementById("divDate").innerHTML = "| " + datDay + "." + datMonth + "." + datYear + " | ";
	}
	
	function breakString(p_strText, p_intNumber){
	    p_strText = p_strText.toString();
        var intInitialNumber = p_intNumber;
        
		while (p_strText.toString().length > p_intNumber){
		    p_strText = p_strText.substring(0, p_intNumber) + "\n" + p_strText.substring(p_intNumber);
			p_intNumber+= (intInitialNumber + "\n".length);
		}

		return p_strText;
	}
	
	function selectDropDownList(p_objDdl, p_strValue){
		for(var i = 0; i < p_objDdl.length; i++){
			if(p_objDdl[i](p_objDdl[i].selectedIndex).text.toString().toUpperCase().trim() == p_strValue.toString().toUpperCase().trim()){
				p_objDdl[i].selected = true;
				break;
			}
		}
	}	
	
	function addOptionDropDownList(p_objDdl, p_intId, p_strValue){
		var objOption = document.createElement("OPTION");
		p_objDdl.options.add(objOption);
		objOption.value = p_intId;
		objOption.innerText = p_strValue;
	}
	
	function deleteOptionDropDownList(p_objDdl){
		if(p_objDdl.selectedIndex > 0)
			p_objDdl.remove(p_objDdl.selectedIndex);
	}
	
	function buildXmlDocument(p_objXmlNodeList){
        var objXml = new ActiveXObject("MsXml2.DomDocument");
        objXml.loadXML("<ROOT></ROOT>");
        if(p_objXmlNodeList.length > 0){
            window.tdError.innerText = "";
            for(i = 0; i < p_objXmlNodeList.length; i++) {
                if (p_objXmlNodeList[i].tagName != "ROOT"){
                    objXml.documentElement.appendChild(p_objXmlNodeList[i]);
                }
            }
        }else
            window.tdError.innerText = "Nenhum registro encontrado";
        return objXml;
    }
    
    function maxWindow()
    {
        window.moveTo(0,0);

        if (document.all)
        {
          top.window.resizeTo(screen.availWidth,screen.availHeight);
        }

        else if (document.layers||document.getElementById)
        {
          if (top.window.outerHeight<screen.availHeight||top.window.outerWidth<screen.availWidth)
          {
            top.window.outerHeight = screen.availHeight;
            top.window.outerWidth = screen.availWidth;
          }
        }
    }
    
    function popupcenter(Url,Name,PosFimX,PosFimY,ScrollBars,Resizable)
    {

      PosIniX=((screen.availWidth/2)-(PosFimX/2));

      PosIniY=((screen.availHeight/2)-(PosFimY/2));

      window.open(Url,Name,'toolbar=0,location=0,directories=0,menubar=0,scrollbars='+ScrollBars+',resizable='+Resizable+',top='+PosIniY+',left='+PosIniX+',width='+PosFimX+',height='+PosFimY+'');

    }
-->