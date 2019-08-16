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
        CancellationTokenSource tokenSource = new CancellationTokenSource();
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
                await Task.Run(() => ListDirectory(ResultTreeView, DirectoryTextBox.Text, FileTemplateTextBox.Text, FileContentTextBox.Text), tokenSource.Token);
            }
            catch  { }
        }
        private void CancellButton_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
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

        private void ListDirectory(TreeView treeView, string path, string pattern, string fileContent)
        {
            tokenSource = new CancellationTokenSource();
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
                    // stop point
                    try
                    {
                        tokenSource.Token.ThrowIfCancellationRequested();

                    }
                    catch (OperationCanceledException ex)
                    {
                        MessageBox.Show($"{nameof(OperationCanceledException)} thrown with message: {ex.Message}");
                    }
                    finally
                    {
                        tokenSource.Dispose();
                    }

                    if (CheckFile(file, fileContent))
                    {
                        treeView.Invoke(new Action(() =>
                        {
                            if (nodeDictionary.TryGetValue(file.Directory.FullName, out var dir))
                                dir.Nodes.Add(new TreeNode(file.Name));
                            else
                            {
                                var branch = GetBranch(nodeDictionary, file);
                                nodeDictionary[((DirectoryInfo)branch.Tag).Parent.FullName].Nodes.Add(branch);
                            }
                        }));
                        Thread.Sleep(1500);
                    }
                }
                if (currentNode.Nodes.Count > 0)
                    treeView.Invoke(new Action(() => currentNode.Expand()));
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    stack.Push(childDirectoryNode);
                }
            }
        }

        private TreeNode GetBranch(Dictionary<string, TreeNode> nodeDictrionary, FileInfo file)
        {
            var currentDirectory = file.Directory;
            var node = new TreeNode(file.Name) { Tag = file };
            while (!nodeDictrionary.ContainsKey(currentDirectory.FullName))
            {
                var tmp = node;
                node = new TreeNode(currentDirectory.Name) { Tag = currentDirectory };
                node.Nodes.Add(tmp);
                node.Expand();
                nodeDictrionary[currentDirectory.FullName] = node;
                currentDirectory = currentDirectory.Parent;
            }
            //node = nodeDictrionary[tmp.FullName];
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
            var parent = dir.Parent;
            string pp;
            try
            {
                pp = parent.Parent.FullName;
                MessageBox.Show(pp);
            }
            catch { }
            

        }

    }
}
