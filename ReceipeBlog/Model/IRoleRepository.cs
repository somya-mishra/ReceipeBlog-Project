namespace ReceipeBlog.Model
{
    public interface IRoleRepository
    {
        Role AddRole (Role role);   
        Role UpdateRole(Role role);

        IEnumerable<Role> GetAllRole ();

        Role GetRoleById (int id);
        Role DeleteRole(int id);    
    }
}
