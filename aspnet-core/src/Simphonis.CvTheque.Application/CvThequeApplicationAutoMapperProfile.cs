
using Simphonis.CvTheque.Entities;
using AutoMapper;

namespace Simphonis.CvTheque
{
    public class CvThequeApplicationAutoMapperProfile : Profile
    {
        public CvThequeApplicationAutoMapperProfile()
        {
            CreateMap<Candidate, CandidateDto>();
            CreateMap<CreateCandidateDto, Candidate>();
            CreateMap<UpdateCandidateDto, Candidate>();
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
        }
    }
}


