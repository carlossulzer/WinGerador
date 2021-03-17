using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
namespace WinGerador 
{
	/// <summary>
	/// struct to handle the caret (L, C) co-ordinates
	/// L = one-based line number of the line containing the caret
	/// C = one-based column number in the line containing the caret
	/// </summary>
	public struct CharPoint 
	{
		private int l, c;

		public static readonly CharPoint Empty;
				
		static CharPoint()
		{
			CharPoint.Empty = new CharPoint();
		}

		public CharPoint(int l, int c) 
		{
			this.l = l;
			this.c = c;

			
		}

		public override string ToString()
		{
			return(String.Format("{0},{1}", this.l, this.c));   
		}

	}

	public class ExtTextBox: TextBox
	{
		[DllImport("user32")] private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);
		[DllImport("user32")] private static extern int GetCaretPos(ref Point lpPoint);
		private int EM_LINEINDEX = 0xbb;
		private int EM_LINEFROMCHAR = 0xc9;
		private int EM_GETSEL = 0xb0;
		private int ln = 0;
        private int cl = 0;
		/// <summary>
		/// Gets the caret current (X, Y) position.
		/// </summary>
		/// <value>
		/// Point struct
		/// </value>
		/// 

		public int Linha
		{
			get
			{
				this.GetCaretLCPosition.ToString(); 
				return (this.ln);
			}
		}

		public int Coluna
		{
			get
			{
				this.GetCaretLCPosition.ToString(); 
				return (this.cl);
			}
		}

		public Point GetCaretXYPosition
		{
			get
			{
				Point pt = Point.Empty;
				// get a Point struct with the caret current (X, Y) position
				GetCaretPos(ref pt);
				// return the Point struct with the caret current (X, Y) position
				return pt;
			}
		}
		
		/// <summary>
		/// Gets the caret current (L, C) position.
		/// </summary>
		/// <value>
		/// CharPoint struct
		/// </value>
		/// 



		public CharPoint GetCaretLCPosition
		{
			get
			{
				CharPoint cpt = CharPoint.Empty;
				// save the handle reference for the ExtToolBox
				HandleRef hr = new HandleRef(this, base.Handle );
				// Send the EM_LINEFROMCHAR message with the value of -1 in wParam.
				// The return value is the zero-based line number 
				// of the line containing the caret.
				int l = (int)SendMessage(hr,EM_LINEFROMCHAR, -1, 0);
				// Send the EM_GETSEL message to the ToolBox control.
				// The low-order word of the return value is the character
				// position of the caret relative to the first character in the
				// ToolBox control, i.e. the absolute character index.
				int sel = (int)SendMessage(hr, EM_GETSEL,0, 0);
				// get the low-order word from sel
				int ai  = sel & 0xffff; 
				// Send the EM_LINEINDEX message with the value of -1 in wParam.
				// The return value is the number of characters
				// that precede the first character in the line containing the caret.
				int li = (int)SendMessage(hr,EM_LINEINDEX, -1, 0);
				// Subtract the li (line index) from the ai (absolute character index),
				// The result is the column number of the caret position 
				// in the line containing the caret.
				int c = ai - li;
				cpt = new CharPoint(l+1,c+1);
				// Add 1 to the l and c since these are zero-based.
				// Return a CharPoint with the caret current (L,C) position
				ln = l+1;
				cl = c+1;
				return new CharPoint(l+1,c+1);
			}
		}
	}
}
