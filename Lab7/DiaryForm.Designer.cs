
namespace Lab7
{
    partial class DiaryForm
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
            this.lbDate = new System.Windows.Forms.ListBox();
            this.dgvListFood = new System.Windows.Forms.DataGridView();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFood)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDate
            // 
            this.lbDate.FormattingEnabled = true;
            this.lbDate.Location = new System.Drawing.Point(12, 12);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(170, 420);
            this.lbDate.TabIndex = 0;
            this.lbDate.SelectedIndexChanged += new System.EventHandler(this.lbDate_SelectedIndexChanged);
            // 
            // dgvListFood
            // 
            this.dgvListFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFood.Location = new System.Drawing.Point(201, 12);
            this.dgvListFood.Name = "dgvListFood";
            this.dgvListFood.Size = new System.Drawing.Size(574, 361);
            this.dgvListFood.TabIndex = 1;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(265, 400);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(125, 13);
            this.lbTotal.TabIndex = 2;
            this.lbTotal.Text = "Số lượng hóa đơn đã lập";
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(534, 400);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(72, 13);
            this.lbAmount.TabIndex = 3;
            this.lbAmount.Text = "Tổng số tiền: ";
            // 
            // DiaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.dgvListFood);
            this.Controls.Add(this.lbDate);
            this.Name = "DiaryForm";
            this.Text = "DiaryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDate;
        private System.Windows.Forms.DataGridView dgvListFood;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbAmount;
    }
}