using AutoMapper;
using PMISBLayer.DTO;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InsertProjectDTO, Project>()
                .ForMember(des => des.EndDate, opt => opt.MapFrom(s => s.StartDate))
                .ForMember(des => des.ContractFile, opt => opt.Ignore());




            CreateMap<ProjectPhaseDTO, Project>();
            CreateMap<Project, ProjectPhaseDTO>();

            CreateMap<ProjectPhaseDTO, ProjectPhase>();

            CreateMap<ProjectPhase, ProjectPhaseDTO>()
                .ForMember(d=>d.PhaseName,s=>s.MapFrom(x=>x.Phase.PhaseName));

            CreateMap<Deliverable, DeliverableDTO>();

            CreateMap<PaymentTerm, InvoicePaymentTermsDTO>();

            CreateMap<InvoicePaymentTerm, InvoicePaymentTermsDTO>();


        }
    }
}
