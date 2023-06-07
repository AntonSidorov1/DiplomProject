using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Text.Json;

namespace FileManegerJson
{
    public partial class DiskForm : Form
    {
        Properties.Settings settings;
        string title, path;
        bool mayOK = false;

        string filePath
        {
            get => settings.FilePath;
            set
            {
                settings.FilePath = value;
                settings.Save();
                if(havePath)
                {
                    Text = title + " - " + filePath;
                }
                else
                {
                    Text = title;
                }
            }
        }

        bool havePath => filePath != "" && !filePath.Equals("") && !filePath.Equals(null) && filePath != null;

        bool haveCachPath => path != "" && !path.Equals("") && !path.Equals(null) && path != null;

        AbstractFileClass FewFile;

        public AbstractFileClass ChangedFile
        {
            get => FewFile;
            set => FewFile = value;
        }

        public FileClass FileClass
        {
            get => FewFile.AsFileClass;
            set => FewFile = value;
        }

        Form MainForm;
        bool yesChoose;
        public ref bool YesChoose => ref yesChoose;

        public DiskForm(AbstractFileClass file, ref bool yesChoose1, Form mainForm, bool open = false) : this(file, ref yesChoose1, open)
        {
            MainForm = mainForm;
        }

        public DiskForm(AbstractFileClass file, bool open = false) : this(open)
        {
            yesChoose = false;
            yesChoose = YesChoose;
            FewFile = file;
            if (file is FileClass)
            {
                file1 = FewFile as FileClass;
                //Folders.Add(file1);
                //FromFolderClass(Folders);
            }
            if (file is ImageFile)
                Image.Image = (file as ImageFile).Image;
            else if (file is FileClass)
                Image.Image = (file as FileClass).ImageView;
            textBoxFileName.Text = (file as FileClass).FileName;
            textBoxIndexFileName.Text = file.IndexFileName;
        }

        public DiskForm(AbstractFileClass file, ref bool yesChoose1, bool open = false) : this(open)
        {
            
            yesChoose = yesChoose1;
            yesChoose = YesChoose;
            FewFile = file;
            if (file is FileClass)
            {
                file1 = FewFile as FileClass;
                //Folders.Add(file1);
                //FromFolderClass(Folders);
            }
            if (file is ImageFile)
                Image.Image = (file as ImageFile).Image;
            else if (file is FileClass)
                Image.Image = (file as FileClass).ImageView;
            textBoxFileName.Text = (file as FileClass).FileName;
            textBoxIndexFileName.Text = file.IndexFileName;

        }

        public DiskForm() : this(true)
        {
            
        }

        public DiskForm(bool open)
        {
            open = false;
            yesChoose = false;
            InitializeComponent();
            choises = new ComboBoxNameClear[] { ButtonLeft, ButtonRight, ButtonMiddle, ClickDouble };
            toolStripMenuItemOpen.Visible = open;

            title = Text;
            path = "";
            settings = Properties.Settings.Default;
            Folders = HelperSettings.Folder;
            folderButonUpdate.Folder = Folders;
        }

        ContextMenuFileClass ContextMenuFileClass => contextMenuStrip1 as ContextMenuFileClass;

        int selectedIndexAddOne = 6;
        ComboBoxNameClear[] choises;
        object[] pounkts = new object[] {"ничего",
            "Удалять",
            "Перемещать",
            "Выбирать",
            "Сохранять содержимое на устройстве",
            "Вызов контекстного меню",
            "Открывать",
            "Увеличить размер на 1",
            "Увеличить размер на 2",
            "Увеличить размер на 3",
            "Увеличить размер на 4",
            "Увеличить размер на 5",
            "Увеличить размер на 6",
            "Увеличить размер на 7",
            "Увеличить размер на 8",
            "Увеличить размер на 9",
            "Увеличить размер на 10",
            "Уменьшить размер на 1",
            "Уменьшить размер на 2",
            "Уменьшить размер на 3",
            "Уменьшить размер на 4",
            "Уменьшить размер на 5",
            "Уменьшить размер на 6",
            "Уменьшить размер на 7",
            "Уменьшить размер на 8",
            "Уменьшить размер на 9",
            "Уменьшить размер на 10"
        };

        int x0, y0;
        bool drag;

        PictureBox PB;
        Random rand;
        DateTime dt = new DateTime();
        Bitmap bit;

        string CloseFile;
        //Pazles.FormClose exit;
        ToolStripMenuItem ButClose;

        FolderClass Folders = new DiskPartClass(new HardDiskClass());
        FileClass file1;

        ref string name => ref file1.RefName;


        private void Program_Close_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            catch
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void Program_Exit_Click(object sender, EventArgs e)
        {
            DialogResult res;

            res = MessageBox.Show("Уважаемый пользыватель\r Вы действительно хотите выйти из программы?\rПосле выхода вы также можете снова запуститить прогамму\r С уважением, Создатель программы, \r Сидоров Антон Дмитриевич", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                MessageBox.Show("Уважаемый пользыватель \r Работа программы продолжается \r Все возможности в этой программе вам предоставлены \r С уважением, Создатель программы, \r Сидоров Антон Дмитриевич");

            }
            else
            {
                MessageBox.Show("Уважаемый пользыватель \rРабота программы завершена \r Спасибо, что воспользовались программой \r Вы также можете снова запустить программу \r С уважение, Создатель программы,\r Сидоров Антон Дмитиревич");

                Environment.Exit(0);
            }
        }

        private void ImageClear_Click(object sender, EventArgs e)
        {
            file1 = null;
            textBoxFileName.Text = "";
            textBoxIndexFileName.Text = "";
            ContextMenuFileClass.File = null;
            labelIndex.Text = "";

            start: try
            {
                if (File.Exists("Image.jpg"))
                {
                    File.Delete("Image.jpg");
                }
            }
            catch (System.IO.IOException)
            {
                goto start;
            }
            Image.Image = null;
        }



        /// <summary>
        /// Форматирует время
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        private string TimeFormat(int Input)
        {
            if (Input < 10)
                return $"0{Input}";
            else
                return $"{Input}";
        }

        /// <summary>
        /// Форматирует дату Input, чтобы она имела length знаков
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string DateFormat(int Input, int length)
        {
            string OutPut = $"{Input}";
            while (OutPut.Length < length)
            {
                OutPut = $"0{OutPut}";
            }
            return OutPut;
        }

        private void ImageChosen_Click(object sender, EventArgs e)
        {
            

            
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
        {
            Interval = 1000,
        };

        private void PictireFile_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is FilePictureBox))
                return;

