using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using FluentValidator.Validation;

namespace Sorteio.Domain.Entities
{
    public class CartaoAposta : Notifiable
    {
        public Guid Id { get; private set; }
        public DateTime DataAposta { get; private set; }
        public string NomeApostador { get; private set; }
        public Dictionary<Guid, List<int>> NumerosApostados { get; private set; }
        public List<int> NumerosAcertados { get; private set; }
        public bool CartaoPremiado { get; private set; }


        public CartaoAposta(bool surpresinha, string nomeApostador)
        {
            if (surpresinha)
            {
                var numeros = new Dictionary<Guid, List<int>>();
                var numerosSuspresinha = new List<int>();
                numerosSuspresinha = GerarNumerosSurpresinha();
                numeros.Add(Guid.NewGuid(), numerosSuspresinha);

                this.NumerosApostados = numeros;
                this.NomeApostador = nomeApostador;
                this.DataAposta = DateTime.Now;
                this.Id = Guid.NewGuid();
            }
            else{
                AddNotifications(new ValidationContract()
                                      .HasMaxLen("", 0, "Surpresinha", "Falha ao gerar surpresinha"));
            }
        }

        public CartaoAposta(List<int> numerosApostados, string nomeApostador)
        {
            var numeros = new Dictionary<Guid, List<int>>();
            var copiaNumeros = new HashSet<int>();

            var duplicados = numerosApostados.GroupBy(x => x)
                        .Where(x => x.Count() > 1)
                        .Select(x => x.Key)
                        .ToList();

            if (duplicados.Count > 0)
            {
                AddNotifications(new ValidationContract()
                                      .HasMaxLen(duplicados.Count.ToString(), 0, "Números", "Números repetidos não são permitidos"));

            }
            else if (numerosApostados.Count == 0 || numerosApostados.Count > 60)
            {
                AddNotifications(new ValidationContract()
                      .HasMinLen(numerosApostados.Count.ToString(), 0, "Números", "Quantidade de números mínimo não permitido de 1 - 60.")
                      .HasMaxLen(numerosApostados.Count.ToString(), 0, "Números", "Quantidade de números máxima não permitido de 1-60."));
            }
            else
            {
                numeros.Add(Guid.NewGuid(), numerosApostados);
                this.NomeApostador = nomeApostador;
                this.Id = Guid.NewGuid();
                this.NumerosApostados = numeros;
                this.DataAposta = DateTime.Now;
            }
        }

        internal List<int> GerarNumerosSurpresinha()
        {
            int Min = 1;
            int Max = 60;

            var lista = new List<int>();
            Random randNum = new Random();
            for (int i = 0; i < 60; i++)
            {
                lista.Add(randNum.Next(Min, Max));
            }
            return lista;
        }
    }

}