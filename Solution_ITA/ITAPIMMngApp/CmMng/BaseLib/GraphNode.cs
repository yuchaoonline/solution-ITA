using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;
using Northwoods.Go;

namespace ITAMngApp.CmMng.BaseLib
{
    public enum MGraphEventType
    {
        DoubleClick=1,
        SingleClick=2
    }

    public class MGraphEventArgs : EventArgs
    {
        public MGraphEventArgs(MGraphEventType p_meventtype)
        {
            EventType = p_meventtype;
        }

        MGraphEventType m_eventtype;
        public MGraphEventType EventType
        {
            get { return m_eventtype; }
            set { m_eventtype = value; }
        }
    }

    /// <summary>
    /// Specify different kinds of GraphNodes.
    /// </summary>
    public enum GraphNodeKind
    {
        Start = 1,
        End = 2,
        Step = 3,
        Input = 4,
        Output = 5,
        Decision = 6,
        Read = 7,
        Write = 8,
        ManualOperation = 9,
        Database = 10
    }


    /// <summary>
    /// A node representing a step or action in a flowchart.
    /// </summary>
    [Serializable]
    public class GraphNode : GoTextNode
    {
        public GraphNode(GraphNodeKind k)
            : base()
        {
            myKind = k;
            this.Label.Wrapping = true;
            this.Label.Editable = true;
            this.Label.Alignment = Middle;
            this.Editable = true;
            switch (k)
            {
                case GraphNodeKind.Start:
                    {
                        this.Background = new GoRoundedRectangle();
                        this.Background.Selectable = false;
                        this.TopPort = null;
                        this.RightPort.IsValidTo = false;
                        this.BottomPort.IsValidTo = false;
                        this.Text = "Start";
                        break;
                    }
                case GraphNodeKind.End:
                    {
                        this.Background = new GoRoundedRectangle();
                        this.Background.Selectable = false;
                        this.TopPort.IsValidFrom = false;
                        this.LeftPort.IsValidFrom = false;
                        this.BottomPort = null;
                        this.Text = "End";
                        break;
                    }
                case GraphNodeKind.Step:
                    {
                        this.BottomPort.IsValidTo = false;
                        this.Text = "Step";
                        break;
                    }
                case GraphNodeKind.Input:
                    {
                        this.Background = new GoParallelogram();
                        this.Background.Selectable = false;
                        this.TopLeftMargin = new SizeF(20, 4);
                        this.BottomRightMargin = new SizeF(20, 4);
                        this.TopPort.IsValidFrom = false;
                        this.BottomPort.IsValidTo = false;
                        this.Text = "Input";
                        break;
                    }
                case GraphNodeKind.Output:
                    {
                        this.Background = new GoParallelogram();
                        this.Background.Selectable = false;
                        this.TopLeftMargin = new SizeF(20, 4);
                        this.BottomRightMargin = new SizeF(20, 4);
                        this.TopPort.IsValidFrom = false;
                        this.BottomPort.IsValidTo = false;
                        this.Text = "Output";
                        break;
                    }
                case GraphNodeKind.Decision:
                    {
                        this.Background = new GoDiamond();
                        this.Background.Selectable = false;
                        this.TopLeftMargin = new SizeF(35, 20);
                        this.BottomRightMargin = new SizeF(35, 20);
                        this.TopPort.IsValidFrom = false;
                        this.BottomPort.IsValidTo = false;
                        this.Text = "?";
                        break;
                    }
                case GraphNodeKind.Read:
                    {
                        this.Background = new GoEllipse();
                        this.Background.Selectable = false;
                        this.TopLeftMargin = new SizeF(20, 10);
                        this.BottomRightMargin = new SizeF(20, 10);
                        this.TopPort.IsValidFrom = false;
                        this.BottomPort.IsValidTo = false;
                        this.Text = "Read";
                        break;
                    }
                case GraphNodeKind.Write:
                    {
                        this.Background = new GoEllipse();
                        this.Background.Selectable = false;
                        this.TopLeftMargin = new SizeF(20, 10);
                        this.BottomRightMargin = new SizeF(20, 10);
                        this.TopPort.IsValidFrom = false;
                        this.BottomPort.IsValidTo = false;
                        this.Text = "Write";
                        break;
                    }
                case GraphNodeKind.ManualOperation:
                    {
                        GoTrapezoid trap = new GoTrapezoid();
                        trap.A = new PointF(0, 0);
                        trap.B = new PointF(50, 0);
                        trap.C = new PointF(45, 100);
                        trap.D = new PointF(5, 100);
                        this.Background = trap;
                        this.Background.Selectable = false;
                        this.TopLeftMargin = new SizeF(20, 10);
                        this.BottomRightMargin = new SizeF(20, 10);
                        this.TopPort.IsValidFrom = false;
                        this.BottomPort.IsValidTo = false;
                        this.Text = "Manual \nOperation";
                        break;
                    }
                case GraphNodeKind.Database:
                    {
                        this.Background = new GoCylinder();
                        this.Background.Selectable = false;
                        this.TopLeftMargin = new SizeF(10, 30);
                        this.BottomRightMargin = new SizeF(10, 15);
                        this.TopPort.IsValidFrom = false;
                        this.BottomPort.IsValidTo = false;
                        this.Text = "Database";
                        break;
                    }
            }
            this.Brush = Brushes.White;
            this.Shadowed = true;
            LayoutChildren(null);
        }

