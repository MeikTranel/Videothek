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
            return File.Exists(dbFilePath);
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
                    Name = "Admin",
                    Balance = 999.99F
                });
                SQLiteConnection.Insert(new UserEntity()
                {
                    Name = "Meik",
                    Balance = 123112313.12F
                });

                SQLiteConnection.Insert(new VideoEntity()
                {
                    Name = "Social Network",
                    Availability = 123,
                    Price = 100f,
                    CoverImageLocation = ""
                });
                SQLiteConnection.Insert(new VideoEntity()
                {
                    Name = "Spongebob Squarepants",
                    Availability = 123,
                    Price = 3.5f,
                    CoverImageLocation = ""
                });
                SQLiteConnection.Insert(new VideoEntity()
                {
                    Name = "Star Wars IV",
                    Availability = 123,
                    Price = 3.5f,
                    CoverImageLocation = ""
                });
            });
        }
    }
}