﻿namespace PhotoSharingAppJessieDomingo.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId);
        Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionId);
    }
}