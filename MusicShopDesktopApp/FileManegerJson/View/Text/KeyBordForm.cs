using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FileManegerJson
{
    /// <summary>
    /// Виртуальная клавиатура
    /// </summary>
    public partial class KeyBordEditForm : Form
    {
        Button Tab = new Button() { Text = tab, Dock = DockStyle.Fill };

        /// <summary>
        /// Виртуальная клавиатура
        /// </summary>
        public KeyBordEditForm()
        {
            InitializeComponent();

            lettersSymwols = new LangugeEditClass("`|•√π÷×¶∆€¥$¢£₹₱^°′″≠≈✓™℅‰*†‡★&¡!¿‽?/№#@,.~♪♥♦♠♣§[]{}()^…↑↓←→≤≥¦¬⟨⟩⁂%‰ ¶", "Symwols", 4).Letters;

            Button Languge = new Button() { Text = "+", Dock = DockStyle.Fill };
            Languge.Click += Languge_Click;

            this.Width += 120;

            MainLetter.Controls.Remove(LanguegeList);
            TableLayoutPanel LanguagePanel = new TableLayoutPanel() { Dock = DockStyle.Fill };
            LanguagePanel.RowCount = 1;
            LanguagePanel.ColumnCount = 3;
            LanguagePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            LanguagePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            LanguagePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            LanguagePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));


            LanguagePanel.Controls.Add(LanguegeList, 0, 0);
            LanguagePanel.Controls.Add(Languge, 2, 0);

            Button LanguageButton = new Button() { Text = "Языки", Dock = DockStyle.Fill };
            LanguageButton.Click += LanguageButton_Click;
            LanguagePanel.Controls.Add(LanguageButton, 1, 0);
            MainLetter.Controls.Add(LanguagePanel, 1, 2);

            int column = MainLetter.GetColumn(BackSpace);
            int row = MainLetter.GetRow(BackSpace);
            MainLetter.Controls.Remove(BackSpace);

            TableLayoutPanel table = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            for (int i = 0; i < table.ColumnCount; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }
            for (int i = 0; i < table.RowCount; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            }
            MainLetter.Controls.Add(table, column, row);
            table.Controls.Add(BackSpace, 0, 0);
            Button Enter = new Button()
            {
                Dock = DockStyle.Fill,
                Text = "⮠",
                Font = BackSpace.Font
            };
            Enter.Click += Enter_Click;
            table.Controls.Add(Enter, 1, 0);


            TableLayoutPanel layoutPanel = new TableLayoutPanel() { ColumnCount = 2, RowCount = 1, Dock = DockStyle.Fill };
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));



            //PermamentClass.ChangeControl(MainLetter, LanguegeList, layoutPanel);
            //layoutPanel.Controls.Add(LanguegeList, 0, 0);



            TableLayoutPanel main = MainLetter;

            main.ColumnCount++;
            main.ColumnStyles.Insert(0, new ColumnStyle(SizeType.Absolute, 50));
            main.Controls.Add(Tab, 0, 0);
            Panel panel = new Panel() { Dock = DockStyle.Fill };
            main.Controls.Add(panel, 0, 1);
            main.SetRowSpan(panel, 2);
            Tab.Click += Tab_Click;

            buttonShift.Text = shift1;
            RightErrow = RightArrow.Text;
            LeftErrow = LeftArrow.Text;
            string left = Convert.ToString(Errows[0]);
            string right = Convert.ToString(Errows[1]);

            RightArrow.Text = right;
            LeftArrow.Text = left;
            Padding margin = CapsLock.Margin;
            margin.Right += 20;
            CapsLock.Margin = margin;

            LanguegeList.WheelChangeIndexRound = true;
        }

        string RightErrow = "", LeftErrow = "";
        const string Errows = "⇽⇾";

        private void Tab_Click(object sender, EventArgs e)
        {
            if (IsIKeyBoedControl)
            {
                KeyBordControl.KeyRun("\t");
            }
        }

        private void LanguageButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LanguagesEditListClass languges = new LanguagesEditListClass(langugesList);
            LanguagesListEditForm form = new LanguagesListEditForm(languges, new LangugeEditClass(lettersRus, "Rus"), new LangugeEditClass(lettersEng, "Eng"), new LangugeEditClass(lettersNumber, "Number"), new LangugeEditClass(lettersSymwols, "Symwol"));
            form.ShowDialog();
            langugesList = languges;

            LanguegeList.Items.Clear();
            LanguegeList.Items.AddRange(new object[] { "Rus", "Eng", "Numbers", "Symwols" });
            LanguegeList.SelectedIndex = 0;
            for (int i = 0; i < langugesList.Count; i++)
            {
                LanguegeList.Items.Add(langugesList[i]);
            }

            this.Show();
        }

        private void Languge_Click(object sender, EventArgs e)
        {
            this.Hide();
            LangugeEditClass languge = new LangugeEditClass();

            LangugeEditForm form = new LangugeEditForm(languge);
            form.ShowDialog();

            if(languge.Save)
            {
                langugesList.Add(languge);
                LanguegeList.Items.Clear();
                LanguegeList.Items.AddRange(new object[] { "Rus", "Eng", "Numbers" });
                LanguegeList.SelectedIndex = 0;
                for (int i = 0; i < langugesList.Count; i++)
                {
                    LanguegeList.Items.Add(langugesList[i]);
                }
            }

            this.Show();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (IsIKeyBoedControl)
            {
                KeyBordControl.KeyRun(13);
            }
            else
            {
                control1.Text = control1.Text.Substring(0, control1.Text.Length - 1);
            }
        }

        Control control1;

        public Control Control
        {
            get => control1;
            set => control1 = value;
        }

        public bool IsTextBox => control1 is TextBox;
        public TextBox TextBox => control1 as TextBox;

        public bool IsIKeyBoedControl => control1 is KeyBordControlView;

        public KeyBordControlView KeyBordControl => control1 as KeyBordControlView;

        /// <summary>
        /// Виртуальная клавиатура для компонента control
        /// </summary>
        /// <param name="control"></param>
        public KeyBordEditForm(Control control):this()
        {
            StartPosition = FormStartPosition.Manual;
            control1 = control;
            int x = Math.Max(control.Location.X - 150, 0);
            int y = control.Location.Y + control.Size.Height;
            Location = new Point(x, y);

            //KeyPressEventHandler keyPress = control1.;
            //keyPress.Invoke(control1, new KeyPressEventArgs(' '));

            //control.KeyPress += Control_KeyPress;
        }



        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        const string letter = " \t";
        const string tab = "↹";
        const string shift1 = "⇪";
        string[] numbersEng = new string[] {"`!", "~@",
            "1\"",
            "2№",
            "3#",
            "4$",
            "5;",
            "6%",
            "7^",
            "8:",
            "9?",
            "0&",
            "-*",
            "=(",
            "_)",
            "+|",
        "\\↻", "/↺", ".,", "♭ⴉ", "¿¡", letter};

        string[,] lettersRus = new string[,]
        {
            {"ёЁ","йЙ", "цЦ", "уУ", "кК", "еЕ", "нН", "гГ", "шШ", "щЩ", "зЗ", "↜↝", "⮠⮢", "⁇‼", "⇧⇦"  },
            {"хХ", "ъЪ", "фФ","ыЫ", "вВ", "аА", "пП", "рР", "оО", "лЛ", "дД", "↞↟", "⮡⮣", "⁈⁉", $"{shift1}⇮"},
            { "жЖ", "эЭ", "яЯ", "чЧ", "сС","мМ", "иИ", "тТ", "ьЬ", "бБ", "юЮ", "↠↡", "⬎⬏", "⸘¿", "⇦⇧"},
            { "⇔≡", "/?", "<>", "[{", "]}", ":;","'\"","<,",">.","|\\","«»", "↨↯", "⬐⬑", "。〜", "⇨⇩" }
        };

        string[,] lettersEng = new string[,]
        {
            {"qQ","wW", "eE", "rR", "tT", "yY", "uU", "iI", "oO", "pP", "aA", "↮↭", "⮤⮥", "؟‽", "⇫⇬"  },
            {"sS", "dD", "fF","gG", "hH", "jJ", "kK", "lL", "zZ", "←↑", "→↓", "↚↛", "⮦⮧", "⸮…", "⇭⇯"},
            { "xX", "cC", "vV", "bB", "nN","mM", "↔↕", "↖↗", "↘↙", "↢↣", "↤↥", "↦↧", "⇄⇋", "‘’", "⇶⇿"},
            { "–—", "/?", "<>", "[{", "]}", ":;","'\"","<,",">.","|\\","«»", "⟨⟩", "⭕⭐", "`~", Errows}
        };

        string[,] lettersNumber = new string[,]
        {
            {"`~","1!", "2@", "3#", "4$", "5%", "6^", "8*", "9(", "0)", "-_", "=+", "↻↺", "€$", "ς&"  },
            {"∞\"", "№;", "%:","?*", "()", "{[", "}]", "|\\", "\\/", ".,", "♭ⴉ", "¿¡", "νΝ", "®©", "Ѵѵ"},
            { "δΔ", "φΦ", "αA", "βB", "γГ","εE", "ζZ", "ηH", "θΘ", "ίI", "κK", "λΛ", "μΜ", $"{tab}⇵", "θð"},
            { "∨¬", "ξΞ", "οΟ", "πП", "ρP", "σΣ","τT","υϒ","φΦ","χХ","ψΨ", "⊕∧", "ωΩ", letter, "Ѳѳ" }
        };


        string[,] lettersSymwols;

        bool shift = false;

        void Shift(bool shift = false)
        {
            bool shift1 = this.shift;
            List<Button> Numbers = this.Numbers;
            if(shift != shift1)
            {
                for(int i = 0; i<Numbers.Count; i++)
                {
                    char left = Numbers[i].Text[0];
                    char right;
                    try
                    {
                        right = Numbers[i].Text[1];
                    }
                    catch
                    {
                        right = Numbers[i].Text[0];
                    }
                    Numbers[i].Text = right + "" + left;
                }
            }
            Numbers = LettersButtons;
            if (shift != shift1)
            {
                for (int i = 0; i < Numbers.Count; i++)
                {
                    char left = Numbers[i].Text[0];
                    char right;
                    try
                    {
                        right = Numbers[i].Text[1];
                    }
                    catch
                    {
                        right = left;
                    }
                    Numbers[i].Text = right + "" + left;
                }
            }

            this.shift = shift;
        }

        //string[] numbersRus = new string[] {"`!", "~@",
        //    "1\"",
        //    "2№",
        //    "3#",
        //    "4$",
        //    "5;",
        //    "6%",
        //    "7^",
        //    "8:",
        //    "9?",
        //    "0&",
        //    "-*",
        //    "=(",
        //    "_)",
        //    "+|" };

        List<Button> Numbers = new List<Button>();

        List<LangugeEditClass> langugesList = new List<LangugeEditClass>();

        private void KeyBordForm_Load(object sender, EventArgs e)
        {
            NumbersPanel.ColumnStyles.Clear();
            for (int i = 0; i < numbersEng.Length; i++)
            {
                Numbers.Add(new Button() { Text = numbersEng[i] });
                NumbersPanel.ColumnCount++;
                NumbersPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                NumbersPanel.Controls.Add(Numbers[i], i, 0);
                Numbers[i].Click += KeyBordForm_Click;
                Numbers[i].Dock = DockStyle.Fill;
                //Numbers[i].Margin = new Padding(7);

                Numbers[i].Paint += KeyBordForm_Paint;
                Numbers[i].Invalidate();
            }

            //PaintLetterRus();

            LanguegeList.Items.AddRange(new object[]{ "Rus", "Eng", "Numbers", "Symwols" });
            LanguegeList.SelectedIndex = 0;
        }

        private void KeyBordForm_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle rectangle = (sender as Button).ClientRectangle;
            //rectangle.Inflate(-2, -2);
            e.Graphics.DrawEllipse(new Pen((sender as Button).BackColor), rectangle);
            rectangle.Inflate(2, 2);
            buttonPath.AddEllipse(rectangle);
            (sender as Button).Region = new Region(buttonPath);
        }

        private void KeyBordForm_Click1(object sender, EventArgs e)
        {
            
        }

        List<Button> RusButtons = new List<Button>();
        List<Button> LettersButtons => RusButtons;

        void PaintLetterRus() => PaintLetter(lettersRus);

        void PaintLetterEng() => PaintLetter(lettersEng);

        void PaintLetter(string[,] lettersRus)
        {
            LetterPanel.Controls.Clear();
            LetterPanel.RowStyles.Clear();
            LetterPanel.ColumnStyles.Clear();
            LetterPanel.ColumnCount = lettersRus.GetLength(1);
            LetterPanel.RowCount = lettersRus.GetLength(0);
            RusButtons.Clear();
            for (int i = 0; i < lettersRus.GetLength(1); i++)
            {
                LetterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }
            for (int i = 0; i < lettersRus.GetLength(0); i++)
            {
                LetterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                List<Button> line = new List<Button>();
                for (int j = 0; j < lettersRus.GetLength(1); j++)
                {
                    line.Add(new Button() { Text = lettersRus[i, j], Dock = DockStyle.Fill });
                    LetterPanel.Controls.Add(line[j], j, i);
                    line[j].Click += KeyBordForm_Click;
                    line[j].Region = new Region(line[j].ClientRectangle);
                    //line[j].Paint += KeyBordForm_Paint;
                    //line[j].Invalidate();
                }
                RusButtons.AddRange(line);
            }

        }

        private void KeyBordForm_Click(object sender, EventArgs e)
        {
            if(IsIKeyBoedControl)
            {
                KeyBordControl.KeyRun((sender as Button).Text);
            }
            if (shift != CapsLock.Checked)
                Shift(CapsLock.Checked);
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BackSpace_Click(object sender, EventArgs e)
        {
            
            if(IsIKeyBoedControl)
            {
                KeyBordControl.KeyRun(8);
            }
            else
            {
                control1.Text = control1.Text.Substring(0, control1.Text.Length - 1);
            }
        }

        private void buttonShift_Click(object sender, EventArgs e)
        {
            Shift(!shift);
        }

        private void CapsLock_CheckedChanged(object sender, EventArgs e)
        {
            Shift((sender as CheckBox).Checked);
            ShiftChecked.Checked = (sender as CheckBox).Checked;
        }

        bool StartEqualEnd = false;

        private void LeftArrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsIKeyBoedControl)
                {

                    if (!CtrlChecked.Checked)
                    {
                        if (!shift)
                        {
                            KeyBordControl.SelectionsStartBigEnd = false;
                            StartEqualEnd = false;
                            KeyBordControl.SelectionLength = 0;
                            KeyBordControl.SelectionStart--;
                            KeyBordControl.SelectionsStartBigEnd = false;
                        }
                        else
                        {
                            KeyBordControl.SelectionStart = 0;
                            KeyBordControl.SelectionEnd = 0;
                        }
                    }
                    else
                    {
                        if (!shift)
                        {
                            KeyBordControl.MinesSelection();
                        }
                        else
                        {
                            KeyBordControl.ShiftMinesSelection();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void RightArrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsIKeyBoedControl)
                {
                    if (!CtrlChecked.Checked)
                    {
                        if (!shift)
                        {
                            KeyBordControl.SelectionsStartBigEnd = false;
                            StartEqualEnd = false;
                            KeyBordControl.SelectionLength = 0;
                            KeyBordControl.SelectionStart++;
                            KeyBordControl.SelectionsStartBigEnd = false;
                        }
                        else
                        {
                            KeyBordControl.SelectionStart = KeyBordControl.ValueInPoleLength;
                            KeyBordControl.SelectionEnd = KeyBordControl.ValueInPoleLength;
                        }
                    }
                    else
                    {
                        if (!shift)
                        {
                            KeyBordControl.PlusSelection();
                        }
                        else
                        {
                            KeyBordControl.ShiftPlusSelection();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void ClearTextButton_Click(object sender, EventArgs e)
        {
            if (IsIKeyBoedControl)
            {
                KeyBordControl.KeyRun(27);
            }
            else
            {
                control1.Text = "";
            }
        }

        private void CtrlChecked_CheckedChanged(object sender, EventArgs e)
        {
            if(IsIKeyBoedControl)
            {
                KeyBordControl.SelectionsStartBigEnd = false;
            }
        }

        private void ShiftChecked_CheckedChanged(object sender, EventArgs e)
        {
            CapsLock.Checked = (sender as CheckBox).Checked;
        }

        private void SpaceButton_Click(object sender, EventArgs e)
        {
            if(IsIKeyBoedControl)
            {
                KeyBordControl.KeyRun(' ');
            }
        }

        private void AltButton_Click(object sender, EventArgs e)
        {

        }

        private void CtrlButton_Click(object sender, EventArgs e)
        {

        }

        private void LanguegeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShiftChecked.Checked = false;
            int index = (sender as ComboBox).SelectedIndex;
            switch(index)
            {
                case 0: PaintLetterRus(); break;
                case 1: PaintLetterEng(); break;
                case 2: PaintLetter(lettersNumber);break;
                case 3: PaintLetter(lettersSymwols); break;
                default:
                    {
                        PaintLetter(langugesList[index - 4].Letters);
                    }
                    break;
            }
        }
    }
}
