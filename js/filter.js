<!--
		function filter(p_strText){
		var arrInput = new Array(12);
		var arrOutput = new Array(12);
		
		arrInput[1] = "������";
		arrOutput[1] = "a";
		
		arrInput[2] = "������";
		arrOutput[2] = "A";
		
		arrInput[3] = "����";
		arrOutput[3] = "e";
		
		arrInput[4] = "����";
		arrOutput[4] = "E";
		
		arrInput[5] = "����";
		arrOutput[5] = "i";
		
		arrInput[6] = "����";
		arrOutput[6] = "I";
		
		arrInput[7] = "�����";
		arrOutput[7] = "o";
		
		arrInput[8] = "�����";
		arrOutput[8] = "O";
		
		arrInput[9] = "����";
		arrOutput[9] = "u";
		
		arrInput[10] = "����";
		arrOutput[10] = "U";
		
		arrInput[11] = "�";
		arrOutput[11] = "c";
		
		arrInput[12] = "�";
		arrOutput[12] = "C";
		
		for(var intCount1 = 1;intCount1 <= 12;intCount1++){
			for(var intCount2 = 0;intCount2 < arrInput[intCount1].length;intCount2++){
				p_strText = replace(p_strText,arrInput[intCount1].substring(intCount2,intCount2+1), arrOutput[intCount1]);
			}
		}
		
		return p_strText.trim();
	}

	function filterCharactersSpecial(p_strText){
		var arrInput = new Array(1);
		var arrOutput = new Array(1);
		
		arrInput[1] = "\"\'!@#$%�&*()-_+=`�~^{}[]?/:;><|\\/-.";
		arrOutput[1] = "";

		for(var intCount1 = 1;intCount1 <= 1;intCount1++){
			for(var intCount2 = 0;intCount2 < arrInput[intCount1].length;intCount2++){
				p_strText = replace(p_strText,arrInput[intCount1].substring(intCount2,intCount2+1), arrOutput[intCount1]);
			}
		}
		
		return p_strText.trim();
	}
-->
