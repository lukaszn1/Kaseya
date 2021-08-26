using Microsoft.Extensions.Caching.Memory;

namespace CodeChallenge.Infrastructure.Persistence
{
    public class CodeChallengeMemoryCache
    {
        public MemoryCache Cache { get; set; }

        public CodeChallengeMemoryCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions());
        }
    }
}
