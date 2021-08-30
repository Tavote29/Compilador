using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Analizador.Anlizadores;
using Analizador.Analizador;

namespace Analizador
{
    public partial class Form1 : Form
    {

        string[] palabrasReservadas =
        {
            "public", "private", "protected",
            "int", "String", "double", "float","long", "byte","boolean", "char", "short", "void",
             "if", "else", "while", "for", "do", "switch", "break", "default", "case", "return",
             "import", "new", "static", "package", "in", "null", "true", "false"
        };

        List<Token> tokens = new List<Token>();
        List<string> token_names = new List<string>();
        Regex rex;
        StringBuilder pattern = null;
        int[] gruposNum;
        

        public Form1()
        {
            InitializeComponent();
        }

        public int getWidth()
        {
            int w = 25;
            int linea = txtEditorCodigo.Lines.Length;

            if (linea <= 99)
            {
                w = 20 + (int)txtEditorCodigo.Font.Size;

            }
            else if (linea <= 999)
            {
                w = 30 + (int)txtEditorCodigo.Font.Size;
            }
            else
            {
                w = 50 + (int)txtEditorCodigo.Font.Size;
            }
            return w;
        }


        public void EnumerarLineas()
        {
            Point p = new Point(0, 0);

            int Primerindice = txtEditorCodigo.GetCharIndexFromPosition(p);
            int Primeralinea = txtEditorCodigo.GetLineFromCharIndex(Primerindice);

            p.X = PanelCodigo.Width;
            p.Y = PanelCodigo.Height;
            int UltimoIndice = txtEditorCodigo.GetCharIndexFromPosition(p);
            int UltimaLinea = txtEditorCodigo.GetLineFromCharIndex(UltimoIndice);
            txtNumLinea.SelectionAlignment = HorizontalAlignment.Center;
            txtNumLinea.Text = "";
            txtNumLinea.Width = getWidth();

            for (int i = Primeralinea; i <= UltimaLinea + 2; i++)
            {
                txtNumLinea.Text += i + 1 + "\n";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNumLinea.Font = txtEditorCodigo.Font;
            txtEditorCodigo.Select();
            EnumerarLineas();

            //se almacenan los tokens a la lista con sus patrones
            tokens.Add(new Token(@"\s+", "ESPACIO"));
            tokens.Add(new Token(@"\b[_a-zA-Z][\w]*\b", "IDENTIFICADOR"));
            tokens.Add(new Token("\".*?\"", "CADENA"));
            tokens.Add(new Token(@"'\\.'|'[^\\]'", "CARACTER"));
            tokens.Add(new Token("//[^\r\n]*", "COMENTARIO1"));
            tokens.Add(new Token("/[*].*?[*]/", "COMENTARIO2"));
            tokens.Add(new Token(@"\d*\.?\d+", "NUMERO"));
            tokens.Add(new Token(@"[\(\)\{\}\[\];,]", "DELIMITADOR"));
            tokens.Add(new Token(@"[\+\-/*%]", "OPERADOR"));
            tokens.Add(new Token(@">|<|==|>=|<=|!", "COMPARADOR"));
            tokens.Add(new Token(@"&&|\|\|", "OPERADOR_LOGICO"));
            tokens.Add(new Token(@"\S", "OPERADOR_CONCATENACION"));
            tokens.Add(new Token(@"[-=|\+=|\*=|\/=|%=|=]", "OPERADOR_ASIGNACION"));
            tokens.Add(new Token(@"\+\+", "OPERADOR_INCREMENTO"));
            tokens.Add(new Token(@"--", "OPERADOR_DECREMENTO"));

            foreach (Token token in tokens)
            {
                if (pattern == null)
                {
                    pattern = new StringBuilder(string.Format("(?<{0}>{1})", token.getNombre(), token.getPatron()));
                }

                if (!token.getIgnore())
                {

                    pattern.Append(string.Format("|(?<{0}>{1})", token.getNombre(), token.getPatron())); //Aqui batalle por el |
                    token_names.Add(token.getNombre());
                }
            }

            rex = new Regex(pattern.ToString(), RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.ExplicitCapture | RegexOptions.Multiline);
            gruposNum = new int[token_names.Count];
            string[] gn = rex.GetGroupNames();

            for (int i=0, idx=0; i < gn.Length; i++)
            {
                if (token_names.Contains(gn[i]))
                {
                    gruposNum[idx++] = rex.GroupNumberFromName(gn[i]);
                }
            }
        }

        private int ContarLineas(string token, int index, ref int line_start)
        {
            int linea = 0;

            for (int i = 0; i < token.Length; i++)
            {
                if (token[i] == '\n')
                {
                    linea++;
                    line_start = index + i + 1;
                }
            }
            return linea;
        }

        private IEnumerable<Tokens> GetTokens(string text)
        {
            Match match = rex.Match(text);

            if (!match.Success) yield break;

            int line = 1, start = 0, index = 0;

            while (match.Success)
            {
                if (match.Index > index)
                {
                    string token = text.Substring(index, match.Index - index);
                    yield return new Tokens("ERROR", token, index, line);
                    line += ContarLineas(token, index, ref start);
                }

                for (int i = 0; i < gruposNum.Length; i++)
                {
                    if (match.Groups[gruposNum[i]].Success)
                    {
                        string name = rex.GroupNameFromNumber(gruposNum[i]);
                        yield return new Tokens(name, match.Value, match.Index, line);
                        break;
                    }
                }
                line += ContarLineas(match.Value, match.Index, ref start);
                index = match.Index + match.Length;
                match = match.NextMatch();
            }

            if (text.Length > index)
            {
                yield return new Tokens("ERROR", text.Substring(index), index, line);
            }
        }

        private void AnalizarCodigo()
        {
            tablaTokens.Rows.Clear();
            foreach (var tk in this.GetTokens(txtEditorCodigo.Text))
            {
                if (tk.Name == "ERROR")
                {
                    tablaTokens.Rows.Add(tk.Name, tk.Lexema, tk.Linea);
                   
                }
                else
                {
                    if (tk.Name == "COMENTARIO")
                    {
                        tablaTokens.Rows.Add(tk.Name, tk.Lexema, tk.Linea);
                        

                    } else
                    {
                        if(tk.Name != "ESPACIO")
                        {
                            if (tk.Name == "IDENTIFICADOR")
                                if (palabrasReservadas.Contains(tk.Lexema))
                                    tk.Name = "PALABRA RESERVADA";
                            tablaTokens.Rows.Add(tk.Name, tk.Lexema, tk.Linea);
                        }
                    }
                }
            }
           
        }

        private void TxtEditorCodigo_TextChanged(object sender, EventArgs e)
        {
            AnalizarCodigo();
            if (txtEditorCodigo.Text == "")
            {
                EnumerarLineas();
            }
        }


        private void TxtEditorCodigo_SelectionChanged(object sender, EventArgs e)
        {
            Point p = txtEditorCodigo.GetPositionFromCharIndex(txtEditorCodigo.SelectionStart);
            if (p.X == 1)
            {
                EnumerarLineas();
            }
        }


        private void TxtEditorCodigo_VScroll(object sender, EventArgs e)
        {
            txtNumLinea.Text = "";
            EnumerarLineas();
            txtNumLinea.Invalidate();
        }


        private void TxtEditorCodigo_FontChanged(object sender, EventArgs e)
        {
            txtNumLinea.Font = txtEditorCodigo.Font;
            txtEditorCodigo.Select();
            EnumerarLineas();
        }

        private void TxtNumLinea_MouseDown(object sender, MouseEventArgs e)
        {
            txtEditorCodigo.Select();
            txtNumLinea.DeselectAll();
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            EnumerarLineas();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            abrirArchivo.Title = "Abrir";
            abrirArchivo.ShowDialog();
            string nombreArchivo = abrirArchivo.FileName;

            if (File.Exists(abrirArchivo.FileName))
            {
                TextReader leer = new StreamReader(nombreArchivo);
                txtEditorCodigo.Text = leer.ReadToEnd();
                leer.Close();
            }

        }

       
    }

}