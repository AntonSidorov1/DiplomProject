
namespace FileManegerJson
{
    partial class TextInputEdit
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
            this.tableLayoutPanelPole = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxTitle.SuspendLayout();
            this.tableLayoutPanelPole.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTitle
            // 
            this.groupBoxTitle.Controls.Add(this.tableLayoutPanelPole);
            this.groupBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTitle.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxTitle.Name = "groupBoxTitle";
            this.groupBoxTitle.Size = new System.Drawing.Size(248, 75);
            this.groupBoxTitle.TabIndex = 0;
            this.groupBoxTitle.TabStop = false;
            this.groupBoxTitle.Text = "groupBox1";
            this.groupBoxTitle.Enter += new System.EventHandler(this.groupBoxTitle_Enter);
            // 
            // tableLayoutPanelPole
            // 
            this.tableLayoutPanelPole.ColumnCount = 2;
            this.tableLayoutPanelPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPole.Controls.Add(this.textBoxInput, 0, 0);
            this.tableLayoutPanelPole.Controls.Add(this.buttonClear, 1, 0);
            this.tableLayoutPanelPole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPole.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelPole.Name = "tableLayoutPanelPole";
            this.tableLayoutPanelPole.RowCount = 2;
            this.tableLayoutPanelPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPole.Size = new System.Drawing.Size(242, 54);
            this.tableLayoutPanelPole.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInput.Location = new System.Drawing.Point(3, 3);
            this.textBoxInput.Name = "textBoxInput";
            this.tableLayoutPanelPole.SetRowSpan(this.textBoxInput, 2);
            this.textBoxInput.Size = new System.Drawing.Size(186, 22);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.ReadOnlyChanged += new System.EventHandler(this.textBoxInput_ReadOnlyChanged);
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            this.textBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInput_KeyPress);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Location = new System.Drawing.Point(197, 5);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(5);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(40, 40);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.VisibleChanged += new System.EventHandler(this.buttonClear_VisibleChanged);
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // TextInputEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBoxTitle);
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "TextInputEdit";
            this.Size = new System.Drawing.Size(248, 75);
            this.Load += new System.EventHandler(this.TextInput_Load);
            this.groupBoxTitle.ResumeLayout(false);
            this.tableLayoutPanelPole.ResumeLayout(false);
            this.tableLayoutPanelPole.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPole;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonClear;
    }
}
