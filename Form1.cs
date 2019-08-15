using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Threading.Tasks;
using System.Threading;

namespace SearchApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void Label3_Click(object sender, EventArgs e)
        {

        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DirectoryTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private async void SearchButton_ClickAsync(object sender, EventArgs e)
        {
            
            try
            {
                // var rootDir = new DirectoryInfo(DirectoryTextBox.Text);
                // var fileList = Directory.GetFiles(DirectoryTextBox.Text, FileTemplateTextBox.Text, SearchOption.AllDirectories);
                await Task.Run(() => ListDirectory(ResultTreeView, DirectoryTextBox.Text, FileTemplateTextBox.Text, FileContentTextBox.Text));
            }
            catch { }
        }

        private void FileTemplateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FileContentTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DirectoryTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ResultTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void ListDirectory(TreeView treeView, string path, string pattern, string FileContent)
        {
            treeView.Nodes.Clear();

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(path);
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            var nodeDictionary = new Dictionary<string, TreeNode>
            {
                { rootDirectory.FullName, node }
            };
            stack.Push(node);
            treeView.Invoke(new Action(() => { treeView.Nodes.Add(node); }));
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var file in directoryInfo.GetFiles(pattern))
                {
                    if (CheckFile(file, FileContent))
                    {
                        treeView.Invoke(new Action(() =>
                        {
                            if (nodeDictionary.ContainsKey(file.Directory.FullName))
                                nodeDictionary[directoryInfo.FullName].Nodes.Add(new TreeNode(file.Name));
                            else
                            {
                                var branch = GetBranch(nodeDictionary, file);
                                nodeDictionary[((DirectoryInfo)branch.Tag).FullName].Nodes.Add(branch);
                            }
                            treeView.ExpandAll();
                        }));
                    }
                }
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    stack.Push(childDirectoryNode);
                }
            }
        }

        private TreeNode GetBranch(Dictionary<string, TreeNode> nodeDictrionary, FileInfo file)
        {
            var tmp = file.Directory;
            var node = new TreeNode(file.Name) { Tag = file };
            if (!nodeDictrionary.ContainsKey(tmp.FullName))
            {
                nodeDictrionary.Add(tmp.FullName, new TreeNode(tmp.Name) { Tag = tmp });
                nodeDictrionary[tmp.FullName].Nodes.Add(node);
                while (!nodeDictrionary.ContainsKey(tmp.Parent.FullName))
                {
                    nodeDictrionary.Add(tmp.Parent.FullName, new TreeNode(tmp.Parent.Name));
                    nodeDictrionary[tmp.Parent.FullName].Nodes.Add(new TreeNode(tmp.Name) { Tag = tmp });
                    tmp = tmp.Parent;
                }
                node = nodeDictrionary[tmp.FullName];
            }
            return node;
        }

        
        private static bool CheckFile(FileInfo file, string contentText)
        {
            var fileText = File.ReadAllText(file.FullName);
            if (fileText.Contains(contentText))
                return true;
            else
                return false;
        }

        //private TreeNode FindByTag(DirectoryInfo directoryInfo, TreeNode rootNode)
        //{
        //    foreach (TreeNode node in rootNode.Nodes)
        //    {
        //        if (node.Tag.Equals(directoryInfo)) return node;
        //        TreeNode next = FindByTag(directoryInfo, node);
        //        if (next != null) return next;
        //    }
        //    return null;
        //}

        private void Button1_Click(object sender, EventArgs e)
        {
            var dir = new DirectoryInfo("D:/trash");
            var file = new FileInfo("D:/trash/abab.txt");
        }
    }
}
