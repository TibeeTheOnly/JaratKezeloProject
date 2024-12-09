namespace ClassLibrary1
{
    public class Jarat
    {
        internal List<Itiner> jaratok = new List<Itiner>();

        internal void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratSzam != "" && repterHonnan != "" && repterHova != "" && repterHonnan != repterHova && jaratSzam != null && repterHonnan != null && repterHova != null && indulas > DateTime.Now)
            {
                DateTime pontosIndulas = indulas;
                this.jaratok.Add(new Itiner(jaratSzam, repterHonnan, repterHova, indulas, pontosIndulas));
            }
            else if(jaratSzam == "")
            {
                throw new ArgumentException("Hibás járatszám!");
            }
            else if(repterHonnan == "")
            {
                throw new ArgumentException("Hibás kiindulási reptér!");
            }
            else if(repterHova == "")
            {
                throw new ArgumentException("Hibás érkezési reptér!");
            }
            else if (jaratSzam == null)
            {
                throw new ArgumentException("Hibás járatszám!");
            }
            else if (repterHonnan == null)
            {
                throw new ArgumentException("Hibás kiindulási reptér!");
            }
            else if (repterHova == null)
            {
                throw new ArgumentException("Hibás érkezési reptér!");
            }
            else if(repterHonnan == repterHova)
            {
                throw new ArgumentException("Hibás érkezési reptér!");
            }
            else if(indulas < DateTime.Now)
            {
                throw new ArgumentException("Hibás dátum!");
            }
        }

        internal void Keses(string jaratszam, int keses)
        {
            var itiner = jaratok.Find(x => x.JaratSzam == jaratszam);
            if (itiner != null)
            {
                itiner.PontosIndulas = itiner.PontosIndulas.AddMinutes(keses);
            }
            if (itiner.PontosIndulas < itiner.Indulas)
            {
                throw new NegativKesesException("Negatív késés!");
            }
        }

        internal DateTime mikorIndul(string jaratszam)
        {
            var itiner = jaratok.Find(x => x.JaratSzam == jaratszam);
            if (itiner != null)
            {
                return itiner.PontosIndulas;
            }
            else
            {
                throw new ArgumentException("Nincs ilyen járat!");

            }
        }

        internal List<string> jaratokRepuloterrol(string repter)
        {
            List<string> jaratokRepterrol = new List<string>();
            foreach (var item in jaratok)
            {
                if (item.RepterHonnan == repter)
                {
                    jaratokRepterrol.Add(item.JaratSzam);
                }
            }
            return jaratokRepterrol;
        }

        internal Itiner jaratKereso(string jaratszam)
        {
            var itiner = jaratok.Find(x => x.JaratSzam == jaratszam);
            if (itiner == null)
            {
                throw new ArgumentException("Nincs ilyen járat!");
            }
            else
            {
                return itiner;
            }
        }
    }
    public class NegativKesesException : Exception
    {
        public NegativKesesException(string message) : base(message)
        {
        }
    }
}
