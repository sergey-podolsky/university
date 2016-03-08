using System;
using System.IO;
using System.Linq;

namespace LexicalAnalyzer
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
                        var text = streamReader.ReadToEnd();
                        var scanner = new Scanner();
                        Console.WriteLine("Program output token string:\n" + scanner.Scan(text).Aggregate("", (sum, next) => sum + next.Item1 + ' '));
                        Console.WriteLine("\nTable of identifiers:");
                        foreach (var pair in scanner.identifiers)
                            Console.WriteLine("{0}\t{1}", pair.Value, pair.Key);
                        Console.WriteLine("\nTable of numerical constants:");
                        foreach (var pair in scanner.constants)
                            Console.WriteLine("{0}\t{1}", pair.Value, pair.Key);
                        Console.WriteLine("\nTable of long delimiters:");
                        foreach (var pair in scanner.longDelimiters)
                            Console.WriteLine("{0}\t{1}", pair.Value, pair.Key);
                        Console.WriteLine();
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
        }
    }
}
