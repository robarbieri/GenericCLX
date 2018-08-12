<!--
	function formatFloat(fltValue, intNDecimal){
		fltValue = fltValue.toString().trim();
		if(fltValue.trim()!=""){
			fltValue = replace(fltValue,".",",");
			
			if(fltValue.indexOf(",")==-1)
				fltValue += ",00";
			else if(fltValue.substring(fltValue.indexOf(","),fltValue.length)!=1 && intNDecimal != undefined)
				fltValue = fltValue.toString() + "0";

			if(intNDecimal != undefined)
				fltValue = roundOff(fltValue,intNDecimal);
			
			var intPositionPoint = 0;
			var intPositionComma = fltValue.indexOf(",");
			var intCount = 1;
			
			for(var i=intPositionComma;i>intPositionPoint;i--){
				intPositionPoint = (intPositionComma-(intCount*3));
				intCount++;
				
				if(intPositionPoint<=-1)
					break;

				fltValue = fltValue.substring(0,intPositionPoint) + '.' + fltValue.substring(intPositionPoint,fltValue.length);
				var intVerifyFirstCharacter = fltValue.substring(0,1);

				if (intVerifyFirstCharacter=="."){
					fltValue = fltValue.substring(1,fltValue.length);
				}

			}
		}else
			fltValue = "0,00"
		
		return(fltValue.toString());
	}

	function roundOff(fltValue, intNDecimal){
		var fltValueAux = fltValue.substring(fltValue.indexOf(",")+1,(fltValue.indexOf(",") + 1) + (intNDecimal + 1));
		var fltValueAuxLastNum = 0;
		var intSum = 0;
		var fltValueAuxNum = fltValueAux;
		for(i=fltValueAux.length-1;i>=intNDecimal;i--){
			fltValueAuxLastNum = fltValueAux.substring(i,i+1);
			intSum = (fltValueAuxLastNum>4?1:0);
			i--;
			fltValueAux = fltValueAux.substring(0,i+1);
			fltValueAux = (parseInt(fltValueAux) + parseInt(intSum)).toString();
			i++;
		}
		
		fltValueAux = fltValueAux.substring(0,intNDecimal);
		fltValue = fltValue.substring(0,fltValue.indexOf(","));
		
		if(fltValueAux=="10"){
			fltValueAux="00";
			fltValue = parseInt(fltValue) + 1;
		}
		
		return(fltValue + "," + fltValueAux);
	}
-->
	