using Atacado.Business.Ancestral;

namespace Atacado.Business.RH
{
    public class TesteRegra : IRule
    {
        private List<string> ruleMessages;

        public List<string> RuleMessages => this.ruleMessages;

        public TesteRegra()
        {
            this.ruleMessages = new List<string>();
        }

        public bool Process()
        {
            throw new NotImplementedException();
        }

        private bool Regra1()
        {
            return false;
        }

        private bool Regra2()
        {
            return false;
        }

        private bool Regra3()
        {
            return false;
        }

        private bool Regra4()
        {
            return false;
        }

        private bool Regra5()
        {
            return false;
        }
    }
}
