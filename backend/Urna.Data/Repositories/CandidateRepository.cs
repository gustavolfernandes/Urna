using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urna.Domain.Entities;
using Urna.Domain.Interfaces.Repositories;

namespace Urna.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {

        protected readonly DataContext context;
        public CandidateRepository(DataContext context)
        {
            this.context = context;

        }
        public async Task<List<Candidate>> Get()
        {
            var candidates = await context
                .Candidates
                .AsNoTracking()
                .ToListAsync();
            return candidates;
        }
        public async Task<Candidate> Post(Candidate model)
        {
            try
            {
                if (!context.Candidates.Any(u => u.Subtitle == model.Subtitle))
                {
                    model.RegisterDate = DateTime.Now.Date;
                    context.Candidates.Add(model);                   
                    await context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Candidate> Delete(
            int id)
        {
            var Candidate = await context
                .Candidates
                .FirstOrDefaultAsync(x => x.Id == id);
            try
            {
                context.Candidates.Remove(Candidate);
                await context.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
