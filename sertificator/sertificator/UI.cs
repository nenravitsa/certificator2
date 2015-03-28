using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Crmf;

namespace sertificator
{
    static class UI
    {
        public static  int StartMenu() //#1
        {
            Console.WriteLine("********** Program Sertificator start ***********\n");
            Console.WriteLine("Чего изволите: ");
            Console.WriteLine("1. Создать базу данных по осуществляемым услугам?");
            Console.WriteLine("2. Загрузить существующую базу данных по осуществляемым услугам?");
            Console.WriteLine("3. Создать сертификат?");
            Console.WriteLine("0. Закончить работу с программой.");
            return InputMenu(3);
        }

        public static int WorkWithExistService() //#20
        {
            Console.WriteLine("********** Работа с существующими услугами ***********\n");
            Console.WriteLine("Чего изволите: ");
            Console.WriteLine("1. Вывести список доступных услуг?");
            Console.WriteLine("2. Добавить услугу?");
            Console.WriteLine("3. Удалить услугу?");
            Console.WriteLine("0. Закончить работу с услугами.");
            return InputMenu(3);
        }

        public static int CreateNewService() // #10
        {
            Console.WriteLine("********** Создание нового списка услуг ***********\n");
            Console.WriteLine("Чего изволите: ");
            Console.WriteLine("1. Вывести список доступных услуг?");
            Console.WriteLine("2. Добавить услугу?");
            Console.WriteLine("3. Удалить услугу?");
            Console.WriteLine("0. Закончить работу с услугами и сохранить данные.");
            return InputMenu(3);
        }

        public static int CreateSertificate() //30
        {
            Console.WriteLine("********** Создание сертификата ***********\n");
            Console.WriteLine("Чего изволите: ");
            Console.WriteLine("1. Вывести данные сертификата?");
            Console.WriteLine("2. Изменить данные сертификата?");
            Console.WriteLine("3. Создать сертификат?");
            Console.WriteLine("0. Закончить работу с услугами.");
            return InputMenu(3);
        }

        public static int SelectionService(int countServices) //#90
        {
            Console.WriteLine("********** Выберите  услугу ***********\n");
            Console.WriteLine("Введите номер услуги... ");
            Console.WriteLine("Или 0 для окончания работы с сервисом.");
            return InputMenu(countServices);
        }


        public static int AddService(out int num, out string name)
        {
            Console.WriteLine("********** Добавление  услуги ***********\n");
            Console.WriteLine("Введите номер услуги... ");
            Console.WriteLine("Или 0 для окончания работы с добавлением услуги.");
            num = InputMenu(100);
            Console.WriteLine("Введите описание услуги... ");
            name = Console.ReadLine();
            return num;
        }

        public static int DeleteService(int range)
        {
            Console.WriteLine("********** Удаление  услуги ***********\n");
            Console.WriteLine("Введите номер услуги... ");
            Console.WriteLine("Или 0 для окончания работы с удалением услуги.");
            return  InputMenu(range);
        }


        public static int ChangeCertificat() //320
        {
            Console.WriteLine("********** Изменение сертификата ***********\n");
            Console.WriteLine("Чего изволите: ");
            Console.WriteLine("1. Изменить ФИО клиента?");
            Console.WriteLine("2. Изменить услугу?");
            Console.WriteLine("3. Изменить администратора?");
            Console.WriteLine("0. Закончить работу с услугами.");
            return InputMenu(3);
        }

        public static string InputString()
        {
            Console.WriteLine("Введите новое значение...");
            return Console.ReadLine();
        }

        private static int InputMenu(int range)
        {
            int answer = 0;
            do
            {
                Console.WriteLine("Выберите действие ... ");
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (answer >= 0 && answer <= range)
                    {
                        return answer;
                    }
                    else
                    {
                        Console.WriteLine("Вы должны выбрать число от 0 до {0}", range);
                    }
                    Console.WriteLine("Вы должны выбрать число от 0 до {0}", range);
                }
            } while (true);
        }
    }
}
