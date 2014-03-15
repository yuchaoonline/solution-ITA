using System;
using System.Collections.Generic;
using System.Text;
using SCAATSoft.CommFramework;
using System.Windows.Forms;

namespace ITAMngApp.ApplicationFun
{
    public interface IFormExchange
    {
        void SetSelectedCargo(string p_SelectedCargoID);
    }

    public interface IResvNetData
    {
        void ResvNetData(string p_destformtext,object p_sender,DataReceivedEventArgs p_e);
    }

    public interface ISendNetdata
    {
        void InitData(Form p_mainform);
    }

    public class NetMsgExForShow
    {
        public string Msg_01_ID;
        public string Msg_02_State;
        public string Msg_03_CommModule;
        public string Msg_04_IDInfo;
        public string Msg_05_Len;
        public string Msg_06_SrcId;
        public string Msg_07_DestId;
        public string Msg_08_Seq;
        public string Msg_09_Tm;
        public string Msg_10_SendorResv;
        public string Msg_11_Content;
        public object Msg_12_Obj;
        public string Msg_13_ReplyStatus;

        public NetMsgExForShow()
        {
            Msg_13_ReplyStatus = "µÈ´ý";
        }
    }
}
