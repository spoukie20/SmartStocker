namespace SmartStocker.Abscrations
{
    public interface ICrud<T>
    {
        public Task<List<T>> GetT();
        public Task<T?> GetTById(int id);
        public Task<T> CreateT(T model);
        public Task<T> UpdateT(T model);
        public Task<T> DeleteT(int id);
    }
}
