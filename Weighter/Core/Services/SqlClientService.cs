﻿using System.Diagnostics.CodeAnalysis;
using SQLite;
using Weighter.Core.Services.Interfaces;

namespace Weighter.Core.Services
{
    [ExcludeFromCodeCoverage]
    public class SqlClientService : ISqlClientService, IDisposable
    {
        private SQLiteConnection _db;
        public SqlClientService()
        {
        }

        public SqlClientService(string connectionString)
        {
            _db = new SQLiteConnection(connectionString);
        }

        public void SetConnectionString(string connectionString)
        {
            _db = new SQLiteConnection(connectionString);
        }

        public CreateTableResult CreateTable<T>()
        {
            return _db.CreateTable<T>();
        }

        public TableQuery<T> Table<T>() where T : new()
        {
            return _db.Table<T>();
        }

        public int Insert<T>(T value)
        {
            return _db.Insert(value);
        }

        public int InsertRange<T>(IEnumerable<T> values)
        {
            return _db.InsertAll(values);
        }

        public int Update<T>(T value)
        {
            return _db.Update(value);
        }

        public int UpdateRange<T>(IEnumerable<T> values)
        {
            return _db.UpdateAll(values);
        }

        public int CreateOrUpdate<T>(T value) where T : new()
        {
            var existingEntry = _db.Table<T>().FirstOrDefault(entry => entry.Equals(value));
            if (existingEntry == null)
            {
                return _db.Insert(value);
            }

            return _db.Update(value);
        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}