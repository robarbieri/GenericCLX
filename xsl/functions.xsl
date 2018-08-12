<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:user="http://mycompany.com/mynamespace"
                version="1.0">
	<msxsl:script language="JScript" implements-prefix="user">
		function returnBackground(p_intNumber){
		return ((p_intNumber / 2).toString().indexOf(".") != -1);
		}

		function replace(p_strText, p_strWhat, p_strFor){
		while (p_strText.indexOf(p_strWhat) > -1)
		p_strText = p_strText.replace(p_strWhat,p_strFor);
		return (p_strText.toString().replace(p_strWhat, p_strFor));
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
	</msxsl:script>
</xsl:stylesheet>