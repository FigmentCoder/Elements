using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Elements.Common.Extensions;

namespace Elements.Common.Services
{
    public class AsyncCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged = null!;

        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly Action<Exception> _exceptionHandler;

        internal AsyncCommand(
            Func<Task> execute,
            Func<bool> canExecute = null!,
            Action<Exception> exceptionHandler = null!)
        {
            _execute = execute;
            _canExecute = canExecute;
            _exceptionHandler = exceptionHandler;
        }

        public bool CanExecute()
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            ExecuteAsync().FireAndForgetSafeAsync(_exceptionHandler);
        }
        #endregion
    }

    public class AsyncCommand<T> : IAsyncCommand<T> where T : class
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;
        private readonly Action<Exception> _exceptionHandler;

        internal AsyncCommand(
            Func<T, Task> execute,
            Func<T, bool> canExecute = null,
            Action<Exception> exceptionHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _exceptionHandler = exceptionHandler;
        }

        public bool CanExecute(T parameter)
        {
            return !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);
        }

        public async Task ExecuteAsync(T parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    _isExecuting = true;

                    if (parameter.IsNotNull())
                    {
                        await _execute(parameter);
                    }
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter as T);
        }

        void ICommand.Execute(object parameter)
        {
            ExecuteAsync(parameter as T).FireAndForgetSafeAsync(_exceptionHandler);
        }
        #endregion
    }

    internal static class AsyncCommandTask
    {
        public static async void FireAndForgetSafeAsync(
            this Task task,
            Action<Exception> handler = null!)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler.IsNotNull(() => handler?.Invoke(ex));
            }
        }
    }

    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }

    public interface IAsyncCommand<in T> : ICommand
    {
        Task ExecuteAsync(T parameter);
        bool CanExecute(T parameter);
    }

    public static class AsyncCommandConstructors
    {
        public static AsyncCommand AsyncCommand(
            Func<Task> execute,
            Func<bool> canExecute = null!,
            Action<Exception> exceptionHandler = null!)
            => new(execute, canExecute, exceptionHandler);

        public static AsyncCommand AsyncCommand(
            Func<Task> execute,
            Action<Exception> exceptionHandler)
            => new(execute, null!, exceptionHandler);

        public static AsyncCommand<T> AsyncCommand<T>(
            Func<T, Task> execute,
            Func<T, bool> canExecute = null!,
            Action<Exception> exceptionHandler = null!)
            where T : class => new(execute, canExecute, exceptionHandler);

        public static AsyncCommand<T> AsyncCommand<T>(
            Func<T, Task> execute,
            Action<Exception> exceptionHandler = null!)
            where T : class => new(execute, null!, exceptionHandler);
    }
}