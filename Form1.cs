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
using System.Threading.Tasks;
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
                await Task.Run(() => ListDirectory(ResultTreeView, DirectoryTextBox.Text));
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

        private void ListDirectory(TreeView treeView, string path)
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
                foreach (var file in directoryInfo.GetFiles(FileTemplateTextBox.Text))
                {
                    // file checked
                    var newFileNode = new TreeNode(file.Name);
                    nodeDictionary.Add(file.FullName, newFileNode);
                    if (nodeDictionary.ContainsKey(directoryInfo.FullName))
                    {
                        treeView.Invoke(new Action(() =>
                        {
                            nodeDictionary[directoryInfo.FullName].Nodes.Add(newFileNode);
                            treeView.ExpandAll();
                        }));
                    }
                    else
                    {
                        nodeDictionary.Add(directoryInfo.FullName, currentNode);
                        nodeDictionary[directoryInfo.FullName].Nodes.Add(nodeDictionary[file.FullName]);
                        var tmp = (DirectoryInfo)currentNode.Tag;
                        var lastDirectoryInfo = new DirectoryInfo(tmp.FullName);
                        while (!nodeDictionary.ContainsKey(tmp.Parent.FullName))
                        {
                            nodeDictionary.Add(tmp.Parent.FullName, new TreeNode(tmp.Parent.Name));
                            nodeDictionary[tmp.Parent.FullName].Nodes.Add(nodeDictionary[tmp.FullName]);
                            lastDirectoryInfo = tmp;
                            tmp = tmp.Parent;
                        }
                        treeView.Invoke(new Action(() =>
                        {
                            nodeDictionary[tmp.FullName].Nodes.Add(nodeDictionary[lastDirectoryInfo.FullName]);
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

        
        private static bool CheckFile(string path, string contentText)
        {
            var fileText = File.ReadAllText(path);
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

        }
    }
}
