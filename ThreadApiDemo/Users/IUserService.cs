namespace MyWebApi.Users
{
    using System.Threading.Tasks;
    public interface IUserService
    {
        Task<bool> ExportUsersToExternalSystem();
    }
}
