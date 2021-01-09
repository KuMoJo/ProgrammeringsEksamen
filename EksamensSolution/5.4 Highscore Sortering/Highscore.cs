using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._4_Highscore_Sortering
{
    /// <summary>
    /// Klasse der definerer en Highscore og kan sammenligne scores.
    /// </summary>
    public class Highscore : IComparable<Highscore>
    {
        private string name;
        private int score;


        public string Name { get => name; set => name = value; }
        public int Score { get => score; set => score = value; }


        /// <summary>
        /// Constructor.
        /// </summary>
        public Highscore(string name, int score)
        {
            Name = name;
            Score = score;
        }


        /// <summary>
        /// Sammenlign med en anden highscore. Fra IComparable.
        /// Implementeringen af denne metode garanterer, at listen kan sorte Highscore-objekter.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Highscore other)
        {
            //Hvis scoren er ens, sammenlign da med navnene i stedet for. Alfabetisk.
            if (Score == other.score)
            {
                return Name.CompareTo(other.Name);
            }

            //Returnerer en sammenligning af de to scores.
            return other.Score.CompareTo(Score);
        }

        /// <summary>
        /// Returnerer en streng der repræsenterer Highscore-objektet.
        /// Bruges når man skriver Highscore-objektet ud i console.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Score.ToString() + ", " + Name;
        }
    }
}
