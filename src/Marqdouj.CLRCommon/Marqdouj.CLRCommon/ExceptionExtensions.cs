namespace Marqdouj.CLRCommon
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Resolves all messages, including inner exceptions.
        /// Originally designed for use with Aggregate exceptions, but will work with any Exception.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string ToMessage(this Exception ex)
        {
            var messages = ex.ToMessageList();
            return string.Join("\n", messages);
        }

        /// <summary>
        /// <see cref="ToMessage(Exception)"/>
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
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
