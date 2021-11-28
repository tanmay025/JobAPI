namespace JobAPI.ViewModel
{
    public class ResponseJobViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public LocationViewModel Location { get; set; }
        public DepartmentViewModel Department { get; set; }
        public System.DateTime PostedDate { get; set; }
        public System.DateTime ClosingDate { get; set; }
    }
}