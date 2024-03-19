namespace ModelViews.ModelView
{
    public class PartyPostModel
    {
        public int PartyPostId { get; set; }
        public string PartyPostTitle { get; set; } = null!;
        public string PartyPostDetails { get; set; } = null!;
        public DateTime? CreatedTime { get; set; }
        public int? CreatedBy { get; set; }
    }
}
