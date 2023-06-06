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
    public partial class LanguagesListEditForm : Form
    {
        public LanguagesListEditForm()
        {
            

            InitializeComponent();

            Size size = this.Size;
            this.Font = new Font(new FontFamily("Times New Roman"), 12, FontStyle.Bold | FontStyle.Italic);
            this.Size = size;
            Languges = new LanguagesEditListClass();
            Languges.ListChanged += Languges_ListChanged;
        }

        void Languges_ListChanged(object sender, EventArgs e)
        {
            LangugeList.SelectedIndexChanged -= LangugeList_SelectedIndexChanged;
            LangugeList.Items.Clear();
            for (int i = 0; i < Languges.Count; i++)
            {
                LangugeList.Items.Add(Languges[i].Name);
            }
            LangugeList.SelectedIndexChanged += LangugeList_SelectedIndexChanged;
        }

        LanguagesEditListClass Languges;
        

        public LanguagesListEditForm(LanguagesEditListClass languges):this()
        {
            //Languges = languges;
            Languges.AddRange(languges);
            languges.ChangeFew = Languges;
        }

        LangugeEditClass Rus, Eng, Number;

        Panel CreatePanel(LangugeEditClass languge)
        {
            PanelTagString panel = new PanelTagString()
            { Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D,
                Margin = new Padding(10),
                TagString = languge.Name
            };


            TableLayoutPanel tableLayout = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D,
                Margin = new Padding(10),
                ColumnCount = 2,
                RowCount = 1
            };

            for (int i = 0; i < tableLayout.ColumnCount; i++)
            {
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }

            for (int i = 0; i < tableLayout.RowCount; i++)
            {
                tableLayout.ColumnStyles.Add(new RowStyle(SizeType.Percent, 100));
            }
            panel.Controls.Add(tableLayout);

            Label label = new Label()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D,
                Margin = new Padding(10),
                TextAlign = ContentAlignment.MiddleRight,
                Text = languge.Name
            };

            tableLayout.Controls.Add(label, 0, 0);

            ButtonTagString button = new ButtonTagString()
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                TagString = languge.Name,
                Text = "Добавить"
            };
            button.Click += Button_Click;
            tableLayout.Controls.Add(button, 1, 0);

            return panel;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ButtonTagString button = sender as ButtonTagString;
            if (button.TagString.ToLower() == "rus")
                Languges.Add(Rus);
            if (button.TagString.ToLower() == "eng")
                Languges.Add(Eng);
            if (button.TagString.ToLower() == "number")
                Languges.Add(Number);
            if (button.TagString.ToLower() == "symwol")
                Languges.Add(Symwol);

        }

        LangugeEditClass Symwol;

        public LanguagesListEditForm(LanguagesEditListClass languages, LangugeEditClass rus, LangugeEditClass eng, LangugeEditClass number, LangugeEditClass symwol) : this(languages)
        {
            Rus = rus;
            Eng = eng;
            Number = number;
            Symwol = symwol;

            Height += 350;

            MailLayout.RowCount += 4;
            for (int i = 0; i < 4; i++) 
            {
                MailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            }

            Panel panelRus = CreatePanel(Rus);
            Panel panelEng = CreatePanel(Eng);
            Panel panelNumber = CreatePanel(number);
            Panel panelSymwol = CreatePanel(symwol);

            MailLayout.Controls.Add(panelRus, 0, 2);
            MailLayout.SetColumnSpan(panelRus, 3);
            MailLayout.Controls.Add(panelEng, 0, 3);
            MailLayout.SetColumnSpan(panelEng, 3);
            MailLayout.Controls.Add(panelNumber, 0, 4);
            MailLayout.SetColumnSpan(panelNumber, 3);
            MailLayout.Controls.Add(panelSymwol, 0, 5);
            MailLayout.SetColumnSpan(panelSymwol, 3);
        }

        private void LanguagesListForm_Load(object sender, EventArgs e)
        {
            Languges.FewRemove();
            Languges.Save = true;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            Languges.Clear();
        }

        private void LangugeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = (sender as ListView).SelectedItems[0].Index;
                LangugeEditClass languge = Languges[index];

                LanguageMenuView menu = new LanguageMenuView(index, Languges, languge, this);
                menu.ShowDialog();

                Show();
                if (languge.Save)
                {
                    Languges[index] = languge;
                }
            }
            catch
            {

            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            this.Hide();
            LangugeEditClass languge = new LangugeEditClass();

            LangugeEditForm form = new LangugeEditForm(languge);
            form.ShowDialog();

            if (languge.Save)
            {
                Languges.Add(languge);
            }

            Show();
        }
    }
}
