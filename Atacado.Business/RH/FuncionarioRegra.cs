﻿using Atacado.Business.Ancestral;
using Atacado.Poco.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Business.RH
{
    /// <summary>
    /// 
    /// </summary>
    public class FuncionarioRegra : RuleAncestor<FuncionarioPoco>, IRule
    {
        public FuncionarioRegra()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        public FuncionarioRegra(FuncionarioPoco poco) : base(poco)
        { }

        public override bool Process()
        {
            bool resultado = true;

            string mensagemProcess = string.Empty;

            if (RegrasGenericas.NomeRegra(this.poco.Nome, ref mensagemProcess) == false)
            {
                this.ruleMessages.Add(mensagemProcess);
                resultado = false;
            }

            if (RegrasGenericas.SobrenomeRegra(this.poco.Sobrenome, ref mensagemProcess) == false)
            {
                this.ruleMessages.Add(mensagemProcess);
                resultado = false;
            }

            if (RegrasGenericas.SexoRegra(this.poco.Sexo, ref mensagemProcess) == false)
            {
                this.ruleMessages.Add(mensagemProcess);
                resultado = false;
            }

            if (RegrasGenericas.EmailRegra(this.poco.Email, ref mensagemProcess) == false)
            {
                this.ruleMessages.Add(mensagemProcess);
                resultado = false;
            }

            return resultado;
        }
    }
}
