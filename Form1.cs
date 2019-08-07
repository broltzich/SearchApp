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
            var files = new List<string>();
            try
            {
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
            stack.Push(node);
            treeView.Invoke(new Action(() =>
            {
                treeView.Nodes.Add(node);
            }));

            while(stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };

                    treeView.Invoke(new Action(() =>
                    {
                        currentNode.Nodes.Add(childDirectoryNode);
                        if (currentNode.Nodes.Count == 1)
                            currentNode.Expand();
                    }));
                    stack.Push(childDirectoryNode);
                    Thread.Sleep(500);
                }
                foreach (var file in directoryInfo.GetFiles(FileTemplateTextBox.Text))
                {
                    Thread.Sleep(500);
                    treeView.Invoke(new Action(() =>
                      {
                          currentNode.Nodes.Add(new TreeNode(file.Name));
                          if (currentNode.Nodes.Count == 1)
                              currentNode.Expand();
                      }));
                }
            }
        }

        private static bool CheckFile(string path)
        {
            return false;
        }
    }
}
