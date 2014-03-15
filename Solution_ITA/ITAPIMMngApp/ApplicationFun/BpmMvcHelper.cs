using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;

namespace ITAMngApp.ApplicationFun
{

    public class BPMMvcModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        private string _nid;

        public string Nid
        {
            get { return _nid; }
            set { _nid = value; }
        }
        private string _form;

        public string Form
        {
            get { return _form; }
            set { _form = value; }
        }
    }

    public class BpmMvcHelper
    {

        public static ArrayList InitMvcNodeList(string p_filenamemvc)
        {
            string strAppDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string m_filename = strAppDir + "\\BPMFiles\\" + p_filenamemvc;

            Stream file = null;
            try
            {
                ArrayList ret_list = new ArrayList();

                file = File.Open(m_filename, FileMode.Open);
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(file);
                XmlNode root_xmlnode = xdoc.DocumentElement;


                foreach (XmlNode item in root_xmlnode)
                {
                    if (item.Name == "node")
                    {
                        XmlAttribute a_name;
                        XmlAttribute a_text;
                        XmlAttribute a_nid;
                        XmlAttribute a_form;
                        a_name = item.Attributes["name"];
                        a_text = item.Attributes["text"];
                        a_form = item.Attributes["form"];
                        a_nid = item.Attributes["nid"];
                        if (a_name != null && a_text != null && a_nid != null && a_form != null)
                        {
                            BPMMvcModel model = new BPMMvcModel();
                            model.Nid = a_nid.Value.Trim();
                            model.Name = a_name.Value.Trim();
                            model.Text = a_text.Value.Trim();
                            model.Form = a_form.Value.Trim();
                            ret_list.Add(model);
                        }

                    }
                }

                return ret_list;
            }
            catch (Exception e1)
            {
                return null;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                    file.Dispose();
                }
            }
        }


        public static BPMMvcModel GetMvcNodeByNid(string p_nid, ArrayList p_MvcNodeList)
        {
            if (p_MvcNodeList != null)
            {
                for (int i = 0; i < p_MvcNodeList.Count; i++)
                {
                    BPMMvcModel m_tempnode = (BPMMvcModel)p_MvcNodeList[i];
                    if (m_tempnode.Nid == p_nid) return m_tempnode;
                }
            }
            return null;
        }
      
    }
}
