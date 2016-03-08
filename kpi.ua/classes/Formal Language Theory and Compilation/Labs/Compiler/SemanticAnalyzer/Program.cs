using System;
using System.IO;
using System.Linq;
using LexicalAnalyzer;
using RelationsComputing;
using SyntaxAnalyzer;

namespace SemanticAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("Program parameter: input file path");
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
                        var codeGenerator = new CodeGenerator();
                        var assembly = codeGenerator.ColdFire(tree);
                        Console.WriteLine(assembly);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (LexicalException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SyntaxException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SemanticException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RelationException<string, Relation> e)
                {
                    Console.WriteLine(e.Message);
                }
        }
    }
}
