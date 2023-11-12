using WebMvcAppInventory.Models;
using WebMvcAppInventory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebMvcAppInventory.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IStockService _stockService;

    public HomeController(ILogger<HomeController> logger, IStockService stockService)
    {
        _logger = logger;
        _stockService = stockService;
    }

    public IActionResult Index()
    {
        return View("Index", _stockService.GetProductList());
    }

    public IActionResult Edit()
    {
        return View("Edit", _stockService.GetProductList());
    }

    public IActionResult Error()
    {
        return View("Error", new ResultModel { Success = false, Message = "Something went wrong" });
    }

    [HttpPost]
    public IActionResult ClearStock()
    {
        _stockService.Clear();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddProduct([FromForm] ProductModel product)
    {
        ResultModel result = _stockService.Add(product);

        if (!result.Success)
        {
            return View("Error", result);
        }

        return RedirectToAction("Edit");
    }

    [HttpPost]
    public IActionResult DeleteProduct([FromForm] ProductActionDto product)
    {
        ResultModel result = _stockService.Remove(product);

        if (!result.Success)
        {
            return View("Error", result);
        }

        return RedirectToAction("Edit");
    }

    [HttpPost]
    public IActionResult AddProductCount([FromForm] ChangeProductCntDto product)
    {
        ResultModel result = _stockService.AddProductCount(product);

        if (!result.Success)
        {
            return View("../Shared/Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        return RedirectToAction("Edit");
    }

    [HttpPost]
    public IActionResult RemoveProductCount([FromForm] ChangeProductCntDto product)
    {
        ResultModel result = _stockService.RemoveProductCount(product);

        if (!result.Success)
        {
            return View("../Shared/Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        return RedirectToAction("Edit");
    }
}