using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTo
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }


    class User
    {
        public string Name { set; get; }
        public int Age { get; set; }
        public List<string> Language { get; set; }
        public User()
        {
            new List<string>();
        }
    }
    class Phone
    {
        public string Name { set; get; }
        public string Company { set; get; }
    }





    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }




    class Program
    {
        static void Main(string[] args)
        {
            string[] teams = { "Бавария", "Борусия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            int[] numbers = { 1, 23, 45, 5, 7, 878, 989, 6, 67, 4, 7, 12, 5 };
            string[] soft = { "Mircrosoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };



            List<User> users = new List<User> {
                new User {Name="Bob", Age = 14, Language = new List<string> {"Английский","Арабский" } },
                new User {Name="Tom", Age = 24, Language = new List<string> {"Английский","Француский" } },
                new User {Name="Jon", Age = 14, Language = new List<string> {"Английский","португальский" } },
                new User {Name="Bob", Age = 30, Language = new List<string> { "Арабский", "Француский" } }
            };

            List<Person> person = new List<Person>()
            {
                new Person() { Name="Andrey", Age=24,City="Kyiv"},
                new Person() { Name="Liza", Age=18,City="Moscow"},
                new Person() { Name="Oleg", Age=15,City="lONDON"},
                new Person() { Name="Sergey", Age=55,City="Kyiv"},
                new Person() { Name="Sergey", Age=32,City="Kyiv"},
            };

            List<Phone> phones = new List<Phone> {
                new Phone {Name = "Lumia 630", Company="Misrosoft" },
                new Phone {Name = "IPhone 6", Company="Apple Кривой Рог" }
            };


            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
            };
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee()
                { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee()
                { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee()
                { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee()
                { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee()
                { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee()
                { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepId = 4 }
            };

            Console.WriteLine("---1");
            var result1 = from employe in employees
                          from d in departments
                          where d.City != "Donetsk" && d.Country == "Ukraine" && employe.DepId ==d.Id
                          select employe;
            foreach (var item in result1)
            {
                Console.WriteLine($"{ item.FirstName} {item.LastName}");
            }


            ///
            Console.WriteLine("---1.2");
            var select61 = employees.Join(departments,
                e=>e.DepId,
                d=>d.Id,
                (e, d)=>new { e.FirstName, e.LastName, d.City, d.Country}).
                Where(d => d.City != "Donetsk" && d.Country == "Ukraine");

            foreach (var item in select61)
            {
                Console.WriteLine($"{ item.FirstName} {item.LastName}");
            }


            Console.WriteLine("---2");
            var result2 = (from d in departments
                           select d.Country).Distinct();
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---3");
            var result3 = (from d in employees
                          where d.Age>25
                          select d).Take(3);
            foreach (var item in result3)
            {
                Console.WriteLine(item.FirstName);
            }


            Console.WriteLine("---4");

            var result4 = from employe in employees
                          from d in departments
                          where d.City == "Kyiv" && employe.Age > 21 && employe.DepId == d.Id
                          select employe;
            foreach (var item in result4)
            {
                Console.WriteLine($"{ item.FirstName} {item.LastName} {item.Age}");
            }









            Console.WriteLine("---1");
            var select1 = (from p in person
                           where p.Age > 25
                           select p).Distinct();
            foreach (var item in select1)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("---1.1");
            var select2 = person.Where(p => p.Age > 25);
            foreach (var item in select2)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("---2");
            var select3 = from p in person
                          where p.City!= "Kyiv"
                          select p;
            foreach (var item in select3)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("---2.1");
            var select4 = person.Where(p => p.City != "Kyiv");
            foreach (var item in select4)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("---3");
            var select5 = from p in person
                          where p.City == "Kyiv"
                          select p.Name;
            foreach (var item in select5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---3.1");
            var select6 = person.Where(p => p.City == "Kyiv").Select(/*p=>p.Name*/p=>new { p.Name,p.City});
            foreach (var item in select6)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("---4");
            var select7 = from p in person
                          where p.Age>35 && p.Name == "Sergey"
                          select p;
            foreach (var item in select7)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("---4.1");
            var select8 = person.Where(p => p.Age > 35 && p.Name == "Sergey");
            foreach (var item in select8)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("---5");
            var select9 = from p in person
                          where p.City == "Moscow"
                          select p;
            foreach (var item in select9)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("---5.1");
            var select10 = person.Where(p => p.City == "Moscow");
            foreach (var item in select10)
            {
                Console.WriteLine(item.Name);
            }



            


            //Основы LINQ
            Console.WriteLine("--------Основы LINQ--------");
            MethodLinQ(teams);

            //Фильтрация
            Console.WriteLine("--------Основы Фильтрация--------");
            MethodLinQ2(numbers);

            //Выборка сложных обьектов
            Console.WriteLine("--------Выборка сложных обьектов--------");
            MethodLinQ3(users);

            //Проэкция
            Console.WriteLine("--------Проэкция--------");
            MethodLinQ4(users);

            //Выборка из нескольких источников
            Console.WriteLine("--------Выборка из нескольких источников--------");
            MethodLinQ5(users, phones);

            //Сортировка
            Console.WriteLine("--------Сортировка--------");
            MethodLinQ6(users);

            //Работа с множествами
            //Разность множеств
            Console.WriteLine("\n\n--------Работа с множествами--------\n");
            Console.WriteLine("--------Разность множеств--------");
            MethodLinQ7(soft, hard);
            //Пересечения множеств
            Console.WriteLine("--------Пересечения множеств--------");
            MethodLinQ8(soft, hard);
            //Обьединение множеств
            Console.WriteLine("--------Обьединение множеств--------");
            MethodLinQ9(soft, hard);
            //Удаление дубликатов
            Console.WriteLine("--------Удаление дубликатов--------");
            MethodLinQ10(soft, hard);


            //Агрегатные операции
            Console.WriteLine("\n\n--------Агрегатные операции--------\n");
            //Метод Aggregate
            Console.WriteLine("--------Метод Aggregate--------");
            MethodLinQ11(numbers);
            //Методы агрегирования
            Console.WriteLine("--------Методы агрегирования--------");
            MethodLinQ12(numbers,users);

            //Take, Skip, Take and skip
            Console.WriteLine("--------Take, Skip, Take and skip--------");
            MethodLinQ13(numbers);

            //TakeWhile,SkipWhile
            Console.WriteLine("--------TakeWhile,SkipWhile--------");
            MethodLinQ14(teams);

        }
        //TakeWhile,SkipWhile
        private static void MethodLinQ14(string[] teams)
        {
            foreach (var item in teams.TakeWhile(team=>team.StartsWith("Б")))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------");
            foreach (var item in teams.Skip(5).TakeWhile(team => team.StartsWith("Б")))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------");
            foreach (var item in teams.SkipWhile(team => team.StartsWith("Б")))
            {
                Console.WriteLine(item);
            }

        }

        //Take, Skip, Take and skip
        private static void MethodLinQ13(int[] numbers)
        {
            var result = numbers.Take(3);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");
            foreach (var item in numbers.Skip(3))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");
            foreach (var item in numbers.Skip(4).Take(3))
            {
                Console.WriteLine(item);
            }



        }

        //Методы агрегирования
        private static void MethodLinQ12(int[] numbers, List<User>users)
        {
           int size =( from i in numbers where i % 2 == 0 && i > 10 select i).Count();
           Console.WriteLine(size);

           Console.WriteLine(numbers.Count(i => i % 2 == 0 && i > 10));
        //Сум возрозтов
           Console.WriteLine(users.Sum(user=>user.Age));
            //MIn
            Console.WriteLine(numbers.Min());
            Console.WriteLine(users.Min(u=>u.Age));
            //Max
            Console.WriteLine(numbers.Max());
            Console.WriteLine(users.Max(u => u.Age));
            //Average
            Console.WriteLine(numbers.Average());
            Console.WriteLine(users.Average(u => u.Age));

        }

        //Метод Aggregate
        private static void MethodLinQ11(int[] numbers)
        {
            int query = numbers.Aggregate((x,y)=>x-y); // 1-12-45-5...n
        }

        //Удаление дубликатов
        private static void MethodLinQ10(string[] soft, string[] hard)
        {
            foreach (var item in soft.Concat(hard).Distinct())
            {
                Console.WriteLine(item);
            }
        }

        //Обьединение множеств
        private static void MethodLinQ9(string[] soft, string[] hard)
        {
            var result = soft.Union(hard);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------");
            foreach (var item in soft.Concat(hard))
            {
                Console.WriteLine(item);
            }

        }

        //Пересечения множеств
        private static void MethodLinQ8(string[] soft, string[] hard)
        {
            var result = soft.Intersect(hard);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        //Разность множеств
        private static void MethodLinQ7(string[] soft, string[] hard)
        {
            var result = soft.Except(hard);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        //Сортировка
        private static void MethodLinQ6(List<User> users)
        {
            var result = from user in users
                         orderby user.Name, user.Age, user.Language[0] descending
                         select user;
            foreach (var item in result)
            {
                Console.WriteLine($"{ item.Name },{ item.Age},{ item.Language[0]}");
            }

            var resultTwo = users.OrderBy(u => u.Name).ThenBy(u => u.Age);
            foreach (var item in result)
            {
                Console.WriteLine($"{ item.Name },{ item.Age}");
            }
        }

        //Выборка из нескольких источников
        private static void MethodLinQ5(List<User> users, List<Phone> phones)
        {
            var people = from user in users
                         from phone in phones
                         select new { Name = user.Name, Phone = phone.Name };
            foreach (var item in people)
            {
                Console.WriteLine($"{item.Name} - {item.Phone}");
            }
        }

        //Проэкция
        private static void MethodLinQ4(List<User> users)
        {
            Console.WriteLine("----");
            var names = from user in users select user.Name;
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");
            var namesAge = from user in users
                           select new { FirstName = user.Name, UserAge = user.Age };
            foreach (var item in namesAge)
            {
                Console.WriteLine(item.FirstName+" "+item.UserAge);
            }

            ///через метод розширения
            //выборка по имени

            Console.WriteLine("----");
            foreach (var item in users.Select(u=>u.Name))
            {
                Console.WriteLine(item);
            }

            //выборка обьекта анонимного типа
            Console.WriteLine("----");
            var items = users.Select(u => new { u.Name,u.Age });
            foreach (var item in items)
            {
                Console.WriteLine(item.Name+" "+item.Age);
            }



        }

        //Выборка сложных обьектов
        private static void MethodLinQ3(List<User> users)
        {
            var selectedUsers = from user in users
                                where user.Age > 23
                                select user;
            foreach (var item in selectedUsers)
            {
                Console.WriteLine(item.Name+" "+item.Age);
            }
            Console.WriteLine("----");
            var selectedUsersLang = from user in users
                                    from lang in user.Language
                                    where user.Age > 23
                                    where lang == "Английский"
                                    select user;
            foreach (var item in selectedUsersLang)
            {
                Console.WriteLine(item.Name+" "+item.Age);
            }

            Console.WriteLine("----");
            var selectedUsersLangM = users.SelectMany(user => user.Language, (u, l) => new { User = u, lang = l }).
                Where(u => u.lang == "Английский" && u.User.Age > 23).Select(u => u.User);
            foreach (var item in selectedUsersLangM)
            {
                Console.WriteLine(item.Name+" "+item.Age);
            }



        }

        //Фильтрация
        private static void MethodLinQ2(int[] numbers)
        {
            IEnumerable<int> result = from number in numbers
                                      where number > 10 && number % 2 == 0
                                      select number;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            //средствами розширеных методов
            IEnumerable<int> result2 = numbers.Where(number => number > 10 && number % 2 == 0).OrderBy(t => t);
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            //or
            foreach (var item in numbers.Where(number => number > 10 && number % 2 == 0))
            {
                Console.WriteLine(item);
            }
        }

        //Основы LINQ
        private static void MethodLinQ(string[] teams)
        {
            /*IEnumerable<string>*/
            var selectedTeam = from team in teams //опеределяем каждый обьект из teams как team
                               where team.StartsWith("Б") //фильтрация по критериям
                               orderby team //сортируем по возрастанию
                               select team/*.ToUpper()*/; //выбираем обьект

            //Console.WriteLine(selectedTeam.GetType().Name);
            foreach (var item in selectedTeam)
            {
                Console.WriteLine(item.GetType().Name);
                Console.WriteLine(item);
            }

            ///синтаксис методов
            //or            var selectdTeam2 = teams.Where((string team) => { return team.StartsWith("Б"); });
            var selectdTeam2 = teams.Where(team => team.StartsWith("Б")).Select(t => t.ToUpper());
            foreach (var item in selectdTeam2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
