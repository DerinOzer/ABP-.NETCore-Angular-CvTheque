using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Simphonis.CvTheque.Candidates
{
    internal static class CandidateQueryableExtensions
    {
        public static IQueryable<Candidate> IncludeDetails(
            this IQueryable<Candidate> queryable,
            bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.CandidateSkills);
        }


    }
}
