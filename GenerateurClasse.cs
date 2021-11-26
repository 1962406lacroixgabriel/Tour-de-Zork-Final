using System;
using System.IO;

namespace Tour_de_Zork_Final
{
    class Utilitaire
    {
        public string[] Questions { get; set; }
        public Acteur[] Classes { get; set; }
        public int Magicien { get; set; }
        public int Voleur { get; set; }
        public int Guerrier { get; set; }

        public Utilitaire()
        {
            Questions = new string[4];
            Classes = new Acteur[3];

            StreamReader lecteur = new StreamReader("questions.txt");

            Questions[0] = lecteur.ReadLine();
            Questions[1] = lecteur.ReadLine();
            Questions[2] = lecteur.ReadLine();
            Questions[3] = lecteur.ReadLine();
            lecteur.Close();

            lecteur = new StreamReader("classes.txt");
            string separateur = lecteur.ReadLine();
            DecoderClasse(separateur.Split(','));
            lecteur.Close();

        }
        private Acteur DecoderClasse(string[] Specs)
            {
                Acteur acteur = new Acteur(Specs [0], Specs [6], Convert.ToInt32(Specs[1]), Convert.ToInt32(Specs[2]), Convert.ToInt32(Specs[3]), Convert.ToInt32(Specs[4]), Convert.ToInt32(Specs[5]) );
                return acteur;
            }
        public Acteur GenererClasse()
        {
            int reponse = 0;
             for (int i = 0; i < 3; i++)
             {
                 switch(PoserQuestion(Questions[i])) 
                {
                case 1:
                    Guerrier ++;
                    break;
                case 2:
                    Magicien ++;
                    break;
                case 3:
                    Voleur ++;
                    break;
                }
             }

             if ((Guerrier > Magicien) && (Guerrier > Voleur))
            { 
                reponse = 2;
            }
            else if ((Magicien > Guerrier) && (Magicien > Voleur))
            { 
                reponse = 0;
            }
            else if ((Voleur > Guerrier) && (Voleur > Magicien))
            { 
                reponse = 1;
            }

            else
            {

            switch(PoserQuestion(Questions[3])) 
                {
                case 1:
                    reponse = 2;
                    break;
                case 2:
                    reponse = 0;
                    break;
                case 3:
                    reponse =1;
                    break;
                }

            }

            Classes[reponse].AfficherEtat();
                
            return Classes[reponse];

        }


        public int PoserQuestion(string questions)
        {
            int reponse = 0;

            bool validation = false;

            Console.WriteLine(questions);

            int.TryParse(Console.ReadLine(), out reponse);

            while (validation == false)
            {
                 if (reponse == 1)
                 {
                     validation = true;
                 }
                 else if (reponse == 2)
                 {
                     validation = true;
                 }
                 else if (reponse == 3)
                 {
                     validation = true;
                 }
                 else
                 {
                    Console.WriteLine("ERREUR, veuillez entrer une valeur entre 1 et 3.");
                 }
            }
            
            return reponse;

        }

    }
}