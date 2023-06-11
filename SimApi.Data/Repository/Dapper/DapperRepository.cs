using SimApi.Base;
using SimApi.Data.Context;
using static Dapper.SqlMapper;

namespace SimApi.Data.Repository;

public class DapperRepository<TEntity> : IDapperRepository<TEntity> where TEntity : BaseModel
{
    protected readonly SimDapperDbContext dbContext;
    private bool disposed;

    public DapperRepository(SimDapperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void DeleteById(int id)
    {
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var query = $"DELETE FROM dbo.\"{typeof(TEntity).Name}\" WHERE \"Id\" = @Id";
            connection.Execute(query, new { Id = id });
            connection.Close();
        }
    }

    public List<TEntity> Filter(string sql)
    {
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            return connection.Query<TEntity>(sql).ToList();
        }
    }

    public List<TEntity> GetAll()
    {
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var query = $"SELECT * FROM dbo.\"{typeof(TEntity).Name}\"";
            return connection.Query<TEntity>(query).ToList();
        }
    }

    public TEntity GetById(int id)
    {
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var query = $"SELECT * FROM dbo.\"{typeof(TEntity).Name}\" WHERE \"Id\" = @Id";
            return connection.QuerySingleOrDefault<TEntity>(query, new { Id = id });
        }
    }

    public void Insert(TEntity entity)
    {
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var properties = typeof(TEntity).GetProperties().Where(p => p.Name != "Id" && p.GetValue(entity) != null);
            var columns = string.Join(", ", properties.Select(p => $"\"{p.Name}\""));
            var paramNames = string.Join(", ", properties.Select(p => $"@{p.Name}"));
            var query = $"INSERT INTO dbo.\"{typeof(TEntity).Name}\" ({columns}) VALUES ({paramNames})";
            connection.Execute(query, entity);
        }
    }

    public void Update(TEntity entity)
    {
        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            var updateColumns = string.Join(", ", typeof(TEntity).GetProperties()
                .Where(p => p.Name != "Id" && p.GetValue(entity) != null) // Sadece null olmayan attributeleri al
                .Select(p => $"\"{p.Name}\" = @{p.Name}"));
            var query = $"UPDATE dbo.\"{typeof(TEntity).Name}\" SET {updateColumns} WHERE \"Id\" = @Id";
            connection.Execute(query, entity);
        }
    }
}