namespace TestWebService.Models
{
    //Department model
    public class Department
    {
        public int DepartmentID { get; set; }
        public int CollegeID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}