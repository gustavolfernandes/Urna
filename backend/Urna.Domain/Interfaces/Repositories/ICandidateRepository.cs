using System.Collections.Generic;
using System.Threading.Tasks;
using Urna.Domain.Entities;

namespace Urna.Domain.Interfaces.Repositories
{
    public interface ICandidateRepository
    {
        Task<List<Candidate>> Get();
        Task<Candidate> Post(Candidate model);
        Task<Candidate> Delete(int id);

    }
}
