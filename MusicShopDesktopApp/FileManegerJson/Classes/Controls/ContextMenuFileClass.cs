using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public class ContextMenuFileClass : ContextMenuStrip
    {
        public ContextMenuFileClass() : base()
        {
            
        }

        public ContextMenuFileClass(ToolStrip tools) : this()
        {
            int count = tools.Items.Count;
            Font = tools.Font;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    Items.Add(tools.Items[i]);
                }
                catch
                {
                    Items.Add(tools.Items[0]);
                }
            }

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (File.IsFileClass)
                {
                    GetSettingsByFile?.Invoke(File.AsFileClass);
                }
            }
            catch (NullReferenceException ex)
            {

            }
            catch (ArgumentNullException ex)
            {

            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            catch (ArithmeticException ex)
            {

            }
            catch (ArgumentException ex)
            {

            }
            catch
            {

            }
        }

        public event Action<FileClass> GetSettingsByFile;

        public Action<FileClass> GetSettingsByFileDelegate
        {
            get => GetSettingsByFile;
            set => GetSettingsByFile = value;
        }

        AbstractFileClass file;

        /// <summary>
        /// Возвращает или задаёт файл
        /// </summary>
        public AbstractFileClass File
        {
            get => file;
            set => file = value;
        }


    }
}
