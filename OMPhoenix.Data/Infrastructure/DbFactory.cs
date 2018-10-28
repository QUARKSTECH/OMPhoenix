
namespace OMPhoenix.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private OMPhoenixContext _dbContext;

        public OMPhoenixContext Init()
        {
            return _dbContext ?? (_dbContext = new OMPhoenixContext());
        }

        protected override void DisposeCore()
        {
            _dbContext.Dispose();
        }
    }
}
