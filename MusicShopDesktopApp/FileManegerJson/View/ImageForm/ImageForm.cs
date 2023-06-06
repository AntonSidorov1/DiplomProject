using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    public partial class ImageForm : Form
    {
        
        public ImageForm(ImageFile file)
        {
            InitializeComponent();
            pictureBoxImage.Image = file.Image;
            textBoxName.Text = file.FileName;
            textBoxIndexName.Text = file.IndexFileName;
            textBoxProperty.Text = file.PropertyOfCopyFileNewLine;
            try
            {
                contextMenuImage.File = file.CopyFile;
            }
            catch
            {
                contextMenuImage.File = file;
            }
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveImage_Click(object sender, EventArgs e)
        {
            
            Bitmap bmpDrawing;
            Rectangle rectBounds;
            SaveFile.Filter = new ImageFile().TypesFileContentWithTxt;
            //SaveFile.FileName = textBoxFileName.Text + ".jpg";
            SaveFile.FilterIndex = 1;
            ImageFile image = contextMenuImage.File.AsFileClass.AsImage;
            SaveFile.FileName = image.FileName + ".jpg";
            if (SaveFile.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                // Create bitmap for paint storage
                bmpDrawing = new Bitmap(image.Bitmap);

                // Set the bounds of the bitmap
                //rectBounds = new Rectangle(0, 0, bmpDrawing.Width, bmpDrawing.Height);

                // Move drawing to bitmap
                //PanelImage.DrawToBitmap(bmpDrawing, rectBounds);

                // Save the bitmap to file
                bmpDrawing.Save(SaveFile.FileName);
                MessageBox.Show("Уважаемый пользователь \n" +
                    $"Ваша картинка успешно сохранена в файле {SaveFile.FileName} \n" +
                    $"Вы также можете сохранять свои работы (картинки) в файлы, являющиеся изображениями \n" +
                    $"С уважением, Создатель программы, Сидоров Антон Дмитриевич");
            }
            catch (Exception f)
            {
                MessageBox.Show("Уважаемый пользователь \n" +
                    $"Не удалось сохранить картинку в файле {SaveFile.FileName} \n" +
                    $"Вы можете повторить попытку \n" +
                    $"С уважением, Создатель программы, Сидоров Антон Дмитриевич");
            }
        }

        private void какJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileClass file1 = contextMenuImage.File.AsFileClass;
                ImageFile image = file1.AsImage;
                string[] line = image.Name.Split('/', '\\');
                SaveFile.FileName = line[line.Length - 1];

                SaveFile.Filter = image.TypesFileJsonWithTxt;
                DialogResult result = SaveFile.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                image.SaveJson(SaveFile.FileName);
                MessageBox.Show("Изображение успешно сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неудалось сохранить изображение");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            contextMenuImage.Show(sender as Control, new Point(0, 0));
        }
    }
}
