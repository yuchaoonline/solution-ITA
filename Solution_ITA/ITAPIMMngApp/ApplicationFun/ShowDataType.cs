using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using SharpGL;
using System.Drawing;

namespace ITAMngApp.ApplicationFun
{
    /// <summary>
    /// 二维坐标点
    /// </summary>
    public class Show2DPoint
    {
        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }


        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        
    }
    /// <summary>
    /// OpenGL绘图
    /// </summary>
    public class OpenGLDraw
    {
        [DllImport("opengl32.dll")]
        public static extern bool wglUseFontBitmaps(IntPtr hdc, uint first, uint count, uint listbase);
        [DllImport("opengl32.dll")]
        public static extern bool wglUseFontBitmapsW(IntPtr hdc, uint word, uint count, uint listbase);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        protected uint lists = 1000;
        IntPtr hdc = GetDC(IntPtr.Zero);
        //对应界面中的可以绘制的句柄
        public  SharpGL.OpenGL gl;
        /// <summary>
        ///  绘制坐标系
        /// </summary>
        /// <param name="length_y">Y轴长度</param>
        /// <param name="length_z">Z轴长度</param>
        /// <param name="length_x">X轴长度</param>
        public void DrawCoodinate(double length_y, double length_z, double length_x)
        {
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.LineWidth(1.5f);             //线宽
            gl.Begin(OpenGL.LINES);         //开始画线
            gl.Vertex(0, 0, 0);             //点1
            gl.Vertex(length_y, 0, 0);      //点2
            gl.End();                       //结束画线
            DrawArrow_Y(length_y);          //绘制箭头
            print_letters("Y", length_y + 3, 0, 0);//标注字母
            gl.Begin(OpenGL.LINES);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, length_z, 0);
            gl.End();
            DrawArrow_Z(length_z);
            print_letters("Z", 0, length_z + 3, 0);
            gl.Begin(OpenGL.LINES);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 0, length_x);
            gl.End();
            DrawArrow_X(length_x);
            print_letters("X", 0, 0, length_x + 3);
            gl.Flush();

        }
        /// <summary>
        /// //采用和其他坐标系一致的坐标系
        /// </summary>
        /// <param name="length_y"></param>
        /// <param name="length_z"></param>
        /// <param name="length_x"></param>
        public void DrawCoodinate_2(double length_y, double length_z, double length_x)
        {
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.LineWidth(1.5f);             //线宽
            gl.Begin(OpenGL.LINES);         //开始画线
            gl.Vertex(0, 0, 0);             //点1
            gl.Vertex(length_y, 0, 0);      //点2
            gl.End();                       //结束画线
            DrawArrow_Y(length_y);          //绘制箭头
            print_letters("Y", length_y + 3, 0, 0);//标注字母
            gl.Begin(OpenGL.LINES);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, length_z, 0);
            gl.End();
            
            DrawArrow_X_2(length_z);
            print_letters("X", 0, length_z + 3, 0);
            gl.Begin(OpenGL.LINES);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 0, length_x);
            gl.End();
            DrawArrow_Z_2(length_x);
            print_letters("Z", 0, 0, length_x - 3);
            gl.Flush();

        }
        /// <summary>
        /// 绘制坐标系的X轴箭头
        /// </summary>
        /// <param name="position">箭头在X轴上的位置</param>
        private void DrawArrow_X(double position)
        {
            int slices = 16;
            int stacks = 16;
            double radius = 0.5;
            double height =1.5;
            gl.MatrixMode(OpenGL.MODELVIEW);
            gl.PushMatrix();
            gl.Translate(0, 0, position);
           
            //绘制箭头（圆锥体）底面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < slices; i++)
            {
                gl.Vertex(radius * Math.Cos(Math.PI * 2 * i / slices) , radius * Math.Sin(Math.PI * 2 * i / slices) , 0);
            }
            gl.End();
            //底面绘制结束
            //开始绘制箭头（圆锥体）侧面
            IntPtr qobj = gl.NewQuadric();
            gl.Cylinder(qobj, radius, 0.0, height, slices, stacks);
            gl.PopMatrix();
            
        }
        private void DrawArrow_Z_2(double position)
        {
            int slices = 16;
            int stacks = 16;
            double radius = 0.5;
            double height = 1.5;
            gl.MatrixMode(OpenGL.MODELVIEW);
            gl.PushMatrix();
            gl.Translate(0, 0, position);
            gl.Rotate(180, 0, 1, 0);
            //绘制箭头（圆锥体）底面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < slices; i++)
            {
                gl.Vertex(radius * Math.Cos(Math.PI * 2 * i / slices), radius * Math.Sin(Math.PI * 2 * i / slices), 0);
            }
            gl.End();
            //底面绘制结束
            //开始绘制箭头（圆锥体）侧面
            IntPtr qobj = gl.NewQuadric();
            gl.Cylinder(qobj, radius, 0.0, height, slices, stacks);
            gl.PopMatrix();

        }
        /// <summary>
        /// 绘制坐标系的Y轴箭头
        /// </summary>
        /// <param name="position">箭头在Y轴上的位置</param>
        private void DrawArrow_Y(double position)
        {
            int slices = 16;
            int stacks = 16;
            double radius = 0.5;
            double height = 1.5;
            gl.MatrixMode(OpenGL.MODELVIEW);
            gl.PushMatrix();
            gl.Translate(position,0, 0);
            gl.Rotate(90,0,1 , 0);
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < slices; i++)
            {
                gl.Vertex(radius * Math.Cos(Math.PI * 2 * i / slices), radius * Math.Sin(Math.PI * 2 * i / slices), 0);
            }
            gl.End();
            IntPtr qobj = gl.NewQuadric();
            gl.Cylinder(qobj, radius, 0.0, height, slices, stacks);
            gl.PopMatrix();

        }
        /// <summary>
        /// 绘制坐标系的Z轴箭头
        /// </summary>
        /// <param name="position">箭头在Z轴上的位置</param>
        private void DrawArrow_Z(double position)
        {
            int slices = 16;
            int stacks = 16;
            double radius = 0.5;
            double height = 1.5;
            gl.MatrixMode(OpenGL.MODELVIEW);
            gl.PushMatrix();
            gl.Translate(0,position, 0 );
            gl.Rotate(-90, 1, 0, 0);
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < slices; i++)
            {
                gl.Vertex(radius * Math.Cos(Math.PI * 2 * i / slices), radius * Math.Sin(Math.PI * 2 * i / slices), 0);
            }
            gl.End();
            IntPtr qobj = gl.NewQuadric();
            gl.Cylinder(qobj, radius, 0.0, height, slices, stacks);
            gl.PopMatrix();

        }
        private void DrawArrow_X_2(double position)
        {
            int slices = 16;
            int stacks = 16;
            double radius = 0.5;
            double height = 1.5;
            gl.MatrixMode(OpenGL.MODELVIEW);
            gl.PushMatrix();
            gl.Translate(0, position, 0);
            gl.Rotate(-90, 1, 0, 0);
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < slices; i++)
            {
                gl.Vertex(radius * Math.Cos(Math.PI * 2 * i / slices), radius * Math.Sin(Math.PI * 2 * i / slices), 0);
            }
            gl.End();
            IntPtr qobj = gl.NewQuadric();
            gl.Cylinder(qobj, radius, 0.0, height, slices, stacks);
            gl.PopMatrix();

        }
        /// <summary>
        /// 绘制质心
        /// </summary>
        /// <param name="position_x">质心的x坐标</param>
        /// <param name="position_y">质心的y坐标</param>
        /// <param name="position_z">质心的z坐标</param>
        public void DrawMessCenter(double position_x, double position_y, double position_z)
        {
            gl.Color(0.0, 0.0, 1.0);
            gl.PointSize(8.0f);
            gl.Begin(OpenGL.POINTS);
            gl.Vertex(position_x, position_y, position_z);
            gl.End();
        }
        /// <summary>
        /// 显示英文字母
        /// </summary>
        /// <param name="str">待显示字符串</param>
        /// <param name="position_x">显示位置的x坐标</param>
        /// <param name="position_y">显示位置的y坐标</param>
        /// <param name="position_z">显示位置的z坐标</param>
        public void print_letters(string str, double position_x, double position_y, double position_z)
        {

            gl.RasterPos(position_x, position_y, position_z);
            for (int i = 0; i < str.Length; i++)
            {
                bool b = wglUseFontBitmaps(hdc, (uint)str[i], 1, lists);
                gl.CallList(lists);

            }
        }
        /// <summary>
        /// 显示汉字及其他特殊字符
        /// </summary>
        /// <param name="str">待显示字符串</param>
        /// <param name="position_x">显示位置的x坐标</param>
        /// <param name="position_y">显示位置的y坐标</param>
        /// <param name="position_z">显示位置的z坐标</param>
        public void print_CN(string str, double position_x, double position_y, double position_z)
        {
            gl.RasterPos(position_x, position_y, position_z);
            for (int i = 0; i < str.Length; i++)
            {
                bool b = wglUseFontBitmapsW(hdc, (uint)str[i], 1, lists);
                gl.CallList(lists);
            }
        }

        #region 绘制一个侧面

        /// <summary>
        /// 绘制一个侧面
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="baseHeight">基础高度</param>
        /// <param name="height">图形高度</param>
        private  void DrawOneSideSurface(Show2DPoint point1, Show2DPoint point2,double baseHeight, double height)
        {
            double x1 = point1.X;
            double y1 = point1.Y;
            double x2 = point2.X;
            double y2 = point2.Y;
            double topHeight = baseHeight + height;

            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.0f, 0.0f, 0.0f);
            //线框
            gl.Vertex(y1, baseHeight, x1);
            gl.Vertex(y2, baseHeight, x2);
            gl.Vertex(y2, topHeight, x2);
            gl.Vertex(y1, topHeight, x1);
            gl.End();
            //填充面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.5f, 0.5f, 0.5f);
            gl.Vertex(y1, baseHeight, x1);
            gl.Vertex(y2, baseHeight, x2);
            gl.Vertex(y2, topHeight, x2);
            gl.Vertex(y1, topHeight, x1);
            gl.End();
            gl.Flush();
        }
        
        /// <summary>
        /// 绘制一个侧面,仅保留线框，不填充图形
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="height"></param>
        private void DrawOneSideSurface_line(Show2DPoint point1, Show2DPoint point2, double height)
        {
            double x1 = point1.X;
            double y1 = point1.Y;
            double x2 = point2.X;
            double y2 = point2.Y;
         

            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.0f, 0.0f, 0.0f);
            //线框
            gl.Vertex(y1, 0, x1);
            gl.Vertex(y2, 0, x2);
            gl.Vertex(y2, height, x2);
            gl.Vertex(y1, height, x1);
            gl.End();
            gl.Flush();
        }
        /// <summary>
        /// 绘制一个侧面,仅保留线框，不填充图形
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="baseHeight"></param>
        /// <param name="height"></param>
        private void DrawOneSideSurface_line(Show2DPoint point1, Show2DPoint point2,double baseHeight, double height)
        {
            double x1 = point1.X;
            double y1 = point1.Y;
            double x2 = point2.X;
            double y2 = point2.Y;
            double topHeight = baseHeight + height;

            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.0f, 0.0f, 0.0f);
            //线
            gl.Vertex(y1, baseHeight, x1);
            gl.Vertex(y2, baseHeight, x2);
            gl.Vertex(y2, topHeight, x2);
            gl.Vertex(y1, topHeight, x1);
            gl.End();
            
            gl.Flush();
        }
        /// <summary>
        /// 绘制一个侧面,
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="height"></param>
        /// <param name="alpha"></param>
        private void DrawOneSideSurface(Show2DPoint point1, Show2DPoint point2, double height, float alpha)
        {
            double x1 = point1.X;
            double y1 = point1.Y;
            double x2 = point2.X;
            double y2 = point2.Y;
          
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.0f, 0.0f, 0.0f, alpha);
            //线
            gl.Vertex(y1, 0, x1);
            gl.Vertex(y2, 0, x2);
            gl.Vertex(y2, height, x2);
            gl.Vertex(y1, height, x1);
            gl.End();
            //面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.6f, 0.5f, 0.5f, alpha);
            gl.Vertex(y1, 0, x1);
            gl.Vertex(y2, 0, x2);
            gl.Vertex(y2, height, x2);
            gl.Vertex(y1, height, x1);
            gl.End();
            gl.Flush();
        }

        private void DrawOneSideSurface(Show2DPoint point1, Show2DPoint point2, double height,Int32 argb, float alpha)
        {
            Color color = Color.FromArgb(argb);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            double x1 = point1.X;
            double y1 = point1.Y;
            double x2 = point2.X;
            double y2 = point2.Y;


            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.0f, 0.0f, 0.0f, alpha);
            //线
            gl.Vertex(y1, 0, x1);
            gl.Vertex(y2, 0, x2);
            gl.Vertex(y2, height, x2);
            gl.Vertex(y1, height, x1);
            gl.End();
            //面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(r,g,b, alpha);
            gl.Vertex(y1, 0, x1);
            gl.Vertex(y2, 0, x2);
            gl.Vertex(y2, height, x2);
            gl.Vertex(y1, height, x1);
            gl.End();
            gl.Flush();
        }

        /// <summary>
        /// 绘制一个侧面
        /// </summary>
        /// <param name="point1">点1</param>
        /// <param name="point2">点2</param>
        /// <param name="baseHeight">基础高度</param>
        /// <param name="height">图形高度</param>
        /// <param name="argb">颜色值</param>
        /// <param name="alpha">混合因子</param>
        private void DrawOneSideSurface(Show2DPoint point1, Show2DPoint point2, double baseHeight, double height,Int32 argb, float alpha,bool selected,bool exchangeSelected)
        {
            Color color = Color.FromArgb(argb);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            double x1 = point1.X;
            double y1 = point1.Y;
            double x2 = point2.X;
            double y2 = point2.Y;
            double topHeight = baseHeight + height;
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);
            if (exchangeSelected == true)
            {
                gl.Color(1.0f, 0.0f, 0.0f, alpha);
                gl.LineWidth(2.0f);
            }
            else if (selected == true)
            {
                gl.LineWidth(8.0f);
                gl.Color(1.0f, 0.0f, 0.0f, alpha);
            }
            else gl.Color(0.0f, 0.0f, 0.0f, alpha);
            
            //线
            gl.Vertex(y1, baseHeight, x1);
            gl.Vertex(y2, baseHeight, x2);
            gl.Vertex(y2, topHeight, x2);
            gl.Vertex(y1, topHeight, x1);
            gl.End();
            //面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(r,g,b, alpha);
            gl.Vertex(y1, baseHeight, x1);
            gl.Vertex(y2, baseHeight, x2);
            gl.Vertex(y2, topHeight, x2);
            gl.Vertex(y1, topHeight, x1);
            gl.End();
            gl.Flush();
        }
        #endregion
        #region 绘制上下面
        /// <summary>
        /// 绘制上下面
      /// </summary>
      /// <param name="p_pointlist"></param>
      /// <param name="height"></param>
      /// <param name="alpha"></param>
        private void DrawUpDownSurface(Show2DPoint[] p_pointlist, double height, float alpha)
        {
            
            //线
            int count = p_pointlist.Length;
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.0f, 0.0f, 0.0f, alpha);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, 0, p_pointlist[i].X);
            gl.End();
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, height, p_pointlist[i].X);
            gl.End();
            //面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.6f, 0.5f, 0.4f, alpha);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, 0, p_pointlist[i].X);
            gl.End();
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, height, p_pointlist[i].X);
            gl.End();
            gl.Flush();

        }
        private void DrawUpDownSurface(Show2DPoint[] p_pointlist, double height,Int32 argb, float alpha)
        {
            Color color = Color.FromArgb(argb);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            //线
            int count = p_pointlist.Length;
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(0.0f, 0.0f, 0.0f, alpha);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, 0, p_pointlist[i].X);
            gl.End();
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, height, p_pointlist[i].X);
            gl.End();
            //面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(r, g, b, alpha);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, 0, p_pointlist[i].X);
            gl.End();
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, height, p_pointlist[i].X);
            gl.End();
            gl.Flush();

        }
        private void DrawUpDownSurface(Show2DPoint[] p_pointlist, double baseHeight, double height, Int32 argb, float alpha, bool selected, bool exchangeSelected)
        {
            Color color = Color.FromArgb(argb);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            double topHeight = baseHeight + height;
            //线
            int count = p_pointlist.Length;
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.POLYGON);

            if (exchangeSelected == true)
            {
                gl.Color(1.0f, 0.0f, 0.0f, alpha);
                gl.LineWidth(2.0f);
            }
            else if (selected == true)
            {
                gl.LineWidth(8.0f);
                gl.Color(1.0f, 0.0f, 0.0f, alpha);
            }
            else gl.Color(0.0f, 0.0f, 0.0f, alpha);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, baseHeight, p_pointlist[i].X);
            gl.End();
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, topHeight, p_pointlist[i].X);
            gl.End();
            //面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(r, g, b, alpha);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, baseHeight, p_pointlist[i].X);
            gl.End();
            gl.Begin(OpenGL.POLYGON);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_pointlist[i].Y, topHeight, p_pointlist[i].X);
            gl.End();
            gl.Flush();

        }
      
        #endregion
        #region 绘制完整货包图形
        /// <summary>
        /// 绘制完整货包图形
        /// </summary>
        /// <param name="p_pointlist"></param>
        public void DrawStorInterf_Comprehensive(ShowStorIfInfo p_storInfo,float alpha)
        {
            
            int count = p_storInfo.Pointlist.Length;
            for (int i = 0; i < count - 1; i++)
            {
                DrawOneSideSurface(p_storInfo.Pointlist[i], p_storInfo.Pointlist[i + 1], p_storInfo.Zri, p_storInfo.Height, p_storInfo.Argb, alpha, p_storInfo.Selected, p_storInfo.ExchangeSelected);
            }
            DrawOneSideSurface(p_storInfo.Pointlist[0], p_storInfo.Pointlist[count - 1], p_storInfo.Zri, p_storInfo.Height, p_storInfo.Argb, alpha, p_storInfo.Selected, p_storInfo.ExchangeSelected);
            DrawUpDownSurface(p_storInfo.Pointlist, p_storInfo.Zri, p_storInfo.Height, p_storInfo.Argb, alpha, p_storInfo.Selected, p_storInfo.ExchangeSelected);

        }
        /// <summary>
        /// 绘制货包图形
        /// </summary>
        /// <param name="p_storInfo"></param>
        /// <param name="alpha"></param>
        public  void DrawStorInterf(ShowStorIfInfo p_storInfo,float alpha)
        {

            int count = p_storInfo.Pointlist.Length;
            for (int i = 0; i < count - 1; i++)
            {
                DrawOneSideSurface(p_storInfo.Pointlist[i], p_storInfo.Pointlist[i + 1], p_storInfo.Height, alpha);
            }
            DrawOneSideSurface(p_storInfo.Pointlist[0], p_storInfo.Pointlist[count - 1], p_storInfo.Height, alpha);
            DrawUpDownSurface(p_storInfo.Pointlist, p_storInfo.Height, alpha);

        }
       
        public void DrawStorInterf_line(ShowStorIfInfo p_storInfo)
        {

            int count = p_storInfo.Pointlist.Length;
            for (int i = 0; i < count - 1; i++)
            {
                DrawOneSideSurface_line(p_storInfo.Pointlist[i], p_storInfo.Pointlist[i + 1], p_storInfo.Height);
            }
            DrawOneSideSurface_line(p_storInfo.Pointlist[0], p_storInfo.Pointlist[count - 1], p_storInfo.Height);
            //DrawUpDownSurface(p_storInfo.Pointlist, p_storInfo.Height);

        }

        public void DrawStorInterf_TopView(ShowStorIfInfo p_storInfo)
        {

            Color color = Color.FromArgb(p_storInfo.Argb);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            int count = p_storInfo.Pointlist.Length;
            //线
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Color(0.0f, 0.0f, 0.0f);
            gl.Begin(OpenGL.POLYGON);

            if (p_storInfo.ExchangeSelected == true)
            {
                gl.Color(1.0f, 0.0f, 0.0f);
                gl.LineWidth(2.0f);
            }
            for (int i = 0; i < count; i++)
                gl.Vertex(p_storInfo.Pointlist[i].Y, 0, p_storInfo.Pointlist[i].X);
            gl.End();

            //面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Begin(OpenGL.POLYGON);
            gl.Color(r, g, b);
            for (int i = 0; i < count; i++)
                gl.Vertex(p_storInfo.Pointlist[i].Y, 0, p_storInfo.Pointlist[i].X);
            gl.End();
            gl.Flush();

        }
        #endregion
        #region 绘制货物
        /// <summary>
        /// 绘制货物
        /// </summary>
        public void DrawCargo(double p_length, double p_width, double p_height,Int32 p_argb)
        {

            Color color = Color.FromArgb(p_argb);

            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Color(0.0f, 0.0f, 0.0f);

            #region 绘制棱线

            //底面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, 0, 0);
            gl.Vertex(p_width, 0, 0);
            gl.Vertex(p_width, 0, p_length);
            gl.Vertex(0, 0, p_length);
            gl.End();
            //右面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, 0, 0);
            gl.Vertex(p_width, 0, 0);
            gl.Vertex(p_width, p_height, 0);
            gl.Vertex(0, p_height, 0);
            gl.End();
            //后面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 0, p_length);
            gl.Vertex(0, p_height, p_length);
            gl.Vertex(0, p_height, 0);
            gl.End();
            //左面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, 0, p_length);
            gl.Vertex(p_width, 0, p_length);
            gl.Vertex(p_width, p_height, p_length);
            gl.Vertex(0, p_height, p_length);
            gl.End();
            //前面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(p_width, 0, p_length);
            gl.Vertex(p_width, 0, 0);
            gl.Vertex(p_width, p_height, 0);
            gl.Vertex(p_width, p_height, p_length);
            gl.End();
            //上面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, p_height, 0);
            gl.Vertex(p_width, p_height, 0);
            gl.Vertex(p_width, p_height, p_length);
            gl.Vertex(0, p_height, p_length);
            gl.End();
            #endregion
            #region 填充面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Color(r, g, b);
            //底面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, 0, 0);
            gl.Vertex(p_width, 0, 0);
            gl.Vertex(p_width, 0, p_length);
            gl.Vertex(0, 0, p_length);
            gl.End();
            //右面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, 0, 0);
            gl.Vertex(p_width, 0, 0);
            gl.Vertex(p_width, p_height, 0);
            gl.Vertex(0, p_height, 0);
            gl.End();
            //后面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 0, p_length);
            gl.Vertex(0, p_height, p_length);
            gl.Vertex(0, p_height, 0);
            gl.End();
            //左面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, 0, p_length);
            gl.Vertex(p_width, 0, p_length);
            gl.Vertex(p_width, p_height, p_length);
            gl.Vertex(0, p_height, p_length);
            gl.End();
            //前面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(p_width, 0, p_length);
            gl.Vertex(p_width, 0, 0);
            gl.Vertex(p_width, p_height, 0);
            gl.Vertex(p_width, p_height, p_length);
            gl.End();
            //上面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(0, p_height, 0);
            gl.Vertex(p_width, p_height, 0);
            gl.Vertex(p_width, p_height, p_length);
            gl.Vertex(0, p_height, p_length);
            gl.End();
            gl.Flush();
            #endregion

        }
       
        public void DrawCargo(double position_x, double position_y, double position_z, double length, double width, double height, Int32 p_argb)
        {
            
            Color color = Color.FromArgb(p_argb);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            double x = position_x + length;
            double y = position_y + width;
            double z = position_z + height;
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Color(0.0f, 0.0f, 0.0f);

            #region 绘制棱线
            //底面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(position_y, position_z, x);
            gl.End();
            //右面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //后面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(position_y, z, x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //左面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            //前面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(y, z, position_x);
            gl.End();
            //上面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            #endregion
            #region 填充面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Color(r, g, b);
            //底面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(position_y, position_z, x);
            gl.End();
            //右面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //后面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(position_y, z, x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //左面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            //前面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(y, z, position_x);
            gl.End();
            //上面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            gl.Flush();
            #endregion
        }
        public void DrawCargo(double position_x, double position_y, double position_z, double length, double width, double height, Int32 p_argb,float alpha)
        {

            Color color = Color.FromArgb(p_argb);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            double x = position_x + length;
            double y = position_y + width;
            double z = position_z + height;
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            gl.Color(0.0f, 0.0f, 0.0f);

            #region 绘制棱线
            //底面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(position_y, position_z, x);
            gl.End();
            //右面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //后面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(position_y, z, x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //左面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            //前面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(y, z, position_x);
            gl.End();
            //上面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            #endregion
            #region 填充面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Color(r, g, b);
            //底面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(position_y, position_z, x);
            gl.End();
            //右面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //后面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(position_y, z, x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //左面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            //前面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(y, z, position_x);
            gl.End();
            //上面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            gl.Flush();
            #endregion
        }
        public void DrawCargo(ShowCargoInfo p_cargoinfo)
        {
            double position_x = p_cargoinfo.Xri;
            double position_y = p_cargoinfo.Yri;
            double position_z = p_cargoinfo.Zri;
            double length = p_cargoinfo.Postlength;
            double width = p_cargoinfo.Postwidth;
            double height = p_cargoinfo.Postheight;

            Color color = Color.FromArgb(p_cargoinfo.Argb);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;
            double x = position_x + length;
            double y = position_y + width;
            double z = position_z + height;
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.LINE);
            gl.LineWidth(1.0f);
            if (p_cargoinfo.Thiscargo == true) gl.Color(1.0f, 0.0f, 0.0f);
            else gl.Color(0.0f, 0.0f, 0.0f);
            

            #region 绘制棱线
            //底面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(position_y, position_z, x);
            gl.End();
            //右面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //后面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(position_y, z, x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //左面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            //前面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(y, z, position_x);
            gl.End();
            //上面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            #endregion

            #region 填充面
            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);
            gl.Color(r, g, b);
            //底面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(position_y, position_z, x);
            gl.End();
            //右面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //后面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, position_x);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(position_y, z, x);
            gl.Vertex(position_y, z, position_x);
            gl.End();
            //左面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, position_z, x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            //前面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(y, position_z, position_x);
            gl.Vertex(y, position_z, x);
            gl.Vertex(y, z, x);
            gl.Vertex(y, z, position_x);
            gl.End();
            //上面
            gl.Begin(OpenGL.POLYGON);
            gl.Vertex(position_y, z, position_x);
            gl.Vertex(y, z, position_x);
            gl.Vertex(y, z, x);
            gl.Vertex(position_y, z, x);
            gl.End();
            gl.Flush();
            #endregion


        }
        #endregion
        #region 绘制存储单元
        /// <summary>
        /// 绘制存储单元,
        /// </summary>
        /// <param name="p_storunitinfo"></param>
        /// <param name="alpha"></param>
        public void DrawStorUnit_Line(ShowStorUnitInfo p_storunitinfo)
        {
            int count = p_storunitinfo.Pointlist1.Length;
            for (int i = 0; i < count - 1; i++)
            {
                DrawOneSideSurface_line(p_storunitinfo.Pointlist1[i], p_storunitinfo.Pointlist1[i + 1], p_storunitinfo.Height);
            }
            DrawOneSideSurface_line(p_storunitinfo.Pointlist1[0], p_storunitinfo.Pointlist1[count - 1], p_storunitinfo.Height);
        }
        public void DrawStorUnit(ShowStorUnitInfo p_storunitinfo,float alpha)
        {
            if (p_storunitinfo.Num >= 1 && p_storunitinfo.Pointlist1!=null)
            {
                int count1 = p_storunitinfo.Pointlist1.Length;
                for (int i = 0; i < count1 - 1; i++)
                {
                    DrawOneSideSurface(p_storunitinfo.Pointlist1[i], p_storunitinfo.Pointlist1[i + 1], p_storunitinfo.Height,p_storunitinfo.Argb, alpha);
                }
                DrawOneSideSurface(p_storunitinfo.Pointlist1[0], p_storunitinfo.Pointlist1[count1 - 1], p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                DrawUpDownSurface(p_storunitinfo.Pointlist1, p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                if (p_storunitinfo.Num >= 2 && p_storunitinfo.Pointlist2 != null)
                {
                    int count2 = p_storunitinfo.Pointlist2.Length;
                    for (int i = 0; i < count2 - 1; i++)
                    {
                        DrawOneSideSurface(p_storunitinfo.Pointlist2[i], p_storunitinfo.Pointlist2[i + 1], p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                    }
                    DrawOneSideSurface(p_storunitinfo.Pointlist2[0], p_storunitinfo.Pointlist2[count2 - 1], p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                    DrawUpDownSurface(p_storunitinfo.Pointlist2, p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                }
                if (p_storunitinfo.Num >= 3 && p_storunitinfo.Pointlist3 != null)
                {
                    int count3 = p_storunitinfo.Pointlist3.Length;
                    for (int i = 0; i < count3 - 1; i++)
                    {
                        DrawOneSideSurface(p_storunitinfo.Pointlist3[i], p_storunitinfo.Pointlist3[i + 1], p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                    }
                    DrawOneSideSurface(p_storunitinfo.Pointlist3[0], p_storunitinfo.Pointlist3[count3 - 1], p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                    DrawUpDownSurface(p_storunitinfo.Pointlist3, p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                    if (p_storunitinfo.Num >= 4 && p_storunitinfo.Pointlist4 != null)
                    {
                        int count4 = p_storunitinfo.Pointlist4.Length;
                        for (int i = 0; i < count4 - 1; i++)
                        {
                            DrawOneSideSurface(p_storunitinfo.Pointlist4[i], p_storunitinfo.Pointlist4[i + 1], p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                        }
                        DrawOneSideSurface(p_storunitinfo.Pointlist4[0], p_storunitinfo.Pointlist4[count4 - 1], p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                        DrawUpDownSurface(p_storunitinfo.Pointlist4, p_storunitinfo.Height, p_storunitinfo.Argb, alpha);
                    }
                }

            }

        }
        /// <summary>
        ///  绘制存储单元,相对高度可设
        /// </summary>
        /// <param name="p_storunitinfo"></param>
        /// <param name="baseHeight"></param>
        /// <param name="alpha"></param>
        public void DrawStorUnit(ShowStorUnitInfo p_storunitinfo,double baseHeight,Int32 argb, float alpha)
        {
 
            if (p_storunitinfo.Num >= 1 && p_storunitinfo.Pointlist1 != null)
            {
                int count1 = p_storunitinfo.Pointlist1.Length;
                for (int  i = 0; i < count1 - 1; i++)
                {
                    DrawOneSideSurface(p_storunitinfo.Pointlist1[i], p_storunitinfo.Pointlist1[i + 1], baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected,false);
                }
                DrawOneSideSurface(p_storunitinfo.Pointlist1[0], p_storunitinfo.Pointlist1[count1 - 1], baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                DrawUpDownSurface(p_storunitinfo.Pointlist1, baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                if (p_storunitinfo.Num >= 2 && p_storunitinfo.Pointlist2 != null)
                {
                    int count2 = p_storunitinfo.Pointlist2.Length;
                    for (int i = 0; i < count2 - 1; i++)
                    {
                        DrawOneSideSurface(p_storunitinfo.Pointlist2[i], p_storunitinfo.Pointlist2[i + 1], baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                    }
                    DrawOneSideSurface(p_storunitinfo.Pointlist2[0], p_storunitinfo.Pointlist2[count2 - 1], baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                    DrawUpDownSurface(p_storunitinfo.Pointlist2, baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                }
                if (p_storunitinfo.Num >= 3 && p_storunitinfo.Pointlist3 != null)
                {
                    int count3 = p_storunitinfo.Pointlist3.Length;
                    for (int i = 0; i < count3 - 1; i++)
                    {
                        DrawOneSideSurface(p_storunitinfo.Pointlist3[i], p_storunitinfo.Pointlist3[i + 1], baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                    }
                    DrawOneSideSurface(p_storunitinfo.Pointlist3[0], p_storunitinfo.Pointlist3[count3 - 1], baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                    DrawUpDownSurface(p_storunitinfo.Pointlist3, baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                    if (p_storunitinfo.Num >= 4 && p_storunitinfo.Pointlist4 != null)
                    {
                        int count4 = p_storunitinfo.Pointlist4.Length;
                        for (int i = 0; i < count4 - 1; i++)
                        {
                            DrawOneSideSurface(p_storunitinfo.Pointlist4[i], p_storunitinfo.Pointlist4[i + 1], baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                        }
                        DrawOneSideSurface(p_storunitinfo.Pointlist4[0], p_storunitinfo.Pointlist4[count4 - 1], baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                        DrawUpDownSurface(p_storunitinfo.Pointlist4, baseHeight, p_storunitinfo.Height, argb, alpha, p_storunitinfo.Selected, false);
                    }
                }

            }

        }
        public void DrawStorUnit_Line(ShowStorUnitInfo p_storunitinfo, double baseHeight)
        {

            if (p_storunitinfo.Num >= 1 && p_storunitinfo.Pointlist1 != null)
            {
                int count1 = p_storunitinfo.Pointlist1.Length;
                for (int i = 0; i < count1 - 1; i++)
                {
                    DrawOneSideSurface_line(p_storunitinfo.Pointlist1[i], p_storunitinfo.Pointlist1[i + 1], baseHeight, p_storunitinfo.Height);
                }
                DrawOneSideSurface_line(p_storunitinfo.Pointlist1[0], p_storunitinfo.Pointlist1[count1 - 1], baseHeight, p_storunitinfo.Height);
           
                if (p_storunitinfo.Num >= 2 && p_storunitinfo.Pointlist2 != null)
                {
                    int count2 = p_storunitinfo.Pointlist2.Length;
                    for (int i = 0; i < count2 - 1; i++)
                    {
                        DrawOneSideSurface_line(p_storunitinfo.Pointlist2[i], p_storunitinfo.Pointlist2[i + 1], baseHeight, p_storunitinfo.Height);
                    }
                    DrawOneSideSurface_line(p_storunitinfo.Pointlist2[0], p_storunitinfo.Pointlist2[count2 - 1], baseHeight, p_storunitinfo.Height);
                }
                if (p_storunitinfo.Num >= 3 && p_storunitinfo.Pointlist3 != null)
                {
                    int count3 = p_storunitinfo.Pointlist3.Length;
                    for (int i = 0; i < count3 - 1; i++)
                    {
                        DrawOneSideSurface_line(p_storunitinfo.Pointlist3[i], p_storunitinfo.Pointlist3[i + 1], baseHeight, p_storunitinfo.Height);
                    }
                    DrawOneSideSurface_line(p_storunitinfo.Pointlist3[0], p_storunitinfo.Pointlist3[count3 - 1], baseHeight, p_storunitinfo.Height);
                    if (p_storunitinfo.Num >= 4 && p_storunitinfo.Pointlist4 != null)
                    {
                        int count4 = p_storunitinfo.Pointlist4.Length;
                        for (int i = 0; i < count4 - 1; i++)
                        {
                            DrawOneSideSurface_line(p_storunitinfo.Pointlist4[i], p_storunitinfo.Pointlist4[i + 1], baseHeight, p_storunitinfo.Height);
                        }
                        DrawOneSideSurface_line(p_storunitinfo.Pointlist4[0], p_storunitinfo.Pointlist4[count4 - 1], baseHeight, p_storunitinfo.Height);
                    }
                }

            }

        }
        #endregion
        #region 绘制ChinaHV
        /// <summary>
        /// 绘制ChinaHV
        /// </summary>
        /// <param name="p_storunitinfo"></param>
        /// <param name="alpha">混合因子</param>
        public void DrawTransVehicle(ShowStorUnitInfo[] p_storunitinfo,float alpha)
        {
            for (int i = 0; i < p_storunitinfo.Length; i++)
            {
 
                DrawStorUnit(p_storunitinfo[i],p_storunitinfo[i].Zri,p_storunitinfo[i].Argb, alpha);
                
            }
        }
        public void DrawTransVehicle_line(ShowStorUnitInfo[] p_storunitinfo)
        {
            for (int i = 0; i < p_storunitinfo.Length; i++)
            {

                DrawStorUnit_Line(p_storunitinfo[i], p_storunitinfo[i].Zri);

            }
        }
        #endregion
        /// <summary>
        /// 从被击中的对象中筛选离观察者最近的一个
        /// </summary>
        /// <param name="p_hit"></param>
        /// <param name="p_selectBuffer"></param>
        /// <returns></returns>
        public uint znearSelected(int p_hit, uint[] p_selectBuffer)
        {
            uint temp = p_selectBuffer[1];
            uint nearest = p_selectBuffer[3];
            for (int i = 0; i < p_hit; i++)
            {
                if (p_selectBuffer[4 * i + 1] < temp)
                {
                    temp = p_selectBuffer[4 * i + 1];
                    nearest = p_selectBuffer[4 * i + 3];
                }

            }
            return nearest;
        }
    }
    /// <summary>
    /// 显示货物所需信息
    /// </summary>
    public class ShowCargoInfo
    {
        private bool thiscargo = false;

        public bool Thiscargo
        {
            get { return thiscargo; }
            set { thiscargo = value; }
        }
        private int colid;

        public int Colid
        {
            get { return colid; }
            set { colid = value; }
        }
        private double xri;

        public double Xri
        {
            get { return xri; }
            set { xri = value; }
        }
        private double yri;

        public double Yri
        {
            get { return yri; }
            set { yri = value; }
        }
        private double zri;

        public double Zri
        {
            get { return zri; }
            set { zri = value; }
        }
        private double xanglei;

        public double Xanglei
        {
            get { return xanglei; }
            set { xanglei = value; }
        }
        private double yanglei;

        public double Yanglei
        {
            get { return yanglei; }
            set { yanglei = value; }
        }
        private double zanglei;

        public double Zanglei
        {
            get { return zanglei; }
            set { zanglei = value; }
        }
        private double postlength;

        public double Postlength
        {
            get { return postlength; }
            set { postlength = value; }
        }
        private double postwidth;

        public double Postwidth
        {
            get { return postwidth; }
            set { postwidth = value; }
        }
        private double postheight;

        public double Postheight
        {
            get { return postheight; }
            set { postheight = value; }
        }
        private double density;

        public double Density
        {
            get { return density; }
            set { density = value; }
        }

        private Int32 argb;

        public Int32 Argb
        {
            get { return argb; }
            set { argb = value; }
        }
    }
    /// <summary>
    /// 绘制货包所需信息
    /// </summary>
    public class ShowStorIfInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private bool selected = false;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        private bool exchangeSelected = false;

        public bool ExchangeSelected
        {
            get { return exchangeSelected; }
            set { exchangeSelected = value; }
        }
        private string storifno;

        public string Storifno
        {
            get { return storifno; }
            set { storifno = value; }
        }
        private string storunitid;

        public string Storunitid
        {
            get { return storunitid; }
            set { storunitid = value; }
        }
        private int step;

        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        private double height ;
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        private double xri;

        public double Xri
        {
            get { return xri; }
            set { xri = value; }
        }
        private double yri;

        public double Yri
        {
            get { return yri; }
            set { yri = value; }
        }
        private double zri;

        public double Zri
        {
            get { return zri; }
            set { zri = value; }
        }
        private double xanglei;

        public double Xanglei
        {
            get { return xanglei; }
            set { xanglei = value; }
        }
        private double yanglei;

        public double Yanglei
        {
            get { return yanglei; }
            set { yanglei = value; }
        }
        private double zanglei;

        public double Zanglei
        {
            get { return zanglei; }
            set { zanglei = value; }
        }

        private Show2DPoint[] pointlist = null;

        public Show2DPoint[] Pointlist
        {
            get { return pointlist; }
            set { pointlist = value; }
        }
        Int32 argb;

        public Int32 Argb
        {
            get { return argb; }
            set { argb = value; }
        }
    }
    /// <summary>
    /// 绘制存储单元所需信息
    /// </summary>
    public class ShowStorUnitInfo
    {
        private int locked;

        public int Locked
        {
            get { return locked; }
            set { locked = value; }
        }
        private bool selected=false;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        private string storUnitNo;

        public string StorUnitNo
        {
            get { return storUnitNo; }
            set { storUnitNo = value; }
        }
        private string storunitid;

        public string Storunitid
        {
            get { return storunitid; }
            set { storunitid = value; }
        }

        private int num ;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        private double height ;
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        private double xri;

        public double Xri
        {
            get { return xri; }
            set { xri = value; }
        }
        private double yri;

        public double Yri
        {
            get { return yri; }
            set { yri = value; }
        }
        private double zri;

        public double Zri
        {
            get { return zri; }
            set { zri = value; }
        }

        private double xAnglei;

        public double XAnglei
        {
            get { return xAnglei; }
            set { xAnglei = value; }
        }


        private double yAnglei;

        public double YAnglei
        {
            get { return yAnglei; }
            set { yAnglei = value; }
        }


        private double zAnglei;

        public double ZAnglei
        {
            get { return zAnglei; }
            set { zAnglei = value; }
        }

    
        private int quadrantNo;

        public int QuadrantNo
        {
            get { return quadrantNo; }
            set { quadrantNo = value; }
        }
        private int storUnitType;

        public int StorUnitType
        {
            get { return storUnitType; }
            set { storUnitType = value; }
        }
        private int floorNo;

        public int FloorNo
        {
            get { return floorNo; }
            set { floorNo = value; }
        }
        private Show2DPoint[] pointlist1 = null;

        public Show2DPoint[] Pointlist1
        {
            get { return pointlist1; }
            set { pointlist1 = value; }
        }
        private Show2DPoint[] pointlist2 = null;

        public Show2DPoint[] Pointlist2
        {
            get { return pointlist2; }
            set { pointlist2 = value; }
        }
        private Show2DPoint[] pointlist3 = null;

        public Show2DPoint[] Pointlist3
        {
            get { return pointlist3; }
            set { pointlist3 = value; }
        }
        private Show2DPoint[] pointlist4 = null;

        public Show2DPoint[] Pointlist4
        {
            get { return pointlist4; }
            set { pointlist4 = value; }
        }

        Int32 argb ;

        public Int32 Argb
        {
          get { return argb; }
          set { argb = value; }
        }
        private string boxID;

        public string BoxID
        {
            get { return boxID; }
            set { boxID = value; }
        }

    }
    /// <summary>
    /// 相对坐标系参数
    /// </summary>
    public class RalativeLocation
    {
        private double xri;

        public double Xri
        {
            get { return xri; }
            set { xri = value; }
        }

        private double yri;

        public double Yri
        {
            get { return yri; }
            set { yri = value; }
        }

        private double zri;

        public double Zri
        {
            get { return zri; }
            set { zri = value; }
        }

        private double xanglei;

        public double Xanglei
        {
            get { return xanglei; }
            set { xanglei = value; }
        }

        private double yanglei;

        public double Yanglei
        {
            get { return yanglei; }
            set { yanglei = value; }
        }

        private double zanglei;

        public double Zanglei
        {
            get { return zanglei; }
            set { zanglei = value; }
        }
    }
    /// <summary>
    /// 三维坐标点
    /// </summary>
    public class Point3D
    {
        private double _x;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        private double _y;

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private double _z;

        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public Point3D()
        {
            _x = 0.0;
            _y = 0.0;
            _z = 0.0;
        }
    }
    /// <summary>
    /// 坐标系变换
    /// </summary>
    public class CoordinateTransform
    {
        /// <summary>
        /// 右手法则
        /// </summary>
        /// <param name="p_rflocation"></param>
        /// <param name="p_oldpoint"></param>
        /// <returns></returns>
        private static Point3D GetPointNewValue(RalativeLocation p_rflocation, Point3D p_oldpoint)
        {
            return GetPointNewValueForRight(p_rflocation, p_oldpoint);
        }

        //右手法则变换
        private static Point3D GetPointNewValueForRight(RalativeLocation p_rflocation, Point3D p_oldpoint)
        {
            
            Point3D m_newpoint = new Point3D();
            m_newpoint.X =( Math.Cos(p_rflocation.Yanglei) * Math.Cos(p_rflocation.Zanglei) - Math.Sin(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Yanglei) *Math.Sin(p_rflocation.Zanglei))* p_oldpoint.X +
                 ((-1.0) * Math.Cos(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Zanglei)) * p_oldpoint.Y +
                ( Math.Sin(p_rflocation.Yanglei) * Math.Cos(p_rflocation.Zanglei)  + Math.Sin(p_rflocation.Xanglei)* Math.Cos(p_rflocation.Yanglei) * Math.Sin(p_rflocation.Zanglei))* p_oldpoint.Z +
                p_rflocation.Xri;

            m_newpoint.Y = (Math.Cos(p_rflocation.Yanglei) * Math.Sin(p_rflocation.Zanglei) + Math.Sin(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Yanglei) * Math.Cos(p_rflocation.Zanglei)) * p_oldpoint.X +
                Math.Cos(p_rflocation.Xanglei) * Math.Cos(p_rflocation.Zanglei) * p_oldpoint.Y +
                ( Math.Sin(p_rflocation.Yanglei) * Math.Sin(p_rflocation.Zanglei) - Math.Sin(p_rflocation.Xanglei) * Math.Cos(p_rflocation.Yanglei) * Math.Cos(p_rflocation.Zanglei)) * p_oldpoint.Z +
                p_rflocation.Yri;

            m_newpoint.Z = ((-1.0)*Math.Cos(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Yanglei)) * p_oldpoint.X +
                Math.Sin(p_rflocation.Xanglei) * p_oldpoint.Y +
                (Math.Cos(p_rflocation.Xanglei) * Math.Cos(p_rflocation.Yanglei)) * p_oldpoint.Z +
                p_rflocation.Zri;

            return m_newpoint;
        }
        
        //左手法则变换
        private static Point3D GetPointNewValueForLeft(RalativeLocation p_rflocation, Point3D p_oldpoint)
        {
            Point3D m_newpoint = new Point3D();
            m_newpoint.X = Math.Cos(p_rflocation.Yanglei) * Math.Cos(p_rflocation.Zanglei) * p_oldpoint.X +
                (-1.0) * Math.Cos(p_rflocation.Yanglei) * Math.Sin(p_rflocation.Zanglei) * p_oldpoint.Y +
                Math.Sin(p_rflocation.Yanglei) * p_oldpoint.Z +
                p_rflocation.Xri;

            m_newpoint.Y = (Math.Sin(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Yanglei) * Math.Cos(p_rflocation.Zanglei) + Math.Cos(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Zanglei)) * p_oldpoint.X +
                ((-1.0) * Math.Sin(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Yanglei) * Math.Sin(p_rflocation.Zanglei) + Math.Cos(p_rflocation.Xanglei) * Math.Cos(p_rflocation.Zanglei)) * p_oldpoint.Y +
                (-1.0) * Math.Sin(p_rflocation.Xanglei) * Math.Cos(p_rflocation.Yanglei) * p_oldpoint.Z +
                p_rflocation.Yri;

            m_newpoint.Z = ((-1.0) * Math.Cos(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Yanglei) * Math.Cos(p_rflocation.Zanglei) + Math.Sin(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Zanglei)) * p_oldpoint.X +
                ((-1.0) * Math.Cos(p_rflocation.Xanglei) * Math.Sin(p_rflocation.Yanglei) * Math.Sin(p_rflocation.Zanglei) + Math.Sin(p_rflocation.Xanglei) * Math.Cos(p_rflocation.Zanglei)) * p_oldpoint.Y +
                Math.Cos(p_rflocation.Xanglei) * Math.Cos(p_rflocation.Yanglei) * p_oldpoint.Z +
                p_rflocation.Zri;
            return m_newpoint;
        }


        public static ShowStorUnitInfo[] StorunitToTransvehicle(ShowStorUnitInfo[] p_storunitinfo)
        {
            
            for (int i = 0; i < p_storunitinfo.Length; i++)
            {
                RalativeLocation ralative = new RalativeLocation();
                ralative.Xri = p_storunitinfo[i].Xri;
                ralative.Yri = p_storunitinfo[i].Yri;
                ralative.Zri = p_storunitinfo[i].Zri;
                ralative.Xanglei = p_storunitinfo[i].XAnglei;
                ralative.Yanglei = p_storunitinfo[i].YAnglei;
                ralative.Zanglei = p_storunitinfo[i].ZAnglei;
                
                Point3D point3d = new Point3D();
                if (p_storunitinfo[i].Num >= 1 && p_storunitinfo[i].Pointlist1 != null)
                {
                    for (int j = 0; j < p_storunitinfo[i].Pointlist1.Length; j++)
                    {
                        point3d.X = p_storunitinfo[i].Pointlist1[j].X;
                        point3d.Y = p_storunitinfo[i].Pointlist1[j].Y;
                        point3d.Z = 0;

                        point3d = GetPointNewValue(ralative, point3d);
                        p_storunitinfo[i].Pointlist1[j].X = point3d.X;
                        p_storunitinfo[i].Pointlist1[j].Y = point3d.Y;

                    }
                    if (p_storunitinfo[i].Num >= 2 && p_storunitinfo[i].Pointlist2 != null)
                    {
                        for (int j = 0; j < p_storunitinfo[i].Pointlist2.Length; j++)
                        {
                            point3d.X = p_storunitinfo[i].Pointlist2[j].X;
                            point3d.Y = p_storunitinfo[i].Pointlist2[j].Y;
                            point3d.Z = 0;
                            point3d = GetPointNewValue(ralative, point3d);
                            p_storunitinfo[i].Pointlist2[j].X = point3d.X;
                            p_storunitinfo[i].Pointlist2[j].Y = point3d.Y;

                        }
                        if (p_storunitinfo[i].Num >= 3 && p_storunitinfo[i].Pointlist3 != null)
                        {
                            for (int j = 0; j < p_storunitinfo[i].Pointlist3.Length; j++)
                            {
                                point3d.X = p_storunitinfo[i].Pointlist3[j].X;
                                point3d.Y = p_storunitinfo[i].Pointlist3[j].Y;
                                point3d.Z = 0;
                                point3d = GetPointNewValue(ralative, point3d);
                                p_storunitinfo[i].Pointlist3[j].X = point3d.X;
                                p_storunitinfo[i].Pointlist3[j].Y = point3d.Y;

                            }
                            if (p_storunitinfo[i].Num >= 4 && p_storunitinfo[i].Pointlist4 != null)
                            {
                                for (int j = 0; j < p_storunitinfo[i].Pointlist4.Length; j++)
                                {
                                    point3d.X = p_storunitinfo[i].Pointlist4[j].X;
                                    point3d.Y = p_storunitinfo[i].Pointlist4[j].Y;
                                    point3d.Z = 0;
                                    point3d = GetPointNewValue(ralative, point3d);
                                    p_storunitinfo[i].Pointlist4[j].X = point3d.X;
                                    p_storunitinfo[i].Pointlist4[j].Y = point3d.Y;

                                }
                            }
                        }
                    }
                }

            }
            return p_storunitinfo;
        }


        public static ShowStorUnitInfo[] Transvehicle_2D(ShowStorUnitInfo[] p_storunitinfo)
        {
            double pi = 3.1415926;
            for (int i = 0; i < p_storunitinfo.Length; i++)
            {
                RalativeLocation ralative = new RalativeLocation();

                switch (p_storunitinfo[i].QuadrantNo)
                {
                    case 1:
                        ralative.Xri = 6;
                        ralative.Yri = 0;
                        ralative.Zri = 0;
                        ralative.Xanglei = 0;
                        ralative.Yanglei = 0;
                        ralative.Zanglei = 0;
                        break;
                    case 2:
                        ralative.Xri = 19;
                        ralative.Yri = 0;
                        ralative.Zri = 0;
                        ralative.Xanglei = 0;
                        ralative.Yanglei = 0;
                        ralative.Zanglei = -pi/2;
                        break;
                    case 3:
                        ralative.Xri = -20;
                        ralative.Yri = 0;
                        ralative.Zri = 0;
                        ralative.Xanglei = 0;
                        ralative.Yanglei = 0;
                        ralative.Zanglei = pi;
                        break;
                    case 4:
                        ralative.Xri = -7;
                        ralative.Yri = 0;
                        ralative.Zri = 0;
                        ralative.Xanglei = 0;
                        ralative.Yanglei = 0;
                        ralative.Zanglei = pi/2;
                        break;
                }
 

                Point3D point3d = new Point3D();
                if (p_storunitinfo[i].Num >= 1 && p_storunitinfo[i].Pointlist1 != null)
                {
                    for (int j = 0; j < p_storunitinfo[i].Pointlist1.Length; j++)
                    {
                        point3d.X = p_storunitinfo[i].Pointlist1[j].X;
                        point3d.Y = p_storunitinfo[i].Pointlist1[j].Y;
                        point3d.Z = 0;
                        point3d = GetPointNewValue(ralative, point3d);
                        p_storunitinfo[i].Pointlist1[j].X = point3d.X;
                        p_storunitinfo[i].Pointlist1[j].Y = point3d.Y;

                    }
                    if (p_storunitinfo[i].Num >= 2 && p_storunitinfo[i].Pointlist2 != null)
                    {
                        for (int j = 0; j < p_storunitinfo[i].Pointlist2.Length; j++)
                        {
                            point3d.X = p_storunitinfo[i].Pointlist2[j].X;
                            point3d.Y = p_storunitinfo[i].Pointlist2[j].Y;
                            point3d.Z = 0;
                            point3d = GetPointNewValue(ralative, point3d);
                            p_storunitinfo[i].Pointlist2[j].X = point3d.X;
                            p_storunitinfo[i].Pointlist2[j].Y = point3d.Y;

                        }
                        if (p_storunitinfo[i].Num >= 3 && p_storunitinfo[i].Pointlist3 != null)
                        {
                            for (int j = 0; j < p_storunitinfo[i].Pointlist3.Length; j++)
                            {
                                point3d.X = p_storunitinfo[i].Pointlist3[j].X;
                                point3d.Y = p_storunitinfo[i].Pointlist3[j].Y;
                                point3d.Z = 0;
                                point3d = GetPointNewValue(ralative, point3d);
                                p_storunitinfo[i].Pointlist3[j].X = point3d.X;
                                p_storunitinfo[i].Pointlist3[j].Y = point3d.Y;

                            }
                            if (p_storunitinfo[i].Num >= 4 && p_storunitinfo[i].Pointlist4 != null)
                            {
                                for (int j = 0; j < p_storunitinfo[i].Pointlist4.Length; j++)
                                {
                                    point3d.X = p_storunitinfo[i].Pointlist4[j].X;
                                    point3d.Y = p_storunitinfo[i].Pointlist4[j].Y;
                                    point3d.Z = 0;
                                    point3d = GetPointNewValue(ralative, point3d);
                                    p_storunitinfo[i].Pointlist4[j].X = point3d.X;
                                    p_storunitinfo[i].Pointlist4[j].Y = point3d.Y;

                                }
                            }
                        }
                    }
                }

            }
            return p_storunitinfo;
        }

        public static ShowStorIfInfo StorIfToStorUnit(ShowStorIfInfo p_storifinfo)
        {
            RalativeLocation ralative = new RalativeLocation();
            ralative.Xri = p_storifinfo.Xri;
            ralative.Yri = p_storifinfo.Yri;
            ralative.Zri = p_storifinfo.Zri;
            ralative.Xanglei = p_storifinfo.Xanglei;
            ralative.Yanglei = p_storifinfo.Yanglei;
            ralative.Zanglei = p_storifinfo.Zanglei;
            Point3D point3d = new Point3D();
            for (int i = 0; i < p_storifinfo.Pointlist.Length; i++)
            {
                point3d.X = p_storifinfo.Pointlist[i].X;
                point3d.Y = p_storifinfo.Pointlist[i].Y;
                point3d.Z = 0;
                point3d = GetPointNewValue(ralative, point3d);
                p_storifinfo.Pointlist[i].X = point3d.X;
                p_storifinfo.Pointlist[i].Y = point3d.Y;

            }
            return p_storifinfo;
        }

        public static ShowStorIfInfo StorIf_StorUnit_TransVehicle(ShowStorIfInfo p_storifinfo, ShowStorUnitInfo p_storunitinfo)
        {
            p_storifinfo = StorIfToStorUnit(p_storifinfo);
            RalativeLocation ralative = new RalativeLocation();
            ralative.Xri = p_storunitinfo.Xri;
            ralative.Yri = p_storunitinfo.Yri;
            ralative.Zri = p_storunitinfo.Zri;
            ralative.Xanglei = p_storunitinfo.XAnglei;
            ralative.Yanglei = p_storunitinfo.YAnglei;
            ralative.Zanglei = p_storunitinfo.ZAnglei;
            Point3D point3d = new Point3D();
            for (int i = 0; i < p_storifinfo.Pointlist.Length; i++)
            {
                point3d.X = p_storifinfo.Pointlist[i].X;
                point3d.Y = p_storifinfo.Pointlist[i].Y;
                point3d.Z = 0;
                point3d = GetPointNewValue(ralative, point3d);
                p_storifinfo.Pointlist[i].X = point3d.X;
                p_storifinfo.Pointlist[i].Y = point3d.Y;

            }
            return p_storifinfo;
        }
    }
}
