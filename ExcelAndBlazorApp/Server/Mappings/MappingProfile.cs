using AutoMapper;
using ExcelAndBlazorApp.Entities;
using ExcelAndBlazorApp.Shared.Dtos;
using Microsoft.AspNetCore.Routing.Constraints;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Contract, ContractDto>().ReverseMap();

		CreateMap<Employee, EmployeeDto>().ReverseMap();

		CreateMap<WorkLog, WorkLogDto>().ReverseMap();

		CreateMap<Order, OrderDto>().ReverseMap();

		CreateMap<OrderItemDto, OrderItem>().ReverseMap();
	}
}