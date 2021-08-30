using Analizador.Lexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace Analizador.Anlizadores
{
    class Sintactico
    {
        /*public static string analizar(String cadena)
        {
            Form1.Errores = "";
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;

            if (raiz == null || Form1.Errores.CompareTo("") !=0)
            {
                return Form1.Errores;
            }
            return "El analisis fue exitoso";
        }

      public  bool esValido(string codigo)
        {
            Form1.Errores = "";
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(codigo);
            ParseTreeNode raiz = arbol.Root;

            return raiz != null;
        }*/
    }
}
