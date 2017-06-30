/*
 * Created by SharpDevelop.
 * User: Jake Hooper
 * Date: 6/29/2017
 * Time: 1:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Encryptor
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			
			System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
	        Stream myStream = myAssembly.GetManifestResourceStream("Encryptor.Encryptor.png");
	        Image image = Image.FromStream(myStream);
	        iconPictureBox.Image = image;
		}
		void Button1Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
