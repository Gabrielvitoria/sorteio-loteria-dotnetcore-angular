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
        public void Deve_Retornar_Notificacao_Ao_Criar_Um_Cartao_Aposta_Com_Mais_60_Numeros()
        {
            List<int> numeros = new List<int>() {   1,
                                                    2,
                                                    3,
                                                    4,
                                                    5,
                                                    6,
                                                    7,
                                                    8,
                                                    9,
                                                    10,
                                                    11,
                                                    12,
                                                    13,
                                                    14,
                                                    15,
                                                    16,
                                                    17,
                                                    18,
                                                    19,
                                                    20,
                                                    21,
                                                    22,
                                                    23,
                                                    24,
                                                    25,
                                                    26,
                                                    27,
                                                    28,
                                                    29,
                                                    30,
                                                    31,
                                                    32,
                                                    33,
                                                    34,
                                                    35,
                                                    36,
                                                    37,
                                                    38,
                                                    39,
                                                    40,
                                                    41,
                                                    42,
                                                    43,
                                                    44,
                                                    45,
                                                    46,
                                                    47,
                                                    48,
                                                    49,
                                                    50,
                                                    51,
                                                    52,
                                                    53,
                                                    54,
                                                    55,
                                                    56,
                                                    57,
                                                    58,
                                                    59,
                                                    60,
                                                    61};

            var cartaoAposta = new CartaoAposta(numeros, "Gabriel");

            Assert.AreEqual(1, cartaoAposta.Notifications.Count);
        }
    }
}
