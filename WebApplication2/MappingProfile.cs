using AutoMapper;
using WebApplication2.Models;
using WebApplication2.Models.Views;

namespace WebApplication2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookView>().ForMember(x => x.Series, opt => opt.Ignore());
        }
    }
}
