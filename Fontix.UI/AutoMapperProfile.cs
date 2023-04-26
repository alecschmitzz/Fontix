using AutoMapper;
using Fontix.UI.Models;

namespace Fontix.UI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /*EVENT*/
            CreateMap<Fontix.Models.Event, Event>();
            CreateMap<Event, Fontix.Models.Event>();

            /* USER */
            // CreateMap<Fontix.Models.User, User>();
            // CreateMap<User, Fontix.Models.User>();

            /* TICKET */
            CreateMap<Fontix.Models.Ticket, Ticket>();
            CreateMap<Ticket, Fontix.Models.Ticket>();
            
        }
    }
}