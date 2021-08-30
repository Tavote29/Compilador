using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;


namespace Analizador.Lexico
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: true)
        {
            #region ER
            RegexBasedTerminal digito = new RegexBasedTerminal("[0-9]+"); // numeros enteros
            RegexBasedTerminal decimales = new RegexBasedTerminal("[0-9]+ [.]");
            IdentifierTerminal id = new IdentifierTerminal("id");
            CommentTerminal cadena = new CommentTerminal("string", "\"", ".", "\"");
            CommentTerminal regexchar = new CommentTerminal("caracteres", "'", ".", "'");
            #endregion

            #region Terminales
            var reservedclass = "class";
            var reservedpublic = "public";
            var reservedstatic = "static";
            var reservedprivate = "private";
            var reservedprotected = "protected";
            var reservedvoid = "void";
            var reservedint = "int";
            var reservedchar = "char";
            var reserveddouble = "double";
            var reservedfloat = "float";
            var reservedlong = "long";
            var reservedbyte = "byte";
            var reservedstring = "String";
            var reservedboolean = "boolean";
            var reservedshort = "short";
            var reservedif = "if";
            var reservedelse = "else";
            var reserveddo = "do";
            var reservedwhile = "while";
            var reservedswitch = "switch";
            var reservedfor = "for";
            var reservedreturn = "return";
            var reservedllaveabrir = "{";
            var reservedllavecerrar = "}";
            var reservedcorcheteabrir = "[";
            var reservedcorchetecerrar = "]";
            var reservedpuntocoma = ";";
            #endregion

            #region Comentarios
            CommentTerminal comentariolinea = new CommentTerminal("comentariolinea", "//", "\n", "\r\n");
            CommentTerminal comentariobloque = new CommentTerminal("comentariobloque", "/*", "*/");
            base.NonGrammarTerminals.Add(comentariolinea);
            base.NonGrammarTerminals.Add(comentariobloque);
            #endregion

            #region NoTerminales
            NonTerminal INICIO = new NonTerminal("INICIO");
            NonTerminal VISIBILIDAD = new NonTerminal("VISIBILIDAD");
            NonTerminal CUERPO = new NonTerminal("CUERPO");
            NonTerminal DECLARACION = new NonTerminal("DECLARACION");
            NonTerminal TIPO = new NonTerminal("TIPO");
            #endregion

            #region Gramatica 
            INICIO.Rule = VISIBILIDAD + reservedclass + id + reservedllaveabrir + CUERPO + reservedllavecerrar;
            INICIO.ErrorRule = SyntaxError + Eof;

            VISIBILIDAD.Rule = Empty
                | reservedprivate
                | reservedprotected
                | reservedpublic;

            CUERPO.Rule = CUERPO + DECLARACION
                | DECLARACION;
            CUERPO.ErrorRule = SyntaxError + reservedpuntocoma;

            DECLARACION.Rule = VISIBILIDAD + TIPO + id + reservedpuntocoma
                | Empty;
            DECLARACION.ErrorRule = SyntaxError + reservedpuntocoma;

            TIPO.Rule = TIPO
                | reserveddouble
                | reservedboolean
                | reservedbyte
                | reservedfloat
                | reservedlong
                | reservedshort
                | reservedstring
                | reservedint
                | reservedchar;
            #endregion

            #region Operadores
            this.Root = INICIO;
            this.MarkPunctuation(reservedllaveabrir, reservedllavecerrar);
            #endregion


        }

        public override void ReportParseError(ParsingContext context)
        {
            base.ReportParseError(context);
            String error = context.CurrentToken.ValueString;
            int fila = 1;
            string descripcion = "";
            if (error.Contains("Invalid character"))
            {
                fila = context.Source.Location.Line;
                string delimStr = ":";
                char[] delim = delimStr.ToCharArray();
                string[] division = error.Split(delim, 2);
                division = division[1].Split('.');
                descripcion = "Caracter invalido" + division[0];
                //Form1.Errores += "lexico : fila" + fila + " " + division[0] + "\n";
            }
        }
    }
}
