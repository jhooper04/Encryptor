/*
 * Created by SharpDevelop.
 * User: Jake Hooper
 * Date: 6/29/2017
 * Time: 3:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Encryptor.UndoRedo
{
	/// <summary>
	/// Description of UndoRedo.
	/// </summary>
	public class UndoRedo
	{
		
		private Stack<ICommand> _Undocommands = new Stack<ICommand>();
      	private Stack<ICommand> _Redocommands = new Stack<ICommand>();
      	
      	private TextBox _editTextBox;
      	
      	public TextBox EditTextBox
      	{
      		get { return _editTextBox; }
      		set { _editTextBox = value; }
      	}
		
		public void Undo(int levels=1) {
			
			for (int i = 1; i <= levels; i++)
			{
				if (_Undocommands.Count != 0)
				{
					ICommand command = _Undocommands.Pop();
					command.UnExecute();
					_Redocommands.Push(command);
				}
			}
		}
		
		public void Redo(int levels=1) {
			
			for (int i = 1; i <= levels; i++)
			{
				if (_Redocommands.Count != 0)
				{
					ICommand command = _Redocommands.Pop();
					command.Execute();
					_Undocommands.Push(command);
				}
			}
		}
		
		
		public void InsertCommandForTextChange(string changedText, int startIndex, int length)
		{
			ICommand cmd = new TextChangedCommand(changedText, startIndex, length, _editTextBox);
			_Undocommands.Push(cmd);
			_Redocommands.Clear();
		}
	}
}
