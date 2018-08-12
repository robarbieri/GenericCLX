	function createTD(p_strTD, p_strAlign, p_intID){
		var objTD = document.createElement("TD");
		if(p_strAlign != null)objTD.align = p_strAlign;
		objTD.innerText = (p_strTD.trim() != "") ? p_strTD : " ";
		if(p_intID != null)objTD.id = "td" + p_intID;
		return objTD;
	}

	function createTDActionUpdate(p_nameFunction){
		var objTD = document.createElement("TD");
		var objImgInputOutput = document.createElement("IMG");
		objImgInputOutput.src = "/GenericCLX/img/alterar.gif";
		objTD.appendChild(objImgInputOutput);
		objTD.onclick = eval(p_nameFunction);
		objTD.className = "hand";
		objTD.align = "center";
		return objTD;
	}

	function createTDActionDelete(p_nameFunction){
		var objTD = document.createElement("TD");
		var objImgInputOutput = document.createElement("IMG");
		objImgInputOutput.src = "/GenericCLX/img/excluir.gif";
		objTD.appendChild(objImgInputOutput);
		objTD.onclick = eval(p_nameFunction);
		objTD.className = "hand";
		objTD.align = "center";
		return objTD;
	}
	
	function createTDActionView(p_nameFunction){
		var objTD = document.createElement("TD");
		var objImgInputOutput = document.createElement("IMG");
		objImgInputOutput.src = "/GenericCLX/img/visualizar.gif";
		objTD.appendChild(objImgInputOutput);
		objTD.onclick = eval(p_nameFunction);
		objTD.className = "hand";
		objTD.align = "center";
		return objTD;
	}	

