using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LexicalAnalyzer;
using RelationsComputing;

namespace SyntaxAnalyzer
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                MessageBox.Show("Program parameter: input file path", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                try
                {
                    using (var streamReader = File.OpenText(args[0]))
                    {
                        var scanner = new Scanner();
                        var tokenString = scanner.Scan(streamReader.ReadToEnd());
                        var identifiers = scanner.identifiers.Keys.Except(Scanner.Keywords);
                        var constants = scanner.constants.Keys;
                        var relationTable = new RelationTable(identifiers, constants);
                        var tree = new Parser(relationTable).Parse(tokenString);
                        Application.Run(new TreeViewer(tree));
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (LexicalException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (SyntaxException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (RelationException<string, Relation> e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }
    }
}
