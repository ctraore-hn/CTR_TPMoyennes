using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace TPMoyennes
{
    public class Classe
    {
        public string[] matieres { get; private set; }
        public List<Eleve> eleves = new List<Eleve>();
        public static int iMatieres { get; private set; }
        public string nomClasse;
        public float somme = 0;
        public float count = 0;

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
             matieres = new string[10];
             iMatieres = 0;
        }
   
        internal void ajouterEleve(string nom, string prenom)
        {
            Eleve eleve = new(nom, prenom);
            eleves.Add(eleve);

        }
        internal void ajouterMatiere(string nomMatiere)
        {
            matieres[iMatieres] = nomMatiere;
            iMatieres++;
            
        }
        float moyenneClasse;
        internal float Moyenne()
        {
            somme = 0;
            count = 0;
            foreach(Eleve eleve in eleves)
            {
                somme += eleve.Moyenne();
                count++;
            }
            moyenneClasse = somme / count;
            return moyenneClasse = (float)System.Math.Round(moyenneClasse, 2);
        }
        float moyenneClasseMatiere;
        internal float Moyenne(int x)
        {
            somme = 0;
            count = 0;
            foreach (Eleve eleve in eleves)
            {
                somme += eleve.Moyenne(x);
                count++;
                moyenneClasseMatiere = somme / count;
            }
            return moyenneClasseMatiere = (float)System.Math.Round(moyenneClasseMatiere, 2);
        }

        public class Eleve
        {
            public string nom;
            public string prenom;
            
            public Eleve(string nom, string prenom)
            {
                this.nom = nom;
                this.prenom = prenom;               
            }
            List<Note> notes = new List<Note>();
            public float somme = 0;
            public float count = 0;

            internal void ajouterNote(Note note)
            {
                notes.Add(note);               
            }
            
            public float Moyenne()
            {
                float somme = 0;
                float count = 0;
                float moyenneEleve = 0;
                for (int i = 0; i < iMatieres; i++)
                {
                    somme += Moyenne(i);
                    count++;
                    moyenneEleve = somme / count;   
                }   
                return (float)System.Math.Round(moyenneEleve, 2);
            }

            public float Moyenne(int x)
            {
                float somme = 0;
                float count = 0;
                float moyenneMatiere = 0;

                foreach (Note note in notes)
                {    
                    if ( x == note.matiere )
                    {
                        somme += note.note;
                        count++;   
                        moyenneMatiere = somme / count;
                        moyenneMatiere = (float)System.Math.Round(moyenneMatiere, 2);
                    }                                       
                }
                return moyenneMatiere;
            }
        }
    }
}

    
