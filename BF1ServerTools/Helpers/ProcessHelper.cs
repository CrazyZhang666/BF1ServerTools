﻿namespace BF1ServerTools.Helpers;

public static class ProcessHelper
{
    /// <summary>
    /// 判断程序是否运行
    /// </summary>
    /// <param name="appName">程序名称</param>
    /// <returns>正在运行返回true，未运行返回false</returns>
    public static bool IsAppRun(string appName)
    {
        return Process.GetProcessesByName(appName).Length > 0;
    }

    /// <summary>
    /// 判断战地1程序是否运行
    /// </summary>
    /// <returns></returns>
    public static bool IsBf1Run()
    {
        var pArray = Process.GetProcessesByName("bf1");
        if (pArray.Length > 0)
        {
            foreach (var item in pArray)
            {
                if (item.MainWindowTitle.Equals("Battlefield™ 1"))
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 打开http链接或者文件夹路径
    /// </summary>
    /// <param name="url"></param>
    public static void OpenLink(string url)
    {
        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
    }

    /// <summary>
    /// 打开指定进程，可以附带运行参数
    /// </summary>
    /// <param name="path">本地文件夹路径</param>
    public static void OpenProcess(string path, string args = "")
    {
        Process.Start(path, args);
    }

    /// <summary>
    /// 根据名字关闭指定程序
    /// </summary>
    /// <param name="processName">程序名字，不需要加.exe</param>
    public static void CloseProcess(string processName)
    {
        var appProcess = Process.GetProcesses();
        foreach (var targetPro in appProcess)
        {
            if (targetPro.ProcessName.Equals(processName))
                targetPro.Kill();
        }
    }

    /// <summary>
    /// 运行CMD命令
    /// </summary>
    /// <param name="cmd"></param>
    public static void RunCMD(string cmd)
    {
        var process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = "/k" + cmd;
        process.Start();
    }

    /// <summary>
    /// 关闭全部第三方exe进程
    /// </summary> 
    public static void CloseThirdProcess()
    {
        CloseProcess("go-cqhttp");
    }
}
