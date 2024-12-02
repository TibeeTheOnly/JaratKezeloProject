namespace ClassLibrary1
{
    public class Jarat
    {
        List<Itiner> jaratok = new List<Itiner>();

        internal void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratSzam != null && repterHonnan != null && repterHova != null && repterHonnan != repterHova)
            {
                DateTime pontosIndulas = indulas;
                jaratok.Add(new Itiner(jaratSzam, repterHonnan, repterHova, indulas, pontosIndulas));
            }
        }

        internal void Keses(string jaratszam, int keses)
        {
            var itiner = jaratok.Find(x => x.JaratSzam == jaratszam);
            if (itiner != null)
            {
                if (keses > 0)
                {
                    itiner.PontosIndulas = itiner.Indulas.AddMinutes(keses);
                }
                else if (keses < 0)
                {
                    itiner.PontosIndulas = itiner.Indulas.AddMinutes(keses);
                }
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
    }
    public class NegativKesesException : Exception
    {
        public NegativKesesException(string message) : base(message)
        {
        }
    }
}
