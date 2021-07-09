using System;

namespace PartePratica
{
    internal class Menu
    {
        internal static void Start()
        {
            int scelta = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Premi 1 per visualizzare i tasks");
                Console.WriteLine("Premi 2 per inserire un nuovo task");
                Console.WriteLine("Premi 3 per eliminare un task");
                Console.WriteLine("Premi 4 per filtrare i tasks per importanza");
                Console.WriteLine("Premi 0 per uscire");

                while(!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 4)
                {
                    Console.WriteLine("Scelta sbagliata! Riprova");
                }

                switch (scelta)
                {
                    case 1:
                        TasksManager.MostraTasks();
                        break;
                    case 2:
                        TasksManager.AggiungiTask();
                        break;
                    case 3:
                        TasksManager.EliminaTask();
                        break;
                    case 4:
                        TasksManager.FiltraTasks();
                        break;
                    case 0:                       
                        TasksManager.SalvaSuFile();
                        break;
                }

            } while (scelta != 0);
        }
    }
}