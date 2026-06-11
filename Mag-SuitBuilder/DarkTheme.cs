using System.Drawing;
using System.Windows.Forms;

namespace Mag_SuitBuilder
{
	internal static class DarkTheme
	{
		public static readonly Color WindowBack = Color.FromArgb(32, 32, 32);
		public static readonly Color ControlBack = Color.FromArgb(45, 45, 48);
		public static readonly Color ControlFore = Color.FromArgb(241, 241, 241);
		public static readonly Color Border = Color.FromArgb(70, 70, 70);
		public static readonly Color GridAlt = Color.FromArgb(50, 50, 50);
		public static readonly Color GridLine = Color.FromArgb(64, 64, 64);
		public static readonly Color Selection = Color.FromArgb(0, 120, 215);

		public static void ApplyToForm(Form form)
		{
			form.BackColor = WindowBack;
			form.ForeColor = ControlFore;
			Apply(form);
		}

		public static void ApplyToControl(Control control)
		{
			control.BackColor = WindowBack;
			control.ForeColor = ControlFore;
			Apply(control);
		}

		static void Apply(Control control)
		{
			foreach (Control child in control.Controls)
				ApplyControl(child);

			if (control is ContextMenuStrip contextMenu)
				ApplyToolStrip(contextMenu);
			else if (control is MenuStrip menuStrip)
				ApplyToolStrip(menuStrip);
		}

		static void ApplyControl(Control control)
		{
			control.ForeColor = ControlFore;

			switch (control)
			{
				case Button button:
					button.FlatStyle = FlatStyle.Flat;
					button.FlatAppearance.BorderColor = Border;
					button.BackColor = Color.FromArgb(60, 60, 60);
					break;
				case TextBox textBox:
					textBox.BorderStyle = BorderStyle.FixedSingle;
					textBox.BackColor = ControlBack;
					break;
				case ComboBox comboBox:
					comboBox.FlatStyle = FlatStyle.Flat;
					comboBox.BackColor = ControlBack;
					break;
				case CheckBox checkBox:
					checkBox.BackColor = WindowBack;
					break;
				case Label label:
					label.BackColor = Color.Transparent;
					break;
				case DataGridView dataGridView:
					ApplyDataGridView(dataGridView);
					break;
				case TreeView treeView:
					treeView.BackColor = ControlBack;
					treeView.BorderStyle = BorderStyle.FixedSingle;
					break;
				case TabControl tabControl:
					tabControl.BackColor = WindowBack;
					foreach (TabPage tabPage in tabControl.TabPages)
					{
						tabPage.BackColor = WindowBack;
						tabPage.ForeColor = ControlFore;
					}
					break;
				case TabPage tabPage:
					tabPage.BackColor = WindowBack;
					break;
				case Panel panel:
					panel.BackColor = WindowBack;
					break;
				case SplitContainer splitContainer:
					splitContainer.BackColor = Border;
					break;
				case UserControl userControl:
					userControl.BackColor = WindowBack;
					break;
				case ContextMenuStrip contextMenu:
					ApplyToolStrip(contextMenu);
					break;
				default:
					if (!(control is DataGridView))
						control.BackColor = control is TextBox or ComboBox or TreeView ? ControlBack : WindowBack;
					break;
			}

			if (control.HasChildren)
				Apply(control);
		}

		static void ApplyDataGridView(DataGridView dataGridView)
		{
			dataGridView.EnableHeadersVisualStyles = false;
			dataGridView.BackgroundColor = ControlBack;
			dataGridView.GridColor = GridLine;
			dataGridView.BorderStyle = BorderStyle.None;

			var cellStyle = new DataGridViewCellStyle
			{
				BackColor = ControlBack,
				ForeColor = ControlFore,
				SelectionBackColor = Selection,
				SelectionForeColor = ControlFore,
			};
			dataGridView.DefaultCellStyle = cellStyle;
			dataGridView.RowsDefaultCellStyle = cellStyle;

			var altStyle = new DataGridViewCellStyle(cellStyle)
			{
				BackColor = GridAlt,
			};
			dataGridView.AlternatingRowsDefaultCellStyle = altStyle;

			var headerStyle = new DataGridViewCellStyle
			{
				BackColor = Color.FromArgb(55, 55, 55),
				ForeColor = ControlFore,
				SelectionBackColor = Color.FromArgb(55, 55, 55),
				SelectionForeColor = ControlFore,
			};
			dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
			dataGridView.RowHeadersDefaultCellStyle = headerStyle;
		}

		static void ApplyToolStrip(ToolStrip toolStrip)
		{
			toolStrip.BackColor = ControlBack;
			toolStrip.ForeColor = ControlFore;
			toolStrip.Renderer = new DarkToolStripRenderer();
			foreach (ToolStripItem item in toolStrip.Items)
				ApplyToolStripItem(item);
		}

		static void ApplyToolStripItem(ToolStripItem item)
		{
			item.BackColor = ControlBack;
			item.ForeColor = ControlFore;

			if (item is ToolStripMenuItem menuItem && menuItem.HasDropDownItems)
			{
				menuItem.DropDown.BackColor = ControlBack;
				menuItem.DropDown.ForeColor = ControlFore;
				foreach (ToolStripItem subItem in menuItem.DropDownItems)
					ApplyToolStripItem(subItem);
			}
		}
	}

	internal sealed class DarkToolStripRenderer : ToolStripProfessionalRenderer
	{
		public DarkToolStripRenderer() : base(new DarkColorTable()) { }
	}

	internal sealed class DarkColorTable : ProfessionalColorTable
	{
		public override Color MenuItemSelected => Color.FromArgb(70, 70, 70);
		public override Color MenuItemSelectedGradientBegin => Color.FromArgb(70, 70, 70);
		public override Color MenuItemSelectedGradientEnd => Color.FromArgb(70, 70, 70);
		public override Color MenuItemBorder => Color.FromArgb(90, 90, 90);
		public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 48);
		public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 48);
		public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 48);
		public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 48);
	}
}
