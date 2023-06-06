using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    /// <summary>
    /// Торговая сеть
    /// </summary>
    [DataContract]
    public class DisributingFacilities : DistributingPoint
    {
        public DisributingFacilities()
        {
        }

        public DisributingFacilities(string name) : base(name)
        {
        }

        public DisributingFacilities(ProductParameter parameter) : base(parameter)
        {
        }

        public override void SetParameter(ProductParameter parameter)
        {
            base.SetParameter(parameter);
            if(parameter is DisributingFacilities)
            {
                DisributingFacilities org = (parameter as DisributingFacilities);
                Site = org.Site;
                Logotip = org.Logotip;
            }

        }

        string site = "";

        [DataMember]
        public string Site
        {
            get => site;
            set => site = value;
        }


        string logotip = "";

        /// <summary>
        /// Логотип
        /// </summary>
        [DataMember]
        public string Logotip
        {
            get => logotip;
            set => logotip = value;
        }

        /// <summary>
        /// Установить логотип
        /// </summary>
        /// <param name="photo"></param>
        public void SetLogotip(byte[] photo)
        {
            Logotip = Convert.ToBase64String(photo);
        }

        public byte[] LogotipBytes
        {
            get => Convert.FromBase64String(Logotip);
            set => SetLogotip(value);
        }


        public Bitmap LogotipImage
        {
            get
            {
                MemoryStream memory = new MemoryStream(LogotipBytes);
                Bitmap bitmap = new Bitmap(memory);
                memory.Close();
                return bitmap;
            }
            set
            {
                MemoryStream memory = new MemoryStream();
                value.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                LogotipBytes = memory.ToArray();
            }
        }


        public Bitmap ImageLogoip
        {
            get
            {
                try
                {
                    return new Bitmap(LogotipImage);
                }
                catch
                {
                    return new Bitmap(100, 100);
                }
            }
        }

        public bool HaveLogotip
        {
            get
            {
                if (Logotip.Length < 1)
                    return false;
                try
                {
                    Bitmap bitmap = new Bitmap(LogotipImage);
                    bitmap.Dispose();
                    return true;
                }
                catch
                {
                    return false;
                }

            }

        }
    }
}
