using System;
using System.Collections.Generic;

using MVVMInfrastructure;


using System.Windows;
using System.Windows.Input;

namespace XamlMVVMInfrastructure.WpfLib.Commands
{
    public class KeyAttachCommand
    {

        #region KeyDownCommand

        public static readonly DependencyProperty KeyDownCommandProperty =
            DependencyProperty.RegisterAttached("KeyDownCommand",
                typeof(ICommand), typeof(KeyAttachCommand)
                , new FrameworkPropertyMetadata(KeyDownCommandChanged));

        private static void KeyDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            element.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(Element_KeyDown));
            element.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(Element_KeyDown_Unload));
        }

        private static void Element_KeyDown_Unload(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            element.RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(Element_KeyDown));
            element.RemoveHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(Element_KeyDown_Unload));
        }

        private static void Element_KeyDown(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement)sender;

            var command = GetKeyDownCommand(element);

            var ekem = new KeyCommandParam(KeyMapping.Map(e.Key));

            command.Execute(ekem);
        }

        public static void SetKeyDownCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(KeyDownCommandProperty, value);
        }

        public static ICommand GetKeyDownCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(KeyDownCommandProperty);
        }

        #endregion KeyDownCommand

        #region PreviewKeyDownCommand

        public static readonly DependencyProperty PreviewKeyDownCommandProperty =
            DependencyProperty.RegisterAttached("PreviewKeyDownCommand",
                typeof(ICommand), typeof(KeyAttachCommand)
                , new FrameworkPropertyMetadata(PreviewKeyDownCommandChanged));

        private static void PreviewKeyDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            element.AddHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(Element_PreviewKeyDown));
            element.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(Element_PreviewKeyDown_Unload));
        }

        private static void Element_PreviewKeyDown_Unload(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            element.RemoveHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(Element_PreviewKeyDown));
            element.RemoveHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(Element_PreviewKeyDown_Unload));
        }

        private static void Element_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement)sender;

            var command = GetPreviewKeyDownCommand(element);

            var ekem = new KeyCommandParam(KeyMapping.Map(e.Key));

            command.Execute(ekem);
        }

        public static void SetPreviewKeyDownCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(PreviewKeyDownCommandProperty, value);
        }

        public static ICommand GetPreviewKeyDownCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(PreviewKeyDownCommandProperty);
        }

        #endregion PreviewKeyDownCommand

        #region KeyUpCommand

        public static readonly DependencyProperty KeyUpCommandProperty =
    DependencyProperty.RegisterAttached("KeyUpCommand",
        typeof(ICommand), typeof(KeyAttachCommand)
        , new FrameworkPropertyMetadata(KeyUpCommandChanged));

        private static void KeyUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            element.AddHandler(UIElement.KeyUpEvent, new KeyEventHandler(Element_KeyUp));
            element.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(Element_KeyUp_Unload));
        }

        private static void Element_KeyUp_Unload(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            element.RemoveHandler(UIElement.KeyUpEvent, new KeyEventHandler(Element_KeyUp));
            element.RemoveHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(Element_KeyUp_Unload));
        }

        private static void Element_KeyUp(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement)sender;

            var command = GetKeyUpCommand(element);

            var ekem = new KeyCommandParam(KeyMapping.Map(e.Key));

            command.Execute(ekem);
        }

        public static void SetKeyUpCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(KeyUpCommandProperty, value);
        }

        public static ICommand GetKeyUpCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(KeyUpCommandProperty);
        }

        #endregion KeyUpCommand

        #region PreviewKeyUpCommand

        public static readonly DependencyProperty PreviewKeyUpCommandProperty =
    DependencyProperty.RegisterAttached("PreviewKeyUpCommand",
        typeof(ICommand), typeof(KeyAttachCommand)
        , new FrameworkPropertyMetadata(PreviewKeyUpCommandChanged));

        private static void PreviewKeyUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            element.AddHandler(UIElement.PreviewKeyUpEvent, new KeyEventHandler(Element_PreviewKeyUp));
            element.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(Element_PreviewKeyUp_Unload));
        }

        private static void Element_PreviewKeyUp_Unload(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            element.RemoveHandler(UIElement.PreviewKeyUpEvent, new KeyEventHandler(Element_PreviewKeyUp));
            element.RemoveHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(Element_PreviewKeyUp_Unload));
        }

        private static void Element_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement)sender;

            var command = GetPreviewKeyUpCommand(element);

            var ekem = new KeyCommandParam(KeyMapping.Map(e.Key));

            command.Execute(ekem);
        }

        public static void SetPreviewKeyUpCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(PreviewKeyUpCommandProperty, value);
        }

        public static ICommand GetPreviewKeyUpCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(PreviewKeyUpCommandProperty);
        }

        #endregion PreviewKeyUpCommand
    }
}
