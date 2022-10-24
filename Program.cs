using static System.Console;
using static System.ConsoleKey;
using static System.ConsoleColor;

namespace ToD0
{
    internal class Program
    {
        static void Main()
        {
            WriteLine("ДЛЯ ЗАПУСКА ПРОГРАММЫ НАЖМИТЕ ПРОБЕЛ");
            Arrow();
        }
        public static void Arrow()
        {
            Note note1 = new()
            {
                Name = "сделаю си шарпик",
                Description = "Или да",
                EndDate = new DateTime(2022, 10, 14)
            };

            Note note2 = new()
            {
                Name = "Выспаться",
                Description = "не я же в мпт учусь",
                EndDate = new DateTime(2022, 10, 16)
            };

            Note note3 = new()
            {
                Name = "маме помочь",
                Description = "купить продукты и яйца",
                EndDate = new DateTime(2022, 10, 16)
            };

            Note note4 = new()
            {
                Name = "купить саше шоколадку",
                Description = "падла блин",
                EndDate = new DateTime(2022, 10, 15)
            };

            Note note5 = new()
            {
                Name = "Поехать утром в москву",
                Description = "надеюсь без пробок",
                EndDate = new DateTime(2022, 10, 15)
            };

            List<Note> allNotes = new()
            {
                note1,
                note2,
                note3,
                note4,
                note5
            };

            DateTime dayNow = new(2022, 10, 15);
            int position = 1;
            var key = ReadKey();
            while (key.Key != Enter)
            {
                switch (key.Key)
                {
                    case UpArrow:
                        position--;
                        break;
                    case DownArrow:
                        position++;
                        break;
                    case LeftArrow:
                        dayNow = dayNow.AddDays(-1);
                        break;
                    case RightArrow:
                        dayNow = dayNow.AddDays(1);
                        break;
                    case OemPlus:
                        //allNotes = Add(position, dayNow, allNotes);
                        break;
                    case OemMinus:
                        allNotes = Remove(position, dayNow, allNotes);
                        break;
                    case Escape:
                        Clear();
                        WriteLine(" нне забывай про меня");
                        Environment.Exit(0);
                        break;
                }

                Clear();

                ShowDate(dayNow, allNotes);

                SetCursorPosition(0, position);
                WriteLine("->");

                key = ReadKey();
            }

            Clear();
            ShowInfo(position, dayNow, allNotes);
            Arrow();
        }
        private static void ShowInfo(int position, DateTime date, List<Note> myNotes)
        {
            List<Note> sortedNotes = myNotes.Where(note => note.EndDate.Date == date.Date).ToList();
            WriteLine(sortedNotes[position - 1].Name +
                      "\t" + "|" + "\t" +
                      sortedNotes[position - 1].EndDate.Date + "\n" +
                    
                      " " + sortedNotes[position - 1].Description + "\n" + "\n" +
                      
                      "Для возвращения меню нажмите Пробел");
        }
        private static void ShowDate(DateTime date, List<Note> myNotes)
        {
            Clear();
            ForegroundColor = Green;
            WriteLine("-*-*-" + date.ToLongDateString() + "-*-*-");

            List<Note> sortedNotes = myNotes.Where(note => note.EndDate.Date == date.Date).ToList();
            foreach (Note note in sortedNotes)
            {
                WriteLine("  " + note.Name);
            }
        }
        private static List<Note> Remove(int position, DateTime date, List<Note> myNotes)
        {
            List<Note> sortedNotes = myNotes.Where(note => note.EndDate.Date == date.Date).ToList();
            Note forDelete = sortedNotes[position - 1];
            myNotes.Remove(forDelete);
            foreach (Note note in myNotes)
            {
                WriteLine("  " + note.Name);
            }

            return myNotes;

        }

        private static List<Note> Add(int position, DateTime date, List<Note> myNotes)
        {
            List<Note> sortedNotes = myNotes.Where(note => note.EndDate.Date == date.Date).ToList();
            Note newNote = new Note();
            sortedNotes.Add(newNote);

            return myNotes;
        }
    }
}