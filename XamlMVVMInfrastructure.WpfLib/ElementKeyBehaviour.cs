using System.Windows;
using System.Windows.Input;

namespace XamlMVVMInfrastructure.WpfLib.Commands
{
    public class ElementKeyBehavior
    {
        #region CommandParameter

        public static object GetCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
    DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(ElementKeyBehavior), new UIPropertyMetadata(CommandPrarmeterChanged));

        private static void CommandPrarmeterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as FrameworkElement;

            if (sender == null)
            {
                return;
            }
        }

        #endregion CommandParameter

        #region KeyDownCommand

        public static readonly DependencyProperty KeyDownCommandProperty =
            DependencyProperty.RegisterAttached("KeyDownCommand",
                typeof(ICommand), typeof(ElementKeyBehavior)
                , new FrameworkPropertyMetadata(KeyDownCommandChanged));

        private static void KeyDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            element.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(element_KeyDown));
            element.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(element_KeyDown_Unload));
        }

        private static void element_KeyDown_Unload(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            element.RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(element_KeyDown));
            element.RemoveHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(element_KeyDown_Unload));
        }

        private static void element_KeyDown(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement)sender;

            var command = GetKeyDownCommand(element);

            var ekem = new ElementKeyEventMerge(element, e, GetCommandParameter(element));

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
                typeof(ICommand), typeof(ElementKeyBehavior)
                , new FrameworkPropertyMetadata(PreviewKeyDownCommandChanged));

        private static void PreviewKeyDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            element.AddHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(element_PreviewKeyDown));
            element.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(element_PreviewKeyDown_Unload));
        }

        private static void element_PreviewKeyDown_Unload(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            element.RemoveHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(element_PreviewKeyDown));
            element.RemoveHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(element_PreviewKeyDown_Unload));
        }

        private static void element_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement)sender;

            var command = GetPreviewKeyDownCommand(element);

            var ekem = new ElementKeyEventMerge(element, e, GetCommandParameter(element));

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
        typeof(ICommand), typeof(ElementKeyBehavior)
        , new FrameworkPropertyMetadata(KeyUpCommandChanged));

        private static void KeyUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            element.AddHandler(UIElement.KeyUpEvent, new KeyEventHandler(element_KeyUp));
            element.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(element_KeyUp_Unload));
        }

        private static void element_KeyUp_Unload(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            element.RemoveHandler(UIElement.KeyUpEvent, new KeyEventHandler(element_KeyUp));
            element.RemoveHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(element_KeyUp_Unload));
        }

        private static void element_KeyUp(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement)sender;

            var command = GetKeyUpCommand(element);

            var ekem = new ElementKeyEventMerge(element, e, GetCommandParameter(element));

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
        typeof(ICommand), typeof(ElementKeyBehavior)
        , new FrameworkPropertyMetadata(PreviewKeyUpCommandChanged));

        private static void PreviewKeyUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;

            element.AddHandler(UIElement.PreviewKeyUpEvent, new KeyEventHandler(element_PreviewKeyUp));
            element.AddHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(element_PreviewKeyUp_Unload));
        }

        private static void element_PreviewKeyUp_Unload(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;

            element.RemoveHandler(UIElement.PreviewKeyUpEvent, new KeyEventHandler(element_PreviewKeyUp));
            element.RemoveHandler(FrameworkElement.UnloadedEvent, new RoutedEventHandler(element_PreviewKeyUp_Unload));
        }

        private static void element_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement)sender;

            var command = GetPreviewKeyUpCommand(element);

            var ekem = new ElementKeyEventMerge(element, e, GetCommandParameter(element));

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