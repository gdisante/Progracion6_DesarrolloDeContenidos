using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Progracion6_DesarrolloDeContenidos.Models;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Progracion6_DesarrolloDeContenidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersHistoryController : ControllerBase
    {

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=MAX_THE_MULE_BROKER;Trusted_Connection=True;TrustServerCertificate=true";


        [HttpPost]
        [Route("CrearOrdenes2")]
        public bool crearOrdenes(OrdersHistory C) {

            string query = "insert into orders_history ( ORDER_DATE, ACTION, STATUS, SYMBOL, QUANTITY, PRICE) values(getdate(),'" + C.ACTION + "','" + C.STATUS + "','" + C.SYMBOL + "'," + C.QUANTITY + "," + C.PRICE + ");";
            SqlConnection sqlConn = new SqlConnection(connectionString);

            sqlConn.Open();
            SqlCommand cm = new SqlCommand(query, sqlConn);
            cm.ExecuteNonQuery();



            
            return true;
        }



        [HttpPost]
        [Route("CrearOrden")]
        public string crearOrden(OrdersHistory C) {
            string query = "insert into orders ( ORDER_DATE, ACTION, STATUS, SYMBOL, QUANTITY, PRICE) values(getdate(),'"+C.ACTION+"','"+C.STATUS+"','"+C.SYMBOL+"',"+C.QUANTITY+"," + C.PRICE+");";
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

           SqlCommand CM = new SqlCommand(query, sqlConn);

            if (CM.ExecuteNonQuery() == 1){
                sqlConn.Close();
                return "{'resultado':'OK'}";
                 
            }
            else {
                sqlConn.Close();
                return "{'resultado':'NOK'}"; 
            }
          
        }



        [HttpGet]
        [Route("getOrdersHistory")]
        public List<OrdersHistory> getOrdersHistory() { 

            List<OrdersHistory> lh = new List<OrdersHistory>();

            string Query = "select TX_NUMBER, ORDER_DATE, ACTION, STATUS, SYMBOL, QUANTITY, PRICE from ORDERS";

            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlCommand sqlCM = new SqlCommand(Query, sqlConn);
            SqlDataReader dr = sqlCM.ExecuteReader();

            while (dr.Read()) {
                OrdersHistory oh = new OrdersHistory();
                oh.TX_NUMBER = int.Parse(dr[0].ToString());
                oh.ORDER_DATE = Convert.ToDateTime(dr[1].ToString());
                oh.ACTION = dr[2].ToString();
                oh.STATUS = dr[3].ToString();
                oh.SYMBOL = dr[4].ToString();
                oh.QUANTITY = int.Parse(dr[5].ToString());
                oh.PRICE = double.Parse(dr[6].ToString());

                lh.Add(oh);

            }
        

            sqlConn.Close();


          

            


            return lh;
        
        }

        [HttpGet]
        [Route("getOrdersHistoryYear")]
        public List<OrdersHistory> getOrdersHistoryYear(string Year)
        {

            List<OrdersHistory> lh = new List<OrdersHistory>();

            string Query = "select TX_NUMBER, ORDER_DATE, ACTION, STATUS, SYMBOL, QUANTITY, PRICE from ORDERS where YEAR(ORDER_DATE) ='"+ Year+"';";

            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlCommand sqlCM = new SqlCommand(Query, sqlConn);
            SqlDataReader dr = sqlCM.ExecuteReader();

            while (dr.Read())
            {
                OrdersHistory oh = new OrdersHistory();
                oh.TX_NUMBER = int.Parse(dr[0].ToString());
                oh.ORDER_DATE = Convert.ToDateTime(dr[1].ToString());
                oh.ACTION = dr[2].ToString();
                oh.STATUS = dr[3].ToString();
                oh.SYMBOL = dr[4].ToString();
                oh.QUANTITY = int.Parse(dr[5].ToString());
                oh.PRICE = double.Parse(dr[6].ToString());

                lh.Add(oh);

            }


            sqlConn.Close();







            return lh;

        }








   }
}
