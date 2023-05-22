namespace CORE
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid UserCreate { get; set; }
        public Guid? UserUpdate { get; set; }
    }
}
