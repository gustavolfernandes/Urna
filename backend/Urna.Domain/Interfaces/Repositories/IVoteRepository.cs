using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Urna.Domain.Entities;

namespace Urna.Domain.Interfaces.Repositories
{
    public interface IVoteRepository
    {
        Task<List<Vote>> Get();
        Task<List<Vote>> GetByCandidateId(int id);
        Task<Vote> Post(Vote model);
    }
}
