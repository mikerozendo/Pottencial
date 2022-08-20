using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IBaseQueryRepository<T> where T : Base
{
    IEnumerable<T> Get(int id = 0);
    int ObterQuantidade();
}
