using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volante;

namespace Karkas.CodeGeneration.WinApp.ConfigurationInformation
{
    public class DatabaseRoot : Persistent
    {

        public IIndex<string, DatabaseEntry> IndexName;
        public IIndex<DateTime, DatabaseEntry> IndexLastWriteTime;
        public IIndex<DateTime, DatabaseEntry> IndexLastAccessTime;
        public IIndex<DateTime, DatabaseEntry> IndexCreationTime;

        private static DatabaseRoot dbRootinstance;

        public static DatabaseRoot DbRootInstance
        {
            get { return DatabaseRoot.dbRootinstance; }
        }


        private static IDatabase db = null;
        public static void closeDatabase()
        {
            db.Close();
        }

        public static void openDatabase()
        {
            db = DatabaseFactory.CreateDatabase();
            db.Open("connectionDatabase.dbs");
            createDatabaseRoot();
            db.Commit();

        }

        private static void createDatabaseRoot()
        {

            if (null != db.Root)
            {
                dbRootinstance = (DatabaseRoot)db.Root;
            }
            else
            {
                // only create root the first time
                dbRootinstance = new DatabaseRoot();
                DbRootInstance.IndexName = db.CreateIndex<string, DatabaseEntry>(IndexType.NonUnique);
                DbRootInstance.IndexLastWriteTime = db.CreateIndex<DateTime, DatabaseEntry>(IndexType.NonUnique);
                DbRootInstance.IndexLastAccessTime = db.CreateIndex<DateTime, DatabaseEntry>(IndexType.NonUnique);
                DbRootInstance.IndexCreationTime = db.CreateIndex<DateTime, DatabaseEntry>(IndexType.NonUnique);

                db.Root = DbRootInstance;
                // changing the root marks database as modified but it's
                // only modified in memory. Commit to persist changes to disk.
                createExampleDatabaseEntry();
            }
        }

        private static void createExampleDatabaseEntry()
        {
            DatabaseEntry de = getExampleDatabaseEntry();

            addToIndexes(de);

            db.Commit();
        }

        public static void addToIndexes(DatabaseEntry de)
        {
            DbRootInstance.IndexName.Put(de.ConnectionName, de);
            DbRootInstance.IndexLastAccessTime.Put(de.LastAccessTimeUtc, de);
            DbRootInstance.IndexLastWriteTime.Put(de.LastWriteTimeUtc, de);
            DbRootInstance.IndexCreationTime.Put(de.CreationTimeUtc, de);
        }
        public static void addToIndexesAndCommit(DatabaseEntry de)
        {
            addToIndexes(de);
            DbRootInstance.Database.Commit();
        }

        private static DatabaseEntry getExampleDatabaseEntry()
        {
            DatabaseEntry de = new DatabaseEntry();
            de.CodeGenerationDirectory = "D:\\projects\\karkas\\Karkas.Ornek";
            de.CodeGenerationNamespace = "Karkas.Ornek";
            de.ConnectionDatabaseType = DatabaseType.SqlServer;
            de.ConnectionName = "KARKAS_ORNEK";
            de.ConnectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog=KARKAS_ORNEK;Data Source=localhost";
            de.CreationTimeUtc = DateTime.UtcNow;
            de.LastWriteTimeUtc = DateTime.UtcNow;
            de.LastAccessTimeUtc = DateTime.UtcNow;
            return de;
        }


        public static DatabaseEntry getLastAccessedDatabaseEntry()
        {
            return DbRootInstance.IndexLastAccessTime.First();

        }


        public static void Commit()
        {
            DbRootInstance.Database.Commit();
        }

        public static List<DatabaseEntry> getAllDatabaseEntriesSortedByName()
        {
            var list = DatabaseRoot.DbRootInstance.IndexName.ToList();
            return list;
        }


        public static void removeFromIndexesAndCommit(DatabaseEntry de)
        {
            removeFromIndexes(de);
            DbRootInstance.Database.Commit();

        }
        public static void removeFromIndexes(DatabaseEntry de)
        {
            DbRootInstance.IndexName.Remove(de.ConnectionName, de);
            DbRootInstance.IndexLastAccessTime.Remove(de.LastAccessTimeUtc, de);
            DbRootInstance.IndexLastWriteTime.Remove(de.LastWriteTimeUtc, de);
            DbRootInstance.IndexCreationTime.Remove(de.CreationTimeUtc, de);
        }
    }
}
