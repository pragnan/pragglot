﻿using System.Collections.Generic;
using AutoMapper;
using Restaurant.Common.DataTransferObjects;
using Restaurant.Server.Api.Models;
using Restaurant.Server.Api.Constants;

namespace Restaurant.Server.Api.Mappers
{
	public class RestaurantModelsToDtoProfile : Profile
	{
		public RestaurantModelsToDtoProfile()
		{
			CreateMap<DailyEatingDto, DailyEating>()
				.ForMember(x => x.TotalAmount, map => map.Ignore())
				.ForMember(x => x.Orders, map => map.MapFrom(x => Mapper.Map<ICollection<Order>>(x.Orders)));

			CreateMap<Food, FoodDto>()
				.ForMember(x => x.CategoryDto,
					map => map.MapFrom(x => Mapper.Map<CategoryDto>(x.Category)))
				.ForMember(x => x.Picture,
					map => map.MapFrom(x => Folders.UploadFilesPath + x.Picture));

			CreateMap<FoodDto, Food>()
				.ForMember(x => x.Category,
					map => map.MapFrom(x => Mapper.Map<Category>(x.CategoryDto)))
				.ForMember(x => x.Picture,
					map => map.MapFrom(x => x.Picture.Contains(Folders.UploadFilesPath) 
											? x.Picture.Replace(Folders.UploadFilesPath, "")
										    : x.Picture));

			CreateMap<Category, CategoryDto>();

			CreateMap<CategoryDto, Category>();

			CreateMap<Order, OrderDto>()
				.ForMember(x => x.OrderItems,
					map => map.MapFrom(x => Mapper.Map<IEnumerable<OrderItemDto>>(x.OrderItems)));

			CreateMap<OrderDto, Order>()
				.ForMember(x => x.OrderItems,
					map => map.MapFrom(x => Mapper.Map<ICollection<OrderItem>>(x.OrderItems)));

			CreateMap<OrderItem, OrderItemDto>();
			CreateMap<OrderItemDto, OrderItem>();
		}
	}
}
