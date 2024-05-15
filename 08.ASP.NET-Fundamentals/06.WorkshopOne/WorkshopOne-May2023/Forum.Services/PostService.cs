namespace Forum.Services;

using Microsoft.EntityFrameworkCore;

using Data;
using Data.Models;
using Interfaces;
using ViewModels.Post;

public class PostService : IPostService
{
    private readonly ForumAppDbContext dbContext;

    public PostService(ForumAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
    {
        IEnumerable<PostListViewModel> allPosts = await dbContext
            .Posts
            .Select(p => new PostListViewModel()
            {
                Id = p.Id.ToString(),
                Title = p.Title,
                Content = p.Content
            })
            .ToArrayAsync();

        return allPosts;
    }

    public async Task AddPostAsync(PostFormModel postFormModel)
    {
        Post newPost = new Post()
        {
            Title = postFormModel.Title,
            Content = postFormModel.Content
        };

        await this.dbContext.AddAsync(newPost);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<PostFormModel> GetForEditOrDeleteByIdAsync(string id)
    {
        Post postToEdit = await this.dbContext.Posts.FirstAsync(p => p.Id.ToString() == id);

        return new PostFormModel()
        {
            Title = postToEdit.Title,
            Content = postToEdit.Content
        };
    }

    public async Task EditByIdAsync(string id, PostFormModel postEditModel)
    {
        Post postToEdit = await this.dbContext.Posts.FirstAsync(p => p.Id.ToString() == id);

        postToEdit.Title = postEditModel.Title;
        postToEdit.Content = postEditModel.Content;

        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(string id)
    {
        Post postToDelete = await this.dbContext.Posts.FirstAsync(p => p.Id.ToString() == id);

        this.dbContext.Posts.Remove(postToDelete);

        await this.dbContext.SaveChangesAsync();
    }
}