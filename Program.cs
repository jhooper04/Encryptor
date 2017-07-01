/*
 * Created by Jake Hooper (c) 2017
 * hosted on GitHum @ https://github.com/jhooper04/Encryptor
 * 
 * Encryptor may be freely distributed under the MIT license.
 */
 
using System;
using System.Windows.Forms;

namespace Encryptor
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
