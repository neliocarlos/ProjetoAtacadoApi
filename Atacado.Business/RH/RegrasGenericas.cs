namespace Atacado.Business.RH
{
    /// <summary>
    /// Regras genéricas para uso em qualquer unidade de regra.
    /// </summary>
    public static class RegrasGenericas
    {
        /// <summary>
        /// Validar se campo NOME está vazio.
        /// </summary>
        /// <param name="nome">Campo a ser verificado.</param>
        /// <param name="mensagem">Mensagem passada em caso de erro.</param>
        /// <returns>Retorna true se bem sucedido, caso contrário, false.</returns>
        public static bool NomeRegra(string nome, ref string mensagem)
        {
            if (string.IsNullOrEmpty(nome) == true)
            {
                mensagem = "Nome não pode ser vazio!";
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Validar se campo SOBRENOME está vazio.
        /// </summary>
        /// <param name="sobrenome">Campo a ser verificado.</param>
        /// <param name="mensagem">Mensagem passada em caso de erro.</param>
        /// <returns>Retorna true se bem sucedido, caso contrário, false.</returns>
        public static bool SobrenomeRegra(string sobrenome, ref string mensagem)
        {
            if (string.IsNullOrEmpty(sobrenome) == true)
            {
                mensagem = "Sobrenome não pode ser vazio!";
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Validar se campo SEXO está vazio ou contém um caractere aceitável.
        /// </summary>
        /// <param name="sexo">Campo a ser verificado.</param>
        /// <param name="mensagem">Mensagem passada em caso de erro.</param>
        /// <returns>Retorna true se bem sucedido, caso contrário, false.</returns>
        public static bool SexoRegra(string sexo, ref string mensagem)
        {
            if (string.IsNullOrEmpty(sexo) == true)
            {
                mensagem = "Sexo não pode ser vazio!";
                return false;
            }
            else if ((sexo.Contains("F") == false) && ((sexo.Contains("M") == false)))
            {
                mensagem = "Sexo deve conter a letra F ou M.";
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Validar se campo EMAIL está vazio ou se está no formato correto.
        /// </summary>
        /// <param name="email">Campo a ser verificado.</param>
        /// <param name="mensagem">Mensagem passada em caso de erro.</param>
        /// <returns>Retorna true se bem sucedido, caso contrário, false.</returns>
        public static bool EmailRegra(string email, ref string mensagem)
        {
            bool validEmail = false;
            int indexArr = email.IndexOf("@");

            if (string.IsNullOrEmpty(email) == true)
            {
                mensagem = "Email não pode ser vazio!";
            }
            else if (indexArr > 0)
            {
                int indexDot = email.IndexOf(".", indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            else
            {
                mensagem = "Formato do email inválido.";
            }
            return validEmail;
        }
    }
}
