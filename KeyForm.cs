/*
 * Created by Jake Hooper (c) 2017
 * hosted on GitHum @ https://github.com/jhooper04/Encryptor
 * 
 * Encryptor may be freely distributed under the MIT license.
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Encryptor
{
	/// <summary>
	/// Description of KeyForm.
	/// </summary>
	public partial class KeyForm : Form
	{
		public string keyphrase = "";

		public KeyForm()
		{
			InitializeComponent();
		}
		void OkButtonClick(object sender, EventArgs e)
		{
			keyphrase = keyTextBox.Text;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		void CancelButtonClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
