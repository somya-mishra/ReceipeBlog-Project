namespace ReceipeBlog.Model
{
    public class SQLRolesRepository : IRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        
        public SQLRolesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Role AddRole(Role role)
        {
            _appDbContext.Roles.Add(role);
            _appDbContext.SaveChanges();
            return role;
        }

        public Role DeleteRole(int id)
        {
            var result = _appDbContext.Roles.SingleOrDefault(x =>x.Id==id);
            if (result != null)
            {
                _appDbContext.Roles.Remove(result);
                _appDbContext.SaveChanges();
                

            }
            return result;
        }

        public IEnumerable<Role> GetAllRole()
        {
            return _appDbContext.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
           return  _appDbContext.Roles.SingleOrDefault(x =>x.Id==id);
        }

        public Role UpdateRole(Role role)
        {
           var result =  _appDbContext.Roles.Attach(role);

            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();

            return role;

        }
    }
}
