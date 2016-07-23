using System.Threading.Tasks;
using Abp.Application.Services;
using DogeDaycare.Roles.Dto;

namespace DogeDaycare.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
