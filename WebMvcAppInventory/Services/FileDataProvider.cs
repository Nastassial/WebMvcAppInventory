
using WebMvcAppInventory.Models;
using WebMvcAppInventory.Services.Interfaces;
using System.Text.Json;

namespace WebMvcAppInventory.Services;

public class FileDataProvider : IDataProvider
{
    private readonly string _outputFileName;

    public FileDataProvider(string outputFileName)
    {
        _outputFileName = outputFileName;
    }

    public void Clear()
    {
        if (File.Exists(_outputFileName)) 
        {
            File.Delete(_outputFileName);
        }
    }

    public void Save(List<ProductModel> productList)
    {
        File.WriteAllText(_outputFileName, JsonSerializer.Serialize(productList));
    }

    public List<ProductModel> Load()
    {
        if (File.Exists(_outputFileName))
        {
            string fileContext = File.ReadAllText(_outputFileName);

            if (string.IsNullOrEmpty(fileContext))
            {
                return new List<ProductModel>();
            }

            return JsonSerializer.Deserialize<List<ProductModel>>(fileContext) ?? new List<ProductModel>();
        }

        File.Create(_outputFileName);

        return new List<ProductModel>();
    }
}
