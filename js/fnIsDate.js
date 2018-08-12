<!--
/*
Verificar se é uma data válida
*/
function fnIsDate(str)
	{
	try
		{
		//Se String vier vazia retorna
		if (str=='')
			{
			return(true);
			}
		//Valida Expressão dd/mm/aaaa
		var dtRegExp = /^(\d{10}|\d{2}\/\d{2}\/\d{4})$/;
		if (dtRegExp.test(str))
			{
			var strData = new String(str);
			var arrData = strData.split('/');
			var dia = new Number(arrData[0]);
			var mes = new Number(arrData[1]);
			var ano = new Number(arrData[2]);
			//Verifica se dia e mes existe
			if (dia < 1 || dia > 31 || mes < 1 || mes > 12)
				{
				return(false);
				}
			//Verifica se dia existe no mes	
			if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && (dia == 31))
				{
				return(false);
				}
			//Se Fevereiro	
			if (mes == 2)
				{
				//Se for Ano-Bissexto
				if (ano % 4 == 0)
					{
					if (dia > 29)
						{
						return(false);
						}
					}
				//Se não for Ano-Bissexto	
				else
					{
					if (dia > 28)
						{
						return(false);
						}				
					}				
				}
			return(true);
			}
		else
			{
			return(false);
			}
		}
	catch(e)
		{
		return(false);		
		}
	}
-->