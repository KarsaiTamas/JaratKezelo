using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JaratKezelo
{
    [TestFixture]
    class RepuloTeszt
    {
        JaratKezelo j;
        [SetUp]
        public void Setup()
        {
            j = new JaratKezelo();
        }
        [Test]
        public void UjJaratTestLetrehoz()
        {
             
            j.UjJarat("sajt","a","b",DateTime.Now);
            Assert.IsNotEmpty(j.jaratok);
        }
        [Test]
        public void UjJaratDuplikaltJarat()
        {
             
            j.UjJarat("sajt", "a", "b", DateTime.Now);
            Assert.Throws<ArgumentException>(
                () =>
                { 
                     j.UjJarat("sajt", "a", "b", DateTime.Now);
                }
                );
           
             
        }
        [Test]
        public void UjJaratTestTobbJaratFelveteleHibanelkul()
        {
             
            j.UjJarat("sajt", "a", "b", DateTime.Now);
            j.UjJarat("pajt", "a", "b", DateTime.Now);
            j.UjJarat("kajt", "a", "b", DateTime.Now);
            j.UjJarat("dajt", "a", "b", DateTime.Now);
            Assert.AreEqual(4, j.jaratok.Count);
        }
        [Test]
        public void KesesTestHozzaadas()
        {
            j.UjJarat("test1", "a", "b", DateTime.Now);
            j.Keses("test1",new TimeSpan(0,5,0));
            Assert.AreEqual(new TimeSpan(0,5,0),j.GetJarat("test1").Keses);
        }
        [Test]
        public void KesesTestTobbHozzaadas()
        {
            j.UjJarat("test1", "a", "b", DateTime.Now);
            j.Keses("test1", new TimeSpan(0, 5, 0));
            j.Keses("test1", new TimeSpan(0, 5, 0));
            j.Keses("test1", new TimeSpan(0, 5, 0));
            Assert.AreEqual(new TimeSpan(0, 15, 0), j.GetJarat("test1").Keses);
        }
        [Test]
        public void KesesTestHozzaadasMinusz()
        {
            j.UjJarat("test1", "a", "b", DateTime.Now);
            j.Keses("test1", new TimeSpan(0, 5, 0));
             
            Assert.Throws<NegativKesesException>(
                () =>
                {
                    j.Keses("test1", new TimeSpan(0, -10, 0));
                }
                );
        }
        [Test]
        public void MikorIndulTest()
        {
            j.UjJarat("test1","a","b",DateTime.Now);
            Assert.AreEqual(j.MikorIndul("test1"),j.GetJarat("test1").Indulas+ j.GetJarat("test1").Keses);
        }
        [Test]
        public void MikorIndulTestNemLetezoJarat()
        {
            j.UjJarat("test1", "a", "b", DateTime.Now);
            Assert.Throws<ArgumentException>(
                 () =>
                 {
                     j.MikorIndul("asd");
                 }
                 );
        }
        [Test]
        public void MikorIndulTestKesessel()
        {

            j.UjJarat("test1", "a", "b", DateTime.Now);
            j.Keses("test1",new TimeSpan(0,2,0));
            Assert.AreEqual(j.MikorIndul("test1"), j.GetJarat("test1").Indulas + j.GetJarat("test1").Keses);

        }
        [Test]
        public void JaratokRepuloTerrolEgyRepulo()
        {
            j.UjJarat("test1", "a", "b", DateTime.Now);
            List<string> repulok = new List<string>();
            repulok.Add("test1");
            Assert.AreEqual(j.JaratokRepuloterrol("a"),repulok);
        }
        [Test]
        public void JaratokRepuloTerrolTobbRepulo()
        {
            j.UjJarat("test1", "a", "b", DateTime.Now);
            j.UjJarat("test2", "a", "b", DateTime.Now);
            List<string> repulok = new List<string>();
            repulok.Add("test1");
            repulok.Add("test2");
            Assert.AreEqual(j.JaratokRepuloterrol("a"), repulok);
        }
        [Test]
        public void JaratokRepuloTerrolTobbRepuloMasAllomas()
        {
            j.UjJarat("test1", "a", "b", DateTime.Now);
            j.UjJarat("test2", "b", "a", DateTime.Now);
            List<string> repulok = new List<string>();
            repulok.Add("test1");
           
            Assert.AreEqual(j.JaratokRepuloterrol("a"), repulok);
        }
        [Test]
        public void JaratokRepuloTerrolNincsRepuloTer()
        {
            j.UjJarat("test1", "a", "b", DateTime.Now);
            List<string> repulok = new List<string>();
            repulok.Add("test1");
            
            Assert.Throws<ArgumentException>(
                 () =>
                 {
                     Assert.AreEqual(j.JaratokRepuloterrol("asd"), repulok);
                 }
                 );
        }
    }
}
