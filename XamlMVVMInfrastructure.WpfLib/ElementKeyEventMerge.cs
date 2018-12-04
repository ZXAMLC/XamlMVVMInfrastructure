using System;

using System.Windows;
using System.Windows.Input;

namespace XamlMVVMInfrastructure.WpfLib.Commands
{
    public class ElementKeyEventMerge : ElementEventMerge
    {
        private readonly KeyEventArgs _e;

        public ElementKeyEventMerge(FrameworkElement sender, KeyEventArgs e, Object commandPara)
            : base(sender, commandPara)
        {
            _e = e;
        }

        public KeyEventArgs E => _e;
    }
}