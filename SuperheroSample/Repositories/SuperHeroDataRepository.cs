using System.Data.Common;
using Dapper;
using Microsoft.Data.Sqlite;
namespace SuperheroSample.Repositories;

public interface ISuperHeroDataRepository
{
    Task<SuperHero?> GetSuperHeroByNameAsync(string name);
}

public class SuperHeroDataRepository: ISuperHeroDataRepository
{
    private readonly DbConnection _connection;
    public SuperHeroDataRepository()
    {
        _connection = new SqliteConnection("AppData/Superhero.db");
    }

    public Task<SuperHero?> GetSuperHeroByNameAsync(string name)
    {
        return _connection.QueryFirstOrDefaultAsync<SuperHero>("SELECT * FROM SuperHero WHERE Name ilike '%' | @Name | '%'", new { Name = name });
    }
}

public record SuperHero(int Id, string Name, string EyeColor, string HairColor, int AppearanceCount, string FirstAppearance, string FirstAppearanceYear); 