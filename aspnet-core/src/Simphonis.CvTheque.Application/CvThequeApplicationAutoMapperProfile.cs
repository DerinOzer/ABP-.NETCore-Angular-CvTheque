using AutoMapper;
using Simphonis.CvTheque.Candidates;
using Simphonis.CvTheque.Documents;

namespace Simphonis.CvTheque
{
    public class CvThequeApplicationAutoMapperProfile : Profile
    {
        public CvThequeApplicationAutoMapperProfile()
        {
            CreateMap<Candidate, CandidateDto>();
            CreateMap<CreateCandidateDto, Candidate>();
            CreateMap<UpdateCandidateDto, Candidate>();
            CreateMap<Cv, CvDto>();
            CreateMap<SaveCvDto, Cv>();
            CreateMap<GetCvDto, Cv>();
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
        }
    }
}


