using AutoMapper;
using Fontix.DAL.Entities;

namespace Fontix.DAL;

public class AutoMapperDALProfile : Profile
{
    public AutoMapperDALProfile()
    {
        /* EVENTS */
        CreateMap<Event, Models.Event>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.OrganiserId, act => act.MapFrom(src => src.organiser_id))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.name))
            .ForMember(dest => dest.Description, act => act.MapFrom(src => src.description))
            .ForMember(dest => dest.Tickets, act => act.MapFrom(src => src.Tickets));

        CreateMap<Models.Event, Event>()
            .ForMember(dest => dest.id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.organiser_id, act => act.MapFrom(src => src.OrganiserId))
            .ForMember(dest => dest.name, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.description, act => act.MapFrom(src => src.Description))
            .ForMember(dest => dest.Tickets, act => act.MapFrom(src => src.Tickets));

        /* ORGANISERS */
        CreateMap<Organiser, Models.Organiser>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.name))
            .ForMember(dest => dest.Events, act => act.MapFrom(src => src.Events));

        CreateMap<Models.Organiser, Organiser>()
            .ForMember(dest => dest.id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.Events, act => act.MapFrom(src => src.Events));


        /*TICKETS*/
        CreateMap<Ticket, Models.Ticket>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.name))
            .ForMember(dest => dest.EventId, act => act.MapFrom(src => src.event_id))
            .ForMember(dest => dest.Price, act => act.MapFrom(src => src.price))
            .ForMember(dest => dest.DatetimeStart, act => act.MapFrom(src => src.datetime_start))
            .ForMember(dest => dest.DatetimeEnd, act => act.MapFrom(src => src.datetime_end))
            .ForMember(dest => dest.DatetimeView, act => act.MapFrom(src => src.datetime_view))
            .ForMember(dest => dest.Amount, act => act.MapFrom(src => src.amount));

        CreateMap<Models.Ticket, Ticket>()
            .ForMember(dest => dest.id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.event_id, act => act.MapFrom(src => src.EventId))
            .ForMember(dest => dest.price, act => act.MapFrom(src => src.Price))
            .ForMember(dest => dest.datetime_start, act => act.MapFrom(src => src.DatetimeStart))
            .ForMember(dest => dest.datetime_end, act => act.MapFrom(src => src.DatetimeEnd))
            .ForMember(dest => dest.datetime_view, act => act.MapFrom(src => src.DatetimeView))
            .ForMember(dest => dest.amount, act => act.MapFrom(src => src.Amount));


        /* USER */
        CreateMap<User, Models.User>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.NameFirst, act => act.MapFrom(src => src.name_first))
            .ForMember(dest => dest.NameLast, act => act.MapFrom(src => src.name_last))
            .ForMember(dest => dest.UserPwd, act => act.MapFrom(src => src.userpwd))
            .ForMember(dest => dest.Email, act => act.MapFrom(src => src.email))
            .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => src.created_at))
            .ForMember(dest => dest.UpdatedAt, act => act.MapFrom(src => src.updated_at));

        CreateMap<Models.User, User>()
            .ForMember(dest => dest.name_first, act => act.MapFrom(src => src.NameFirst))
            .ForMember(dest => dest.name_last, act => act.MapFrom(src => src.NameLast))
            .ForMember(dest => dest.userpwd, act => act.MapFrom(src => src.UserPwd))
            .ForMember(dest => dest.email, act => act.MapFrom(src => src.Email));
    }
}