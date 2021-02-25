using System;

namespace MyWineCellar.DAL.Models
{
	public sealed class Wine
	{
		public long Id { get; set; }
		public string Producer { get; set; }
		public string Country { get; set; }
		public string Region { get; set; }
		public string Appellation { get; set; }
		public string Parcel { get; set; }
		public short Vintage { get; set; }
		public short Quantity { get; set; }
		public short Color { get; set; }
		public double Price { get; set; }
		public DateTime AcquisitionDate { get; set; }
		public string AcquisitionMeans { get; set; }
	}
}