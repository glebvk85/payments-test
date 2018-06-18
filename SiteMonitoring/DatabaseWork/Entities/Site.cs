namespace DatabaseWork.Entities
{
    public class Site
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public int CheckPeriodInSeconds { get; set; }
    }
}
