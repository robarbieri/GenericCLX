<!--
function verifyCNPJCPF(number){
	var digit, cnpj, i, j, b, s, numbers, replicated, tipo;

   numbers = "0123456789";
   replicated= "";
   digit = "";
   tipo = "";

	//Tira zeros a esquerda no caso de CPF   
   if(number.substring(0, 3) == "000")
      number = number.substring(3, number.length);
   
   // Tira Pontos, Barras e Hífens do CPF/CNPJ//
   for (i = number.length-1; i >= 0; i--){
      if(numbers.indexOf(number.substr(i, 1)) < 0) 
         number = number.substr(0, i).concat(number.substr(i + 1, number.length-i));
   }
    
   // Cria número de cpf/cnpj repetido para teste de validade //
   for (i=0; i < number.length-2; i++)
      replicated = replicated.concat(number.substr(0, 1));

   // Testa se é cpf ou cnpj //
   if (number.length != 14 && number.length != 11) 
   {
      alert("Preencha corretamente os campos com o seu CPF/CNPJ");
      return false;
   }
    
   // Verifica se todos os números são iguais //
   else if (number.substr(0, number.length-2) == replicated) 
   {
      alert("CNPJinformado incorretamente");
      return false;       
   }
    
   // Calcula Dígito //
   else 
   {
      if (number.length == 14) 
         tipo = "CNPJ"; 
      else 
         tipo = "CPF";

      cnpj = number.substr(0, number.length-2);
      while (digit.length < 2) 
      {
         s = 0;
         b = 2;
         for (i=cnpj.length-1; i>=0; i--) 
         {
             s = s + b * cnpj.substr(i, 1); 
             b = b + 1;
             if (number.length == 14 && b > 9)
                b = 2;
         }
         s = 11 - (s % 11);
         if (s > 9) s = 0;
         digit = digit.concat(s);
         cnpj = cnpj.concat(s);
      }
      // Verifica retorno //
      if (digit==number.substr(number.length-2, 2))
         return(true);
      else 
      {
         alert(tipo + " inválido");
         return(false);
      }   
   }
}
-->
