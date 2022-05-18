using AutoMapper;
using Simphonis.CvTheque.Candidates;

namespace Simphonis.CvTheque
{
    public class CvThequeApplicationAutoMapperProfile : Profile
    {
        public CvThequeApplicationAutoMapperProfile()
        {
            CreateMap<Candidate, CandidateDto>();
            CreateMap<CreateCandidateDto, Candidate>();
            CreateMap<UpdateCandidateDto, Candidate>();
            CreateMap<Skill, CandidateSkillDto>();
            CreateMap<CreateUpdateCandidateSkillDto, Skill>();
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
        }
    }
}


