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
        public List<int> NumerosApostados { get; private set; }
        public List<int> NumerosAcertados { get; private set; }
        public bool CartaoPremiado { get; private set; }


        public CartaoAposta(bool surpresinha, string nomeApostador)
        {
            if (surpresinha)
            {
                this.Id = Guid.NewGuid();
                this.DataAposta = DateTime.Now;
                this.NomeApostador = nomeApostador;
                this.NumerosApostados = GerarNumerosSurpresinha();
            }
            else{
                AddNotifications(new ValidationContract()
                                      .HasMaxLen("", 0, "Surpresinha", "Falha ao gerar surpresinha"));
            }
        }

        public CartaoAposta(List<int> numerosApostados, string nomeApostador)
        {
            var duplicados = numerosApostados.GroupBy(x => x)
                        .Where(x => x.Count() > 1)
                        .Select(x => x.Key)
                        .ToList();

            if (duplicados.Count > 0)
            {
                AddNotifications(new ValidationContract()
                                      .HasMaxLen(duplicados.Count.ToString(), 0, "Números", "Números repetidos não são permitidos"));

            }
            else if (numerosApostados.Count == 0 || numerosApostados.Count > 6)
            {
                AddNotifications(new ValidationContract()
                      .HasMinLen(numerosApostados.Count.ToString(), 0, "Números", "Quantidade de números mínimo não permitido de 1 - 6.")
                      .HasMaxLen(numerosApostados.Count.ToString(), 0, "Números", "Quantidade de números máxima não permitido de 1 - 6."));
            }
            else
            {
                this.Id = Guid.NewGuid();
                this.DataAposta = DateTime.Now;
                this.NomeApostador = nomeApostador;
                this.NumerosApostados = numerosApostados;
            }
        }

        internal List<int> GerarNumerosSurpresinha()
        {
            int Min = 1;
            int Max = 60;

            var lista = new List<int>();
            Random randNum = new Random();
            for (int i = 0; i < 6; i++)
            {
                lista.Add(randNum.Next(Min, Max));
            }
            return lista;
        }
    }

}