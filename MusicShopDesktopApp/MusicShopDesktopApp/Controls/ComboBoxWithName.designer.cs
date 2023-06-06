
namespace MusicShopDesktopApp
{
    partial class ComboBoxWithName
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxTitle = new System.Windows.Forms.GroupBox();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.comboBoxValues = new System.Windows.Forms.ComboBox();
            this.groupBoxTitle.SuspendLayout();
            this.panelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTitle
            // 
            this.groupBoxTitle.Controls.Add(this.comboBoxValues);
            this.groupBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTitle.Name = "groupBoxTitle";
            this.groupBoxTitle.Size = new System.Drawing.Size(277, 68);
            this.groupBoxTitle.TabIndex = 0;
            this.groupBoxTitle.TabStop = false;
            this.groupBoxTitle.Text = "groupBox1";
            // 
            // panelBorder
            // 
            this.panelBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBorder.Controls.Add(this.groupBoxTitle);
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(281, 72);
            this.panelBorder.TabIndex = 1;
            // 
            // comboBoxValues
            // 
            this.comboBoxValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxValues.FormattingEnabled = true;
            this.comboBoxValues.Location = new System.Drawing.Point(3, 18);
            this.comboBoxValues.Name = "comboBoxValues";
            this.comboBoxValues.Size = new System.Drawing.Size(271, 24);
            this.comboBoxValues.TabIndex = 0;
            // 
            // ComboBoxWithName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBorder);
            this.Name = "ComboBoxWithName";
            this.Size = new System.Drawing.Size(281, 72);
            this.Load += new System.EventHandler(this.ComboBoxWithName_Load);
            this.groupBoxTitle.ResumeLayout(false);
            this.panelBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTitle;
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.ComboBox comboBoxValues;
    }
}
