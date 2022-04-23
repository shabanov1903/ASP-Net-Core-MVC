namespace Lesson8.Models
{
    public class OfficeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Employee>? Employees { get; set; }
        public string? Address { get; set; }
        public int Count { get; set; }
    }
}