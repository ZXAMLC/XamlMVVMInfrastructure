using System;

using System.Windows;

namespace XamlMVVMInfrastructure.WpfLib.Commands
{
    public abstract class ElementEventMerge
    {
        protected readonly FrameworkElement _sender;
        protected readonly Object _commandParameter;

        public ElementEventMerge(FrameworkElement sender, Object commandParameter)
        {
            _sender = sender;
            _commandParameter = commandParameter;
        }

        public Object CommandParameter => _commandParameter;
        public FrameworkElement Sender => _sender;
    }
}
