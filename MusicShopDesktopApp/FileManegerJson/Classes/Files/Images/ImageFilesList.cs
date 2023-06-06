using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManegerJson
{
    public class ImageFilesList : List<FileClass>
    {
        public ImageFilesList():base()
        {

        }

        public new FileClass Add(FileClass fileClass)
        {
            base.Add(fileClass);
            int count = Count;
            int last = count - 1;
            FileClass file = this[last];
            file.SetAbstractFile(fileClass);
            return file;
        }

        public ImageFilesList(IEnumerable<FileClass> attachments, bool change = true):this()
        {
            List<FileClass> attachments1 = new List<FileClass>(attachments);
            for (int i = 0; i < attachments1.Count; i++)
            {
                if (change)
                    Add(attachments1[i].ToImageWithAttachment());
                else
                    Add(attachments1[i].AsImage);
                
            }
        }

        public ImageFilesList(ImageFile[] imageFiles):this()
        {
            ImageFilesArray = imageFiles;
        }

        public ImageFilesList(IEnumerable<ImageFileJson> images) :this()
        {
            List<ImageFileJson> images1 = new List<ImageFileJson>(images);
            FileJsons = images1.ToArray();
        }

        public List<ImageFile> ToImageList()
        {
            List<ImageFile> fileClasses = new List<ImageFile>();
            for(int i = 0; i < Count; i++)
            {
                fileClasses.Add(this[i].AsImage);
            }
            return fileClasses;
        }

        public List<ImageFile> ImageFiles
        {
            get => ToImageList();
            set
            {
                Clear();
                AddRange(value);
            }
        }

        public ImageFile[] ImageFilesArray
        {
            get => ImageFiles.ToArray();
            set =>ImageFiles = new List<ImageFile>(value);
        }

        public ImageFileJson[] FileJsons
        {
            get
            {
                ImageFileJson[] images = new ImageFileJson[Count];
                for(int i = 0; i < Count; i++)
                {
                    images[i] = new ImageFileJson(ImageFilesArray[i].AsImage);
                }
                return images;
            }
            set
            {
                ImageFileJson[] images1 = value;
                ImageFile[] images = new ImageFile[images1.Length];
                for(int i = 0; i<images.Length; i++)
                {
                    images[i] = new ImageFile(images1[i]);
                }
                ImageFilesArray = images;
            }
        }
    }
}
