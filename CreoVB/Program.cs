using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pfcls;
using ConnectCreo;

namespace CreoVB
{
    class Program
    {



        static void Main(string[] args)
        {



            var asyncCon = ConCreo.GetAsyncConnection();
            if (asyncCon == null)
            {
                Console.WriteLine("faild");
                return;
            }

            asyncCon.Session.UIShowMessageDialog("YES", null);

            Console.Read();
        }





    }//end class
}










//''' <summary>
//''' 打开新会话
//''' </summary>
//''' <returns>新建会话是否成功</returns>
//Public Function Creo_New() As Boolean
//    Try
//        Dim CmdLine As String = ConfigurationManager.AppSettings("CmdLine").ToString()
//        Dim TextPath As String = ConfigurationManager.AppSettings("TextPath").ToString()
//        asyncConnection = (New CCpfcAsyncConnection).Start(CmdLine, TextPath)
//        Creo_New = True
//    Catch ex As Exception
//        Creo_New = False
//        MsgBox(ex.Message.ToString + Chr(13) + ex.StackTrace.ToString)
//    End Try
//End Function*/
