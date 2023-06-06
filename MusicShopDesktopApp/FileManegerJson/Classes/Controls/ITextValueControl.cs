using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FileManegerJson
{
    public interface ITextValueControlView : ITagStringControlView
    {
        string Text { get; set; }

        void KeyRun(char sign);


        void KeyRun(int v);

        void KeyRun(string s);

        Point Location { get; set; }
        Size Size { get; set; }


        int SelectionStart { get; set; }

        int SelectionEnd { get; set; }

        int SelectionLength { get; set; }

        void SetSelection(int index, bool plus);

        bool SelectionsStartEqualEnd { get; }
        bool SelectionsStartBigEnd { get; set; }

        void MinesSelection();
        void PlusSelection();

        void ShiftMinesSelection();
        void ShiftPlusSelection();


        string ValueInPole { get; set; }
        string TextInPole { get; set; }

        int ValueInPoleLength { get; }

        string SelectedText { get; set; }

        bool Multiline { get; set; }
        bool MultiLine { get; set; }
        bool MultyLine { get; set; }
        bool Multyline { get; set; }

        Font Font { get; set; }

        Color BackColor { get; set; }
        Color ForeColor { get; set; }

        DockStyle Dock { get; set; }

        bool IsTextBoxBase { get; }

        bool ReadOnly { get; set; }

        bool InputPole { get; set; }

        bool ValueInputToPole { get; set; }

        bool Visible { get; set; }

        bool Enabled { get; set; }

        Padding Margin { get; set; }
        Padding TextMargin { get; set; }
        Padding ClearMargin { get; set; }

        Padding Padding { get; set; }
        Padding TextPadding { get; set; }
        Padding ClearPadding { get; set; }


        Padding DefaultPadding { get;  }
        bool AutoSize { get; set; }

        EditTextByFile EditText { get; set; }
        ScrollBars ScrollBars { get; set; }

        Region Region { get; set; }
        Region TextRegion { get; set; }
        Region ClearRegion { get; set; }

        Rectangle ClientRectangle { get; }
        Rectangle TextClientRectangle { get; }
        Rectangle ClearClientRectangle { get; }

        Graphics CreateGraphics();

        string TextWidthPole { get; set; }

        AutoCompleteSource AutoCompleteSource { get; set; }
        AutoCompleteMode AutoCompleteMode { get; set; }
        AutoCompleteStringCollection AutoCompleteCustomSource { get; set; }

        int MarginAll { get; set; }
        int MarginRight { get; set; }
        int MarginLeft { get; set; }
        int MarginTop { get; set; }
        int MarginBottom { get; set; }
    }
}
