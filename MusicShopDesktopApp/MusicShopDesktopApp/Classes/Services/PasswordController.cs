using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShopDesktopApp
{
    /// <summary>
    /// Контроллер для ввода пароля
    /// </summary>
    public class PasswordController
    {
        Func<bool> loadEdit = True;

        /// <summary>
        /// Событие запуска окна редактирования пароля
        /// </summary>
        public Func<bool> LoadEdit
        {
            get => loadEdit;
            set => loadEdit = value;
        }

        Func<bool> beforeInput = False;

        /// <summary>
        /// Событие перед началом ввода пароля
        /// </summary>
        public Func<bool> BeforeInput
        {
            get => beforeInput;
            set => beforeInput = value;
        }

        Func<Secret, bool> checkPassword = True;

        /// <summary>
        /// Проверка пароля
        /// </summary>
        public Func<Secret, bool> CheckPassword
        {
            get => checkPassword;
            set => checkPassword = value;
        }

        Func<Secret, bool> checkPasswordStart = True;

        /// <summary>
        /// Начало проверки пароля
        /// </summary>
        public Func<Secret, bool> CheckPasswordStart
        {
            get => checkPasswordStart;
            set => checkPasswordStart = value;
        }

        Action<Secret> afterEnteringCorrect;

        /// <summary>
        /// Событие после ввода правильного пароля
        /// </summary>
        public Action<Secret> AfterEnteringCorrect
        {
            get => afterEnteringCorrect;
            set => afterEnteringCorrect = value;
        }

        public static bool True() => true;
        public static bool False() => false;
        public static bool True(Secret password) => true;
    }
}
