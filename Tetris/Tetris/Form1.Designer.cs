namespace Tetris
{
    partial class Tetris
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRestart = new System.Windows.Forms.Button();
            this.Gravity = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(308, 397);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 5;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // Gravity
            // 
            this.Gravity.Interval = 250;
            this.Gravity.Tick += new System.EventHandler(this.Gravity_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "消除行數:";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(341, 25);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(11, 12);
            this.lblLine.TabIndex = 7;
            this.lblLine.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "下個方塊";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 84);
            this.label3.TabIndex = 9;
            this.label3.Text = "操作說明：\r\n\r\n    ←→控制方向\r\n\r\n   ↑旋轉 Shift反轉\r\n\r\n   ↓緩降 Z 瞬降";
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 512);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRestart);
            this.MaximizeBox = false;
            this.Name = "Tetris";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Tetris_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Timer Gravity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

