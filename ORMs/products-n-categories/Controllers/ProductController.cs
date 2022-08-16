using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{
  // MyContext class for db querying
  private MyContext _db;

  public ProductController(MyContext context)
  {
    _db = context;
  }

  // displays dashboard and gets ALL products from database
  [HttpGet("")]
  [HttpGet("/products")]
  public IActionResult Dashboard()
  {
    // get all existing products and new product form
    List<Product> AllProducts = _db.Products.ToList();
    return View("Dashboard", AllProducts);
  }

  // post request for adding products to database
  [HttpPost("/products")]
  public IActionResult Create(Product newProduct)
  {
    // validation for if product already in database
    if (_db.Products.Any(c => c.Name == newProduct.Name))
    {
      ModelState.AddModelError("Name", " already exists");
      return Dashboard();
    }

    // runs model validations -> returns to dashboard if errors are found
    if (ModelState.IsValid == false)
    {
      return Dashboard();
    }

    // adds to database
    _db.Products.Add(newProduct);
    _db.SaveChanges();
    return RedirectToAction("Dashboard");
  }

  //get ONE product from database and display details page for it
  [HttpGet("/products/{productId}")]
  public IActionResult Details(int productId)
  {
    // Product? oneProduct = _db.Products.FirstOrDefault(p => p.ProductId == productId);
    Product? product = _db.Products
      .Include(p => p.AssociatedCategories)
      .ThenInclude(c => c.Category)
      .FirstOrDefault(p => p.ProductId == productId);

    // get all unrelated categories and create new list for viewbag to populate form
    if (product != null)
    {
      List<Category> unrelated = _db.Categories
        .Include(c => c.AssociatedProducts)
        .Where( c => c.AssociatedProducts
          .All(cp => cp.ProductId != product.ProductId)
        )
        .ToList();
      ViewBag.categories = unrelated;
    }

    return View("Details", product);
  }

  // create -> add related category to product
  [HttpPost("/products/addCategory")]
  public IActionResult AddCategoryToProduct(int productId, int categoryId)
  {
    // does nothing if button is clicked when option has not been selected -> redirects to product page
    if (categoryId == 0) {
      return Redirect("~/products/" + productId);
    }
    Association category = new Association { ProductId = productId, CategoryId = categoryId };
    _db.Associations.Add(category);
    _db.SaveChanges();
    return Redirect("~/products/" + productId);
  }
}