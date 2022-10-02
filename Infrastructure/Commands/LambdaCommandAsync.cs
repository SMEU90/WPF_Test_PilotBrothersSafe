using System;
using WPF_Test_PilotBrothersSafe.Infrastructure.Commands.Base;

namespace WPF_Test_PilotBrothersSafe.Infrastructure.Commands
{
    internal class LambdaCommandAsync : Command
    {
        private readonly ActionAsync<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommandAsync(ActionAsync Execute, Func<bool> CanExecute = null)
            : this(async p => await Execute(), CanExecute is null ? (Func<object, bool>)null : p => CanExecute())
        {

        }

        public LambdaCommandAsync(ActionAsync<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        protected override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;

        protected override void Execute(object p) => _Execute(p);
    }
}