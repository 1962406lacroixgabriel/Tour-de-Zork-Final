using System;

namespace Tour_de_Zork_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Acteur Magicien = new Acteur ();
            Acteur Voleur = new Acteur ();
                 
            Voleur.AfficherEtat();
            Magicien.Attaquer(Voleur);
            Voleur.AfficherEtat();
            Console.WriteLine(Voleur.EstVivant());
            Console.ReadLine();

            Utilitaire chevre = new Utilitaire();
            chevre.GenererClasse();
            Console.ReadLine();

        }
    }
}
