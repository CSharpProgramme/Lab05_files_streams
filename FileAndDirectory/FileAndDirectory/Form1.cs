using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileAndDirectory
{
    //displays contents of files and directories
    public partial class FileAndDirectoryForm : Form
    {
        //parameterless constructor
        public FileAndDirectoryForm()
        {
            InitializeComponent();
        }
        
        //invoked when user presses key
        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //determine whether user pressed Enter key
            if(e.KeyCode == Keys.Enter)
            {
                //get user-specified file or directory
                string fileName = inputTextBox.Text;

                //determine whether fileName is a file
                if (File.Exists(fileName))
                {
                    //get file's creation date, modification date, etc
                    GetInformation(fileName);

                    //display file contents through StreamReader
                    try
                    {
                        //obtain reader and file contents
                        using (var stream = new StreamReader(fileName))
                        {
                            outputTextBox.AppendText(stream.ReadToEnd());
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error reading from file", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Directory.Exists(fileName))
                {
                    //get directory's creation date,
                    //modification date, etc
                    GetInformation(fileName);

                    //obtain directory lisssst of specified directory
                    string[] directoryList = Directory.GetDirectories(fileName);

                    outputTextBox.AppendText("Directory contents:\n");

                    //output directoryList contents
                    foreach (var directory in directoryList)
                    {
                        outputTextBox.AppendText($"{directory}\n");
                    }
                }
                else
                {
                    //notify user that neither file nor directory exists
                    MessageBox.Show($"{inputTextBox.Text} does not exist", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //get information on file or directory,
        //and output it to outputTextBox
        private void GetInformation(string fileName)
        {
            outputTextBox.Clear();

            //output that file or directory exists
            outputTextBox.AppendText($"{fileName} exists\n");

            //output when file or directory was created
            outputTextBox.AppendText($"Created: {File.GetCreationTime(fileName)}\n" + Environment.NewLine);

            //output when file or directory was last modified
            outputTextBox.AppendText($"Last modified: {File.GetLastWriteTime(fileName)}\n" + Environment.NewLine);

            //output when file or directory was last accessed
            outputTextBox.AppendText($"Last accessed: {File.GetLastAccessTime(fileName)}\n" + Environment.NewLine);
        }
    }
}
