using System;

namespace Infrastructure
{
    public abstract class UIElementRoutedEventParam
    {
        protected readonly Object _sender;
        protected readonly Object _commandParameter;

        public UIElementRoutedEventParam(Object sender, Object commandParameter)
        {
            _sender = sender;
            _commandParameter = commandParameter;
        }

        public Object CommandParameter => _commandParameter;
        public Object Sender => _sender;
    }
}
