/*
 * Created by SharpDevelop.
 * User: Jake Hooper
 * Date: 6/29/2017
 * Time: 4:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Encryptor.UndoRedo
{
	/// <summary>
	/// Description of TextChangedCommand.
	/// </summary>
	public class TextChangedCommand : ICommand
	{
		private int _startIndex;
		private int _length;
		private string _text;
		private TextBox _txtBox;
		
		public TextChangedCommand(string text, int startIndex, int length, TextBox txtBox)
		{
			_text = text;
			_startIndex = startIndex;
			_length = length;
			_txtBox = txtBox;
		}

		public void Execute()
		{
			_txtBox.Text = _txtBox.Text.Insert(_startIndex, _text);
		}

		public void UnExecute()
		{
			string newText = _txtBox.Text.Substring(0, _startIndex);
			newText += _txtBox.Text.Substring(_startIndex + _length);
			_txtBox.Text = newText;
		}
	}
}
