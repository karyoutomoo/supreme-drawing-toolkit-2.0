using System;

namespace DrawingToolkit
{
    partial class DrawingCanvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingCanvas));
            this.LineTool = new System.Windows.Forms.Button();
            this.CircleTool = new System.Windows.Forms.Button();
            this.DrawingTools = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RectangleTool = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DrawingTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // LineTool
            // 
            this.LineTool.BackColor = System.Drawing.Color.Red;
            this.LineTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LineTool.Cursor = System.Windows.Forms.Cursors.Default;
            this.LineTool.Image = global::DrawingToolkit.Properties.Resources.icons8_line_32;
            this.LineTool.Location = new System.Drawing.Point(9, 27);
            this.LineTool.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LineTool.Name = "LineTool";
            this.LineTool.Size = new System.Drawing.Size(54, 47);
            this.LineTool.TabIndex = 0;
            this.LineTool.UseVisualStyleBackColor = false;
            this.LineTool.Click += new System.EventHandler(this.LineTool_Click);
            // 
            // CircleTool
            // 
            this.CircleTool.BackColor = System.Drawing.Color.Red;
            this.CircleTool.BackgroundImage = global::DrawingToolkit.Properties.Resources.icons8_0_percent_80;
            this.CircleTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CircleTool.Image = global::DrawingToolkit.Properties.Resources.icons8_0_percent_80;
            this.CircleTool.Location = new System.Drawing.Point(69, 27);
            this.CircleTool.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CircleTool.Name = "CircleTool";
            this.CircleTool.Size = new System.Drawing.Size(57, 47);
            this.CircleTool.TabIndex = 1;
            this.CircleTool.UseVisualStyleBackColor = false;
            this.CircleTool.Click += new System.EventHandler(this.CircleTool_Click);
            // 
            // DrawingTools
            // 
            this.DrawingTools.BackColor = System.Drawing.Color.Red;
            this.DrawingTools.Controls.Add(this.button4);
            this.DrawingTools.Controls.Add(this.button3);
            this.DrawingTools.Controls.Add(this.button2);
            this.DrawingTools.Controls.Add(this.button1);
            this.DrawingTools.Controls.Add(this.RectangleTool);
            this.DrawingTools.Controls.Add(this.CircleTool);
            this.DrawingTools.Controls.Add(this.LineTool);
            this.DrawingTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawingTools.Location = new System.Drawing.Point(3, 4);
            this.DrawingTools.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawingTools.Name = "DrawingTools";
            this.DrawingTools.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawingTools.Size = new System.Drawing.Size(1149, 94);
            this.DrawingTools.TabIndex = 2;
            this.DrawingTools.TabStop = false;
            this.DrawingTools.Text = "Drawing Tools";
            this.DrawingTools.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Image = global::DrawingToolkit.Properties.Resources.icons8_redo_64;
            this.button4.Location = new System.Drawing.Point(321, 27);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 48);
            this.button4.TabIndex = 8;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Image = global::DrawingToolkit.Properties.Resources.icons8_undo_64;
            this.button3.Location = new System.Drawing.Point(260, 26);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 49);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.BackgroundImage = global::DrawingToolkit.Properties.Resources.icons8_cursor_64__1_;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(196, 27);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 48);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::DrawingToolkit.Properties.Resources.icons8_erase_50;
            this.button1.Location = new System.Drawing.Point(1053, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 64);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RectangleTool
            // 
            this.RectangleTool.BackColor = System.Drawing.Color.Red;
            this.RectangleTool.BackgroundImage = global::DrawingToolkit.Properties.Resources.icons8_rectangular_80;
            this.RectangleTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RectangleTool.Image = global::DrawingToolkit.Properties.Resources.icons8_rectangular_80;
            this.RectangleTool.Location = new System.Drawing.Point(132, 27);
            this.RectangleTool.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RectangleTool.Name = "RectangleTool";
            this.RectangleTool.Size = new System.Drawing.Size(58, 47);
            this.RectangleTool.TabIndex = 2;
            this.RectangleTool.UseVisualStyleBackColor = false;
            this.RectangleTool.Click += new System.EventHandler(this.RectangleTool_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(3, 102);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1149, 634);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // DrawingCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1157, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DrawingTools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DrawingCanvas";
            this.Text = "DRAWING KIT";
            this.Load += new System.EventHandler(this.DrawingCanvas_Load);
            this.DrawingTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LineTool;
        private System.Windows.Forms.Button CircleTool;
        private System.Windows.Forms.GroupBox DrawingTools;
        private System.Windows.Forms.Button RectangleTool;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }

}

