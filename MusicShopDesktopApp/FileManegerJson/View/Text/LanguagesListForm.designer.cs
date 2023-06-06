
namespace FileManegerJson
{
    partial class LanguagesListEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Back = new System.Windows.Forms.Button();
            this.DeleteAll = new System.Windows.Forms.Button();
            this.LanguagePanel = new System.Windows.Forms.Panel();
            this.LangugeList = new System.Windows.Forms.ListView();
            this.Add = new System.Windows.Forms.Button();
            this.MailLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainPanel.SuspendLayout();
            this.LanguagePanel.SuspendLayout();
            this.MailLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.ColumnCount = 3;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MainPanel.Controls.Add(this.Back, 0, 0);
            this.MainPanel.Controls.Add(this.DeleteAll, 1, 0);
            this.MainPanel.Controls.Add(this.LanguagePanel, 0, 1);
            this.MainPanel.Controls.Add(this.Add, 2, 0);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(10);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 2;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.Size = new System.Drawing.Size(761, 450);
            this.MainPanel.TabIndex = 0;
            // 
            // Back
            // 
            this.Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back.Location = new System.Drawing.Point(15, 15);
            this.Back.Margin = new System.Windows.Forms.Padding(15);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(223, 50);
            this.Back.TabIndex = 0;
            this.Back.Text = "Готово";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // DeleteAll
            // 
            this.DeleteAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteAll.Location = new System.Drawing.Point(268, 15);
            this.DeleteAll.Margin = new System.Windows.Forms.Padding(15);
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(223, 50);
            this.DeleteAll.TabIndex = 1;
            this.DeleteAll.Text = "Удалить все";
            this.DeleteAll.UseVisualStyleBackColor = true;
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // LanguagePanel
            // 
            this.LanguagePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPanel.SetColumnSpan(this.LanguagePanel, 3);
            this.LanguagePanel.Controls.Add(this.MailLayout);
            this.LanguagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LanguagePanel.Location = new System.Drawing.Point(20, 100);
            this.LanguagePanel.Margin = new System.Windows.Forms.Padding(20);
            this.LanguagePanel.Name = "LanguagePanel";
            this.LanguagePanel.Size = new System.Drawing.Size(721, 330);
            this.LanguagePanel.TabIndex = 2;
            // 
            // LangugeList
            // 
            this.LangugeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LangugeList.HideSelection = false;
            this.LangugeList.Location = new System.Drawing.Point(10, 10);
            this.LangugeList.Margin = new System.Windows.Forms.Padding(10);
            this.LangugeList.Name = "LangugeList";
            this.LangugeList.Size = new System.Drawing.Size(697, 306);
            this.LangugeList.TabIndex = 0;
            this.LangugeList.UseCompatibleStateImageBehavior = false;
            this.LangugeList.View = System.Windows.Forms.View.List;
            this.LangugeList.SelectedIndexChanged += new System.EventHandler(this.LangugeList_SelectedIndexChanged);
            // 
            // Add
            // 
            this.Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add.Location = new System.Drawing.Point(521, 15);
            this.Add.Margin = new System.Windows.Forms.Padding(15);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(225, 50);
            this.Add.TabIndex = 3;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // MailLayout
            // 
            this.MailLayout.ColumnCount = 1;
            this.MailLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MailLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MailLayout.Controls.Add(this.LangugeList, 0, 0);
            this.MailLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MailLayout.Location = new System.Drawing.Point(0, 0);
            this.MailLayout.Name = "MailLayout";
            this.MailLayout.RowCount = 1;
            this.MailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MailLayout.Size = new System.Drawing.Size(717, 326);
            this.MailLayout.TabIndex = 1;
            // 
            // LanguagesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 450);
            this.Controls.Add(this.MainPanel);
            this.Name = "LanguagesListForm";
            this.Text = "LanguagesListForm";
            this.Load += new System.EventHandler(this.LanguagesListForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.LanguagePanel.ResumeLayout(false);
            this.MailLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button DeleteAll;
        private System.Windows.Forms.Panel LanguagePanel;
        private System.Windows.Forms.ListView LangugeList;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TableLayoutPanel MailLayout;
    }
}