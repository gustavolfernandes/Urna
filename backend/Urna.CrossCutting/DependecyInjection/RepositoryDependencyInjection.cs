using Urna.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Urna.Data.Repositories;

namespace Urna.CrossCutting.DependecyInjection
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<IVoteRepository, VoteRepository>();

            return services;
        }
    }
}
