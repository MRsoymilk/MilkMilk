using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkMilk.Internal
{
    public static class Logger
    {
        private static readonly Action<ILogger, Exception> _index_logger;
        private static readonly Action<ILogger, string, Exception> _quote_add;
        private static readonly Action<ILogger, string, int, Exception> _quote_delete;
        private static readonly Action<ILogger, int, Exception> _quote_delete_fail;
        static Logger()
        {
            _index_logger = LoggerMessage.Define(
                            LogLevel.Information,
                            new EventId(1, nameof(IndexLogger)),
                            "<<<<< index logger");

            _quote_add = LoggerMessage.Define<string>(
                            LogLevel.Information,
                            new EventId(2, nameof(QuoteAdd)),
                            "+++++ quote add (quote = '{quote}')");

            _quote_delete = LoggerMessage.Define<string, int>(
                            LogLevel.Information,
                            new EventId(3, nameof(QuoteDelete)),
                            "----- quote delete (quote = '{quote}' id = '{id}')");
        }

        public static void IndexLogger(this ILogger logger)
        {
            _index_logger(logger, null);
        }

        public static void QuoteAdd(this ILogger logger, string quote)
        {
            _quote_add(logger, quote, null);
        }

        public static void QuoteDelete(this ILogger logger, string quote, int id)
        {
            _quote_delete(logger, quote, id, null);
        }

    }
}
