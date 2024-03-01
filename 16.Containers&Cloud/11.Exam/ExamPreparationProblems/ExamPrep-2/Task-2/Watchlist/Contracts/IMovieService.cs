using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllAsync();

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task AddMovieAsync(AddMovieViewModel model);

        Task AddMovieToCollectionAsync(int movieId, string userId);

        Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

        Task RemoveMovieFromCollectionAsync(int movieId, string userId);
    }
}
