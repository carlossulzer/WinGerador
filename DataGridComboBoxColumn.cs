
using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinGerador
{

	public class DataGridComboBoxColumn : DataGridColumnStyle 
	{
		
		private ComboBox m_comboBox;
		private int m_previouslyEditedCellRow;
		private DataGridColumnStylePadding m_padding;

		public DataGridComboBoxColumn() : base() {
			
			m_comboBox = new ComboBox();
			m_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			m_comboBox.Visible = false;
			m_comboBox.SizeChanged += new EventHandler( ComboBox_SizeChanged );
			
			this.ControlSize = m_comboBox.Size;
			this.Padding = new DataGridColumnStylePadding( 4, 8, 4, 8 );
			this.Width = this.GetPreferredSize( null, null ).Width;
			
			m_comboBox.Items.Add( "TextBox" );
			m_comboBox.Items.Add( "ComboBox" );
			m_comboBox.Items.Add( "CheckBox" );

			m_comboBox.SelectedIndex = 0;

		}

		public ComboBox ComboBox 
		{
			get { return m_comboBox; }
		}

		public DataGridColumnStylePadding Padding 
		{
			get { return m_padding; }
			set { m_padding = value; }
		}

		public Size ControlSize {
			get { return m_comboBox.Size; }
			set { m_comboBox.Size = value; }
		}

		protected override void Abort(int rowNum) 
		{
			// reset combobox
			m_comboBox.Visible = false;
		}

		protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible) 
		{
			Debug.WriteLine( "ComboBox Edit" );

			// get cursor coordinates
			Point p = this.DataGridTableStyle.DataGrid.PointToClient( Cursor.Position );

			// get control bounds
			Rectangle controlBounds = this.GetControlBounds( bounds );

			// get cursor bounds
			Rectangle cursorBounds = new Rectangle( p.X, p.Y, 1, 1 );

			if (this.GetColumnValueAtRow( source, rowNum ) == System.DBNull.Value) 
			{
				m_comboBox.SelectedIndex = 0;
			}
			else
			{
				m_comboBox.SelectedIndex = ( int ) this.GetColumnValueAtRow( source, rowNum );
			}

			Debug.WriteLine( "SelectedItem: " + m_comboBox.SelectedIndex );
			m_comboBox.Location = new Point( controlBounds.X, controlBounds.Y );
			m_comboBox.Visible = true;

			if ( cursorBounds.IntersectsWith( controlBounds ) ) 
			{
				m_comboBox.DroppedDown = true;
			}

			m_previouslyEditedCellRow = rowNum;
		}

		protected override bool Commit( CurrencyManager dataSource, int rowNum ) 
		{
			if ( m_previouslyEditedCellRow == rowNum ) 
			{
				this.SetColumnValueAtRow( dataSource, rowNum, m_comboBox.SelectedIndex );
			}

			m_comboBox.Visible = false;
			
			return true;
		
		}

		protected override void SetDataGridInColumn( DataGrid value ) 
		{
			base.SetDataGridInColumn( value );

			if ( !value.Controls.Contains( m_comboBox ) ) {
				value.Controls.Add( m_comboBox );
			}
		}
			
		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight) 
		{
			g.FillRectangle( new SolidBrush( Color.White ), bounds );

			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Near;
			sf.LineAlignment = StringAlignment.Center;

			Rectangle controlBounds = this.GetControlBounds( bounds );
			
			int colValue;

			if (this.GetColumnValueAtRow( source, rowNum ) == System.DBNull.Value) 
			{
				colValue = 0;
			}
			else
			{
				colValue = ( int ) this.GetColumnValueAtRow( source, rowNum );
			}

			string selectedItem = m_comboBox.Items[ colValue  ].ToString();

			Rectangle textRegion = new Rectangle( 
				controlBounds.X + 1,
				controlBounds.Y + 4,
				controlBounds.Width - 3,
				( int ) g.MeasureString( selectedItem, m_comboBox.Font ).Height );
			
			g.DrawString( selectedItem, m_comboBox.Font, foreBrush, textRegion, sf );
			
			ControlPaint.DrawBorder3D( g, controlBounds, Border3DStyle.Sunken );

			Rectangle buttonBounds = controlBounds;
			buttonBounds.Inflate( -2, -2 );

			ControlPaint.DrawComboButton( 
				g, 
				buttonBounds.X + ( controlBounds.Width - 20 ), 
				buttonBounds.Y, 
				16, 
				17, 
				ButtonState.Normal );
		}

		private void ComboBox_SizeChanged(object sender, EventArgs e) 
		{
			this.ControlSize = m_comboBox.Size;
			this.Width = this.GetPreferredSize( null, null ).Width;
			this.Invalidate();
		}

		private Rectangle GetControlBounds( Rectangle cellBounds ) 
		{
			Rectangle controlBounds = new Rectangle( 
				cellBounds.X + this.Padding.Left, 
				cellBounds.Y + this.Padding.Top, 
				this.ControlSize.Width,
				this.ControlSize.Height );

			return controlBounds;
		}

		#region The rest of the DataGridColumnStyle methods

		protected override int GetMinimumHeight() {
			return GetPreferredHeight( null, null );
		}

		protected override int GetPreferredHeight(System.Drawing.Graphics g, object value) {
			return this.ControlSize.Height + this.Padding.Top + this.Padding.Bottom;
		}

		protected override System.Drawing.Size GetPreferredSize(System.Drawing.Graphics g, object value) {
			
			int width = this.ControlSize.Width + this.Padding.Left + this.Padding.Right;
			int height = this.ControlSize.Height + this.Padding.Top + this.Padding.Bottom;

			return new Size( width, height );

		}

		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, CurrencyManager source, int rowNum) {
			this.Paint( g, bounds, source, rowNum, false );
		}

		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight) {
			this.Paint( g, bounds, source, rowNum, Brushes.White, Brushes.Black, false );
		}

		#endregion The rest of the DataGridColumnStyle methods


	}

}	