using System;
using System.IO;
using System.Net.Mime;
using SQLite;
using Videothek.Persistence.Entities;

namespace Videothek.Persistence
{
    public class Database
    {

        public SQLiteConnection SQLiteConnection { get; }

        public Database(ILocalDBStorageLocationStrategy localDBStorageLocationStrategy)
        {
            if (localDBStorageLocationStrategy == null)
                throw new ArgumentNullException(nameof(localDBStorageLocationStrategy));

            var dbFilePath = localDBStorageLocationStrategy.ProvideFilePath();
            if (DatabaseAlreadyExists(dbFilePath))
            {
                SQLiteConnection = new SQLiteConnection(dbFilePath);
                InitializeDatabase();
            } else {
                SQLiteConnection = new SQLiteConnection(dbFilePath);
                InitializeDatabase();
                LoadInitialData();
            }
        }

        private bool DatabaseAlreadyExists(string dbFilePath)
        {
            return !File.Exists(dbFilePath);
        }

        private void InitializeDatabase()
        {
            SQLiteConnection.CreateTable<UserEntity>();
            SQLiteConnection.CreateTable<PenaltyEntity>();
            SQLiteConnection.CreateTable<VideoEntity>();
            SQLiteConnection.CreateTable<RentalEntity>();
        }

        private void LoadInitialData()
        {
            SQLiteConnection.RunInTransaction(() => {
                SQLiteConnection.Insert(new UserEntity()
                {
                    Name = "Admin"
                });
                SQLiteConnection.Insert(new UserEntity()
                {
                    Name = "Meik"
                });
            });
        }
    }
}