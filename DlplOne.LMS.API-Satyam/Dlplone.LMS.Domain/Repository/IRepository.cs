namespace Dlplone.LMS.Domain
{
    public interface IRepository
    {

        Task<int> AddAsync<T>(T item, string table, string schema);
        Task AddRangeAsync<T>(List<T> items, string table, string schema);
        Task AddRangeWithProcAsync<TP>(string proc, List<TP> parameterObjList, bool isText = true);
        int Add<T>(T item, string table, string schema);
        void AddRange<T>(List<T> items, string table, string schema);
        Task<int> UpdateAsync<T>(T item, string table, string schema);
        Task UpdateRangeAsync<T>(List<T> items, string table, string schema);
        int Update<T>(T item, string table, string schema);
        void UpdateRange<T>(List<T> items, string table, string schema);
        Task<int> RemoveByParentIdAsync(int columnValue, string table, string schema, string columnName);
        int RemoveByParentId(int columnValue, string table, string schema, string columnName);
        Task<int> RemoveAsync(int id, string table, string schema);
        int Remove(int id, string table, string schema);
        Task<int> RemoveRangeAsync(List<int> ids, string table, string schema);
        int RemoveRange(List<int> ids, string table, string schema);
        Task<T> FindByParentIdAsync<T>(int parentId, string table, string schema, string parentColumn);
        T FindByParentId<T>(int parentId, string table, string schema, string parentColumn);
        Task<T> FindByIdAsync<T>(int id, string table, string schema);
        Task<T> FindByIdAsync<T>(int id, string table, string schema, string idName);
        T FindById<T>(int id, string table, string schema);
        Task<IEnumerable<T>> FindAllAsync<T>(string table, string schema, bool asc = true);
        IEnumerable<T> FindAll<T>(string table, string schema, bool asc = true);
        Task<IEnumerable<T>> FindRangeByParentIdAsync<T>(int columnValue, string table, string schema, string columnName);
        IEnumerable<T> FindRangeByParentId<T>(int columnValue, string table, string schema, string columnName);
        IEnumerable<T> ExecuteRawSql<T, TP>(string proc, TP parameterObj, bool isText = true);
        Task<IEnumerable<T>> ExecuteRawSqlAsync<T, TP>(string proc, TP parameterObj, bool isText = true);
        List<Object> ExecuteRawSql<T1, T2, T3, T4, T5, T6, T7, TP>(string proc, TP parameterObj, bool isText = true);
        Task<List<Object>> ExecuteRawSqlAsync<T1, T2, T3, T4, T5, T6, T7, TP>(string proc, TP parameterObj, bool isText = true);
        Task<List<Object>> ExecuteRawSqlAsync<T1, T2, T3, TP>(string proc, TP parameterObj, bool isText = true);

    }
}
