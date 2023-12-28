using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Zadanie24_
{
    public class Vodii // Клас "Водії"
    {
        public int Vkey { get; set; } // Ключ
        public string Pib { get; set; } // ПІБ
        public string Stazh { get; set; } // Стаж
        public string ANumber { get; set; } // Державний номер авто
        public string Udost { get; set; } // Посвідчення
        public string Date { get; set; } // Дата
        public int AktNumber { get; set; } // Номер акту про ДТП
        public Vodii() { } // Пустой конструктор
        public Vodii(int v, string p, string s, string an, string u, string d, int akn) // Конструктор
        { this.Vkey = v; this.Pib = p; this.Stazh = s; this.ANumber = an; this.Udost = u; this.Date = d; this.AktNumber = akn; }
        public override string ToString() => $"Ключ: {Vkey}, П.І.Б: {Pib}, Стаж: {Stazh} роки (років), Держ. номер авто: {ANumber}, Посвідчення: {Udost}, Дата: {Date}, Номер акту про ДТП: {AktNumber}\n";
    }
    public class Avto // Клас «Автомобіль»
    {
        public int Akey { get; set; } // Ключ
        public string Firm { get; set; } // Фірма
        public string Marka { get; set; } // Марка
        public string Type { get; set; } // Тип кузова
        public string ANumber { get; set; } // Державний номер авто
        public Avto() { } // Пустой конструктор
        public Avto(int k, string f, string m, string t, string an) // Конструктор с параметрами
        { this.Akey = k; this.Firm = f; this.Marka = m; this.Type = t; this.ANumber = an; }
        public override string ToString() => $"Ключ: {Akey}, Фірма: {Firm}, Марка: {Marka}, Тип кузова: {Type}, Держ. номер авто {ANumber}";
    }
    public class Viddil // Клас «Відділ ДІБДР»
    {
        public int Dkey { get; set; } // Ключ
        public string Name { get; set; } // Назва
        public int AktNumber { get; set; } // Номер акта про ДТП
        public string Vodila { get; set; } // Водій
        public string ANumber { get; set; } // Державний номер авто
        public string Date { get; set; } // Дата
        public string Place { get; set; } // Місце
        public int DamageCount { get; set; } // Кількість постраждалих
        public string Typedtp { get; set; } // Вид ДТП
        public string Causedtp { get; set; } // Причина ДТП
        public Viddil() { } // Пустой конструктор
        public Viddil(int d, string n, int akn, string v, string an, string dd, string p, int dc, string tdtp, string cdtp) // Конструктор с параметрами
        { this.Dkey = d; this.Name = n; this.AktNumber = akn; this.Vodila = v; this.ANumber = an; this.Date = dd; this.Place = p; this.DamageCount = dc; this.Typedtp = tdtp; this.Causedtp = cdtp; }
        public override string ToString() => $"Ключ: {Dkey}, Назва: {Name}, Номер акту про ДТП: {AktNumber}, Водій: {Vodila}, Держ. номер авто: {ANumber}, Дата: {Date}, Місце {Place}, Кількість постраждалих: {DamageCount}, Вид ДТП: {Typedtp}, Причина ДТП: {Causedtp}\n";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StreamReader FileIn = new StreamReader("C:\\Users\\777\\source\\repos\\КурсоваВ№5\\КурсоваВ№5\\Vodii.txt",
            Encoding.Default); //Заповнюємо таблицю "Водії"
            int v1;
            int akn1;
            string s;
            string[] ms;
            Vodii Vodii1 = new Vodii();
            List<Vodii> Vodii = new List<Vodii>();
            while ((s = FileIn.ReadLine()) != null) // Поки не досягнемо кінця файлу
            {
                ms = s.Split(';'); // Розщіплення на масив строк
                                   // Додавання строки через конструктор з параметрами
                v1 = int.Parse(ms[0]);
                akn1 = int.Parse(ms[6]);
                Vodii.Add(new Vodii(v1, ms[1], ms[2], ms[3], ms[4], ms[5],akn1 ));
            }// От while
            foreach (Vodii f1 in Vodii)
            {
                Console.WriteLine("{0} {1,-25}\t{2,-8}\t{3,-5}\t{4}\t{5}\t{6}", f1.Vkey, f1.Pib, f1.Stazh,
                 f1.ANumber, f1.Udost , f1.Date , f1.AktNumber);
            }
            Console.WriteLine();



            StreamReader FileIn2 = new StreamReader("C:\\Users\\777\\source\\repos\\КурсоваВ№5\\КурсоваВ№5\\Avto.txt",
            Encoding.Default); //Заповнюємо таблицю "Автомобіль"
            int a2;
            string s2;
            string[] ms2;
            Avto Avto1 = new Avto();
            List<Avto> Avto = new List<Avto>();
            while ((s2 = FileIn2.ReadLine()) != null) // Поки не досягнемо кінця файлу
            {
                ms2 = s2.Split(';'); // Розщіплення на масив строк
                                     // Додавання строки через конструктор з параметрами
                a2 = int.Parse(ms2[0]);
                Avto.Add(new Avto(a2, ms2[1], ms2[2], ms2[3], ms2[4]));
            }
            // От while
            foreach (Avto o2 in Avto)
            {
                Console.WriteLine("{0} {1,-12}\t{2,-20}\t{3}\t{4}", o2.Akey, o2.Firm, o2.Marka, o2.Type, o2.ANumber);
            }



            StreamReader FileIn3 = new StreamReader("C:\\Users\\777\\source\\repos\\КурсоваВ№5\\КурсоваВ№5\\Otdel.txt",
            Encoding.Default); //Заповнюємо таблицю "Відділ"
            int d3;
            int akn3;
            int dc3;
            string s3;
            string[] ms3;
            Viddil Viddil1 = new Viddil();
            List<Viddil> Viddil = new List<Viddil>();
            while ((s3 = FileIn3.ReadLine()) != null) // Пока не конец файла
            {
                ms3 = s3.Split(';'); // Розщіплення на масив строк
                                     // Додавання строки через конструктор з параметрами
                d3 = int.Parse(ms3[0]);
                akn3 = int.Parse(ms3[2]);
                dc3 = int.Parse(ms3[7]);
                Viddil.Add(new Viddil(d3, ms3[1], akn3, ms3[3], ms3[4], ms3[5], ms3[6], dc3, ms3[8], ms3[9]));
            }// От while
            foreach (Viddil f3 in Viddil)
            {
                Console.WriteLine("{0} {1,-5}\t{2,-5}\t{3,-25}\t{4}\t{5}\t{6,-20}\t{7}\t{8,-15}\t{9}", f3.Dkey, f3.Name, f3.AktNumber, f3.Vodila, f3.ANumber, f3.Date, f3.Place, f3.DamageCount, f3.Typedtp, f3.Causedtp);
            }
            Console.WriteLine();
            Console.WriteLine("Щоб продовжити натисніть 1, щоб вийти натисніть будь-яку клавішу:");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Ініціалізовано вихід з консолі...");
                    return;
            }
            static void CountDTP(List<Vodii> vodiis)
            {
                Console.WriteLine("Водії, які вчинили більше ДТП:");
                for (int i = 0; i < vodiis.Count; i++)
                {
                    if (vodiis[i].AktNumber > 1)
                    {
                        Console.WriteLine(vodiis[i].Pib);
                    }
                }
            }
            static void DtpPlace(List<Viddil> place)
            {
                Console.WriteLine("Список місць, в яких відбулось ДТП:\n1. St. Sumska\n2. Constitution Square\n3. St. Novgorodska\n4. St. Omska\n5. Pr. Gagarina");
                Console.WriteLine("\nВведіть будь-ласка місце ДТП (Краще скопіювати):");
                string s = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Водії, які беруть участь у ДТП в задану дату:");
                for (int i = 0; i < place.Count; i++)
                {
                    if (place[i].Place.ToLower() == s.ToLower())
                    {
                        Console.WriteLine(place[i].Vodila);
                    }
                }
            }
            static void DtpDate(List<Viddil> date)
            {
                Console.WriteLine("Список дат, в які відбулось ДТП:\n1. 01.12.2023\n2. 30.12.2023\n3. 06.12.2023\n4. 13.12.2023\n5. 17.12.2023");
                Console.WriteLine("\nВведіть будь-ласка дату ДТП (Краще скопіювати):");
                string s = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Водії, які беруть участь у ДТП в заданому місці:");
                for (int i = 0; i < date.Count; i++)
                {
                    if (date[i].Date.ToLower() == s.ToLower())
                    {
                        Console.WriteLine(date[i].Vodila);
                    }
                }
            }
            static void MaxDamageDtp(List<Viddil> maxdamage)
            {
                Console.WriteLine("ДТП із максимальною кількістю потерпілих:");
                string secondLine = File.ReadLines("C:\\Users\\777\\source\\repos\\КурсоваВ№5\\КурсоваВ№5\\Otdel.txt").ElementAtOrDefault(4);
                Console.WriteLine(secondLine);
            }
            static void NzDtp(List<Viddil> nz)
            {
                Console.WriteLine("Список водіїв, які беруть участь у ДТП із наїздом на пішоходів:");
                for (int i = 0; i < nz.Count; i++)
                {
                    if (nz[i].Causedtp == "Наїзд на пішоходів") { Console.WriteLine(nz[i].Vodila); }
                }
            }
            static List<Viddil> Add(List<Viddil> dtp)
            {

                int id = dtp[dtp.Count - 1].Dkey + 1;
                Console.WriteLine("Введіть назву: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введіть номер акту про ДТП:");
                int aktnumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введіть ПІБ водія (давати повні дані, наприклад: Пол Нестор Уокер): ");
                string pib = Console.ReadLine();
                Console.WriteLine("Введіть номер автомобіля, наприклад (АХ 0000 ХА):");
                string anumber = Console.ReadLine();
                Console.WriteLine("Введіть дату, формат: 01.01.0001");
                string date = Console.ReadLine();
                Console.WriteLine("Введіть місце ДТП, наприклад St. Sumska:");
                string place = Console.ReadLine();
                Console.WriteLine("Введіть кількість постраждалих:");
                int damagecount = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть тип ДТП:");
                string typedtp = Console.ReadLine();
                Console.WriteLine("Введіть причину ДТП:");
                string causedtp = Console.ReadLine();
                dtp.Add(new Viddil(id, name, aktnumber, pib, anumber, date, place, damagecount, typedtp, causedtp));
                return dtp;
            }
            static List<Viddil> Remove(List<Viddil> vodiis)
            {

                Console.WriteLine("Введіть ім'я водія для видалення інформації щодо ДТП з його участю. (Пол Нестор Уокер):");
                string name = Console.ReadLine();
                var vodiisToRemove = vodiis.FirstOrDefault(w => w.Name == name);

                if (vodiisToRemove != null)
                {
                    vodiis.Remove(vodiisToRemove);
                    Console.WriteLine($"{name} було видалено.");
                }
                else
                {
                    Console.WriteLine($"Водія з ім'ям {name} не знайдено.");
                }
                return vodiis;
            }
            string[] menuItems = new string[]
                { "1. Список водіїв, які вчинили більше ДТП",
                  "2. Список водіїв, які беруть участь у ДТП в заданому місці",
                  "3. Список водіїв, які беруть участь у ДТП на дану дату",
                  "4. ДТП із максимальною кількістю потерпілих",
                  "5. Список водіїв, які беруть участь у ДТП із наїздом на пішоходів",
                  "6. Причина ДТП у порядку зменшення їх кількості",
                  "7. Додати інформацію про ДТП",
                  "8. Видалити інформацію про ДТП",
                  "9. Вихід" };

                Console.WriteLine("Меню");
                Console.WriteLine();

                int row = Console.CursorTop;
                int col = Console.CursorLeft;
                int index = 0;
                while (true)
                {
                    DrawMenu(menuItems, row, col, index);
                    switch (Console.ReadKey(true).Key)
                    {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 0:
                                Console.Clear();
                                CountDTP(Vodii);
                                return;
                            case 1:
                                Console.Clear();
                                DtpPlace(Viddil);
                                return;
                            case 2:
                                Console.Clear();
                                DtpDate(Viddil);
                                return;
                            case 3:
                                Console.Clear();
                                MaxDamageDtp(Viddil);
                                return;
                            case 4:
                                Console.Clear();
                                NzDtp(Viddil);
                                return;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Кнопку не опрацьовано, через невміння автора.");
                                return;
                            case 6:
                                Console.Clear();
                                Add(Viddil);
                                return;
                            case 7:
                                Console.Clear();
                                Remove(Viddil);
                                return;
                            case 8:
                                Console.Clear();
                                Console.WriteLine("Ініціалізовано вихід з консолі...");
                                return;
                            default:
                                Console.WriteLine($"Обрано пункт: {menuItems[index]}");
                                break;
                        }
                        break;
                    }
                }

            static void DrawMenu(string[] items, int row, int col, int index)
            {
                Console.SetCursorPosition(col, row);
                for (int i = 0; i < items.Length; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(items[i]);
                    Console.ResetColor();
                }
            }
            

            /*Console.WriteLine("\nВодії");
            // Синтаксис запиту метода (в Select задано поле для вибірки)
            var f3Query = lst3.Select(e => e.Name);// Вік списку професій
            foreach (var pr in f3Query)
            {
                Console.WriteLine(pr);
            }
            Console.WriteLine("\nДодавання елементу до списку"); // Синтаксис запиту метода
            Console.WriteLine("Введіть ПІБ водія"); 
            string rei = Console.ReadLine();
            Console.WriteLine("Введіть стаж водія");
            string rei0 = Console.ReadLine();
            Console.WriteLine("Введіть державний номер авто");
            string rei1 = Console.ReadLine();
            Console.WriteLine("Введіть посвідчення водія (є , чи нема)");
            string rei2 = Console.ReadLine();
            Console.WriteLine("Введіть дату реєстру");
            string rei3 = Console.ReadLine();
            Console.WriteLine("Введіть номер акту про ДТП");
            int rei4 = Convert.ToInt32(Console.ReadLine());
            int rei5 = 1;
            lst1.Add(new Vodii(rei5, rei, rei0, rei1, rei2, rei3, rei4));
            foreach (Vodii f1 in lst1)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", f1.Vkey, f1.Pib, f1.Stazh, f1.ANumber, f1.Udost, f1.Date, f1.AktNumber);
            }
            Console.WriteLine();
            */
        }
    }
}