using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook
{
    class Program
    {




        static void Main(string[] args)
        {
            int n;
            Note[] TheMyNote = new Note[0];
            DateTime DT = new DateTime();
            int Year, Mounth, Day;


            while (true)
            {
                Console.WriteLine("_______________________________");
                Console.WriteLine("0.Заполнить для наглядности");
                Console.WriteLine("1.Добавить Новую запись");
                Console.WriteLine("2.Отобразить записную книжку");
                Console.WriteLine("3.Отсортироовать по номеру");
                Console.WriteLine("4.Отсортироовать по Дате рождения");
                Console.WriteLine("5.Отсортироовать по фамилии");
                Console.WriteLine("6.Поиск");
                Console.WriteLine("7.Удалить запись");
                Console.WriteLine("8.Показать именниника");


                int.TryParse(Console.ReadLine(), out n);

                switch (n)
                {

                    case 1:
                        Note[] temp = new Note[TheMyNote.Length + 1];

                        temp[temp.Length - 1] = new Note();

                        for (int i = 0; i < TheMyNote.Length; i++)
                            temp[i] = TheMyNote[i];
                        Console.WriteLine("Введите номер телефона");
                        int.TryParse(Console.ReadLine(), out temp[temp.Length - 1].ThePhoneNumber);
                        Console.WriteLine("Введите фамилию");
                        temp[temp.Length - 1].TheSurname = Console.ReadLine();
                        Console.WriteLine("Введите имя и отчество");
                        temp[temp.Length - 1].TheName = Console.ReadLine();

                        Console.WriteLine("Введите город проживания:");
                        temp[temp.Length - 1].TheCity = Console.ReadLine();
                        Console.WriteLine("Место работы/учебы:");
                        temp[temp.Length - 1].TheWork = Console.ReadLine();
                        Console.WriteLine("Должность, характер знакомства, качества:");
                        temp[temp.Length - 1].TheWork1 = Console.ReadLine();

                        Console.WriteLine("Введите год рождения");
                        Year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц рождения");
                        Mounth = int.Parse(Console.ReadLine());
                        Console.WriteLine("День");
                        Day = int.Parse(Console.ReadLine());
                        DT = new DateTime(Year, Mounth, Day);

                        temp[temp.Length - 1].TheBirthday = DT;

                        DateTime now = DateTime.Now;
                        Console.WriteLine("Дата создания контакта: ");
                        Console.WriteLine(now);
                        temp[temp.Length - 1].TheDate = DateTime.Now;

                        TheMyNote = temp;

                        break;

                    case 2:
                        Note.Display(TheMyNote);
                        break;


                    case 0:
                        Note[] temp1 = new Note[6];
                        temp1[0] = new Note(125451, "Иванович", "Иван Иванович", "Волгоград", "ВолГУ", "Студент, одногруппник, прикольный", new DateTime(1990, 4, 1), new DateTime(2020, 4, 1, 4, 28, 27));
                        temp1[1] = new Note(12251, "Иванович", "Иван Иванович", "Волгоград", "ВолГУ", "Студент", new DateTime(1997, 8, 17), new DateTime(2020, 2, 1, 4, 5, 27));
                        temp1[2] = new Note(7851, "Иванович", "Иван Иванович", "Волгоград", "ВолГУ", "Студент", new DateTime(1992, 4, 1), new DateTime(2020, 8, 1, 4, 8, 27));
                        temp1[3] = new Note(175251, "Иванович", "Иван Иванович", "Волгоград", "ВолГУ", "Студент", new DateTime(1952, 5, 2), new DateTime(2020, 4, 1, 4, 5, 27));
                        temp1[4] = new Note(1277751, "Иванович", "Иван Иванович", "Волгоград", "ВолГУ", "Студент", new DateTime(1946, 4, 15), new DateTime(2020, 3, 1, 4, 5, 27));
                        temp1[5] = new Note(24751, "Иванович", "Иван Иванович", "Волгоград", "ВолГУ", "Студент", new DateTime(1928, 7, 28), new DateTime(2020, 7, 1, 4, 5, 27));

                        TheMyNote = temp1;

                        break;


                    case 3:
                        Note.NumberSort(TheMyNote);
                        Note.Display(TheMyNote);

                        break;

                    case 4:
                        Note.BirthdaySort(TheMyNote);
                        Note.Display(TheMyNote);

                        break;

                    case 5:
                        Note.SurNameSort(TheMyNote);
                        Note.Display(TheMyNote);

                        break;

                    case 6:
                        Console.WriteLine("Введите фимилию , или номер телефона");
                        Note.SearchNote(TheMyNote, Console.ReadLine());

                        break;



                    case 7:
                        Note.Display(TheMyNote);
                        Console.WriteLine("Введите номер записи для удаления");
                        int num = -1;
                        int.TryParse(Console.ReadLine(), out num);

                        if (num > 0 && num < TheMyNote.Length - 1)
                            TheMyNote = Note.DeleteNote(TheMyNote, num - 1);

                        Note.Display(TheMyNote);
                        break;


                    case 8:
                        Note.Birthday(TheMyNote);
                        Note.Display(TheMyNote);

                        break;


                    case 9:

                        break;
                }






            }

        }



    }
}


