using System.Threading.Tasks;
using Storage.Model.Entities;
using Storage.Service.Dtos.LoginHistory;

namespace Storage.Service.Interfaces
{
    public interface ILoginHistoryService: IService<LoginHistory>
    {
        bool CheckTokenLoginNeareast(CheckTokenLoginNeareastDto checkTokenLoginNeareastDto);
    }
}