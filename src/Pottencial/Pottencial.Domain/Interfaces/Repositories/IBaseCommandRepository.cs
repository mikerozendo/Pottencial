using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IBaseCommandRepository<T> where T : Base
{
    T Post(T obj);
    void Remove(T obj);
}
