using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{ 
    public class LettersEditClass:List<string>
    {
        string name = "";
        public string Name { get => name; set => name = value; }


        public static LettersEditClass FromArray(string line, string name = "") => new LettersEditClass(line, name);

        public static LettersEditClass FromArray(IEnumerable<string> letters, string name) => new LettersEditClass(letters, name);

        public static LettersEditClass FromArray(IEnumerable<string> letters) => FromArray(letters, "");

        public static LettersEditClass FromArray(LettersEditClass letters) => FromArray(letters, letters.Name);

        public static LettersEditClass FromArray(LangugeEditClass languge) => FromArray(languge.ToLetters());


        public static LettersEditClass FromLanguge(LettersEditClass languge) => new LettersEditClass(languge);

        public void SetStartArray()
        {

        }

        public LettersEditClass():this("")
        {

        }

        public LettersEditClass(string name):base()
        {
            Name = name;
            SetStartArray();
        }

        public LettersEditClass(IEnumerable<string> letters, string name = ""):this(name)
        {

            Letters = new List<string>(letters);
        }

        public LettersEditClass(string letters, string name = "") : this(name)
        {

            LineLetters = letters;
        }

        public LettersEditClass(LettersEditClass letters):this(letters, letters.Name)
        {

        }


        public List<string> ArrayLetters
        {
            get => this;
            set
            {
                Clear();
                AddRange(value);
            }
        }

        public List<string> Letters
        {
            get => ArrayLetters;
            set => ArrayLetters = value;
        }

        public string[] Symvols
        {
            get => Letters.ToArray();
            set => Letters = new List<string>(value);
        }

        public string LineLetters
        {
            get => String.Join("", Symvols);
            set
            {
                List<string> letters = new List<string>();
                string result = value;
                while (result != "")
                {
                    int count = 2;
                    if (result.Length < 2)
                        count = 1;
                    string symwols = result.Substring(0, count);
                    letters.Add(symwols);
                    result = result.Remove(0, count);
                }
                Symvols = letters.ToArray();
            }
        }

        public const int StandartountLines = 6;

        public string[,] ToMatrix(int lines = StandartountLines) => ArrayToMatrix(Symvols, lines);

        public LangugeEditClass ToLanguge(int lines = StandartountLines) => new LangugeEditClass(ToMatrix(lines), Name);

        public static string[,] ArrayToMatrix(string[] array, int lines = StandartountLines)
        {
            int length = array.Length;
            int count = (array.Length / lines);
            while (count <= 1 && lines > 1)
            {
                lines--;

                count = array.Length / lines;
            }
            if (count <= 1 && lines <= 1)
                count = array.Length;
            else
                if (count * lines < length)
                count++;
            string[,] result = new string[lines, count];

            int line = 0, index = 0;
            for (int i = 0; i < length; i++)
            {
                index = i - count * line;
                while (index >= count)
                {
                    line++;
                    index = i - count * line;
                }
                string symwol = array[i];
                result[line, index] = symwol;
            }
            for (int i = index + 1; i < count; i++)
            {
                index = i;
                result[line, i] = " ";
            }
            for (int i = line + 1; i < lines; i++) 
            {
                line = i;
                for(int j = 0; j<count; j++)
                {
                    index = j;
                    result[i, j] = " ";
                }
            }

            return result;
        }
    }
}
