﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class Dal_MonHoc : connect
    {
        SqlDataAdapter da;
        DataTable dt;

        // hàm lấy dữ liệu từ csdl lên datagridview
        public DataTable MonHoc()
        {
            da = new SqlDataAdapter("SELECT * FROM MONHOC", dbConn);
            dt = new DataTable();
            da.Fill(dt);
            dbConn.Close();
            return dt;
        }

        // thêm KT
        public bool themMH(DTO_MonHoc pKT)
        {
            dbConn.Open();
            string cmd = "INSERT INTO MONHOC VALUES(N'" + pKT.MaMonHoc + "',N'" + pKT.TenMonHoc + "', '" + pKT.SoTiet + "')";
            SqlCommand sqlCmd = new SqlCommand(cmd, dbConn);
            sqlCmd.ExecuteNonQuery();
            dbConn.Close();
            return true;
        }

        // Sửa KT
        public bool suaMH(DTO_MonHoc pKT)
        {
            dbConn.Open();
            string cmd = "UPDATE MONHOC SET TENMH=N'" + pKT.TenMonHoc + "',SOTIET='" + pKT.SoTiet + "'  WHERE MAMH='" + pKT.MaMonHoc + "'";
            SqlCommand sqlCmd = new SqlCommand(cmd, dbConn);
            sqlCmd.ExecuteNonQuery();
            dbConn.Close();
            return true;
        }

        // Xóa KT
        public bool xoaMH(String maMH)
        {
            dbConn.Open();
            string cmd = "DELETE FROM MONHOC WHERE MAMH='" + maMH + "'";
            SqlCommand sqlCmd = new SqlCommand(cmd, dbConn);
            sqlCmd.ExecuteNonQuery();
            dbConn.Close();
            return true;
        }

        public DataTable ds_SinhVien()
        {
            da = new SqlDataAdapter("Select SV.MASV as [Ma SV], HOSV+' '+TENSV as [HoTen], TENMH, HOCKY, DIEMCC, DIEMTX, DIEMGK, DIEMTHI, ( DIEMCC + DIEMTX + DIEMGK*3 + DIEMTHI*5 )/10 as DiemTongKet From SINHVIEN as SV, DIEM as D, MONHOC as MH where (SV.MASV=D.MASV) and (D.MAMH=MH.MAMH)", dbConn);
            dt = new DataTable();
            da.Fill(dt);
            dbConn.Close();
            return dt;
        }

        public DataTable ds_SinhVien_MonHoc( string maMH)
        {
            da = new SqlDataAdapter("Select SV.MASV as [Ma SV], HOSV+' '+TENSV as [HoTen], TENMH, HOCKY, DIEMCC, DIEMTX, DIEMGK, DIEMTHI, ( DIEMCC + DIEMTX + DIEMGK*3 + DIEMTHI*5 )/10 as DiemTongKet From SINHVIEN as SV, DIEM as D, MONHOC as MH where (SV.MASV=D.MASV) and (D.MAMH=MH.MAMH) and MH.MAMH='"+maMH+"'", dbConn);
            dt = new DataTable();
            da.Fill(dt);
            dbConn.Close();
            return dt;
        }
    }
}
