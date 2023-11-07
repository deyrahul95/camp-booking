namespace CampBooking.DAL.DbModel
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid CampId { get; set; }
        public string ReferenceNumber { get; set; }
        public string CellPhone { get; set; }
        public int Star { get; set; }
        public string Comment { get; set; }
    }
}
