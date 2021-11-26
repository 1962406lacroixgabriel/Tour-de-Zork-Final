using System;

namespace Tour_de_Zork_Final
{
    class Acteur
    {
        public string Nom { get; set;}
        public string Description { get; set;}
        public int MaxHp { get; set;}
        public int Hp { get; set;}
        public int MaxArmure { get; set;}
        public int Armure { get; set;}
        public int RegenArmure { get; set;}
        public int Agilite { get; set;}
        public int Dommage { get; set;}
        public int TauxCritique { get; set;}

        public Acteur(string nom, string description, int maxHp, int maxArmure, int regenArmure, int agilite, int dommage)
        {
            this.Nom = nom;
            this.Description = description;
            this.MaxHp = maxHp;
            this.MaxArmure = maxArmure;
            this.RegenArmure = regenArmure;
            this.Agilite = agilite;
            this.Dommage = dommage;
            Hp = maxHp;
            Armure = maxArmure;
            TauxCritique = 100 - agilite / 2;
        }

        public void Attaquer(Acteur autreActeur)
        {
            Random rng = new Random();
            int aleatoire = rng.Next (0,101);
            int degats = 0;
            
            if(aleatoire >= this.TauxCritique)
            {
                degats += (this.Dommage * 3 / 2);
                Console.WriteLine($"(COUP CRITIQUE) Dégats: {degats}");
            }
            else if (aleatoire <= autreActeur.Agilite)
            {
                degats = 0; 
                Console.WriteLine($"(COUP MANQUÉ) Dégats: {degats}");
            }
            else
            {
                degats = this.Dommage;
                Console.WriteLine($"(COUP NORMAL) Dégats: {degats}");             
            }

            autreActeur.Defendre(degats);

        }
        public void Defendre(int degats)
        {
            Armure -= degats;

            if(Armure <= 0)
            {
                Hp += Armure;
                Armure = 0;
            }

            if (Armure + RegenArmure > MaxArmure)
            {
                Armure = MaxArmure;
            }
            else
            {
                Armure += RegenArmure;
            }

            if(Hp < 0)
            {
                Hp = 0;
            }

        }
        public bool EstVivant()
        {
            if (Hp <= 0)
            {
                Console.WriteLine($"Le {Nom} est mort.");
                return false;
            }
            return true;
            
        }
        public void AfficherEtat()
        {
            Console.WriteLine($"Le {Nom} a {Armure} d'armure ainsi que {Hp} de vie.");
        }

    }
}