using System.Collections.Generic;

namespace Sharpenter.IAM.Core
{
    public class Policy
    {
        private string _name;
        private string _description;
        private readonly IList<Statement> _statements;

        public Policy(string name, string description)
        {
            _name = name;
            _description = description;
            _statements = new List<Statement>();
        }

        public Policy WithStatement(Statement statement)
        {
            _statements.Add(statement);
            return this;
        }
    }
}