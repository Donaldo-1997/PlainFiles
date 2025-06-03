using LogginWithStreamWriter;

using (var logger = new LogWriter("C:\\Users\\donal\\OneDrive\\Escritorio\\log.txt"))
{
    logger.WriteLog("INFO", "Application started.");
    logger.WriteLog("ERROR", "An error occurred.");
    logger.WriteLog("DEBUG", "Debugging information.");
}