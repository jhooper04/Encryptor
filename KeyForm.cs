/*
 * Created by SharpDevelop.
 * User: Jake Hooper
 * Date: 6/28/2017
 * Time: 7:17 PM
 * 
 * 
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
