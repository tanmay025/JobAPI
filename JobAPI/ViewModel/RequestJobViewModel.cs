namespace JobAPI.ViewModel
{
    public class RequestJobViewModel
    {
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime ClosingDate { get; set; }
    }
}