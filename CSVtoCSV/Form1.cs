using System;
using System.Windows.Forms;
using exceltool.Contoller;


namespace exceltool
{
    public partial class FormReceiveExcel : Form
    {
        private int _wokrChoice;
        TaskController _tkCon;
        string _fullFilePath = string.Empty;
        string _readFromFileName = string.Empty;
        string _filePath = string.Empty;

        public FormReceiveExcel()
        {
            InitializeComponent();

            //Do componeants of form1 (UI) settings on start
            InitializeFormComponents();
        }

        void InitializeFormComponents()
        {
            _tkCon = new TaskController();
            fromDatePkr.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 26);
            toDatePkr.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            taskCombo.SelectedIndex = 0;
        }

        private void btn_Start_Converting_Click(object sender, EventArgs e)
        {
            string writeToFileName = _filePath + fromDatePkr.Value.ToString("yy-MM-dd") + "_" + toDatePkr.Value.ToString("yy-MM-dd") + "_" + txtDepartment.Text + "_"+ taskCombo.Text + "_로그.csv";
            string tempWriteToFileName = "tempFile.csv";

            switch (taskCombo.SelectedIndex)
            {
                case 0:
                    _tkCon.GetDownloadsInfoFile(_readFromFileName, tempWriteToFileName, _fullFilePath, writeToFileName);
                    break;
                case 1:
                    _tkCon.GetFolderInfo(_readFromFileName, writeToFileName);
                    break;
            }

           
        }
        
        private void taskCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Start_Converting.Text = taskCombo.Text;

            switch (taskCombo.SelectedIndex)
            {
                case 0:
                    _wokrChoice = 0;
                    break;
                case 1:
                    _wokrChoice = 1;
                    break;
            }
            btn_Start_Converting.Enabled = false;
            txtFilePath.Clear();
        }


        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            txtFilePath.Clear();

            openFileDialog.InitialDirectory = "c:\\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _readFromFileName = openFileDialog.FileName;
                _fullFilePath = _readFromFileName.Split('\\')[_readFromFileName.Split('\\').Length -1];
                _filePath = _readFromFileName.Replace(_fullFilePath, "");
                txtFilePath.Text = _readFromFileName;
                btn_Start_Converting.Enabled = true;
            }
        }
    }
}
