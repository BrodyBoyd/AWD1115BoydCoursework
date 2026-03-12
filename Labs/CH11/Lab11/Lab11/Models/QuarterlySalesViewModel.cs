namespace Lab11.Models
{
    public class QuarterlySalesViewModel
    {
        public List<Sales> Sales { get; set; } = new();

        public List<Employee> Employees { get; set; } = new();

        public int? SelectedEmployeeId { get; set; }

        public double TotalSales => Sales.Sum(s => s.Amount);

    }
}
