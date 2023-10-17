namespace LibraryCollectionWebApplication.Models.API
{
    public class Quote
    {
        public int quoteId { get; set; }
        public int authorId { get; set; }
        public string quote { get; set; }
        public string nationality { get; set; }
        public string profession { get; set; }
        public string born { get; set; }
        public string name { get; set; }
    }
}
