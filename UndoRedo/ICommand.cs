/*
 * Created by SharpDevelop.
 * User: Jake Hooper
 * Date: 6/29/2017
 * Time: 3:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Encryptor.UndoRedo
{
	/// <summary>
	/// Description of ICommand.
	/// </summary>
	public interface ICommand
	{
		void Execute();
		void UnExecute();
	}
}
