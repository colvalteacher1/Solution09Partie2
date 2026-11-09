namespace Solution09Partie2.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public string? City { get; set; }

        public DateOnly? CreationDate { get; set; }
    }
}
