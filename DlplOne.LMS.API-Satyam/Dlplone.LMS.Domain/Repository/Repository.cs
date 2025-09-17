using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dlplone.LMS.Domain.Infrastructure.Enums;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Dlplone.LMS.Domain
{
    public class Repository: ILPLRepository, IPartnerRepository,INRLHealthRepository
    {
		private readonly string connectionString;

		public Repository(IConfiguration configuration, string connectionStringName="Default")
		{
			this.connectionString = configuration.GetConnectionString(connectionStringName);
		}
        public Repository(IConfiguration configuration)
		{
			this.connectionString = configuration.GetConnectionString("Default");
		}
        
        public Repository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		private IDbConnection Connection
		{
			get
			{
				return new SqlConnection(connectionString);
			}
		}
    

        public async Task<int> AddAsync<T>(T item, string table, string schema)
        {
            var properties = typeof(T).GetProperties();
            using (IDbConnection dbConnection = Connection)
            {
                try
                {
                    StringBuilder sqlStatement = new StringBuilder();
                    sqlStatement.Append("Insert INTO " + schema + "." + table + "(");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append(prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Append(") VALUES(");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append("@" + prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Replace(";", "");
                    sqlStatement.Append(")");
                    dbConnection.Open();
                    await dbConnection.ExecuteAsync(sqlStatement.ToString(), item);
                    var Id = await dbConnection.ExecuteScalarAsync("SELECT IDENT_CURRENT('" + schema + "." + table + "')");
                    return int.Parse(Id.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);  
                    throw;
                }
            }
        }
        public async Task AddRangeAsync<T>(List<T> items, string table, string schema)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                // var tasks = new List<Task>();
                using (IDbConnection dbConnection = Connection)
                {
                    StringBuilder sqlStatement = new StringBuilder();
                    sqlStatement.Append("Insert INTO " + schema + "." + table + "(");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append(prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Append(") VALUES(");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append("@" + prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Replace(";", "");
                    sqlStatement.Append(")");
                    dbConnection.Open();
                    foreach (var item in items)
                    {
                        await dbConnection.ExecuteAsync(sqlStatement.ToString(), item);
                    }


                    //var Id = await dbConnection.ExecuteScalarAsync("SELECT IDENT_CURRENT('" + schema + "." + table + "')");
                    // return int.Parse(Id.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        public async Task AddRangeWithProcAsync<TP>(string proc, List<TP> parameterObjList, bool isText = true)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    foreach (var item in parameterObjList)
                    {
                        await dbConnection.QueryAsync<TP>(proc, item, commandType: isText ? CommandType.Text : CommandType.StoredProcedure);
                    }

                }

                //var Id = await dbConnection.ExecuteScalarAsync("SELECT IDENT_CURRENT('" + schema + "." + table + "')");
                // return int.Parse(Id.ToString());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public  int Add<T>(T item, string table, string schema)
        {
            try
            {

                var properties = typeof(T).GetProperties();
                using (IDbConnection dbConnection = Connection)
                {
                    StringBuilder sqlStatement = new StringBuilder();
                    sqlStatement.Append("Insert INTO " + schema + "." + table + "(");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append(prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Append(") VALUES(");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append("@" + prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Replace(";", "");
                    sqlStatement.Append(")");
                    dbConnection.Open();
                    dbConnection.Execute(sqlStatement.ToString(), item);
                    var Id = dbConnection.ExecuteScalar("SELECT IDENT_CURRENT('" + schema + "." + table + "')");
                    return int.Parse(Id.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void AddRange<T>(List<T> items, string table, string schema)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                using (IDbConnection dbConnection = Connection)
                {
                    StringBuilder sqlStatement = new StringBuilder();
                    sqlStatement.Append("Insert INTO " + schema + "." + table + "(");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append(prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Append(") VALUES(");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append("@" + prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Replace(";", "");
                    sqlStatement.Append(")");
                    dbConnection.Open();
                    foreach (var item in items)
                    {
                        dbConnection.Execute(sqlStatement.ToString(), item);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }  
        public async Task<int> UpdateAsync<T>(T item, string table, string schema)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                using (IDbConnection dbConnection = Connection)
                {
                    StringBuilder sqlStatement = new StringBuilder();
                    sqlStatement.Append("UPDATE " + schema + "." + table + "  SET ");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append(prop.Name + " = @" + prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Append(" where Id = @Id");
                    sqlStatement.Replace(";", "");
                    dbConnection.Open();
                    await dbConnection.ExecuteAsync(sqlStatement.ToString(), item);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }



        }
        public async Task UpdateRangeAsync<T>(List<T> items, string table, string schema)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                // var tasks = new List<Task>();
                using (IDbConnection dbConnection = Connection)
                {
                    StringBuilder sqlStatement = new StringBuilder();
                    sqlStatement.Append("UPDATE " + schema + "." + table + "  SET ");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append(prop.Name + " = @" + prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Append(" where Id = @Id");
                    sqlStatement.Replace(";", "");
                    dbConnection.Open();
                    foreach (var item in items)
                    {
                        await dbConnection.ExecuteAsync(sqlStatement.ToString(), item);
                    }
                    // await Task.WhenAll(tasks);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        public int Update<T>(T item, string table, string schema)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                using (IDbConnection dbConnection = Connection)
                {
                    StringBuilder sqlStatement = new StringBuilder();
                    sqlStatement.Append("UPDATE " + schema + "." + table + "  SET ");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append(prop.Name + " = @" + prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Append(" where Id = @Id");
                    sqlStatement.Replace(";", "");
                    dbConnection.Open();
                    dbConnection.Execute(sqlStatement.ToString(), item);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }



        }        
        public void UpdateRange<T>(List<T> items, string table, string schema)
        {
            try
            {
                var properties = typeof(T).GetProperties();
                using (IDbConnection dbConnection = Connection)
                {
                    StringBuilder sqlStatement = new StringBuilder();
                    sqlStatement.Append("UPDATE " + schema + "." + table + "  SET ");
                    foreach (var prop in properties)
                    {
                        if (prop.Name != "Id")
                            sqlStatement.Append(prop.Name + " = @" + prop.Name + ",");
                    }
                    sqlStatement.Length--;
                    sqlStatement.Append(" where Id = @Id");
                    sqlStatement.Replace(";", "");
                    dbConnection.Open();
                    foreach (var item in items)
                    {
                        dbConnection.Execute(sqlStatement.ToString(), item);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }



        }       
        public async Task<int> RemoveByParentIdAsync(int columnValue, string table, string schema, string columnName)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var res = await dbConnection.ExecuteAsync("DELETE FROM " + schema + "." + table + "  WHERE " + columnName + " = @Id", new { Id = columnValue });
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public int RemoveByParentId(int columnValue, string table, string schema, string columnName)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var res = dbConnection.Execute("DELETE FROM " + schema + "." + table + "  WHERE " + columnName + " = @Id", new { Id = columnValue });
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> RemoveAsync(int id, string table, string schema)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var res = await dbConnection.ExecuteAsync("DELETE FROM " + schema + "." + table + "  WHERE id = @Id", new { Id = id });
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public async Task<int> RemoveRangeAsync(List<int> ids, string table, string schema)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    foreach (var id in ids)
                    {
                        await dbConnection.ExecuteAsync("DELETE FROM " + schema + "." + table + "  WHERE id = @Id", new { Id = id });
                    }
                    return 1;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public int Remove(int id, string table, string schema)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var res = dbConnection.Execute("DELETE FROM " + schema + "." + table + "  WHERE id = @Id", new { Id = id });
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public int RemoveRange(List<int> ids, string table, string schema)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    foreach (var id in ids)
                    {
                        dbConnection.Execute("DELETE FROM " + schema + "." + table + "  WHERE id = @Id", new { Id = id });
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<T> FindByParentIdAsync<T>(int parentId, string table, string schema, string parentColumn)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryFirstOrDefaultAsync<T>("SELECT * FROM " + schema + "." + table + "  WHERE " + parentColumn + " = @Id", new { Id = parentId });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public T FindByParentId<T>(int parentId, string table, string schema, string parentColumn)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = dbConnection.QueryFirstOrDefault<T>("SELECT * FROM " + schema + "." + table + "  WHERE " + parentColumn + " = @Id", new { Id = parentId });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<T> FindByIdAsync<T>(int id, string table, string schema)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryFirstOrDefaultAsync<T>("SELECT * FROM " + schema + "." + table + "  WHERE id = @Id", new { Id = id });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }        
        public async Task<T> FindByIdAsync<T>(int id,string table, string schema ,string idName)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryFirstOrDefaultAsync<T>("SELECT * FROM " + schema + "." + table + "  WHERE "  + idName +" = @Id", new { Id = id });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }        
        public T FindById<T>(int id, string table, string schema)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = dbConnection.QueryFirstOrDefault<T>("SELECT * FROM " + schema + "." + table + "  WHERE id = @Id", new { Id = id });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IEnumerable<T>> FindAllAsync<T>(string table, string schema,bool asc=true)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryAsync<T>("SELECT * FROM " + schema + "." + table + " order by 1 " + (asc ? "" : "desc"));
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public  IEnumerable<T> FindAll<T>(string table, string schema,bool asc=true)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = dbConnection.Query<T>("SELECT * FROM " + schema + "." + table + " order by 1 " + (asc ? "" : "desc"));
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }       
        public async Task<IEnumerable<T>> FindRangeByParentIdAsync<T>(int columnValue, string table, string schema, string columnName)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryAsync<T>("SELECT * FROM " + schema + "." + table + "  WHERE " + columnName + " = @Id", new { Id = columnValue });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }        
        public IEnumerable<T> FindRangeByParentId<T>(int columnValue, string table, string schema, string columnName)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = dbConnection.Query<T>("SELECT * FROM " + schema + "." + table + "  WHERE " + columnName + " = @Id", new { Id = columnValue });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }           
        public IEnumerable<T> ExecuteRawSql<T,TP>(string proc, TP parameterObj, bool isText = true)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return  dbConnection.Query<T>(proc, parameterObj, commandType: isText ? CommandType.Text : CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null; //Activator.CreateInstance<List<T>>() as Task<IEnumerable<T>>;
            }
        }
        public async Task<IEnumerable<T>> ExecuteRawSqlAsync<T, TP>(string proc, TP parameterObj, bool isText = true)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return await dbConnection.QueryAsync<T>(proc, parameterObj, commandType: isText ? CommandType.Text : CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null; //Activator.CreateInstance<List<T>>() as Task<IEnumerable<T>>;
            }
        }
        public List<Object> ExecuteRawSql<T1, T2, T3, T4, T5, T6, T7, TP>(string proc, TP parameterObj, bool isText=true)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = dbConnection.QueryMultiple(proc, parameterObj, commandType: isText ? CommandType.Text : CommandType.StoredProcedure);
                    var lst = new List<Object>();
                    for (int i = 0; !result.IsConsumed; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                var to1 = result.Read<T1>();
                                lst.Add(to1);
                                break;
                            case 1:
                               var to2 = result.Read<T2>();
                                lst.Add(to2);
                                break;
                            case 2:
                                var to3 = result.Read<T3>();
                                lst.Add(to3);
                                break;
                            case 3:
                                var to4 = result.Read<T4>();
                                lst.Add(to4);
                                break;
                            case 4:
                                var to5 = result.Read<T5>();
                                lst.Add(to5);
                                break;
                            case 5:
                                var to6 = result.Read<T6>();
                                lst.Add(to6);
                                break;
                            case 6:
                                var to7 = result.Read<T7>();
                                lst.Add(to7);
                                break;

                            default:
                                break;
                        }
                    }

                    return lst;
                                                        
                   
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null; //Activator.CreateInstance<List<T>>() as Task<IEnumerable<T>>;
            }
        }
        public async Task<List<Object>> ExecuteRawSqlAsync<T1, T2, T3, T4, T5, T6, T7, TP>(string proc, TP parameterObj, bool isText = true)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryMultipleAsync(proc, parameterObj, commandType: isText ? CommandType.Text : CommandType.StoredProcedure);
                    var lst = new List<Object>();
                    for (int i = 0; !result.IsConsumed; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                var to1 = result.Read<T1>();
                                lst.Add(to1);
                                break;
                            case 1:
                                var to2 = result.Read<T2>();
                                lst.Add(to2);
                                break;
                            case 2:
                                var to3 = result.Read<T3>();
                                lst.Add(to3);
                                break;
                            case 3:
                                var to4 = result.Read<T4>();
                                lst.Add(to4);
                                break;
                            case 4:
                                var to5 = result.Read<T5>();
                                lst.Add(to5);
                                break;
                            case 5:
                                var to6 = result.Read<T6>();
                                lst.Add(to6);
                                break;
                            case 6:
                                var to7 = result.Read<T7>();
                                lst.Add(to7);
                                break;

                            default:
                                break;
                        }
                    }

                    return lst;


                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null; //Activator.CreateInstance<List<T>>() as Task<IEnumerable<T>>;
            }
        }
        public async Task<List<Object>> ExecuteRawSqlAsync<T1, T2, T3,TP>(string proc, TP parameterObj, bool isText = true)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryMultipleAsync(proc, parameterObj, commandType: isText ? CommandType.Text : CommandType.StoredProcedure);
                    var lst = new List<Object>();
                    for (int i = 0; !result.IsConsumed; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                var to1 = result.Read<T1>();
                                lst.Add(to1);
                                break;
                            case 1:
                                var to2 = result.Read<T2>();
                                lst.Add(to2);
                                break;
                            case 2:
                                var to3 = result.Read<T3>();
                                lst.Add(to3);
                                break;
                           default:
                                break;
                        }
                    }

                    return lst;


                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null; //Activator.CreateInstance<List<T>>() as Task<IEnumerable<T>>;
            }
        }


    }
}