namespace PhoneBook
{


    // Класс запись
    class Note
    {
        public int ThePhoneNumber;
        public string TheSurname;
        public string TheName;
        public string TheCity;
        public string TheWork;
        public string TheWork1;
        public DateTime TheDate;
        public DateTime TheBirthday;


        public Note()       // конструктор умолчания
        {
        }


        public Note(int aPhoneNumber, string aSurname, string aName, string aCity, string aWork, string aWork1, DateTime aBirthday, DateTime name)   // Конструктор класса
        {
            ThePhoneNumber = aPhoneNumber;
            TheSurname = aSurname;
            TheName = aName;
            TheCity = aCity;
            TheWork = aWork;
            TheWork1 = aWork1;
            TheBirthday = aBirthday;
            TheDate = name;

        }




        public static void Birthday(Note[] MyNote)
        {
            foreach (var contact in MyNote)
            {
                if (contact.TheBirthday.Day == DateTime.Now.Day && contact.TheBirthday.Month == DateTime.Now.Month)
                    Console.WriteLine($"Сегодня день рождения у {contact.TheName} {contact.TheSurname}. Не забудь поздравить его");
            }
        }


    // функция вывода на экрам записной книги
    public static void Display(Note[] MyNote)
        {
            if (MyNote.Length != 0)
                for (int i = 0; i < MyNote.Length; i++)
                    Console.WriteLine("{8} : ФИО: {0} {1}, Город: {2}, Место учебы/работы {3}, Должность {4},  Дата рождения {5}, Номер телефона {6}, Дата создания контакта: {7}", MyNote[i].TheSurname, MyNote[i].TheName, MyNote[i].TheCity, MyNote[i].TheWork, MyNote[i].TheWork1, MyNote[i].TheBirthday, MyNote[i].ThePhoneNumber, MyNote[i].TheDate, i + 1);
            else
                Console.WriteLine("Записная книга пуста");
        }




        public static void NumberSort(Note[] MyNote)  // сортировка по номеру
        {
            Array.Sort(MyNote, LogicSortNumber);
        }


        public static void BirthdaySort(Note[] MyNote)  // сортировка по дате рождения
        {
            Array.Sort(MyNote, LogicSortBirthday);
        }

        public static void SurNameSort(Note[] MyNote)// сортировка по фамилии
        {
            Array.Sort(MyNote, LogicSortSurName);
        }



        static int LogicSortNumber(Note x, Note y)
        {
            if (x.ThePhoneNumber < y.ThePhoneNumber) return -1; //порядок соблюден
            if (x.ThePhoneNumber > y.ThePhoneNumber) return +1; //порядок нарушен
            return 0; // безразличие

        }

        static int LogicSortBirthday(Note x, Note y)
        {
            if (x.TheDate < y.TheDate) return -1; //порядок соблюден
            if (x.TheDate > y.TheDate) return +1; //порядок нарушен
            return 0; // безразличие
        }



        static int LogicSortSurName(Note x, Note y)
        {
            int i = 0;

            while (i < x.TheSurname.Length && i < y.TheSurname.Length)
            {

                if (x.TheSurname[i] < y.TheSurname[i]) return -1; //порядок соблюден
                if (x.TheSurname[i] > y.TheSurname[i]) return +1; //порядок нарушен
                i++;
            }
            if (x.TheSurname.Length < y.TheSurname.Length) return -1; //порядок соблюден
            if (x.TheSurname.Length > y.TheSurname.Length) return +1; //порядок нарушен
            return 0;


        }



        // Поиск по номеру или фамилии 
        public static void SearchNote(Note[] MyNote, string search)
        {
            int number = 0;
            bool flag = int.TryParse(search, out number);

            for (int i = 0; i < MyNote.Length; i++)
            {

                if (flag)
                    if (MyNote[i].ThePhoneNumber == int.Parse(search))
                    {
                        Console.WriteLine("Фамилия {0} , Дата рождения {1} , Номер телефона {2}", MyNote[i].TheSurname, MyNote[i].TheBirthday, MyNote[i].ThePhoneNumber);
                        number++;
                    }
                if (!flag)
                    if (MyNote[i].TheSurname == search)
                    {
                        Console.WriteLine("Фамилия {0} , Дата рождения {1} , Номер телефона {2}", MyNote[i].TheSurname, MyNote[i].TheBirthday, MyNote[i].ThePhoneNumber);
                        number++;
                    }
            }

            if (number == 0)
                Console.WriteLine("Нет записей с искомыми параметрами");



        }




        // удаление из записной книжки 

        public static Note[] DeleteNote(Note[] MyNote, int numberNote)
        {
            Note[] temp = new Note[MyNote.Length - 1];
            int k = 0;

            for (int i = 0; i < MyNote.Length; i++)
            {
                if (i == numberNote)
                    continue;
                temp[k++] = MyNote[i];

            }

            return temp;

        }








    }

}