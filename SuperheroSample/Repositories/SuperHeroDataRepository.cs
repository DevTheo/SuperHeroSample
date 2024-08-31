using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using Microsoft.Data.Sqlite;
namespace SuperheroSample.Repositories;

public interface ISuperHeroDataRepository
{
    Task<List<SuperHero>> GetSuperHeroesByNameAsync(string name);
    Task<SuperHero?> GetSuperHeroByIdAsync(int id);
}

[ExcludeFromCodeCoverage]
public class SuperHeroDataRepository: ISuperHeroDataRepository
{
    private const string SuperheroByIdSql = "SELECT * FROM SuperHeroes WHERE Id = @Id";
    private const string SearchForSuperheroesByNameSql = @"
        SELECT * 
        FROM SuperHeroes 
        WHERE LOWER(Name) like '%' || @Name || '%'";

    private DbConnection GetConnection()
    {
        var result = new SqliteConnection("datasource=AppData/Superheroes.db");
        result.Open();
        return result;
    }
    
    public async Task<List<SuperHero>> GetSuperHeroesByNameAsync(string name)
    {
        using var connection = GetConnection();
        return (await connection.QueryAsync<SuperHero>(SearchForSuperheroesByNameSql, new { Name = name.ToLower() }))
            .ToList();
    }

    public async Task<SuperHero?> GetSuperHeroByIdAsync(int id)
    {
        using var connection = GetConnection();
        return await  connection.QueryFirstOrDefaultAsync<SuperHero>(SuperheroByIdSql, new { Id = id });
    }
}

[ExcludeFromCodeCoverage]
public class SuperHero(long id, string name, string eye_color, string hair_color, long appearance_count, string first_appearance, string first_appearance_year)
{
    public long Id { get; } = id; 
    public string Name { get; } = name;
    public string EyeColor { get; } = eye_color;
    public string HairColor { get; } = hair_color;
    public long AppearanceCount { get; } = appearance_count;
    public string FirstAppearance { get; } = first_appearance;
    public string FirstAppearanceYear { get; } = first_appearance_year;
} 