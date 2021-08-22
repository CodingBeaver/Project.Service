namespace Project.Service.Models
{
    public interface IPaging
    {

        int? Pages { get; set; }

        int? PageSize { get; set; }
    }
}