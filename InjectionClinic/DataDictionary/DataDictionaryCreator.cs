using InjectionClinic.Contexts;

namespace InjectionClinic.DataDictionary;

using DataDictionaryGenerator;
using DataDictionaryGenerator.Outputs;

public class DataDictionaryCreator
{
    private readonly UserDBContext _dbContext;

    public DataDictionaryCreator(UserDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateDictionary()
    {
        var dictionary = DataDictionary.FromDbContext(_dbContext);
        
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktop, "Data dictionary.csv");
        var wordDocument = WordOutput.Generate(dictionary);
        wordDocument.Write(File.Open(filePath, FileMode.Create));
    }
}