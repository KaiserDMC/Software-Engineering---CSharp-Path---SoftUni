namespace Forum.Services.Interfaces;

using ViewModels.Post;

public interface IPostService
{
    Task<IEnumerable<PostListViewModel>> ListAllAsync();

    Task AddPostAsync(PostFormModel postFormModel);

    Task<PostFormModel> GetForEditOrDeleteByIdAsync(string id);

    Task EditByIdAsync(string id, PostFormModel postEditModel);

    Task DeleteByIdAsync(string id);
}