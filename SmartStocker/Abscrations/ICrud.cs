namespace SmartStocker.Abscrations
{
    public interface ICrud<T>
    {
        public Task<List<T>> GetT(int id = 0);
        public Task<T> SetT(int id);
        public Task<T> UpdateT(int id);
        public Task<T> DeleteT(int id);
    }
}
