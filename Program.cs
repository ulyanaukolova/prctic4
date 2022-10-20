namespace prctic4
{
    class Program
    {
        public static List<Task> taskList = new List<Task>();

        static void Main(string[] args)
        {
            Task taskOne = new Task(name: "сходить в магазин", description: "купить продукты", date: new DateTime(2022, 10, 20));
            Task taskTwo = new Task(name: "сделать практическую", description: "по любимому си шарпу", date: new DateTime(2022, 10, 20));
            Task taskThree = new Task(name: "помочь маме", description: "сделать уборку", date: new DateTime(2022, 10, 21));
            Task taskFour = new Task(name: "пойти погулять", description: "с Дашей и Машей", date: new DateTime(2022, 10, 19));
            Task taskFive = new Task(name: "кота покормить", description: "сухим кормом", date: new DateTime(2022, 10, 19));

            taskList.Add(taskOne);
            taskList.Add(taskTwo);
            taskList.Add(taskThree);
            taskList.Add(taskFour);
            taskList.Add(taskFive);

            DateTime date = new(2022, 10, 20);

            List<Task> orderedList = taskList;
            orderedList = taskList.Where(o => o.date == date).ToList();

            var menu = new Menu(taskList);
            menu.ShowMenu(date);
        }

        public static List<Task> ShowTasksByDate(DateTime date)
        {
            List<Task> tasksByDateList = taskList;
            tasksByDateList = taskList.Where(o => o.date == date).ToList();

            return tasksByDateList;
        }
        public static void ViewDetails(int index)
        {
            int taskID = index;

            Console.Write($"Описание - {taskList.ElementAt(taskID).description}");
        }
    }
}