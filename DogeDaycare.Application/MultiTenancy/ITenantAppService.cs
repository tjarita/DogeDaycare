using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DogeDaycare.MultiTenancy.Dto;

namespace DogeDaycare.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
