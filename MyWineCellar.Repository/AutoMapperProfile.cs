using AutoMapper;
using MyWineCellar.DAL.Models;
using MyWineCellar.DTO;

namespace MyWineCellar.Repository
{
	internal sealed class AutoMapperProfile : Profile
	{
		public AutoMapperProfile() => this.CreateMap<Wine, WineDto>();
	}
}