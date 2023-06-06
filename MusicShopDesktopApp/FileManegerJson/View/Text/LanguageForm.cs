using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public partial class LangugeEditForm : Form
    {
        bool openFile = false;
        public LangugeEditForm()
        {
            InitializeComponent();
            Size size = this.Size;
            this.Font = new Font(new FontFamily("Times New Roman"), 12, FontStyle.Bold|FontStyle.Italic);
            this.Size = size;
        }

        public LangugeEditForm(bool openFile) : this()
        {
            this.openFile = openFile;
        }

        LangugeEditClass languge1;

        public LangugeEditForm(LangugeEditClass languge) : this()
        {
            OK.Visible = true;
            this.languge1 = languge;

            
            LanguageName.Text = languge.Name;

            LanguageTable.RowCount = languge.Rows;
            LanguageTable.ColumnCount = languge.Columns;
            int h = LanguageTable.RowCount;
            int w = LanguageTable.ColumnCount;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    LanguageTable[j, i].Value = languge.Letters[i, j];
                }
            }
        }

        private void MinesRows_Click(object sender, EventArgs e)
        {
            try
            {
                LanguageTable.RowCount--;
            }
            catch
            {

            }
        }

        private void PlusRows_Click(object sender, EventArgs e)
        {
            try
            {
                LanguageTable.RowCount++;
            }
            catch
            {

            }
        }

        private void PlusColumn_Click(object sender, EventArgs e)
        {
            try
            {
                LanguageTable.ColumnCount++;
            }
            catch
            {

            }
        }

        private void MinesColumn_Click(object sender, EventArgs e)
        {
            try
            {
                LanguageTable.ColumnCount--;
            }
            catch
            {

            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            int h = LanguageTable.RowCount;
            int w = LanguageTable.ColumnCount;
            string[,] result = new string[h, w];
            if (w < 1 || h < 1)
                return;
            for(int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    string letter = Convert.ToString(LanguageTable[j, i].Value);
                    if (letter == "" || letter is null || letter == null)
                    {
                        MessageBox.Show("Не все ячейки заполнены");
                        return;
                    }
                    result[i, j] = letter;
                }
            }

            string name = LanguageName.Text;
            if (name == "" || name is null || name == null)
            {
                MessageBox.Show("Имя не заполнено");
                return;
            }


            LangugeEditClass languge = new LangugeEditClass(result, name);

            SaveFile.FileName = languge.Name;

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    languge.SaveJson(SaveFile.FileName);
                    MessageBox.Show("Файл успешно сохранён");
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл");
                }
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if(OpenFile.ShowDialog() == DialogResult.OK)
                {
                    LangugeEditClass languge = LangugeEditClass.Load(OpenFile.FileName);
                    LanguageName.Text = languge.Name;

                    LanguageTable.RowCount = languge.Rows;
                    LanguageTable.ColumnCount = languge.Columns;
                    int h = LanguageTable.RowCount;
                    int w = LanguageTable.ColumnCount;

                    for (int i = 0; i < h; i++)
                    {
                        for (int j = 0; j < w; j++)
                        {
                            LanguageTable[j, i].Value = languge.Letters[i, j];
                        }
                    }

                    MessageBox.Show("Файл успешно открыт");
                }
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!openFile)
                return;
            List<string> line = new List<string>(Environment.GetCommandLineArgs());
            line.RemoveAt(0);
            if (line.Count == 0)
                return;
            string fileName = String.Join(" ", line);

            try
            {

                LangugeEditClass languge = LangugeEditClass.Load(fileName);
                    LanguageName.Text = languge.Name;

                    LanguageTable.RowCount = languge.Rows;
                    LanguageTable.ColumnCount = languge.Columns;
                    int h = LanguageTable.RowCount;
                    int w = LanguageTable.ColumnCount;

                    for (int i = 0; i < h; i++)
                    {
                        for (int j = 0; j < w; j++)
                        {
                            LanguageTable[j, i].Value = languge.Letters[i, j];
                        }
                    }

                    MessageBox.Show("Файл успешно открыт");
                
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл");
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            int h = LanguageTable.RowCount;
            int w = LanguageTable.ColumnCount;
            string[,] result = new string[h, w];
            if (w < 1 || h < 1)
                return;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    string letter = Convert.ToString(LanguageTable[j, i].Value);
                    if (letter == "" || letter is null || letter == null)
                    {
                        MessageBox.Show("Не все ячейки заполнены");
                        return;
                    }
                    result[i, j] = letter;
                }
            }

            string name = LanguageName.Text;
            if (name == "" || name is null || name == null)
            {
                MessageBox.Show("Имя не заполнено");
                return;
            }

            languge1.Save = true;
            languge1.Letters = result;
            languge1.Name = name;



            this.Close();
        }
    }
}
