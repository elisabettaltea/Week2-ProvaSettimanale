using System;
using System.Collections.Generic;
using System.IO;
using static PartePratica.Task;

namespace PartePratica
{
    internal class TasksManager
    {
        public static List<Task> tasks = new List<Task>();
        static string path = @"C:\Users\Betta\Desktop\Week2-ProvaSettimanale\Week2-ProvaSettimanale\PartePratica\Tasks.txt";

        public static void MostraTasks(List<Task> tasks)
        {
            if (tasks.Count > 0)
            {
                int count = 1;
                foreach (Task task in tasks)
                {
                    Console.WriteLine($"{count} -> Descrizione: {task.Descrizione}, Scadenza: {task.DataDiScadenza.ToString("dd/MM/yyyy")}, LivelloDiPriorità: {task.Priorità}");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Nessun task presente");
            }
        }

        public static void MostraTasks()
        {
            MostraTasks(tasks);
        }

        public static void AggiungiTask()
        {
            Task task = new Task();

            Console.WriteLine("Inserisci la descrizione del Task");
            task.Descrizione = Console.ReadLine();

            task.DataDiScadenza = InserisciData();

            task.Priorità = ScegliLivelloPriorità();

            tasks.Add(task);
        }

        public static DateTime InserisciData()
        {
            bool isDateTime = false;
            DateTime dataInserita = new DateTime(); 

            do
            {
                Console.WriteLine("Inserisci la data di scadenza del task " +
                    "(la data di scadenza deve essere posteriore alla data di inserimento del task)");
                isDateTime = DateTime.TryParse(Console.ReadLine(), out dataInserita);
            } while (!isDateTime || dataInserita <= DateTime.Now.Date);

            return dataInserita;
        }

        public static Task.Livello ScegliLivelloPriorità()
        {
            bool isInt = false;
            int priorità = 0;
            do
            {
                Console.WriteLine($"Premi {(int)Livello.Basso} per scegliere il livello di priorità {Livello.Basso}");
                Console.WriteLine($"Premi {(int)Livello.Medio} per scegliere il livello di priorità {Livello.Medio}");
                Console.WriteLine($"Premi {(int)Livello.Alto} per scegliere il livello di priorità {Livello.Alto}");

                isInt = int.TryParse(Console.ReadLine(), out priorità);
            } while (!isInt || priorità < 0 || priorità > 2);

            return (Livello)priorità;
        }

        public static void EliminaTask()
        {
            MostraTasks();

            bool isInt = false;
            int numTask = 0;

            do
            {
                Console.WriteLine("Inserisci il numero del task che vuoi eliminare");
                isInt = int.TryParse(Console.ReadLine(), out numTask);
            } while (!isInt || numTask < 1 || numTask > tasks.Count);

            tasks.RemoveAt(numTask - 1);
        }

        public static void FiltraTasks()
        {
            Livello prioritàTask = ScegliLivelloPriorità();

            List<Task> tasksFiltrati = new List<Task>();

            foreach (Task task in tasks)
            {
                if (task.Priorità == prioritàTask)
                {
                    tasksFiltrati.Add(task);
                }
            }

            if (tasksFiltrati.Count > 0)
            {
                MostraTasks(tasksFiltrati);
            }
            else
            {
                Console.WriteLine($"Non sono presenti task con livello di priorità {prioritàTask}");
            }
        }

        public static void SalvaSuFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Tasks");
                sw.WriteLine();
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Task task in tasks)
                {
                    sw.WriteLine($"Scadenza: {task.DataDiScadenza.ToString("dd/MM/yyyy")}, Livello Di Priorità: {task.Priorità}, Descrizione: {task.Descrizione}");
                }
            }
        }
    }
}