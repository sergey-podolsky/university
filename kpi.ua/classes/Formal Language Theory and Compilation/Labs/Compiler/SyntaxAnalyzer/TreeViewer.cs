using System.Windows.Forms;

namespace SyntaxAnalyzer
{
    public partial class TreeViewer : Form
    {
        public TreeViewer(Tree tree)
        {
            InitializeComponent();
            
            /* Visualize tree */            
            BuildTree(treeView.Nodes, tree);
        }

        static void BuildTree(TreeNodeCollection nodes, Tree tree)
        {
            var node = new TreeNode { Text = tree.Token };
            nodes.Add(node);
            foreach (var subTree in tree)
                BuildTree(node.Nodes, subTree);
        }
    }
}
