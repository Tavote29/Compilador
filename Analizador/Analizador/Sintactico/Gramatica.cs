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
        public static class NoTerminales
        {
            public const string Raiz = "<raiz>";
            public const string ImportacionLibrerias = "<importacion-Librerias>";
            public const string DeclaracionClase = "<clase>";
            public const string LlamadaLibreria = "<libreria>";
            public const string TipoAcceso = "<tipo-acceso>";
            public const string MetodoMain = "<main>";
            public const string BloqueCodigo = "<bloque-codigo>";
            public const string OperacionVariable = "operacion-variable";
            public const string DeclaracionVariable = "<declaracion-variable>";
            public const string TipoDato = "<tipo-dato>";
            public const string Variable = "<variable>";
            public const string Valor = "<valor>";
            public const string EntradaDatos = "<entrada-datos>";
            public const string ExpresionesAritmetica = "<expresion-aritmetica>";
            public const string OperadorAritmetico = "<operador-aritmetico>";
            public const string ValorLogico = "<valor-logico>";
            public const string AsignarValor = "<asignar-valor>";
            public const string OperadorAsignacion = "<operador-asignacion>";
            public const string OperadorIncremento = "<operador-incremento>";
            public const string Scanner = "<scanner>";
            public const string Imprimir = "<imprimir>";
            public const string ControladorFlujo = "<controlador-flujo";
            public const string If = "<if>";
            public const string BloqueIf = "<bloque-if";
            public const string Condicion = "<condicion>";
            public const string OperadorRelacional = "<operador-relacional>";
            public const string OperadorLogico = "<operador-logico>";
            public const string BloqueElse = "<bloque-else>";
            public const string Switch = "<switch>";
            public const string BloqueSwitch = "<bloque-switch>";
            public const string Caso = "<caso>";
            public const string DeclaracionArreglo = "<declaracion-arreglo>";
            public const string BloqueFor = "<bloque-for>";
            public const string BloqueWhile = "<bloque-while>";
            public const string BloqueDoWhile = "<bloque-do-while>";
        }
       
        public static class Terminales
        {
            //Operadores logicos
            public const string And = "&&";
            public const string Or = "||";

            //Incremento y decremento
            public const string Incremento = "++";
            public const string Decremento = "--"; 

            //Operadores aritmeticos
            public const string Mas = "+";
            public const string Menos = "-";
            public const string Por = "*";
            public const string Entre = "/";
            public const string Modulo = "%";

            //Operadores comparativos
            public const string MayorQue = ">";
            public const string MenorQue = "<";
            public const string MayorIgual = ">=";
            public const string MenorIgual = "<=";
            public const string IgualIgual = "==";
            public const string Diferente = "!";
            public const string DiferenteDe = "!=";

            //Operadores de asignacion
            public const string igualar = "=";
            public const string sumar = "+=";
            public const string restar = "-=";
            public const string multiplicar = "*=";

            //Delimitadores
            public const string ParentesisAbrir = "(";
            public const string ParentesisCerrar = ")";
            public const string CorcheteAbrir = "[";
            public const string CorcheteCerrar = "]";
            public const string LlaveAbrir = "{";
            public const string LlaveCerrar = "}";

            //Signos de puntuacion
            public const string Coma = ",";
            public const string Punto = ".";
            public const string DosPuntos = ":";
            public const string PuntoComa = ";";

            //Palabras reservadas
            public const string Import = "import";
            public const string New = "new";
            public const string Class = "class";
            public const string Main = "main";
            public const string Static = "static";
            public const string In = "in";
            public const string Out = "out";
            public const string True = "true";
            public const string False = "false";
            public const string Return = "return";
            public const string Null = "null";
            public const string Scanner = "Scanner";
            public const string System = "System";
            public const string Print = "print";
            public const string Println = "println";

            //Tipo de acceso
            public const string Public = "public";
            public const string Private = "private";
            public const string Protected = "protected";
            
            //Tipo de dato
            public const string Void = "void";
            public const string String = "String";
            public const string Int = "int";
            public const string Double = "double";
            public const string Float = "float";
            public const string Boolean = "boolean";
            public const string Long = "long";
            public const string Short = "short";
            public const string Byte = "byte";
            public const string Char = "char";

            //Bloques
            public const string If = "if";
            public const string Else = "else";
            public const string For = "for";
            public const string While = "while";
            public const string Do = "do";
            public const string Switch = "switch";
            public const string Case = "case";
            public const string Break = "break";
            public const string Default = "default";
            public const string Try = "try";
            public const string Catch = "catch";

            //Declaraciones
            /*public const string Next = "next";
            public const string NextInt = "nextInt";
            public const string NextDouble = "nextDouble";
            public const string NextBoolean = "nextBoolean";
            public const string NexFloat = "nextFloat";
            public const string NexLong = "nextLong";
            public const string NexShort = "nextShort";
            public const string NexByte = "nextByte";
            public const string NexChar = "nextChar";*/
        }

        public static class ExpresionesRegulares
        {
            public const string Comentario = "comentario";
            public const string ComentarioRegex = "(\\/\\*(\\s*|.*?)*\\*\\/)|(\\/\\/.*)";
            public const string Nombre = "id";
            public const string NombreRegex = "([a-zA-Z]|_*[a-zA-Z]){1}[a-zA-Z0-9_]*"; 
            public const string Numero = "numero";
            public const string NumeroRegex = "\\d+[f|d]?(\\.\\d+[f|d]?)?";
            public const string String = "string";
            public const string StringRegex = "\"[^\"]*\"";
            public const string Character = "character";
            public const string CharRegex = "\'[^\']*\'";    
        }

        public Gramatica(): base()
        {
            #region No Terminales
            var raiz = new NonTerminal(NoTerminales.Raiz);
            var importacionLibrerias = new NonTerminal(NoTerminales.ImportacionLibrerias);
            var declaracionClase = new NonTerminal(NoTerminales.DeclaracionClase);
            var llamadaLibreria = new NonTerminal(NoTerminales.LlamadaLibreria);
            var tipoAcceso = new NonTerminal(NoTerminales.TipoAcceso);
            var metodoMain = new NonTerminal(NoTerminales.MetodoMain);
            var bloqueCodigo = new NonTerminal(NoTerminales.BloqueCodigo);
            var operacionVariable = new NonTerminal(NoTerminales.OperacionVariable);
            var declaracionVariable = new NonTerminal(NoTerminales.DeclaracionVariable);
            var tipoDato = new NonTerminal(NoTerminales.TipoDato);
            var variable = new NonTerminal(NoTerminales.Variable);
            var valor = new NonTerminal(NoTerminales.Valor);
            var entradaDatos = new NonTerminal(NoTerminales.EntradaDatos);
            var expresionesAritmeticas = new NonTerminal(NoTerminales.ExpresionesAritmetica);
            var operadorAritmetico = new NonTerminal(NoTerminales.OperadorAritmetico);
            var valorLogico = new NonTerminal(NoTerminales.ValorLogico);
            var asignarValor = new NonTerminal(NoTerminales.AsignarValor);
            var operadorAsignacion = new NonTerminal(NoTerminales.OperadorAsignacion);
            var operadorIncremento = new NonTerminal(NoTerminales.OperadorIncremento);
            var scanner = new NonTerminal(NoTerminales.Scanner);
            var imprimir = new NonTerminal(NoTerminales.Imprimir);
            var controladorFlujo = new NonTerminal(NoTerminales.ControladorFlujo);
            var if_ = new NonTerminal(NoTerminales.If);
            var bloqueif = new NonTerminal(NoTerminales.BloqueIf);
            var condicion = new NonTerminal(NoTerminales.Condicion);
            var operadorRelacional = new NonTerminal(NoTerminales.OperadorRelacional);
            var operadorLogico = new NonTerminal(NoTerminales.OperadorLogico);
            var bloqueElse = new NonTerminal(NoTerminales.BloqueElse);
            var switch_ = new NonTerminal(NoTerminales.Switch);
            var bloqueSwitch = new NonTerminal(NoTerminales.BloqueSwitch);
            var caso = new NonTerminal(NoTerminales.Caso);
            var declaracionArreglo = new NonTerminal(NoTerminales.DeclaracionArreglo);
            var bloqueFor = new NonTerminal(NoTerminales.BloqueFor);
            var bloqueWhile = new NonTerminal(NoTerminales.BloqueWhile);
            var bloqueDoWhile = new NonTerminal(NoTerminales.BloqueDoWhile);
            #endregion

            #region Terminales

            #region Operadores logicos
            var and = ToTerm(Terminales.And);
            var or = ToTerm(Terminales.Or);
            #endregion

            #region Incremento y decremento
            var incremento = ToTerm(Terminales.Incremento);
            var decremento = ToTerm(Terminales.Decremento);
            #endregion

            #region Operadores Aritmeticos
            var mas = ToTerm(Terminales.Mas);
            var menos = ToTerm(Terminales.Menos);
            var por = ToTerm(Terminales.Por);
            var entre = ToTerm(Terminales.Entre);
            var modulo = ToTerm(Terminales.Modulo);
            #endregion

            #region Operadores Comparativos
            var mayorque = ToTerm(Terminales.MayorQue);
            var menorque = ToTerm(Terminales.MenorQue);
            var mayorigual = ToTerm(Terminales.MayorIgual);
            var menorigual = ToTerm(Terminales.MenorIgual);
            var igualigual = ToTerm(Terminales.IgualIgual);
            var diferente = ToTerm(Terminales.Diferente);
            var diferenteDe = ToTerm(Terminales.DiferenteDe);
            #endregion

            #region Operadores de asignacion
            var igualar = ToTerm(Terminales.igualar);
            var sumar = ToTerm(Terminales.sumar);
            var restar = ToTerm(Terminales.restar);
            var multiplicar = ToTerm(Terminales.multiplicar);
            #endregion

            #region Delimitadores
            var parentesisAbrir = ToTerm(Terminales.ParentesisAbrir);
            var parentesisCerrar = ToTerm(Terminales.ParentesisCerrar);
            var corchetesAbrir = ToTerm(Terminales.CorcheteAbrir);
            var corchetesCerrar = ToTerm(Terminales.CorcheteCerrar);
            var llaveAbrir = ToTerm(Terminales.LlaveAbrir);
            var llaveCerrar = ToTerm(Terminales.LlaveCerrar);
            #endregion

            #region Signos de Puntuacion
            var coma = ToTerm(Terminales.Coma);
            var punto = ToTerm(Terminales.Punto);
            var dospuntos = ToTerm(Terminales.DosPuntos);
            var puntocoma = ToTerm(Terminales.PuntoComa);
            #endregion

            #region Palabras reservadas
            var import = ToTerm(Terminales.Import);
            var new_ = ToTerm(Terminales.New);
            var class_ = ToTerm(Terminales.Class);
            var main = ToTerm(Terminales.Main);
            var static_ = ToTerm(Terminales.Static);
            var in_ = ToTerm(Terminales.In);
            var out_ = ToTerm(Terminales.Out);
            var true_ = ToTerm(Terminales.True);
            var false_ = ToTerm(Terminales.False);
            var return_ = ToTerm(Terminales.Return);
            var null_ = ToTerm(Terminales.Null);
            var scanner_ = ToTerm(Terminales.Scanner);
            var system_ = ToTerm(Terminales.System);
            var print = ToTerm(Terminales.Print);
            var println = ToTerm(Terminales.Println);
            #endregion

            #region Tipo de acceso
            var public_ = ToTerm(Terminales.Public);
            var private_ = ToTerm(Terminales.Private);
            var protected_ = ToTerm(Terminales.Protected);
            #endregion

            #region Tipo de dato
            var void_ = ToTerm(Terminales.Void);
            var String_ = ToTerm(Terminales.String);
            var int_ = ToTerm(Terminales.Int);
            var double_ = ToTerm(Terminales.Double);
            var float_ = ToTerm(Terminales.Float);
            var boolean_ = ToTerm(Terminales.Boolean);
            var long_ = ToTerm(Terminales.Long);
            var short_ = ToTerm(Terminales.Short);
            var byte_ = ToTerm(Terminales.Byte);
            var char_ = ToTerm(Terminales.Char);
            #endregion

            #region Bloques
            var If_ = ToTerm(Terminales.If);
            var else_ = ToTerm(Terminales.Else);
            var for_ = ToTerm(Terminales.For);
            var while_ = ToTerm(Terminales.While);
            var do_ = ToTerm(Terminales.Do);
            var Switch_ = ToTerm(Terminales.Switch);
            var case_ = ToTerm(Terminales.Case);
            var break_ = ToTerm(Terminales.Break);
            var default_ = ToTerm(Terminales.Default);
            var try_ = ToTerm(Terminales.Try);
            var catch_ = ToTerm(Terminales.Catch);

            #endregion

            #endregion

            #region Expresiones Regulares
            var comentario = new RegexBasedTerminal(ExpresionesRegulares.Comentario, ExpresionesRegulares.ComentarioRegex);
            var nombre = new RegexBasedTerminal(ExpresionesRegulares.Nombre, ExpresionesRegulares.NombreRegex);
            var numero = new RegexBasedTerminal(ExpresionesRegulares.Numero, ExpresionesRegulares.NumeroRegex);
            var cadenaString = new RegexBasedTerminal(ExpresionesRegulares.String, ExpresionesRegulares.StringRegex);
            var caracter = new RegexBasedTerminal(ExpresionesRegulares.Character, ExpresionesRegulares.CharRegex);
            #endregion

            #region Reglas de Produccion

            raiz.Rule = importacionLibrerias + declaracionClase | declaracionClase;

            importacionLibrerias.Rule = import + llamadaLibreria;

            llamadaLibreria.Rule = nombre + puntocoma | nombre + punto + llamadaLibreria;

            declaracionClase.Rule = tipoAcceso + class_ + nombre + llaveAbrir + llaveCerrar |
                tipoAcceso + class_ + nombre + llaveAbrir + metodoMain + llaveCerrar;

            tipoAcceso.Rule = public_ | private_ | protected_;

            metodoMain.Rule = tipoAcceso + static_ + void_ + main + parentesisAbrir + String_ + corchetesAbrir + corchetesCerrar + nombre + parentesisCerrar + llaveAbrir + llaveCerrar |
                tipoAcceso + static_ + void_ + main + parentesisAbrir + String_ + corchetesAbrir + corchetesCerrar + nombre + parentesisCerrar + llaveAbrir + bloqueCodigo + llaveCerrar;

            bloqueCodigo.Rule = scanner | scanner + bloqueCodigo |
                imprimir | imprimir + bloqueCodigo |
                operacionVariable | operacionVariable + bloqueCodigo |
                controladorFlujo | controladorFlujo + bloqueCodigo |
                declaracionArreglo | declaracionArreglo + bloqueCodigo |
                bloqueFor | bloqueFor + bloqueCodigo |
                bloqueWhile | bloqueWhile + bloqueCodigo |
                bloqueDoWhile | bloqueDoWhile + bloqueCodigo |
                comentario | comentario + bloqueCodigo;

            operacionVariable.Rule = declaracionVariable + puntocoma;

            declaracionVariable.Rule = tipoDato + variable;

            tipoDato.Rule = int_ | double_ | boolean_ | char_ | float_ | long_ | short_ | byte_;

            variable.Rule = nombre | nombre + coma + variable |
                asignarValor | asignarValor + coma + variable;

            valor.Rule = expresionesAritmeticas | valorLogico | entradaDatos | null_ | caracter;

            expresionesAritmeticas.Rule = numero | nombre | cadenaString |
                parentesisAbrir + expresionesAritmeticas + parentesisCerrar |
                expresionesAritmeticas + operadorAritmetico + expresionesAritmeticas;

            operadorAritmetico.Rule = mas | menos | entre | por | modulo;

            operadorIncremento.Rule = incremento | decremento;

            valorLogico.Rule = true_ | false_;

            entradaDatos.Rule = nombre + punto + nombre + parentesisAbrir + parentesisCerrar;

            asignarValor.Rule = nombre + operadorAsignacion + valor | nombre + operadorIncremento;

            operadorAsignacion.Rule = igualar | sumar | restar | multiplicar;

            declaracionArreglo.Rule = tipoDato + corchetesAbrir + corchetesCerrar + nombre + igualar + new_ + tipoDato + corchetesAbrir + expresionesAritmeticas + corchetesCerrar + puntocoma |
                tipoDato + corchetesAbrir + corchetesCerrar + nombre + puntocoma |
                tipoDato + nombre + corchetesAbrir + corchetesCerrar + igualar + new_ + tipoDato + corchetesAbrir + expresionesAritmeticas + corchetesCerrar + puntocoma |
                tipoDato + nombre + corchetesAbrir + corchetesCerrar + puntocoma |
                tipoDato + corchetesAbrir + corchetesCerrar + corchetesAbrir + corchetesCerrar + nombre + igualar + new_ + tipoDato + corchetesAbrir + expresionesAritmeticas + corchetesCerrar + corchetesAbrir + expresionesAritmeticas + corchetesCerrar + puntocoma |
                tipoDato + corchetesAbrir + corchetesCerrar + corchetesAbrir + corchetesCerrar + nombre + puntocoma |
                tipoDato + nombre + corchetesAbrir + corchetesCerrar + corchetesAbrir + corchetesCerrar + igualar + new_ + tipoDato + corchetesAbrir + expresionesAritmeticas + corchetesCerrar + corchetesAbrir + expresionesAritmeticas + corchetesCerrar + puntocoma |
                tipoDato + nombre + corchetesAbrir + corchetesCerrar + corchetesAbrir + corchetesCerrar + puntocoma;

            scanner.Rule = scanner_ + nombre + igualar + new_ + scanner_ + parentesisAbrir + system_ + punto + in_ + parentesisCerrar + puntocoma;

            imprimir.Rule = system_ + punto + out_  + punto + print + parentesisAbrir + expresionesAritmeticas + parentesisCerrar + puntocoma |
                system_ + punto + out_ + punto + println + parentesisAbrir + expresionesAritmeticas + parentesisCerrar + puntocoma;

            controladorFlujo.Rule = bloqueif | switch_;

            if_.Rule = If_ + parentesisAbrir + condicion + parentesisCerrar;

            bloqueif.Rule = if_ + llaveAbrir + llaveCerrar |
                if_ + llaveAbrir + bloqueCodigo + llaveCerrar |
                if_ + llaveAbrir + llaveCerrar + bloqueElse |
                if_ + llaveAbrir + bloqueCodigo + llaveCerrar + bloqueElse;

            condicion.Rule = expresionesAritmeticas + operadorRelacional + expresionesAritmeticas |
                condicion + operadorLogico + condicion |
                valorLogico;

            operadorRelacional.Rule = igualigual | mayorque | menorque | mayorigual | menorigual | diferente | diferenteDe;

            operadorLogico.Rule = and | or;

            bloqueElse.Rule = else_ + llaveAbrir + llaveCerrar |
                else_ + llaveAbrir + bloqueCodigo + llaveCerrar |
                else_ + if_ + llaveAbrir + llaveCerrar |
                else_ + if_ + llaveAbrir + bloqueCodigo + llaveCerrar |
                else_ + if_ + llaveAbrir + llaveCerrar + bloqueElse |
                else_ + if_ + llaveAbrir + bloqueCodigo + llaveCerrar + bloqueElse;

            switch_.Rule = Switch_ + parentesisAbrir + nombre + parentesisCerrar + llaveAbrir + bloqueSwitch + llaveCerrar;

            bloqueSwitch.Rule = caso | caso + bloqueSwitch;

            caso.Rule = case_ + valor + dospuntos |
                case_ + valor + dospuntos + bloqueCodigo |
                case_ + valor + dospuntos + break_ + puntocoma |
                case_ + valor + dospuntos + bloqueCodigo + break_ + puntocoma |
                default_ + dospuntos |
                default_ + dospuntos + bloqueCodigo |
                default_ + dospuntos + break_ + puntocoma |
                default_ + dospuntos + bloqueCodigo + break_ + puntocoma;

            bloqueFor.Rule = for_ + parentesisAbrir + operacionVariable + condicion + puntocoma + asignarValor + parentesisCerrar + llaveAbrir + llaveCerrar |
                for_ + parentesisAbrir + operacionVariable + condicion + puntocoma + asignarValor + parentesisCerrar + llaveAbrir + bloqueCodigo + llaveCerrar; //checar esto

            bloqueWhile.Rule = while_ + parentesisAbrir + condicion + parentesisCerrar + llaveAbrir + llaveCerrar |
                while_ + parentesisAbrir + condicion + parentesisCerrar + llaveAbrir + bloqueCodigo + llaveCerrar;

            bloqueDoWhile.Rule = do_ + llaveAbrir + llaveCerrar + while_ + parentesisAbrir + condicion + parentesisCerrar + puntocoma |
                 do_ + llaveAbrir + bloqueCodigo + llaveCerrar + while_ + parentesisAbrir + condicion + parentesisCerrar + puntocoma;

            Root = raiz;
            #endregion
        }

        /*public override void ReportParseError(ParsingContext context)
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
        }*/
    }
}
