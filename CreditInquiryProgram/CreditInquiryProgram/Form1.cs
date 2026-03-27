using System;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using SequentialAccessText;


namespace CreditInquiryProgram
{
    public partial class CreditInquiryProgram : Form
    {
        private FileStream input; //maintains the connection to the file
        private StreamReader fileReader; //reads data from text file

        //parameterless constructor
        public CreditInquiryProgram()
        {
            InitializeComponent();
        }

        //invoked when user clicks Open File Button
        private void openButton_Click(object sender, EventArgs e)
        {
            //create a dialog box enabling user to open file
            DialogResult result;
            string fileName;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            //exit event handler if user clicked cancel
            if(result == DialogResult.OK)
            {
                //show error if user specified invalid file
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //create FileStream to obtain read access to file
                    input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                    //set file from where data is read
                    fileReader = new StreamReader(input);

                    //enable all GUI buttons, except for Open File button
                    openButton.Enabled = false;
                    creditButton.Enabled = true;
                    debitButton.Enabled = true;
                    zeroButton.Enabled = true;
                }
            }   
        }

        //invoked when user clicks credit balances, debit balances or zero balances button
        private void getBalances_Click(object sender, EventArgs e)
        {
            //convert sender explicitly to object of type button
            Button senderButton = (Button)sender;

            //get text from clicked button, which stores account type
            string accountType = senderButton.Text;

            //read and display file information
            try
            {
                //go back to the beginning of the file
                input.Seek(0, SeekOrigin.Begin);

                displayTextBox.Text = $"Accounts with {accountType}{Environment.NewLine}";

                //traverse file until end of file
                while (true)
                {
                    //get next record available in file
                    string inputRecord = fileReader.ReadLine();

                    //when at the end of file, exit method
                    if (inputRecord == null)
                    {
                        return;
                    }

                    //parse input
                    string[] inputFields = inputRecord.Split(',');

                    //create record from input
                    var record = new Record(int.Parse(inputFields[0]), inputFields[1], inputFields[2], decimal.Parse(inputFields[3]));

                    //determine whether to display balance
                    if (ShouldDisplay(record.Balance, accountType))
                    {
                        //display record
                        displayTextBox.AppendText($"{record.Account}\t" + $"{record.FirstName}\t{record.LastName}\t"
                            + $"{record.Balance:C}{Environment.NewLine}");
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot read file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //determine whether to display given record
        private bool ShouldDisplay(decimal balance, string accountType)
        {
            if(balance > 0M && accountType == "Credit Balances")
            {
                return true; //should display credit balances
            }
            else if (balance < 0M && accountType == "Debit Balances")
            {
                return true; //should display debit balances
            }
            else if (balance == 0M && accountType == "Zero Balances")
            {
                return true; //should display zero balances
            }

            return false;
        }

        //invoked when user clicks Done button
        private void doneButton_Click(object sender, EventArgs e)
        {
            //close file and StreamReader
            try
            {
                fileReader?.Close(); //close StreamReader and underlying file
            }
            catch (IOException)
            {
                //notify user of eror closing file
                MessageBox.Show("Cannot close file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Exit();
        }
    }
}
