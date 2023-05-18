using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace cinema_5D_Best_Films
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true; //когда все заполняться изменим на false и цикл не запуститься (наверное)
            Console.CursorVisible = true;

            Cinema[] seats = { new Cinema(1, 41), new Cinema(2, 57), new Cinema(3, 30) };

            int desiredPlaces = 0;

            while (isOpen)
            {
                Console.WriteLine("ООП Кинотеатр.\n");

                for (int i = 0; i < seats.Length; i++)
                {
                    seats[i].ShowInfo();
                }


                Console.WriteLine("\nКакой зал желаете: ");
                int wishSeats = Convert.ToInt32(Console.ReadLine()) - 1; //выбираем ЗАЛ в котором будем сидеть

                seats[wishSeats].CinemaHall(desiredPlaces);

                Console.WriteLine("Введите количество мест для брони: ");
                desiredPlaces = Convert.ToInt32(Console.ReadLine());

                //desiredPlaces.CinemaHall();
                seats[wishSeats].CinemaHall(desiredPlaces);

                bool isReservationCompleted = seats[wishSeats].Reserve(desiredPlaces); //desired - желаемых

                if (isReservationCompleted)
                {
                    Console.WriteLine("Бронь прошла успешно, ждем вас!");
                }
                else
                {
                    Console.WriteLine("Недостаточно свободных мест");
                }

                Console.ReadKey();

                Console.Clear();
            }


        }


    }

    class Cinema
    {
        public int Number;
        public int MaxPlaces;
        public int FreePlaces;
        public int reservedSeats;

        public int height;
        public int width;

        public int heightRed;
        public int widthRed;

        public Cinema(int number, int maxPlaces)
        {
            Number = number;
            MaxPlaces = maxPlaces;
            FreePlaces = maxPlaces;
        }


        public void ShowInfo()
        {
            Console.WriteLine($"Зал: {Number}. Свободно мест: {FreePlaces} из {MaxPlaces}:");
        }

        public bool Reserve(int places) //сюда отправляем количество мест которые хотим забронировать
        {
            if (FreePlaces >= places)
            {
                FreePlaces -= places;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CinemaHall(int reservedSeats) //и сюда тоже отправляем кол-во мест и номер зала
        {

            //Console.SetCursorPosition(0, 10);
            height = MaxPlaces / 10; //определяем высоту зала, ширина всегда = 10
            width = MaxPlaces % 10;  //тут добавляем недостоющее 

            //int[,] chairsInCinema = new int[height + 1, 10];
            int[,] chairsInCinema = new int[100, 10];

            if (reservedSeats == 0)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        chairsInCinema[i, j] = 0;
                        Console.Write(chairsInCinema[i, j]);
                    }
                    Console.WriteLine();
                }

                if (width != 0)
                {
                    for (int j = 0; j < width; j++)
                    {
                        chairsInCinema[j, height + 1] = 0;
                        Console.Write(chairsInCinema[j, height + 1]);
                    }
                }


                Console.WriteLine();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Console.SetCursorPosition(0, 16);
                height = reservedSeats / 10; //определяем высоту зала, ширина всегда = 10
                width = reservedSeats % 10;  //тут добавляем недостоющее 

                //int[,] chairsInCinema = new int[height + 1, 10];

                for (int i = 0; i < height; i++) //пишем красным цветом
                {
                    for (int j = 0; j < 10; j++)
                    {
                        chairsInCinema[i, j] = 1;
                        Console.Write(chairsInCinema[i, j]);
                    }
                    Console.WriteLine();
                }
                if (width != 0)
                {
                    for (int j = 0; j < width; j++)
                    {
                        chairsInCinema[j, height + 1] = 1;
                        Console.Write(chairsInCinema[j, height + 1]);
                    }
                    Console.WriteLine();
                }


                Console.ForegroundColor = ConsoleColor.White;
                for (int i = height; i < MaxPlaces / 10; i++)  //добавляем белым цветом
                {
                    for (int j = 0; j < 10; j++)
                    {
                        chairsInCinema[i, j] = 0;
                        Console.Write(chairsInCinema[i, j]);
                    }
                    Console.WriteLine();
                }
                if (width != 0)
                {
                    for (int j = width; j < MaxPlaces % 10; j++)
                    {
                        chairsInCinema[j, height + 1] = 0;
                        Console.Write(chairsInCinema[j, height + 1]);
                    }
                    Console.WriteLine();
                }
            }
            //return 1;
            /*
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("▀ ");
            */
            //Console.ForegroundColor = ConsoleColor.Black;

            //Console.ReadKey();
        }


    }
}
