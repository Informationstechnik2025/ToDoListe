using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListe
{
    class Knoten<Typ>
    {
        public Typ Inhalt { get; set; }
        public Knoten<Typ> Naechter { get; set; }

        public Knoten(Typ inhalt)
        {
            Inhalt = inhalt;
            Naechter = null;
        }

        public override string ToString()
        {
            return $"Knoten ({Inhalt})";
        }
    }
}