using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListe
{
    class Liste<Typ>
    {
        public Knoten<Typ> Erster { get; set; }

        public Liste()
        {
            Erster = null;
        }

        /// <summary>
        /// Gibt die Anzahl der Knoten in der Liste zurück.
        /// </summary>
        /// <returns>Anzahl der Knoten in der Liste</returns>
        public int AnzahlElemente()
        {
            int zaehler = 0;
            Knoten<Typ> aktKnoten = Erster;
            while (null != aktKnoten)
            {
                zaehler++;
                aktKnoten = aktKnoten.Naechter;
            }
            return zaehler;
        }

        /// <summary>
        /// Überprüft, ob die Liste leer ist.
        /// </summary>
        /// <returns>True, wenn die Liste leer ist, sonst false</returns>
        public bool IstLeer()
        {
            return (Erster == null);
        }

        /// <summary>
        /// Gibt den Inhalt des Knotens an der Stelle "index" zurück.
        /// </summary>
        /// <param name="index">Der Index des Knotens</param>
        /// <returns>Inhalt des Knotens</returns>
        /// <exception cref="IndexOutOfRangeException">Falls kein Element mit diesem Index existiert</exception>
        public Typ Inhalt(int index)
        {
            if (AnzahlElemente() <= index)
                throw new IndexOutOfRangeException($"Es gibt keinen Knoten mit dem Index {index}");

            if (0 == index)
                return Erster.Inhalt;

            Knoten<Typ> aktuellerKnoten = Erster;
            for (int i = 0; i < index; i++)
            {
                aktuellerKnoten = aktuellerKnoten.Naechter;
            }

            return aktuellerKnoten.Inhalt;
        }

        /// <summary>
        /// Fügt einen neuen Knoten an der angegebenen Position ein.
        /// </summary>
        /// <param name="inhalt">Der Inhalt des neuen Knotens</param>
        /// <param name="position">Die Position, an der der Knoten eingefügt werden soll</param>
        /// <exception cref="IndexOutOfRangeException">Falls die Position ungültig ist</exception>
        public void Einfuegen(Typ inhalt, UInt16 position)
        {
            Knoten<Typ> neu = new Knoten<Typ>(inhalt);
            if (0 == position)
            {
                neu.Naechter = Erster;
                Erster = neu;
            }
            else
            {
                Knoten<Typ> aktKnoten = Erster;
                for (int zaehler = 0; zaehler < position - 1 && aktKnoten.Naechter != null; zaehler++)
                {
                    aktKnoten = aktKnoten.Naechter;
                }

                neu.Naechter = aktKnoten.Naechter;
                aktKnoten.Naechter = neu;
            }
        }

        /// <summary>
        /// Hängt einen neuen Knoten am Ende der Liste an.
        /// </summary>
        /// <param name="inhalt">Der Inhalt des neuen Knotens</param>
        public void Anhaengen(Typ inhalt)
        {
            Knoten<Typ> neu = new Knoten<Typ>(inhalt);
            if (Erster == null)
            {
                Erster = neu;
            }
            else
            {
                Knoten<Typ> akt = Erster;
                while (akt.Naechter != null)
                {
                    akt = akt.Naechter;
                }
                akt.Naechter = neu;
            }
        }

        /// <summary>
        /// Löscht den Knoten an der angegebenen Position.
        /// </summary>
        /// <param name="index">Der Index des Knotens, der gelöscht werden soll</param>
        /// <exception cref="IndexOutOfRangeException">Falls kein Knoten mit diesem Index existiert</exception>
        public void Loeschen(UInt16 index)
        {
            if (AnzahlElemente() <= index || Erster == null)
            {
                throw new IndexOutOfRangeException($"Es gibt keinen Knoten mit dem Index {index}");
            }

            if (index == 0)
            {
                Erster = Erster.Naechter;
                return;
            }

            Knoten<Typ> akt = Erster;
            for (int i = 0; i < index - 1; i++)
            {
                akt = akt.Naechter;
            }

            akt.Naechter = akt.Naechter.Naechter;
        }
    }
}