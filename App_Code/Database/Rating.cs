using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Rating
/// </summary>
namespace shopquanao
{
    /// <summary>
    /// Summary description for KhachHang
    /// </summary>
    public class Rating
    {
        #region Phương thức xóa đánh giá
        /// <summary>
        /// / Phương thức xóa Khachang theo mã Khachang truyền vào
        /// </summary>
        /// <param name="ratingid"></param>
        public static void Rating_Delete(string ratingid)
        {
            OleDbCommand cmd = new OleDbCommand("rating_delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ratingid", ratingid);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
        #endregion

        #region Phương thức thêm mới
        /// <summary>
        /// Phương thức thêm mới Khachang vào Khachang
        /// </summary>
        /// <param name="masp"></param>
        /// <param name="rating"></param>
        /// <param name="comment"></param>
        /// <param name="ret"></param>
        public static void Rating_Insert(string masp, string rating, string comment,string ret)
        {
            OleDbCommand cmd = new OleDbCommand("rating_insert");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masp", masp);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@comment", comment);
            cmd.Parameters.AddWithValue("@ret", ret);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }
        #endregion

        #region  Phương thức chỉnh sửa
        /// <summary>
        /// Phương thức chỉnh sửa thông tin một KhachHang
        /// </summary>
        public static void Rating_Update(string ratingid, string masp, string rating, string comment)
        {
            OleDbCommand cmd = new OleDbCommand("rating_update");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ratingid", ratingid);
            cmd.Parameters.AddWithValue("@masp", masp);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@comment", comment);
            SQLDatabase.ExecuteNoneQuery(cmd);
        }


        #endregion

        #region Phương thức lấy ra thông tin rating theo id
        /// <summary>
        /// Phương thức lấy ra thông tin size theo id size
        /// <para name="ratingid"></para>
        /// </summary>
        /// <returns></returns>
        public static DataTable Thongtin_Rating_By_id (string ratingid)
        {
            OleDbCommand cmd = new OleDbCommand("thongtin_rating_by_id");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ratingid", ratingid);
            return SQLDatabase.GetData(cmd);
        }
        #endregion

        #region Phương thức lấy ra toan bo thông tin
        /// <summary>
        /// Phương thức lấy ra thông tin size theo id size
        /// </summary>
        /// <returns></returns>
        public static DataTable Thongtin_Rating()
        {
            OleDbCommand cmd = new OleDbCommand("thongtin_rating");
            cmd.CommandType = CommandType.StoredProcedure;
            return SQLDatabase.GetData(cmd);
        }
        #endregion

    }
}
