using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace AnimeSearcher
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(368, 30);
			this.label1.TabIndex = 1;
			this.label1.Text = "Anime Title Searcher";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panel1
			// 
			this.panel1.AllowDrop = true;
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.panel1.Location = new System.Drawing.Point(12, 42);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(368, 248);
			this.panel1.TabIndex = 2;
			this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel1DragDrop);
			this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel1DragEnter);
			this.panel1.DragLeave += new System.EventHandler(this.Panel1DragLeave);
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(212, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 47);
			this.label5.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(152, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 47);
			this.label4.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(93, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 47);
			this.label3.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
			this.label2.Location = new System.Drawing.Point(102, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(151, 109);
			this.label2.TabIndex = 0;
			this.label2.Text = "Ctrl + V\r\nOr\r\nDrop Img\r\n";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 302);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Anime Title Searcher";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		
		void MainFormKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ((e.Control && e.KeyCode == Keys.V) && Clipboard.ContainsImage())
			{
				this.startSearchTitleByAnimeImg(Clipboard.GetImage());
			}
			if (e.KeyCode == Keys.F1)
			{
				RefForm refPage = new RefForm();
				refPage.Show();
			}
		}
		
		void Panel1DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				this.label2.Text = "Drop";
				this.paintDragAndDropFild();
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		void Panel1DragLeave(object sender, EventArgs e)
		{
			this.label2.Text = "Ctrl + V\r\nOr\r\nDrop Img\r\n";
			this.resetDragAndDropFild();
		}
		
		void Panel1DragDrop(object sender, DragEventArgs e)
		{
			this.label2.Text = "Ctrl + V\r\nOr\r\nDrop Img\r\n";
			this.resetDragAndDropFild();
			
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			Image img = Image.FromFile(files[0]);
			if (img == null) return;
			
			this.startSearchTitleByAnimeImg(img);
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Black, 3);
			pen.DashPattern = new float[] { 1 };
			e.Graphics.DrawRectangle(pen, 1, 1, panel1.Width - 3, panel1.Height -3);
		}

		private Thread loadAnimationTheard;
		void loadAnimation()
		{
			while (true)
			{
				this.label3.Invoke(new Action(() => this.label3.Text = (this.label3.Text == "♦") ? "" : "♦"));
				Thread.Sleep(200);
				this.label4.Invoke(new Action(() => this.label4.Text = (this.label4.Text == "♦") ? "" : "♦"));
				Thread.Sleep(200);
				this.label5.Invoke(new Action(() => this.label5.Text = (this.label5.Text == "♦") ? "" : "♦"));
				Thread.Sleep(200);
			}
		}
		void startLoadAnimation()
		{	
			this.loadAnimationTheard = new Thread(new ThreadStart((Action)loadAnimation));
			loadAnimationTheard.Start();
		}
		void stopLoadAnimation()
		{
			this.loadAnimationTheard.Abort();
			this.label3.Text = "";
			this.label4.Text = "";
			this.label5.Text = "";
		}
		
		void paintDragAndDropFild()
		{
			Graphics graphics = Graphics.FromHwnd(this.panel1.Handle);
			this.clearDragAndDropFild();
			
			Pen pen = new Pen(Color.Black, 3);
			pen.DashPattern = new float[] { 5, 1 };
			graphics.DrawRectangle(pen, 1, 1, panel1.Width - 3 , panel1.Height - 3);
		}
		void clearDragAndDropFild()
		{
			Graphics graphics = Graphics.FromHwnd(this.panel1.Handle);
			
			Pen pen = new Pen(Color.White, 3);
			pen.DashPattern = new float[] { 1 };
			graphics.DrawRectangle(pen, 1, 1, panel1.Width - 3 , panel1.Height - 3);
		}
		void resetDragAndDropFild()
		{
			Graphics graphics = Graphics.FromHwnd(this.panel1.Handle);
			this.clearDragAndDropFild();
			
			Pen pen = new Pen(Color.Black, 3);
			pen.DashPattern = new float[] { 1 };
			graphics.DrawRectangle(pen, 1, 1, panel1.Width - 3 , panel1.Height - 3);
		}
	}
}
