using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectCreo;
using pfcls;

namespace 文件操作
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void Openprt()
        {
            var asyncCon = ConCreo.GetAsyncConnection();
            if (asyncCon == null)
            {
                Console.WriteLine("faild");
                return;
            }

            //    Dim modelDesc As IpfcModelDescriptor
            //Dim fileOpenopts As IpfcFileOpenOptions
            //Dim filename As String
            //Dim retrieveModelOptions As IpfcRetrieveModelOptions
            //Dim model As IpfcModel

            try
            {
                // 使用ccpfc类初始化ipfc类，生成creo打开文件的对话框的选项
                var fileOpenopts = (new CCpfcFileOpenOptions()).Create("*.prt");


                //'如果点击取消按钮，会throw一个"pfcExceptions::XToolkitUserAbort" Exception，被下面的catch捕捉
                var filename = asyncCon.Session.UIOpenFile(fileOpenopts)
                //'使用ccpfc类初始化ipfc类，生成IpfcModelDescriptor
                //modelDesc = (New CCpfcModelDescriptor).Create(EpfcModelType.EpfcMDL_PART, Nothing, Nothing)
                //modelDesc.Path = filename
                //'使用ccpfc类初始化ipfc类，生成IpfcRetrieveModelOptions
                //retrieveModelOptions = (New CCpfcRetrieveModelOptions).Create
                //retrieveModelOptions.AskUserAboutReps = False
                //'加载零件
                //model = asyncConnection.Session.RetrievemodelWithOpts(modelDesc, retrieveModelOptions)
                //'显示零件
                //model.Display()
                //'激活当前窗体
                //asyncConnection.Session.CurrentWindow.Activate()
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void CCpfcFileOpenOptions()
        {
            throw new NotImplementedException();
        }
    }
}



//''' <summary>
//''' 打开一个模型
//''' </summary>
//Public Sub Openprt()
//    Dim modelDesc As IpfcModelDescriptor
//    Dim fileOpenopts As IpfcFileOpenOptions
//    Dim filename As String
//    Dim retrieveModelOptions As IpfcRetrieveModelOptions
//    Dim model As IpfcModel
//    Try
//        '使用ccpfc类初始化ipfc类，生成creo打开文件的对话框的选项
//        fileOpenopts = (New CCpfcFileOpenOptions).Create("*.prt")
//        '如果点击取消按钮，会throw一个"pfcExceptions::XToolkitUserAbort" Exception，被下面的catch捕捉
//        filename = asyncConnection.Session.UIOpenFile(fileOpenopts)
//        '使用ccpfc类初始化ipfc类，生成IpfcModelDescriptor
//        modelDesc = (New CCpfcModelDescriptor).Create(EpfcModelType.EpfcMDL_PART, Nothing, Nothing)
//        modelDesc.Path = filename
//        '使用ccpfc类初始化ipfc类，生成IpfcRetrieveModelOptions
//        retrieveModelOptions = (New CCpfcRetrieveModelOptions).Create
//        retrieveModelOptions.AskUserAboutReps = False
//        '加载零件
//        model = asyncConnection.Session.RetrievemodelWithOpts(modelDesc, retrieveModelOptions)
//        '显示零件
//        model.Display()
//        '激活当前窗体
//        asyncConnection.Session.CurrentWindow.Activate()
//    Catch ex As Exception
//        If ex.Message<> "pfcExceptions::XToolkitUserAbort" Then
//            MsgBox(ex.Message.ToString + Chr(13) + ex.StackTrace.ToString)
//        End If
//    End Try
//End Sub

//''' <summary>
//''' 保存当前打开的模型
//''' </summary>
//Public Sub Savepart()
//    Dim model As IpfcModel
//    Try
//        '当前打开的模型，也可以是别的model
//        model = asyncConnection.Session.CurrentModel
//        If model IsNot Nothing Then
//            '执行则保存修改
//            model.Save()
//        End If
//    Catch ex As Exception
//        MsgBox(ex.Message.ToString + Chr(13) + ex.StackTrace.ToString)
//    End Try
//End Sub

//''' <summary>
//''' 枚举当前工作目录下所有prt
//''' </summary>
//Public Sub ListFiles()
//    Dim Files As Cstringseq
//    Try
//        '枚举工作目录下所有最新版prt文件
//        Files = CType(asyncConnection.Session, IpfcBaseSession).ListFiles("*.prt", EpfcFileListOpt.EpfcFILE_LIST_LATEST, asyncConnection.Session.GetCurrentDirectory)
//        For Each Str As String In Files
//            MessageBox.Show(Str)
//        Next
//    Catch ex As Exception
//        MsgBox(ex.Message.ToString + Chr(13) + ex.StackTrace.ToString)
//    End Try
//End Sub