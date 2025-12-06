using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    public static class DbHelper
    {
        // Đây là chuỗi kết nối dùng chung cho cả 4 Form
        // Dấu chấm (.) nghĩa là máy hiện tại (Localhost)
        public static string ConnectionString = @"Server=.\SQLEXPRESS;Database=SE08201_AdminDashboard;Integrated Security=true";
    }
}