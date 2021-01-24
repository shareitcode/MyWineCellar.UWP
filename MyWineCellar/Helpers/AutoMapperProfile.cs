using AutoMapper;
using MyWineCellar.Converters;
using MyWineCellar.DTO;
using MyWineCellar.Models;

namespace MyWineCellar.Helpers
{
	internal sealed class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			this.CreateMap<AddWineModel, WineDto>().ForMember(dm => dm.AcquisitionDate, mo => mo.MapFrom(me => me.AcquisitionDate.DateTime));
			this.CreateMap<WineDto, WineListModel>().ForMember(dm => dm.Image, mo => mo.ConvertUsing(new ByteArrayToImageSourceConverter(), src => src.Image));
		}
	}
}