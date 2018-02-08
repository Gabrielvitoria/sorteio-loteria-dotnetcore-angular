using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorteio.Domain.Entities;

namespace Sorteio.Tests
{
    [TestClass]
    public class SorteioTest
    {
        [TestMethod]
        public void Deve_Criar_Um_Sorteio_60_Numeros()
        {
            var sorteio = new Sorteio.Domain.Entities.Sorteio();

            Assert.AreEqual(0, sorteio.Notifications.Count);
        }

        
    }
}
