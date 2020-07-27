namespace Assignment_P_V.Models
{
    public class Trainer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Trainer(string firstName, string lastName,string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;

        }
    }
}
