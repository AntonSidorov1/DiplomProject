using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace FileManegerJson
{

    /// <summary>
    /// Нота в гамме
    /// </summary>
    [DataContract]
    public class NoteInGammaClass : AbstractNotesClass
    {
        string[] Notes = { "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab", "A", "A#/Bb", "B" };
        string[] NotesName = { "До", "До#/Реb", "Ре", "Ре#/Миb", "Ми", "Фа", "Фа#/Сольb", "Соль", "Соль#/Ляb", "Ля", "Ля#/Сиb", "Си" };
        string[] NotesStupens = { "C", "D", "E", "F", "G", "A", "B" };
        string[] NotesNameStupens = { "До", "Ре", "Ми", "Фа", "Соль", "Ля", "Си" };

        public int CountNotes => HaveStupens ? NotesStupens.Length : Notes.Length;


        public void SeNoteName(string name) => SetNoteSymwol(name);
        public void SetNoteSymwol(string symwol)
        {
            if(!HaveStupens)
            {
                string Text = symbol;
                Text = IndexFromNote(Text, out int interval);
                
                //if (Text.Contains('/'))
                //{
                //    Text += "b";
                //    interval++;
                //}
                Text = ToBemol(Text);
                string text = FromBemol(Text);
                int a = 0;
                if (ElementInMassive(Text, Notes, out int i))
                {
                    a = i;
                }
                else if (ElementInMassive(Text, NotesName, out int k))
                {
                    a = k;
                }
                if (ElementInMassive(text, Notes, out int j))
                {
                    a = j;
                }
                else if (ElementInMassive(text, NotesName, out int k))
                {
                    a = k;
                }
                a += interval;

                while (a < -6 || a >6)
                {
                    int Delta = 12;
                    if (a < -6)
                    {
                        a += Delta;
                    }
                    else
                    {
                        a -= Delta;
                    }
                }

                Index = a;
                a = Index;
                a += interval;
                interval = a;
                while (Math.Abs(interval) > 6)
                {
                    int c = Math.Abs(interval);

                    int a1 = interval / c;

                    int b = 12 - Math.Abs(interval);
                    b *= a1;
                    b *= (-1);
                    interval = b;
                }
                Plus = interval;
            }
            else
            {
                string Text = symwol;
                Text = ToBemol(Text);
                Text = IndexFromNote(Text, out int i);

                int a = 0;
                if (ElementInMassive(Text, NotesStupens, out int j))
                {
                    a = j;
                }
                else if (ElementInMassive(Text, NotesNameStupens, out int k))
                {
                    a = k;
                }

                while (a < 1 || a > 7)
                {
                    int Delta = 7;
                    if (a < 1)
                    {
                        a += Delta;
                    }
                    else
                    {
                        a -= Delta;
                    }
                }

                Index = a;
                int b = i;
                int start = -6;
                int end = 6;
                int delta = end - start + 1;
                while (b < start || b > end)
                {
                    int s = b / Math.Abs(b);
                    b -= delta * s;
                }
            }
            NormalIndex();
            SetNoteIndex();
        }




        /// <summary>
        /// Массив гаммы До-мажор
        /// </summary>
        /// <value></value>
        static int[] Cmaj = { 2, 2, 1, 2, 2, 2, 1 };

        string symbol, name;
        int index, plus;
        bool haveStupens;

        public void NormalInterval()
        {
            int interval = Plus;
            while (Math.Abs(interval) > 6)
            {
                int c = Math.Abs(interval);

                int a = interval / c;

                int b = 12 - Math.Abs(interval);
                b *= a;
                b *= (-1);
                interval = b;
            }
            Plus = interval;
        }

        public void NormalIndex()
        {
            int interval = Index;
            while (interval > CountNotes || interval < 1)
            {
                if (interval < 1)
                    interval += CountNotes;
                else
                    interval -= CountNotes;
            }
            Index = interval;
        }

        public void SetInerval(int interval = 0)
        {
            Plus = interval;
            
            SetNoteIndex(Index);
        }

        public void SetNoteIndex() => SetNoteIndex(Index);
        public void SetNoteIndex(int index)
        {
            int a = index;
            int count = haveStupens ? 7 : 12;
            while (a < 1 || a > count)
            {
                if (a < 1)
                {
                    a += count;
                }
                else
                {
                    a -= count;
                }
            }
            index = a;

            NormalInterval();
            int interval1 = Plus;
            int interval = interval1;
            int note = index;
            string result = "";
            string resultName = "";

           

            if (HaveStupens)
            {
                while (note > 7)
                {
                    note -= 7;

                }
                while (note < 1)
                {
                    note += 7;
                }

                result = NotesStupens[note - 1];
                resultName = NotesNameStupens[note - 1];

                if (interval == 0)
                {
                    symbol = result;
                    Name = resultName;
                    return;
                }
                else
                {


                    while (interval > 0)
                    {
                        result += "#";
                        interval--;
                    }
                    while (interval < 0)
                    {
                        result += "♭";
                        interval++;
                    }


                }
            }
            else
            {

                while (note > 12)
                {
                    note -= 12;
                }
                while (note < 1)
                {
                    note += 12;
                }


                result = Notes[note - 1];
                resultName = NotesName[note - 1];

                
            }
            Symbol = result;
            Name = resultName;
            
        }


        /// <summary>
        /// Находится ли элемент element в массиве massive. index - индекс элемента
        /// </summary>
        /// <param name="element"></param>
        /// <param name="massive"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static bool ElementInMassive(string element, string[] massive, out int index, bool trimLower = true)
        {
            bool result = false;
            index = 0;
            for (int i = 0; i < massive.Length; i++)
            {
                if(trimLower)
                {
                    if (massive[i].Trim().ToLower() == element.Trim().ToLower())
                    {
                        index = i;
                        return true;
                    }
                }
                else if (massive[i] == element)
                {
                    index = i;
                    return true;
                }
            }
            return result;
        }

        public NoteInGammaClass(string symbols, string Names, int index, int plus, bool HaveStupens = false) : base()
        {
            this.symbol = symbols;
            this.name = Names;
            this.index = index;
            this.plus = plus;
            this.haveStupens = HaveStupens;

        }

        public NoteInGammaClass(string name):this()
        {
            SetNoteSymwol(name);
        }

        /// <summary>
        /// Возвращает или задаёт буквенное обозначение ноты
        /// </summary>
        [XmlElementAttribute(IsNullable = false, ElementName = "Symbol")]
        [DataMember]
        public string Symbol
        {
            get => symbol;
            set => symbol = value;
        }

        /// <summary>
        /// Возвращает или задаёт название ноты
        /// </summary>
        [XmlElementAttribute(IsNullable = false, ElementName = "Name")]
        [DataMember]
        public string Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// Возвращает индекс ноты
        /// </summary>
        [XmlElementAttribute(IsNullable = false, ElementName = "Index")]
        [DataMember]
        public int Index
        {
            get => index;
            set => index = value;
        }

        /// <summary>
        /// Интервал увеличения ноты, задающий знаки альтерации
        /// </summary>
        [XmlElementAttribute(IsNullable = false, ElementName = "Plus")]
        [DataMember]
        public int Plus
        {
            get => plus;
            set => plus = value;
        }

        /// <summary>
        /// Возвращает или задаёт, учитываются ли ступени
        /// </summary>
        [XmlElementAttribute(IsNullable = false, ElementName = "HaveStupens")]
        [DataMember]
        public bool HaveStupens
        {
            get => haveStupens;
            set => haveStupens = value;
        }


        public NoteInGammaClass() : this("C", "До", 0, 0)
        {

        }


        /// <summary>
        /// Возвращает ноту или её название без знаков альтерации, и интерал её увеличения в зависимости от знаков альтерации
        /// </summary>
        /// <param name="note"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public string IndexFromNote(string note, out int interval)
        {
            interval = 0;

            note = FromBemol(note);
            note = note.Trim();
            note = note.Replace("\\", "/");
            note = note.Replace(",", "/");
            note = note.Replace(".", "/");
            note = string.Join("", note.Split(new char[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries));

            while (RightSymwol(note) == "#" || RightSymwol(note) == "b")
            {
                note = note.Trim();
                if (note.Length < 2)
                    break;
                if(RightSymwol(note)=="/")
                {
                    interval++;
                    note += "B";
                    break;
                }
                if (RightSymwol(note) == "#")
                    interval++;
                if (RightSymwol(note) == "b")
                    interval--;
                note = note.Remove(note.Length - 1, 1);
            }
            if(note.Contains('/'))
            {
                interval++;
                note += "b";
            }

            while (Math.Abs(interval) > 6)
            {
                int c = Math.Abs(interval);

                int a = interval / c;

                int b = 12 - Math.Abs(interval);
                b *= a;
                b *= (-1);
                interval = b;
            }

            return note;
        }


        /// <summary>
        /// Меняет в строке символы обозначения бемолей на символы 'b' и возвращает изменённую строку
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        public static string FromBemol(string Note)
        {
            string result = "";

            //int length = Note.Length;

            //for (int i = 0; i < length; i++)
            //{
            //    string Symwol = RightSymwol(Note);
            //    if (Symwol == "♭")
            //    {
            //        Symwol = "b";
            //    }

            //    result += Symwol;

            //    Note = Note.Remove(length, 1);
            //}
            //Note = result;
            result = Note.Replace("♭", "b");

            return result;
        }

        /// <summary>
        /// Меняет в строке символы 'b' на символы обозначения бемолей и возвращает изменённую строку
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        public static string ToBemol(string Note)
        {
            string result = "";

            //int length = Note.Length;

            //for (int i = 0; i < length; i++)
            //{
            //    string Symwol = RightSymwol(Note);
            //    if (Symwol == "b")
            //    {
            //        Symwol = "♭";
            //    }

            //    result += Symwol;

            //    Note = Note.Remove(length, 1);
            //}
            //Note = result;

            result = Note.Replace("b", "♭");
            return result;
        }


        /// <summary>
        /// Возвращает самый последний символ в строке Text
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        static string RightSymwol(string Text)
        {
            string result = Text.Trim().Remove(0, Text.Length - 1);

            return result;
        }

        public int NoteUp(NoteInGammaClass oneNote, int stupen, out int interval, bool HaveStupens = false)
        {
            return NoteUp(oneNote, this, stupen, out interval, HaveStupens);
        }

        static int NoteUp(NoteInGammaClass oneNote, NoteInGammaClass currentNote, int stupen, out int interval, bool HaveStupens = false)
        {
            int index = currentNote.Index;
            int result = NoteUp(oneNote.Index, oneNote.Plus, ref index, stupen, out interval, HaveStupens);
            currentNote.Index = index;
            currentNote.Plus += result;
            currentNote.NormalInterval();
            return result;
        }


        /// <summary>
        /// Возвращает интервал увеличения ноты при отсутствие ступеней (при этом interval = 0) или 0 при наличии ступеней (при этом interval - возвращаемой значение - интервал увеличения). HaveStupens - наличие ступеней. OneNote - нота, являющаяся первой ступень, увеличенная на IntervalOneNote интервал. CurrentNote - Нота, являющаяся stupen ступенью
        /// </summary>
        /// <param name="OneNote"></param>
        /// <param name="CurrentNote"></param>
        /// <param name="stupen"></param>
        /// <param name="interval"></param>
        /// <param name="HaveStupens"></param>
        /// <returns></returns>
        static int NoteUp(int OneNote, int IntervalOneNote, ref int CurrentNote, int stupen, out int interval, bool HaveStupens = false)
        {
            int result = 0;
            interval = 0;

            int[] CurrentIntervals = new int[Cmaj.Length];

            int interval1 = 0; // Интервал увеличения первой ноты
            int IntervalCurrent = 0; // Интервал увеличения текущей ноты

            string[] NotesStupens = { "C", "D", "E", "F", "G", "A" };// Ноты со ступенями

            string[] Notes = { "C", "", "D", "", "E", "F", "", "G", "", "A", "", "B" };

            int note1 = OneNote;

            int IntervalFromOneNote = 0;



            if (!HaveStupens)
            {
                while (note1 > 12 || note1 < 1)
                {
                    if (note1 > 12)
                    {
                        note1 += 12;
                    }
                    else
                    {
                        note1 -= 12;
                    }

                }
                OneNote = note1;
                note1--;



                string Note = Notes[note1];


                while (!ElementInMassive(Note, NotesStupens, out int index))
                {
                    IntervalOneNote++;
                    note1--;
                    while (note1 < 0)
                    {
                        note1 += 12;
                    }
                    Note = Notes[note1];
                }
            }
            else
            {
                while (note1 > 7 || note1 < 1)
                {
                    if (note1 > 7)
                    {
                        note1 -= 7;
                    }
                    else
                    {
                        note1 += 7;
                    }

                }
                OneNote = note1;
                note1--;
            }




            CurrentIntervals[0] = Cmaj[note1];
            for (int i = 1; i < Cmaj.Length; i++) // Восстановление белоклавишных нот заданной ноты
            {
                note1++;
                while (note1 > 6)
                {
                    note1 -= 7;
                }
                while (note1 < 0)
                {
                    note1 += 7;
                }
                CurrentIntervals[i] = Cmaj[note1];
            }

            while (stupen > 7 || stupen < 1)
            {
                if (stupen > 7)
                {
                    stupen -= 7;
                }
                else
                {
                    stupen += 7;
                }
            }
            if (!HaveStupens)
                stupen--;

            for (int i = 0; i < stupen; i++)
            {
                IntervalFromOneNote += CurrentIntervals[i];
            }
            IntervalFromOneNote += IntervalOneNote;

            if (!HaveStupens)
            {


                string Note = Notes[OneNote - 1];
                if (ElementInMassive(Note, NotesStupens, out int index))
                {
                    interval1 = 0;
                }
                else
                {
                    while (!ElementInMassive(Note, NotesStupens, out int index1))
                    {
                        interval1++;
                        OneNote--;

                        while (OneNote < 1)
                        {
                            OneNote += 12;
                        }

                        Note = Notes[OneNote - 1];
                    }
                }



                OneNote += interval1;

                int DeltaNote = CurrentNote - OneNote;

                while (DeltaNote < 0)
                {
                    DeltaNote += 7;
                }

                int RealInterval = DeltaNote + interval1;

                result = RealInterval - IntervalFromOneNote + IntervalOneNote;

                while (result > 6 || result < -6)
                {
                    int DeltaResult = result / Math.Abs(result);
                    result = 12 - Math.Abs(result);
                    result *= DeltaResult;
                    result *= (-1);
                }
                interval = 0;
            }
            else
            {


                int RealIntervals = 0;
                int DeltaNote = CurrentNote - OneNote + 1;

                while (DeltaNote < 0)
                {
                    DeltaNote += 7;
                }

                for (int i = 0; i < DeltaNote; i++)
                {
                    RealIntervals += CurrentIntervals[i];
                }
                interval = RealIntervals - IntervalFromOneNote + IntervalOneNote;

                result = interval;

                while (result > 6 || result < -6)
                {
                    int DeltaResult = interval / Math.Abs(result);
                    result = 12 - Math.Abs(result);
                    result *= DeltaResult;
                    result *= (-1);
                }

                interval = result;

                result = interval;
            }

            return result;
        }

        public override string GetName()
        {
            return Name;
        }

        public override void SetName(string name)
        {
            SetNoteSymwol(name);
        }
    }
}
