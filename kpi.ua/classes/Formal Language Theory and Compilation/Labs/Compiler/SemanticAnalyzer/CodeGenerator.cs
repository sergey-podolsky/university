using System.Linq;
using SyntaxAnalyzer;

namespace SemanticAnalyzer
{
    class CodeGenerator
    {
        const string label = "?LABEL";
        int labelNumber = 0;
        
        string programIdentifier;

        /// <summary>
        /// Generate ColdFire assembly from parse tree
        /// </summary>
        /// <param name="tree">Parse tree</param>
        /// <param name="misc">Misc params</param>
        /// <returns>ColdFire assembly</returns>
        public string ColdFire(Tree tree, params string[] misc)
        {       
            switch (tree.Token)
            {
                case "<unsigned-integer>":
                    uint _;
                    if (uint.TryParse(tree[0].Token, out _))
                        goto case "<identifier>";
                    throw new SemanticException("Value " + tree[0].Token + " was too large for unsigned integer");
                case "<identifier>":
                    if (tree[0].Token == programIdentifier)
                        throw new SemanticException("Identifier " + tree[0].Token + " is already used as program identifier");
                    return tree[0].Token;
            }
            var rule = tree.Aggregate(tree.Token + " →", (result, node) => result + " " + node.Token);
            switch (rule)
            {
                case "<signal-program> → <program>":
                    return ColdFire(tree[0]);
                case "<program> → PROGRAM <identifier> ; <block> .":
                    return string.Format(".global\t{0}\n{0}:\n{1}\trts\n", programIdentifier = ColdFire(tree[1]), ColdFire(tree[3]));
                case "<block> → BEGIN <statements-list> END":
                    return ColdFire(tree[1]);
                case "<block> → BEGIN END":
                    return string.Empty;
                case "<statements-list> → <statements>":
                    return ColdFire(tree[0]);
                case "<statements> → <statement>":
                    return ColdFire(tree[0]);
                case "<statements> → <statement> <statements>":
                    return ColdFire(tree[0]) + ColdFire(tree[1]);
                case "<statement> → LOOP <statements-list> ENDLOOP ;":
                    return string.Format("{0}{1}:\n{2}\tBRA\t{0}{1}\n", label, labelNumber++, ColdFire(tree[1]));
                case "<statement> → LOOP ENDLOOP ;":
                    return string.Format("{0}{1}:\n\tBRA\t{0}{1}\n", label, labelNumber++); 
                case "<statement> → FOR <identifier> := <loop-declaration> ENDFOR ;":
                    return ColdFire(tree[3], ColdFire(tree[1]));
                case "<loop-declaration> → <expression> TO <expression> DO <statements-list>":
                    return string.Format("{0}\tMOVE.L\tD0, {1}\n{2}{3}:\n{4}\tCMP.L\tD0, {1}\n\tBGT\t{2}{5}\n{6}\tADD.L\t#1, {1}\n\tBRA\t{2}{3}\n{2}{5}:\n\tNOP\n",
                        ColdFire(tree[0]), misc[0], label, labelNumber++, ColdFire(tree[2]), labelNumber++, ColdFire(tree[4]));
                case "<loop-declaration> → <expression> TO <expression> DO":
                    return string.Format("{0}\tMOVE.L\tD0, {1}\n{2}{3}:\n{4}\tCMP.L\tD0, {1}\n\tBGT\t{2}{5}\n\tADD.L\t#1, {1}\n\tBRA\t{2}{3}\n{2}{5}:\n\tNOP\n",
                        ColdFire(tree[0]), misc[0], label, labelNumber++, ColdFire(tree[2]), labelNumber++);                  
                case "<expression> → <summands-list>":
                    return string.Format("\tMOVE.L\t{0}", ColdFire(tree[0]));
                case "<expression> → - <summands-list>":
                    return string.Format("\tMOVE.L\t0, D0\n\tSUB.L\t{0}", ColdFire(tree[1]));
                case "<summands-list> → <summand>":
                    return string.Format("{0}, D0\n", ColdFire(tree[0]));
                case "<summands-list> → <summand> - <summands-list>":
                    return string.Format("{0}, D0\n\tSUB.L\t{1}", ColdFire(tree[0]), ColdFire(tree[2]));
                case "<summands-list> → <summand> + <summands-list>":
                    return string.Format("{0}, D0\n\tADD.L\t{1}", ColdFire(tree[0]), ColdFire(tree[2]));
                case "<summand> → <identifier>":
                    return ColdFire(tree[0]);
                case "<summand> → <unsigned-integer>":
                    return "#" + ColdFire(tree[0]);
            }
            throw new SemanticException("unknown rule\n" + rule);
        }
    }
}
