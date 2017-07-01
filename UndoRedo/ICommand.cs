/*
 * Created by Jake Hooper (c) 2017
 * hosted on GitHum @ https://github.com/jhooper04/Encryptor
 * 
 * Encryptor may be freely distributed under the MIT license.
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
