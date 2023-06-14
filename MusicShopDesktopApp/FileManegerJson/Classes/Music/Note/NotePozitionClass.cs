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
    public class NotePozitionClass : AbstractNotesClass
    {
        /// <summary>
        /// Интервал от предыдущей ноты
        /// </summary>
        [XmlElementAttribute(IsNullable = false, ElementName ="IntervalFromLastNote")]
        [DataMember]
        public int Interval { get; set; }

        /// <summary>
        /// Ступень
        /// </summary>

        [XmlElementAttribute(IsNullable = false, ElementName = "StupenIsNote")]
        [DataMember]
        public int Stupen { get; set; }

        /// <summary>
        /// Создание класса
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="stupen"></param>
        public NotePozitionClass(int interval, int stupen)
        {
            Interval = interval;
            Stupen = stupen;
        }

        public void SetStupen(int stupen)
        {
            while (stupen < 1 || stupen > 7)
            {
                if (stupen < 1)
                    stupen += 7;
                else if (stupen > 7)
                    stupen -= 7;
            }
            Stupen = stupen;
        }

        public void SetInerval(int interval)
        {
            int absInterval = Math.Abs(interval);
            while(absInterval > 6)
            {
                int delta = interval / absInterval;
                interval = 12 - absInterval;
                delta *= (-1);
                interval += delta;
                absInterval = Math.Abs(interval);
            }
            Interval = interval;
        }

        public void SetInterval() => SetInerval(Interval);

        public void SetStupen() => SetStupen(Stupen);

        public NotePozitionClass():this(1,1)
        {

        }

        public override string GetName()
        {
            SetStupen();
            SetInterval();
            return string.Join(".", Stupen, Interval);
        }

        public override void SetName(string name)
        {
            string[] result = name.Split(new char[] { ' ', '.', ',', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            SetStupen(Convert.ToInt32(result[0]));
            SetInerval(Convert.ToInt32(result[1]));
        }
    }
}
