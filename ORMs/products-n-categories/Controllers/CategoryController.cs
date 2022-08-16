using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CategoryController : Controller
{
  // MyContext class for db querying
  private MyContext _db;

  public CategoryController(MyContext context)
  {
    _db = context;
  }

  [HttpGet("/categories")]
  public IActionResult Dashboard()
  {
    // get all categories in db to display list
    List<Category> AllCategories = _db.Categories
      .Include(c => c.AssociatedProducts)
      .ThenInclude(p => p.Product).ToList();
    return View("Dashboard", AllCategories);
  }

  // post method for adding category to database
  [HttpPost("/categories")]
  public IActionResult Create(Category newCategory)
  {
    // validation for if category already in database
    if (_db.Categories.Any(c => c.Name == newCategory.Name))
    {
      ModelState.AddModelError("Name", " already exists");
      return Dashboard();
    }

    // runs model validations -> returns dashboard method if any errors are found
    if (ModelState.IsValid == false)
    {
      return Dashboard();
    }

    // no errors found, add category to database
    _db.Categories.Add(newCategory);
    _db.SaveChanges();
    return RedirectToAction("Dashboard");
  }

  //get ONE product from database and display details page for it
  [HttpGet("/categories/{categoryId}")]
  public IActionResult Details(int categoryId)
  {
    Category? category = _db.Categories
      .Include(c => c.AssociatedProducts)
      .ThenInclude(p => p.Product)
      .FirstOrDefault(c => c.CategoryId == categoryId);

    if (category != null)
    {
      List<Product> unrelated = _db.Products
        .Include(p => p.AssociatedCategories)
        .Where( p => p.AssociatedCategories
          .All(pc => pc.CategoryId != category.CategoryId)
        )
        .ToList();
      ViewBag.products = unrelated;
    }

    return View("Details", category);
  }

    [HttpPost("/categories/addProduct")]
  public IActionResult AddProductToCategory (int categoryId, int productId)
  {
    // does nothing if button is clicked when option has not been selected -> redirects to product page
    if (productId == 0) {
      return Redirect("~/categories/" + categoryId);
    }
    Association product = new Association { ProductId = productId, CategoryId = categoryId };
    _db.Associations.Add(product);
    _db.SaveChanges();
    return Redirect("~/categories/" + categoryId);
  }
}