/*
 * Created by SharpDevelop.
 * User: Jake Hooper
 * Date: 6/29/2017
 * Time: 1:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Encryptor
{
	partial class AboutForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox iconPictureBox;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label detailsLabel;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.Label versionLabel;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.iconPictureBox = new System.Windows.Forms.PictureBox();
			this.titleLabel = new System.Windows.Forms.Label();
			this.detailsLabel = new System.Windows.Forms.Label();
			this.infoLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(431, 226);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// iconPictureBox
			// 
			this.iconPictureBox.Location = new System.Drawing.Point(12, 12);
			this.iconPictureBox.Name = "iconPictureBox";
			this.iconPictureBox.Size = new System.Drawing.Size(168, 165);
			this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.iconPictureBox.TabIndex = 1;
			this.iconPictureBox.TabStop = false;
			// 
			// titleLabel
			// 
			this.titleLabel.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.Location = new System.Drawing.Point(187, 13);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(195, 59);
			this.titleLabel.TabIndex = 2;
			this.titleLabel.Text = "Encryptor";
			// 
			// detailsLabel
			// 
			this.detailsLabel.Location = new System.Drawing.Point(187, 76);
			this.detailsLabel.Name = "detailsLabel";
			this.detailsLabel.Size = new System.Drawing.Size(319, 101);
			this.detailsLabel.TabIndex = 3;
			this.detailsLabel.Text = "label2";
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(13, 184);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(493, 39);
			this.infoLabel.TabIndex = 4;
			this.infoLabel.Text = "label3";
			// 
			// versionLabel
			// 
			this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.versionLabel.Location = new System.Drawing.Point(374, 40);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(127, 23);
			this.versionLabel.TabIndex = 5;
			this.versionLabel.Text = "v0.5";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(518, 257);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.detailsLabel);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.iconPictureBox);
			this.Controls.Add(this.button1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "About Encryptor";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
