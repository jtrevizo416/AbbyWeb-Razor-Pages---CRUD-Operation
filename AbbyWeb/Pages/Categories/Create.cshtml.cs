using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;
[BindProperties]
public class CreateModel : PageModel
{
    [BindProperty]
    public Category Category { get; set; }
    private readonly ApplicationDbContext _db;

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {

    }



    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category created successfuly.";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
