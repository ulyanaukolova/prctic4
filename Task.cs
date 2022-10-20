namespace prctic4
{
    class Task
    {
        public Task(string name, string description, DateTime date)
        {
            this.name = name;
            this.description = description;
            this.date = date;
        }

        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

    }

}