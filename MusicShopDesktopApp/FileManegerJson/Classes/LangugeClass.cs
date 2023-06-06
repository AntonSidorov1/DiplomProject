using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace FileManegerJson
{
    [DataContract]
    public class LangugeEditClass
    {
        string[,] letters = new string[1, 1];
        string name = "";

        bool save = false;

        public bool Save { get => save; set => save = value; }

        public string[,] Letters { get => letters; set => letters = value; }

        public string[,] Symvols { get => Letters; set => Letters = value; }


        public string[,] Symwols { get => Symvols; set => Symvols = value; }

        [DataMember]
        public string Name { get => name; set => name = value; }

        public LangugeEditClass(string name = "")
        {
            Name = name;
        }

        public LangugeEditClass(string[,] letters, string name = "") : this(name)
        {
            Letters = letters;
        }

        public LangugeEditClass(string letters, string name = ""):this(name)
        {
            
                LineSymwols = letters;
        }

        public LangugeEditClass(string letters, string name = "", int lines = LettersEditClass.StandartountLines) : this(name)
        {
            LettersEditClass lettersClass = new LettersEditClass(letters, name);
            Letters = lettersClass.ToMatrix(lines);

        }




        public LangugeEditClass(LangugeEditClass languge) : this(languge.LineSymwols, languge.Name)
        {

        }

        public LangugeEditClass(IEnumerable<string> letters, string name = "", int lines = LettersEditClass.StandartountLines):this(LettersEditClass.FromArray(letters, name).ToLanguge(lines))
        {

        }

        public LangugeEditClass(IEnumerable<string> letters, int lines = LettersEditClass.StandartountLines) : this(letters, "", lines)
        {

        }

        public LangugeEditClass(LettersEditClass letters, int lines = LettersEditClass.StandartountLines): this(letters, letters.Name, lines)
        {

        }

        public int LinesCount() => Letters.GetLength(0);

        public static LangugeEditClass FromLettersClass(IEnumerable<string> letters, string name = "", int lines = LettersEditClass.StandartountLines) => LettersEditClass.FromArray(letters, name).ToLanguge(lines);

        public static LangugeEditClass FromLettersClass(IEnumerable<string> letters, int lines = LettersEditClass.StandartountLines) => LettersEditClass.FromArray(letters).ToLanguge(lines);

        public static LangugeEditClass FromLettersClass(LettersEditClass letters, int lines = LettersEditClass.StandartountLines) => LettersEditClass.FromArray(letters).ToLanguge(lines);

        public static LangugeEditClass FromLettersClass(LangugeEditClass languge) => FromLettersClass(languge.ToLetters(), languge.LinesCount());

        static int Max(IEnumerable<List<string>> list)
        {
            List<List<string>> result = new List<List<string>>(list);
            int max = 0;
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Count > max)
                    max = result[i].Count;
            }
            return max;
        }

        [DataMember]
        public string LineSymwols { get => LettersToLine(Symwols); set => Symwols = LineToLetters(value); }


        public static string[] MatrixToLine(string[,] matrix)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result.Add(matrix[i, j]);
                }
            }
            return result.ToArray();
        }

        public static string[,] LineToMatrix (string[] massiv, int lines = 6)
        {
            LettersEditClass letters = new LettersEditClass(massiv);
            return letters.ToMatrix(lines);
        }

        public string[] LangugeLine
        {
            get => MatrixToLine(Letters);
            set => Letters = LineToMatrix(value);
        }

        public LettersEditClass LettersLine
        {
            get => new LettersEditClass(LangugeLine, Name);
            set
            {
                LangugeLine = value.Letters.ToArray();
                Name = value.Name;
            }
        }

        static string[,] LineToLetters(string line)
        {
            string[,] result = new string[1, 1];

            List<List<string>> lines = new List<List<string>>();
            string[] lines1 = line.Split('/');
            for (int i = 0; i < lines1.Length; i++)
            {
                lines.Add(new List<string>(lines1[i].Split(';')));
            }
            int weight = Max(lines);
            int height = lines.Count;
            result = new string[height, weight];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    string symwol = lines[i][j];
                    string[] symwols = symwol.Split('_');
                    int left = Convert.ToInt32(symwols[0]);
                    int right = 0;
                    try
                    {
                        right = Convert.ToInt32(symwols[1]);
                    }
                    catch
                    {
                        right = Convert.ToInt32(symwols[0]);
                    }
                    result[i, j] = (char)left + "" + (char)right;
                }
            }


            return result;
        }

        static string LettersToLine(string[,] letters)
        {
            string result = "";

            int height = letters.GetLength(0);
            int weght = letters.GetLength(1);
            List<string> lines = new List<string>();
            for (int i = 0; i < height; i++)
            {
                List<string> symvols = new List<string>();
                for (int j = 0; j < weght; j++)
                {
                    string letter = letters[i, j];
                    int right = Convert.ToInt32(letter[0]);
                    int left = 0;
                    try
                    {
                        left = Convert.ToInt32(letter[1]);
                    }
                    catch
                    {
                        left = Convert.ToInt32(letter[0]);
                    }
                    symvols.Add(right + "_" + left);
                }
                lines.Add(String.Join(";", symvols.ToArray()));
            }
            result = String.Join("/", lines.ToArray());
            return result;
        }

        public void SaveJson(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string[] points = fileName.Split('.');
            int last = points.Length - 1;
            points[last] = points[last].Trim().ToLower();
            fileName = string.Join(".", points);
            JsonWrite(this, this.GetType(), fileName);
        }



        /// <summary>
        /// Сохраняет объект obj с типом type в Json-файл namefile
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="namefile"></param>
        private static void JsonWrite(object obj, Type type, string namefile)
        {
            namefile = namefile.Replace('/', '\\');
            FileStream fileStream = new FileStream(namefile, FileMode.Create);
            try
            {

                DataContractJsonSerializer json = new DataContractJsonSerializer(type);
                json.WriteObject(fileStream, obj);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                fileStream.Close();
                throw ex;
            }
        }


        public int Columns => Letters.GetLength(1);
        public int Rows => Letters.GetLength(0);


        /// <summary>
        /// Чтение из Json-файла
        /// </summary>
        /// <param name="namefile"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object JsonRead(string namefile, Type type)
        {

            namefile = namefile.Replace('/', '\\');
            DataContractJsonSerializer json = new DataContractJsonSerializer(type);
            FileStream fileStream = new FileStream(namefile, FileMode.Open);
            try
            {
                object obj = json.ReadObject(fileStream);
                fileStream.Close();
                return obj;
            }
            catch (Exception ex)
            {
                fileStream.Close();
                throw ex;
            }


        }

        public static LangugeEditClass Load(string fileName)
        {


            return (LangugeEditClass)JsonRead(fileName, typeof(LangugeEditClass));

        }


        public override string ToString() => Name;

        public static bool operator ==(LangugeEditClass languge1, LangugeEditClass languge2) => languge1.ToString() == languge2.ToString();

        public static bool operator !=(LangugeEditClass languge1, LangugeEditClass languge2) => !(languge1 == languge2);

        public static string[] ToArray(string[,] matrix)
        {
            int h = matrix.GetLength(0), w = matrix.GetLength(1);
            string[] result = new string[w * h];
            int index = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    result[index] = matrix[i, j];
                    index++;
                }
            }
            return result;
        }

        public string[] ToLettersList() => ToArray(Letters);

        public LettersEditClass ToLetters() => new LettersEditClass(ToLettersList(), Name);

    }
}
