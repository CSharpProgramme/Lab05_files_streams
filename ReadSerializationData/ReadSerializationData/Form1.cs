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

namespace ReadSerializationData
{
    public partial class ReadSerializationForm : BankUIForm
    {
        //object for deserialization Record serializable in binary format
        private BinaryFormatter reader = new BinaryFormatter();
        private FileStream input; //stream for reading from a file

        //parameterless constructor
        public ReadSerializationForm()
        {
            InitializeComponent();
        }

        //invoke when user clicks the Open button
        private void openButton_Click(object sender, EventArgs e)
        {
            //create and show dialog box enabling user to open file
            DialogResult result;//result of OpenFileDialog
            string fileName;//name of file containing data

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; //get specified name
            }

            //ensure that user clicked "OK"
            if(result == DialogResult.OK)
            {
                ClearTextBoxes();

                //show error if user specified invalid file
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //create FileStream to obtain read access to file
                    input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                    openButton.Enabled = false; //disable Open file button
                    nextButton.Enabled = true; //enable Next Record serializable button
                }
            }
        }

        //invoked when user clicks Next button
        private void nextButton_Click(object sender, EventArgs e)
        {
            //deserialize Record serializable and store data in TextBoxes
            try
            {
                //get next Record serializable available in file
                Record record = (Record)reader.Deserialize(input);

                //store Record serializable values in temporary string array
                var values = new string[]
                {
                    record.Account.ToString(),
                    record.FirstName.ToString(),
                    record.LastName.ToString(),
                    record.Balance.ToString()
                };

                //copy string-array values to TextBox values
                SetTextBoxValues(values);
            }
            catch (SerializationException)
            {
                input?.Close(); //close Filestream
                openButton.Enabled = true; //enable Open file button
                nextButton.Enabled = false; //disable Next Record serializable button

                ClearTextBoxes();

                //notify user if no Record serializable in file
                MessageBox.Show("No more records in file", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
