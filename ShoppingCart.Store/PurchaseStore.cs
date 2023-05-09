
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingCart.Store
{

    public interface IPurchaseStore
    {
        List<PurchaseList> GetPurchase();

        PurchaseStoreInfo AddPurchase(PurchaseStoreInfo PurchaseStoreInfo);

        PurchaseStoreInfo GetPurchaseId(long PurchaseID);

        PurchaseStoreInfo UpdatePurchase(PurchaseStoreInfo purchaseStoreInfo);

        void DeletePurchase(long PurchaseID);
    }
    public class PurchaseStore : IPurchaseStore
    {
        private readonly IConfiguration _configuration;

        public PurchaseStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<PurchaseList> GetPurchase()
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            List<PurchaseList> purchases = new List<PurchaseList>();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "SP_LISTPURCHASE";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            {
                while (sqlDataReader.Read())
                {
                    purchases.Add(new PurchaseList
                    {
                        ProductID = Convert.ToInt64(sqlDataReader["ProductID"]),
                        ProductName = sqlDataReader["ProductName"].ToString(),
                        //PurchaseID = Convert.ToInt64(sqlDataReader["PurchaseID"]),
                        PurchasedDate = Convert.ToDateTime(sqlDataReader["PurchasedDate"]),
                        Quantity = Convert.ToInt32(sqlDataReader["Quantity"]),
                        // UnitPrice = Convert.ToDecimal(sqlDataReader["UnitPrice"]),
                        //UnitDiscount = Convert.ToDecimal(sqlDataReader["UnitDiscount"]),
                        TotalDiscount = Convert.ToDecimal(sqlDataReader["TotalDiscount"]),
                        TotalAmount = Convert.ToDecimal(sqlDataReader["TotalAmount"]),
                        ReturnedDate = Convert.ToDateTime(sqlDataReader["ReturnedDate"]),
                        ReturnedQuantity = Convert.ToInt32(sqlDataReader["ReturnedQuantity"]),
                        ReturnedTotalDiscount = Convert.ToDecimal(sqlDataReader["ReturnedTotalDiscount"]),
                        ReturnedTotalAmount = Convert.ToDecimal(sqlDataReader["ReturnedTotalAmount"]),

                    });
                }
                sqlConnection.Close();
            }
            return purchases;
        }

        public PurchaseStoreInfo GetPurchaseId(long PurchaseID)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            PurchaseStoreInfo purchases = new PurchaseStoreInfo();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_GETPURCHASEID";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@PurchaseID", PurchaseID);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            {
                while (sqlDataReader.Read())
                {
                    purchases = new PurchaseStoreInfo()
                    {
                        PurchaseID = Convert.ToInt64(sqlDataReader["PurchaseID"]),
                        ProductID = Convert.ToInt64(sqlDataReader["ProductID"]),
                        Quantity = Convert.ToInt32(sqlDataReader["Quantity"]),
                        UnitPrice = Convert.ToDecimal(sqlDataReader["UnitPrice"]),
                        UnitDiscount = Convert.ToDecimal(sqlDataReader["UnitDiscount"]),
                        TotalDiscount = Convert.ToDecimal(sqlDataReader["TotalDiscount"]),
                        TotalAmount = Convert.ToDecimal(sqlDataReader["TotalAmount"]),
                        PurchasedDate = Convert.ToDateTime(sqlDataReader["PurchasedDate"]),
                        CreatedBy = sqlDataReader["CreatedBy"].ToString(),
                        // ModifiedBy = sqlDataReader["ModifiedBy"].ToString(),
                        // CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                        // ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"])
                    };
                }
                sqlConnection.Close();
            }
            return purchases;
        }

        public PurchaseStoreInfo AddPurchase(PurchaseStoreInfo PurchaseStoreInfo)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            // int StockQuantity = 0;

            SqlConnection sqlConnection = new SqlConnection(Connection);
            string query = "SP_ADDPURCHASE";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            // sqlCommand.Parameters.AddWithValue("@PurchaseID", purchaseStoreInfo.PurchaseID);
            sqlCommand.Parameters.AddWithValue("@ProductId", PurchaseStoreInfo.ProductID);
            sqlCommand.Parameters.AddWithValue("@Quantity", PurchaseStoreInfo.Quantity);
            // sqlCommand.Parameters.AddWithValue("@UnitPrice", purchaseStoreInfo.UnitPrice);
            // sqlCommand.Parameters.AddWithValue("@UnitDiscount", purchaseStoreInfo.UnitDiscount);
            //sqlCommand.Parameters.AddWithValue("@TotalDiscount", purchaseStoreInfo.TotalDiscount);
            //sqlCommand.Parameters.AddWithValue("@TotalAmount", purchaseStoreInfo.TotalAmount);
            //sqlCommand.Parameters.AddWithValue("@PurchasedDate", purchaseStoreInfo.PurchasedDate);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", PurchaseStoreInfo.CreatedBy);
            //sqlCommand.Parameters.AddWithValue("ModifiedBy", purchaseStoreInfo.ModifiedBy);
            //sqlCommand.Parameters.AddWithValue("CreatedDate", purchaseStoreInfo.CreatedDate);
            //sqlCommand.Parameters.AddWithValue("ModifiedDate", purchaseStoreInfo.ModifiedDate);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            sqlConnection.Close();

            // var StockQuantity = 0;
            //SqlConnection sqlConnection1 = new SqlConnection(Connection);
            //string Query = "sp_StockQuantity";
            //SqlCommand sqlCommand1 = new SqlCommand(Query);
            //sqlCommand1.CommandType = CommandType.StoredProcedure;
            //sqlCommand1.Parameters.AddWithValue("@ProductId", purchaseStoreInfo.ProductID);
            //sqlCommand1.Parameters.AddWithValue("@StockQuantity", purchaseStoreInfo.Quantity);
            //StockQuantity = purchaseStoreInfo.Quantity;
            //sqlConnection1.Open();
            //SqlDataReader sqlData = sqlCommand1.ExecuteReader();
            //sqlData.Read();
            //sqlConnection1.Close();

            //var StockQuantity = 0;
            //SqlConnection sqlConnection3 = new SqlConnection(Connection);
            //string Query2 = "select Quantity from Stock where ProductID = " + purchaseStoreInfo.ProductID + @"";
            //SqlCommand sqlCommand3 = new SqlCommand(Query2);
            //sqlCommand3.Connection = sqlConnection3;
            //sqlConnection3.Open();
            //SqlDataReader sqlDataReader1 = sqlCommand3.ExecuteReader();
            //while (sqlDataReader1.Read())
            //{
            //    StockQuantity = Convert.ToInt32(sqlDataReader1["Quantity"]);
            //}

            //sqlConnection3.Close();

            //var remaningQuantity = StockQuantity - purchaseStoreInfo.Quantity;
            //string Query1 = "update Stock set Quantity = '" + remaningQuantity + @"' where ProductID = '" + purchaseStoreInfo.ProductID + @"'";
            //SqlConnection sqlConnection2 = new SqlConnection(Connection);
            //SqlCommand sqlCommand2 = new SqlCommand(Query1);
            //sqlCommand2.Connection = sqlConnection2;
            //sqlConnection2.Open();
            ////purchaseStoreInfo.Quantity = Convert.ToInt16(remaningQuantity);
            //sqlCommand2.ExecuteNonQuery();
            //sqlConnection2.Close();



            return PurchaseStoreInfo;
        }

        public PurchaseStoreInfo UpdatePurchase(PurchaseStoreInfo purchaseStoreInfo)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_UpsertPurchase";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@PurchaseID", purchaseStoreInfo.PurchaseID);
            sqlCommand.Parameters.AddWithValue("@ProductID", purchaseStoreInfo.ProductID);
            sqlCommand.Parameters.AddWithValue("@Quantity", purchaseStoreInfo.Quantity);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", purchaseStoreInfo.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@UnitDiscount", purchaseStoreInfo.UnitDiscount);
            sqlCommand.Parameters.AddWithValue("@TotalDiscount", purchaseStoreInfo.TotalDiscount);
            sqlCommand.Parameters.AddWithValue("@TotalAmount", purchaseStoreInfo.TotalAmount);
            sqlCommand.Parameters.AddWithValue("@PurchasedDate", purchaseStoreInfo.PurchasedDate);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", purchaseStoreInfo.CreatedBy);
            sqlCommand.Parameters.AddWithValue("ModifiedBy", purchaseStoreInfo.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("CreatedDate", purchaseStoreInfo.CreatedDate);
            sqlCommand.Parameters.AddWithValue("ModifiedDate", purchaseStoreInfo.ModifiedDate);

            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            sqlConnection.Close();
            return purchaseStoreInfo;
        }

        public void DeletePurchase(long PurchaseID)
        {
            string Connection = _configuration.GetConnectionString("ShoppingDb");
            SqlConnection sqlConnection = new SqlConnection(Connection);
            string Query = "sp_DeletePurchaseAndUpdateStock";
            SqlCommand sqlCommand = new SqlCommand(Query);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue(@"PurchaseID", PurchaseID);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            sqlConnection.Close();
        }

    }
}
