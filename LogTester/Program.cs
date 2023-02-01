// See https://aka.ms/new-console-template for more information

using static KTLog.KtLog;

void pop()
{
    LogStart();
    Log("Log Proof");
    try
    {
        var zero = 0;
        var beans = 3 / zero;
    }
    catch (Exception ex)
    {
        LogWarning(ex);
    }
    SignPost();
    LogEnd();
    Console.ReadLine();
}

pop();