namespace ProjectDB.Data
{
    public class MysqlConnection
    {
        public string ConnectionString { get; set; }
        public MysqlConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}