namespace MotionCameraAPI
{
    public class Secret
    {
        private static string connectionString = @"Data Source=mssql4.unoeuro.com;Initial Catalog=silasstilling_dk_db_gproser;Persist Security Info=True;User ID=silasstilling_dk;Password=cxenHybp2DFGf9Rtz6aw;TrustServerCertificate=True";

        public static string ConnectionString
        {
            get { return connectionString; }
        }
    }
}