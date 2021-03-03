using System;

namespace MyWineCellar.Models
{
	internal sealed class AddWineModel : ModelBase
	{
		public long Id { get; set; }
		public string Producer { get; set; }
		public string ProducerErrorMessage { get; set; }
		public string Country { get; set; }
		public string CountryErrorMessage { get; set; }
		public string Region { get; set; }
		public string RegionErrorMessage { get; set; }
		public string Appellation { get; set; }
		public string AppellationErrorMessage { get; set; }
		public string Parcel { get; set; }
		public string ParcelErrorMessage { get; set; }
		public short? Vintage { get; set; }
		public string VintageErrorMessage { get; set; }
		public short? Quantity { get; set; }
		public string QuantityErrorMessage { get; set; }
		public short Color { get; set; }
		public string ColorErrorMessage { get; set; }
		public double? Price { get; set; }
		public DateTimeOffset AcquisitionDate { get; set; } = DateTimeOffset.Now;
		public short AcquisitionMeans { get; set; }
		public string AcquisitionMeansErrorMessage { get; set; }
		public byte[] Image { get; set; }
		public string ImageNameWithExtension { get; set; }
	}
}