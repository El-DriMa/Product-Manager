using AutoMapper;
using ProductManager.Server.Data;
using ProductManager.Server.Models;
using ProductManager.Server.Models.Domain;
using ProductManager.Server.Models.DTO;
using ProductManager.Server.Repositories;

namespace ProductManager.Server.Mappers
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
        }
    }
}
