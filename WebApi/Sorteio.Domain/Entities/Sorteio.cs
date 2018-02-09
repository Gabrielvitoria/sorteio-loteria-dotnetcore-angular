using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using FluentValidator.Validation;

namespace Sorteio.Domain.Entities
{
    public class Sorteio : Notifiable
    {
        public Sorteio()
        {
            this.NumeroSorteio = Guid.NewGuid();
            this.DataSorteio = DateTime.Now;
            this.NumerosSorteados = GerarNumerosSorteio();

                if(this.NumerosSorteados.Count == 0)
                        AddNotifications(  new ValidationContract()
                                        .HasMaxLen(this.NumerosSorteados.Count.ToString(), 0, "Sorteio", "Sorteio não gerou números."));
        }

        public Guid NumeroSorteio { get; set; }
        public DateTime DataSorteio { get; private set; }
        public List<int> NumerosSorteados { get; private set; }
        public List<CartaoAposta> CartoesPremiados { get; private set; }



        internal List<int> GerarNumerosSorteio()
        {
            int Min = 1;
            int Max = 60;

            var lista = new List<int>();
            Random randNum = new Random();
            for (int i = 0; i < 6 ; i++)
            {
                lista.Add(randNum.Next(Min, Max) );
            }
            return lista;
        }
    }



}