using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

class MyStupidLogger
{
    public string Path { get; private set; }
    private Stopwatch Watch = new Stopwatch();

    public MyStupidLogger(string path)
    {
        Path = path;
        СallToStartWork();
    }

    public void StartStopWatch()
    {
        Watch.Start();
    }
    public void StopStopWatch(string text)
    {
        Watch.Stop();
        var time = Watch.ElapsedMilliseconds;
        Watch.Reset();
        WriteDown(text + " за: " + time + " мс.\n");
    }

    public void СallToFinishWork()
    {
        WriteDown(GetDate());
        WriteDown("Успешное окончание работы.\n\n");
    }
    private void СallToStartWork()
    {
        WriteDown(GetDate());
        WriteDown("Запуск программы.\n");
    }

    public void CallToError(string text, string methodName = "")
    {
        WriteDown(GetDate());
        WriteDown("Обработанная ошибка в " + methodName);
        WriteDown(text + "\n");
    }
    public void CallToInfo(string text, string methodName = "")
    {
        WriteDown(GetDate());
        WriteDown(methodName);
        WriteDown(text + "\n");
    }

    private string GetDate()
    {
        return DateTime.Now + ": ";
    }

    private void WriteDown(string text)
    {
        using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
        {
            sw.WriteAsync(text);
        }
    }
    public static string GetCallerName([CallerMemberName] string name = "")
    {
        return name;
    }
}