using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public class FileClassImage : PictureBoxFileClass<FileClass>
    {
        public override FileClass TagProperty { get => File; set => File = value; }

        private FileClass file;

        public FileClassImage() : base()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public FileClassImage(FileClass file):this()
        {
            File = file;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            base.Image = Bitmap;
        }

        public FileClass File
        {
            get
            {
                file.PictureBox = this;
                return file;
            }
            set
            {
                try
                {
                    FileClass image = value;
                    file.SetFile(image);
                    forderParent = image.Parent;
                    file.CopyFile = image;
                    file.PictureBox = this;
                    if (file.IsText && image.IsText)
                    {
                        file.AsText.Text = image.AsText.Text;
                    }
                    file.PictureBox = this;
                }
                catch
                {
                    file = value.Copy();
                    file.PictureBox = this;
                    file.CopyIndex();
                    forderParent = file.Parent;
                }
            }
        }

        public new Image Image
        {
            get
            {
                try
                {
                    try
                    {
                        return File.BitmapView;
                    }
                    catch (ArithmeticException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (ArgumentNullException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (NullReferenceException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (ArgumentException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message, e);
                    }
                }
                catch (Exception e)
                {
                    return new Bitmap(100, 100);
                }

            }
            set
            {
                try
                {
                    try
                    {
                        if (File.IsImage)
                        {
                            File.AsImage.Image = value;
                        }
                    }
                    catch (ArithmeticException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (ArgumentNullException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (NullReferenceException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (ArgumentException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message, e);
                    }
                }
                catch (Exception e)
                {
                    
                }
            }
        }

        public Bitmap Bitmap
        {
            get
            {
                try
                {
                    try
                    {
                        return File.BitmapView;
                    }
                    catch (ArithmeticException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (ArgumentNullException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (NullReferenceException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (ArgumentException e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message, e);
                    }
                }
                catch(Exception e)
                {
                    return new Bitmap(100, 100);
                }

            }
        }

    }
}
