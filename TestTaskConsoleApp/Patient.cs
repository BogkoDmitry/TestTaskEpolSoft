namespace TestTaskConsoleApp
{
    public class Patient
    {
        public Guid Id { get; set; }
        public PatientName Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

        public class PatientName
        {
            public string Use { get; set; }
            public string Family { get; set; }
            public string[] Given { get; set; }
        }
    }
}
