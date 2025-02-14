﻿namespace Repository.GenericRepository
{
    public interface IReadRepository<T>
    {
        Task<IEnumerable<T>?> Gets();
        Task<T?> GetById(string id);
    }
}
