using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;
using Northwoods.Go;
using System.Collections;

namespace ITAMngApp.CmMng.BaseLib
{
    [Serializable]
    public class GraphDoc : GoDocument
    {
        public GraphDoc()
        {
            this.Name = "Flow Chart " + NextDocumentID();
            this.MaintainsPartID = true;
            this.IsModified = false;
        }

        public String Location
        {
            get { return myLocation; }
            set
            {
                String old = myLocation;
                if (old != value)
                {
                    //RemoveDocument(old);
                    myLocation = value;
                    //AddDocument(value, this);
                    RaiseChanged(ChangedLocation, 0, null, 0, old, NullRect, 0, value, NullRect);
                }
            }
        }

        public void AddTitleAndAnnotation()
        {
            StartTransaction();
            Title title = new Title();
            title.Text = "Flow Chart";
            title.Label.FontSize = 20;
            title.Label.Bold = true;
            title.Position = new PointF(100, 10);
            Add(title);
            Title annot = new Title();
            annot.Text = DateTime.Today.ToShortDateString();
            annot.Position = new PointF(400, 10);
            Add(annot);
            FinishTransaction("Added Title and Annotation");
        }

        public void InsertComment()
        {
            GoComment comment = new GoComment();
            comment.Text = "Enter your comment here,\r\non multiple lines.";
            comment.Position = NextNodePosition();
            comment.Label.Multiline = true;
            comment.Label.Editable = true;
            StartTransaction();
            Add(comment);
            FinishTransaction("Insert Comment");
        }

        public void InsertNode(GraphNodeKind k)
        {
            GoObject n = new GraphNode(k);
            n.Position = NextNodePosition();
            StartTransaction();
            Add(n);
            FinishTransaction("Insert Node");
        }

        public PointF NextNodePosition()
        {
            PointF next = myNextNodePos;
            myNextNodePos.X += 50;
            if (myNextNodePos.X > 400)
            {
                myNextNodePos.X = 40;
                myNextNodePos.Y += 50;
                if (myNextNodePos.Y > 300)
                    myNextNodePos.Y = 40;
            }
            return next;
        }

        public override void ChangeValue(GoChangedEventArgs e, bool undo)
        {
            switch (e.Hint)
            {
                case ChangedLocation:
                    {
                        this.Location = (String)e.GetValue(undo);
                        break;
                    }
                default:
                    base.ChangeValue(e, undo);
                    return;
            }
        }

        public override void Undo()
        {
            base.Undo();
           
        }

        public override void Redo()
        {
            base.Redo();
         
        }

        public override bool FinishTransaction(String tname)
        {
            bool result = base.FinishTransaction(tname);
           
            return result;
        }

       

        public bool IsReadOnly
        {
            get
            {
                if (this.Location == "") return false;
                FileInfo info = new FileInfo(this.Location);
                bool ro = ((info.Attributes & FileAttributes.ReadOnly) != 0);
                bool oldskips = this.SkipsUndoManager;
                this.SkipsUndoManager = true;
                // take out the following statement if you want the user to be able
                // to modify the graph even though the file is read-only
                SetModifiable(!ro);
                this.SkipsUndoManager = oldskips;
                return ro;
            }
        }

        public static int NextDocumentID()
        {
            return myDocCounter++;
        }

        //public static GraphDoc FindDocument(String location)
        //{
        //    return myDocuments[location] as GraphDoc;
        //}

        //internal static void AddDocument(String location, GraphDoc doc)
        //{
        //    myDocuments[location] = doc;
        //}

        //internal static void RemoveDocument(String location)
        //{
        //    myDocuments.Remove(location);
        //}

        public const int ChangedLocation = LastHint + 23;

        private static int myDocCounter = 1;

        //private static Hashtable myDocuments = new Hashtable();

        private String myLocation = "";

        public PointF myNextNodePos = new PointF(30, 30);
    }

    [Serializable]
    public class Title : GoComment
    {
        public Title()
        {
            this.Label.Multiline = true;
            this.Label.Editable = true;
            this.Label.Alignment = GoObject.MiddleTop;
        }

        protected override GoObject CreateBackground()
        {
            return null;
        }
    }
}
