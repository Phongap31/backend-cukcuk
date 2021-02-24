
namespace MISA.CukCuk.Common.Enums
{
    public class ProcName
    {
    }

    /// <summary>
    /// Lớp store procedure
    /// </summary>
    /// created by lhphong 20.02.2021
    public class PreProcName
    {
        /// <summary>
        /// Hàm store thực thi lấy tất cả dữ liệu
        /// </summary>
        public const string ProcGetAll = "Proc_GetAll";

        /// <summary>
        /// Hàm store thực thi thêm mới
        /// </summary>
        public const string ProcInsert = "Proc_Insert";

        /// <summary>
        /// Hàm store thực thi sửa thông tin theo ID
        /// </summary>
        public const string ProcUpdate = "Proc_Update";

        /// <summary>
        /// Hàm store thực thi xóa bản ghi theo ID
        /// </summary>
        public const string ProcDelete = "Proc_Drop";

        /// <summary>
        /// Hàm store thực thi lấy bản ghi theo ID
        /// </summary>
        public const string ProcGetByID = "Proc_Get";
    }

    public class LastProcName
    {
        public const string ProcGetByID = "ByID";
    }
}