            ComboBoxNameClear But = null;
            FilePictureBox Pix = (sender as FilePictureBox);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                But = ButtonLeft;
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                But = ButtonRight;
            }
            else if (e.Button == MouseButtons.Middle && e.Clicks == 1)
            {
                But = ButtonMiddle;
            }
            else if (e.Clicks == 2)
            {
                But = ClickDouble;
            }
            Pix.BringToFront();

            int selectedIndex;
            try
            {
                selectedIndex = But.SelectedIndex;
            }
            catch
            {
                selectedIndex = 3;
            }

            if (selectedIndex == 1)
            {
                FileClass content = Pix.GetFileNow();
                ContextMenuFileClass.File = content;
                ContextMenuFileClass.File.CopyFile = Folders[content.TemporaryIndex];
                buttonDropFile_Click(sender, e);
                return;
            }

            if (selectedIndex == 2)
            {
                x0 = e.X;
                y0 = e.Y;
                drag = true;
                Pix.MouseMove += Pix_MouseMove;
                Pix.MouseUp += Pix_MouseUp;
                return;
            }
            if (selectedIndex == 3 || e.Clicks == 0)
            {
                Bitmap BitPix = (Bitmap)Pix.Image;
                Image.Image = BitPix;
                int index = Convert.ToInt32(Pix.Tag);
                FileClass file = Pix.FileNowInFolder();
                //file.CopyFile = Pix.ImageFile;
                labelIndex.Text = file.IndexText;
                try
                {
                    file1.Dispose();
                }
                catch
                {

                }
                file1 = file.Copy();
                file1.PictureBox = file.PictureBox;
                file1.CopyFile = file;
                textBoxFileName.Text = file.FileName;
                textBoxIndexFileName.Text = file.IndexFileName;
                ContextMenuFileClass.File = file;
                return;
            }

            if (selectedIndex > selectedIndexAddOne && selectedIndex < selectedIndexAddOne + 21)
            {
                int increment = But.SelectedIndex - (selectedIndexAddOne + 1);
                int delta = ((increment / 10));
                delta = (delta == 0) ? 1 : -1;
                increment = (increment % 10) + 1;
                int increment1 = increment / 2;
                Pix.BringToFront();

                if (delta > 0)
                {
                    Pix.Width += increment;
                    Pix.Left -= increment1;
                    Pix.Height += increment;
                    Pix.Top -= increment1;
                }
                if (delta < 0)
                {
                    Pix.Width -= increment;
                    Pix.Left += increment1;
                    Pix.Height -= increment;
                    Pix.Top += increment1;
                }
                return;
            }
            if (selectedIndex == 5)
            {
                ContextMenuFileClass.File = Pix.GetFileNow();
                ContextMenuFileClass.File.CopyFile = Pix.FileNowInFolder();
                contextMenuStrip1.Show(Pix, new Point(Pix.Width / 20, Pix.Height / 20));
                return;
            }
            if (selectedIndex == 6)
            {
                ContextMenuFileClass.File = Pix.GetFileNow();
                ContextMenuFileClass.File.CopyFile = Pix.FileNowInFolder();
                toolStripMenuItemOpenFile_Click(sender, e);
                return;
            }

            if (selectedIndex == 4)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                try
                {
                    FileClass file = Pix.GetFileNow();
                    saveFile.FileName = file.Name;
                    saveFile.Filter = file.TypesFileContentWithTxt;
                    if(file.IsDataBase)
                    {
                        saveFile.Title = "Сохранение строки подключения";
                    }
                    else if(file.IsImage)
                    {
                        saveFile.Title = "Сохранение изображения";
                        SaveFile.FileName = file + ".jpg";
                        SaveFile.FilterIndex = 1;
                    }
                    else if(file.IsText)
                    {
                        saveFile.Title = "Сохранение текста";
                        SaveFile.FileName = file + ".text";
                        SaveFile.FilterIndex = 1;
                    }
                    else if(file.IsNote)
                    {
                        saveFile.Title = "Сохранение заметки";
                    }
                    else if (file.IsSity)
                    {
                        saveFile.Title = "Сохранение города";
                    }
                    else if (file.IsOrganizaion)
                    {
                        saveFile.Title = "Сохранение организации (торговой сети)";
                    }
                    else if (file.IsTraidingPoint)
                    {
                        saveFile.Title = "Сохранение торговой точки";
                    }
                    else if (file.IsStore)
                    {
                        saveFile.Title = "Сохранение торговой точки";
                    }


                    if (saveFile.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }

                    if (sender is PictureBoxFile)
                    {
                        Bitmap bmpDrawing = file.AsImage.Bitmap;

                        // Set the bounds of the bitmap
                        //rectBounds = new Rectangle(0, 0, bmpDrawing.Width, bmpDrawing.Height);

                        // Move drawing to bitmap
                        //PanelImage.DrawToBitmap(bmpDrawing, rectBounds);

                        bmpDrawing.Save(saveFile.FileName);
                    }
                    else if (sender is PictureBoxTextFile)
                    {
                        File.WriteAllText(saveFile.FileName, file.AsText.Text);
                    }    
                        
                    else if (sender is PictureBoxDataBaseFile)
                    {
                        
                        file.AsDataBase.DataBase.SaveJson(saveFile.FileName);
                    }
                    else if(sender is PictureBoxNote)
                    {
                        file.AsNote.Content.SaveJson(saveFile.FileName);
                    }

                    else if (sender is PictureBoxSity)
                    {
                        file.AsSity.Content.SaveJson(saveFile.FileName);
                    }

                    else if (sender is PictureBoxOrg)
                    {
                        file.AsOrganizaion.Content.SaveJson(saveFile.FileName);
                    }

                    else if (sender is PictureBoxTraidingPoint)
                    {
                        file.AsTraidingPoint.Content.SaveJson(saveFile.FileName);
                    }

                    else if (sender is PictureBoxStore)
                    {
                        file.AsStore.Content.SaveJson(saveFile.FileName);

                    }

                    MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Pix_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            (sender as PictureBox).MouseMove -= Pix_MouseMove;
            (sender as PictureBox).MouseUp -= Pix_MouseUp;
        }

        private void Pix_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox Pix = (sender as PictureBox);
            if (drag)
            {
                Pix.Left += (e.X - x0);
                Pix.Top += (e.Y - y0);
            }
        }

        private void DoingClear_Click(object sender, EventArgs e)
        {
            ButtonLeft.SelectedIndex = 0;
            ButtonRight.SelectedIndex = 0;
            ButtonMiddle.SelectedIndex = 0;
            ClickDouble.SelectedIndex = 0;
            NoDoing.Checked = true;
        }

        private void Desctop1_Load(object sender, EventArgs e)
        {
            toolStripMenuItemChooseFile.Visible = false;
            drag = false;
            //ButtonLeft.SelectedIndex = 0;
            //ButtonRight.SelectedIndex = 0;
            //ButtonMiddle.SelectedIndex = 0;
            //ClickDouble.SelectedIndex = 0;
            rand = new Random();
            this.FormClosed -= Fitten_FormClosed;

            contextMenuStrip1 = new ContextMenuFileClass(contextMenuStrip1);
            contextMenuStrip1.Items.Add(toolStripMenuItemSave);
            (contextMenuStrip1 as ContextMenuFileClass).GetSettingsByFile += DiskForm_GetSettingsByFile;
            toolStripMenuItemDoingFile.DropDown = contextMenuStrip1;

            CreateItems(choises);

            filePath = filePath;
            if (!havePath) 
            ChangeImage();
            else
            {
                while (PanelImage.Controls.Count > 0)
                {
                    PanelImage.Controls.Clear();
                }
                try
                {
                    Folders.LoadJson(filePath);
                }
                catch
                {
                    filePath = "";
                }

                FromFolderClass(Folders);
            }
        }

        private void DiskForm_GetSettingsByFile(FileClass file)
        {
            ShowJson.Visible = file.IsImage;
            ShowDoubleCode.Visible = file.IsImage;
            toolStripMenuItemSave.Visible = file.IsImage;
            DataBaseSave.Visible = file.IsDataBase;
            buttonSaveText.Visible = file.IsText;
            SaveNote.Visible = file.IsNote;
            toolStripMenuItemChooseFile.Visible = file.Index >= 0;
            buttonSaveSity.Visible = file.IsSity;
            SaveOrganization.Visible = file.IsOrganizaion;
            buttonSaveTraidingPoint.Visible = file.IsTraidingPoint;
            SaveStore.Visible = file.IsStore;

        }

        public void CreateItems(IEnumerable<ComboBoxNameClear> comboBoxes)
        {
            foreach(ComboBoxNameClear comboBox in comboBoxes)
            {
                CreateItems(comboBox);

            }
        }

        public void CreateItems(ComboBoxNameClear comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(pounkts);
            comboBox.SelectedIndex = 0;
            comboBox.Clear();
        }

        void ToFolderClass()
        {
            for (int i = 0; i < PanelImage.Controls.Count; i++)
            {
                if (PanelImage.Controls[i] is PictureBox)
                {
                    PictureBox pictureBox = PanelImage.Controls[i] as PictureBox;
                    try
                    {
                        object tag = pictureBox.Tag;
                        if (tag is null || tag == null)
                            throw new Exception();
                        int index = Convert.ToInt32(tag);
                        ImageFile imageFile = Folders.GetImage(index);
                        try
                        {
                            imageFile.Bitmap = new Bitmap(pictureBox.Image);
                        }
                        catch
                        {
                            Bitmap bit = new Bitmap(100, 100);
                            Graphics graphics = Graphics.FromImage(bit);
                            graphics.Clear(Color.White);
                            imageFile.Image = bit;
                        }
                    }
                    catch
                    {
                        try
                        {
                            Folders.Add(new Bitmap(pictureBox.Image));
                        }
                        catch
                        {
                            Bitmap bit = new Bitmap(100, 100);
                            Graphics graphics = Graphics.FromImage(bit);
                            graphics.Clear(Color.White);
                            Folders.Add(bit);
                        }
                    }
                }
            }
            Folders.ChangeIndexNameAllFiles();
        }

        void ChangeImage()
        {
            ToFolderClass();
            FromFolderClass(Folders);
        }

        void FromFolderClass(FolderClass folder)
        {
            mayOK = false;
            for(int i = 0; i < PanelImage.Controls.Count; i++)
            {
                Control control = PanelImage.Controls[i];
                //PanelImage.Controls.Remove(control);
                control.Dispose();
            }
            PanelImage.Controls.Clear();
            folder.ChangeIndexNameAllFiles();
            if (havePath)
                folder.SaveJson(filePath);
            ImageFilesList images = folder.ImageList;
            List<TextFile> files = folder.TextList;
            Folders = folder;
            int s = 25;
            int w = s;
            int h = w;
            for(int i = 0; i < folder.Count; i++)
            {
                FileClass fileObject = folder[i];
                if (fileObject.IsImage)
                {
                    PB = new PictureBoxFile();
                }
                else if(fileObject.IsText)
                {
                    PB = new PictureBoxTextFile();
                }
                else if(fileObject.IsNote)
                {
                    PB = new PictureBoxNote();
                }
                else if (fileObject.IsDataBase)
                {
                    PB = new PictureBoxDataBaseFile();
                }
                else if (fileObject.IsSity)
                {
                    PB = new PictureBoxSity();
                }
                else if (fileObject.IsOrganizaion)
                {
                    PB = new PictureBoxOrg();
                }
                else if (fileObject.IsTraidingPoint)
                {
                    PB = new PictureBoxTraidingPoint();
                }
                else if (fileObject.IsStore)
                {
                    PB = new PictureBoxStore();
                }

                PB.Tag = folder[i].IndexText;
                PB.Left = w;
                PB.Top = h;
                PB.Size = new Size(100, 100);
                PB.BackColor = Color.Transparent;
                PB.Image = Image.Image;
                PB.SizeMode = PictureBoxSizeMode.Zoom;
                PB.MaximumSize = new Size(550, 400);
                PB.MinimumSize = new Size(40, 40);
                //bit = new Bitmap(images[i].AsImage.Bitmap);
                //PB.Image = new Bitmap(bit);

                if (fileObject.IsImage)
                {
                    PictureBoxFile file = PB as PictureBoxFile;
                    file.ImageFile = folder[i].AsImage;
                    file.ImageFile.CopyFile = folder[i];
                }
                else if (fileObject.IsText)
                {
                    PictureBoxTextFile file = PB as PictureBoxTextFile;
                    file.TextFile = folder[i].AsText;
                    file.TextFile.CopyFile = folder[i];
                }
                else if (fileObject.IsDataBase)
                {
                    PictureBoxDataBaseFile file = PB as PictureBoxDataBaseFile;
                    file.DataBaseFile = folder[i].AsDataBase;
                    file.DataBaseFile.CopyFile = folder[i];
                }
                else if (fileObject.IsNote)
                {
                    PictureBoxNote file = PB as PictureBoxNote;
                    file.NoteFile = folder[i].AsNote;
                    file.NoteFile.CopyFile = folder[i];
                }
                else if (fileObject.IsSity)
                {
                    PictureBoxSity file = PB as PictureBoxSity;
                    file.SityFile = folder[i].AsSity;
                    file.SityFile.CopyFile = folder[i];
                }
                else if (fileObject.IsOrganizaion)
                {
                    PictureBoxOrg file = PB as PictureBoxOrg;
                    file.OrganizaionFile = folder[i].AsOrganizaion;
                    file.OrganizaionFile.CopyFile = folder[i];
                }
                else if (fileObject.IsTraidingPoint)
                {
                    PictureBoxTraidingPoint file = PB as PictureBoxTraidingPoint;
                    file.TraidingPointFile = folder[i].AsTraidingPoint;
                    file.TraidingPointFile.CopyFile = folder[i];
                }
                else if (fileObject.IsStore)
                {
                    PictureBoxStore file = PB as PictureBoxStore;
                    file.StoreFile = folder[i].AsStore;
                    file.StoreFile.CopyFile = folder[i];
                }

                PB.BorderStyle = BorderStyle.Fixed3D;
                PB.Invalidate();

                PB.MouseDown += PictireFile_MouseDown;
                PB.MouseWheel += PB_MouseWheel;

                PanelImage.Controls.Add(PB);
                PB.BringToFront();
                PB.BringToFront();
                w += 135;
                if(w >= PanelImage.Width - 135)
                {
                    w = s;
                    h += 135;
                }
            }
            mayOK = true;
        }

        private void AddPicture_Click(object sender, EventArgs e)
        {
            ImageFile folder = new ImageFile();
            OpenFiles.Filter = folder.AllTypesFile;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImageFile image = ImageFile.Load(OpenFiles.FileName);
                    
                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PB_MouseWheel(object sender, MouseEventArgs e)
        {
            PictureBox Pix = sender as PictureBox;
            int increment = (int)(SizeIncrement.Value / 2);
            int increment1 = increment / 2;
            Pix.BringToFront();
            if (SizeImageChange.Checked)
            {
                
                if (e.Delta > 0)
                {
                    Pix.Width += increment;
                    Pix.Left -= increment1;
                    Pix.Height += increment;
                    Pix.Top -= increment1;
                }
                if (e.Delta < 0)
                {
                    Pix.Width -= increment;
                    Pix.Left += increment1;
                    Pix.Height -= increment;
                    Pix.Top += increment1;
                }
            }
        }

        

        private void Desctop1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                HelperSettings.Folder = Folders;
            }
            catch
            {

            }

            if (YesChoose)
                return;
            string ExitText = "";
            try
            {
                ExitText = (string)ButClose.Tag;
            }
            catch (System.NullReferenceException)
            {
                if (File.Exists("Desctop.txt"))
                {
                    File.Delete("Desctop.txt");
                }
                ExitText = "change";
            }

            


            if (ExitText == "change")
            {
                if (File.Exists("Desctop.txt"))
                {
                    File.Delete("Desctop.txt");
                }
                e.Cancel = false;
            }
            else
            if (ExitText == "choose")
            {
                if (Image.Image != null)
                {
                    Bitmap BitPix = (Bitmap)Image.Image;
                start: try
                    {
                        if (File.Exists("Image.jpg"))
                        {
                            File.Delete("Image.jpg");
                        }
                        BitPix.Save("Image.jpg");
                        if (File.Exists("Pazle.txt"))
                        {
                            File.Delete("Pazle.txt");
                        }
                    }
                    catch (System.IO.IOException)
                    {
                        goto start;
                    }
                }
                StreamWriter writer = new StreamWriter("Desctop.txt");
                writer.Close();
                e.Cancel = true;
                this.Hide();
                //PermamentForm form = (PermamentForm)Application.OpenForms[0];

                try
                {
                    Form form = MainForm;
                    form.Show();
                }
                catch(Exception ex)
                {

                }

            }
            else
            if(ExitText == "NoChoose")
            {
                StreamWriter writer = new StreamWriter("Desctop.txt");
                writer.Close();
                e.Cancel = true;
                this.Hide();
                //PermamentForm form = (PermamentForm)Application.OpenForms[0];
                try
                {
                    Form form = MainForm;
                    form.Show();
                }
                catch(Exception ex)
                {

                }
            }
            else
            {
                if (File.Exists("Desctop.txt"))
                {
                    File.Delete("Desctop.txt");
                }
                try
                {
                    try
                    {
                        Form form = MainForm;
                        form.Hide();
                        form.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch(Exception ex)
                {

                }
            }
        }



        private void Exit_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit.Visible = false;
            //exit.Hide();
            //exit.FormClosed -= Exit_FormClosed;
            //exit.Close();

            if (!File.Exists("Exit.txt"))
            {

                this.Show();
            }
            else
            {
                StreamReader reader = new StreamReader("Exit.txt");
                CloseFile = reader.ReadLine();
                reader.Close();
                this.Close();
            }
        }

        private void Exit_Load(object sender, EventArgs e)
        {
            if (File.Exists("Exit.txt"))
            {
                File.Delete("Exit.txt");
            }
        }

        private void Fitten_FormClosed(object sender, FormClosedEventArgs e)
        {

            //PermamentForm form = (PermamentForm)Application.OpenForms[0];
            try
            {
                Form form = MainForm;
                form.Hide();
                form.Close();
            }
            catch(Exception ex)
            {

            }
        }


        private void ClearAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                
                ButClose = (sender as ToolStripMenuItem);
                string tag = Convert.ToString(ButClose.Tag).ToLower();
                if (tag == "choose" || tag.Equals("choose"))
                {
                    
                    yesChoose = true;
                    FewFile.FromFile(file1);
                }
            }
            catch
            {

            }
            this.Close();

        }

        public bool Choosen
        {
            get => yesChoose;
            set => yesChoose = value;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                file1.FileName = (sender as TextBox).Text;
            }
            catch
            {

            }
        }

        private void SaveImage_Click(object sender, EventArgs e)
        {
            //SaveFileDialog SaveFile = new SaveFileDialog();
            Bitmap bmpDrawing;
            Rectangle rectBounds;
            SaveFile.Filter = new ImageFile().TypesFileContentWithTxt;
            SaveFile.FileName = textBoxFileName.Text + ".jpg";
            SaveFile.FilterIndex = 1;
            if (SaveFile.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                // Create bitmap for paint storage
                bmpDrawing = new Bitmap(Image.Image);

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

        private void SaveJson_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFile image = file1.AsImage;
                string[] line = image.Name.Split('/', '\\');
                SaveJsonImage.FileName = line[line.Length - 1];

                SaveJsonImage.Filter = image.TypesFileJsonWithTxt;
                DialogResult result = SaveJsonImage.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                image.SaveJson(SaveJsonImage.FileName);
                MessageBox.Show("Изображение успешно сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неудалось сохранить изображение");
            }
        }

        private void SaveFolder_Click(object sender, EventArgs e)
        {
            try
            {
                
                FolderClass image = Folders.AsFolder;
                string[] line = image.Name.Split('/', '\\');
                FolderSave.FileName = line[line.Length - 1];
                FolderSave.Filter = image.TypesFileJsonWithTxt;
                DialogResult result = FolderSave.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                image.Copy().SaveJson(FolderSave.FileName);
                MessageBox.Show("Каталог успешно сохранён");
                path = FolderSave.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неудалось сохранить каталог");
            }
        }

        private void FolderChange_Click(object sender, EventArgs e)
        {
            FolderClass folder = new FolderClass();
            OpenFolder.Filter = folder.TypesFileJsonWithTxt;
            if (OpenFolder.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Folders.LoadJson(OpenFolder.FileName);

                    FromFolderClass(Folders);
                    path = OpenFolder.FileName;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveSmallJson_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFile image1 = file1.AsImage;
                ImageFileJson image = new ImageFileJson(image1);
                string[] line = image.FileName.Split('/', '\\');
                SaveJsonImage.FileName = line[line.Length - 1];

                SaveJsonImage.Filter = image.TypesFileJsonWithTxt;
                DialogResult result = SaveJsonImage.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                image.SaveJson(SaveJsonImage.FileName);
                MessageBox.Show("Изображение успешно сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неудалось сохранить изображение");
            }
        }

        private void SaveBynaryJson_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFile image1 = file1.AsImage;
                BynaryImageFileJson image = new BynaryImageFileJson(image1);
                string[] line = image.FileName.Split('/', '\\');
                SaveJsonImage.FileName = line[line.Length - 1];

                SaveJsonImage.Filter = image.TypesFileJsonWithTxt;
                DialogResult result = SaveJsonImage.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                image.SaveJson(SaveJsonImage.FileName);
                MessageBox.Show("Изображение успешно сохранено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неудалось сохранить изображение");
            }
        }

        private void ToBynaryJson_Click(object sender, EventArgs e)
        {
            SaveBynaryJson_Click(sender, e);
        }

        private void TextJsonSave_Click(object sender, EventArgs e)
        {
            ImageFile image1 = file1.AsImage;
            string json = JsonSerializer.Serialize(image1);
            string jsonText = "jsonText.txt";
            File.WriteAllText(jsonText, json);
            Process process = new Process();
            process.StartInfo.FileName = jsonText;
            process.Start();
        }

        private void textBoxIndexFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                AbstractFileClass fileClass = file1;
                if (fileClass == null || fileClass is null)
                    throw new Exception();
                if (AbstractFileClass.Symwols.Contains(e.KeyChar))
                    throw new Exception();
            }
            catch
            {
                e.Handled = true;
            }
        }

        private void MenuItemProperty_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(ContextMenuFileClass.File.PropertyOfCopyFile);
            }
            catch (Exception ex)
            {

            }
        }



        private void toolStripMenuItemDoingFile_Click(object sender, EventArgs e)
        {
            try
            {
                ContextMenuFileClass.File = file1;
            }
            catch
            {

            }
        }

        private void buttonIndexNameOK_Click(object sender, EventArgs e)
        {
            try
            {
                string name1 = file1.IndexFileName;
                string name2 = textBoxFileName.Text;
                if (name1 == name2 || name1.Equals(name2) || name2.Equals(name1))
                    return;

                file1.IndexFileName = textBoxIndexFileName.Text;
                file1.FileName = textBoxFileName.Text;
                int index = file1.CopyFile.AsFileClass.TemporaryIndex;
                Folders[index] = file1.AsFileClass.Copy();
                if (havePath && mayOK)
                    Folders.SaveJson(filePath);
                Folders.ChangeIndexName(file1);
                textBoxFileName.Text = file1.FileName;
                textBoxIndexFileName.Text = file1.IndexFileName;
                if (file1.IsImage)
                    Image.Image = file1.AsImage.Image;
            }
            catch(Exception ex)
            {

            }
        }

        private void textBoxIndexFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonIndexNameOK_Click(sender, e);
            }
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            bool yesChoose1 = false;
            ref bool yesChoose = ref yesChoose1;
            using (DiskForm disk = new DiskForm(file1, ref yesChoose))
            {

                Hide();
                disk.ShowDialog();
                Show();
                textBoxIndexFileName.Text = file1.IndexFileName;
                int index = file1.Index;
                yesChoose = disk.YesChoose;
                if (yesChoose)
                {
                    //buttonIndexNameOK_Click(sender, e);


                    Folders[index] = file1;
                }
                FromFolderClass(Folders);

                SetCheckFile(file1);

                disk.Dispose();
            };
        }

        private void toolStripMenuItemCopyFile_Click(object sender, EventArgs e)
        {
            try
            {
                FileClass file = ContextMenuFileClass.File.AsFileClass.Copy();
                Folders.Add(file);
                FromFolderClass(Folders);
            }
            catch
            {

            }
        }

        private void toolStripMenuItemChooseFile_Click(object sender, EventArgs e)
        {
            
            try
            {
                FileClass file = ContextMenuFileClass.File.AsFileClass;
                PictureBox pictureBox = file.PictureBox;
                e = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                    PictireFile_MouseDown(pictureBox, e as MouseEventArgs);

            }
            catch
            {
                
            }

        }

        private void ShowJson_Click(object sender, EventArgs e)
        {
            string text = ContextMenuFileClass.File.AsFileClass.GetMemoryJson(true);
            int length = Math.Min(4250, text.Length);
            MessageBox.Show(text.Substring(0, length));

            string json = ContextMenuFileClass.File.AsFileClass.GetJson();
            int length1 = Math.Min(4250, json.Length);
            MessageBox.Show(json.Substring(0, length1));


            ImageFile image = new ImageFile();
            image.LoadJson(text, true);
            //image.CopyFile = ContextMenuFileClass.File.CopyFile;
            ImageForm form = new ImageForm(image);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void toolStripMenuItemOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                AbstractFileClass file = ContextMenuFileClass.File;
                if (file.IsFileClass)
                {
                    FileClass checkFile = file.AsFileClass;
                    if (checkFile.IsImage)
                    {
                        ImageForm image = new ImageForm(checkFile.AsImage);
                        Hide();
                        image.ShowDialog();
                        Show();
                    }
                    if (checkFile.IsText)
                    {
                        TextForm text = new TextForm(checkFile.AsText.Text);
                        Hide();
                        text.ShowDialog();
                        int index = checkFile.TemporaryIndex;
                        if (text.Save)
                        {
                            try
                            {
                                Folders[index].AsText.Text = text.EditText.Text;
                            }
                            catch
                            {

                            }
                            checkFile.AsText.Text = text.EditText.Text;
                        }
                        Show();

                        //FromFolderClass(Folders);
                    }
                    if (checkFile.IsDataBase)
                    {
                        ConnectionEditForm text = new ConnectionEditForm(checkFile.AsDataBase.DataBase);
                        Hide();
                        text.ShowDialog();
                        int index = checkFile.TemporaryIndex;
                        //if (text.Save)
                        //{
                        try
                        {
                            Folders[index].AsDataBase.DataBase = text.ConnectionDataBase.CopyWithFull();
                        }
                        catch
                        {

                        }
                        checkFile.AsDataBase.DataBase = text.ConnectionDataBase.CopyWithFull();
                        //}
                        Show();

                        //FromFolderClass(Folders);
                    }
                    if(checkFile.IsNote)
                    {
                        NoteFile note = checkFile.AsNote;
                        FormNoteEdit form = new FormNoteEdit(note);
                        Hide();

                        form.ShowDialog();
                        if(form.Save)
                        {
                            note.Content = form.Note.CopyNote();
                            int index = checkFile.TemporaryIndex;
                            try
                            {
                                Folders[index].AsNote.Content = note.Content.CopyNote();
                            }
                            catch(Exception ex)
                            {

                            }
                        }

                        Show();
                    }

                    if (checkFile.IsSity)
                    {
                        SityFile note = checkFile.AsSity;
                        SityEditForm form = new SityEditForm(note.Content.Name);
                        Hide();

                        form.ShowDialog();
                        if (form.Save)
                        {
                            note.Content.Name = form.Value;
                            int index = checkFile.TemporaryIndex;
                            try
                            {
                                Folders[index].AsSity.Content = note.Content.CopySity();
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        Show();
                    }

                    if (checkFile.IsOrganizaion)
                    {
                        OrganizaionFile note = checkFile.AsOrganizaion;
                        OrganizationEditForm form = new OrganizationEditForm(note.Content);
                        form.ChangeOrganization += (organization) =>
                        {
                            
                            int index = checkFile.TemporaryIndex;
                            try
                            {
                                note.Content = organization.CopyOrganization();
                                Folders[index].AsOrganizaion.Content = note.Content.CopyOrganization();
                            }
                            catch (Exception ex)
                            {

                            }
                        };
                        Hide();

                        form.ShowDialog();
                        
                        Show();
                    }

                    if (checkFile.IsTraidingPoint)
                    {
                        TraidingPointFile note = checkFile.AsTraidingPoint;
                        TraidingPointEditForm form = new TraidingPointEditForm(note.Content);
                        form.ChangeOrganization += (organization) =>
                        {

                            int index = checkFile.TemporaryIndex;
                            try
                            {
                                note.Content = organization.CopyTraidingPoint();
                                Folders[index].AsTraidingPoint.Content = note.Content.CopyTraidingPoint();
                            }
                            catch (Exception ex)
                            {

                            }
                        };
                        Hide();

                        form.ShowDialog();

                        Show();
                    }

                    if (checkFile.IsStore)
                    {
                        StoreFile note = checkFile.AsStore;
                        StorePointEditForm form = new StorePointEditForm(note.Content);
                        form.ChangeOrganization += (organization) =>
                        {

                            int index = checkFile.TemporaryIndex;
                            try
                            {
                                note.Content = organization.CopyStore();
                                Folders[index].AsStore.Content = note.Content.CopyStore();
                            }
                            catch (Exception ex)
                            {

                            }
                        };
                        Hide();

                        form.ShowDialog();

                        Show();
                    }

                    FromFolderClass(Folders);
                    SetCheckFile(checkFile);

                }

            }
            catch
            {

            }
        }



        private void CreateLink_Click(object sender, EventArgs e)
        {
            SaveFolder_Click(sender, e);
            if (haveCachPath)
                filePath = path;
        }

        private void OpenLinkCatalog_Click(object sender, EventArgs e)
        {
            FolderChange_Click(sender, e);
            if (haveCachPath)
                filePath = path;
        }

        private void CloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowDoubleCode_Click(object sender, EventArgs e)
        {
            try
            {
                ImageFile image1 = file1.AsImage;
                BynaryImageFileJson image = new BynaryImageFileJson(image1);
                string code = image.PhotoText;
                CodeForm codeForm = new CodeForm(code);
                Hide();
                codeForm.ShowDialog();
                Show();
            }
            catch
            {
                AbstractFileClass file = ContextMenuFileClass.File;
                if (file.IsFileClass)
                {
                    FileClass checkFile = file.AsFileClass;
                    if (checkFile.IsImage)
                    {
                        ImageForm image1 = new ImageForm(checkFile.AsImage);
                        BynaryImageFileJson image = new BynaryImageFileJson(checkFile.AsImage);
                        string code = image.PhotoText;
                        CodeForm codeForm = new CodeForm(code);
                        Hide();
                        codeForm.ShowDialog();
                        Show();
                    }
                }
            }
        }

        private void buttonCreateText_Click(object sender, EventArgs e)
        {
            Folders.Add(new TextFile());
            Folders.ChangeIndexName();
            FromFolderClass(Folders);
        }

        private void buttonSaveText_Click(object sender, EventArgs e)
        {

        }

        private void saveByText_Click(object sender, EventArgs e)
        {
            TextFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsText;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileContentWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        File.WriteAllText(saveFile.FileName, textFile.Text);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonLoadtextFromFile_Click(object sender, EventArgs e)
        {
            TextFile folder = new TextFile();
            OpenFiles.Filter = folder.AllTypesFile;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TextFile image = TextFile.Load(OpenFiles.FileName);
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadContentFile_Click(object sender, EventArgs e)
        {
            TextFile folder = new TextFile();
            OpenFiles.Filter = "All Files (*.*)|*.*";

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TextFile image = new TextFile
                    {
                        Name = OpenFiles.FileName,
                        Text = File.ReadAllText(OpenFiles.FileName)
                    };
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            FromFolderClass(Folders);
        }

        private void DataBaseCreate_Click(object sender, EventArgs e)
        {
            Folders.Add(new DataBaseFile());
            FromFolderClass(Folders);

        }

        private void SaveDataBase_Click(object sender, EventArgs e)
        {
            DataBaseFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsDataBase;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileContentWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.DataBase.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveDataBaseJson_Click(object sender, EventArgs e)
        {
            DataBaseFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsDataBase;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение строки подключения к базе данных";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileJsonWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataBaseLoad_Click(object sender, EventArgs e)
        {
            DataBaseFile folder = new DataBaseFile();
            OpenFiles.Filter = folder.AllTypesFile;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataBaseFile image = DataBaseFile.Load(OpenFiles.FileName);
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        ToolTip tool = new ToolTip();
        private void textInputEditName_TextInputChanged(object sender, Control senderControl, TextBox controlInput, object senderInput, TextInputEdit textInputContol, EventArgs e, string text)
        {
            
            tool.SetToolTip(senderControl, text);
            tool.SetToolTip(controlInput, text);

        }

        private void comboBoxLeft_Clearing(object sender, Control senderControl, ComboBox controlInput, object senderInput, ComboBoxNameClear textInputContol, EventArgs e, int selectedIndex, string text, ref int selectedIndexChanging)
        {
            selectedIndexChanging = 0;
        }

        private void buttonClearFolder_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Вы действительно хотите очистить весь каталог",
                "Очистка каталога", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.No)
                return;

            Folders.Clear();
            FromFolderClass(Folders);
        }

        private void buttonDropFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить файл?", "Удаление файла", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(dialog == DialogResult.No)
                {
                    return;
                }

                AbstractFileClass file = ContextMenuFileClass.File;


                if (file.IsFileClass)
                {
                    FileClass checkFile = file.AsFileClass;
                    int index = checkFile.CopyFile.AsFileClass.Index;


                    try
                    {
                        int index1 = file1.TemporaryIndex;
                        if (index == index1)
                        {

                            file1.TemporaryIndex = -1;
                            file1 = file1.Copy();
                            file1.CopyFile = file1;
                            textBoxFileName.Text = file1.FileName;
                            textBoxIndexFileName.Text = file1.IndexFileName;
                            labelIndex.Text = file1.IndexText;
                        }
                    }
                    catch
                    {

                    }
                    //ImageClear_Click(sender, e);

                    Folders.RemoveAt(index);
                }

                FromFolderClass(Folders);
            }
            catch(Exception ex)
            {

            }
        }

        private void buttonNameChange_Click(object sender, EventArgs e)
        {
            try
            {
                FileClass checkFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass;

                FormNoteEdit form = new FormNoteEdit(checkFile.Name);
                Hide();
                form.ShowDialog();
                if(form.Save)
                {
                    int index = checkFile.TemporaryIndex;
                    if (form.Save)
                    {
                        try
                        {
                            Folders[index].Name = form.Value;
                        }
                        catch
                        {

                        }
                        checkFile.Name = form.Value;
                    }
                }

                Show();
                FromFolderClass(Folders);

                SetCheckFile(checkFile);
            }
            catch
            {

            }


        }


        void SetCheckFile(FileClass fileCheck)
        {
            try
            {
                if (fileCheck.TemporaryIndex == file1.TemporaryIndex)
                {
                    PictureBox check = fileCheck.PictureBox;
                    try
                    {
                        string name = check.Name;
                        PictireFile_MouseDown(check, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));

                        return;
                    }
                    catch
                    {

                    }


                    Bitmap BitPix = fileCheck.ImageView;
                    Image.Image = BitPix;
                    int index = fileCheck.TemporaryIndex;
                    FileClass file = fileCheck.CopyFile.AsFileClass;
                    //file.CopyFile = Pix.ImageFile;
                    labelIndex.Text = file.IndexText;
                    try
                    {
                        file1.Dispose();
                    }
                    catch
                    {

                    }
                    file1 = file.Copy();
                    file1.PictureBox = file.PictureBox;
                    file1.CopyFile = file;
                    textBoxFileName.Text = file.FileName;
                    textBoxIndexFileName.Text = file.IndexFileName;
                    ContextMenuFileClass.File = file;
                }
            }
            catch
            {

            }
        }


        private void buttonRenameChange_Click(object sender, EventArgs e)
        {
            try
            {
                FileClass checkFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass;

                FormNoteEdit form = new FormNoteEdit(checkFile.IndexFileName);
                Hide();
                form.ShowDialog();
                if (form.Save)
                {
                    int index = checkFile.TemporaryIndex;
                    if (form.Save)
                    {
                        try
                        {
                            Folders[index].IndexFileName = form.Value;
                        }
                        catch
                        {

                        }
                        checkFile.IndexFileName = form.Value;
                    }
                }

                Show();
                FromFolderClass(Folders);

                SetCheckFile(checkFile);
            }
            catch
            {

            }
        }

        private void buttonNoteCreate_Click(object sender, EventArgs e)
        {
            Folders.Add(new NoteFile());
            FromFolderClass(Folders);
        }

        private void SavetextByJson_Click(object sender, EventArgs e)
        {
            TextFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsText;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileJsonWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNoteFromFile_Click(object sender, EventArgs e)
        {
            NoteFile folder = new NoteFile();
            OpenFiles.Filter = folder.AllTypesFile;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    NoteFile image = NoteFile.Load(OpenFiles.FileName);
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveNoteContent_Click(object sender, EventArgs e)
        {
            NoteFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsNote;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileContentWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.Content.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveNoteJson_Click(object sender, EventArgs e)
        {
            NoteFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsNote;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileJsonWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSityCreate_Click(object sender, EventArgs e)
        {
            Folders.Add(new SityFile());
            FromFolderClass(Folders);
        }

        private void buttonSityLoad_Click(object sender, EventArgs e)
        {
            SityFile folder = new SityFile();
            OpenFiles.Filter = folder.AllTypesFile;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SityFile image = SityFile.Load(OpenFiles.FileName);
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSityContentFromJson_Click(object sender, EventArgs e)
        {
            SityFile folder = new SityFile();
            OpenFiles.Filter = folder.TypesFileContentWithTxt;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SityFile image = new SityFile
                    {
                        Name = OpenFiles.FileName,
                        Content = (Town)SityFile.JsonRead(OpenFiles.FileName, typeof(Town))
                    };
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveSityContent_Click(object sender, EventArgs e)
        {
            SityFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsSity;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileContentWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.Content.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveSityJson_Click(object sender, EventArgs e)
        {
            SityFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsSity;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileJsonWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OrganizationCreate_Click(object sender, EventArgs e)
        {
            Folders.Add(new OrganizaionFile());
            folderButonUpdate.UpdateContent();
        }

        private void folderButonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void LoadOrganizationFile_Click(object sender, EventArgs e)
        {
            OrganizaionFile folder = new OrganizaionFile();
            OpenFiles.Filter = folder.AllTypesFile;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OrganizaionFile image = OrganizaionFile.Load(OpenFiles.FileName);
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadOrgContent_Click(object sender, EventArgs e)
        {
            OrganizaionFile folder = new OrganizaionFile();
            OpenFiles.Filter = folder.TypesFileContentWithTxt;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OrganizaionFile image = new OrganizaionFile
                    {
                        Name = OpenFiles.FileName,
                        Content = (DisributingFacilities)SityFile.JsonRead(OpenFiles.FileName, typeof(DisributingFacilities))
                    };
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveOrgContent_Click(object sender, EventArgs e)
        {
            OrganizaionFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsOrganizaion;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileContentWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.Content.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveOrgJson_Click(object sender, EventArgs e)
        {
            OrganizaionFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsOrganizaion;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileJsonWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NoteLoadContent_Click(object sender, EventArgs e)
        {
            NoteFile folder = new NoteFile();
            OpenFiles.Filter = folder.TypesFileContentWithTxt;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    NoteFile image = new NoteFile
                    {
                        Name = OpenFiles.FileName,
                        Content = (NoteClass)FileClass.JsonRead(OpenFiles.FileName, typeof(NoteClass))
                    };
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TraidingPointCreae_Click(object sender, EventArgs e)
        {
            Folders.Add(new TraidingPointFile());
            folderButonUpdate.UpdateContent();
        }

        private void LoadDataBaseContent_Click(object sender, EventArgs e)
        {
            DataBaseFile folder = new DataBaseFile();
            OpenFiles.Filter = folder.TypesFileContentWithTxt;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataBaseFile image = new DataBaseFile
                    {
                        Name = OpenFiles.FileName,
                        DataBase = (ConnectionDataBase)FileClass.JsonRead(OpenFiles.FileName, typeof(ConnectionDataBase))
                    };
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TraidingPointJsonLoad_Click(object sender, EventArgs e)
        {
            FileClass folder = new TraidingPointFile();
            OpenFiles.Filter = folder.AllTypesFile;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TraidingPointFile image = TraidingPointFile.Load(OpenFiles.FileName);
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TraidingPointContentLoad_Click(object sender, EventArgs e)
        {
            FileClass folder = new TraidingPointFile();
            OpenFiles.Filter = folder.TypesFileContentWithTxt;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TraidingPointFile image = new TraidingPointFile
                    {
                        Name = OpenFiles.FileName,
                        Content = (DistributingPoint)FileClass.JsonRead(OpenFiles.FileName, typeof(DistributingPoint))
                    };
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveTraidingPointContent_Click(object sender, EventArgs e)
        {
            TraidingPointFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsTraidingPoint;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileContentWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.Content.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveTraidingPointJson_Click(object sender, EventArgs e)
        {
            FileClass textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsTraidingPoint;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение текста";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileJsonWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonStoreLoadContent_Click(object sender, EventArgs e)
        {
            FileClass folder = new StoreFile();
            OpenFiles.Filter = folder.TypesFileContentWithTxt;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StoreFile image = new StoreFile
                    {
                        Name = OpenFiles.FileName,
                        Content = (Store)FileClass.JsonRead(OpenFiles.FileName, typeof(Store))
                    };
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonStoreLoadFile_Click(object sender, EventArgs e)
        {
            FileClass folder = new StoreFile();
            OpenFiles.Filter = folder.AllTypesFile;

            if (OpenFiles.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StoreFile image = StoreFile.Load(OpenFiles.FileName);
                    if (image is null || image == null)
                        throw new Exception();

                    Folders.Add(image);
                    FromFolderClass(Folders);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Уважаемый пользователь \n" +
                        "Невозможно открыть выбранный вами файл \n" +
                        "Пожалуйста, выберите другой файл и повторите попытку \n" +
                        "С уважением, Создатель программы, Сидоров Антон Дмитриевич",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonStoreCreate_Click(object sender, EventArgs e)
        {
            Folders.Add(new StoreFile());
            folderButonUpdate.UpdateContent();
        }

        private void buttonSaveStoreContent_Click(object sender, EventArgs e)
        {
            StoreFile textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsStore;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение торговой точки";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileContentWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.Content.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveStoreJson_Click(object sender, EventArgs e)
        {
            FileClass textFile = (contextMenuStrip1 as ContextMenuFileClass).File.AsFileClass.AsStore;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Сохранение торговой точки";
            saveFile.FileName = textFile.Name;
            saveFile.Filter = textFile.TypesFileJsonWithTxt;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    try
                    {
                        textFile.SaveJson(saveFile.FileName);

                        MessageBox.Show("Файл успешно сохранён", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //writer.Close();
                        throw ex;

                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить файл", saveFile.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DropLink_Click(object sender, EventArgs e)
        {
            filePath = "";
        }

        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            TextTime.Text = $"{TimeFormat(dt.Hour)}" + $"{TimeFormat(dt.Minute)}" + $"{TimeFormat(dt.Second)}";
            TextDate.Text = $"{DateFormat(dt.Date.Day, 2)}" + $"{DateFormat(dt.Date.Month, 2)}" + $"{DateFormat(dt.Date.Year, 4)}";


            if (File.Exists("User.txt"))
            {
                StreamReader reader = new StreamReader("User.txt");
                UserName.Text = reader.ReadLine();
                reader.Close();
            }
            else
            {
                UserName.Text = "неизвестный пользователь";
            }


        }
    }
}
