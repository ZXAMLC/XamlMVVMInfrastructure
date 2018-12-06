using System;
using System.Threading.Tasks;

using System.Windows.Input;

namespace MVVMInfrastructure
{
    public abstract class NVCommandBase
    {
        protected readonly Func<bool> _canExecute;

        public NVCommandBase(Func<bool> canExecute)
        {
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }


        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }


    public class NVCommand : NVCommandBase, ICommand
    {
        private readonly Action _execute;

        public NVCommand(Action execute, Func<bool> canExecute = null)
            : base(canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

    }

    public class NVAsyncCommand : NVCommandBase, ICommand
    {
        private readonly Func<Task> _execute;

        public NVAsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
            : base(canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
        }

        public async void Execute(object parameter)
        {
            await _execute();
        }

    }

    public abstract class NVCommandBase<T>
    {
        protected readonly Func<T, bool> _canExecute;

        public NVCommandBase(Func<T, bool> canExecute)
        {
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }


        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }

    public class NVDelegateCommand<T> : NVCommandBase<T>, ICommand
    {
        private readonly Action<T> _execute;



        public NVDelegateCommand(Action<T> execute, Func<T, bool> canExecute = null)
            : base(canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

    }


    public class NVAsyncDelegateCommand<T> : NVCommandBase<T>, ICommand
    {
        #region Fields

        protected readonly Func<T, Task> _execute;

        #endregion

        #region Constructors

        public NVAsyncDelegateCommand(Func<T, Task> execute, Func<T, bool> canExecute = null)
            : base(canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
        }

        #endregion


        #region ICommand Members

        public async void Execute(object parameter)
        {

            await _execute((T)parameter);

        }

        #endregion
    }



}