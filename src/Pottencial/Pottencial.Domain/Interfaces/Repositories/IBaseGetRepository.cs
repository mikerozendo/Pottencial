using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IBaseGetRepository<T> where T : Base
{
    IEnumerable<T> Get();
}
