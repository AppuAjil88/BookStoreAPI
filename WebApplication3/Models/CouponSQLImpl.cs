using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication3.Models
{
    public class CouponSQLImpl : ICouponRepository
    {
        public Coupon addCoupon(Coupon coupon)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = $"insert into Coupon ( Discount, MaxAmount,CouponCode) values ( {coupon.Discount} , {coupon.MaxAmount} , '{coupon.CouponCode}') ";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                conn.Close();
                return coupon;

            }
        }

        public bool checkCoupon(string couponCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from Coupon where CouponCode = '" + couponCode + "'";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read() == true)
                {
                    conn.Close();
                    return true;
                }
                conn.Close();
                return false;

            }
        }

        public bool deleteCouponById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "delete from Coupon where CouponID = " + id + "";
                comm.Connection = conn;
                conn.Open();
                int rows = comm.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    return true;
                }
                return false;

            }
        }

        public List<Coupon> GetCoupons()
        {
            List<Coupon> coupons = new List<Coupon>();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from Coupon";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {

                    Coupon coupon = new Coupon();
                    coupon.CouponID = dr.GetInt32(0);
                    coupon.Discount = dr.GetInt32(1);
                    coupon.MaxAmount = dr.GetInt32(2);
                    coupon.CouponCode = dr.GetString(3);
                    coupons.Add(coupon);

                }
                conn.Close();
                return coupons;

            }
        }

        public Coupon getCouponByCode(string code)
        {
            Coupon coupon = new Coupon();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                SqlCommand comm = new SqlCommand();
                comm.CommandText = $"select * from Coupon where CouponCode = '{code}'";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {

                    coupon.CouponID = dr.GetInt32(0);
                    coupon.Discount = dr.GetInt32(1);
                    coupon.MaxAmount = dr.GetInt32(2);
                    coupon.CouponCode = dr.GetString(3);
                }
                conn.Close();
            }
            return coupon;
        }
    }
}