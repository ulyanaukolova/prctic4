namespace prctic4
{
    class Menu
    {
        public int selectedIndex;
        public List<Task> taskList;

        public Menu(List<Task> taskList)
        {
            this.taskList = taskList;
            selectedIndex = 0;
        }

        public void ShowMenu(DateTime date)
        {
            taskList = Program.ShowTasksByDate(date);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(date);
                for (var i = 0; i < taskList.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"{taskList[i].name}");
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }

                var input = Console.ReadKey();

                if (input.Key is ConsoleKey.LeftArrow)
                {
                    date = date.AddDays(-1);
                    taskList = Program.ShowTasksByDate(date);
                }

                if (input.Key is ConsoleKey.RightArrow)
                {
                    date = date.AddDays(1);
                    taskList = Program.ShowTasksByDate(date);
                }

                if (input.Key is ConsoleKey.DownArrow)
                {
                    if (selectedIndex < taskList.Count - 1) selectedIndex++;
                }

                if (input.Key is ConsoleKey.UpArrow)
                {
                    if (selectedIndex > 0) selectedIndex--;
                }

                if (input.Key is ConsoleKey.Enter)
                {
                    Console.Clear();
                    Program.ViewDetails(selectedIndex);
                    Console.ReadKey();
                }

                if (input.Key is ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }

    }
}
