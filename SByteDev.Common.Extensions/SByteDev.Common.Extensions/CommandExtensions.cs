using System.Windows.Input;

namespace SByteDev.Common.Extensions
{
    public static class CommandExtensions
    {
        /// <summary>
        /// Safely checks whether the command can be executed in its current state.
        /// </summary>
        /// <param name="command">The command itself.</param>
        /// <param name="parameter">An optional parameter.</param>
        /// <returns>True if the command can be executed in its current state and False otherwise.</returns>
        public static bool SafeCanExecute(this ICommand command, object parameter = null)
        {
            return command != null && command.CanExecute(parameter);
        }

        /// <summary>
        /// Safely invokes the command if this command can be executed in its current state.
        /// </summary>
        /// <param name="command">The command itself.</param>
        /// <param name="parameter">An optional parameter.</param>
        /// <returns>True if the command was invoked and False otherwise.</returns>
        public static bool SafeExecute(this ICommand command, object parameter = null)
        {
            if (!command.SafeCanExecute(parameter))
            {
                return false;
            }

            command.Execute(parameter);

            return true;
        }
    }
}