/*
 * Created by Jake Hooper (c) 2017
 * hosted on GitHum @ https://github.com/jhooper04/Encryptor
 * 
 * Encryptor may be freely distributed under the MIT license.
 */
 
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Encryptor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private const string encryptionSignature = "!=!enc!=!";
		private string currentFileName;
		private string currentFilePath;
		private string currentKey;
		private bool fileChanged;
		
		private KeyForm keyphraseForm;
		private AboutForm aboutForm;
		
		public MainForm()
		{
			InitializeComponent();
			mainTextBox.Font = Properties.Settings.Default.TextboxFont;
			
			NewFile(false);
		}
		
		void NewToolStripMenuItemClick(object sender, EventArgs e)
		{
			NewFile();
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			keyphraseForm = new KeyForm();

			if (keyphraseForm.ShowDialog() == DialogResult.OK) {
				
				mainSaveFileDialog.InitialDirectory = currentFilePath;
				mainSaveFileDialog.FileName = currentFileName;

				if (mainSaveFileDialog.ShowDialog() == DialogResult.OK)
					SaveFile(mainSaveFileDialog.FileName, keyphraseForm.keyphrase);
			}
		}
		
		void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			keyphraseForm = new KeyForm();

			if (keyphraseForm.ShowDialog() == DialogResult.OK) {
				
				mainSaveFileDialog.InitialDirectory = currentFilePath;
				mainSaveFileDialog.FileName = currentFileName;
				
				if (mainSaveFileDialog.ShowDialog() == DialogResult.OK)
					SaveFile(mainSaveFileDialog.FileName, keyphraseForm.keyphrase);
			}
		}
		
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (ConfirmLosingChanges())
				return;
			
			mainOpenFileDialog.InitialDirectory = currentFilePath;
			mainOpenFileDialog.FileName = "";
			
			if (mainOpenFileDialog.ShowDialog() == DialogResult.OK) {
				
				string fileText;
				
				try {
					fileText = File.ReadAllText(mainOpenFileDialog.FileName);
				} catch(Exception ex) {
					MessageBox.Show("An error has occurred while opening the file.\n\n" + ex.Message, 
				                "Decryption failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (fileText.StartsWith(encryptionSignature, StringComparison.InvariantCulture)) {

					keyphraseForm = new KeyForm();

					if (keyphraseForm.ShowDialog() == DialogResult.OK)
						OpenFile(mainOpenFileDialog.FileName, keyphraseForm.keyphrase, fileText.Remove(0, encryptionSignature.Length));

				} else {

					currentFileName = Path.GetFileName(mainOpenFileDialog.FileName);
					currentFilePath = Path.GetDirectoryName(mainOpenFileDialog.FileName);
					currentKey = "";
					mainTextBox.Text = fileText;
					this.Text = currentFileName + " - Encryptor";
					fileChanged = false;
					UpdateEditMenuitems();
				}
			}
				
		}

		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}

		void MainTextBoxTextChanged(object sender, EventArgs e)
		{
			fileChanged = true;
			this.Text = currentFileName + " - Encryptor - Unsaved";
			UpdateEditMenuitems();
		}

		void MainTextBoxMouseClick(object sender, MouseEventArgs e)
		{
			UpdateEditMenuitems();
		}
		
		void MainTextBoxKeyUp(object sender, KeyEventArgs e)
		{
			UpdateEditMenuitems();
		}
		
		void MainFormMouseUp(object sender, MouseEventArgs e)
		{
			UpdateEditMenuitems();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (ConfirmLosingChanges())
				e.Cancel = true;
		}
		
		void CutToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (mainTextBox.SelectedText.Length > 0)
			{
				Clipboard.SetText(mainTextBox.SelectedText);
				
				int start = mainTextBox.SelectionStart;
				int length = mainTextBox.SelectionLength;
				string newText = mainTextBox.Text.Substring(0, start);
				newText += mainTextBox.Text.Substring(start + length);
				
				mainTextBox.Text = newText;
				mainTextBox.SelectionStart = start;
				UpdateEditMenuitems();
			}
		}
		
		void CopyToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (mainTextBox.SelectedText.Length > 0)
				Clipboard.SetText(mainTextBox.SelectedText);
		}
		
		void PasteToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (Clipboard.ContainsText()) {
				if (mainTextBox.SelectionLength > 0) {
					
					int start = mainTextBox.SelectionStart;
					int length = mainTextBox.SelectionLength;
					string ptext = Clipboard.GetText();
					string newText = mainTextBox.Text.Substring(0, start);
					
					newText += mainTextBox.Text.Substring(start + length);
					newText = newText.Insert(start, ptext);

					mainTextBox.Text = newText;
					mainTextBox.SelectionStart = start+ptext.Length;
					UpdateEditMenuitems();
					
				} else {
					int start = mainTextBox.SelectionStart;
					string text = Clipboard.GetText();
					mainTextBox.Text = mainTextBox.Text.Insert(mainTextBox.SelectionStart, text);
					mainTextBox.SelectionStart = start+text.Length;
					UpdateEditMenuitems();
				}
			}
		}
		
		void AboutEncyptorToolStripMenuItemClick(object sender, EventArgs e)
		{
			aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}
		
		void UndoToolStripMenuItemClick(object sender, EventArgs e)
		{
			//mainTextBox.
		}
		
		void RedoToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (mainTextBox.SelectedText.Length > 0)
			{
				int start = mainTextBox.SelectionStart;
				int length = mainTextBox.SelectionLength;
				string newText = mainTextBox.Text.Substring(0, start);
				newText += mainTextBox.Text.Substring(start + length);
				mainTextBox.Text = newText;
				mainTextBox.SelectionStart = start;
				UpdateEditMenuitems();
			
			} else if (mainTextBox.SelectionStart < mainTextBox.Text.Length-1) {
				
				int start = mainTextBox.SelectionStart;
				string newText = mainTextBox.Text.Substring(0, start);
				newText += mainTextBox.Text.Substring(start + 1);
				mainTextBox.Text = newText;
				mainTextBox.SelectionStart = start;
				UpdateEditMenuitems();
			}
		}
		
		void SelectAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			mainTextBox.SelectAll();
			UpdateEditMenuitems();
		}
		
		void TimeDateToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (mainTextBox.SelectedText.Length > 0)
			{
				int start = mainTextBox.SelectionStart;
				int length = mainTextBox.SelectionLength;
				string newText = mainTextBox.Text.Substring(0, start);
				newText += mainTextBox.Text.Substring(start + length);
				
				string stamp = DateTime.Now.ToString();
				mainTextBox.Text = newText;
				mainTextBox.Text = mainTextBox.Text.Insert(start, stamp);
				mainTextBox.SelectionStart = start + stamp.Length;
				UpdateEditMenuitems();
				
			} else {
				
				int start = mainTextBox.SelectionStart;
				string stamp = DateTime.Now.ToString();
				
				mainTextBox.Text = mainTextBox.Text.Insert(mainTextBox.SelectionStart, DateTime.Now.ToString());
				mainTextBox.SelectionStart = start + stamp.Length;
				UpdateEditMenuitems();
			}
		}
		
		void WordWrapToolStripMenuItemClick(object sender, EventArgs e)
		{
			wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
			
			mainTextBox.WordWrap = wordWrapToolStripMenuItem.Checked;
			mainTextBox.ScrollBars = wordWrapToolStripMenuItem.Checked ? ScrollBars.Vertical : ScrollBars.Both;
		}
		
		void FontToolStripMenuItemClick(object sender, EventArgs e)
		{
			mainFontDialog.Font = mainTextBox.Font;
			mainFontDialog.ShowDialog();
			mainTextBox.Font = mainFontDialog.Font;
			
			Properties.Settings.Default.TextboxFont = mainTextBox.Font;
			Properties.Settings.Default.Save();
		}
		
		bool ConfirmLosingChanges() {
			bool result = false;
			
			if (fileChanged) {
				
				DialogResult dr = MessageBox.Show("There are Unsaved changes, do you want to continue?", "Unsaved changes", 
				                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				
				if (dr == DialogResult.Cancel) {
					result = true;
				}
			}
			return result;
		}
		
		void UpdateEditMenuitems() {
			
			cutToolStripMenuItem.Enabled = mainTextBox.SelectionLength > 0;
			copyToolStripMenuItem.Enabled = mainTextBox.SelectionLength > 0;
			pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
			deleteToolStripMenuItem.Enabled = mainTextBox.SelectionStart < mainTextBox.Text.Length-1;
			selectAllToolStripMenuItem.Enabled = !(mainTextBox.SelectionStart == 0 && mainTextBox.SelectionLength == mainTextBox.Text.Length);
		}
		
		void NewFile(bool confirmation=true) {
			
			if (confirmation && ConfirmLosingChanges())
				return;
			
			currentFileName = "Untitled.txt";
			currentFilePath = Properties.Settings.Default.InitialDirectory;
			currentKey = "";
			mainTextBox.Text = "";
			this.Text = currentFileName + " - Encryptor";
			fileChanged = false;
			UpdateEditMenuitems();
		}
		
		void OpenFile(string path, string key, string cipher) {
			
			string prevName = currentFileName;
			string prevPath = currentFilePath;
			string prevKey = currentKey;
			
			currentFileName = Path.GetFileName(path);
			currentFilePath = Path.GetDirectoryName(path);
			currentKey = key;

			try {
				
				//string cipher = File.ReadAllText(path);
				mainTextBox.Text = EncDec.Decrypt(cipher, key);
				
				this.Text = currentFileName + " - Encryptor";
				fileChanged = false;
				UpdateEditMenuitems();
			
			} catch(System.Security.Cryptography.CryptographicException e) {
				
				currentFileName = prevName;
				currentFilePath = prevPath;
				currentKey = prevKey;
				UpdateEditMenuitems();
				
				MessageBox.Show("An error has occurred while decrypting the file.\nMost likely an invalid passphrase or could be a corrupted file.\n\n" + e.Message, 
				                "Decryption failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void SaveFile(string path, string key) {
			
			string prevName = currentFileName;
			string prevPath = currentFilePath;
			string prevKey = currentKey;
			
			currentFileName = Path.GetFileName(path);
			currentFilePath = Path.GetDirectoryName(path);
			currentKey = key;
			
			try {
				
				string cipher = EncDec.Encrypt(mainTextBox.Text, key);
				File.WriteAllText(path, encryptionSignature + cipher);
				
				this.Text = currentFileName + " - Encryptor";
				fileChanged = false;
				
			} catch(System.Security.Cryptography.CryptographicException e) {
				
				currentFileName = prevName;
				currentFilePath = prevPath;
				currentKey = prevKey;
				
				MessageBox.Show("An error has occurred while encrypting the file.\n\n" + e.Message, 
				                "Encryption failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
