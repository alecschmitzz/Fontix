using AutoMapper;
using Fontix.DAL.Entities;

namespace Fontix.DAL;

public class AutoMapperDALProfile : Profile
{
    public AutoMapperDALProfile()
    {
        /* EVENTS */
        // CreateMap<Event, Models.Event>()
        //     .ForMember(dest => dest.Id, act => act.MapFrom(src => src.id))
        //     .ForMember(dest => dest.OrganisationId, act => act.MapFrom(src => src.organisation_id))
        //     .ForMember(dest => dest.Name, act => act.MapFrom(src => src.name))
        //     .ForMember(dest => dest.Description, act => act.MapFrom(src => src.description))
        //     .ForMember(dest => dest.Tickets, act => act.MapFrom(src => src.Tickets));

        // CreateMap<Event, Models.Event>()
        //     .ConstructUsing(src => src.ConvertToModel());
        //
        // CreateMap<Fontix.Models.Event, Event>()
        //     .ConstructUsing(src => new Event(src.Id, src.OrganisationId, src.Name, src.Description, null));

        // CreateMap<Models.Event, Event>()
        //     .ForMember(dest => dest.id, act => act.MapFrom(src => src.Id))
        //     .ForMember(dest => dest.organisation_id, act => act.MapFrom(src => src.OrganisationId))
        //     .ForMember(dest => dest.name, act => act.MapFrom(src => src.Name))
        //     .ForMember(dest => dest.description, act => act.MapFrom(src => src.Description))
        //     .ForMember(dest => dest.Tickets, act => act.MapFrom(src => src.Tickets));

        /* ORGANISATIONS */
        // CreateMap<Organisation, Models.Organisation>()
        //     .ConstructUsing(src => src.ConvertToModel());
        //
        // CreateMap<Fontix.Models.Organisation, Organisation>()
        //     .ConstructUsing(src => new Organisation(src.Id, src.Name, null));


        /*TICKETS*/
        // CreateMap<Ticket, Models.Ticket>()
        //     .ConstructUsing(src => src.ConvertToModel());
        //
        // CreateMap<Fontix.Models.Ticket, Ticket>()
        //     .ConstructUsing(src => new Ticket(src.Id, src.Name, src.EventId, src.Price, src.DatetimeStart,
        //         src.DatetimeEnd,
        //         src.DatetimeView, src.Amount));


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