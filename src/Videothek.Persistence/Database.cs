using System;
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

            SQLiteConnection = new SQLiteConnection(
                localDBStorageLocationStrategy.ProvideFilePath()    
            );
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            SQLiteConnection.CreateTable<UserEntity>();
            SQLiteConnection.CreateTable<PenaltyEntity>();
            SQLiteConnection.CreateTable<VideoEntity>();
            SQLiteConnection.CreateTable<RentalEntity>();
        }


    }
}