namespace WebMvcAppInventory.Models;

public class ProductListDto
{
    public List<ProductModel> products { get; set; }

    public int Count { get; set; }

    public decimal CommonCost { get; set; }
}
