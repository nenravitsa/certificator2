using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sertificator
{
    class SystemLogic
    {
        private int menuNumber = 1;
        public void Start()
        {
            var answer = 0;
            var workServices = new Services();
            var workSertificat = new Sertificat();
            int num = 0;
            string name = "";
            do
            {
                switch (menuNumber)
                {
                    case 1:
                        answer= StartMenu() * 10;
                        menuNumber = answer;
                        break;

                    case 10:
                        
                        answer=UI.CreateNewService();
                        if (answer != 0)
                        {
                            menuNumber += answer;
                        }
                        else
                        {
                            menuNumber = 1; 
                            workServices.WriteSettings();
                        }
                        break;

                     case 20:
                        workServices.ReadSettings();
                         answer=UI.WorkWithExistService();
                        if (answer != 0)
                        {
                            menuNumber += answer;
                        }
                        else menuNumber = 1;

                        break;

                    case 30:
                        answer = UI.CreateSertificate();
                        if (answer != 0)
                        {
                            menuNumber += answer;
                        }
                        else menuNumber = 1;
                        break;

   
                    case 11:
                        workServices.PrintServices();
                        menuNumber = 10;
                        break;
                    case 12:
                        num = 0;
                        name = null;
                        answer = UI.AddService(out num, out name);
                        if (answer != 0)
                        {
                            workServices.AddService(num, name);
                        }
                        else menuNumber = 10;
                        break;

                    case 13:
                        answer = UI.DeleteService(workServices.GetNumber());
                        if (answer != 0)
                        {
                            workServices.DeleteService(answer);
                        }
                        else menuNumber = 10;
                        break;

                    case 21:
                        workServices.PrintServices();
                        menuNumber = 10;
                        break;

                    case 22:
                        num=0;
                        name = null;
                        answer = UI.AddService(out num, out name);
                        if (answer != 0)
                        {
                            workServices.AddService(num, name);
                        } else menuNumber = 20;
                        break;

                    case 23:
                        answer = UI.DeleteService(workServices.GetNumber());
                        if (answer != 0)
                        {
                            workServices.DeleteService(answer);
                        }
                        else menuNumber = 20;
                        break;

                    case 31:
                        workServices.PrintServices();
                        menuNumber = 30;
                        break;

                    case 32:
                        menuNumber = 320;
                        break;

                      
                    case 320:
                        answer = UI.ChangeCertificat();
                        if (answer != 0)
                        {
                            if (answer != 2)
                                workSertificat.ChangeSettings(answer, UI.InputString());
                            else
                            {
                                workServices.PrintServices();
                                var chService = UI.SelectionService(workServices.GetNumber());
                                workSertificat.ChangeSettings(answer,"", chService);
                            }
                        }
                        else menuNumber = 30;
                        break;

                    case 33:
                    {
                        workSertificat.Create(workServices);
                        var doPDF = new CreatePDF(workSertificat, workServices);
                        doPDF.Create();
                        Console.WriteLine("Сертификат в формате PDF создан!");
                        Console.WriteLine("Выберете дальнейшее действие:");
                        menuNumber = 30;
                    }
                        break;
                }
            } while (menuNumber !=0);

            EndOfWork();
            
        }

        private int StartMenu()
        {
            return UI.StartMenu();
        }

        private void EndOfWork()
        {
            Console.Clear();
            Console.WriteLine("********* See You later *********");
            Console.WriteLine("\n      *** THE END ***");
        }

    }
}
