namespace OMPhoenix.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private OMPhoenixContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbContext = _dbContext ?? _dbFactory.Init();
        }

        public OMPhoenixContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public void Commit()
        {
            DbContext.Commit();
        }
        public void Test()
        {
            DbContext.Commit();
        }
    }
}
