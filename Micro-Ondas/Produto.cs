using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace Micro_Ondas
{
    class Produto
    {
        public string ID;
        public string Alimento;
        public string Descricao;
        public int Tempo;
        public int Power;
        public char CharHeating;

        public Produto()
        {
        }

        public Produto(string id, string alimento, string descricao, int power, int tempo, char caractere)
        {
            ID = id;
            Alimento = alimento;
            Descricao = descricao;
            Tempo = tempo;
            Power = power;
            CharHeating = caractere;
        }

        public static ObservableCollection<Produto> StartProgram()
        {
            ObservableCollection<Produto> programs = new ObservableCollection<Produto>();
            var program = new Produto("1","Frango", "Descogelamento de Frango", 10, 120, '+');
            programs.Add(program);

            program = new Produto("2","Pipoca", "Preparar Pipoca", 5, 45, '*');
            programs.Add(program);

            program = new Produto("3","Arroz", "Fazer arroz ", 3, 90, '&');
            programs.Add(program);

            program = new Produto("4","Pizza", "Pizzas Média/Grande", 7, 90, '$');
            programs.Add(program);

            program = new Produto("5","Macarrão", "Fazer Macarrão", 7, 90, '=');
            programs.Add(program);

            return programs;
        }
               
        public override string ToString()
        {
            return Alimento
            + ", "
            + Descricao
            + ", "
            + Tempo
            + ", "
            + Power;
        }

    }
}
