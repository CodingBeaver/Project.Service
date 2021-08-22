namespace Project.Service.Models
{
    public interface ISort
    {
        string SortField { get; set; }

        string SortDirection { get; set; }
    }
}