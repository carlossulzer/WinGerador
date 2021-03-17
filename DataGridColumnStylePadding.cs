
using System;
using System.ComponentModel;

namespace WinGerador 
{

	public class DataGridColumnStylePadding {
		
		int m_left;
		int m_right;
		int m_top;
		int m_bottom;

		public int Left {
			get { return m_left; }
			set { m_left = value; }
		}

		public int Right {
			get { return m_right; }
			set { m_right = value; }
		}

		public int Top {
			get { return m_top; }
			set { m_top = value; }
		}

		public int Bottom {
			get { return m_bottom; }
			set { m_bottom = value; }
		}

		public void SetPadding( int padValue ) {
			
			m_left = padValue;
			m_right = padValue;
			m_top = padValue;
			m_bottom = padValue;

		}

		public void SetPadding( int top, int right, int bottom, int left ) {
			UpdatePaddingValues( top, right, bottom, left );
		}

		public DataGridColumnStylePadding( int padValue ) {
			this.SetPadding( padValue );
		}

		public DataGridColumnStylePadding( int top, int right, int bottom, int left ) {
			UpdatePaddingValues( top, right, bottom, left );
		}

		private void UpdatePaddingValues( int top, int right, int bottom, int left ) {

			m_top = top;
			m_right = right;
			m_bottom = bottom;
			m_left = left;
		
		}

	}

}