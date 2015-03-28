using System;

namespace sertificator
{
    class Sertificat
    {
        #region Даныне сертификата

        public static int CurrentNumber { private set; get; }
        public int Numder { private set; get; }
        public int CodOfOrder { private set; get; }
        public DateTime DateOrder { private set; get; }
        public Decimal PriceOrder { private set; get; }
        public string Person { private set; get; }
        public string Phone { private set; get; }
        public string Email { private set; get; }

        public string Administrator { private set ; get;}
        #endregion

        public bool Create(Services currentServices)
        {
            Numder = CurrentNumber + 1;
            CurrentNumber++;
            Console.WriteLine("Введите данные сертификата № {0}", Numder);
            Console.WriteLine("Перечень сервисов");
            currentServices.PrintServices();
            CodOfOrder= UI.SelectionService(currentServices.GetNumber());  // ввод услуги
            if (CodOfOrder == 0) { return false; }
            Console.WriteLine("Введите ФИО получателя сертификата");
            Person = Console.ReadLine();
            Console.WriteLine( "Введите контактный телефон" );
            Phone  = Console.ReadLine();
            Console.WriteLine("Введите email");
            Email = Console.ReadLine();
            Console.WriteLine("Введите ФИО Администратора");
            Administrator = Console.ReadLine();
            DateOrder = DateTime.Now;
            return true;
        }

        public bool ChangeSettings(int sw,  string param2 = "", int param1 = 0)
        {
            switch (sw)
            {
                case 1:  // смена ФИО
                    Person = param2;
                    return true;
                    break;

                case 2: // изменение услуги
                    CodOfOrder= param1;
                    return true;
                    break;

                case 3:  // смена администратора
                    Administrator = param2;
                    return true;
                    break;

            }
            return false;
        }
        

    }
}
