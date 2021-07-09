using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartePratica
{
    class Task
    {
        public string Descrizione { get; set; }
        public DateTime DataDiScadenza { get; set; }
        public Livello Priorità { get; set; }

        public Task()
        {

        }

        public enum Livello
        {
            Basso,
            Medio,
            Alto
        }
    }
}
