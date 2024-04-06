using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AbbyWeb.Pages.Categories
{

    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        //[BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        //creating post handler 
        public async Task<IActionResult> onPost()
        { 
            if(ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
