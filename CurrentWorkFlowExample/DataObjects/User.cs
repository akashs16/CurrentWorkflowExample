namespace CurrentWorkFlowExample.DataObjects
{
    public class User
    {
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public string Country { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
    }
}