using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;
using System.Diagnostics.Metrics;
using AutoMapper;

namespace Project_NetCore_MongoDB.AutoMapper
{
    public class DataAM:Profile
    {
        public DataAM()
        {
            CreateMap<Products, ProductsDto>();

            CreateMap<Categories, CategoriesDto>();
            CreateMap<CategoriesDto, Categories>();

            CreateMap<Users, UsersDto>();
            CreateMap<UsersDto, Users>();

            CreateMap<RolesName,RolesDto>();

            CreateMap<Articles, ArticlesDto>();
            CreateMap<ArticlesDto, Articles>();

            CreateMap<Comments, CommentsDto>();
            CreateMap<CommentsDto, Comments>();
        }
    }
}
