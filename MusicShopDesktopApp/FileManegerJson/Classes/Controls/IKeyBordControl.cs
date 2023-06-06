using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManegerJson
{
    /// <summary>
    /// Базовый интерфейс, реализующие классы, которые предоставляют возможность пользоваться виртуальной клавиатурой.
    /// Реализует интерфейсы KeyBordControl, ITextValueControl, ITagStringControl
    /// </summary>
    public interface IKeyBordControlView : ITextValueControlView, KeyBordControlView
    {
        
        bool VirtualKeyBord { get; set; }


        KeyBordEditForm KeyBordForm { get; set; }

        bool HaveKeyBord { get; set; }

    }
}
