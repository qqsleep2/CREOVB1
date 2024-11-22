using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pfcls;


namespace ConnectCreo
{
    public static class ConCreo
    {
        public static IpfcAsyncConnection asyncConnection = null;

        public static string CreoPath = @"D:\PTC\Creo 6.0.0.0\Parametric\bin\parametric.exe";


        public static IpfcAsyncConnection GetAsyncConnection()
        {
            IpfcAsyncConnection ret = null;

            if (Creo_Connect() || Creo_New())
                ret = asyncConnection;

            return ret;
        }

        /// <summary>
        /// 连接现有会话
        /// </summary>
        /// <returns>是否连接成功</returns>
        public static bool Creo_Connect()
        {
            bool ret = false;
            try
            {
                if (asyncConnection == null || asyncConnection.IsRunning())
                {
                    asyncConnection = (new CCpfcAsyncConnection()).Connect(null, null, null, null);
                    if (asyncConnection != null)
                        ret = true;
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("failed");
            }


            return ret;
        }



        /// <summary>
        /// 打开新会话
        /// </summary>
        /// <returns>新建会话是否成功</returns>
        public static bool Creo_New()
        {
            bool ret = false;

            try
            {
                asyncConnection = (new CCpfcAsyncConnection()).Start(CreoPath, null);
                Debug.Print(asyncConnection.ToString());
               
                if (asyncConnection != null)
                    ret = true;
            }
            catch (Exception)
            {


                //Console.WriteLine("failed");
            }


            return ret;
        }

    }
}
