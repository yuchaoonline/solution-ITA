using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net.Sockets;
using System.Net;

namespace SCAATSoft.CommFramework
{
    public class DataReceivedEventArgs : EventArgs
    {
        public DataReceivedEventArgs(byte[] data, int datalen)
        {
            Data = data;
            DataLen = datalen; 
        }

        byte[] m_Data;
        public byte[] Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        int m_datalen;
        public int DataLen
        {
            get { return m_datalen; }
            set { m_datalen = value; }
        }
    }

    public class UdpSocketServer
    {

        public delegate void OnReceivedDataHandler(object sender, DataReceivedEventArgs e);
        
        /// <summary> 
        /// 服务器接收到数据事件 
        /// </summary> 
        /// 
        public event OnReceivedDataHandler OnRecivedData;


        private int _servPort = 0x8000;

        public int ServPort
        {
            get { return _servPort; }
            set { _servPort = value; }
        }

        private int _bufferSize = 64 * 1024;
        public int BufferSize
        {
            get { return _bufferSize; }
            set { _bufferSize = value; }
        }


        //The collection of all clients logged into the room (an array of type ClientInfo)
        ArrayList clientList;

        //The main socket on which the server listens to the clients
        Socket serverSocket;

        byte[] byteData = null;

        public bool Init()
        {
            try
            {
                byteData = new byte[_bufferSize];
                //We are using UDP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);

                //Assign the any IP of the machine and listen on port number ServPort
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, _servPort);

                //Bind this address to the server
                serverSocket.Bind(ipEndPoint);

                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                //The epSender identifies the incoming clients
                EndPoint epSender = (EndPoint)ipeSender;

                //Start receiving data
                serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length,
                    SocketFlags.None, ref epSender, new AsyncCallback(OnReceive), epSender);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        public bool Init(string p_ipaddress)
        {
            try
            {
                byteData = new byte[_bufferSize];
                //We are using UDP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);

                //Assign the any IP of the machine and listen on port number ServPort
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(p_ipaddress), _servPort);

                //Bind this address to the server
                serverSocket.Bind(ipEndPoint);

                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                //The epSender identifies the incoming clients
                EndPoint epSender = (EndPoint)ipeSender;

                //Start receiving data
                serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length,
                    SocketFlags.None, ref epSender, new AsyncCallback(OnReceive), epSender);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }


        public bool Close()
        {
            try
            {
                serverSocket.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)ipeSender;

                int recvlen = serverSocket.EndReceiveFrom(ar, ref epSender);

                try
                {
                    if (OnRecivedData != null)
                    {
                        OnRecivedData(this, new DataReceivedEventArgs(byteData, recvlen));
                    }
                }
                catch (System.Exception ex)
                {

                }
                finally
                {

                }
                serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epSender,
                       new AsyncCallback(OnReceive), epSender);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                
            }
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {
                serverSocket.EndSend(ar);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }


    }

    public class UdpSocketClient
    {
        public string m_ServerIP;
        public int m_ServerPort;

        private Socket clientSocket;
        private EndPoint epServer;

        public void SendMsg(byte[] p_msgbyteData)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork,
                   SocketType.Dgram, ProtocolType.Udp);

            //IP address of the server machine
            IPAddress ipAddress = IPAddress.Parse(m_ServerIP);
            //Server is listening on port 1000
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, m_ServerPort);

            epServer = (EndPoint)ipEndPoint;

            //Login to the server
            clientSocket.BeginSendTo(p_msgbyteData, 0, p_msgbyteData.Length,
                SocketFlags.None, epServer, new AsyncCallback(OnSend), null);
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}
