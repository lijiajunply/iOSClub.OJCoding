using System.Diagnostics;

namespace OJBlazor.Share.DataModels;

public class DebugModel : IDisposable
{
    private readonly Process proc;

    private readonly Lang _lang;

    private readonly string _code;

    private readonly string _codeFile;

    public static Lang StringToLang(string land)
    {
        return land switch
        {
            "python2" => Lang.py2,
            "python" => Lang.py,
            "csharp" => Lang.cs,
            "cpp" => Lang.cpp,
            "java" => Lang.java,
            "c" => Lang.c,
            _ => Lang.cs
        };
    }

    /// <summary>
    /// debug model
    /// </summary>
    /// <param name="lang">语言</param>
    /// <param name="code">代码</param>
    public DebugModel(Lang lang, string code)
    {
        proc = new Process();
        proc.StartInfo.FileName = "/bin/bash";
        proc.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
        proc.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
        proc.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
        proc.StartInfo.RedirectStandardError = true; //重定向标准错误输出
        _lang = lang;
        _code = code;
        _codeFile = "text." + _lang;
    }

    /// <summary>
    /// 运行代码
    /// </summary>
    /// <returns>输出:string</returns>
    public string RunCode()
    {
        proc.Start();
        proc.StandardInput.WriteLine("docker exec -i testUbuntu /bin/bash");
        proc.StandardInput.WriteLine(LangToShell());
        proc.StandardInput.Close();
        return proc.StandardOutput.ReadToEnd();
    }

    private string? LangToShell()
    {
        var shell = "cat>" + _codeFile + @"<<\EOF " + "\n" + _code + "\n" + "EOF" + "\n";
        return _lang switch
        {
            Lang.c => shell + "gcc text.c && a.out",
            Lang.cpp => shell + "g++ -std=c++11 text.cpp && a.out",
            Lang.cs => shell + "dotnet-exec text.cs",
            Lang.java => shell + "java text.java",
            Lang.py => shell + "python3 text.py",
            Lang.py2 => shell + "python2 text.py2",
            _ => null
        };
    }

    public void Dispose()
    {
        proc.Dispose();
    }
}

public enum Lang
{
    cs,
    java,
    cpp,
    c,
    py,
    py2
}

public class CodeModel
{
    public string Code { get; set; }
    public string Lang { get; set; }

    public DebugModel ToDebugModel()
    {
        var l = DebugModel.StringToLang(Lang);
        return new DebugModel(l, Code);
    }
}