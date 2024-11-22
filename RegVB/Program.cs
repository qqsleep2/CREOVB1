using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace RegVB
{
    class Program
    {
        static void Main(string[] args)
        {

            string regFilePath = @"D:\PTC\Creo 6.0.0.0\Parametric\bin\vb_api_register.bat";
            string unregFilePath = @"D:\PTC\Creo 6.0.0.0\Parametric\bin\vb_api_unregister.bat";


            string variableValue = @"D:\PTC\Creo 6.0.0.0\Common Files\x86e_win64\obj\pro_comm_msg.exe";
            string variableName = "PRO_COMM_MSG_EXE";



            //STEP1:注册vb_api_register
             RegCom(regFilePath);
           // RunCmd(regFilePath);

            //STEP2:设置环境变量
            SetEnv(variableValue, variableName);

            //STEP3:启用变量
            RunCmd("echo PATH=C:");


            Console.Read();
        }

        private static void SetEnv(string variableValue, string variableName)
        {
            try
            {
                // 获取当前用户的环境变量
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);

                // 添加或修改环境变量
                registryKey.SetValue(variableName, variableValue, RegistryValueKind.String);

                registryKey.Close();

              //  Console.WriteLine($"{variableName} 环境变量已添加或修改。");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }

        public static void RegCom(string regFilePath)
        {
            Process.Start(regFilePath);
           
        }


        public static void RunCmd(string cmd)
        {
            // 要执行的cmd命令
            string command = cmd;

            // 启动进程
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe"; // 设置cmd.exe作为程序执行
                process.StartInfo.UseShellExecute = false; // 不使用系统外壳程序启动
                process.StartInfo.RedirectStandardInput = true; // 重定向标准输入
                process.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
                process.StartInfo.RedirectStandardError = true; // 重定向错误输出
                process.StartInfo.CreateNoWindow = true; // 不创建新窗口


                // 启动进程
                process.Start();

                // 输入要执行的命令
                //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(process.StandardInput.BaseStream))
                //{
                //    sw.WriteLine(command);
                //    sw.WriteLine("exit"); // 可以退出cmd.exe
                //}

                // 获取命令执行结果
                string result = process.StandardOutput.ReadToEnd();
                Console.WriteLine(result);
                // 等待程序执行完成
                process.WaitForExit();
            }
        }
    }

}