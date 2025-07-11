﻿namespace Common.Interfaces
{
    public interface IUow : IAsyncDisposable
    {
        IGenericRepository<T> GetGenericRepo<T>() where T : class, IEquatable<T>;
        Task<int> SaveAsync();
        int Save();
    }
}
