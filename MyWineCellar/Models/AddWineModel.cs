using System;

namespace MyWineCellar.Models
{
	internal sealed class AddWineModel
	{
		public long Id { get; set; }
		public string Producer { get; set; }
		public string Country { get; set; }
		public string Region { get; set; }
		public string Appellation { get; set; }
		public string Parcel { get; set; }
		public short? Vintage { get; set; }
		public short? Quantity { get; set; }
		public short? Color { get; set; }
		public double? Price { get; set; }
		public DateTimeOffset AcquisitionDate { get; set; } = DateTimeOffset.Now;
		public string AcquisitionMeans { get; set; }
	}
}