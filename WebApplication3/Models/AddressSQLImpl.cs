using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication3.Models
{
    public class AddressSQLImpl : IAddressRespository
    {
        public Address addAddress(Address address)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "insert into Address(UserID, [Name], Mobile, BuildingName, PinCode, Locality, District, Landmark) values(" + address.UserID + ",'"+ address.Name + "'," + address.Mobile +",'"+ address.BuildingName + "'," + address.Pincode + ",'" + address.Locality + "','" + address.District + "','" + address.Landmark + "')";
                comm.Connection = conn;
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                    return address;
                else
                {
                    Address newaddr = new Address(); // returning empty address if not successful
                    return newaddr;
                }
            }
        }

        public bool deleteAddress(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "delete from Address where AddressID = "+ id +"";
                comm.Connection = conn;
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                    return true;
                return false;

            }
        }

        public Address updateAddress(int id, Address address)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "update Address set UserID = "+address.UserID+", [Name] ='"+address.Name + "', Mobile =" + address.Mobile + ", BuildingName ='" + address.BuildingName + "', PinCode =" +
                    address.Pincode + ",Locality = '"+address.Locality+"',District ='"+ address.District+"',Landmark = '"+address.Landmark+"' where AddressID = " + address.AddressID + "";

                comm.Connection = conn;
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
                if(rows > 0)
                    return address;
                else
                {
                    Address newaddr = new Address();  //returns empty object when failed
                    return newaddr;
                }

            }
        }

        public Address viewAddressByID(int id)
        {
            Address address = new Address();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                //comm.CommandText = "select top(1) AddressID, UserID, [Name], Mobile, BuildingName, PinCode, Locality, District, Landmark from Address where UserID ="+ id;
                comm.CommandText = "select * from Address where UserID =" + 1;
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    address.AddressID = dr.GetInt32(0);
                    address.UserID = dr.GetInt32(1);
                    address.Name = dr.GetString(2);
                    address.Mobile = dr.GetInt32(3);
                    address.BuildingName = dr.GetString(4);
                    address.Pincode = dr.GetInt32(5);
                    address.Locality = dr.GetString(6);
                    address.District = dr.GetString(7);
                    address.Landmark= dr.GetString(8);
                }
                conn.Close();
                return address;
            }
        }

        public List<Address> viewAddressByUserID(int id)
        {
            List<Address> addresses = new List<Address>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from Address where UserID = "+id+"";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {

                    Address address = new Address();
                    address.AddressID = dr.GetInt32(0);
                    address.UserID = dr.GetInt32(1);
                    address.Name = dr.GetString(2);
                    address.Mobile = dr.GetInt32(3);
                    address.BuildingName = dr.GetString(4);
                    address.Pincode = dr.GetInt32(5);
                    address.Locality = dr.GetString(6);
                    address.District = dr.GetString(7);
                    address.Landmark = dr.GetString(8);
                    addresses.Add(address);
                }
                conn.Close();
                return addresses;
            }
        }
    }
}