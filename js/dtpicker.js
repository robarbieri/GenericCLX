<!--
	var oCampo
	
	var oDate = new Date()
	
	var nMonth = oDate.getMonth()
	var nYear = oDate.getFullYear()

	var nMonthRef = oDate.getMonth()
	var nYearRef = oDate.getFullYear()

	var sDiv = String()

	sDiv += '<TABLE UNSELECTABLE="on" WIDTH="100%" HEIGHT="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0" BGCOLOR="#FFFFFF"><TR UNSELECTABLE="on" CLASS="texto"><TD UNSELECTABLE="on">'
	sDiv += '<TABLE UNSELECTABLE="on" WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0" BGCOLOR="#E3EEE3"><TR UNSELECTABLE="on" BGCOLOR="#E3EEE3" CLASS="texto" STYLE="font-weight:bold"><TD UNSELECTABLE="on" WIDTH="23%">' 
	sDiv += '&nbsp;&nbsp;&nbsp;<INPUT TYPE="button" NAME="previousMonth" VALUE="<" ONCLICK="previousMonth()" CLASS="texto"></TD>'
	sDiv += '<TD UNSELECTABLE="on" WIDTH="54%" HEIGHT="30" ALIGN="center" ID="tdMes"></TD>'
	sDiv += '<TD UNSELECTABLE="on" WIDTH="23%" ALIGN="right"><INPUT TYPE="button" NAME="nextMonth" VALUE=">" ONCLICK="nextMonth()" CLASS="texto">&nbsp;&nbsp;&nbsp;</TD>'
	sDiv += '</TR></TABLE></TD></TR><TR UNSELECTABLE="on"><TD UNSELECTABLE="on"><TABLE UNSELECTABLE="on" WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0" ID="tbDias">'
	sDiv += '<TR UNSELECTABLE="on" CLASS="texto" STYLE="font-weight:bold"><TD UNSELECTABLE="on">Dom</TD><TD UNSELECTABLE="on">Seg</TD><TD UNSELECTABLE="on">Ter</TD><TD UNSELECTABLE="on">Qua</TD><TD UNSELECTABLE="on">Qui</TD><TD UNSELECTABLE="on">Sex</TD><TD UNSELECTABLE="on">Sab</TD></TR><TR UNSELECTABLE="on" BGCOLOR="#000000">' 
	sDiv += '<TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD></TR><TR UNSELECTABLE="on" CLASS="texto" HEIGHT="17">' 
	sDiv += '<TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD></TR><TR UNSELECTABLE="on" CLASS="texto" HEIGHT="17">' 
	sDiv += '<TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD></TR><TR UNSELECTABLE="on" CLASS="texto" HEIGHT="17">'
	sDiv += '<TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD></TR><TR UNSELECTABLE="on" CLASS="texto" HEIGHT="17">'
	sDiv += '<TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD></TR><TR UNSELECTABLE="on" CLASS="texto" HEIGHT="17">' 
	sDiv += '<TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD></TR><TR UNSELECTABLE="on" CLASS="texto" HEIGHT="17">' 
	sDiv += '<TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on"></TD><TD UNSELECTABLE="on" COLSPAN="2" ONCLICK="javascript:dtPickerHidden()" CLASS="hand bold">Fechar(x)</TD></TR></TABLE></TD>'
	sDiv += '</TR><TR UNSELECTABLE="on"><TD UNSELECTABLE="on" ID="tdNow"></TD></TR></TABLE>'

	oDate.setFullYear(nYear, nMonth, 1)

	function getMonthName(nMonth)
		{
		switch (nMonth.toString())
			{
			case '0':
				return('Janeiro');
			case '1':
				return('Fevereiro');
			case '2':
				return('Março');
			case '3':
				return('Abril');
			case '4':
				return('Maio');
			case '5':
				return('Junho');
			case '6':
				return('Julho');
			case '7':
				return('Agosto');
			case '8':
				return('Setembro');
			case '9':
				return('Outubro');
			case '10':
				return('Novembro');
			case '11':
				return('Dezembro');
			}
		}	

	function lastDay(nMonth)
		{
		switch (nMonth.toString())
			{
			case '0':
				return(31);
			case '1':
				return(28);
			case '2':
				return(31);
			case '3':
				return(30);
			case '4':
				return(31);
			case '5':
				return(30);
			case '6':
				return(31);
			case '7':
				return(31);
			case '8':
				return(30);
			case '9':
				return(31);
			case '10':
				return(30);
			case '11':
				return(31);
			}		
		}

	function nextMonth()
		{
		nMonth++;
		if (nMonth > 11)
			{
			nMonth = 0;
			nYear++;
			}
		oDate.setFullYear(nYear, nMonth, 1);
		dtPicker(oCampo);
		}

	function previousMonth()
		{
		nMonth--;
		if (nMonth < 0)
			{
			
			nMonth = 11;
			nYear--;
			}
		oDate.setFullYear(nYear, nMonth, 1);
		dtPicker(oCampo);
		}

	function dtPicker(campo)
		{	
		
		if (oCampo != campo)
			{
			oDate.setFullYear(nYearRef, nMonthRef, 1);
			nMonth = nMonthRef;
			}
		
		oCampo = campo
		
		var	oElements = document.all.tags('SELECT')
		
		for(var i = 0; i < oElements.length; i++)
			oElements[i].style.visibility = 'hidden';

		if (typeof(dvDtPicker) == 'undefined')
			{		
			oElement = document.createElement('DIV');
			oElement.id = 'dvDtPicker';
			document.body.appendChild(oElement);
			dvDtPicker.innerHTML = sDiv;
			dvDtPicker.style.position = 'absolute';
			dvDtPicker.style.width = '200px';
			dvDtPicker.style.height = '115px';
			dvDtPicker.style.borderWidth = '1px';
			dvDtPicker.style.borderColor = '#000000';
			dvDtPicker.style.borderStyle = 'solid';
			}

		dvDtPicker.style.display = '';
		dvDtPicker.style.left = campo.getClientRects().item(0).left + 238;
		dvDtPicker.style.top = campo.getClientRects().item(0).top + campo.offsetHeight - 20;
			
		tdMes.innerText = getMonthName(nMonth) + ' ' + nYear;
		
		var	nToday = oDate.getDay();	
		var nlastDay = lastDay(nMonth);
		var j = new Number(2);
		var i = new Number(nToday);
		var nErase = new Number();
		
		for (nErase = 0; nErase <= 6; nErase++)
			{
			tbDias.childNodes(0).childNodes(2).childNodes(nErase).onclick = '';	
			tbDias.childNodes(0).childNodes(2).childNodes(nErase).innerText = '';
			tbDias.childNodes(0).childNodes(2).childNodes(nErase).style.cursor = 'default';
			}
		
		for (var nDay = 1; nDay <= nlastDay; nDay++)
			{
			tbDias.childNodes(0).childNodes(j).childNodes(i).style.cursor = 'hand';
			tbDias.childNodes(0).childNodes(j).childNodes(i).onclick = returnDate;
			tbDias.childNodes(0).childNodes(j).childNodes(i++).innerText = nDay;
			if (i > 6)
				{
				i = 0;
				j++;
				}
			}
			
		while(tbDias.childNodes(0).childNodes(j).childNodes(i).innerText != '')
			{
			tbDias.childNodes(0).childNodes(j).childNodes(i).style.cursor = 'default';
			tbDias.childNodes(0).childNodes(j).childNodes(i).onclick = '';
			tbDias.childNodes(0).childNodes(j).childNodes(i++).innerText = '';
			if (i > 6)
				{
				i = 0;
				j++;
				}			
			}
		}

	function returnDate()
		{
		
		var	oElements = document.all.tags('SELECT');
		var sDia = new String(window.event.srcElement.innerText);
		var sMes = new String(nMonth + 1);
		var sAno = new String(nYear);
		
		if (sDia.length == 1)
			{
			sDia = '0' + sDia;
			}
		 
		if (sMes.length == 1)
			{
			sMes = '0' + sMes;	
			}		
		
		oCampo.value = sDia + '/' + sMes + '/' + sAno;

		for(var i = 0; i < oElements.length; i++)
			oElements[i].style.visibility = 'visible';
		
		dvDtPicker.style.display = 'none';
		
		//AtualizaCampos();
		oCampo.focus();
		oCampo.blur();
		}

	function dtPickerHidden()
	{
		var	oElements = document.all.tags('SELECT');
	
		if (typeof(dvDtPicker) != 'undefined')
			dvDtPicker.style.display = 'none';
		
		for (var i = 0; i < oElements.length; i++)
			oElements[i].style.visibility = 'visible';
	}
-->