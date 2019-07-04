using System.Windows.Input;

namespace SByte.Common.Extensions
{
    public static class CommandExtensions
    {
        public static bool SafeCanExecute(this ICommand command, object parameter = null)
        {
            return command != null && command.CanExecute(parameter);
        }

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