        public delegate void OnNewEventHandler(object sender, MGraphEventArgs e);
        
        /// <summary> 
        /// 节点的动作事件 
        /// </summary> 
        public event OnNewEventHandler OnNewEventFun;

        /// <summary>
        /// The location for each node is the Center.
        /// </summary>
        public override PointF Location
        {
            get { return this.Center; }
            set { this.Center = value; }
        }

        /// <summary>
        /// Adjust port positions for certain background shapes.
        /// </summary>
        /// <param name="childchanged"></param>
        public override void LayoutChildren(GoObject childchanged)
        {
            base.LayoutChildren(childchanged);
            GoParallelogram back = this.Background as GoParallelogram;
            if (back != null)
            {
                SizeF skew = back.Skew;
                if (this.RightPort != null)
                    this.RightPort.Left -= skew.Width / 2;
                if (this.LeftPort != null)
                    this.LeftPort.Left += skew.Width / 2;
            }
            GoTrapezoid trap = this.Background as GoTrapezoid;
            if (trap != null)
            {
                if (this.RightPort != null)
                    this.RightPort.Left -= Math.Abs(trap.B.X - trap.C.X) / 2;
                if (this.LeftPort != null)
                    this.LeftPort.Left += Math.Abs(trap.A.X - trap.D.X) / 2;
                if (this.TopPort != null)
                    this.TopPort.Top += Math.Abs(trap.A.Y - trap.B.Y) / 2;
                if (this.BottomPort != null)
                    this.BottomPort.Top -= Math.Abs(trap.D.Y - trap.C.Y) / 2;
            }
        }

        /// <summary>
        /// When the mouse passes over a node, display all of its ports.
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        /// <remarks>
        /// All ports on all nodes are hidden when the mouse hovers over the background.
        /// </remarks>
        public override bool OnMouseOver(GoInputEventArgs evt, GoView view)
        {
            GraphView v = view as GraphView;
            if (v != null)
            {
                foreach (GoPort p in this.Ports)
                {
                    p.SkipsUndoManager = true;
                    p.Style = GoPortStyle.Ellipse;
                    p.Brush = null;
                    p.SkipsUndoManager = false;
                }
            }
            return false;
        }

        /// <summary>
        /// Bring up a GraphNode specific context menu.
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public override bool OnContextClick(GoInputEventArgs evt, GoView view)
        {
            return base.OnContextClick(evt, view);
        }

        public override bool OnDoubleClick(GoInputEventArgs evt, GoView view)
        {
            if (view is GraphView)
            {
                //GraphView gview = view as GraphView;
                if (this.IsPredecessor)
                {
                    //MessageBox.Show(this.PartID + "_" + this.Text);
                    if (OnNewEventFun != null)
                    {
                        OnNewEventFun(this, new MGraphEventArgs(MGraphEventType.DoubleClick));
                    }
                }
                return true;
            }
            else
            {
                return base.OnDoubleClick(evt, view);
            }
        }


        public GraphNodeKind Kind
        {
            get { return myKind; }
        }

        public bool IsPredecessor
        {
            get { return this.BottomPort != null; }
        }

        private GraphNodeKind myKind = GraphNodeKind.Step;
    }

    [Serializable]
    public class GraphLabeledLink : GoLabeledLink
    {
        public delegate void OnNewEventHandler(object sender, MGraphEventArgs e);

        /// <summary> 
        /// 节点的动作事件 
        /// </summary> 
        public event OnNewEventHandler OnNewEventFun;


        public override bool OnDoubleClick(GoInputEventArgs evt, GoView view)
        {
            if (view is GraphView)
            {
                //GraphView gview = view as GraphView;
                
                //if (this.MidLabel is GoText)
                //{
                //    GoText t = (GoText)this.MidLabel;
                //    MessageBox.Show(this.PartID + "_" + t.Text);
                //}

                if (OnNewEventFun != null)
                {
                    OnNewEventFun(this, new MGraphEventArgs(MGraphEventType.DoubleClick));
                }
                return true;
            }
            else
            {
                return base.OnDoubleClick(evt, view);
            }
        }
    }
}
