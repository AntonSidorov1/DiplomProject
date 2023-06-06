
namespace MusicShopDesktopApp
{
    partial class NumericControlWithName
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
            this.components = new System.ComponentModel.Container();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.groupBoxTitle = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelPole = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.NumericUpDown();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.panelBorder.SuspendLayout();
            this.groupBoxTitle.SuspendLayout();
            this.tableLayoutPanelPole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxInput)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBorder
            // 
            this.panelBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBorder.Controls.Add(this.groupBoxTitle);
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(310, 76);
            this.panelBorder.TabIndex = 0;
            // 
            // groupBoxTitle
            // 
            this.groupBoxTitle.Controls.Add(this.tableLayoutPanelPole);
            this.groupBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTitle.Name = "groupBoxTitle";
            this.groupBoxTitle.Size = new System.Drawing.Size(306, 72);
            this.groupBoxTitle.TabIndex = 0;
            this.groupBoxTitle.TabStop = false;
            this.groupBoxTitle.Text = "groupBox1";
            // 
            // tableLayoutPanelPole
            // 
            this.tableLayoutPanelPole.ColumnCount = 2;
            this.tableLayoutPanelPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPole.Controls.Add(this.buttonClear, 1, 0);
            this.tableLayoutPanelPole.Controls.Add(this.textBoxInput, 0, 0);
            this.tableLayoutPanelPole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPole.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelPole.Name = "tableLayoutPanelPole";
            this.tableLayoutPanelPole.RowCount = 1;
            this.tableLayoutPanelPole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPole.Size = new System.Drawing.Size(300, 51);
            this.tableLayoutPanelPole.TabIndex = 0;
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Location = new System.Drawing.Point(253, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(44, 45);
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.VisibleChanged += new System.EventHandler(this.buttonClear_VisibleChanged);
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInput.Location = new System.Drawing.Point(3, 3);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(244, 22);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.EnabledChanged += new System.EventHandler(this.textBoxInput_EnabledChanged);
            this.textBoxInput.VisibleChanged += new System.EventHandler(this.textBoxInput_VisibleChanged);
            this.textBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInput_KeyPress);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // NumericControlWithName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBorder);
            this.Name = "NumericControlWithName";
            this.Size = new System.Drawing.Size(310, 76);
            this.Load += new System.EventHandler(this.NumericControlWithName_Load);
            this.panelBorder.ResumeLayout(false);
            this.groupBoxTitle.ResumeLayout(false);
            this.tableLayoutPanelPole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.GroupBox groupBoxTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPole;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.NumericUpDown textBoxInput;
        private System.Windows.Forms.Timer timerUpdate;
    }
}
