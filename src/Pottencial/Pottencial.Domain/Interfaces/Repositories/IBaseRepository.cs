﻿using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IBaseRepository<T> where T : Base
{
    IEnumerable<T> Get();
}