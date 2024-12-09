using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Teszt
{
    [TestFixture]
    internal class JaratKezeloTeszt
    {
        Jarat j;

        [SetUp]
        public void Setup()
        {
            j = new Jarat();
            j.UjJarat("MA420", "LHBP", "KLAX", new DateTime(2026, 12, 03, 15, 30, 0));
        }

        [Test]
        public void UjJaratHelyesMentes()
        {
            Assert.That(j.jaratok.Count, Is.EqualTo(1));
            Assert.That(j.jaratKereso("MA420"), Is.Not.Null);

            var vizsgaltjarat = j.jaratKereso("MA420");
            Assert.That(vizsgaltjarat.JaratSzam, Is.EqualTo("MA420"));
            Assert.That(vizsgaltjarat.RepterHonnan, Is.EqualTo("LHBP"));
            Assert.That(vizsgaltjarat.RepterHova, Is.EqualTo("KLAX"));
            Assert.That(vizsgaltjarat.Indulas, Is.EqualTo(new DateTime(2026, 12, 03, 15, 30, 0)));
            Assert.That(vizsgaltjarat.PontosIndulas, Is.EqualTo(new DateTime(2026, 12, 03, 15, 30, 0)));
        }

        [Test]
        public void UjJaratHibasJaratSzam()
        {
            var hiba = Assert.Throws<ArgumentException>(() => j.UjJarat("", "LHBP", "KLAX", new DateTime(2026, 12, 03, 15, 30, 0)));
            Assert.That(hiba.Message, Is.EqualTo("Hibás járatszám!"));
            var hiba2 = Assert.Throws<ArgumentException>(() => j.UjJarat(null, "LHBP", "KLAX", new DateTime(2026, 12, 03, 15, 30, 0)));
            Assert.That(hiba2.Message, Is.EqualTo("Hibás járatszám!"));
        }

        [Test]
        public void UjJaratHibasKiindulas()
        {
            var hiba = Assert.Throws<ArgumentException>(() => j.UjJarat("MA420", "", "KLAX", new DateTime(2026, 12, 03, 15, 30, 0)));
            Assert.That(hiba.Message, Is.EqualTo("Hibás kiindulási reptér!"));
            var hiba2 = Assert.Throws<ArgumentException>(() => j.UjJarat("MA420", null, "KLAX", new DateTime(2026, 12, 03, 15, 30, 0)));
            Assert.That(hiba2.Message, Is.EqualTo("Hibás kiindulási reptér!"));
        }

        [Test]
        public void UjJaratHibasErkezes()
        {
            var hiba = Assert.Throws<ArgumentException>(() => j.UjJarat("MA420", "LHBP", "", new DateTime(2026, 12, 03, 15, 30, 0)));
            Assert.That(hiba.Message, Is.EqualTo("Hibás érkezési reptér!"));
            var hiba2 = Assert.Throws<ArgumentException>(() => j.UjJarat("MA420", "LHBP", null, new DateTime(2026, 12, 03, 15, 30, 0)));
            Assert.That(hiba2.Message, Is.EqualTo("Hibás érkezési reptér!"));
        }

        [Test]
        public void UjJaratKiindulasEgyezikAzErkezessel()
        {
            var hiba = Assert.Throws<ArgumentException>(() => j.UjJarat("MA420", "LHBP", "LHBP", new DateTime(2026, 12, 03, 15, 30, 0)));
            Assert.That(hiba.Message, Is.EqualTo("Hibás érkezési reptér!"));
        }

        [Test]
        public void UjJaratHibasDatum()
        {
            var hiba = Assert.Throws<ArgumentException>(() => j.UjJarat("MA420", "LHBP", "KLAX", DateTime.Now.AddDays(-1)));
            Assert.That(hiba.Message, Is.EqualTo("Hibás dátum!"));
        }

        [Test]
        public void KesesPozitiv()
        {
            var eredetiido = j.jaratKereso("MA420").Indulas;
            j.Keses("MA420", 10);
            Assert.That(j.jaratKereso("MA420").PontosIndulas, Is.EqualTo(eredetiido.AddMinutes(10)));
        }

        [Test]
        public void KesesNegativ()
        {
            var eredetiido = j.jaratKereso("MA420").Indulas;
            j.Keses("MA420", 30);
            j.Keses("MA420", -10);
            Assert.That(j.jaratKereso("MA420").PontosIndulas, Is.EqualTo(eredetiido.AddMinutes(20)));
        }

        [Test]
        public void KesesNegativKeses()
        {
            j.Keses("MA420", 10);
            var hiba = Assert.Throws<NegativKesesException>(() => j.Keses("MA420", -20));
            Assert.That(hiba.Message, Is.EqualTo("Negatív késés!"));
        }

        [Test]
        public void MikorIndul()
        {
            Assert.That(j.mikorIndul("MA420"), Is.EqualTo(new DateTime(2026, 12, 03, 15, 30, 0)));
        }

        [Test]
        public void MikorIndulNincsJarat()
        {
            var hiba = Assert.Throws<ArgumentException>(() => j.mikorIndul("MA421"));
            Assert.That(hiba.Message, Is.EqualTo("Nincs ilyen járat!"));
        }

        [Test]
        public void JaratKeresoMukodik()
        {
            Assert.That(j.jaratKereso("MA420"), Is.Not.Null);
        }

        [Test]
        public void JaratKeresoNemLetezoJarat()
        {
            var hiba = Assert.Throws<ArgumentException>(() => j.jaratKereso("MA421"));
            Assert.That(hiba.Message, Is.EqualTo("Nincs ilyen járat!"));
        }

        [Test]
        public void JaratokRepuloterrol()
        {
            j.UjJarat("MA421", "LHBP", "KLAX", new DateTime(2026, 12, 03, 15, 30, 0));
            j.UjJarat("MA422", "LHBP", "KLAX", new DateTime(2026, 12, 03, 15, 30, 0));
            j.UjJarat("MA423", "LHBP", "KLAX", new DateTime(2026, 12, 03, 15, 30, 0));
            j.UjJarat("MA424", "LHBP", "KLAX", new DateTime(2026, 12, 03, 15, 30, 0));
            Assert.That(j.jaratokRepuloterrol("LHBP").Count, Is.EqualTo(5));
        }

        [Test]
        public void JaratokRepuloterrolNincsJarat()
        {
            Assert.That(j.jaratokRepuloterrol("LGSK").Count, Is.EqualTo(0));
        }
    }
}
