using System.ComponentModel.DataAnnotations;

namespace JobAPI.ViewModel
{
    public class SearchJobsViewModel
    {
        [Required]
        public string SearchValue { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PageNo { get; set; }
        [Required]
        [Range(1, 100)]
        public int PageSize { get; set; }
        public int? locationId{ get; set; }
        public int? departmentId { get; set; }
    }
}