
namespace FileManegerJson
{
    partial class ComboBoxNameClear
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
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupBoxTitle = new System.Windows.Forms.GroupBox();
            this.panelInternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelPole = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxValue = new System.Windows.Forms.ComboBox();
            this.panelMiddle.SuspendLayout();
            this.groupBoxTitle.SuspendLayout();
            this.panelInternal.SuspendLayout();
            this.tableLayoutPanelPole.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.BackColor = System.Drawing.Color.Transparent;
            this.panelMiddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMiddle.Controls.Add(this.groupBoxTitle);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 0);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(235, 78);
            this.panelMiddle.TabIndex = 0;
            // 
            // groupBoxTitle
            // 
            this.groupBoxTitle.Controls.Add(this.panelInternal);
            this.groupBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTitle.Name = "groupBoxTitle";
            this.groupBoxTitle.Size = new System.Drawing.Size(231, 74);
            this.groupBoxTitle.TabIndex = 0;
            this.groupBoxTitle.TabStop = false;
            this.groupBoxTitle.Text = "Заголовок";
            // 
            // panelInternal
            // 
            this.panelInternal.Controls.Add(this.tableLayoutPanelPole);
            this.panelInternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInternal.Location = new System.Drawing.Point(3, 18);
            this.panelInternal.Name = "panelInternal";
            this.panelInternal.Size = new System.Drawing.Size(225, 53);
            this.panelInternal.TabIndex = 0;
            // 
            // tableLayoutPanelPole
            // 
            this.tableLayoutPanelPole.ColumnCount = 2;
            this.tableLayoutPanelPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPole.Controls.Add(this.buttonClear, 1, 0);
            this.tableLayoutPanelPole.Controls.Add(this.comboBoxValue, 0, 0);
            this.tableLayoutPanelPole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPole.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPole.Name = "tableLayoutPanelPole";
            this.tableLayoutPanelPole.RowCount = 2;
            this.tableLayoutPanelPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPole.Size = new System.Drawing.Size(225, 53);
            this.tableLayoutPanelPole.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Location = new System.Drawing.Point(180, 5);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(5);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(40, 40);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.VisibleChanged += new System.EventHandler(this.buttonClear_VisibleChanged);
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxValue
            // 
            this.comboBoxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxValue.FormattingEnabled = true;
            this.comboBoxValue.Location = new System.Drawing.Point(3, 3);
            this.comboBoxValue.Name = "comboBoxValue";
            this.comboBoxValue.Size = new System.Drawing.Size(169, 24);
            this.comboBoxValue.TabIndex = 2;
            this.comboBoxValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxValue_SelectedIndexChanged);
            // 
            // ComboBoxNameClear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMiddle);
            this.Name = "ComboBoxNameClear";
            this.Size = new System.Drawing.Size(235, 78);
            this.Load += new System.EventHandler(this.ComboBoxnameClear_Load);
            this.panelMiddle.ResumeLayout(false);
            this.groupBoxTitle.ResumeLayout(false);
            this.panelInternal.ResumeLayout(false);
            this.tableLayoutPanelPole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.GroupBox groupBoxTitle;
        private System.Windows.Forms.Panel panelInternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPole;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ComboBox comboBoxValue;
    }
}
