using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterNumber
{
    class Program
    {  
        public static int NbCoups = 0;
        
        static void Main(string[] args)
        {
            // Generer les 4 chiffres

            List<int> LesChiffres = new List<int>();
            GenereLesChiffres(LesChiffres);
            Console.WriteLine("Bienvenue au jeu MonsterNumber. Les 4 chiffres à deviner ont été générés.");

            //Transformer les chiffres in strings

            List<string> LesChiffresS = new List<string>();
            foreach (int item in LesChiffres)
            {
                string ChiffresString = Convert.ToString(item);
                LesChiffresS.Add(ChiffresString);
            }

            //Demander d'estimer le nombre de coup

            Console.WriteLine("Dans combien de coups pensez-vous reussir à deviner les chiffres?");
            int max = int.Parse(Console.ReadLine());

            //Proposer les sequences
            bool Win = false;

            for (int cpt = 0; cpt < max && !Win; cpt++)
            {

                Console.WriteLine("\n" + "Veuillez proposer une sequence: ");
                string s = Console.ReadLine();

                //Transformer le string in 4 strings

                List<string> ChiffresDev = new List<string>();
                char[] CD = s.ToCharArray();
                foreach (char Cdev in CD)
                {
                    string CDS = Convert.ToString(Cdev);
                    ChiffresDev.Add(CDS);
                }

                //Verifier les chiffres devinés

                List<string> ChiffresOk = new List<string>();
                List<string> ChiffresNotOk = new List<string>();

                //S'ils sont dans l'ordre correct
                for (int i = 0; i < 4; i++)
                {
                    if (LesChiffresS[i] != ChiffresDev[i])
                    {
                        ChiffresOk.Add(" _ ");
                    }
                    else
                    {
                        ChiffresOk.Add(ChiffresDev[i]);
                    }
                }

                //Print la premiere analyse des chiffres
                foreach (string CO in ChiffresOk)
                {
                    Console.Write(CO);
                }
                
                //S'ils sont dans la sequence
                foreach (string chif in ChiffresDev)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (chif == LesChiffresS[i])
                        {
                            if (!ChiffresNotOk.Contains(chif))
                            {
                                ChiffresNotOk.Add(chif);
                            }
                        }
                    }
                }

                //Print les chiffres se trouvant dans la sequence
                Console.WriteLine("\n" + "Chiffres se trouvant dans la sequence: ");
                foreach (string CNO in ChiffresNotOk)
                {
                    Console.Write(CNO);
                }
                
                NbCoups++;

                //Arreter le jeu si chiffres ok
                int nbUnderscore=0;
                foreach (string item in ChiffresOk)
	            {
		                if(item==" _ ")
                        {nbUnderscore++;}
	            }
                if(nbUnderscore>0) Win=false;
                else Win=true;
            }
                
            //Fin du Jeu
           

            if (Win) 
            {
                Console.WriteLine("\n" + "Bravo! Vous avez trouver la sequence in " + NbCoups + " essais");
            }
            else 
            {
                Console.WriteLine("\n" + "Perdu! Vous n'avez pas trouver la sequence in " + max + " essais");
                Console.Write("\n" + "La sequence etait: ");
                foreach (int chf in LesChiffres)
                {
                    Console.Write(chf);
                }
            }
            



                


            Console.ReadLine();
        }

        public static Random MonRandom = new Random();
        public static void GenereLesChiffres(List<int>LesChiffres)
        {
            //4 chiffres aléatoire 1-9
            for (int i = 0; i < 4; i++)
            {
                int chiffre = MonRandom.Next(0, 9);
                LesChiffres.Add(chiffre);
            }
        }

    }

}
