using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class EditTextByFile
    {
        string text = "";

        public string Text { get => text; set => text = value; }

        public string[] Lines { get => Text.Split('\n', '\r'); set => Text = string.Join("\n", value); }

        public EditTextByFile()
        {

        }

        public EditTextByFile(string text) :this()
        {
            Text = text;
        }

        public EditTextByFile(EditTextByFile editText):this(editText.Text)
        {

        }

    }
}
