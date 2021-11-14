
namespace Lab7
{
    partial class RoleForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lvRole = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModifyRole = new System.Windows.Forms.Button();
            this.btnSaveRole = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(156, 22);
            this.tsmiDelete.Text = "Xóa tài khoảng ";
            // 
            // lvRole
            // 
            this.lvRole.CheckBoxes = true;
            this.lvRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvRole.FullRowSelect = true;
            this.lvRole.HideSelection = false;
            this.lvRole.Location = new System.Drawing.Point(12, 168);
            this.lvRole.Name = "lvRole";
            this.lvRole.Size = new System.Drawing.Size(494, 286);
            this.lvRole.TabIndex = 6;
            this.lvRole.UseCompatibleStateImageBehavior = false;
            this.lvRole.View = System.Windows.Forms.View.Details;
            this.lvRole.SelectedIndexChanged += new System.EventHandler(this.lvRole_SelectedIndexChanged);
            this.lvRole.Click += new System.EventHandler(this.lvRole_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên vai trò";
            this.columnHeader2.Width = 148;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "đường dẫn";
            this.columnHeader3.Width = 195;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Notes";
            this.columnHeader4.Width = 219;
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(93, 25);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(314, 20);
            this.txtRole.TabIndex = 7;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(93, 64);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(314, 20);
            this.txtPath.TabIndex = 8;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(93, 101);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(314, 20);
            this.txtNotes.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên vai trò";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đường dẫn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Notes";
            // 
            // btnModifyRole
            // 
            this.btnModifyRole.Location = new System.Drawing.Point(431, 99);
            this.btnModifyRole.Name = "btnModifyRole";
            this.btnModifyRole.Size = new System.Drawing.Size(75, 23);
            this.btnModifyRole.TabIndex = 13;
            this.btnModifyRole.Text = "lưu";
            this.btnModifyRole.UseVisualStyleBackColor = true;
            this.btnModifyRole.Click += new System.EventHandler(this.btnModifyRole_Click);
            // 
            // btnSaveRole
            // 
            this.btnSaveRole.Location = new System.Drawing.Point(332, 467);
            this.btnSaveRole.Name = "btnSaveRole";
            this.btnSaveRole.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRole.TabIndex = 15;
            this.btnSaveRole.Text = "Lưu vai trò";
            this.btnSaveRole.UseVisualStyleBackColor = true;
            this.btnSaveRole.Click += new System.EventHandler(this.btnSaveRole_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(431, 467);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // RoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 502);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveRole);
            this.Controls.Add(this.btnModifyRole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.lvRole);
            this.Name = "RoleForm";
            this.Text = "RoleForm";
            this.Load += new System.EventHandler(this.RoleForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ListView lvRole;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModifyRole;
        private System.Windows.Forms.Button btnSaveRole;
        private System.Windows.Forms.Button btnExit;
    }
}