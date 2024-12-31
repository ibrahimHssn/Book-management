using Book_management.DatabaseManager;
using System.Data;
using System.Data.SqlClient;

namespace Book_management.BL
{
    class GetAllBooks
    {
        DBManager db = new DBManager();

        public DataTable View_All_Books()
        {
            db.Open();
            DataTable dt = new DataTable();
            SqlParameter[] q = null;
            dt = db.Read("GetAllBooks", q);
            db.Close();
            return dt;
        }

    }
}
