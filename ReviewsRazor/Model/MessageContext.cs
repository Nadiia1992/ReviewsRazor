using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;



namespace ReviewsRazor.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    FirstName = "Наталка",
                    LastName = "Діденко",
                    Login = "Natali",
                    Email = "Natali@gmail.com",
                    Password = "123123",
                },

                new Users
                {
                    Id = 2,
                    FirstName = "Ангеліна",
                    LastName = "Степанюк",
                    Login = "Angel",
                    Email = "Angela1@gmail.com",
                    Password = "qwery",
                },

                new Users
                {
                    Id = 3,
                    FirstName = "Сергій",
                    LastName = "Степанюк",
                    Login = "Serg",
                    Email = "Serg888@gmail.com",
                    Password = "qwery123",
                },

                new Users
                {
                    Id = 4,
                    FirstName = "Дмитро",
                    LastName = "Шпак",
                    Login = "Dmytro",
                    Email = "ShpakDmytro@gmail.com",
                    Password = "888888",
                },

                new Users
                {
                    Id = 5,
                    FirstName = "София",
                    LastName = "Ковальчук",
                    Login = "Sofi",
                    Email = "Sofi@gmail.com",
                    Password = "zxcvb",
                },

                new Users
                {
                    Id = 6,
                    FirstName = "Олена",
                    LastName = "Павленко",
                    Login = "Lena",
                    Email = "Pavlenko@gmail.com",
                    Password = "qweryqwerty",
                },

                new Users
                {
                    Id = 7,
                    FirstName = "Микола",
                    LastName = "Коваленко",
                    Login = "Top",
                    Email = "Mykola@gmail.com",
                    Password = "asdfg",
                },

                new Users
                {
                    Id = 8,
                    FirstName = "Оксана",
                    LastName = "Ткаченко",
                    Login = "!Angel!",
                    Email = "Angel@gmail.com",
                    Password = "angel",

                },

                new Users
                {
                    Id = 9,
                    FirstName = "Мария",
                    LastName = "Шевчук",
                    Login = "Mary",
                    Email = "Mary@gmail.com",
                    Password = "mary123",
                },

                new Users
                {
                    Id = 10,
                    FirstName = "Аліна",
                    LastName = "Мельник",
                    Login = "Star",
                    Email = "AlinaMelnyk@gmail.com",
                    Password = "qwerystar",
                }
            );

            modelBuilder.Entity<Message>().HasData(
             new Message
             {
                 Id = 1,
                 Comment = "Було дуже атмосферно та смачно",
                 MessageDate = new DateTime(2026, 9, 20, 15, 02, 0, 0),
                 Foto = "/picture/foto1.jpg",
                 UserId = 1
             },

             new Message
             {
                 Id = 2,
                 Comment = "Не рекомендуємо цей заклад. Вчора були в закладі, зібралися " +
                 "з друзями, так офіціант примусово ще добавила +10% від суми. " +
                 "Це враховуючи що ми зробили дуже велику виручку.",
                 MessageDate = new DateTime(2025, 8, 10, 9, 30, 0, 0),
                 Foto = "/picture/foto8.jpg",
                 UserId = 2
             },

             new Message
             {
                 Id = 3,
                 Comment = "Неймовірний ресторан, дуже привітний персонал, дуже затишно та сучасно. " +
                 "Пишаюся такими ресторанами, оці всі суші і тп вже набридли. " +
                 "Раджу скуштувати фірмовий сніданок ",
                 MessageDate = new DateTime(2025, 5, 8, 20, 7, 0, 0),
                 Foto = "/picture/foto3.jpg",
                 UserId = 3
             },

             new Message
             {
                 Id = 4,
                 Comment = "Святкували день народження, не сподобалось обслуговування і халатне відношення до " +
                 "відвідувачів , адміністрація не розраховує свої сили на велику кількість людей.",
                 MessageDate = new DateTime(2026, 4, 5, 6, 25, 0, 0),

                 UserId = 4
             },

             new Message
             {
                 Id = 5,
                 Comment = "Неймовірний ресторан, дуже привітний персонал, дуже затишно та сучасно. " +
                 "Пишаюся такими ресторанами, оці всі суші і тп вже набридли. " +
                 "Раджу скуштувати фірмовий сніданок ",
                 MessageDate = new DateTime(2025, 5, 8, 23, 2, 0, 0),
                 Foto = "/picture/foto2.jpg",
                 UserId = 5
             },

             new Message
             {
                 Id = 6,
                 Comment = "У п'ятницю святкували корпоратив з колегами, всім дуже все сподобалось. " +
                 "Їжа свіжа, смачна, адміністратори та офіціанти приємні в спілкуванні. " +
                 "Нас було 28 чоловік, і всі задоволені. Дякуємо за все.",
                 MessageDate = new DateTime(2025, 8, 30, 17, 25, 0, 0),
                 Foto = "/picture/foto7.jpg",
                 UserId = 6
             },

             new Message
             {
                 Id = 7,
                 Comment = "Прекрасний ресторан. Охайна територія, доброзичлививй персонал, дуже смачна кухня.",
                 MessageDate = new DateTime(2026, 5, 18, 16, 18, 0, 0),
                 Foto = "/picture/foto4.jpg",
                 UserId = 7
             },

             new Message
             {
                 Id = 8,
                 Comment = "Дуже сподобалося. Кухня ДУЖЕ самачна." +
                 "Дякуємо.Рекомендуємо всім. ",
                 MessageDate = new DateTime(2024, 8, 8, 19, 2, 0, 0),
                 Foto = "/picture/foto5.jpg",
                 UserId = 8
             },

             new Message
             {
                 Id = 9,
                 Comment = "Дуже гармонійне, затишне та естетичне місце, " +
                 "куди хочеться повертатися за атмосферою та відпочинком. Страви свіжі, " +
                 "красиві в подачі та орієнтовані на натуральні інгредієнти. " +
                 "Ідеальна локація для душевних зустрічей із друзями чи неспішного сімейного сніданку.",
                 MessageDate = new DateTime(2025, 7, 22, 8, 15, 0, 0),
                 Foto = "/picture/foto6.jpg",
                 UserId = 9
             },

             new Message
             {
                 Id = 10,
                 Comment = "Не впустили с маленької собачкою( чихуа), це жахливо, " +
                 "в нас було свято, вони его зіпсували!",
                 MessageDate = new DateTime(2025, 11, 12, 13, 20, 0, 0),
                 UserId = 10
             }
             );
        }
        public DbSet<Users> User => Set<Users>();
        public DbSet<Message> Messages => Set<Message>();
    }
}