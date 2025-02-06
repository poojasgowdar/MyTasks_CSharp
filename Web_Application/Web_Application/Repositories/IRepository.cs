namespace Web_Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        public T GetById(int id);
        public T GetByUserName(string userName);
        public IEnumerable<T> GetAll();
        public void Add(T user);
        public void Delete(T user);

    }
}
