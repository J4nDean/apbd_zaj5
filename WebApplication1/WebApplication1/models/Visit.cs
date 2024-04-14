namespace WebApplication1.models;

public class Visit
{
    public DateTime VisitDate { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}