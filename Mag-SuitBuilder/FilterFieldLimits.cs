using System.Windows.Forms;

namespace Mag_SuitBuilder
{
	// Raised from upstream Mag-SuitBuilder v2.1.4 defaults (999 armor, single-digit cantrip/rating caps).
	internal static class FilterFieldLimits
	{
		public const int ArmorLevelMaxLength = 6;
		public const int WieldMaxLength = 6;
		public const int QuantityMaxLength = 3;
		public const int RatingMaxLength = 4;

		public const string DefaultMaxArmorLevel = "5000";
		public const string DefaultMaxWield = "5000";
		public const string DefaultMaxQuantity = "99";
		public const string DefaultMaxRating = "999";

		public static void ConfigureNumericTextBox(TextBox textBox, int maxLength, int widthPx)
		{
			textBox.MaxLength = maxLength;
			textBox.Width = widthPx;
		}
	}
}
