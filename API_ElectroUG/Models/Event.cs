namespace API_ElectroUG.Models
{
    public class Event
    {
        public int EventId { get; set; }    

        public string EventName { get; set; }   

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Localization { get; set; }

        public bool IsDisabled { get; set; }
    }
}
