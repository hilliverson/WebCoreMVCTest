namespace DAL.ImplementLibrary
{
    public enum DBProvider
    {
        Oracle,
        MsSqlServer,
        Odbc
    }
    public class DBSetting
    {
        public DBSetting(string connectionstr, DBProvider dbProvider)
        {
            this.connectionStr= connectionstr;  
            this.dbProvider = dbProvider;   
        }
        public string connectionStr { get; set; }
        public DBProvider dbProvider { get; set; }

    }
}