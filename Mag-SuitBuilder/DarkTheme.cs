using System.Drawing;
using System.Windows.Forms;

namespace Mag_SuitBuilder
{
	// Soft dim: toned-down classic WinForms grays, not a high-contrast dark theme.
	internal static class DarkTheme
	{
		public static readonly Color WindowBack = Color.FromArgb(228, 228, 231);
		public static readonly Color SurfaceBack = Color.FromArgb(242, 242, 245);
		public static readonly Color SurfaceAltBack = Color.FromArgb(234, 235, 239);
		public static readonly Color InputBack = Color.FromArgb(250, 250, 252);
		public static readonly Color TextFore = Color.FromArgb(30, 30, 30);
		public static readonly Color GridLine = Color.FromArgb(206, 206, 212);
		public static readonly Color SelectionBack = Color.FromArgb(51, 153, 255);
		public static readonly Color SelectionFore = Color.White;

		public static void ApplyToForm(Form form)
		{
			form.BackColor = WindowBack;
			form.ForeColor = TextFore;
			Apply(form);
		}

		static void Apply(Control control)
		{
			foreach (Control child in control.Controls)
				ApplyControl(child);

			if (control is ContextMenuStrip contextMenu)
				ApplyContextMenu(contextMenu);
			else if (control is MenuStrip menuStrip)
				ApplyContextMenu(menuStrip);
		}

		static void ApplyControl(Control control)
		{
			control.ForeColor = TextFore;

			switch (control)
			{
				case Button:
					// Keep native Windows button chrome.
					break;
				case TextBox textBox:
					textBox.BackColor = InputBack;
					textBox.BorderStyle = BorderStyle.FixedSingle;
					break;
				case ComboBox comboBox:
					comboBox.BackColor = InputBack;
					comboBox.FlatStyle = FlatStyle.System;
					break;
				case CheckBox checkBox:
					checkBox.BackColor = WindowBack;
					checkBox.UseVisualStyleBackColor = true;
					break;
				case RadioButton radioButton:
					radioButton.BackColor = WindowBack;
					radioButton.UseVisualStyleBackColor = true;
					break;
				case Label:
					control.BackColor = Color.Transparent;
					break;
				case DataGridView dataGridView:
					ApplyDataGridView(dataGridView);
					break;
				case TreeView treeView:
					treeView.BackColor = InputBack;
					treeView.BorderStyle = BorderStyle.Fixed3D;
					break;
				case TabControl tabControl:
					tabControl.BackColor = WindowBack;
					foreach (TabPage tabPage in tabControl.TabPages)
					{
						tabPage.BackColor = WindowBack;
						tabPage.ForeColor = TextFore;
						tabPage.UseVisualStyleBackColor = true;
					}
					break;
				case TabPage tabPage:
					tabPage.BackColor = WindowBack;
					tabPage.UseVisualStyleBackColor = true;
					break;
				case Panel panel:
					panel.BackColor = WindowBack;
					break;
				case SplitContainer splitContainer:
					splitContainer.BackColor = WindowBack;
					break;
				case UserControl userControl:
					userControl.BackColor = WindowBack;
					break;
				case GroupBox groupBox:
					groupBox.BackColor = WindowBack;
					groupBox.ForeColor = TextFore;
					break;
				case ContextMenuStrip contextMenu:
					ApplyContextMenu(contextMenu);
					break;
				default:
					if (control is not DataGridView)
						control.BackColor = IsInputControl(control) ? InputBack : WindowBack;
					break;
			}

			if (control.HasChildren)
				Apply(control);
		}

		static bool IsInputControl(Control control)
		{
			return control is TextBox or ComboBox or TreeView or ListBox or NumericUpDown;
		}

		static void ApplyDataGridView(DataGridView dataGridView)
		{
			dataGridView.EnableHeadersVisualStyles = true;
			dataGridView.BackgroundColor = SurfaceBack;
			dataGridView.GridColor = GridLine;
			dataGridView.BorderStyle = BorderStyle.Fixed3D;

			var cellStyle = new DataGridViewCellStyle
			{
				BackColor = SurfaceBack,
				ForeColor = TextFore,
				SelectionBackColor = SelectionBack,
				SelectionForeColor = SelectionFore,
			};
			dataGridView.DefaultCellStyle = cellStyle;
			dataGridView.RowsDefaultCellStyle = cellStyle;

			var altStyle = new DataGridViewCellStyle(cellStyle)
			{
				BackColor = SurfaceAltBack,
			};
			dataGridView.AlternatingRowsDefaultCellStyle = altStyle;
		}

		static void ApplyContextMenu(ToolStrip toolStrip)
		{
			toolStrip.RenderMode = ToolStripRenderMode.System;
			toolStrip.BackColor = SystemColors.Menu;
			toolStrip.ForeColor = SystemColors.MenuText;
		}
	}
}
