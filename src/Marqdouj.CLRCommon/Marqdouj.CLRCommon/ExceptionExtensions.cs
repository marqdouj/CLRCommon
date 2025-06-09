namespace Marqdouj.CLRCommon
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Resolves all messages recursively.
        /// Originally designed for use with Aggregate exceptions, but will work with any Exception.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Returns a joined string of all messages, using '\n' as the separator</returns>
        public static string ToMessage(this Exception ex)
        {
            return ex.ToMessage('\n');
        }

        /// <summary>
        /// Resolves all messages recursively.
        /// Originally designed for use with Aggregate exceptions, but will work with any Exception.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="separator">Separator for joining messages</param>
        /// <returns>Returns a joined string of all messages, using a char separator. default = '\n'</returns>
        public static string ToMessage(this Exception ex, char separator)
        {
            var messages = ex.ToMessageList();
            return string.Join(separator, messages);
        }

        /// <summary>
        /// Resolves all messages recursively.
        /// Originally designed for use with Aggregate exceptions, but will work with any Exception.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="separator">Separator for joining messages</param>
        /// <returns>Returns a joined string of all messages, using a string separator. default = "\n"</returns>
        public static string ToMessage(this Exception ex, string separator)
        {
            var messages = ex.ToMessageList();
            return string.Join(separator, messages);
        }

        /// <summary>
        /// Resolves all messages recursively.
        /// Originally designed for use with Aggregate exceptions, but will work with any Exception.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>a list of all messages.</returns>
        public static List<string> ToMessageList(this Exception ex)
        {
            var messages = new List<string>();
            AddMessagesToList(messages, ex);
            return messages;
        }

        private static void AddMessagesToList(List<string> messages, Exception? ex)
        {
            if (ex == null) return;

            if (ex is AggregateException aggregate)
            {
                foreach (var item in aggregate.InnerExceptions)
                {
                    if (item is not AggregateException)
                        AddMessageToList(messages, item.Message);

                    AddMessagesToList(messages, item.InnerException);
                }
            }
            else
            {
                AddMessageToList(messages, ex.Message);
                AddMessagesToList(messages, ex.InnerException);
            }
        }

        private static void AddMessageToList(List<string> messages, string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                messages.Add(message);
        }
    }
}
