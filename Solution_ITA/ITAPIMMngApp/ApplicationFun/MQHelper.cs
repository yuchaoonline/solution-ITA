using System;
using System.Collections.Generic;
using System.Text;
using MDS.Client;

namespace ITAMngApp.ApplicationFun
{
    public class MQHelper
    {
        private MDSClient mdsClient = null;

        private int timeoutMilliseconds;

        public int TimeoutMilliseconds
        {
            get { return timeoutMilliseconds; }
            set { timeoutMilliseconds = value; }
        }

        public bool InitClient(string p_MyAppName, MessageReceivedHandler p_MDSClient_MessageReceived)
        {
            try
            {
                //Create MDSClient object to connect to DotNetMQ
                //Name of this application: Application2
                mdsClient = new MDSClient(p_MyAppName);

                //Register to MessageReceived event to get messages.
                mdsClient.MessageReceived += p_MDSClient_MessageReceived;

                //Connect to DotNetMQ server
                mdsClient.Connect();

                return true;
            }
            catch (Exception e1)
            {
                return false;
            }
            finally
            {
 
            }
        }


        public bool SendMessage(string p_DestAppName,string p_MessageText)
        {
            try
            {
                IOutgoingMessage message = mdsClient.CreateMessage();
                //Set destination application name
                message.DestinationApplicationName = p_DestAppName;
                //message.DestinationServerName = "this_server2";
                //Set message data
                message.MessageData = Encoding.UTF8.GetBytes(p_MessageText);

                //Send message
                message.Send(timeoutMilliseconds);

                return true;
            }
            catch (Exception e1)
            {
                return false;
            }
            finally
            {

            }
        }

        static void MDSClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            //Get message
            string messageText = Encoding.UTF8.GetString(e.Message.MessageData);
            //Acknowledge that message is properly handled and processed. So, it will be deleted from queue.
            e.Message.Acknowledge();
        }


        public bool CloseClient()
        {
            try
            {
                mdsClient.Disconnect();
                return true;
            }
            catch (Exception e1)
            {
                return false;
            }
            finally
            {

            }
        }
    }
}
