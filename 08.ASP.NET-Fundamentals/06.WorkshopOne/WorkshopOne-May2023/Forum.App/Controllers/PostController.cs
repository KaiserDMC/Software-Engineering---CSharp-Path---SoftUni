namespace Forum.App.Controllers;

using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;
using ViewModels.Post;

public class PostController : Controller
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<PostListViewModel> allPosts = await this.postService.ListAllAsync();

        return View(allPosts);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await this.postService.AddPostAsync(model);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your post!");

            return View(model);
        }

        return RedirectToAction("All", "Post");
    }

    public async Task<IActionResult> Edit(string id)
    {
        try
        {
            PostFormModel postModel = await this.postService.GetForEditOrDeleteByIdAsync(id);

            return View(postModel);
        }
        catch (Exception)
        {
            return this.RedirectToAction("All", "Post");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, PostFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return this.View(model);
        }

        try
        {
            await this.postService.EditByIdAsync(id, model);
        }
        catch (Exception)
        {
            ModelState.AddModelError(String.Empty, "Unexpected error occurred while updating your post!");

            return View(model);
        }

        return RedirectToAction("All", "Post");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await this.postService.DeleteByIdAsync(id);
        }
        catch (Exception)
        {

        }

        return RedirectToAction("All", "Post");
    }

    public async Task<IActionResult> DeleteView(string id)
    {
        try
        {
            PostFormModel postModel = await this.postService.GetForEditOrDeleteByIdAsync(id);

            return View(postModel);
        }
        catch (Exception)
        {
            return this.RedirectToAction("All", "Post");
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteView(string id, PostFormModel model)
    {
        try
        {
            await this.postService.DeleteByIdAsync(id);
        }
        catch (Exception)
        {
            ModelState.AddModelError(String.Empty, "Unexpected error occurred while deleting your post!");

            return View(model);
        }

        return RedirectToAction("All", "Post");
    }
}