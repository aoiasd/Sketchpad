namespace Sketchpad
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.中点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.交点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.垂线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new Sketchpad.MyPanel();
            this.button_Arrow = new System.Windows.Forms.Button();
            this.button_Line = new System.Windows.Forms.Button();
            this.button_Point = new System.Windows.Forms.Button();
            this.button_Circle = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中点ToolStripMenuItem,
            this.交点ToolStripMenuItem,
            this.垂线ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 76);
            // 
            // 中点ToolStripMenuItem
            // 
            this.中点ToolStripMenuItem.Name = "中点ToolStripMenuItem";
            this.中点ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.中点ToolStripMenuItem.Text = "中点";
            this.中点ToolStripMenuItem.Visible = false;
            this.中点ToolStripMenuItem.Click += new System.EventHandler(this.中点ToolStripMenuItem_Click);
            // 
            // 交点ToolStripMenuItem
            // 
            this.交点ToolStripMenuItem.Name = "交点ToolStripMenuItem";
            this.交点ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.交点ToolStripMenuItem.Text = "交点";
            this.交点ToolStripMenuItem.Visible = false;
            this.交点ToolStripMenuItem.Click += new System.EventHandler(this.交点ToolStripMenuItem_Click);
            // 
            // 垂线ToolStripMenuItem
            // 
            this.垂线ToolStripMenuItem.Name = "垂线ToolStripMenuItem";
            this.垂线ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.垂线ToolStripMenuItem.Text = "垂线";
            this.垂线ToolStripMenuItem.Visible = false;
            this.垂线ToolStripMenuItem.Click += new System.EventHandler(this.垂线ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(67, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 539);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button_Arrow
            // 
            this.button_Arrow.AutoSize = true;
            this.button_Arrow.BackColor = System.Drawing.SystemColors.Window;
            this.button_Arrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Arrow.FlatAppearance.BorderSize = 0;
            this.button_Arrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Arrow.Image = global::Sketchpad.Properties.Resources.toolarrow;
            this.button_Arrow.Location = new System.Drawing.Point(-2, 160);
            this.button_Arrow.Name = "button_Arrow";
            this.button_Arrow.Size = new System.Drawing.Size(46, 48);
            this.button_Arrow.TabIndex = 4;
            this.button_Arrow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Arrow.UseVisualStyleBackColor = false;
            this.button_Arrow.Click += new System.EventHandler(this.button_Arrow_Click);
            // 
            // button_Line
            // 
            this.button_Line.AutoSize = true;
            this.button_Line.BackColor = System.Drawing.SystemColors.Window;
            this.button_Line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Line.FlatAppearance.BorderSize = 0;
            this.button_Line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Line.Image = global::Sketchpad.Properties.Resources.toolLine;
            this.button_Line.Location = new System.Drawing.Point(-2, 106);
            this.button_Line.Name = "button_Line";
            this.button_Line.Size = new System.Drawing.Size(46, 48);
            this.button_Line.TabIndex = 3;
            this.button_Line.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Line.UseVisualStyleBackColor = false;
            this.button_Line.Click += new System.EventHandler(this.button_Line_Click);
            // 
            // button_Point
            // 
            this.button_Point.AutoSize = true;
            this.button_Point.BackColor = System.Drawing.SystemColors.Window;
            this.button_Point.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Point.FlatAppearance.BorderSize = 0;
            this.button_Point.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Point.Image = global::Sketchpad.Properties.Resources.toolPoint;
            this.button_Point.Location = new System.Drawing.Point(-2, 52);
            this.button_Point.Name = "button_Point";
            this.button_Point.Size = new System.Drawing.Size(46, 48);
            this.button_Point.TabIndex = 2;
            this.button_Point.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Point.UseVisualStyleBackColor = false;
            this.button_Point.Click += new System.EventHandler(this.button_Point_Click);
            // 
            // button_Circle
            // 
            this.button_Circle.AutoSize = true;
            this.button_Circle.BackColor = System.Drawing.SystemColors.Window;
            this.button_Circle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Circle.FlatAppearance.BorderSize = 0;
            this.button_Circle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Circle.Image = global::Sketchpad.Properties.Resources.toolcircle;
            this.button_Circle.Location = new System.Drawing.Point(-2, 214);
            this.button_Circle.Name = "button_Circle";
            this.button_Circle.Size = new System.Drawing.Size(46, 48);
            this.button_Circle.TabIndex = 5;
            this.button_Circle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Circle.UseVisualStyleBackColor = false;
            this.button_Circle.Click += new System.EventHandler(this.button_Circle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1358, 537);
            this.Controls.Add(this.button_Circle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Arrow);
            this.Controls.Add(this.button_Line);
            this.Controls.Add(this.button_Point);
            this.Name = "Form1";
            this.Text = "Sketchpad";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Point;
        private System.Windows.Forms.Button button_Line;
        private System.Windows.Forms.Button button_Arrow;
        private MyPanel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 中点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 交点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 垂线ToolStripMenuItem;
        private System.Windows.Forms.Button button_Circle;
    }
}

