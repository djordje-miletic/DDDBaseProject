namespace DDD.Domain.Interfaces
{
    public interface IAudit
    {
        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get;}
    }
}
