using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyWineCellar.Models
{
	internal sealed class AddWineModel : INotifyDataErrorInfo
	{
		public long Id { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Enter a valid producer name")]
		public string Producer { get; set; }
		public string Country { get; set; }
		public string Region { get; set; }
		public string Appellation { get; set; }
		public string Parcel { get; set; }
		public short? Vintage { get; set; }
		public short? Quantity { get; set; }
		public short Color { get; set; }
		public double? Price { get; set; }
		public DateTimeOffset AcquisitionDate { get; set; } = DateTimeOffset.Now;
		public short AcquisitionMeans { get; set; }


		public Dictionary<string, ObservableCollection<ValidationResult>> Errors = new Dictionary<string, ObservableCollection<ValidationResult>>();
		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
		public bool HasErrors => Errors.Count > 0;
		public IEnumerable GetErrors([CallerMemberName] string propertyName = "")
		{
			return propertyName != null && Errors.ContainsKey(propertyName) ? Errors[propertyName] : new ObservableCollection<ValidationResult>();
		}

		public void Validate(object value, [CallerMemberName] string propertyName = "")
        {
			if (Errors.ContainsKey(propertyName))
            {
				Errors.Remove(propertyName);
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }

			var results = new ObservableCollection<ValidationResult>();
			var context = new ValidationContext(this, null, null) { MemberName = propertyName };
			Validator.TryValidateProperty(value, context, results);

			if (results.Count > 0)
            {
				if (!Errors.ContainsKey(propertyName))
                {
					Errors.Add(propertyName, new ObservableCollection<ValidationResult>());
					foreach(var result in results)
                    {
						Errors[propertyName].Add(new ValidationResult(result.ErrorMessage));
                    }
					ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                }
            }
        }
	}
}