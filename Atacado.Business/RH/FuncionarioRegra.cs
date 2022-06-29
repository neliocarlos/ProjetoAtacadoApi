﻿using Atacado.Business.Ancestral;
using Atacado.Poco.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Business.RH
{
    public class FuncionarioRegra : IRule
    {
        private List<string> ruleMessages;
        public List<string> RuleMessages => this.ruleMessages;

        private FuncionarioPoco poco;

        public FuncionarioRegra(FuncionarioPoco poco)
        {
            this.ruleMessages = new List<string>();
            this.poco = poco;
        }

        public bool Process()
        {
            bool resultado = true;

            if (this.NomeRegra() == false)
            {
                resultado = false;
            }
            //...
            //...
            //...
            //aqui vão outras regras.

            return resultado;
        }

        private bool NomeRegra()
        {
            if (string.IsNullOrEmpty(this.poco.Nome) == true)
            {
                this.ruleMessages.Add("Nome não pode ser vazio!");
                return false;
            }
            else
                return true;
        }
    }
}