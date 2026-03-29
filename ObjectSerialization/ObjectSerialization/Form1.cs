using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SequentialAccessText;

namespace ObjectSerialization
{
    public partial class ObjectSerializationForm : BankUIForm
    {
        //object for serializing RecordSerializable in binary format
        private BinaryFormatter formatter = new BinaryFormatter();
        private FileStream output; //stream for writing to a file

        //parameterless constructor
        public ObjectSerializationForm()
        {
            InitializeComponent();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            //create and show dialog box enabling user to save file
            DialogResult result;
            string fileName; //name of file to save data

            using (SaveFileDialog fileChooser = new SaveFileDialog()) 
            {
                fileChooser.CheckFileExists = false; //let user create file

                //retrieve the result of the dialog box
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; //get specified file name
            }

            if (result == DialogResult.OK)
            {
                //show error if user specified invalid file
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid file name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //save file via FileStream if user specified valid file
                    try
                    {
                        //open file with write access
                        output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

                        //disbale save button and enable enter button
                        saveButton.Enabled = false;
                        enterButton.Enabled = true;
                    }
                    catch (IOException)
                    {
                        //notify user if file could not be opened
                        MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            //store TextBox values string array
            string[] values = GetTextBoxValues();

            //determine whether TextBox acount field is empty
            if (!string.IsNullOrEmpty(values[(int)TextBoxIndices.Account]))
            {
                //store TextBox values in RecordSerializable and serialize it
                try
                {
                    //get account-number value from textBox
                    int accountNumber = int.Parse(values[(int)TextBoxIndices.Account]);

                    //determine whether accountNumber is valid
                    if (accountNumber > 0)
                    {
                        //RecordSerializable to serialize
                        var record = new Record(accountNumber, values[(int)TextBoxIndices.First],
                            values[(int)TextBoxIndices.Last], decimal.Parse(values[(int)TextBoxIndices.Balance]));

                        //write Record to FileStream(serialize object)
                        formatter.Serialize(output, record);
                    }
                    else
                    {
                        //notify user if invalid account number
                        MessageBox.Show("Invalid Account Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SerializationException)
                {
                    MessageBox.Show("Error Writing to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ClearTextBoxes();//clear TextBox values
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close file
            try
            {
                output?.Close(); //close FileStream
            }
            catch 
            {
                MessageBox.Show("Cannot close file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Exit();
        }
    }
}
