using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorteio.Domain.Entities;

namespace Sorteio.Tests
{
    [TestClass]
    public class CartaoApostaTest
    {
        [TestMethod]
        public void Deve_Criar_UmCartaoDeAposta()
        {
            List<int> numeros = new List<int>() { 1, 2, 3, 4, 5, 6 };

            var cartaoAposta = new CartaoAposta(numeros, "Gabriel");

            Assert.AreEqual(0, cartaoAposta.Notifications.Count);
        }


        [TestMethod]
        public void Deve_Criar_Um_Cartao_De_Aposta_Surpresinha()
        {
            var cartaoAposta = new CartaoAposta(true, "Gabriel");

            Assert.AreEqual(0, cartaoAposta.Notifications.Count);
        }


        [TestMethod]
        public void Deve_Retornar_Notificar_Ao_Criar_Um_Cartao_Aposta_Sem_Numeros()
        {
            List<int> numeros = new List<int>() { };

            var cartaoAposta = new CartaoAposta(numeros, "Gabriel");

            Assert.AreEqual(1, cartaoAposta.Notifications.Count);
        }

        [TestMethod]
        public void Deve_Retornar_Notificacao_Criar_Um_Cartao_Aposta_Com_Numeros_Repedidos()
        {
            List<int> numeros = new List<int>() { 1, 2, 3, 4, 5, 6, 6, 1, 2 };

            var cartaoAposta = new CartaoAposta(numeros, "Gabriel");

            Assert.AreEqual(1, cartaoAposta.Notifications.Count);
        }

        [TestMethod]
        public void Deve_Retornar_Notificacao_Ao_Criar_Um_Cartao_Aposta_Com_Mais_6_Numeros()
        {
            List<int> numeros = new List<int>() {   1,
                                                    2,
                                                    3,
                                                    4,
                                                    5,
                                                    6,
                                                    7,
                                                };

            var cartaoAposta = new CartaoAposta(numeros, "Gabriel");

            Assert.AreEqual(1, cartaoAposta.Notifications.Count);
        }
    }
}
