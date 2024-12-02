using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class Itiner
    {
        public string JaratSzam { get; set; }

        public string RepterHonnan { get; set; }

        public string RepterHova { get; set; }

        public DateTime Indulas { get; set; }

        public DateTime PontosIndulas { get; set; }


        public Itiner(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas, DateTime pontosIndulas)
        {
            JaratSzam = jaratSzam;
            RepterHonnan = repterHonnan;
            RepterHova = repterHova;
            Indulas = indulas;
            PontosIndulas = pontosIndulas;
        }

        public override string ToString()
        {
            return $"{JaratSzam}: {RepterHonnan} - {RepterHova} - ({Indulas}) - ({PontosIndulas})";
        }
    }
}
