using System.Collections.Generic;

namespace Sharpenter.IAM.Core
{
    public class Statement
    {
        private readonly Effect _effect;
        private readonly IList<string> _actions;
        private readonly IList<string> _resources;

        public Statement(Effect effect, IList<string> actions, IList<string> resources)
        {
            _effect = effect;
            _actions = actions;
            _resources = resources;
        }
    }
}