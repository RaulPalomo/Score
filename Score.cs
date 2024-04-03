using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Score
{
    public class Score
    {
        public string Player {  get; set; }
        public string Mission { get; set; }
        public int Scoring { get; set; }
        public Score(string player,string mission, int score) 
        {
            Player = player;
            Mission = mission;
            Scoring = score;
        }
        public static void GenerateUniqueRanking(List <Score>scores)
        {
            string name = "";
            string mision = "";
            int number = 0;
            Score last=new Score(name,mision,number);
            scores.Sort((x, y) => y.Scoring.CompareTo(x.Scoring));

            //Eric, hugo
            var groupUp = scores.GroupBy(g => g.Player);
            
            foreach (var grupo in groupUp)
            {
                foreach(Score score in grupo)
                {
                    if(last.Player == score.Player&&last.Mission==score.Mission)
                    {
                        scores.Remove(score);
                    }
                    last= score;
                }
            }
            foreach (var grupo in groupUp)
            {
                Console.WriteLine("***************************************************");
                foreach (Score score in grupo)
                {
                    Console.WriteLine($"Jugador: {score.Player}  Misió: {score.Mission}  Puntuació: {score.Scoring}");
                }
                Console.WriteLine("***************************************************");
            }
        }

    }
}
