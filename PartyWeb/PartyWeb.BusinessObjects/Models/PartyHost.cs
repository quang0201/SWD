namespace BusinessObjects.Models
{
    public class PartyHost
    {
        public int PartyHostId { get; set; }
        public string? PartyHostTitle { get; set; }
        public string? PartyHostDetails { get; set; }
        public int? NumberOfPeople { get; set; }
        public DateTime? StartedTime { get; set; }
        public DateTime? EndedTime { get; set; }
        public int? CreatedBy { get; set; }
        public virtual Account? CreatedByNavigation { get; set; }
    }
}
