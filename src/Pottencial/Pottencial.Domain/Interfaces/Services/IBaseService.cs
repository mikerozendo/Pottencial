using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : Base
    {
        IEnumerable<T> Get();
    }
}
