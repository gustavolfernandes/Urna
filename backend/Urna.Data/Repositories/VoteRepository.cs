using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urna.Domain.Entities;
using Urna.Domain.Interfaces.Repositories;

namespace Urna.Data.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        
            protected readonly DataContext context;
            public VoteRepository(DataContext context)
            {
                this.context = context;

            }

        public async Task<List<Vote>> Get()
        {
            var users = await context
                .Votes
                .AsNoTracking()
                .ToListAsync();
            return users;
        }
        public async Task<List<Vote>> GetByCandidateId(int id)
        {
            if (context.Candidates.Any(u => u.Id == id))
            {
                var votes = await context.Votes.Where(x => x.CandidateId == id).ToListAsync();
                return votes.ToList();
            }
            else
            {
                return null;
            }


        }
        public async Task<Vote> Post(Vote model)
        {
            if (context.Candidates.Any(u => u.Id == model.CandidateId))
            {
                try
                {
                    model.VoteDate = DateTime.Now.Date;
                    model.Nulo = false;
                    context.Votes.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else {
                model.Nulo = true;
                return model; 
            }         
        }
    }
  
}
