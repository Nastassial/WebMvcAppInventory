using WebMvcAppInventory.Models;

namespace WebMvcAppInventory.Services.Interfaces;

public interface IStockService
{
    ResultModel Remove(ProductActionDto productActionDto);

    ResultModel Remove(ProductModel product);

    ResultModel Add(ProductModel product);

    void Clear();

    ProductModel? GetProduct(ProductActionDto getProductDto);

    ProductListDto GetProductList();

    ResultModel AddProductCount(ChangeProductCntDto productDto);

    ResultModel RemoveProductCount(ChangeProductCntDto productDto);

    void Save();
}
