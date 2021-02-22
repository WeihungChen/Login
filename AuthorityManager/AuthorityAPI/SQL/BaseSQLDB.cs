using SQLLibrary;

namespace AuthorityAPI.SQL
{
    internal abstract class BaseSQLDB
    {
        protected MySQL SQL { get; private set; }

        public abstract MySQLConnectData SetSQLConnectData();

        public BaseSQLDB()
        {
            SQL = new MySQL(SetSQLConnectData());
        }
    }
}