using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManegerJson
{
    public partial class TextForm : Form
    {
        EditTextByFile editText = new EditTextByFile();
        SaveFileDialog SaveFile1 = new SaveFileDialog();
        OpenFileDialog OpenFile1 = new OpenFileDialog();

        string valueText = "";

        public string Value
        {
            get => EditText.Text;
            set => EditText.Text = value;
        }

        public EditTextByFile EditText { get => editText; set => editText = value; }

        List<FileDialog> fileDialogs = new List<FileDialog>();


        public TextForm()
        {
            InitializeComponent();

            VirtualKeyBord.Text = "Виртуальная клавиатура";
            this.FormClosing += TextEditorForm_FormClosing;

            fileDialogs.AddRange(new FileDialog[] { SaveFile1, OpenFile1 }) ;

            for (int i = 0; i< fileDialogs.Count; i++)
            {
                FileDialog saveFile = fileDialogs[i];
                saveFile.Filter = "TXT-Files (*.txt)|*.txt|CSV-Files (*.csv)|*.csv|STXT-Files (*.stxt)|*.stxt|All Files (*.*)|*.*";
                saveFile.FilterIndex = 0;
                saveFile.Title = saveFile is OpenFileDialog ? "Открытие файла" : "Сохранение файла";
            }
            //SaveFile.Click += SaveFile_Click;
            //OpenFile.Click += OpenFile_Click;
        }

        private void TextEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            editText.Text = TextInFile.Text;
        }

        public TextForm(EditTextByFile editText) : this()
        {
            tableLayoutPanel1.ColumnCount++;

            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, tableLayoutPanel1.ColumnStyles[0].Width));
            tableLayoutPanel1.SetColumnSpan(TextInFile, tableLayoutPanel1.ColumnCount);
            tableLayoutPanel1.SetColumnSpan(buttonSet, 2);

            Button OK = new Button() { Text = "OK", Dock = DockStyle.Fill, Margin = new Padding(10), Padding = new Padding(5) };
            tableLayoutPanel1.Controls.Add(OK, 3, 0);
            OK.Click += OK_Click; ;

            EditText = editText;
            TextInFile.EditText = EditText;
        }


        bool save = false;

        public bool Save
        {
            get => save;
            set => save = value;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            EditText.Text = TextInFile.Text;
            Save = true;
            ButtonBack_Click(sender, e);
        }

        public TextForm(string text) : this(new EditTextByFile(text))
        {

        }


        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFile = OpenFile1;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //StreamReader reader = new StreamReader(saveFile.FileName);
                    try
                    {
                        string[] lines = File.ReadAllLines(saveFile.FileName);
                        TextInFile.Lines = lines;

                        MessageBox.Show("Файл успешно открыт", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //reader.Close();
                        throw ex;
                    }
                }
                catch
                {

                    MessageBox.Show("Не удалось открыть файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {

            string[] lines = TextInFile.Lines;
            string text = "";
            for (int i = 0; i < lines.Length; i++)
            {
                text += lines[i];
                if (i < lines.Length - 1)
                {
                    text += Environment.NewLine;
                }
            }
            SaveFileDialog saveFile = SaveFile1;
            StreamWriter writer;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    writer = new StreamWriter(saveFile.FileName);
                    try
                    {

                        writer.Write("");

                        for (int i = 0; i < lines.Length; i++)
                        {
                            writer.WriteLine(lines[i]);
                        }
                        writer.Close();

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextInFile_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void VirtualKeyBord_CheckedChanged(object sender, EventArgs e)
        {
            TextInFile.VirtualKeyBord = (sender as CheckBox).Checked;
        }

        KeyBordTextView TextInFile;
        Button ButtonBack, OpenFile, SaveFile;
        CheckBox VirtualKeyBord;
        TableLayoutPanel tableLayoutPanel1;

        private void buttonSet_Click(object sender, EventArgs e)
        {
            TextFile textFile = new TextFile();
            textFile.Text = TextInFile.Text;

            bool yes = false;
            DiskForm disk = new DiskForm(textFile, ref yes, this);
            Hide();
            disk.ShowDialog();
            Show();

            try
            {
                if (disk.YesChoose)
                {

                    TextInFile.Text = textFile.Text;
                }
            }
            catch
            {

            }
            disk.Dispose();
        }

        private void buttonVieWindow_Click(object sender, EventArgs e)
        {
            TextForm form = new TextForm(TextInFile.Text);
            Hide();
            form.ShowDialog();
            Show();
            if(form.Save)
            {
                TextInFile.Text = form.Value;
            }
        }

        private void InitializeComponent()
        {
            FileManegerJson.EditTextByFile editTextByFile1 = new FileManegerJson.EditTextByFile();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonBack = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.Button();
            this.VirtualKeyBord = new System.Windows.Forms.CheckBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonVieWindow = new System.Windows.Forms.Button();
            this.TextInFile = new FileManegerJson.KeyBordTextView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.ButtonBack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OpenFile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SaveFile, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.VirtualKeyBord, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextInFile, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSet, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonVieWindow, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(873, 402);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ButtonBack
            // 
            this.ButtonBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonBack.Location = new System.Drawing.Point(9, 7);
            this.ButtonBack.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ButtonBack.Size = new System.Drawing.Size(272, 45);
            this.ButtonBack.TabIndex = 0;
            this.ButtonBack.Text = "Назад";
            this.ButtonBack.UseVisualStyleBackColor = true;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenFile.Location = new System.Drawing.Point(299, 7);
            this.OpenFile.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.OpenFile.Size = new System.Drawing.Size(273, 45);
            this.OpenFile.TabIndex = 1;
            this.OpenFile.Text = "Открыть";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveFile.Location = new System.Drawing.Point(590, 7);
            this.SaveFile.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.SaveFile.Size = new System.Drawing.Size(274, 45);
            this.SaveFile.TabIndex = 2;
            this.SaveFile.Text = "Сохранить ";
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // VirtualKeyBord
            // 
            this.VirtualKeyBord.AutoSize = true;
            this.VirtualKeyBord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VirtualKeyBord.Location = new System.Drawing.Point(9, 66);
            this.VirtualKeyBord.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.VirtualKeyBord.Name = "VirtualKeyBord";
            this.VirtualKeyBord.Size = new System.Drawing.Size(272, 32);
            this.VirtualKeyBord.TabIndex = 3;
            this.VirtualKeyBord.Text = "Виртуальная клавиатура";
            this.VirtualKeyBord.UseVisualStyleBackColor = true;
            this.VirtualKeyBord.CheckedChanged += new System.EventHandler(this.VirtualKeyBord_CheckedChanged);
            // 
            // buttonSet
            // 
            this.buttonSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSet.Location = new System.Drawing.Point(590, 66);
            this.buttonSet.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(274, 32);
            this.buttonSet.TabIndex = 5;
            this.buttonSet.Text = "Задать/Сохранить/изменить";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonVieWindow
            // 
            this.buttonVieWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonVieWindow.Location = new System.Drawing.Point(299, 66);
            this.buttonVieWindow.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.buttonVieWindow.Name = "buttonVieWindow";
            this.buttonVieWindow.Size = new System.Drawing.Size(273, 32);
            this.buttonVieWindow.TabIndex = 6;
            this.buttonVieWindow.Text = "Через отдельное окно";
            this.buttonVieWindow.UseVisualStyleBackColor = true;
            this.buttonVieWindow.Click += new System.EventHandler(this.buttonVieWindow_Click);
            // 
            // TextInFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TextInFile, 3);
            this.TextInFile.Dock = System.Windows.Forms.DockStyle.Fill;
            editTextByFile1.Lines = new string[] {
        ""};
            editTextByFile1.Text = "";
            this.TextInFile.EditText = editTextByFile1;
            this.TextInFile.HaveKeyBord = false;
            this.TextInFile.InputPole = true;
            this.TextInFile.KeyBordForm = null;
            this.TextInFile.Location = new System.Drawing.Point(18, 120);
            this.TextInFile.Margin = new System.Windows.Forms.Padding(18, 15, 18, 15);
            this.TextInFile.MarginAll = -1;
            this.TextInFile.MarginBottom = 15;
            this.TextInFile.MarginLeft = 18;
            this.TextInFile.MarginRight = 18;
            this.TextInFile.MarginTop = 15;
            this.TextInFile.Multiline = true;
            this.TextInFile.MultiLine = true;
            this.TextInFile.Multyline = true;
            this.TextInFile.MultyLine = true;
            this.TextInFile.Name = "TextInFile";
            this.TextInFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextInFile.SelectionEnd = 0;
            this.TextInFile.SelectionsStartBigEnd = false;
            this.TextInFile.Size = new System.Drawing.Size(837, 267);
            this.TextInFile.TabIndex = 4;
            this.TextInFile.TagString = "0";
            this.TextInFile.TextInPole = "";
            this.TextInFile.TextMargin = new System.Windows.Forms.Padding(18, 15, 18, 15);
            this.TextInFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.TextInFile.TextRegion = null;
            this.TextInFile.ValueInPole = "";
            this.TextInFile.ValueInputToPole = true;
            this.TextInFile.VirtualKeyBord = false;
            this.TextInFile.TextChanged += new System.EventHandler(this.TextInFile_TextChanged);
            // 
            // TextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 402);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TextForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Текстовый редактор";
            this.Load += new System.EventHandler(this.TextEditorForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void TextEditorForm_Load(object sender, EventArgs e)
        {
            TextInFile.Padding = new Padding(10);
        }
    }
}
