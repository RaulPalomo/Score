using System;
using System.Text.RegularExpressions;
namespace Score
{
    public static class ScoreProgram
    {
        public static void Main()
        {
            const string Welcome = "Benvingut a SCORE", MsgName="Escriu el nom de l'explorador: ",MsgMision="Escriu el nom de la misió: ",MsgScore="Escriu la puntuació: ";
            Console.WriteLine(Welcome);
            Regex nameRegex = new Regex(@"^[a-zA-Z]+$");
            Regex misionRegex = new Regex(@"^(Alpha|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mu|Nu|Xi|Omicron|Pi|Rho|Sigma|Tau|Upsilon|Phi|Chi|Psi|Omega)-\d{3}$");
            Regex scoreRegex= new Regex(@"^(?:[0-4]?[0-9]?[0-9]|500)$");
            List<Score> scores = new List<Score>();
            for (int i = 0; i < 10; i++)
            {
                string name="";
                string mision = "";
                string score;
                Console.WriteLine(MsgName);
                do
                { 
                    name=Console.ReadLine();
                    Console.WriteLine(!nameRegex.IsMatch(name)?"Valor no acceptat":"Valor acceptat");
                } while (!nameRegex.IsMatch(name));
                Console.WriteLine(MsgMision);
                do
                {
                    mision = Console.ReadLine();
                    Console.WriteLine(!misionRegex.IsMatch(mision) ? "Valor no acceptat" : "Valor acceptat");

                } while(!misionRegex.IsMatch(mision));
                Console.WriteLine(MsgScore);
                do
                {
                    score = Console.ReadLine();
                    Console.WriteLine(!scoreRegex.IsMatch(score) ? "Valor no acceptat" : "Valor acceptat");
                } while (!scoreRegex.IsMatch(score));
                Score newScore=new Score(name,mision,Convert.ToInt32(score));
                scores.Add(newScore);
            }

            Score.GenerateUniqueRanking(scores);


            
        }
    }
}
