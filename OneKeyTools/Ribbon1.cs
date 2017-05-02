﻿using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;

namespace OneKeyTools
{
    public partial class Ribbon1
    {
        private PowerPoint.Application app;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            app = Globals.ThisAddIn.Application;
            if (Properties.Settings.Default.g1 == 0)
            {
                group2.Visible = false;
            }
            else
            {
                group2.Visible = true;
            }
            if (Properties.Settings.Default.g2 == 0)
            {
                group3.Visible = false;
            }
            else
            {
                group3.Visible = true;
            }
            if (Properties.Settings.Default.g3 == 0)
            {
                group4.Visible = false;
            }
            else
            {
                group4.Visible = true;
            }
            if (Properties.Settings.Default.g4 == 0)
            {
                group1.Visible = false;
            }
            else
            {
                group1.Visible = true;
            }
            if (Properties.Settings.Default.g5 == 0)
            {
                group7.Visible = false;
            }
            else
            {
                group7.Visible = true;
            }
            if (Properties.Settings.Default.g6 == 0)
            {
                group6.Visible = false;
            }
            else
            {
                group6.Visible = true;
            }
            if (Properties.Settings.Default.g7 == 0)
            {
                group8.Visible = false;
            }
            else
            {
                group8.Visible = true;
            }
            if (Properties.Settings.Default.morph == 0)
            {
                menu26.Visible = false;
            }
            else
            {
                menu26.Visible = true;
            }
            if (Properties.Settings.Default.Replace == 0)
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
            if (Properties.Settings.Default.tab1 == 0)
            {
                Globals.Ribbons.Ribbon1.tab1.Visible = false;
                Globals.Ribbons.Ribbon1.button247.Label = "显示主卡";
            }
            else
            {
                Globals.Ribbons.Ribbon1.tab1.Visible = true;
                Globals.Ribbons.Ribbon1.button247.Label = "隐藏主卡";
            }
            if (Properties.Settings.Default.tab2 == 0)
            {
                Globals.Ribbons.Ribbon1.tab2.Visible = false;
            }
            else
            {
                Globals.Ribbons.Ribbon1.tab2.Visible = true;
            }
        }

        public void button1_Click(object sender, RibbonControlEventArgs e)
        {
            OK_About OK_About = null;
            if (OK_About == null || OK_About.IsDisposed)
            {
                OK_About = new OK_About();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                OK_About.Show();
            }
        }

        public void splitButton3_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                string[] name = new string[range.Count];
                for (int i = 1; i <= range.Count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    PowerPoint.Shape nshape = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, shape.Left, shape.Top, shape.Width, shape.Height);
                    if (nshape.Line.Visible == Office.MsoTriState.msoTrue)
                    {
                        nshape.Line.Visible = Office.MsoTriState.msoFalse;
                    }
                    nshape.Line.Weight = 0;
                    nshape.Rotation = shape.Rotation;
                    name[i - 1] = nshape.Name;
                }
                slide.Shapes.Range(name).Select();
            }
            else
            {
                PowerPoint.SlideRange srange = sel.SlideRange;
                if (sel.SlideRange.Count == 1)
                {
                    PowerPoint.Shape shape = sel.SlideRange[1].Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, -100, 0, 100, 100);
                    if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                    {
                        shape.Line.Visible = Office.MsoTriState.msoFalse;
                    }
                    shape.Line.Weight = 0;
                    shape.Select();
                }
                else
                {
                    foreach (PowerPoint.Slide item in srange)
                    {
                        PowerPoint.Shape shape = item.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, -100, 0, 100, 100);
                        if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                        {
                            shape.Line.Visible = Office.MsoTriState.msoFalse;
                        }
                        shape.Line.Weight = 0;
                    }
                }
            }
        }

        public void button8_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                float w = app.ActivePresentation.PageSetup.SlideWidth;
                float h = app.ActivePresentation.PageSetup.SlideHeight;
                PowerPoint.Shape shape = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 0, 0, w, h);
                if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                {
                    shape.Line.Visible = Office.MsoTriState.msoFalse;
                }
                shape.Line.Weight = 0;
                shape.Select();
            }
            else
            {
                PowerPoint.SlideRange srange = sel.SlideRange;
                float w = app.ActivePresentation.PageSetup.SlideWidth;
                float h = app.ActivePresentation.PageSetup.SlideHeight;
                if (sel.SlideRange.Count == 1)
                {
                    PowerPoint.Shape shape = sel.SlideRange[1].Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 0, 0, w, h);
                    if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                    {
                        shape.Line.Visible = Office.MsoTriState.msoFalse;
                    }
                    shape.Line.Weight = 0;
                    shape.Select();
                }
                else
                {
                    foreach (PowerPoint.Slide item in srange)
                    {
                        PowerPoint.Shape shape = item.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 0, 0, w, h);
                        if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                        {
                            shape.Line.Visible = Office.MsoTriState.msoFalse;
                        }
                        shape.Line.Weight = 0;
                    }
                }
            }
        }

        public void button9_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                string[] name = new string[range.Count];
                for (int i = 1; i <= range.Count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    float n = 0;
                    if (shape.Width >= shape.Height)
                    {
                        n = shape.Height;
                    }
                    else
                    {
                        n = shape.Width;
                    }
                    PowerPoint.Shape nshape = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeOval, shape.Left, shape.Top, n, n);
                    if (nshape.Line.Visible == Office.MsoTriState.msoTrue)
                    {
                        nshape.Line.Visible = Office.MsoTriState.msoFalse;
                    }
                    nshape.Line.Weight = 0;
                    name[i - 1] = nshape.Name;
                }
                slide.Shapes.Range(name).Select();
            }
            else
            {
                PowerPoint.SlideRange srange = sel.SlideRange;
                if (sel.SlideRange.Count == 1)
                {
                    PowerPoint.Shape shape = sel.SlideRange[1].Shapes.AddShape(Office.MsoAutoShapeType.msoShapeOval, -100, 100, 100, 100);
                    if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                    {
                        shape.Line.Visible = Office.MsoTriState.msoFalse;
                    }
                    shape.Line.Weight = 0;
                    shape.Select();
                }
                else
                {
                    foreach (PowerPoint.Slide item in srange)
                    {
                        PowerPoint.Shape shape = item.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeOval, -100, 100, 100, 100);
                        if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                        {
                            shape.Line.Visible = Office.MsoTriState.msoFalse;
                        }
                        shape.Line.Weight = 0;
                    }
                }
            }
        }

        public void button12_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = range.Count; i >= 1; i--)
                {
                    range[i].Delete();
                }
            }
            else
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = item.Shapes.Count; i >= 1; i--)
                    {
                        item.Shapes[i].Delete();
                    }
                }
            }
        }

        public void button13_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            if (range[i].GroupItems[j].HasTextFrame == Office.MsoTriState.msoTrue)
                            {
                                range[i].GroupItems[j].TextFrame.DeleteText();
                            }
                        }
                    }
                    else
                    {
                        if (range[i].HasTextFrame == Office.MsoTriState.msoTrue)
                        {
                            range[i].TextFrame.DeleteText();
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            for (int j = 1; j <= item.Shapes[i].GroupItems.Count; j++)
                            {
                                if (item.Shapes[i].GroupItems[j].HasTextFrame == Office.MsoTriState.msoTrue)
                                {
                                    item.Shapes[i].GroupItems[j].TextFrame.DeleteText();
                                }
                            }
                        }
                        else
                        {
                            if (item.Shapes[i].HasTextFrame == Office.MsoTriState.msoTrue)
                            {
                                if (item.Shapes[i].HasTextFrame == Office.MsoTriState.msoTrue)
                                {
                                    item.Shapes[i].TextFrame.DeleteText();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中文本框或包含文本框的幻灯片");
            }
        }

        public void button14_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                for (int i = slide.Shapes.Placeholders.Count; i >= 1; i--)
                {
                    slide.Shapes.Placeholders[i].Delete();
                }
            }
            else
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = item.Shapes.Placeholders.Count; i >= 1; i--)
                    {
                        item.Shapes.Placeholders[i].Delete();
                    }
                }
            }
        }

        public void button15_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            PowerPoint.Shape gshape = range[i].GroupItems[j];
                            if (gshape.Fill.Visible == Office.MsoTriState.msoTrue)
                            {
                                gshape.Fill.Visible = Office.MsoTriState.msoFalse;
                            }
                        }
                    }
                    else if (range[i].Fill.Visible == Office.MsoTriState.msoTrue)
                    {
                        range[i].Fill.Visible = Office.MsoTriState.msoFalse;
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            for (int j = 1; j <= item.Shapes[i].GroupItems.Count; j++)
                            {
                                PowerPoint.Shape gshape = item.Shapes[i].GroupItems[j];
                                if (gshape.Fill.Visible == Office.MsoTriState.msoTrue)
                                {
                                    gshape.Fill.Visible = Office.MsoTriState.msoFalse;
                                }
                            }
                        }
                        else if (item.Shapes[i].Fill.Visible == Office.MsoTriState.msoTrue)
                        {
                            item.Shapes[i].Fill.Visible = Office.MsoTriState.msoFalse;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中形状或包含形状的幻灯片");
            }
        }

        public void button16_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            PowerPoint.Shape gshape = range[i].GroupItems[j];
                            if (gshape.Line.Visible == Office.MsoTriState.msoTrue)
                            {
                                gshape.Line.Visible = Office.MsoTriState.msoFalse;
                                gshape.Line.Weight = 0;
                            }
                        }
                    }
                    else if (range[i].Line.Visible == Office.MsoTriState.msoTrue)
                    {
                        range[i].Line.Visible = Office.MsoTriState.msoFalse;
                        range[i].Line.Weight = 0;
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            for (int j = 1; j <= item.Shapes[i].GroupItems.Count; j++)
                            {
                                PowerPoint.Shape gshape = item.Shapes[i].GroupItems[j];
                                if (gshape.Line.Visible == Office.MsoTriState.msoTrue)
                                {
                                    gshape.Line.Visible = Office.MsoTriState.msoFalse;
                                    gshape.Line.Weight = 0;
                                }
                            }
                        }
                        else if (item.Shapes[i].Line.Visible == Office.MsoTriState.msoTrue)
                        {
                            item.Shapes[i].Line.Visible = Office.MsoTriState.msoFalse;
                            item.Shapes[i].Line.Weight = 0;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中形状或包含形状的幻灯片");
            }
        }

        public void button17_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            PowerPoint.Shape gshape = range[i].GroupItems[j];
                            if (gshape.Shadow.Visible == Office.MsoTriState.msoTrue)
                            {
                                gshape.Shadow.Visible = Office.MsoTriState.msoFalse;
                            }
                        }
                    }
                    else if (range[i].Shadow.Visible == Office.MsoTriState.msoTrue)
                    {
                        range[i].Shadow.Visible = Office.MsoTriState.msoFalse;
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            for (int j = 1; j <= item.Shapes[i].GroupItems.Count; j++)
                            {
                                PowerPoint.Shape gshape = item.Shapes[i].GroupItems[j];
                                if (gshape.Shadow.Visible == Office.MsoTriState.msoTrue)
                                {
                                    gshape.Shadow.Visible = Office.MsoTriState.msoFalse;
                                }
                            }
                        }
                        else if (item.Shapes[i].Shadow.Visible == Office.MsoTriState.msoTrue)
                        {
                            item.Shapes[i].Shadow.Visible = Office.MsoTriState.msoFalse;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中形状或包含形状的幻灯片");
            }
        }

        public void splitButton4_Click(object sender, RibbonControlEventArgs e)
        {
            if (Clipboard.ContainsData("EnhancedMetafile"))
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.Shape shape = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPasteEnhancedMetafile)[1];
                PowerPoint.ShapeRange range = shape.Ungroup().Ungroup();
                range[1].Delete();
            }
            else
            {
                MessageBox.Show("请先复制素材");
            }
        }

        public void button18_Click(object sender, RibbonControlEventArgs e)
        {
            if (Clipboard.ContainsData("EnhancedMetafile"))
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.Shape shape = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPasteEnhancedMetafile)[1];
                PowerPoint.ShapeRange range = shape.Ungroup().Ungroup();
                range[1].Delete();
            }
            else
            {
                MessageBox.Show("请先复制素材");
            }
        }

        public void button19_Click(object sender, RibbonControlEventArgs e)
        {
            if (Clipboard.ContainsData("EnhancedMetafile"))
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.Shape shape = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPasteEnhancedMetafile)[1];
                PowerPoint.ShapeRange range = shape.Ungroup().Ungroup();
                range[1].Delete();
                int count = range.Count;
                if (count != 1)
                {
                    range.Group();
                }
            }
            else
            {
                MessageBox.Show("请先复制素材");
            }
        }

        private void splitButton5_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请至少选择2个形状或1个文本框");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                float a = tr.Characters(1).Font.Size;
                for (int i = 2; i <= tr.Text.Count(); i++)
                {
                    tr.Characters(i).Font.Size = a;
                }
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            range[1].GroupItems[i].Top = range[1].GroupItems[i].Top + range[1].GroupItems[i].Height / 2 - range[1].GroupItems[1].Height / 2;
                            range[1].GroupItems[i].Left = range[1].GroupItems[i].Left + range[1].GroupItems[i].Width / 2 - range[1].GroupItems[1].Width / 2;
                            range[1].GroupItems[i].Height = range[1].GroupItems[1].Height;
                            range[1].GroupItems[i].Width = range[1].GroupItems[1].Width;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一个组合或者两个以上形状");
                    }
                }
                else if (count >= 2)
                {
                    for (int i = 2; i <= count; i++)
                    {
                        range[i].Top = range[i].Top + range[i].Height / 2 - range[1].Height / 2;
                        range[i].Left = range[i].Left + range[i].Width / 2 - range[1].Width / 2;
                        range[i].Height = range[1].Height;
                        range[i].Width = range[1].Width;
                    }
                }
            }
        }

        public void button21_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请至少选择2个形状或1个文本框");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                float min = tr.Characters(1).Font.Size;
                float max = tr.Characters(1).Font.Size;
                for (int i = 2; i <= tr.Characters(tr.Text.Count()).Font.Size; i++)
                {
                    float osize = tr.Characters(i).Font.Size;
                    min = Math.Min(osize, min);
                    max = Math.Max(osize, max);
                }
                if (min == max)
                {
                    MessageBox.Show("请先改变一个字符的字号");
                }
                float n = (max - min) / ((float)tr.Text.Count() - 1);
                for (int i = 1; i <= tr.Text.Count(); i++)
                {
                    tr.Characters(i).Font.Size = min + n * (i - 1);
                }
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float minh = range[1].GroupItems[1].Height;
                        float maxh = range[1].GroupItems[1].Height;
                        float minw = range[1].GroupItems[1].Width;
                        float maxw = range[1].GroupItems[1].Width;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float oheight = range[1].GroupItems[i].Height;
                            float owidth = range[1].GroupItems[i].Width;
                            minh = Math.Min(oheight, minh);
                            maxh = Math.Max(oheight, maxh);
                            minw = Math.Min(owidth, minw);
                            maxw = Math.Max(owidth, maxw);
                        }

                        float n1 = (maxh - minh) / (range[1].GroupItems.Count - 1);
                        float n2 = (maxw - minw) / (range[1].GroupItems.Count - 1);

                        for (int j = 1; j <= range[1].GroupItems.Count; j++)
                        {
                            float oh = range[1].GroupItems[j].Height;
                            range[1].GroupItems[j].Height = minh + n1 * (j - 1);
                            range[1].GroupItems[j].Top = range[1].GroupItems[j].Top - (range[1].GroupItems[j].Height - oh) / 2;
                            float ow = range[1].GroupItems[j].Width;
                            range[1].GroupItems[j].Width = minw + n2 * (j - 1);
                            range[1].GroupItems[j].Left = range[1].GroupItems[j].Left - (range[1].GroupItems[j].Width - ow) / 2;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一个组合或者两个以上形状");
                    }
                }
                else if (count >= 2)
                {
                    float minh = range[1].Height;
                    float maxh = range[1].Height;
                    float minw = range[1].Width;
                    float maxw = range[1].Width;

                    for (int i = 2; i <= count; i++)
                    {
                        float oheight = range[i].Height;
                        float owidth = range[i].Width;
                        minh = Math.Min(oheight, minh);
                        maxh = Math.Max(oheight, maxh);
                        minw = Math.Min(owidth, minw);
                        maxw = Math.Max(owidth, maxw);
                    }

                    float n1 = (maxh - minh) / (count - 1);
                    float n2 = (maxw - minw) / (count - 1);

                    for (int j = 1; j <= count; j++)
                    {
                        float oh = range[j].Height;
                        range[j].Height = minh + n1 * (j - 1);
                        range[j].Top = range[j].Top - (range[j].Height - oh) / 2;
                        float ow = range[j].Width;
                        range[j].Width = minw + n2 * (j - 1);
                        range[j].Left = range[j].Left - (range[j].Width - ow) / 2;
                    }
                }
            }
        }

        public void button22_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请至少选择2个形状或1个文本框");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue)|| sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                float min = tr.Characters(1).Font.Size;
                float max = tr.Characters(1).Font.Size;
                for (int i = 2; i <= tr.Characters(tr.Text.Count()).Font.Size; i++)
                {
                    float osize = tr.Characters(i).Font.Size;
                    min = Math.Min(osize, min);
                    max = Math.Max(osize, max);
                }
                if (min == max)
                {
                    MessageBox.Show("请先改变一个字符的字号");
                }
                float n = (max - min) / ((float)tr.Text.Count() - 1);
                for (int i = 1; i <= tr.Text.Count(); i++)
                {
                    tr.Characters(i).Font.Size = max - n * (i - 1);
                }
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float minh = range[1].GroupItems[1].Height;
                        float maxh = range[1].GroupItems[1].Height;
                        float minw = range[1].GroupItems[1].Width;
                        float maxw = range[1].GroupItems[1].Width;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float oheight = range[1].GroupItems[i].Height;
                            float owidth = range[1].GroupItems[i].Width;
                            minh = Math.Min(oheight, minh);
                            maxh = Math.Max(oheight, maxh);
                            minw = Math.Min(owidth, minw);
                            maxw = Math.Max(owidth, maxw);
                        }

                        float n1 = (maxh - minh) / (range[1].GroupItems.Count - 1);
                        float n2 = (maxw - minw) / (range[1].GroupItems.Count - 1);

                        for (int j = 1; j <= range[1].GroupItems.Count; j++)
                        {
                            float oh = range[1].GroupItems[j].Height;
                            range[1].GroupItems[j].Height = maxh - n1 * (j - 1);
                            range[1].GroupItems[j].Top = range[1].GroupItems[j].Top - (range[1].GroupItems[j].Height - oh) / 2;
                            float ow = range[1].GroupItems[j].Width;
                            range[1].GroupItems[j].Width = maxw - n2 * (j - 1);
                            range[1].GroupItems[j].Left = range[1].GroupItems[j].Left - (range[1].GroupItems[j].Width - ow) / 2;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一个组合或者两个以上形状");
                    }
                }
                else if (count >= 2)
                {
                    float minh = range[1].Height;
                    float maxh = range[1].Height;
                    float minw = range[1].Width;
                    float maxw = range[1].Width;

                    for (int i = 2; i <= count; i++)
                    {
                        float oheight = range[i].Height;
                        float owidth = range[i].Width;
                        minh = Math.Min(oheight, minh);
                        maxh = Math.Max(oheight, maxh);
                        minw = Math.Min(owidth, minw);
                        maxw = Math.Max(owidth, maxw);
                    }

                    float n1 = (maxh - minh) / (count - 1);
                    float n2 = (maxw - minw) / (count - 1);

                    for (int j = 1; j <= count; j++)
                    {
                        float oh = range[j].Height;
                        range[j].Height = maxh - n1 * (j - 1);
                        range[j].Top = range[j].Top - (range[j].Height - oh) / 2;
                        float ow = range[j].Width;
                        range[j].Width = maxw - n2 * (j - 1);
                        range[j].Left = range[j].Left - (range[j].Width - ow) / 2;
                    }
                }
            }
        }

        public void button23_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请至少选择2个形状或1个文本框");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                float a = tr.Characters(1).Font.Size;
                for (int i = 2; i <= tr.Text.Count(); i++)
                {
                    tr.Characters(i).Font.Size = a;
                }
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            range[1].GroupItems[i].Top = range[1].GroupItems[i].Top + range[1].GroupItems[i].Height / 2 - range[1].GroupItems[1].Height / 2;
                            range[1].GroupItems[i].Left = range[1].GroupItems[i].Left + range[1].GroupItems[i].Width / 2 - range[1].GroupItems[1].Width / 2;
                            range[1].GroupItems[i].Height = range[1].GroupItems[1].Height;
                            range[1].GroupItems[i].Width = range[1].GroupItems[1].Width;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一个组合或者两个以上形状");
                    }
                }
                else if (count >= 2)
                {
                    for (int i = 2; i <= count; i++)
                    {
                        range[i].Top = range[i].Top + range[i].Height / 2 - range[1].Height / 2;
                        range[i].Left = range[i].Left + range[i].Width / 2 - range[1].Width / 2;
                        range[i].Height = range[1].Height;
                        range[i].Width = range[1].Width;
                    }
                }
            }
        }

        public void button20_Click(object sender, RibbonControlEventArgs e)
        {
            Align_More Align_More = null;
            if (Align_More == null || Align_More.IsDisposed)
            {
                Align_More = new Align_More();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Align_More.Show();
                button20.Enabled = false;

            }
        }

        public void button24_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中至少三个角度不同的形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup && range[1].GroupItems.Count > 2)
                    {
                        float froll = range[1].GroupItems[1].Rotation;
                        float eroll = range[1].GroupItems[range[1].GroupItems.Count].Rotation;
                        float nr = (eroll - froll) / (range[1].GroupItems.Count - 1);
                        for (int i = 2; i < range[1].GroupItems.Count; i++)
                        {
                            range[1].GroupItems[i].Rotation = froll + nr * (i - 1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内至少有三个角度不同的形状");
                    }
                }
                else if (count >= 3)
                {
                    float froll = range[1].Rotation;
                    float eroll = range[count].Rotation;
                    float nr = (eroll - froll) / (count - 1);
                    for (int i = 2; i < count; i++)
                    {
                        range[i].Rotation = froll + nr * (i - 1);
                    }
                }
                else
                {
                    MessageBox.Show("请至少选中三个角度不同的形状");
                }
            }
        }

        public void button28_Click(object sender, RibbonControlEventArgs e)
        {
            Rotation_More Rotation_More = null;
            if (Rotation_More == null || Rotation_More.IsDisposed)
            {
                Rotation_More = new Rotation_More();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Rotation_More.Show();
                button28.Enabled = false;
            }
        }

        public void button29_Click(object sender, RibbonControlEventArgs e)
        {
            Copy_Rectangle Copy_Rectangle = null;
            if (Copy_Rectangle == null || Copy_Rectangle.IsDisposed)
            {
                Copy_Rectangle = new Copy_Rectangle();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Copy_Rectangle.Show();
                button29.Enabled = false;
            }
        }

        public void button30_Click(object sender, RibbonControlEventArgs e)
        {
            ControlPoints ControlPoints = null;
            if (ControlPoints == null || ControlPoints.IsDisposed)
            {
                ControlPoints = new ControlPoints();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                ControlPoints.Show();
                button30.Enabled = false;
            }
        }

        public void button31_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中至少1个文本框");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    string txt = shape.TextEffect.Text;
                    if (txt.Contains("\r") || txt.Contains("\v"))
                    {
                        String[] arr = txt.Split(char.Parse("\r"), char.Parse("\v")).ToArray();
                        int tcount = arr.Count();
                        shape.PickUp();
                        for (int j = 1; j <= tcount; j++)
                        {
                            PowerPoint.Shape text = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, shape.Left + shape.Width, shape.Top + shape.Height * (j - 1) / tcount, shape.Width, shape.Height);
                            text.TextFrame.TextRange.Text = arr[j - 1];
                            text.Apply();
                            text.TextFrame.AutoSize = PowerPoint.PpAutoSize.ppAutoSizeShapeToFitText;
                        }
                    }
                    else
                    {
                        MessageBox.Show("存在没有分段的文本框");
                    }
                }
            }
        }

        public void button32_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中要合并的文本框，或者幻灯片");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.Shape text = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, -200, 0, 200, 200);
                text.TextFrame.AutoSize = PowerPoint.PpAutoSize.ppAutoSizeShapeToFitText;
                text.Name = "textcount";
                text.TextFrame.TextRange.Text = "";
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        PowerPoint.Shape shape = item.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoGroup)
                        {
                            for (int j = 1; j <= shape.GroupItems.Count; j++)
                            {
                                if (shape.GroupItems[j].HasTextFrame == Office.MsoTriState.msoTrue)
                                {
                                    if (shape.GroupItems[j].Name != "textcount")
                                    {
                                        text.TextFrame.TextRange.Text = text.TextFrame.TextRange.Text + Environment.NewLine + shape.GroupItems[j].TextFrame.TextRange.Text;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (shape.HasTextFrame == Office.MsoTriState.msoTrue)
                            {
                                if (shape.Name != "textcount")
                                {
                                    text.TextFrame.TextRange.Text = text.TextFrame.TextRange.Text + Environment.NewLine + shape.TextFrame.TextRange.Text;
                                }
                            }
                        }
                    }
                }
                text.Select();
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Shape text = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, -200, 0, 200, 200);
                text.TextFrame.AutoSize = PowerPoint.PpAutoSize.ppAutoSizeShapeToFitText;
                text.Name = "textcount";
                text.TextFrame.TextRange.Text = "";
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= shape.GroupItems.Count; j++)
                        {
                            if (shape.GroupItems[j].HasTextFrame == Office.MsoTriState.msoTrue)
                            {
                                if (shape.GroupItems[j].Name != "textcount")
                                {
                                    text.TextFrame.TextRange.Text = text.TextFrame.TextRange.Text + Environment.NewLine + shape.GroupItems[j].TextFrame.TextRange.Text;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (shape.HasTextFrame == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Name != "textcount")
                            {
                                text.TextFrame.TextRange.Text = text.TextFrame.TextRange.Text + Environment.NewLine + shape.TextFrame.TextRange.Text;
                            }
                        }
                    }
                }
            }
        }

        public void button33_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中至少1个文本框");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    string txt = shape.TextEffect.Text;
                    int tcount = txt.Length;
                    shape.PickUp();
                    for (int j = 1; j <= tcount; j++)
                    {
                        PowerPoint.Shape text = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, shape.Left + shape.Width + 24 * (j - 1), shape.Top, 24, 20);
                        text.TextFrame.TextRange.Text = txt.Substring(j - 1, 1);
                        text.Apply();
                        text.TextFrame2.TextRange.Font.Size = shape.TextFrame2.TextRange.Characters[j].Font.Size;
                        text.TextFrame2.TextRange.Font.Name = shape.TextFrame2.TextRange.Characters[j].Font.Name;
                        text.TextFrame2.TextRange.Font.NameFarEast = shape.TextFrame2.TextRange.Characters[j].Font.NameFarEast;
                        text.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = shape.TextFrame2.TextRange.Characters[j].Font.Fill.ForeColor.RGB;
                        text.TextFrame2.TextRange.Font.Fill.Transparency = shape.TextFrame2.TextRange.Characters[j].Font.Fill.Transparency;
                        text.TextFrame.AutoSize = PowerPoint.PpAutoSize.ppAutoSizeShapeToFitText;
                    }
                }
            }
        }

        public void button34_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.TextRange.Count < 2)
            {
                MessageBox.Show("请选中至少2个文本框");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape text = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, sel.ShapeRange[sel.ShapeRange.Count].Left + sel.ShapeRange[sel.ShapeRange.Count].Width, sel.ShapeRange[1].Top, sel.ShapeRange[1].Width * sel.ShapeRange.Count / 2, sel.ShapeRange[1].Height);
                PowerPoint.TextFrame2 tframe = text.TextFrame2;
                int count = sel.ShapeRange.Count;
                for (int i = 1; i <= count; i++)
                {
                    tframe.TextRange.Text = tframe.TextRange.Text + range[i].TextFrame2.TextRange.Text;
                    tframe.AutoSize= Office.MsoAutoSize.msoAutoSizeShapeToFitText;
                }
            }
        }

        public void button35_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || (!sel.HasChildShapeRange && sel.ShapeRange.Fill.Type != Office.MsoFillType.msoFillGradient) || (sel.HasChildShapeRange && sel.ChildShapeRange.Fill.Type != Office.MsoFillType.msoFillGradient))
            {
                MessageBox.Show("请先选中一个带渐变填充的矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                List<int> rgbs = new List<int>();
                foreach (Office.GradientStop item in shape.Fill.GradientStops)
                {
                    rgbs.Add(item.Color.RGB);
                }
                for (int i = 1; i <= shape.Fill.GradientStops.Count; i++)
                {
                    Office.GradientStop item = shape.Fill.GradientStops[i];
                    PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                    PowerPoint.Shape nshape = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 820, 50 * (i - 1), 100, 50);
                    nshape.Fill.ForeColor.RGB = item.Color.RGB;
                    nshape.Fill.Transparency = item.Transparency;
                    nshape.Line.Visible = Office.MsoTriState.msoFalse;
                }
            }
        }

        public void button36_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选择至少两个纯色矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int scount = range.Count;
                if (scount == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        scount = range[1].GroupItems.Count;
                        PowerPoint.Shape nshape = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 720, 0, 100, 100);
                        nshape.Line.Visible = Office.MsoTriState.msoFalse;
                        nshape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1.0f);
                        for (int i = 2; i <= scount + 1; i++)
                        {
                            nshape.Fill.GradientStops.Insert2(range[1].GroupItems[i - 1].Fill.ForeColor.RGB, (i - 2.0f) / (scount - 1), range[1].GroupItems[i - 1].Fill.Transparency, i, 0f);
                        }
                        nshape.Fill.GradientStops.Delete(1);
                        nshape.Fill.GradientStops.Delete(scount + 1);
                    }
                    else
                    {
                        MessageBox.Show("请选中两个纯色矢量形状");
                    }
                }
                else
                {
                    PowerPoint.Shape nshape = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 720, 0, 100, 100);
                    nshape.Line.Visible = Office.MsoTriState.msoFalse;
                    nshape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1.0f);
                    for (int i = 2; i <= scount + 1; i++)
                    {
                        nshape.Fill.GradientStops.Insert2(range[i - 1].Fill.ForeColor.RGB, (i - 2.0f) / (scount - 1), range[i - 1].Fill.Transparency, i, 0f);
                    }
                    nshape.Fill.GradientStops.Delete(1);
                    nshape.Fill.GradientStops.Delete(scount + 1);
                }
            }
        }

        public void button37_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("选中至少1个纯色矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            int r = range[i].GroupItems[j].Fill.ForeColor.RGB % 256;
                            int g = (range[i].GroupItems[j].Fill.ForeColor.RGB / 256) % 256;
                            int b = (range[i].GroupItems[j].Fill.ForeColor.RGB / 256 / 256) % 256;
                            range[i].GroupItems[j].TextFrame2.DeleteText();
                            range[i].GroupItems[j].TextFrame2.TextRange.Characters.Text = r + "," + g + "," + b;
                        }
                    }
                    else
                    {
                        int r = range[i].Fill.ForeColor.RGB % 256;
                        int g = (range[i].Fill.ForeColor.RGB / 256) % 256;
                        int b = (range[i].Fill.ForeColor.RGB / 256 / 256) % 256;
                        range[i].TextFrame2.DeleteText();
                        range[i].TextFrame2.TextRange.Characters.Text = r + "," + g + "," + b;
                    }
                }
            }
        }

        private int Rgb2Hsl(int r, int g, int b)
        {
            float h = 0;
            float s = 0;
            float l = 0;
            float max = Math.Max(Math.Max(r, g), b);
            float min = Math.Min(Math.Min(r, g), b);

            if (max == min)
            {
                h = 0;
            }
            else
            {
                if (max == r)
                {
                    if (g >= b)
                    {
                        h = 255 / 6 * (g - b) / (max - min) + 0;
                    }
                    else
                    {
                        h = 255 / 6 * (g - b) / (max - min) + 255;
                    }
                }
                if (max == g & max != r)
                {
                    h = 255 / 6 * (b - r) / (max - min) + 255 / 3;
                }
                if (max == b && max != g)
                {
                    h = 255 / 6 * (r - g) / (max - min) + 255 * 2 / 3;
                }
            }
            if (h >= (int)h + 0.5f)
            {
                h = (int)h + 1;
            }

            l = (max + min) / 2;
            if (max + min == 255)
            {
                l = 128;
            }
            if (l >= (int)l + 0.5f)
            {
                l = (int)l + 1;
            }

            if (l == 0 || max == min)
            {
                s = 0;
            }
            else
            {
                if (l <= 255 / 2)
                {
                    s = 255 * (max - min) / (max + min);
                }
                else
                {
                    s = 255 * (max - min) / (2 * 255 - (max + min));
                }
            }
            if (s >= (int)s + 0.5f)
            {
                s = (int)s + 1;
            }

            int hsl = (int)h + (int)s * 256 + (int)l * 256 * 256;
            return hsl;
        }

        private int Hsl2Rgb(int h, int s, int l)
        {
            float nh = (float)h / 255;
            float ns = (float)s / 255;
            float nl = (float)l / 255;
            float nr = 0;
            float ng = 0;
            float nb = 0;

            if (ns == 0)
            {
                nr = nl;
                ng = nl;
                nb = nl;
            }
            else
            {
                float q = 0;
                if (nl < 0.5f)
                {
                    q = nl * (1 + ns);
                }
                else
                {
                    q = nl + ns - nl * ns;
                }

                float p = 2 * nl - q;
                float tr = nh + (float)1 / 3;
                float tg = nh;
                float tb = nh - (float)1 / 3;

                if (tr < 0)
                {
                    tr = tr + 1;
                }
                else
                {
                    if (tr > 1)
                    {
                        tr = tr - 1;
                    }
                    else
                    {
                        tr = tr + 0;
                    }
                }

                if (tg < 0)
                {
                    tg = tg + 1;
                }
                else
                {
                    if (tg > 1)
                    {
                        tg = tg - 1;
                    }
                    else
                    {
                        tg = tg + 0;
                    }
                }

                if (tb < 0)
                {
                    tb = tb + 1;
                }
                else
                {
                    if (tb > 1)
                    {
                        tb = tb - 1;
                    }
                    else
                    {
                        tb = tb + 0;
                    }
                }

                if (tr < (float)1 / 6)
                {
                    nr = p + (q - p) * 6 * tr;
                }
                else
                {
                    if (tr < (float)1 / 2)
                    {
                        nr = q;
                    }
                    else
                    {
                        if (tr < (float)2 / 3)
                        {
                            nr = p + (q - p) * 6 * ((float)2 / 3 - tr);
                        }
                        else
                        {
                            nr = p;
                        }
                    }
                }

                if (tg < (float)1 / 6)
                {
                    ng = p + (q - p) * 6 * tg;
                }
                else
                {
                    if (tg < (float)1 / 2)
                    {
                        ng = q;
                    }
                    else
                    {
                        if (tg < (float)2 / 3)
                        {
                            ng = p + (q - p) * 6 * ((float)2 / 3 - tg);
                        }
                        else
                        {
                            ng = p;
                        }
                    }
                }

                if (tb < (float)1 / 6)
                {
                    nb = p + (q - p) * 6 * tb;
                }
                else
                {
                    if (tb < (float)1 / 2)
                    {
                        nb = q;
                    }
                    else
                    {
                        if (tb < (float)2 / 3)
                        {
                            nb = p + (q - p) * 6 * ((float)2 / 3 - tb);
                        }
                        else
                        {
                            nb = p;
                        }
                    }
                }
            }
            int r = (int)(nr * 255);
            int g = (int)(ng * 255);
            int b = (int)(nb * 255);
            int rgb = r + g * 256 + b * 256 * 256;
            return rgb;
        }

        public void button38_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("选中至少1个纯色矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            PowerPoint.Shape shape = range[i].GroupItems[j];
                            int rgb = shape.Fill.ForeColor.RGB;
                            int r = rgb % 256;
                            int g = (rgb / 256) % 256;
                            int b = (rgb / 256 / 256) % 256;
                            int hsl = Rgb2Hsl(r, g, b);
                            int h = hsl % 256;
                            int s = (hsl / 256) % 256;
                            int l = (hsl / 256 / 256) % 256;
                            shape.TextFrame2.TextRange.Characters.Text = h + "," + s + "," + l;
                        }
                    }
                    else
                    {
                        PowerPoint.Shape shape = range[i];
                        int rgb = shape.Fill.ForeColor.RGB;
                        int r = rgb % 256;
                        int g = (rgb / 256) % 256;
                        int b = (rgb / 256 / 256) % 256;
                        int hsl = Rgb2Hsl(r, g, b);
                        int h = hsl % 256;
                        int s = (hsl / 256) % 256;
                        int l = (hsl / 256 / 256) % 256;
                        shape.TextFrame2.TextRange.Characters.Text = h + "," + s + "," + l;
                    }
                }
            }
        }

        public int gys(int n1, int n2, int n3)
        {
            int temp = Math.Max(n1, Math.Max(n2, n3));
            n2 = Math.Min(n1, Math.Min(n2, n3));
            n1 = temp;
            while (n2 != 0)
            {
                n1 = n1 > n2 ? n1 : n2;
                int m = n1 % n2;
                n1 = n2;
                n2 = m;
            }
            return n1;
        }

        public void button39_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                int r1 = rgb1 % 256;
                int g1 = (rgb1 / 256) % 256;
                int b1 = (rgb1 / 256 / 256) % 256;
                int r2 = rgb2 % 256;
                int g2 = (rgb2 / 256) % 256;
                int b2 = (rgb2 / 256 / 256) % 256;

                int hsl1 = Rgb2Hsl(r1, g1, b1);
                int hsl2 = Rgb2Hsl(r2, g2, b2);

                int h1 = hsl1 % 256;
                int s1 = (hsl1 / 256) % 256;
                int l1 = (hsl1 / 256 / 256) % 256;
                int h2 = hsl2 % 256;
                int s2 = (hsl2 / 256) % 256;
                int l2 = (hsl2 / 256 / 256) % 256;

                int nh, ns, nl, n1, n2, n3, nrgb;
                if (h2 == h1 && s2 == s1 && l2 == l1)
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的HSL值相同，不能进行HSL补色");
                }
                else
                {
                    if (Math.Max(Math.Abs(h2 - h1), Math.Max(Math.Abs(s2 - s1), Math.Abs(l2 - l1))) >= count - 2)
                    {
                        n1 = (h2 - h1) / (count - 1);
                        n2 = (s2 - s1) / (count - 1);
                        n3 = (l2 - l1) / (count - 1);

                        for (int i = 2; i < count; i++)
                        {
                            nh = h1 + (i - 1) * n1;
                            ns = s1 + (i - 1) * n2;
                            nl = l1 + (i - 1) * n3;
                            nrgb = Hsl2Rgb(nh, ns, nl);
                            tr.Characters(i).Font.Color.RGB = nrgb;
                        }
                    }
                    else
                    {
                        int nit1, nit2, nit3;
                        for (int i = 2; i < count; i++)
                        {
                            if (h2 == h1)
                            {
                                nit1 = 0;
                            }
                            else
                            {
                                nit1 = (i - 1) % (h2 - h1);
                            }
                            if (s2 == s1)
                            {
                                nit2 = 0;
                            }
                            else
                            {
                                nit2 = (i - 1) % (s2 - s1);
                            }
                            if (l2 == l1)
                            {
                                nit3 = 0;
                            }
                            else
                            {
                                nit3 = (i - 1) % (l2 - l1);
                            }

                            if (h2 - h1 < 0)
                            {
                                nit1 = -nit1;
                            }
                            if (i <= Math.Abs(h2 - h1) + 1)
                            {
                                nit1 = i % (h2 - h1);
                                if (h2 - h1 < 0)
                                {
                                    nit1 = -nit1;
                                }
                            }

                            if (s2 - s1 < 0)
                            {
                                nit2 = -nit2;
                            }
                            if (i <= Math.Abs(s2 - s1) + 1)
                            {
                                nit2 = i % (s2 - s1);
                                if (s2 - s1 < 0)
                                {
                                    nit2 = -nit2;
                                }
                            }

                            if (l2 - l1 < 0)
                            {
                                nit3 = -nit3;
                            }
                            if (i <= Math.Abs(l2 - l1) + 1)
                            {
                                nit3 = i % (l2 - l1);
                                if (l2 - l1 < 0)
                                {
                                    nit3 = -nit3;
                                }
                            }

                            nh = h1 + nit1;
                            ns = s1 + nit2;
                            nl = l1 + nit3;
                            nrgb = Hsl2Rgb(nh, ns, nl);
                            tr.Characters(i).Font.Color.RGB = nrgb;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }
                        int r1 = rgb1 % 256;
                        int g1 = (rgb1 / 256) % 256;
                        int b1 = (rgb1 / 256 / 256) % 256;
                        int r2 = rgb2 % 256;
                        int g2 = (rgb2 / 256) % 256;
                        int b2 = (rgb2 / 256 / 256) % 256;

                        int hsl1 = Rgb2Hsl(r1, g1, b1);
                        int hsl2 = Rgb2Hsl(r2, g2, b2);

                        int h1 = hsl1 % 256;
                        int s1 = (hsl1 / 256) % 256;
                        int l1 = (hsl1 / 256 / 256) % 256;
                        int h2 = hsl2 % 256;
                        int s2 = (hsl2 / 256) % 256;
                        int l2 = (hsl2 / 256 / 256) % 256;

                        int nh, ns, nl, n1, n2, n3, nrgb;
                        if (h2 == h1 && s2 == s1 && l2 == l1)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的HSL值相同，不能进行HSL补色");
                        }
                        else
                        {
                            if (Math.Max(Math.Abs(h2 - h1), Math.Max(Math.Abs(s2 - s1), Math.Abs(l2 - l1))) >= count - 2)
                            {
                                n1 = (h2 - h1) / (count - 1);
                                n2 = (s2 - s1) / (count - 1);
                                n3 = (l2 - l1) / (count - 1);

                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        nh = h1 + (i - 1) * n1;
                                        ns = s1 + (i - 1) * n2;
                                        nl = l1 + (i - 1) * n3;
                                        nrgb = Hsl2Rgb(nh, ns, nl);
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        nh = h1 + (i - 1) * n1;
                                        ns = s1 + (i - 1) * n2;
                                        nl = l1 + (i - 1) * n3;
                                        nrgb = Hsl2Rgb(nh, ns, nl);
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                    }
                                }
                            }
                            else
                            {
                                int nit1, nit2, nit3;
                                for (int i = 2; i < count; i++)
                                {
                                    if (h2 == h1)
                                    {
                                        nit1 = 0;
                                    }
                                    else
                                    {
                                        nit1 = (i - 1) % (h2 - h1);
                                    }
                                    if (s2 == s1)
                                    {
                                        nit2 = 0;
                                    }
                                    else
                                    {
                                        nit2 = (i - 1) % (s2 - s1);
                                    }
                                    if (l2 == l1)
                                    {
                                        nit3 = 0;
                                    }
                                    else
                                    {
                                        nit3 = (i - 1) % (l2 - l1);
                                    }

                                    if (h2 - h1 < 0)
                                    {
                                        nit1 = -nit1;
                                    }
                                    if (i <= Math.Abs(h2 - h1) + 1)
                                    {
                                        nit1 = i % (h2 - h1);
                                        if (h2 - h1 < 0)
                                        {
                                            nit1 = -nit1;
                                        }
                                    }

                                    if (s2 - s1 < 0)
                                    {
                                        nit2 = -nit2;
                                    }
                                    if (i <= Math.Abs(s2 - s1) + 1)
                                    {
                                        nit2 = i % (s2 - s1);
                                        if (s2 - s1 < 0)
                                        {
                                            nit2 = -nit2;
                                        }
                                    }

                                    if (l2 - l1 < 0)
                                    {
                                        nit3 = -nit3;
                                    }
                                    if (i <= Math.Abs(l2 - l1) + 1)
                                    {
                                        nit3 = i % (l2 - l1);
                                        if (l2 - l1 < 0)
                                        {
                                            nit3 = -nit3;
                                        }
                                    }

                                    nh = h1 + nit1;
                                    ns = s1 + nit2;
                                    nl = l1 + nit3;
                                    nrgb = Hsl2Rgb(nh, ns, nl);
                                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                    {
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                    }
                                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                    {
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }
                    int r1 = rgb1 % 256;
                    int g1 = (rgb1 / 256) % 256;
                    int b1 = (rgb1 / 256 / 256) % 256;
                    int r2 = rgb2 % 256;
                    int g2 = (rgb2 / 256) % 256;
                    int b2 = (rgb2 / 256 / 256) % 256;

                    int hsl1 = Rgb2Hsl(r1, g1, b1);
                    int hsl2 = Rgb2Hsl(r2, g2, b2);

                    int h1 = hsl1 % 256;
                    int s1 = (hsl1 / 256) % 256;
                    int l1 = (hsl1 / 256 / 256) % 256;
                    int h2 = hsl2 % 256;
                    int s2 = (hsl2 / 256) % 256;
                    int l2 = (hsl2 / 256 / 256) % 256;

                    int nh, ns, nl, n1, n2, n3, nrgb;
                    if (h2 == h1 && s2 == s1 && l2 == l1)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的HSL值相同，不能进行HSL补色");
                    }
                    else
                    {
                        if (Math.Max(Math.Abs(h2 - h1), Math.Max(Math.Abs(s2 - s1), Math.Abs(l2 - l1))) >= count - 2)
                        {
                            n1 = (h2 - h1) / (count - 1);
                            n2 = (s2 - s1) / (count - 1);
                            n3 = (l2 - l1) / (count - 1);
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    nh = h1 + (i - 1) * n1;
                                    ns = s1 + (i - 1) * n2;
                                    nl = l1 + (i - 1) * n3;
                                    nrgb = Hsl2Rgb(nh, ns, nl);
                                    range[i].Fill.ForeColor.RGB = nrgb;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    nh = h1 + (i - 1) * n1;
                                    ns = s1 + (i - 1) * n2;
                                    nl = l1 + (i - 1) * n3;
                                    nrgb = Hsl2Rgb(nh, ns, nl);
                                    range[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                        else
                        {
                            int nit1, nit2, nit3;
                            for (int i = 2; i < count; i++)
                            {
                                if (h2 == h1)
                                {
                                    nit1 = 0;
                                }
                                else
                                {
                                    nit1 = (i - 1) % (h2 - h1);
                                }
                                if (s2 == s1)
                                {
                                    nit2 = 0;
                                }
                                else
                                {
                                    nit2 = (i - 1) % (s2 - s1);
                                }
                                if (l2 == l1)
                                {
                                    nit3 = 0;
                                }
                                else
                                {
                                    nit3 = (i - 1) % (l2 - l1);
                                }

                                if (h2 - h1 < 0)
                                {
                                    nit1 = -nit1;
                                }
                                if (i <= Math.Abs(h2 - h1) + 1)
                                {
                                    nit1 = i % (h2 - h1);
                                    if (h2 - h1 < 0)
                                    {
                                        nit1 = -nit1;
                                    }
                                }

                                if (s2 - s1 < 0)
                                {
                                    nit2 = -nit2;
                                }
                                if (i <= Math.Abs(s2 - s1) + 1)
                                {
                                    nit2 = i % (s2 - s1);
                                    if (s2 - s1 < 0)
                                    {
                                        nit2 = -nit2;
                                    }
                                }

                                if (l2 - l1 < 0)
                                {
                                    nit3 = -nit3;
                                }
                                if (i <= Math.Abs(l2 - l1) + 1)
                                {
                                    nit3 = i % (l2 - l1);
                                    if (l2 - l1 < 0)
                                    {
                                        nit3 = -nit3;
                                    }
                                }

                                nh = h1 + nit1;
                                ns = s1 + nit2;
                                nl = l1 + nit3;
                                nrgb = Hsl2Rgb(nh, ns, nl);
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    range[i].Fill.ForeColor.RGB = nrgb;
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    range[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button40_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                int r1 = rgb1 % 256;
                int g1 = (rgb1 / 256) % 256;
                int b1 = (rgb1 / 256 / 256) % 256;
                int r2 = rgb2 % 256;
                int g2 = (rgb2 / 256) % 256;
                int b2 = (rgb2 / 256 / 256) % 256;

                int hsl1 = Rgb2Hsl(r1, g1, b1);
                int hsl2 = Rgb2Hsl(r2, g2, b2);

                int h1 = hsl1 % 256;
                int s1 = (hsl1 / 256) % 256;
                int l1 = (hsl1 / 256 / 256) % 256;
                int h2 = hsl2 % 256;
                int s2 = (hsl2 / 256) % 256;
                int l2 = (hsl2 / 256 / 256) % 256;

                if (h2 - h1 == 0)
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的H值相同，不能进行H补色");
                }
                else
                {
                    if (Math.Abs(h2 - h1) >= count - 2)
                    {
                        int n = (h2 - h1) / (count - 1);
                        for (int i = 2; i < count; i++)
                        {
                            int nh = h1 + (i - 1) * n;
                            int nrgb = Hsl2Rgb(nh, s1, l1);
                            tr.Characters(i).Font.Color.RGB = nrgb;
                        }
                    }
                    else
                    {
                        for (int i = 2; i < count; i++)
                        {
                            int nit = (i - 1) % (h2 - h1);
                            if (h2 - h1 < 0)
                            {
                                nit = -nit;
                            }
                            if (i <= Math.Abs(h2 - h1) + 1)
                            {
                                nit = i % (h2 - h1);
                                if (h2 - h1 < 0)
                                {
                                    nit = -nit;
                                }
                            }
                            int nh = h1 + nit;
                            int nrgb = Hsl2Rgb(nh, s1, l1);
                            tr.Characters(i).Font.Color.RGB = nrgb;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }
                        int r1 = rgb1 % 256;
                        int g1 = (rgb1 / 256) % 256;
                        int b1 = (rgb1 / 256 / 256) % 256;
                        int r2 = rgb2 % 256;
                        int g2 = (rgb2 / 256) % 256;
                        int b2 = (rgb2 / 256 / 256) % 256;

                        int hsl1 = Rgb2Hsl(r1, g1, b1);
                        int hsl2 = Rgb2Hsl(r2, g2, b2);

                        int h1 = hsl1 % 256;
                        int s1 = (hsl1 / 256) % 256;
                        int l1 = (hsl1 / 256 / 256) % 256;
                        int h2 = hsl2 % 256;
                        int s2 = (hsl2 / 256) % 256;
                        int l2 = (hsl2 / 256 / 256) % 256;

                        if (h2 - h1 == 0)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的H值相同，不能进行H补色");
                        }
                        else
                        {
                            if (Math.Abs(h2 - h1) >= count - 2)
                            {
                                int n = (h2 - h1) / (count - 1);
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nh = h1 + (i - 1) * n;
                                        int nrgb = Hsl2Rgb(nh, s1, l1);
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nh = h1 + (i - 1) * n;
                                        int nrgb = Hsl2Rgb(nh, s1, l1);
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                    }
                                }
                            }
                            else
                            {
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (h2 - h1);
                                        if (h2 - h1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(h2 - h1) + 1)
                                        {
                                            nit = i % (h2 - h1);
                                            if (h2 - h1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        int nh = h1 + nit;
                                        int nrgb = Hsl2Rgb(nh, s1, l1);
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (h2 - h1);
                                        if (h2 - h1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(h2 - h1) + 1)
                                        {
                                            nit = i % (h2 - h1);
                                            if (h2 - h1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        int nh = h1 + nit;
                                        int nrgb = Hsl2Rgb(nh, s1, l1);
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }
                    int r1 = rgb1 % 256;
                    int g1 = (rgb1 / 256) % 256;
                    int b1 = (rgb1 / 256 / 256) % 256;
                    int r2 = rgb2 % 256;
                    int g2 = (rgb2 / 256) % 256;
                    int b2 = (rgb2 / 256 / 256) % 256;

                    int hsl1 = Rgb2Hsl(r1, g1, b1);
                    int hsl2 = Rgb2Hsl(r2, g2, b2);

                    int h1 = hsl1 % 256;
                    int s1 = (hsl1 / 256) % 256;
                    int l1 = (hsl1 / 256 / 256) % 256;
                    int h2 = hsl2 % 256;
                    int s2 = (hsl2 / 256) % 256;
                    int l2 = (hsl2 / 256 / 256) % 256;

                    if (h2 - h1 == 0)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的H值相同，不能进行H补色");
                    }
                    else
                    {
                        if (Math.Abs(h2 - h1) >= count - 2)
                        {
                            int n = (h2 - h1) / (count - 1);
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nh = h1 + (i - 1) * n;
                                    int nrgb = Hsl2Rgb(nh, s1, l1);
                                    range[i].Fill.ForeColor.RGB = nrgb;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nh = h1 + (i - 1) * n;
                                    int nrgb = Hsl2Rgb(nh, s1, l1);
                                    range[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                        else
                        {
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (h2 - h1);
                                    if (h2 - h1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(h2 - h1) + 1)
                                    {
                                        nit = i % (h2 - h1);
                                        if (h2 - h1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    int nh = h1 + nit;
                                    int nrgb = Hsl2Rgb(nh, s1, l1);
                                    range[i].Fill.ForeColor.RGB = nrgb;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (h2 - h1);
                                    if (h2 - h1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(h2 - h1) + 1)
                                    {
                                        nit = i % (h2 - h1);
                                        if (h2 - h1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    int nh = h1 + nit;
                                    int nrgb = Hsl2Rgb(nh, s1, l1);
                                    range[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button41_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                int r1 = rgb1 % 256;
                int g1 = (rgb1 / 256) % 256;
                int b1 = (rgb1 / 256 / 256) % 256;
                int r2 = rgb2 % 256;
                int g2 = (rgb2 / 256) % 256;
                int b2 = (rgb2 / 256 / 256) % 256;

                int hsl1 = Rgb2Hsl(r1, g1, b1);
                int hsl2 = Rgb2Hsl(r2, g2, b2);

                int h1 = hsl1 % 256;
                int s1 = (hsl1 / 256) % 256;
                int l1 = (hsl1 / 256 / 256) % 256;
                int h2 = hsl2 % 256;
                int s2 = (hsl2 / 256) % 256;
                int l2 = (hsl2 / 256 / 256) % 256;

                if (s2 - s1 == 0)
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的S值相同，不能进行S补色");
                }
                else
                {
                    if (Math.Abs(s2 - s1) >= count - 2)
                    {
                        int n = (s2 - s1) / (count - 1);
                        for (int i = 2; i < count; i++)
                        {
                            int ns = s1 + (i - 1) * n;
                            int nrgb = Hsl2Rgb(h1, ns, l1);
                            tr.Characters(i).Font.Color.RGB = nrgb;
                        }
                    }
                    else
                    {
                        for (int i = 2; i < count; i++)
                        {
                            int nit = (i - 1) % (s2 - s1);
                            if (s2 - s1 < 0)
                            {
                                nit = -nit;
                            }
                            if (i <= Math.Abs(s2 - s1) + 1)
                            {
                                nit = i % (s2 - s1);
                                if (s2 - s1 < 0)
                                {
                                    nit = -nit;
                                }
                            }
                            int ns = s1 + nit;
                            int nrgb = Hsl2Rgb(h1, ns, l1);
                            tr.Characters(i).Font.Color.RGB = nrgb;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }
                        int r1 = rgb1 % 256;
                        int g1 = (rgb1 / 256) % 256;
                        int b1 = (rgb1 / 256 / 256) % 256;
                        int r2 = rgb2 % 256;
                        int g2 = (rgb2 / 256) % 256;
                        int b2 = (rgb2 / 256 / 256) % 256;

                        int hsl1 = Rgb2Hsl(r1, g1, b1);
                        int hsl2 = Rgb2Hsl(r2, g2, b2);

                        int h1 = hsl1 % 256;
                        int s1 = (hsl1 / 256) % 256;
                        int l1 = (hsl1 / 256 / 256) % 256;
                        int h2 = hsl2 % 256;
                        int s2 = (hsl2 / 256) % 256;
                        int l2 = (hsl2 / 256 / 256) % 256;

                        if (s2 - s1 == 0)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的S值相同，不能进行S补色");
                        }
                        else
                        {
                            if (Math.Abs(s2 - s1) >= count - 2)
                            {
                                int n = (s2 - s1) / (count - 1);
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int ns = s1 + (i - 1) * n;
                                        int nrgb = Hsl2Rgb(h1, ns, l1);
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int ns = s1 + (i - 1) * n;
                                        int nrgb = Hsl2Rgb(h1, ns, l1);
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                    }
                                }
                            }
                            else
                            {
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (s2 - s1);
                                        if (s2 - s1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(s2 - s1) + 1)
                                        {
                                            nit = i % (s2 - s1);
                                            if (s2 - s1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        int ns = s1 + nit;
                                        int nrgb = Hsl2Rgb(h1, ns, l1);
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (s2 - s1);
                                        if (s2 - s1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(s2 - s1) + 1)
                                        {
                                            nit = i % (s2 - s1);
                                            if (s2 - s1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        int ns = s1 + nit;
                                        int nrgb = Hsl2Rgb(h1, ns, l1);
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }
                    int r1 = rgb1 % 256;
                    int g1 = (rgb1 / 256) % 256;
                    int b1 = (rgb1 / 256 / 256) % 256;
                    int r2 = rgb2 % 256;
                    int g2 = (rgb2 / 256) % 256;
                    int b2 = (rgb2 / 256 / 256) % 256;

                    int hsl1 = Rgb2Hsl(r1, g1, b1);
                    int hsl2 = Rgb2Hsl(r2, g2, b2);

                    int h1 = hsl1 % 256;
                    int s1 = (hsl1 / 256) % 256;
                    int l1 = (hsl1 / 256 / 256) % 256;
                    int h2 = hsl2 % 256;
                    int s2 = (hsl2 / 256) % 256;
                    int l2 = (hsl2 / 256 / 256) % 256;

                    if (s2 - s1 == 0)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的H值相同，不能进行H补色");
                    }
                    else
                    {
                        if (Math.Abs(s2 - s1) >= count - 2)
                        {
                            int n = (s2 - s1) / (count - 1);
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int ns = s1 + (i - 1) * n;
                                    int nrgb = Hsl2Rgb(h1, ns, l1);
                                    range[i].Fill.ForeColor.RGB = nrgb;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int ns = s1 + (i - 1) * n;
                                    int nrgb = Hsl2Rgb(h1, ns, l1);
                                    range[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                        else
                        {
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (s2 - s1);
                                    if (s2 - s1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(s2 - s1) + 1)
                                    {
                                        nit = i % (s2 - s1);
                                        if (s2 - s1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    int ns = s1 + nit;
                                    int nrgb = Hsl2Rgb(h1, ns, l1);
                                    range[i].Fill.ForeColor.RGB = nrgb;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (s2 - s1);
                                    if (s2 - s1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(s2 - s1) + 1)
                                    {
                                        nit = i % (s2 - s1);
                                        if (s2 - s1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    int ns = s1 + nit;
                                    int nrgb = Hsl2Rgb(h1, ns, l1);
                                    range[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button42_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                int r1 = rgb1 % 256;
                int g1 = (rgb1 / 256) % 256;
                int b1 = (rgb1 / 256 / 256) % 256;
                int r2 = rgb2 % 256;
                int g2 = (rgb2 / 256) % 256;
                int b2 = (rgb2 / 256 / 256) % 256;

                int hsl1 = Rgb2Hsl(r1, g1, b1);
                int hsl2 = Rgb2Hsl(r2, g2, b2);

                int h1 = hsl1 % 256;
                int s1 = (hsl1 / 256) % 256;
                int l1 = (hsl1 / 256 / 256) % 256;
                int h2 = hsl2 % 256;
                int s2 = (hsl2 / 256) % 256;
                int l2 = (hsl2 / 256 / 256) % 256;

                if (l2 - l1 == 0)
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的L值相同，不能进行L补色");
                }
                else
                {
                    if (Math.Abs(l2 - l1) >= count - 2)
                    {
                        int n = (l2 - l1) / (count - 1);
                        for (int i = 2; i < count; i++)
                        {
                            int nl = l1 + (i - 1) * n;
                            int nrgb = Hsl2Rgb(h1, s1, nl);
                            tr.Characters(i).Font.Color.RGB = nrgb;
                        }
                    }
                    else
                    {
                        for (int i = 2; i < count; i++)
                        {
                            int nit = (i - 1) % (l2 - l1);
                            if (l2 - l1 < 0)
                            {
                                nit = -nit;
                            }
                            if (i <= Math.Abs(l2 - l1) + 1)
                            {
                                nit = i % (l2 - l1);
                                if (l2 - l1 < 0)
                                {
                                    nit = -nit;
                                }
                            }
                            int nl = l1 + nit;
                            int nrgb = Hsl2Rgb(h1, s1, nl);
                            tr.Characters(i).Font.Color.RGB = nrgb;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }
                        int r1 = rgb1 % 256;
                        int g1 = (rgb1 / 256) % 256;
                        int b1 = (rgb1 / 256 / 256) % 256;
                        int r2 = rgb2 % 256;
                        int g2 = (rgb2 / 256) % 256;
                        int b2 = (rgb2 / 256 / 256) % 256;

                        int hsl1 = Rgb2Hsl(r1, g1, b1);
                        int hsl2 = Rgb2Hsl(r2, g2, b2);

                        int h1 = hsl1 % 256;
                        int s1 = (hsl1 / 256) % 256;
                        int l1 = (hsl1 / 256 / 256) % 256;
                        int h2 = hsl2 % 256;
                        int s2 = (hsl2 / 256) % 256;
                        int l2 = (hsl2 / 256 / 256) % 256;

                        if (l2 - l1 == 0)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的L值相同，不能进行L补色");
                        }
                        else
                        {
                            if (Math.Abs(l2 - l1) >= count - 2)
                            {
                                int n = (l2 - l1) / (count - 1);
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nl = l1 + (i - 1) * n;
                                        int nrgb = Hsl2Rgb(h1, s1, nl);
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nl = l1 + (i - 1) * n;
                                        int nrgb = Hsl2Rgb(h1, s1, nl);
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                    }
                                }
                            }
                            else
                            {
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (l2 - l1);
                                        if (l2 - l1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(l2 - l1) + 1)
                                        {
                                            nit = i % (l2 - l1);
                                            if (l2 - l1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        int nl = l1 + nit;
                                        int nrgb = Hsl2Rgb(h1, s1, nl);
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (l2 - l1);
                                        if (l2 - l1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(l2 - l1) + 1)
                                        {
                                            nit = i % (l2 - l1);
                                            if (l2 - l1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        int nl = l1 + nit;
                                        int nrgb = Hsl2Rgb(h1, s1, nl);
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }
                    int r1 = rgb1 % 256;
                    int g1 = (rgb1 / 256) % 256;
                    int b1 = (rgb1 / 256 / 256) % 256;
                    int r2 = rgb2 % 256;
                    int g2 = (rgb2 / 256) % 256;
                    int b2 = (rgb2 / 256 / 256) % 256;

                    int hsl1 = Rgb2Hsl(r1, g1, b1);
                    int hsl2 = Rgb2Hsl(r2, g2, b2);

                    int h1 = hsl1 % 256;
                    int s1 = (hsl1 / 256) % 256;
                    int l1 = (hsl1 / 256 / 256) % 256;
                    int h2 = hsl2 % 256;
                    int s2 = (hsl2 / 256) % 256;
                    int l2 = (hsl2 / 256 / 256) % 256;

                    if (l2 - l1 == 0)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的L值相同，不能进行L补色");
                    }
                    else
                    {
                        if (Math.Abs(l2 - l1) >= count - 2)
                        {
                            int n = (l2 - l1) / (count - 1);
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nl = l1 + (i - 1) * n;
                                    int nrgb = Hsl2Rgb(h1, s1, nl);
                                    range[i].Fill.ForeColor.RGB = nrgb;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nl = l1 + (i - 1) * n;
                                    int nrgb = Hsl2Rgb(h1, s1, nl);
                                    range[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                        else
                        {
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (l2 - l1);
                                    if (l2 - l1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(l2 - l1) + 1)
                                    {
                                        nit = i % (l2 - l1);
                                        if (l2 - l1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    int nl = l1 + nit;
                                    int nrgb = Hsl2Rgb(h1, s1, nl);
                                    range[i].Fill.ForeColor.RGB = nrgb;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (l2 - l1);
                                    if (l2 - l1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(l2 - l1) + 1)
                                    {
                                        nit = i % (l2 - l1);
                                        if (l2 - l1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    int nl = l1 + nit;
                                    int nrgb = Hsl2Rgb(h1, s1, nl);
                                    range[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button43_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                int r1 = rgb1 % 256;
                int g1 = (rgb1 / 256) % 256;
                int b1 = (rgb1 / 256 / 256) % 256;
                int r2 = rgb2 % 256;
                int g2 = (rgb2 / 256) % 256;
                int b2 = (rgb2 / 256 / 256) % 256;

                int nr, ng, nb, n1, n2, n3;
                if (r2 == r1 && g2 == g1 && b2 == b1)
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的RGB值相同，不能进行RGB补色");
                }
                else
                {
                    if (Math.Abs(r2 - r1) >= count - 2)
                    {
                        n1 = (r2 - r1) / (count - 1);
                        n2 = (g2 - g1) / (count - 1);
                        n3 = (b2 - b1) / (count - 1);
                               
                        for (int i = 2; i < count; i++)
                        {
                            nr = r1 + (i - 1) * n1;
                            ng = g1 + (i - 1) * n2;
                            nb = b1 + (i - 1) * n3;
                            tr.Characters(i).Font.Color.RGB = nr + ng * 256 + nb * 256 * 256;
                        } 
                    }
                    else
                    {
                        int nit1, nit2, nit3;
                        for (int i = 2; i < count; i++)
                        {
                            if (r2 == r1)
                            {
                                nit1 = 0;
                            }
                            else
                            {
                                nit1 = (i - 1) % (r2 - r1);
                            }
                            if (g2 == g1)
                            {
                                nit2 = 0;
                            }
                            else
                            {
                                nit2 = (i - 1) % (g2 - g1);
                            }
                            if (b2 == b1)
                            {
                                nit3 = 0;
                            }
                            else
                            {
                                nit3 = (i - 1) % (b2 - b1);
                            }

                            if (r2 - r1 < 0)
                            {
                                nit1 = -nit1;
                            }
                            if (i <= Math.Abs(r2 - r1) + 1)
                            {
                                nit1 = i % (r2 - r1);
                                if (r2 - r1 < 0)
                                {
                                    nit1 = -nit1;
                                }
                            }

                            if (g2 - g1 < 0)
                            {
                                nit2 = -nit2;
                            }
                            if (i <= Math.Abs(g2 - g1) + 1)
                            {
                                nit2 = i % (g2 - g1);
                                if (g2 - g1 < 0)
                                {
                                    nit2 = -nit2;
                                }
                            }

                            if (b2 - b1 < 0)
                            {
                                nit3 = -nit3;
                            }
                            if (i <= Math.Abs(b2 - b1) + 1)
                            {
                                nit3 = i % (b2 - b1);
                                if (b2 - b1 < 0)
                                {
                                    nit3 = -nit3;
                                }
                            }

                            nr = r1 + nit1;
                            ng = g1 + nit2;
                            nb = b1 + nit3;
                            tr.Characters(i).Font.Color.RGB = nr + ng * 256 + nb * 256 * 256;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }
                        int r1 = rgb1 % 256;
                        int g1 = (rgb1 / 256) % 256;
                        int b1 = (rgb1 / 256 / 256) % 256;
                        int r2 = rgb2 % 256;
                        int g2 = (rgb2 / 256) % 256;
                        int b2 = (rgb2 / 256 / 256) % 256;

                        int nr, ng, nb, n1, n2, n3;
                        if (r2 == r1 && g2 == g1 && b2 == b1)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的RGB值相同，不能进行RGB补色");
                        }
                        else
                        {
                            if (Math.Abs(r2 - r1) >= count - 2)
                            {
                                n1 = (r2 - r1) / (count - 1);
                                n2 = (g2 - g1) / (count - 1);
                                n3 = (b2 - b1) / (count - 1);
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        nr = r1 + (i - 1) * n1;
                                        ng = g1 + (i - 1) * n2;
                                        nb = b1 + (i - 1) * n3;
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nr + ng * 256 + nb * 256 * 256;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        nr = r1 + (i - 1) * n1;
                                        ng = g1 + (i - 1) * n2;
                                        nb = b1 + (i - 1) * n3;
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nr + ng * 256 + nb * 256 * 256;
                                    }
                                }
                            }
                            else
                            {
                                int nit1, nit2, nit3;
                                for (int i = 2; i < count; i++)
                                {
                                    if (r2 == r1)
                                    {
                                        nit1 = 0;
                                    }
                                    else
                                    {
                                        nit1 = (i - 1) % (r2 - r1);
                                    }
                                    if (g2 == g1)
                                    {
                                        nit2 = 0;
                                    }
                                    else
                                    {
                                        nit2 = (i - 1) % (g2 - g1);
                                    }
                                    if (b2 == b1)
                                    {
                                        nit3 = 0;
                                    }
                                    else
                                    {
                                        nit3 = (i - 1) % (b2 - b1);
                                    }

                                    if (r2 - r1 < 0)
                                    {
                                        nit1 = -nit1;
                                    }
                                    if (i <= Math.Abs(r2 - r1) + 1)
                                    {
                                        nit1 = i % (r2 - r1);
                                        if (r2 - r1 < 0)
                                        {
                                            nit1 = -nit1;
                                        }
                                    }

                                    if (g2 - g1 < 0)
                                    {
                                        nit2 = -nit2;
                                    }
                                    if (i <= Math.Abs(g2 - g1) + 1)
                                    {
                                        nit2 = i % (g2 - g1);
                                        if (g2 - g1 < 0)
                                        {
                                            nit2 = -nit2;
                                        }
                                    }

                                    if (b2 - b1 < 0)
                                    {
                                        nit3 = -nit3;
                                    }
                                    if (i <= Math.Abs(b2 - b1) + 1)
                                    {
                                        nit3 = i % (b2 - b1);
                                        if (b2 - b1 < 0)
                                        {
                                            nit3 = -nit3;
                                        }
                                    }

                                    nr = r1 + nit1;
                                    ng = g1 + nit2;
                                    nb = b1 + nit3;
                                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                    {
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nr + ng * 256 + nb * 256 * 256;
                                    }
                                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                    {
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nr + ng * 256 + nb * 256 * 256;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }
                    int r1 = rgb1 % 256;
                    int g1 = (rgb1 / 256) % 256;
                    int b1 = (rgb1 / 256 / 256) % 256;
                    int r2 = rgb2 % 256;
                    int g2 = (rgb2 / 256) % 256;
                    int b2 = (rgb2 / 256 / 256) % 256;

                    int nr, ng, nb, n1, n2, n3;
                    if (r2 == r1 && g2 == g1 && b2 == b1)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的RGB值相同，不能进行RGB补色");
                    }
                    else
                    {
                        if (Math.Abs(r2 - r1) >= count - 2)
                        {
                            n1 = (r2 - r1) / (count - 1);
                            n2 = (g2 - g1) / (count - 1);
                            n3 = (b2 - b1) / (count - 1);
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    nr = r1 + (i - 1) * n1;
                                    ng = g1 + (i - 1) * n2;
                                    nb = b1 + (i - 1) * n3;
                                    range[i].Fill.ForeColor.RGB = nr + ng * 256 + nb * 256 * 256;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    nr = r1 + (i - 1) * n1;
                                    ng = g1 + (i - 1) * n2;
                                    nb = b1 + (i - 1) * n3;
                                    range[i].Line.ForeColor.RGB = nr + ng * 256 + nb * 256 * 256;
                                }
                            }
                        }
                        else
                        {
                            int nit1, nit2, nit3;
                            for (int i = 2; i < count; i++)
                            {
                                if (r2 == r1)
                                {
                                    nit1 = 0;
                                }
                                else
                                {
                                    nit1 = (i - 1) % (r2 - r1);
                                }
                                if (g2 == g1)
                                {
                                    nit2 = 0;
                                }
                                else
                                {
                                    nit2 = (i - 1) % (g2 - g1);
                                }
                                if (b2 == b1)
                                {
                                    nit3 = 0;
                                }
                                else
                                {
                                    nit3 = (i - 1) % (b2 - b1);
                                }

                                if (r2 - r1 < 0)
                                {
                                    nit1 = -nit1;
                                }
                                if (i <= Math.Abs(r2 - r1) + 1)
                                {
                                    nit1 = i % (r2 - r1);
                                    if (r2 - r1 < 0)
                                    {
                                        nit1 = -nit1;
                                    }
                                }

                                if (g2 - g1 < 0)
                                {
                                    nit2 = -nit2;
                                }
                                if (i <= Math.Abs(g2 - g1) + 1)
                                {
                                    nit2 = i % (g2 - g1);
                                    if (g2 - g1 < 0)
                                    {
                                        nit2 = -nit2;
                                    }
                                }

                                if (b2 - b1 < 0)
                                {
                                    nit3 = -nit3;
                                }
                                if (i <= Math.Abs(b2 - b1) + 1)
                                {
                                    nit3 = i % (b2 - b1);
                                    if (b2 - b1 < 0)
                                    {
                                        nit3 = -nit3;
                                    }
                                }

                                nr = r1 + nit1;
                                ng = g1 + nit2;
                                nb = b1 + nit3;
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    range[i].Fill.ForeColor.RGB = nr + ng * 256 + nb * 256 * 256;
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    range[i].Line.ForeColor.RGB = nr + ng * 256 + nb * 256 * 256;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button44_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                int r1 = rgb1 % 256;
                int g1 = (rgb1 / 256) % 256;
                int b1 = (rgb1 / 256 / 256) % 256;
                int r2 = rgb2 % 256;

                if (r2 - r1 == 0)
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的R值相同，不能进行R补色");
                }
                else
                {
                    if (Math.Abs(r2 - r1) >= count - 2)
                    {
                        int n = (r2 - r1) / (count - 1);
                        for (int i = 2; i < count; i++)
                        {
                            int nr = r1 + (i - 1) * n;
                            tr.Characters(i).Font.Color.RGB = nr + g1 * 256 + b1 * 256 * 256;
                        }
                    }
                    else
                    {
                        for (int i = 2; i < count; i++)
                        {
                            int nit = (i - 1) % (r2 - r1);
                            if (r2 - r1 < 0)
                            {
                                nit = -nit;
                            }
                            if (i <= Math.Abs(r2 - r1) + 1)
                            {
                                nit = i % (r2 - r1);
                                if (r2 - r1 < 0)
                                {
                                    nit = -nit;
                                }
                            }
                            int nr = r1 + nit;
                            tr.Characters(i).Font.Color.RGB = nr + g1 * 256 + b1 * 256 * 256;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count, nr;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }
                        int r1 = rgb1 % 256;
                        int g = (rgb1 / 256) % 256;
                        int b = (rgb1 / 256 / 256) % 256;
                        int r2 = rgb2 % 256;

                        if (r2 - r1 == 0)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的R值相同，不能进行R补色");
                        }
                        else
                        {
                            if (Math.Abs(r2 - r1) >= count - 2)
                            {
                                int n = (r2 - r1) / (count - 1);
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        nr = r1 + (i - 1) * n;
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nr + g * 256 + b * 256 * 256;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        nr = r1 + (i - 1) * n;
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nr + g * 256 + b * 256 * 256;
                                    }
                                }
                            }
                            else
                            {
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (r2 - r1);
                                        if (r2 - r1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(r2 - r1) + 1)
                                        {
                                            nit = i % (r2 - r1);
                                            if (r2 - r1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        nr = r1 + nit;
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = nr + g * 256 + b * 256 * 256;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (r2 - r1);
                                        if (r2 - r1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(r2 - r1) + 1)
                                        {
                                            nit = i % (r2 - r1);
                                            if (r2 - r1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        nr = r1 + nit;
                                        range[1].GroupItems[i].Line.ForeColor.RGB = nr + g * 256 + b * 256 * 256;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }
                    int r1 = rgb1 % 256;
                    int g = (rgb1 / 256) % 256;
                    int b = (rgb1 / 256 / 256) % 256;
                    int r2 = rgb2 % 256;

                    if (r2 - r1 == 0)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的R值相同，不能进行R补色");
                    }
                    else
                    {
                        if (Math.Abs(r2 - r1) >= count - 2)
                        {
                            int n = (r2 - r1) / (count - 1);
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    nr = r1 + (i - 1) * n;
                                    range[i].Fill.ForeColor.RGB = nr + g * 256 + b * 256 * 256;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    nr = r1 + (i - 1) * n;
                                    range[i].Line.ForeColor.RGB = nr + g * 256 + b * 256 * 256;
                                }
                            }
                        }
                        else
                        {
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (r2 - r1);
                                    if (r2 - r1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(r2 - r1) + 1)
                                    {
                                        nit = i % (r2 - r1);
                                        if (r2 - r1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    nr = r1 + nit;
                                    range[i].Fill.ForeColor.RGB = nr + g * 256 + b * 256 * 256;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (r2 - r1);
                                    if (r2 - r1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(r2 - r1) + 1)
                                    {
                                        nit = i % (r2 - r1);
                                        if (r2 - r1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    nr = r1 + nit;
                                    range[i].Line.ForeColor.RGB = nr + g * 256 + b * 256 * 256;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button45_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                int r1 = rgb1 % 256;
                int g1 = (rgb1 / 256) % 256;
                int b1 = (rgb1 / 256 / 256) % 256;
                int g2 = (rgb2 / 256) % 256;

                if (g2 - g1 == 0)
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的G值相同，不能进行G补色");
                }
                else
                {
                    if (Math.Abs(g2 - g1) >= count - 2)
                    {
                        int n = (g2 - g1) / (count - 1);
                        for (int i = 2; i < count; i++)
                        {
                            int ng = g1 + (i - 1) * n;
                            tr.Characters(i).Font.Color.RGB = r1 + ng * 256 + b1 * 256 * 256;
                        }
                    }
                    else
                    {
                        for (int i = 2; i < count; i++)
                        {
                            int nit = (i - 1) % (g2 - g1);
                            if (g2 - g1 < 0)
                            {
                                nit = -nit;
                            }
                            if (i <= Math.Abs(g2 - g1) + 1)
                            {
                                nit = i % (g2 - g1);
                                if (g2 - g1 < 0)
                                {
                                    nit = -nit;
                                }
                            }
                            int ng = g1 + nit;
                            tr.Characters(i).Font.Color.RGB = r1 + ng * 256 + b1 * 256 * 256;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count, ng;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }
                        int r = rgb1 % 256;
                        int g1 = (rgb1 / 256) % 256;
                        int b = (rgb1 / 256 / 256) % 256;
                        int g2 = (rgb2 / 256) % 256;

                        if (g2 == g1)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的G值相同，不能进行G补色");
                        }
                        else
                        {
                            if (Math.Abs(g2 - g1) >= count - 2)
                            {
                                int n = (g2 - g1) / (count - 1);
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        ng = g1 + (i - 1) * n;
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = r + ng * 256 + b * 256 * 256;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        ng = g1 + (i - 1) * n;
                                        range[1].GroupItems[i].Line.ForeColor.RGB = r + ng * 256 + b * 256 * 256;
                                    }
                                }
                            }
                            else
                            {
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (g2 - g1);
                                        if (g2 - g1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(g2 - g1) + 1)
                                        {
                                            nit = i % (g2 - g1);
                                            if (g2 - g1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        ng = g1 + nit;
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = r + ng * 256 + b * 256 * 256;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (g2 - g1);
                                        if (g2 - g1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(g2 - g1) + 1)
                                        {
                                            nit = i % (g2 - g1);
                                            if (g2 - g1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        ng = g1 + nit;
                                        range[1].GroupItems[i].Line.ForeColor.RGB = r + ng * 256 + b * 256 * 256;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }
                    int r = rgb1 % 256;
                    int g1 = (rgb1 / 256) % 256;
                    int b = (rgb1 / 256 / 256) % 256;
                    int g2 = (rgb2 / 256) % 256;

                    if (g2 == g1)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的G值相同，不能进行G补色");
                    }
                    else
                    {
                        if (Math.Abs(g2 - g1) >= count - 2)
                        {
                            int n = (g2 - g1) / (count - 1);
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    ng = g1 + (i - 1) * n;
                                    range[i].Fill.ForeColor.RGB = r + ng * 256 + b * 256 * 256;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    ng = g1 + (i - 1) * n;
                                    range[i].Line.ForeColor.RGB = r + ng * 256 + b * 256 * 256;
                                }
                            }
                        }
                        else
                        {
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (g2 - g1);
                                    if (g2 - g1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(g2 - g1) + 1)
                                    {
                                        nit = i % (g2 - g1);
                                        if (g2 - g1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    ng = g1 + nit;
                                    range[i].Fill.ForeColor.RGB = r + ng * 256 + b * 256 * 256;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (g2 - g1);
                                    if (g2 - g1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(g2 - g1) + 1)
                                    {
                                        nit = i % (g2 - g1);
                                        if (g2 - g1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    ng = g1 + nit;
                                    range[i].Line.ForeColor.RGB = r + ng * 256 + b * 256 * 256;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button46_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                int r1 = rgb1 % 256;
                int g1 = (rgb1 / 256) % 256;
                int b1 = (rgb1 / 256 / 256) % 256;
                int b2 = (rgb2 / 256 / 256) % 256;

                if (b2 - b1 == 0)
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的B值相同，不能进行B补色");
                }
                else
                {
                    if (Math.Abs(b2 - b1) >= count - 2)
                    {
                        int n = (b2 - b1) / (count - 1);
                        for (int i = 2; i < count; i++)
                        {
                            int nb = b1 + (i - 1) * n;
                            tr.Characters(i).Font.Color.RGB = r1 + g1 * 256 + nb * 256 * 256;
                        }
                    }
                    else
                    {
                        for (int i = 2; i < count; i++)
                        {
                            int nit = (i - 1) % (b2 - b1);
                            if (b2 - b1 < 0)
                            {
                                nit = -nit;
                            }
                            if (i <= Math.Abs(b2 - b1) + 1)
                            {
                                nit = i % (b2 - b1);
                                if (b2 - b1 < 0)
                                {
                                    nit = -nit;
                                }
                            }
                            int nb = b1 + nit;
                            tr.Characters(i).Font.Color.RGB = r1 + g1 * 256 + nb * 256 * 256;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count, nb;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }
                        int r = rgb1 % 256;
                        int g = (rgb1 / 256) % 256;
                        int b1 = (rgb1 / 256 / 256) % 256;
                        int b2 = (rgb2 / 256 / 256) % 256;

                        if (b2 == b1)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的B值相同，不能进行B补色");
                        }
                        else
                        {
                            if (Math.Abs(b2 - b1) >= count - 2)
                            {
                                int n = (b2 - b1) / (count - 1);
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        nb = b1 + (i - 1) * n;
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = r + g * 256 + nb * 256 * 256;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        nb = b1 + (i - 1) * n;
                                        range[1].GroupItems[i].Line.ForeColor.RGB = r + g * 256 + nb * 256 * 256;
                                    }
                                }
                            }
                            else
                            {
                                if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (b2 - b1);
                                        if (b2 - b1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(b2 - b1) + 1)
                                        {
                                            nit = i % (b2 - b1);
                                            if (b2 - b1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        nb = b1 + nit;
                                        range[1].GroupItems[i].Fill.ForeColor.RGB = r + g * 256 + nb * 256 * 256;
                                    }
                                }
                                else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                                {
                                    for (int i = 2; i < count; i++)
                                    {
                                        int nit = (i - 1) % (b2 - b1);
                                        if (b2 - b1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                        if (i <= Math.Abs(b2 - b1) + 1)
                                        {
                                            nit = i % (b2 - b1);
                                            if (b2 - b1 < 0)
                                            {
                                                nit = -nit;
                                            }
                                        }
                                        nb = b1 + nit;
                                        range[1].GroupItems[i].Line.ForeColor.RGB = r + g * 256 + nb * 256 * 256;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }
                    int r = rgb1 % 256;
                    int g = (rgb1 / 256) % 256;
                    int b1 = (rgb1 / 256 / 256) % 256;
                    int b2 = (rgb2 / 256 / 256) % 256;

                    if (b2 == b1)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的B值相同，不能进行B补色");
                    }
                    else
                    {
                        if (Math.Abs(b2 - b1) >= count - 2)
                        {
                            int n = (b2 - b1) / (count - 1);
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    nb = b1 + (i - 1) * n;
                                    range[i].Fill.ForeColor.RGB = r + g * 256 + nb * 256 * 256;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    nb = b1 + (i - 1) * n;
                                    range[i].Line.ForeColor.RGB = r + g * 256 + nb * 256 * 256;
                                }
                            }
                        }
                        else
                        {
                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (b2 - b1);
                                    if (b2 - b1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(b2 - b1) + 1)
                                    {
                                        nit = i % (b2 - b1);
                                        if (b2 - b1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    nb = b1 + nit;
                                    range[i].Fill.ForeColor.RGB = r + g * 256 + nb * 256 * 256;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nit = (i - 1) % (b2 - b1);
                                    if (b2 - b1 < 0)
                                    {
                                        nit = -nit;
                                    }
                                    if (i <= Math.Abs(b2 - b1) + 1)
                                    {
                                        nit = i % (b2 - b1);
                                        if (b2 - b1 < 0)
                                        {
                                            nit = -nit;
                                        }
                                    }
                                    nb = b1 + nit;
                                    range[i].Line.ForeColor.RGB = r + g * 256 + nb * 256 * 256;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button47_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中至少一个图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    range[i].ThreeD.Visible = Office.MsoTriState.msoFalse;
                    range[i].ThreeD.BevelBottomType = Office.MsoBevelType.msoBevelNone;
                    range[i].ThreeD.BevelTopType = Office.MsoBevelType.msoBevelNone;
                    range[i].ThreeD.ContourWidth = 0;
                    range[i].ThreeD.Depth = 0;
                    range[i].ThreeD.ResetRotation();
                }
            }
        }

        public void button48_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中一个图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    float nw = range[i].Width / 2;
                    float nh = range[i].Height / 2;
                    float min = Math.Min(nw, nh);
                    range[i].ThreeD.BevelBottomType = Office.MsoBevelType.msoBevelCircle;
                    range[i].ThreeD.BevelBottomDepth = min;
                    range[i].ThreeD.BevelBottomInset = min;
                    range[i].ThreeD.BevelTopType = Office.MsoBevelType.msoBevelCircle;
                    range[i].ThreeD.BevelTopDepth = min;
                    range[i].ThreeD.BevelTopInset = min;
                    if (range[i].ThreeD.RotationX == 0 && range[i].ThreeD.RotationY == 0 && range[i].ThreeD.RotationZ == 0)
                    {
                        range[i].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                        range[i].ThreeD.FieldOfView = 45;
                        range[i].ThreeD.RotationX = 350;
                        range[i].ThreeD.RotationY = 10;
                        range[i].ThreeD.RotationZ = 0;
                    }
                    range[i].ThreeD.Z = min;
                }
            }
        }

        public void button49_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中一个图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    float nw = range[i].Width / 2;
                    float nh = range[i].Height / 2;
                    float min = Math.Min(nw, nh);
                    range[i].ThreeD.BevelBottomDepth = min;
                    range[i].ThreeD.BevelBottomInset = 0;
                    range[i].ThreeD.BevelTopDepth = min;
                    range[i].ThreeD.BevelTopInset = 0;
                    if (range[i].ThreeD.RotationX == 0 && range[i].ThreeD.RotationY == 0 && range[i].ThreeD.RotationZ == 0)
                    {
                        range[i].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                        range[i].ThreeD.FieldOfView = 45;
                        range[i].ThreeD.RotationX = 350;
                        range[i].ThreeD.RotationY = 10;
                        range[i].ThreeD.RotationZ = 0;
                    }
                    range[i].ThreeD.Z = min;
                }
            }
        }

        public void button50_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || (sel.ShapeRange.Count != 6 && sel.ShapeRange.Count != 3))
            {
                MessageBox.Show("沙漪立方拼需要6个或3个正方形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;

                range.Align(Office.MsoAlignCmd.msoAlignCenters, Office.MsoTriState.msoFalse);
                range.Align(Office.MsoAlignCmd.msoAlignMiddles, Office.MsoTriState.msoFalse);
                range[1].ZOrder(Office.MsoZOrderCmd.msoBringToFront);
                range[2].ZOrder(Office.MsoZOrderCmd.msoBringToFront);
                range[3].ZOrder(Office.MsoZOrderCmd.msoSendToBack);
                int count = range.Count;
                if (count == 6)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        range[i].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                        range[i].ThreeD.FieldOfView = 45;
                        range[i].ThreeD.RotationX = 0 + 90 * (i - 1);
                        range[i].ThreeD.RotationY = 0;
                        range[i].ThreeD.RotationZ = 0;
                        range[i].ThreeD.Z = range[i].Width / 2;
                    }
                    for (int j = 5; j <= 6; j++)
                    {
                        range[j].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                        range[j].ThreeD.FieldOfView = 45;
                        range[j].ThreeD.RotationX = 0;
                        range[j].ThreeD.RotationY = 270 - 180 * (j - 5);
                        range[j].ThreeD.RotationZ = 0;
                        range[j].ThreeD.Z = range[j].Width / 2;
                    }
                }
                if (count == 3)
                {
                    range[1].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                    range[1].ThreeD.FieldOfView = 45;
                    range[1].ThreeD.RotationX = 0;
                    range[1].ThreeD.RotationY = 0;
                    range[1].ThreeD.RotationZ = 0;
                    range[1].ThreeD.Z = range[2].Width / 2;

                    range[2].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                    range[2].ThreeD.FieldOfView = 45;
                    range[2].ThreeD.RotationX = 90;
                    range[2].ThreeD.RotationY = 0;
                    range[2].ThreeD.RotationZ = 0;
                    range[2].ThreeD.Z = range[1].Width / 2;

                    range[3].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                    range[3].ThreeD.FieldOfView = 45;
                    range[3].ThreeD.RotationX = 0;
                    range[3].ThreeD.RotationY = 270;
                    range[3].ThreeD.RotationZ = 0;
                    range[3].ThreeD.Z = range[1].Height / 2;
                }
            }
        }

        public void button51_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中一个图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    int sid = app.ActiveWindow.Selection.SlideRange.SlideNumber;
                    PowerPoint.Shape sh = range[i];
                    PowerPoint.Shape bw = app.ActivePresentation.Slides[sid].Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, sh.Left - sh.Width / 2, sh.Top, sh.Width * 2, sh.Height);
                    bw.Fill.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    bw.Fill.Transparency = 1.0f;
                    bw.Line.Visible = Office.MsoTriState.msoFalse;
                    bw.ZOrder(Office.MsoZOrderCmd.msoSendToBack);
                    if (!sel.HasChildShapeRange)
                    {
                        PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                        string[] arr = new string[2];
                        arr[0] = sh.Name;
                        arr[1] = bw.Name;
                        slide.Shapes.Range(arr).Group().Select();
                    }
                    else
                    {
                        bw.Select();
                    }
                }
            }
        }

        public void button52_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中一个图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    int sid = app.ActiveWindow.Selection.SlideRange.SlideNumber;
                    PowerPoint.Shape sh = range[i];
                    PowerPoint.Shape bw = app.ActivePresentation.Slides[sid].Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, sh.Left, sh.Top - sh.Height / 2, sh.Width, sh.Height * 2);
                    bw.Fill.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    bw.Fill.Transparency = 1.0f;
                    bw.Line.Visible = Office.MsoTriState.msoFalse;
                    bw.ZOrder(Office.MsoZOrderCmd.msoSendToBack);
                    if (!sel.HasChildShapeRange)
                    {
                        PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                        string[] arr = new string[2];
                        arr[0] = sh.Name;
                        arr[1] = bw.Name;
                        slide.Shapes.Range(arr).Group().Select();
                    }
                    else
                    {
                        bw.Select();
                    }
                }
            }
        }

        public void button53_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("什么都没选呢");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    float RX = range[i].ThreeD.RotationX;
                    float RY = range[i].ThreeD.RotationY;
                    float RZ = range[i].ThreeD.RotationZ;
                    range[i].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                    range[i].ThreeD.FieldOfView = 45;
                    range[i].ThreeD.RotationX = RX;
                    range[i].ThreeD.RotationY = RY;
                    range[i].ThreeD.RotationZ = RZ;
                }
            }
        }

        public void button54_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange[1].ThreeD.Visible == Office.MsoTriState.msoFalse || sel.ShapeRange.Count <= 1)
            {
                MessageBox.Show("选中的第一个图形需设置三维效果，其他形状复制该效果");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                PowerPoint.Shape tshape = range[1];
                int count = range.Count;
                for (int i = 2; i <= count; i++)
                {
                    range[i].ThreeD.Visible = Office.MsoTriState.msoTrue;

                    range[i].ThreeD.SetPresetCamera(tshape.ThreeD.PresetCamera);
                    range[i].ThreeD.FieldOfView = tshape.ThreeD.FieldOfView;
                    range[i].ThreeD.RotationX = tshape.ThreeD.RotationX;
                    range[i].ThreeD.RotationY = tshape.ThreeD.RotationY;
                    range[i].ThreeD.RotationZ = tshape.ThreeD.RotationZ;
                    range[i].ThreeD.Z = tshape.ThreeD.Z;

                    if (tshape.ThreeD.PresetMaterial == Office.MsoPresetMaterial.msoPresetMaterialMixed)
                    {
                        MessageBox.Show("形状没有三维格式");
                    }
                    else
                    {
                        range[i].ThreeD.BevelBottomType = tshape.ThreeD.BevelBottomType;
                        range[i].ThreeD.BevelBottomDepth = tshape.ThreeD.BevelBottomDepth;
                        range[i].ThreeD.BevelBottomInset = tshape.ThreeD.BevelBottomInset;
                        range[i].ThreeD.BevelTopType = tshape.ThreeD.BevelTopType;
                        range[i].ThreeD.BevelTopDepth = tshape.ThreeD.BevelTopDepth;
                        range[i].ThreeD.BevelTopInset = tshape.ThreeD.BevelTopInset;

                        range[i].ThreeD.ExtrusionColor.RGB = tshape.ThreeD.ExtrusionColor.RGB;
                        range[i].ThreeD.ExtrusionColorType = tshape.ThreeD.ExtrusionColorType;
                        range[i].ThreeD.PresetMaterial = tshape.ThreeD.PresetMaterial;
                        range[i].ThreeD.PresetLighting = tshape.ThreeD.PresetLighting;
                        range[i].ThreeD.LightAngle = tshape.ThreeD.LightAngle;

                        if (tshape.ThreeD.Depth == 0)
                        {
                            range[i].ThreeD.Depth = 0;
                        }
                        else
                        {
                            range[i].ThreeD.Depth = tshape.ThreeD.Depth;
                        }
                        if (tshape.ThreeD.ContourWidth == 0)
                        {
                            range[i].ThreeD.ContourWidth = 0;
                        }
                        else
                        {
                            range[i].ThreeD.ContourWidth = tshape.ThreeD.ContourWidth;
                            range[i].ThreeD.ContourColor.RGB = tshape.ThreeD.ContourColor.RGB;
                        }

                        if (tshape.ThreeD.Depth == 0)
                        {
                            range[i].ThreeD.Depth = 0;
                        }
                        else
                        {
                            range[i].ThreeD.Depth = tshape.ThreeD.Depth;
                        }
                    }
                }
            }
        }

        public void button55_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange[1].ThreeD.Visible == Office.MsoTriState.msoFalse || sel.ShapeRange.Count <= 1)
            {
                MessageBox.Show("先选中设置了3D旋转的图形，再同时选中要套用的图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                PowerPoint.Shape tshape = range[1];
                int count = range.Count;
                for (int i = 2; i <= count; i++)
                {
                    range[i].ThreeD.SetPresetCamera(tshape.ThreeD.PresetCamera);
                    range[i].ThreeD.FieldOfView = tshape.ThreeD.FieldOfView;
                    range[i].ThreeD.RotationX = tshape.ThreeD.RotationX;
                    range[i].ThreeD.RotationY = tshape.ThreeD.RotationY;
                    range[i].ThreeD.RotationZ = tshape.ThreeD.RotationZ;
                    range[i].ThreeD.Z = tshape.ThreeD.Z;
                }
            }
        }

        public void button56_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.ThreeD.Visible == Office.MsoTriState.msoFalse || sel.ShapeRange.Count <= 1)
            {
                MessageBox.Show("先选中设置了3D格式的图形，再同时选中要套用的图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                PowerPoint.Shape tshape = range[1];
                int count = range.Count;
                for (int i = 2; i <= count; i++)
                {
                    if (tshape.ThreeD.PresetMaterial == Office.MsoPresetMaterial.msoPresetMaterialMixed)
                    {
                        MessageBox.Show("形状没有三维格式");
                    }
                    else
                    {
                        range[i].ThreeD.BevelBottomType = tshape.ThreeD.BevelBottomType;
                        range[i].ThreeD.BevelBottomDepth = tshape.ThreeD.BevelBottomDepth;
                        range[i].ThreeD.BevelBottomInset = tshape.ThreeD.BevelBottomInset;
                        range[i].ThreeD.BevelTopType = tshape.ThreeD.BevelTopType;
                        range[i].ThreeD.BevelTopDepth = tshape.ThreeD.BevelTopDepth;
                        range[i].ThreeD.BevelTopInset = tshape.ThreeD.BevelTopInset;
                        range[i].ThreeD.ExtrusionColor.RGB = tshape.ThreeD.ExtrusionColor.RGB;
                        range[i].ThreeD.ExtrusionColorType = tshape.ThreeD.ExtrusionColorType;
                        range[i].ThreeD.PresetMaterial = tshape.ThreeD.PresetMaterial;
                        range[i].ThreeD.PresetLighting = tshape.ThreeD.PresetLighting;
                        range[i].ThreeD.LightAngle = tshape.ThreeD.LightAngle;
                        if (tshape.ThreeD.Depth == 0)
                        {
                            range[i].ThreeD.Depth = 0;
                        }
                        else
                        {
                            range[i].ThreeD.Depth = tshape.ThreeD.Depth;
                        }
                        if (tshape.ThreeD.ContourWidth == 0)
                        {
                            range[i].ThreeD.ContourWidth = 0;
                        }
                        else
                        {
                            range[i].ThreeD.ContourWidth = tshape.ThreeD.ContourWidth;
                            range[i].ThreeD.ContourColor.RGB = tshape.ThreeD.ContourColor.RGB;
                        }
                        if (tshape.ThreeD.Depth == 0)
                        {
                            range[i].ThreeD.Depth = 0;
                        }
                        else
                        {
                            range[i].ThreeD.Depth = tshape.ThreeD.Depth;
                        }
                    }
                }
            }
        }

        public void button57_Click(object sender, RibbonControlEventArgs e)
        {
            ThreeD_Copy ThreeDcopy = null;
            if (ThreeDcopy == null || ThreeDcopy.IsDisposed)
            {
                ThreeDcopy = new ThreeD_Copy();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                ThreeDcopy.Show();
                button57.Enabled = false;
            }
        }

        public void splitButton7_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中元素或幻灯片，且做好备份！");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                foreach (PowerPoint.Shape item in range)
                {
                    item.Copy();
                    PowerPoint.Shape pic = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                    pic.ScaleHeight(1f, Office.MsoTriState.msoTrue, Office.MsoScaleFrom.msoScaleFromMiddle);
                    pic.Left = item.Left + item.Width / 2 - pic.Width / 2;
                    pic.Top = item.Top + item.Height / 2 - pic.Height / 2;
                    item.Delete();
                    pic.Select();
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange sliderange = sel.SlideRange;
                foreach (PowerPoint.Slide item in sliderange)
                {
                    for (int i = item.Shapes.Count; i >= 1; i--)
                    {
                        item.Shapes[i].Copy();
                        PowerPoint.Shape pic = item.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                        pic.ScaleHeight(1f, Office.MsoTriState.msoTrue, Office.MsoScaleFrom.msoScaleFromMiddle);
                        pic.Left = item.Shapes[i].Left + item.Shapes[i].Width / 2 - pic.Width / 2;
                        pic.Top = item.Shapes[i].Top + item.Shapes[i].Height / 2 - pic.Height / 2;
                        item.Shapes[i].Delete();
                    }
                }
                MessageBox.Show("已将所选页面中的所有元素转为png图片");
            }
        }

        public void button58_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中元素或幻灯片，且做好备份！");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                foreach (PowerPoint.Shape item in range)
                {
                    item.Copy();
                    PowerPoint.Shape pic = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                    pic.ScaleHeight(1f, Office.MsoTriState.msoTrue, Office.MsoScaleFrom.msoScaleFromMiddle);
                    pic.Left = item.Left + item.Width / 2 - pic.Width / 2;
                    pic.Top = item.Top + item.Height / 2 - pic.Height / 2;
                    item.Delete();
                    pic.Select();
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange sliderange = sel.SlideRange;
                foreach (PowerPoint.Slide item in sliderange)
                {
                    for (int i = item.Shapes.Count; i >= 1; i--)
                    {
                        item.Shapes[i].Copy();
                        PowerPoint.Shape pic = item.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                        pic.ScaleHeight(1f, Office.MsoTriState.msoTrue, Office.MsoScaleFrom.msoScaleFromMiddle);
                        pic.Left = item.Shapes[i].Left + item.Shapes[i].Width / 2 - pic.Width / 2;
                        pic.Top = item.Shapes[i].Top + item.Shapes[i].Height / 2 - pic.Height / 2;
                        item.Shapes[i].Delete();
                    }
                }
                MessageBox.Show("已将所选页面中的所有元素转为png图片");
            }
        }

        public void button59_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中元素或幻灯片，且做好备份！");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                foreach (PowerPoint.Shape item in range)
                {
                    item.Copy();
                    PowerPoint.Shape pic = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPasteJPG)[1];
                    pic.ScaleHeight(1f, Office.MsoTriState.msoTrue, Office.MsoScaleFrom.msoScaleFromMiddle);
                    pic.Left = item.Left + item.Width / 2 - pic.Width / 2;
                    pic.Top = item.Top + item.Height / 2 - pic.Height / 2;
                    item.Delete();
                    pic.Select();
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange sliderange = sel.SlideRange;
                foreach (PowerPoint.Slide item in sliderange)
                {
                    for (int i = item.Shapes.Count; i >= 1; i--)
                    {
                        item.Shapes[i].Copy();
                        PowerPoint.Shape pic = item.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPasteJPG)[1];
                        pic.ScaleHeight(1f, Office.MsoTriState.msoTrue, Office.MsoScaleFrom.msoScaleFromMiddle);
                        pic.Left = item.Shapes[i].Left + item.Shapes[i].Width / 2 - pic.Width / 2;
                        pic.Top = item.Shapes[i].Top + item.Shapes[i].Height / 2 - pic.Height / 2;
                        if (!sel.HasChildShapeRange)
                        {
                            item.Shapes[i].Delete();
                        }
                    }
                }
                MessageBox.Show("已将所选页面中的所有元素转为jpg图片");
            }
        }

        public void button60_Click(object sender, RibbonControlEventArgs e)
        {
            GIFTools GIFTools = null;
            if (GIFTools == null || GIFTools.IsDisposed)
            {
                GIFTools = new GIFTools();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                GIFTools.Show();
                button60.Enabled = false;
            }
        }

        public void button61_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("可选中形状和图片元素导出为PNG；选中多页幻灯片，只导出其中的图片元素");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的元素\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                    int k = dir.GetFiles().Length + (i - i + 1);
                    string shname = name + "_" + k;
                    shape.Export(cPath + shname + ".png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的元素\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }

                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        PowerPoint.Shape shape = item.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoPicture)
                        {
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                            int k = dir.GetFiles().Length + (i - i + 1);
                            string shname = name + "_" + k;
                            shape.Export(cPath + shname + ".png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        }
                    }
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
        }

        public void button62_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中一个矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    shape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalUp, 1, 1.0f);
                    shape.Fill.GradientStops.Insert2(255 + 255 * 256 + 255 * 256 * 256, 0.8f, 0f, 1, 1.0f);
                    shape.Fill.GradientStops[1].Color.RGB = 191 + 191 * 256 + 191 * 256 * 256;
                    shape.Fill.GradientStops[2].Color.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    shape.Fill.GradientStops[1].Position = 0.2f;
                    shape.Fill.GradientStops[2].Position = 0.8f;
                    shape.Line.Visible = Office.MsoTriState.msoTrue;
                    shape.Line.ForeColor.RGB = 242 + 242 * 256 + 242 * 256 * 256;
                    shape.Line.Weight = 2.25f;
                    shape.Shadow.Style = Office.MsoShadowStyle.msoShadowStyleOuterShadow;
                    shape.Shadow.ForeColor.RGB = 0 + 0 * 256 + 0 * 256 * 256;
                    shape.Shadow.Transparency = 0.77f;
                    shape.Shadow.Blur = 7;
                    shape.Shadow.OffsetX = 4.2f;
                    shape.Shadow.OffsetY = 4.2f;
                    shape.TextFrame.TextRange.Font.Color.RGB = 0 + 0 + 0;
                }
            }
        }

        public void button63_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中一张图片");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoPicture)
                    {
                        if (range[i].Fill.PictureEffects.Count != 0)
                        {
                            int en = -1;
                            for (int j = 1; j <= range[i].Fill.PictureEffects.Count; j++)
                            {
                                if (range[i].Fill.PictureEffects[j].Type == Office.MsoPictureEffectType.msoEffectBlur)
                                {
                                    Office.PictureEffect piceff = range[i].Fill.PictureEffects[j];
                                    piceff.EffectParameters[1].Value = 10f;
                                    en = 1;
                                }
                            }
                            if (en == -1)
                            {
                                Office.PictureEffect piceff = range[i].Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectBlur, 0);
                                piceff.EffectParameters[1].Value = 10f;
                            }
                        }
                        else
                        {
                            Office.PictureEffect piceff = range[i].Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectBlur, 0);
                            piceff.EffectParameters[1].Value = 10f;
                        }
                    }
                    else
                    {
                        n += 1;
                    }
               }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个形状不是图片");
                }
            }
        }

        public void button64_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中一个矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    shape.Shadow.Visible = Office.MsoTriState.msoTrue;
                    shape.Shadow.Type = Office.MsoShadowType.msoShadow25;
                    shape.Shadow.Style = Office.MsoShadowStyle.msoShadowStyleOuterShadow;
                    shape.Shadow.ForeColor.RGB = shape.Fill.ForeColor.RGB;
                    shape.Shadow.Size = 200;
                    shape.Shadow.Transparency = 0f;
                    shape.Shadow.Blur = 32;
                    shape.Shadow.OffsetX = 0f;
                    shape.Shadow.OffsetY = 0f;
                }
            }
        }

        public void button65_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Shape shape = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, -480, 0, 480, 270);
            shape.Fill.ForeColor.RGB = 230 + 220 * 256 + 148 * 256 * 256;
            shape.Line.Visible = Office.MsoTriState.msoFalse;
            shape.Copy();
            PowerPoint.Shape pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
            app.ActivePresentation.Save();
            Office.PictureEffect pic1wt = pic1.Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectWatercolorSponge, 0);
            pic1wt.EffectParameters[1].Value = 4;
            pic1wt.EffectParameters[1].Value = 0f;
            pic1.Copy();
            PowerPoint.Shape pic2 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
            app.ActivePresentation.Save();
            pic1.Delete();
            Office.PictureEffect pic2wt = pic2.Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectWatercolorSponge, 0);
            pic2wt.EffectParameters[1].Value = 1;
            pic2wt.EffectParameters[1].Value = 0f;
            Office.PictureEffect pic2s = pic2.Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectSaturation, 0);
            pic2s.EffectParameters[1].Value = 0;
            pic2.PictureFormat.Contrast = 1.0f;
            pic2.PictureFormat.Brightness = 0.33f;
            pic2.Copy();
            PowerPoint.Shape pic21 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
            app.ActivePresentation.Save();
            pic2.Delete();
            pic21.PictureFormat.TransparencyColor = 255 + 255 * 256 + 255 * 256 * 256;
            pic21.Fill.Visible = Office.MsoTriState.msoTrue;
            pic21.Fill.ForeColor.RGB = 112 + 173 * 256 + 71 * 256 * 256;
            pic21.Fill.Solid();
            pic21.Copy();
            PowerPoint.Shape pic3 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
            app.ActivePresentation.Save();
            pic21.Delete();
            pic3.PictureFormat.TransparencyColor = 0 + 0 + 0;
            pic3.PictureFormat.Contrast = 0.36f;
            pic3.PictureFormat.Brightness = 0.43f;
            pic3.Copy();
            PowerPoint.Shape pic32 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
            app.ActivePresentation.Save();
            pic32.PictureFormat.Brightness = 0.24f;
            pic32.Height = 1.5f * pic32.Height;
            pic32.Copy();
            PowerPoint.Shape pic4 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
            app.ActivePresentation.Save();
            pic32.Delete();
            pic4.PictureFormat.CropRight = pic4.Width - shape.Width;
            pic4.PictureFormat.CropTop = pic4.Height - shape.Height;
            pic3.Left = shape.Left;
            pic3.Top = shape.Top;
            pic4.Left = shape.Left;
            pic4.Top = shape.Top;

            string[] threeShapes = new string[3];
            threeShapes[0] = shape.Name;
            threeShapes[1] = pic3.Name;
            threeShapes[2] = pic4.Name;
            PowerPoint.Shape threeShapesGroup = slide.Shapes.Range(threeShapes).Group();
            threeShapesGroup.Copy();
            PowerPoint.Shape okShape = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
            threeShapesGroup.Delete();
            okShape.Top = 0;
            okShape.Left = -480;
            return;
        }

        public void button66_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                PowerPoint.Shape oval = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeOval, -100, 200, 100, 90);
                oval.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalDown, 1, 1f);
                oval.Fill.GradientStops[1].Color.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                oval.Fill.GradientStops[1].Position = 0.17f;
                oval.Fill.GradientStops[2].Color.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                oval.Fill.GradientStops[2].Position = 0.7f;
                oval.Fill.GradientStops[2].Transparency = 1f;
                oval.Line.Visible = Office.MsoTriState.msoTrue;
                oval.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                oval.Line.Weight = 2;
                oval.Shadow.Type = Office.MsoShadowType.msoShadow23;
                oval.Shadow.Style = Office.MsoShadowStyle.msoShadowStyleOuterShadow;
                oval.Shadow.ForeColor.RGB = 0 + 0 + 0;
                oval.Shadow.Transparency = 0.44f;
                oval.Shadow.Blur = 16;
                oval.Shadow.OffsetX = -11.313708499f;
                oval.Shadow.OffsetY = 11.313708499f;
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape oval = range[i];
                    oval.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalDown, 1, 1f);
                    oval.Fill.GradientStops[1].Color.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    oval.Fill.GradientStops[1].Position = 0.17f;
                    oval.Fill.GradientStops[2].Color.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    oval.Fill.GradientStops[2].Position = 0.7f;
                    oval.Fill.GradientStops[2].Transparency = 1f;
                    oval.Line.Visible = Office.MsoTriState.msoTrue;
                    oval.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    oval.Line.Weight = 2;
                    oval.Shadow.Type = Office.MsoShadowType.msoShadow23;
                    oval.Shadow.Style = Office.MsoShadowStyle.msoShadowStyleOuterShadow;
                    oval.Shadow.ForeColor.RGB = 0 + 0 + 0;
                    oval.Shadow.Transparency = 0.44f;
                    oval.Shadow.Blur = 16;
                    oval.Shadow.OffsetX = -11.313708499f;
                    oval.Shadow.OffsetY = 11.313708499f;
                }
            }

        }

        public void button68_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中一个元素");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    range[i].Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                    float rt = shape.Rotation;
                    if (rt == 0)
                    {
                        PowerPoint.Shape pic = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, shape.Left, shape.Top, shape.Width, shape.Height);
                        pic.Fill.Visible = Office.MsoTriState.msoTrue;
                        pic.Fill.UserPicture(apath + @"xshape.png");
                        pic.Line.Visible = Office.MsoTriState.msoFalse;
                        File.Delete(apath + @"xshape.png");
                        shape.Delete();
                        pic.Select();
                    }
                    else
                    {
                        shape.Copy();
                        PowerPoint.Shape nshape = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                        nshape.ScaleHeight(1f, Office.MsoTriState.msoFalse, Office.MsoScaleFrom.msoScaleFromTopLeft);
                        PowerPoint.Shape pic = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, shape.Left + shape.Width - nshape.Width / 2, shape.Top + shape.Height / 2 - nshape.Height / 2, nshape.Width, nshape.Height);
                        pic.Fill.Visible = Office.MsoTriState.msoTrue;
                        pic.Fill.UserPicture(apath + @"xshape.png");
                        pic.Line.Visible = Office.MsoTriState.msoFalse;
                        File.Delete(apath + @"xshape.png");
                        nshape.Delete();
                        shape.Delete();
                        pic.Select();
                    }
                }
            }
        }

        public void button70_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(swidth * 0.382f, 0, swidth * 0.382f, sheight);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(0, sheight * 0.382f, swidth, sheight * 0.382f);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                {
                    line1.Line.ForeColor.RGB = 0;
                    line2.Line.ForeColor.RGB = 0;
                }
                else
                {
                    line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                float width = shape.Width;
                float height = shape.Height;
                float top = shape.Top;
                float left = shape.Left;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(left + width * 0.382f, top, left + width * 0.382f, top + height);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(left, top + height * 0.382f, left + width, top + height * 0.382f);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (shape.Type == Office.MsoShapeType.msoLine)
                {
                    if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                }
                else
                {
                    int rgb = 0;
                    rgb = shape.Fill.ForeColor.RGB;
                    int r = rgb % 256;
                    int g = (rgb / 256) % 256;
                    int b = (rgb / 256 / 256) % 256;
                    int hsl = Rgb2Hsl(r, g, b);
                    int h = hsl % 256;
                    int s = (hsl / 256) % 256;
                    int l = (hsl / 256 / 256) % 256;
                    int nl = 0;
                    if (l > 200)
                    {
                        nl = 0;
                    }
                    else
                    {
                        nl = 255;
                    }
                    int nrgb = Hsl2Rgb(h, s, nl);
                    line1.Line.ForeColor.RGB = nrgb;
                    line2.Line.ForeColor.RGB = nrgb;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange sliderange = sel.SlideRange;
                foreach (PowerPoint.Slide item in sliderange)
                {
                    float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                    float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                    PowerPoint.Shape line1 = item.Shapes.AddLine(swidth * 0.382f, 0, swidth * 0.382f, sheight);
                    PowerPoint.Shape line2 = item.Shapes.AddLine(0, sheight * 0.382f, swidth, sheight * 0.382f);
                    line1.Visible = Office.MsoTriState.msoTrue;
                    line2.Visible = Office.MsoTriState.msoTrue;
                    line1.Name = "line01";
                    line2.Name = "line01";
                    if (item.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                    line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
                    line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
                }
            }
        }

        public void button71_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(swidth * 0.618f, 0, swidth * 0.618f, sheight);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(0, sheight * 0.618f, swidth, sheight * 0.618f);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                {
                    line1.Line.ForeColor.RGB = 0;
                    line2.Line.ForeColor.RGB = 0;
                }
                else
                {
                    line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                float width = shape.Width;
                float height = shape.Height;
                float top = shape.Top;
                float left = shape.Left;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(left + width * 0.618f, top, left + width * 0.618f, top + height);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(left, top + height * 0.618f, left + width, top + height * 0.618f);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (shape.Type == Office.MsoShapeType.msoLine)
                {
                    if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                }
                else
                {
                    int rgb = 0;
                    rgb = shape.Fill.ForeColor.RGB;
                    int r = rgb % 256;
                    int g = (rgb / 256) % 256;
                    int b = (rgb / 256 / 256) % 256;
                    int hsl = Rgb2Hsl(r, g, b);
                    int h = hsl % 256;
                    int s = (hsl / 256) % 256;
                    int l = (hsl / 256 / 256) % 256;
                    int nl = 0;
                    if (l > 200)
                    {
                        nl = 0;
                    }
                    else
                    {
                        nl = 255;
                    }
                    int nrgb = Hsl2Rgb(h, s, nl);
                    line1.Line.ForeColor.RGB = nrgb;
                    line2.Line.ForeColor.RGB = nrgb;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange sliderange = sel.SlideRange;
                foreach (PowerPoint.Slide item in sliderange)
                {
                    float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                    float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                    PowerPoint.Shape line1 = item.Shapes.AddLine(swidth * 0.618f, 0, swidth * 0.618f, sheight);
                    PowerPoint.Shape line2 = item.Shapes.AddLine(0, sheight * 0.618f, swidth, sheight * 0.618f);
                    line1.Visible = Office.MsoTriState.msoTrue;
                    line2.Visible = Office.MsoTriState.msoTrue;
                    line1.Name = "line01";
                    line2.Name = "line01";
                    if (item.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                    line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
                    line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineSolid;
                }
            }
        }

        public void button72_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                int count = slide.Shapes.Count;
                for (int i = count; i > 0; i--)
                {
                    PowerPoint.Shape line = slide.Shapes[i];
                    if (line.Name == "line01")
                    {
                        line.Delete();
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    int count = item.Shapes.Count;
                    for (int i = count; i > 0; i--)
                    {
                        PowerPoint.Shape line = item.Shapes[i];
                        if (line.Name == "line01")
                        {
                            line.Delete();
                        }
                    }
                }
            }
        }

        public void button75_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                List<string> oname = new List<string>();
                List<string> name = new List<string>();
                for (int i = 1; i <= range.Count; i++)
                {
                    oname.Add(range[i].Name);
                    range[i].Name = range[i].Name + "_" + i;
                    name.Add(range[i].Name);
                }
                int rn = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = slide.Shapes[name[i - 1]];
                    if (shape.Rotation != 0)
                    {
                        rn += 1;
                    }
                    shape.ThreeD.Visible = Office.MsoTriState.msoTrue;
                    shape.ThreeD.PresetMaterial = Office.MsoPresetMaterial.msoMaterialFlat;
                    shape.ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraObliqueBottomRight);
                    shape.ThreeD.RotationX = 0;
                    shape.ThreeD.RotationY = 0;
                    shape.ThreeD.RotationZ = 0;
                    shape.ThreeD.Depth = 1500;
                    shape.ThreeD.BevelBottomType = Office.MsoBevelType.msoBevelNone;
                    shape.ThreeD.BevelTopType = Office.MsoBevelType.msoBevelNone;
                    shape.Copy();
                    PowerPoint.Shape nsh = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                    if (nsh.Width == nsh.Height)
                    {
                        nsh.PictureFormat.CropRight = nsh.Width - shape.Width * 4 / 3;
                        nsh.PictureFormat.CropBottom = nsh.Height - shape.Height * 4 / 3;
                        nsh.PictureFormat.CropLeft = -shape.Width * 0.3f;
                        nsh.PictureFormat.CropTop = -shape.Height * 0.3f;
                    }
                    else
                    {
                        if (nsh.Width > nsh.Height)
                        {
                            float n = shape.Width - shape.Height;
                            nsh.PictureFormat.CropRight = nsh.Width - shape.Width - shape.Width / 3;
                            nsh.PictureFormat.CropBottom = nsh.Height - shape.Height - shape.Width / 3 - n / 2;
                            nsh.PictureFormat.CropLeft = -shape.Width * 0.3f;
                            nsh.PictureFormat.CropTop = -shape.Width / 3 - (shape.Width - shape.Height) / 2;
                        }
                        else
                        {
                            float n = shape.Height - shape.Width;
                            nsh.PictureFormat.CropRight = nsh.Width - shape.Width - shape.Height / 3 - n / 2;
                            nsh.PictureFormat.CropBottom = nsh.Height - shape.Height - shape.Height / 3;
                            nsh.PictureFormat.CropLeft = -shape.Height / 3 - (shape.Height - shape.Width) / 2;
                            nsh.PictureFormat.CropTop = -shape.Height * 0.3f;
                        }
                    }
                    nsh.Fill.Visible = Office.MsoTriState.msoTrue;
                    nsh.Fill.ForeColor.RGB = 242 + 242 * 256 + 242 * 256 * 256;
                    nsh.Fill.Solid();
                    nsh.AutoShapeType = Office.MsoAutoShapeType.msoShapeRoundedRectangle;
                    nsh.Left = shape.Left + shape.Width;
                    nsh.Top = shape.Top;
                    shape.ThreeD.Visible = Office.MsoTriState.msoFalse;
                }
                for (int i = 0; i < oname.Count(); i++)
                {
                    slide.Shapes[name[i]].Name = oname[i];
                }
                if (rn != 0)
                {
                    MessageBox.Show("所选图形中有 " + rn + " 个图形旋转角度不为0，可以手动裁剪图片以达到最佳长阴影效果");
                }
            }
        }

        public void button76_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中文本框");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                List<string> oname = new List<string>();
                List<string> name = new List<string>();
                for (int i = 1; i <= range.Count; i++)
                {
                    oname.Add(range[i].Name);
                    range[i].Name = range[i].Name + "_" + i;
                    name.Add(range[i].Name);
                }
                int rn = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape oshape = slide.Shapes[name[i - 1]];
                    if (oshape.Rotation != 0)
                    {
                        rn += 1;
                    }
                    PowerPoint.Shape shape = oshape.Duplicate()[1];
                    shape.TextFrame2.ThreeD.Visible = Office.MsoTriState.msoTrue;
                    shape.TextFrame2.ThreeD.PresetMaterial = Office.MsoPresetMaterial.msoMaterialFlat;
                    shape.TextFrame2.ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraObliqueBottomRight);
                    shape.TextFrame2.ThreeD.RotationX = 0;
                    shape.TextFrame2.ThreeD.RotationY = 0;
                    shape.TextFrame2.ThreeD.RotationZ = 0;
                    int rgb = 0;
                    if (shape.Fill.Visible == Office.MsoTriState.msoTrue)
                    {
                        rgb = shape.Fill.ForeColor.RGB;
                    }
                    shape.TextFrame2.ThreeD.ExtrusionColor.RGB = rgb;
                    shape.TextFrame2.ThreeD.BevelBottomType = Office.MsoBevelType.msoBevelNone;
                    shape.TextFrame2.ThreeD.BevelTopType = Office.MsoBevelType.msoBevelNone;
                    shape.TextFrame2.ThreeD.Depth = 1500;
                    shape.Copy();
                    PowerPoint.Shape nsh = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                    nsh.AutoShapeType = Office.MsoAutoShapeType.msoShapeRoundedRectangle;
                    nsh.PictureFormat.CropRight = nsh.Width - oshape.Width;
                    nsh.PictureFormat.CropBottom = nsh.Height - oshape.Height;
                    nsh.Left = oshape.Left + oshape.Width;
                    nsh.Top = oshape.Top;
                    shape.Delete();
                }
                for (int i = 0; i < oname.Count(); i++)
                {
                    slide.Shapes[name[i]].Name = oname[i];
                }
                if (rn != 0)
                {
                    MessageBox.Show("所选图形中有 " + rn + " 个图形旋转角度不为0，可以手动裁剪图片以达到最佳长阴影效果");
                }
            }
        }

        public void button77_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            Info.FileName = "calc.exe ";
            System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
        }

        public void button73_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("先选中图形");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.TimeLine timeline = slide.TimeLine;
                    PowerPoint.Sequence seq = timeline.MainSequence;
                    PowerPoint.Shape shape = range[i];
                    PowerPoint.Effect xz = seq.AddEffect(range[i], PowerPoint.MsoAnimEffect.msoAnimEffectSwivel, PowerPoint.MsoAnimateByLevel.msoAnimateLevelNone, PowerPoint.MsoAnimTriggerType.msoAnimTriggerOnPageClick, -1);
                    xz.Timing.Duration = 0.01f;
                    xz.Timing.RepeatCount = 6;
                    PowerPoint.Effect lz = seq.AddEffect(range[i], PowerPoint.MsoAnimEffect.msoAnimEffectWheel, PowerPoint.MsoAnimateByLevel.msoAnimateLevelNone, PowerPoint.MsoAnimTriggerType.msoAnimTriggerWithPrevious, -1);
                    lz.Timing.Duration = 2;
                    lz.Timing.TriggerDelayTime = 0.01f;
                }
                MessageBox.Show("添加完成，请手动把“基本旋转”动画的重复次数设置为0.6。");
            }
        }

        public void button74_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("先选中图形");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.TimeLine timeline = slide.TimeLine;
                    PowerPoint.Sequence seq = timeline.MainSequence;
                    PowerPoint.Shape shape = range[i];
                    PowerPoint.Effect xz = seq.AddEffect(range[i], PowerPoint.MsoAnimEffect.msoAnimEffectSwivel, PowerPoint.MsoAnimateByLevel.msoAnimateLevelNone, PowerPoint.MsoAnimTriggerType.msoAnimTriggerOnPageClick, -1);
                    xz.Exit = Office.MsoTriState.msoTrue;
                    xz.Timing.Duration = 0.01f;
                    xz.Timing.RepeatCount = 4;
                    PowerPoint.Effect lz = seq.AddEffect(range[i], PowerPoint.MsoAnimEffect.msoAnimEffectWheel, PowerPoint.MsoAnimateByLevel.msoAnimateLevelNone, PowerPoint.MsoAnimTriggerType.msoAnimTriggerWithPrevious, -1);
                    lz.Timing.Duration = 2;
                    lz.Timing.TriggerDelayTime = 0.01f;
                }
                MessageBox.Show("添加完成，请手动把“基本旋转”动画的重复次数设置为0.4。");
            }
        }

        public void button79_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://oktools.xyz");
        }

        public void button81_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.rapidbbs.cn");
        }

        public void button82_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://slibe.yanj.cn");
        }

        public void button2_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.office-cn.net/");
        }

        public void button83_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.yanj.cn/");
        }

        public void button84_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://huaban.com/slibe/");
        }

        public void button85_Click(object sender, RibbonControlEventArgs e)
        {
            Text_Unity Text_Unity = null;
            if (Text_Unity == null || Text_Unity.IsDisposed)
            {
                Text_Unity = new Text_Unity();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Text_Unity.Show();
                button85.Enabled = false;
            }
        }

        public void button86_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(swidth / 3, 0, swidth / 3, sheight);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(swidth * 2 / 3, 0, swidth * 2 / 3, sheight);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                {
                    line1.Line.ForeColor.RGB = 0;
                    line2.Line.ForeColor.RGB = 0;
                }
                else
                {
                    line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                float width = shape.Width;
                float height = shape.Height;
                float top = shape.Top;
                float left = shape.Left;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(left + width / 3, top, left + width / 3, top + height);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(left + width * 2 / 3, top, left + width * 2 / 3, top + height);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (shape.Type == Office.MsoShapeType.msoLine)
                {
                    if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                }
                else
                {
                    int rgb = 0;
                    rgb = shape.Fill.ForeColor.RGB;
                    int r = rgb % 256;
                    int g = (rgb / 256) % 256;
                    int b = (rgb / 256 / 256) % 256;
                    int hsl = Rgb2Hsl(r, g, b);
                    int h = hsl % 256;
                    int s = (hsl / 256) % 256;
                    int l = (hsl / 256 / 256) % 256;
                    int nl = 0;
                    if (l > 200)
                    {
                        nl = 0;
                    }
                    else
                    {
                        nl = 255;
                    }
                    int nrgb = Hsl2Rgb(h, s, nl);
                    line1.Line.ForeColor.RGB = nrgb;
                    line2.Line.ForeColor.RGB = nrgb;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange sliderange = sel.SlideRange;
                foreach (PowerPoint.Slide item in sliderange)
                {
                    float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                    float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                    PowerPoint.Shape line1 = item.Shapes.AddLine(swidth / 3, 0, swidth / 3, sheight);
                    PowerPoint.Shape line2 = item.Shapes.AddLine(swidth * 2 / 3, 0, swidth * 2 / 3, sheight);
                    line1.Visible = Office.MsoTriState.msoTrue;
                    line2.Visible = Office.MsoTriState.msoTrue;
                    line1.Name = "line01";
                    line2.Name = "line01";
                    if (item.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                    line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                    line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                }
            }
        }

        public void button87_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(0, sheight / 3, swidth, sheight / 3);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(0, sheight * 2 / 3, swidth, sheight * 2 / 3);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                {
                    line1.Line.ForeColor.RGB = 0;
                    line2.Line.ForeColor.RGB = 0;
                }
                else
                {
                    line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                float width = shape.Width;
                float height = shape.Height;
                float top = shape.Top;
                float left = shape.Left;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(left, top + height / 3, left + width, top + height / 3);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(left, top + height * 2 / 3, left + width, top + height * 2 / 3);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (shape.Type == Office.MsoShapeType.msoLine)
                {
                    if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                }
                else
                {
                    int rgb = 0;
                    rgb = shape.Fill.ForeColor.RGB;
                    int r = rgb % 256;
                    int g = (rgb / 256) % 256;
                    int b = (rgb / 256 / 256) % 256;
                    int hsl = Rgb2Hsl(r, g, b);
                    int h = hsl % 256;
                    int s = (hsl / 256) % 256;
                    int l = (hsl / 256 / 256) % 256;
                    int nl = 0;
                    if (l > 200)
                    {
                        nl = 0;
                    }
                    else
                    {
                        nl = 255;
                    }
                    int nrgb = Hsl2Rgb(h, s, nl);
                    line1.Line.ForeColor.RGB = nrgb;
                    line2.Line.ForeColor.RGB = nrgb;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange sliderange = sel.SlideRange;
                foreach (PowerPoint.Slide item in sliderange)
                {
                    float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                    float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                    PowerPoint.Shape line1 = item.Shapes.AddLine(0, sheight / 3, swidth, sheight / 3);
                    PowerPoint.Shape line2 = item.Shapes.AddLine(0, sheight * 2 / 3, swidth, sheight * 2 / 3);
                    line1.Visible = Office.MsoTriState.msoTrue;
                    line2.Visible = Office.MsoTriState.msoTrue;
                    line1.Name = "line01";
                    line2.Name = "line01";
                    if (item.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                    line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                    line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                }
            }
        }

        public void button88_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            string apath = app.ActivePresentation.Path;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选中2个图形，并将矢量形状置于要裁剪的图片之上，形状不要旋转");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                List<string> oname = new List<string>();
                List<string> name = new List<string>();
                for (int i = 2; i <= range.Count; i++)
                {
                    oname.Add(range[i].Name);
                    range[i].Name = range[i].Name + "_" + i;
                    name.Add(range[i].Name);
                }
                PowerPoint.Shape pic = range[1];
                pic.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                for (int i = 2; i <= count; i++)
                {
                    PowerPoint.Shape shape = slide.Shapes[name[i - 2]];
                    if (shape.Rotation == 0)
                    {
                        shape.Fill.Visible = Office.MsoTriState.msoTrue;
                        shape.Fill.UserPicture(apath + @"xshape.png");
                        shape.Fill.TextureTile = Office.MsoTriState.msoFalse;
                        shape.Fill.RotateWithObject = Office.MsoTriState.msoTrue;
                        shape.PictureFormat.Crop.PictureOffsetX = pic.Left + pic.Width / 2 - shape.Left - shape.PictureFormat.Crop.PictureWidth / 2;
                        shape.PictureFormat.Crop.PictureOffsetY = pic.Top + pic.Height / 2 - shape.Top - shape.PictureFormat.Crop.PictureHeight / 2;
                        shape.PictureFormat.Crop.PictureHeight = pic.Height;
                        shape.PictureFormat.Crop.PictureWidth = pic.Width;
                    }
                    else
                    {
                        shape.Copy();
                        PowerPoint.Shape nshape = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                        nshape.Left = shape.Left + shape.Width / 2 - nshape.Width / 2;
                        nshape.Top = shape.Top + shape.Height / 2 - nshape.Height / 2;
                        shape.Fill.Visible = Office.MsoTriState.msoTrue;
                        shape.Fill.UserPicture(apath + @"xshape.png");
                        shape.Fill.TextureTile = Office.MsoTriState.msoFalse;
                        shape.Fill.RotateWithObject = Office.MsoTriState.msoFalse;
                        shape.PictureFormat.Crop.PictureOffsetX = pic.Left + pic.Width / 2 - nshape.Left - shape.PictureFormat.Crop.PictureWidth / 2;
                        shape.PictureFormat.Crop.PictureOffsetY = pic.Top + pic.Height / 2 - nshape.Top - shape.PictureFormat.Crop.PictureHeight / 2;
                        shape.PictureFormat.Crop.PictureHeight = pic.Height;
                        shape.PictureFormat.Crop.PictureWidth = pic.Width;
                        nshape.Delete();
                    }
                }
                File.Delete(apath + @"xshape.png");
                for (int i = 0; i < oname.Count(); i++)
                {
                    slide.Shapes[name[i]].Name = oname[i];
                }
            }
        }

        public void button91_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(swidth * 0.5f, 0, swidth * 0.5f, sheight);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(0, sheight * 0.5f, swidth, sheight * 0.5f);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                {
                    line1.Line.ForeColor.RGB = 0;
                    line2.Line.ForeColor.RGB = 0;
                }
                else
                {
                    line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                float width = shape.Width;
                float height = shape.Height;
                float top = shape.Top;
                float left = shape.Left;
                PowerPoint.Shape line1 = slide.Shapes.AddLine(left + width * 0.5f, top, left + width * 0.5f, top + height);
                PowerPoint.Shape line2 = slide.Shapes.AddLine(left, top + height * 0.5f, left + width, top + height * 0.5f);
                line1.Visible = Office.MsoTriState.msoTrue;
                line2.Visible = Office.MsoTriState.msoTrue;
                line1.Name = "line01";
                line2.Name = "line01";
                if (shape.Type == Office.MsoShapeType.msoLine)
                {
                    if (slide.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                }
                else
                {
                    int rgb = 0;
                    rgb = shape.Fill.ForeColor.RGB;
                    int r = rgb % 256;
                    int g = (rgb / 256) % 256;
                    int b = (rgb / 256 / 256) % 256;
                    int hsl = Rgb2Hsl(r, g, b);
                    int h = hsl % 256;
                    int s = (hsl / 256) % 256;
                    int l = (hsl / 256 / 256) % 256;
                    int nl = 0;
                    if (l > 200)
                    {
                        nl = 0;
                    }
                    else
                    {
                        nl = 255;
                    }
                    int nrgb = Hsl2Rgb(h, s, nl);
                    line1.Line.ForeColor.RGB = nrgb;
                    line2.Line.ForeColor.RGB = nrgb;
                }
                line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange sliderange = sel.SlideRange;
                foreach (PowerPoint.Slide item in sliderange)
                {
                    float swidth = app.ActivePresentation.PageSetup.SlideWidth;
                    float sheight = app.ActivePresentation.PageSetup.SlideHeight;
                    PowerPoint.Shape line1 = item.Shapes.AddLine(swidth * 0.5f, 0, swidth * 0.5f, sheight);
                    PowerPoint.Shape line2 = item.Shapes.AddLine(0, sheight * 0.5f, swidth, sheight * 0.5f);
                    line1.Visible = Office.MsoTriState.msoTrue;
                    line2.Visible = Office.MsoTriState.msoTrue;
                    line1.Name = "line01";
                    line2.Name = "line01";
                    if (item.Background.Fill.ForeColor.RGB > 255 + 200 * 256 + 200 * 256 * 256)
                    {
                        line1.Line.ForeColor.RGB = 0;
                        line2.Line.ForeColor.RGB = 0;
                    }
                    else
                    {
                        line1.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                        line2.Line.ForeColor.RGB = 255 + 255 * 256 + 255 * 256 * 256;
                    }
                    line1.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                    line2.Line.DashStyle = Office.MsoLineDashStyle.msoLineDash;
                }
            }
        }

        public void button93_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少2个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合" + Environment.NewLine + "3.选中一个组合内2个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb = tr.Characters(1).Font.Color.RGB;
                for (int i = 2; i <= count; i++)
                {
                    tr.Characters(i).Font.Color.RGB = rgb;
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoPicture || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 2))))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    PowerPoint.Shape shape1 = range[1].GroupItems[1];
                    if ((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue && (shape1.Fill.Type == Office.MsoFillType.msoFillSolid || shape1.Fill.Type == Office.MsoFillType.msoFillGradient))
                    {
                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            range[1].GroupItems[i].Fill.Visible = Office.MsoTriState.msoTrue;
                            range[1].GroupItems[i].Fill.Solid();
                            range[1].GroupItems[i].Fill.ForeColor.RGB = shape1.Fill.ForeColor.RGB;
                        }
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine || shape1.Fill.Visible == Office.MsoTriState.msoFalse) && shape1.Line.Visible == Office.MsoTriState.msoTrue)
                    {
                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            range[1].GroupItems[i].Line.Visible = Office.MsoTriState.msoTrue;
                            range[1].GroupItems[i].Line.ForeColor.RGB = shape1.Line.ForeColor.RGB;
                        }
                    }
                    else
                    {
                        MessageBox.Show("只支持纯色");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    if ((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue && (shape1.Fill.Type == Office.MsoFillType.msoFillSolid || shape1.Fill.Type == Office.MsoFillType.msoFillGradient))
                    {
                        for (int i = 2; i <= count; i++)
                        {
                            range[i].Fill.Visible = Office.MsoTriState.msoTrue;
                            range[i].Fill.Solid();
                            range[i].Fill.ForeColor.RGB = shape1.Fill.ForeColor.RGB;
                        }
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine || shape1.Fill.Visible == Office.MsoTriState.msoFalse) && shape1.Line.Visible == Office.MsoTriState.msoTrue)
                    {
                        for (int i = 2; i <= count; i++)
                        {
                            range[i].Line.Visible = Office.MsoTriState.msoTrue;
                            range[i].Line.ForeColor.RGB = shape1.Line.ForeColor.RGB;
                        }
                    }
                    else
                    {
                        MessageBox.Show("只支持纯色");
                    }
                }
            }
        }

        public void button25_Click(object sender, RibbonControlEventArgs e)
        {
            Time_Clock Time_Clock = null;
            if (Time_Clock == null || Time_Clock.IsDisposed)
            {
                Time_Clock = new Time_Clock();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Time_Clock.Show();
                button25.Enabled = false;
            }
        }

        public void button26_Click(object sender, RibbonControlEventArgs e)
        {
            Time_Count Time_Count = null;
            if (Time_Count == null || Time_Count.IsDisposed)
            {
                Time_Count = new Time_Count();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Time_Count.Show();
                button26.Enabled = false;
            }
        }

        public void button89_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slides slides = app.ActivePresentation.Slides;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中至少一个图形，注意不要选占位符");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int sid = sel.SlideRange.SlideNumber;
                int count = range.Count;
                List<string> oname = new List<string>();
                List<string> name = new List<string>();
                for (int i = 1; i <= range.Count; i++)
                {
                    oname.Add(range[i].Name);
                    range[i].Name = range[i].Name + "_" + i;
                    name.Add(range[i].Name);
                }
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = slides[sid].Shapes[name[i - 1]];
                    shape.Copy();
                    PowerPoint.CustomLayout layout = slides[sid].CustomLayout;
                    PowerPoint.Slide slide = slides.AddSlide(sid + i, layout);
                    slide.Shapes.Paste();
                }
                for (int i = 0; i < oname.Count(); i++)
                {
                    slides[sid].Shapes[name[i]].Name = oname[i];
                }
            }
        }

        public void button90_Click(object sender, RibbonControlEventArgs e)
        {
            OK_Fast OK_Fast = null;
            if (OK_Fast == null || OK_Fast.IsDisposed)
            {
                OK_Fast = new OK_Fast();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                OK_Fast.Show();
            }
        }

        public void button69_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中一张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                int count = range.Count;
                List<string> oname = new List<string>();
                List<string> name = new List<string>();
                for (int i = 1; i <= range.Count; i++)
                {
                    oname.Add(range[i].Name);
                    range[i].Name = range[i].Name + "_" + i;
                    name.Add(range[i].Name);
                }
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape pic = slide.Shapes[name[i - 1]];
                    pic.Copy();
                    PowerPoint.Shape pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                    PowerPoint.Shape pic1 = pic0.Duplicate()[1];
                    PowerPoint.Shape pic2 = pic0.Duplicate()[1];
                    PowerPoint.Shape pic3 = pic0.Duplicate()[1];

                    pic1.PictureFormat.CropRight = pic0.Width * 2 / 3;
                    pic2.PictureFormat.CropLeft = pic0.Width / 3;
                    pic2.PictureFormat.CropRight = pic0.Width / 3;
                    pic3.PictureFormat.CropLeft = pic0.Width * 2 / 3;

                    PowerPoint.Shape bw1 = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 0, 0, pic0.Width * 5 / 6, pic1.Height);
                    PowerPoint.Shape bw2 = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 0, 0, pic0.Width * 5 / 6, pic2.Height);
                    PowerPoint.Shape bw3 = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 0, 0, pic0.Width * 5 / 6, pic3.Height);
                    pic1.Name = pic1.Name + "_1";
                    pic2.Name = pic2.Name + "_2";
                    pic3.Name = pic3.Name + "_3";

                    string[] gt1 = new string[2];
                    gt1[0] = pic1.Name;
                    gt1[1] = bw1.Name;
                    pic1.ZOrder(Office.MsoZOrderCmd.msoBringToFront);
                    bw1.Fill.Visible = Office.MsoTriState.msoFalse;
                    bw1.Line.Visible = Office.MsoTriState.msoFalse;
                    slide.Shapes.Range(gt1).Align(Office.MsoAlignCmd.msoAlignLefts, Office.MsoTriState.msoFalse);
                    slide.Shapes.Range(gt1).Align(Office.MsoAlignCmd.msoAlignMiddles, Office.MsoTriState.msoFalse);
                    PowerPoint.Shape g1 = slide.Shapes.Range(gt1).Group();

                    string[] gt2 = new string[2];
                    gt2[0] = pic2.Name;
                    gt2[1] = bw2.Name;
                    pic2.ZOrder(Office.MsoZOrderCmd.msoBringToFront);
                    bw2.Fill.Visible = Office.MsoTriState.msoFalse;
                    bw2.Line.Visible = Office.MsoTriState.msoFalse;
                    slide.Shapes.Range(gt2).Align(Office.MsoAlignCmd.msoAlignCenters, Office.MsoTriState.msoFalse);
                    slide.Shapes.Range(gt2).Align(Office.MsoAlignCmd.msoAlignMiddles, Office.MsoTriState.msoFalse);
                    PowerPoint.Shape g2 = slide.Shapes.Range(gt2).Group();

                    string[] gt3 = new string[2];
                    gt3[0] = pic3.Name;
                    gt3[1] = bw3.Name;
                    pic3.ZOrder(Office.MsoZOrderCmd.msoBringToFront);
                    bw3.Fill.Visible = Office.MsoTriState.msoFalse;
                    bw3.Line.Visible = Office.MsoTriState.msoFalse;
                    slide.Shapes.Range(gt3).Align(Office.MsoAlignCmd.msoAlignRights, Office.MsoTriState.msoFalse);
                    slide.Shapes.Range(gt3).Align(Office.MsoAlignCmd.msoAlignMiddles, Office.MsoTriState.msoFalse);
                    PowerPoint.Shape g3 = slide.Shapes.Range(gt3).Group();

                    g1.ThreeD.Visible = Office.MsoTriState.msoTrue;
                    g1.ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                    g1.ThreeD.RotationX = 30;
                    g1.ThreeD.RotationY = 0;
                    g1.ThreeD.RotationZ = 0;
                    g1.ThreeD.FieldOfView = 45;
                    g1.ThreeD.Z = -pic1.Width / 2 * (float)Math.Sqrt(3) / 2;

                    g2.ThreeD.Visible = Office.MsoTriState.msoTrue;
                    g2.ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                    g2.ThreeD.RotationX = 330;
                    g2.ThreeD.RotationY = 0;
                    g2.ThreeD.RotationZ = 0;
                    g2.ThreeD.FieldOfView = 45;
                    g2.ThreeD.Z = 0;

                    g3.ThreeD.Visible = Office.MsoTriState.msoTrue;
                    g3.ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                    g3.ThreeD.RotationX = 30;
                    g3.ThreeD.RotationY = 0;
                    g3.ThreeD.RotationZ = 0;
                    g3.ThreeD.FieldOfView = 45;
                    g3.ThreeD.Z = pic3.Width / 2 * (float)Math.Sqrt(3) / 2;

                    pic0.Left = pic.Left + pic.Width / 2 + pic0.Width / 2;
                    pic0.Top = pic.Top + pic.Height / 2 - pic0.Height / 2;
                    g1.Left = pic0.Left;
                    g1.Top = pic0.Top;
                    g2.Left = pic0.Left;
                    g2.Top = pic0.Top;
                    g3.Left = pic0.Left;
                    g3.Top = pic0.Top;
                    pic0.Delete();
                }
                for (int i = 0; i < oname.Count(); i++)
                {
                    slide.Shapes[name[i]].Name = oname[i];
                }
            }
        }

        public void button80_Click(object sender, RibbonControlEventArgs e)
        {
            Color_Picker Color_Picker = null;
            if (Color_Picker == null || Color_Picker.IsDisposed)
            {
                Color_Picker = new Color_Picker();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Color_Picker.Show();
                button80.Enabled = false;
            }
        }

        public void button92_Click(object sender, RibbonControlEventArgs e)
        {
            Color_Multiply Color_Multiply = null;
            if (Color_Multiply == null || Color_Multiply.IsDisposed)
            {
                Color_Multiply = new Color_Multiply();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Color_Multiply.Show();
                button92.Enabled = false;
            }
        }

        public void button95_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同尺寸的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                for (int i = 1; i <= slide.Shapes.Count; i++)
                {
                    PowerPoint.Shape item = slide.Shapes[i];
                    if (item.Name == shape.Name && item.Id != shape.Id)
                    {
                        item.Name = item.Name + "_" + i;
                    }
                }
                List<string> list = new List<string>();
                foreach (PowerPoint.Shape item in slide.Shapes)
                {
                    if (item.Height == shape.Height && item.Width == shape.Width)
                    {
                        list.Add(item.Name);
                    }
                }
                slide.Shapes.Range(list.ToArray()).Select();
            }
        }

        Bitmap bmp2 = null;
        public void button96_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            int nr = 0, ng = 0, nb = 0;
                                            na = (color2.A * color.A) / 255;
                                            if (color.R <= color2.R)
                                            {
                                                nr = color.R;
                                            }
                                            else
                                            {
                                                nr = color2.R;
                                            }

                                            if (color.G <= color2.G)
                                            {
                                                ng = color.G;
                                            }
                                            else
                                            {
                                                ng = color2.G;
                                            }

                                            if (color.B <= color2.B)
                                            {
                                                nb = color.B;
                                            }
                                            else
                                            {
                                                nb = color2.B;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            int nr = 0, ng = 0, nb = 0;
                                            na = (color2.A * color.A) / 255;
                                            if (color.R <= color2.R)
                                            {
                                                nr = color.R;
                                            }
                                            else
                                            {
                                                nr = color2.R;
                                            }

                                            if (color.G <= color2.G)
                                            {
                                                ng = color.G;
                                            }
                                            else
                                            {
                                                ng = color2.G;
                                            }

                                            if (color.B <= color2.B)
                                            {
                                                nb = color.B;
                                            }
                                            else
                                            {
                                                nb = color2.B;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button97_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            int nr = color2.R * (255 - color.R) / 255 + color.R;
                                            int ng = color2.G * (255 - color.G) / 255 + color.G;
                                            int nb = color2.B * (255 - color.B) / 255 + color.B;
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            int nr = color2.R * (255 - color.R) / 255 + color.R;
                                            int ng = color2.G * (255 - color.G) / 255 + color.G;
                                            int nb = color2.B * (255 - color.B) / 255 + color.B;
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }

        }

        public void button27_Click(object sender, RibbonControlEventArgs e)
        {
            Teachers teacher1 = null;
            if (teacher1 == null || teacher1.IsDisposed)
            {
                teacher1 = new Teachers();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                teacher1.Show();
                button27.Enabled = false;
            }
        }

        public void button99_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中要对齐的幻灯片，且保证幻灯片中只有一个图形");
            }
            else
            {
                PowerPoint.SlideRange srange = sel.SlideRange;
                PowerPoint.Shape shape = srange[1].Shapes[1];
                float pointx = shape.Left + shape.Width / 2;
                float pointy = shape.Top + shape.Height / 2;
                int count = srange.Count;

                for (int i = 2; i <= count; i++)
                {
                    PowerPoint.Shape nshape = srange[i].Shapes[1];
                    nshape.Left = pointx - nshape.Width / 2;
                    nshape.Top = pointy - nshape.Height / 2;
                }
            }
        }

        public void button100_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中要对齐的幻灯片，且保证幻灯片中只有一个图形");
            }
            else
            {
                PowerPoint.SlideRange srange = sel.SlideRange;
                PowerPoint.Shape shape = srange[1].Shapes[1];
                int count = srange.Count;
                for (int i = 2; i <= count; i++)
                {
                    PowerPoint.Shape nshape = srange[i].Shapes[1];
                    nshape.Width = shape.Width;
                    nshape.Height = shape.Height;
                }
            }
        }

        public void button101_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同填充类型的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Fill.Type != Office.MsoFillType.msoFillMixed)
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        PowerPoint.Shape item = slide.Shapes[i];
                        if (item.Name == shape.Name && item.Id != shape.Id)
                        {
                            item.Name = item.Name + "_" + i;
                        }
                    }
                    List<string> list = new List<string>();
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == shape.Type && item.Fill.Type == shape.Fill.Type)
                        {
                            list.Add(item.Name);
                        }
                    }
                    slide.Shapes.Range(list.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("形状无填充");
                }

            }
        }

        public void button102_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || (sel.ShapeRange[1].Type != Office.MsoShapeType.msoFreeform && sel.ShapeRange[1].Type != Office.MsoShapeType.msoAutoShape) || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine)
            {
                MessageBox.Show("先选中一个自绘形状或线条，再选中准备吸附的图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                PowerPoint.Shape shape = range[1];
                if (shape.Type == Office.MsoShapeType.msoAutoShape)
                {
                    shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                    shape.Nodes.Delete(2);
                }
                PowerPoint.ShapeNodes nodes = shape.Nodes;
                List<float> xlist = new List<float>();
                List<float> ylist = new List<float>();

                int count = range.Count;
                int ncount = nodes.Count;
                if (count <= ncount)
                {
                    for (int i = 1; i <= count - 1; i++)
                    {
                        float x = shape.Nodes[i].Points[1, 1];
                        float y = shape.Nodes[i].Points[1, 2];
                        xlist.Add(x);
                        ylist.Add(y);
                    }
                    for (int j = 2; j <= count; j++)
                    {
                        PowerPoint.Shape shape2 = range[j];
                        shape2.Left = xlist[j - 2] - shape2.Width / 2;
                        shape2.Top = ylist[j - 2] - shape2.Height / 2;
                    }
                }
                else
                {
                    for (int i = 1; i <= ncount; i++)
                    {
                        float x = shape.Nodes[i].Points[1, 1];
                        float y = shape.Nodes[i].Points[1, 2];
                        xlist.Add(x);
                        ylist.Add(y);
                    }
                    for (int j = 2; j <= ncount + 1; j++)
                    {
                        PowerPoint.Shape shape2 = range[j];
                        shape2.Left = xlist[j - 2] - shape2.Width / 2;
                        shape2.Top = ylist[j - 2] - shape2.Height / 2;
                    }
                }

            }
        }

        public void button103_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Visible == Office.MsoTriState.msoTrue)
                    {
                        shape.Visible = Office.MsoTriState.msoFalse;
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择元素");
            }
        }

        public void button104_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.ShapeRange range = sel.ShapeRange;
            string apath = app.ActivePresentation.Path;
            PowerPoint.Shape pic = range[1];
            if (pic.Rotation == 0)
            {
                pic.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                Bitmap bmp = new Bitmap(apath + @"xshape.png");
                bmp = ResizeImage(bmp, pic.Width, pic.Height);
                int count = range.Count;
                int[,] sarr = new int[count - 1, 3];
                for (int i = 2; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    int mw = (int)(shape.Left + shape.Width / 2 - pic.Left);
                    int mh = (int)(shape.Top + shape.Height / 2 - pic.Top);
                    if (shape.Left + shape.Width / 2 < pic.Left || shape.Left + shape.Width / 2 > pic.Left + pic.Width || shape.Top + shape.Height / 2 < pic.Top || shape.Top + shape.Height / 2 > pic.Top + pic.Height)
                    {
                        mw = -1; mh = -1;
                    }
                    sarr[i - 2, 0] = mw;
                    sarr[i - 2, 1] = mh;
                    sarr[i - 2, 2] = i;
                }
                for (int j = 0; j < sarr.Length / 3; j++)
                {
                    if (sarr[j, 0] != -1 && sarr[j, 1] != -1)
                    {
                        Color color = bmp.GetPixel(sarr[j, 0], sarr[j, 1]);
                        int a = color.A;
                        if (a != 0)
                        {
                            int r = color.R; int g = color.G; int b = color.B;
                            PowerPoint.Shape shape = sel.ShapeRange[sarr[j, 2]];
                            shape.Fill.Solid();
                            shape.Fill.ForeColor.RGB = r + g * 256 + b * 256 * 256;
                        }
                    }
                }
                bmp.Dispose();
                File.Delete(apath + @"xshape.png");
            }
            else
            {
                MessageBox.Show("请勿旋转背景图");
            }
        }

        public void button3_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中一张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                for (int p = 1; p <= count; p++)
                {
                    PowerPoint.Shape npic = range[p];
                    npic.Copy();
                    PowerPoint.Shape pic = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                    pic.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                    Bitmap bmp = new Bitmap(apath + @"xshape.png");
                    bmp = ResizeImage(bmp, pic.Width, pic.Height);

                    for (int i = 0; i < bmp.Width / 10; i++)
                    {
                        for (int j = 0; j < bmp.Height / 10; j++)
                        {
                            Color color = bmp.GetPixel(i * 10, j * 10);
                            for (int m = 0; m < 10; m++)
                            {
                                for (int n = 0; n < 10; n++)
                                {
                                    bmp.SetPixel(i * 10 + m, j * 10 + n, color);
                                }
                            }
                        }
                    }
                    bmp.Save(apath + @"xshape2.png");
                    PowerPoint.Shape nshape = slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, npic.Left, npic.Top, npic.Width, npic.Height);
                    pic.Delete();
                    npic.Delete();
                    bmp.Dispose();
                    File.Delete(apath + @"xshape.png");
                    File.Delete(apath + @"xshape2.png");
                }
            }
        }

        public void button4_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            int nr = color.R * color2.R / 255;
                                            int ng = color.G * color2.G / 255;
                                            int nb = color.B * color2.B / 255;
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            int nr = color.R * color2.R / 255;
                                            int ng = color.G * color2.G / 255;
                                            int nb = color.B * color2.B / 255;
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
            }
        }

        public void button5_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            int nr = 0, ng = 0, nb = 0;
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R != 0)
                                            {
                                                nr = color.R - (255 - color.R) * (255 - color2.R) / color2.R;
                                                if (nr <= 0)
                                                {
                                                    nr = 0;
                                                }
                                            }
                                            else
                                            {
                                                nr = color2.R;
                                            }

                                            if (color2.G != 0)
                                            {
                                                ng = color.G - (255 - color.G) * (255 - color2.G) / color2.G;
                                                if (ng <= 0)
                                                {
                                                    ng = 0;
                                                }
                                            }
                                            else
                                            {
                                                ng = color2.G;
                                            }

                                            if (color2.B != 0)
                                            {
                                                nb = color.B - (255 - color.B) * (255 - color2.B) / color2.B;
                                                if (nb <= 0)
                                                {
                                                    nb = 0;
                                                }
                                            }
                                            else
                                            {
                                                nb = color2.B;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            int nr = 0, ng = 0, nb = 0;
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R != 0)
                                            {
                                                nr = color.R - (255 - color.R) * (255 - color2.R) / color2.R;
                                                if (nr <= 0)
                                                {
                                                    nr = 0;
                                                }
                                            }
                                            else
                                            {
                                                nr = color2.R;
                                            }

                                            if (color2.G != 0)
                                            {
                                                ng = color.G - (255 - color.G) * (255 - color2.G) / color2.G;
                                                if (ng <= 0)
                                                {
                                                    ng = 0;
                                                }
                                            }
                                            else
                                            {
                                                ng = color2.G;
                                            }

                                            if (color2.B != 0)
                                            {
                                                nb = color.B - (255 - color.B) * (255 - color2.B) / color2.B;
                                                if (nb <= 0)
                                                {
                                                    nb = 0;
                                                }
                                            }
                                            else
                                            {
                                                nb = color2.B;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button6_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            int nr = 0, ng = 0, nb = 0;
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R != 255)
                                            {
                                                nr = color.R + (color.R * color2.R) / (255 - color2.R);
                                                if (nr > 255)
                                                {
                                                    nr = 255;
                                                }
                                            }
                                            else
                                            {
                                                nr = color2.R;
                                            }

                                            if (color2.G != 255)
                                            {
                                                ng = color.G + (color.G * color2.G) / (255 - color2.G);
                                                if (ng > 255)
                                                {
                                                    ng = 255;
                                                }
                                            }
                                            else
                                            {
                                                ng = color2.G;
                                            }

                                            if (color2.B != 255)
                                            {
                                                nb = color.B + (color.B * color2.B) / (255 - color2.B);
                                                if (nb > 255)
                                                {
                                                    nb = 255;
                                                }
                                            }
                                            else
                                            {
                                                nb = color2.B;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            int nr = 0, ng = 0, nb = 0;
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R != 255)
                                            {
                                                nr = color.R + (color.R * color2.R) / (255 - color2.R);
                                                if (nr > 255)
                                                {
                                                    nr = 255;
                                                }
                                            }
                                            else
                                            {
                                                nr = color2.R;
                                            }

                                            if (color2.G != 255)
                                            {
                                                ng = color.G + (color.G * color2.G) / (255 - color2.G);
                                                if (ng > 255)
                                                {
                                                    ng = 255;
                                                }
                                            }
                                            else
                                            {
                                                ng = color2.G;
                                            }

                                            if (color2.B != 255)
                                            {
                                                nb = color.B + (color.B * color2.B) / (255 - color2.B);
                                                if (nb > 255)
                                                {
                                                    nb = 255;
                                                }
                                            }
                                            else
                                            {
                                                nb = color2.B;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button7_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            int nr = 0, ng = 0, nb = 0;
                                            if (color.R <= color2.R)
                                            {
                                                nr = color2.R;
                                            }
                                            else
                                            {
                                                nr = color.R;
                                            }

                                            if (color.G <= color2.G)
                                            {
                                                ng = color2.G;
                                            }
                                            else
                                            {
                                                ng = color.G;
                                            }

                                            if (color.B <= color2.B)
                                            {
                                                nb = color2.B;
                                            }
                                            else
                                            {
                                                nb = color.B;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            int nr = 0, ng = 0, nb = 0;
                                            if (color.R <= color2.R)
                                            {
                                                nr = color2.R;
                                            }
                                            else
                                            {
                                                nr = color.R;
                                            }

                                            if (color.G <= color2.G)
                                            {
                                                ng = color2.G;
                                            }
                                            else
                                            {
                                                ng = color.G;
                                            }

                                            if (color.B <= color2.B)
                                            {
                                                nb = color2.B;
                                            }
                                            else
                                            {
                                                nb = color.B;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button105_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中一张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                for (int p = 1; p <= count; p++)
                {
                    PowerPoint.Shape pic = range[p];
                    pic.Copy();
                    PowerPoint.Shape npic = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                    pic.ScaleHeight(1f, Office.MsoTriState.msoFalse, Office.MsoScaleFrom.msoScaleFromMiddle);
                    pic.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                    Bitmap bmp0 = new Bitmap(apath + @"xshape.png");

                    for (int i = 0; i < bmp0.Width; i++)
                    {
                        for (int j = 0; j < bmp0.Height; j++)
                        {
                            Color color = bmp0.GetPixel(i, j);
                            int nr = 0, ng = 0, nb = 0;
                            int na = color.A;
                            if (na != 0)
                            {
                                nr = 255 - color.R;
                                ng = 255 - color.G;
                                nb = 255 - color.B;
                                bmp0.SetPixel(i, j, Color.FromArgb(na, nr, ng, nb));
                            }
                        }
                    }
                    bmp0.Save(apath + @"xshape2.png");
                    PowerPoint.Shape pic2 = slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, pic.Left, pic.Top + pic.Height / 2 - npic.Height / 2, npic.Width, npic.Height);
                    npic.Delete();
                    bmp0.Dispose();
                    File.Delete(apath + @"xshape.png");
                    File.Delete(apath + @"xshape2.png");
                    pic.Delete();
                    pic2.Select();
                }
            }

        }

        public void button106_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            nr = color.R + color2.R - 255;
                                            ng = color.G + color2.G - 255;
                                            nb = color.B + color2.B - 255;
                                            if (nr < 0)
                                            {
                                                nr = 0;
                                            }
                                            if (ng < 0)
                                            {
                                                ng = 0;
                                            }
                                            if (nb < 0)
                                            {
                                                nb = 0;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            nr = color.R + color2.R - 255;
                                            ng = color.G + color2.G - 255;
                                            nb = color.B + color2.B - 255;
                                            if (nr < 0)
                                            {
                                                nr = 0;
                                            }
                                            if (ng < 0)
                                            {
                                                ng = 0;
                                            }
                                            if (nb < 0)
                                            {
                                                nb = 0;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public static int[] ImageSize(PowerPoint.Shape npic0, PowerPoint.Shape npic1, Bitmap bmp0, Bitmap bmp1)
        {
            try
            {
                float wm0 = npic0.Left + npic0.Width / 2;
                float wm1 = npic1.Left + npic1.Width / 2;
                float hm0 = npic0.Top + npic0.Height / 2;
                float hm1 = npic1.Top + npic1.Height / 2;

                float wl0 = wm0 - bmp0.Width / 2;
                float wl1 = wm1 - bmp1.Width / 2;
                float ht0 = hm0 - bmp0.Height / 2;
                float ht1 = hm1 - bmp1.Height / 2;
                float wr0 = wm0 + bmp0.Width / 2;
                float wr1 = wm1 + bmp1.Width / 2;
                float hb0 = hm0 + bmp0.Height / 2;
                float hb1 = hm1 + bmp1.Height / 2;

                int x = 0; int y = 0; int w = 0; int h = 0; int l = 0; int t = 0;

                if (wl1 < wl0 && wr1 > wl0)
                {
                    x = 0;
                    w = (int)(wr1 - wl0);
                    l = (int)(wl0 - wl1);
                }
                if (wl1 >= wl0 && wr1 <= wr0)
                {
                    x = (int)(wl1 - wl0);
                    w = bmp1.Width;
                    l = 0;
                }
                if (wl1 < wr0 && wr1 > wr0)
                {
                    x = (int)(wl1 - wl0);
                    w = (int)(wr0 - wl1);
                    l = 0;
                }
                if (wl1 < wl0 && wr1 > wr0)
                {
                    x = 0;
                    w = bmp0.Width;
                    l = (int)(wl0 - wl1);
                }

                if (ht1 < ht0 && hb1 > ht0)
                {
                    y = 0;
                    h = (int)(hb1 - ht0);
                    t = (int)(ht0 - ht1);
                }
                if (ht1 >= ht0 && hb1 <= hb0)
                {
                    y = (int)(ht1 - ht0);
                    h = bmp1.Height;
                    t = 0;
                }
                if (ht1 < hb0 && hb1 > hb0)
                {
                    y = (int)(ht1 - ht0);
                    h = (int)(hb0 - ht1);
                    t = 0;
                }
                if (ht1 < ht0 && hb1 > hb0)
                {
                    y = 0;
                    h = bmp0.Height;
                    t = (int)(ht0 - ht1);
                }

                if (wr1 <= wl0 || wr0 <= wl1 || hb0 <= ht1 || hb1 <= ht0)
                {
                    w = -1; h = 0; x = 0; y = 0; l = 0; t = 0;
                }

                int[] arr4 = new int[6];
                arr4[0] = w;
                arr4[1] = h;
                arr4[2] = x;
                arr4[3] = y;
                arr4[4] = l;
                arr4[5] = t;
                return arr4;
            }
            catch
            {
                return null;
            }
        }

        public static Bitmap ResizeImage(Bitmap bmp, float newW, float newH)
        {
            try
            {
                int newW2 = (int)newW;
                int newH2 = (int)newH;
                Bitmap b = new Bitmap(newW2, newH2);
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(bmp, new Rectangle(0, 0, newW2, newH2), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                bmp.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        public void button107_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            int nr = color.R + color2.R;
                                            int ng = color.G + color2.G;
                                            int nb = color.B + color2.B;
                                            if (nr > 255)
                                            {
                                                nr = 255;
                                            }
                                            if (ng > 255)
                                            {
                                                ng = 255;
                                            }
                                            if (nb > 255)
                                            {
                                                nb = 255;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            int nr = color.R + color2.R;
                                            int ng = color.G + color2.G;
                                            int nb = color.B + color2.B;
                                            if (nr > 255)
                                            {
                                                nr = 255;
                                            }
                                            if (ng > 255)
                                            {
                                                ng = 255;
                                            }
                                            if (nb > 255)
                                            {
                                                nb = 255;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button108_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            if (color.R <= 128)
                                            {
                                                nr = color.R * color2.R / 128;
                                            }
                                            else
                                            {
                                                nr = 255 - (255 - color.R) * (255 - color2.R) / 128;
                                            }

                                            if (color.G <= 128)
                                            {
                                                ng = color.G * color2.G / 128;
                                            }
                                            else
                                            {
                                                ng = 255 - (255 - color.G) * (255 - color2.G) / 128;
                                            }

                                            if (color.B <= 128)
                                            {
                                                nb = color.B * color2.B / 128;
                                            }
                                            else
                                            {
                                                nb = 255 - (255 - color.B) * (255 - color2.B) / 128;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            if (color.R <= 128)
                                            {
                                                nr = color.R * color2.R / 128;
                                            }
                                            else
                                            {
                                                nr = 255 - (255 - color.R) * (255 - color2.R) / 128;
                                            }

                                            if (color.G <= 128)
                                            {
                                                ng = color.G * color2.G / 128;
                                            }
                                            else
                                            {
                                                ng = 255 - (255 - color.G) * (255 - color2.G) / 128;
                                            }

                                            if (color.B <= 128)
                                            {
                                                nb = color.B * color2.B / 128;
                                            }
                                            else
                                            {
                                                nb = 255 - (255 - color.B) * (255 - color2.B) / 128;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button109_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R <= 128)
                                            {
                                                nr = color.R + (2 * color2.R - 255) * (color.R - color.R * color.R / 255) / 255;
                                            }
                                            else
                                            {
                                                nr = (int)(color.R + (2 * color2.R - 255) * (Math.Sqrt(color.R * 0.003921568627451) - color.R / 255));
                                            }

                                            if (color2.G <= 128)
                                            {
                                                ng = color.G + (2 * color2.G - 255) * (color.G - color.G * color.G / 255) / 255;
                                            }
                                            else
                                            {
                                                ng = (int)(color.G + (2 * color2.G - 255) * (Math.Sqrt(color.G * 0.003921568627451) - color.G / 255));
                                            }

                                            if (color2.B <= 128)
                                            {
                                                nb = color.B + (2 * color2.B - 255) * (color.B - color.B * color.B / 255) / 255;
                                            }
                                            else
                                            {
                                                nb = (int)(color.B + (2 * color2.B - 255) * (Math.Sqrt(color.B * 0.003921568627451) - color.B / 255));
                                            }
                                            if (nr > 255)
                                            {
                                                nr = 255;
                                            }
                                            if (ng > 255)
                                            {
                                                ng = 255;
                                            }
                                            if (nb > 255)
                                            {
                                                nb = 255;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R <= 128)
                                            {
                                                nr = color.R + (2 * color2.R - 255) * (color.R - color.R * color.R / 255) / 255;
                                            }
                                            else
                                            {
                                                nr = (int)(color.R + (2 * color2.R - 255) * (Math.Sqrt(color.R * 0.003921568627451) - color.R / 255));
                                            }

                                            if (color2.G <= 128)
                                            {
                                                ng = color.G + (2 * color2.G - 255) * (color.G - color.G * color.G / 255) / 255;
                                            }
                                            else
                                            {
                                                ng = (int)(color.G + (2 * color2.G - 255) * (Math.Sqrt(color.G * 0.003921568627451) - color.G / 255));
                                            }

                                            if (color2.B <= 128)
                                            {
                                                nb = color.B + (2 * color2.B - 255) * (color.B - color.B * color.B / 255) / 255;
                                            }
                                            else
                                            {
                                                nb = (int)(color.B + (2 * color2.B - 255) * (Math.Sqrt(color.B * 0.003921568627451) - color.B / 255));
                                            }
                                            if (nr > 255)
                                            {
                                                nr = 255;
                                            }
                                            if (ng > 255)
                                            {
                                                ng = 255;
                                            }
                                            if (nb > 255)
                                            {
                                                nb = 255;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button110_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R <= 128)
                                            {
                                                nr = color.R * color2.R / 128;
                                            }
                                            else
                                            {
                                                nr = 255 - (255 - color.R) * (255 - color2.R) / 128;
                                            }

                                            if (color2.G <= 128)
                                            {
                                                ng = color.G * color2.G / 128;
                                            }
                                            else
                                            {
                                                ng = 255 - (255 - color.G) * (255 - color2.G) / 128;
                                            }

                                            if (color2.B <= 128)
                                            {
                                                nb = color.B * color2.B / 128;
                                            }
                                            else
                                            {
                                                nb = 255 - (255 - color.B) * (255 - color2.B) / 128;
                                            }
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R <= 128)
                                            {
                                                nr = color.R * color2.R / 128;
                                            }
                                            else
                                            {
                                                nr = 255 - (255 - color.R) * (255 - color2.R) / 128;
                                            }

                                            if (color2.G <= 128)
                                            {
                                                ng = color.G * color2.G / 128;
                                            }
                                            else
                                            {
                                                ng = 255 - (255 - color.G) * (255 - color2.G) / 128;
                                            }

                                            if (color2.B <= 128)
                                            {
                                                nb = color.B * color2.B / 128;
                                            }
                                            else
                                            {
                                                nb = 255 - (255 - color.B) * (255 - color2.B) / 128;
                                            }
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }

                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button114_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count != 3)
            {
                MessageBox.Show("选择要合并的三张分通道图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                PowerPoint.Shape pic1 = range[1];
                PowerPoint.Shape pic2 = range[2];
                PowerPoint.Shape pic3 = range[3];
                if (pic2.Width != pic1.Width || pic2.Height != pic1.Height || pic3.Width != pic1.Width || pic3.Height != pic1.Height)
                {
                    MessageBox.Show("所选图片不是分通道图片");
                }
                else
                {

                    if (pic1.Rotation != 0)
                    {
                        float mw = pic1.Left + pic1.Width / 2;
                        float mh = pic1.Top + pic1.Height / 2;
                        pic1.Copy();
                        pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                        pic1.Left =  mw - pic1.Width / 2;
                        pic1.Top =  mh - pic1.Height / 2;
                        range[1].Delete();
                    }
                    pic1.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                    Bitmap bmp1 = new Bitmap(apath + @"xshape.png");
                    bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                    if (pic2.Rotation != 0)
                    {
                        float mw = pic2.Left + pic2.Width / 2;
                        float mh = pic2.Top + pic2.Height / 2;
                        pic2.Copy();
                        pic2 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                        pic2.Left = mw - pic2.Width / 2;
                        pic2.Top = mh - pic2.Height / 2;
                        range[2].Delete();
                    }
                    pic2.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                    Bitmap bmp2 = new Bitmap(apath + @"xshape_1.png");
                    bmp2 = ResizeImage(bmp2, pic1.Width, pic1.Height);

                    if (pic3.Rotation != 0)
                    {
                        float mw = pic3.Left + pic3.Width / 2;
                        float mh = pic3.Top + pic3.Height / 2;
                        pic3.Copy();
                        pic3 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                        pic3.Left = mw - pic3.Width / 2;
                        pic3.Top = mh - pic3.Height / 2;
                        range[3].Delete();
                    }
                    pic3.Export(apath + @"xshape_2.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                    Bitmap bmp3 = new Bitmap(apath + @"xshape_2.png");
                    bmp3 = ResizeImage(bmp3, pic1.Width, pic1.Height);

                    for (int i = 0; i < bmp1.Width; i++)
                    {
                        for (int j = 0; j < bmp1.Height; j++)
                        {
                            Color color1 = bmp1.GetPixel(i, j);
                            Color color2 = bmp2.GetPixel(i, j);
                            Color color3 = bmp3.GetPixel(i, j);
                            int na1 = color1.A;
                            int na2 = color2.A;
                            int na3 = color3.A;
                            int nr = 0, ng = 0, nb = 0;
                            if (na1 != 0 && na2 != 0 && na3 != 0)
                            {
                                na1 = ((na2 * na1) / 255 * na3) / 255;
                                nr = color1.R;
                                ng = color2.G;
                                nb = color3.B;
                                bmp1.SetPixel(i, j, Color.FromArgb(na1, nr, ng, nb));
                            }
                        }
                    }
                    bmp1.Save(apath + @"xshape2.png");
                    slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, pic1.Left + pic1.Width / 2, pic1.Top, pic1.Width, pic1.Height);
                    bmp1.Dispose();
                    bmp2.Dispose();
                    bmp3.Dispose();
                    File.Delete(apath + @"xshape.png");
                    File.Delete(apath + @"xshape_1.png");
                    File.Delete(apath + @"xshape_2.png");
                    File.Delete(apath + @"xshape2.png");
                }
            }
        }

        public void button117_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中一张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                PowerPoint.Shape pic = range[1];
                pic.Copy();
                PowerPoint.Shape npic = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                npic.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                Bitmap bmp0 = new Bitmap(apath + @"xshape.png");
                Graphics g = Graphics.FromImage(bmp0);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(bmp0, 0, 0);
                g.Dispose();
                Bitmap bmp1 = new Bitmap(bmp0);

                for (int p = 1; p <= 3; p++)
                {
                    for (int i = 0; i < bmp0.Width; i++)
                    {
                        for (int j = 0; j < bmp0.Height; j++)
                        {
                            Color color = bmp0.GetPixel(i, j);
                            int nr = 0, ng = 0, nb = 0;
                            int na = color.A;
                            if (na != 0)
                            {
                                if (p == 1)
                                {
                                    nr = color.R;
                                    ng = color.R;
                                    nb = color.R;
                                }
                                if (p == 2)
                                {
                                    nr = color.G;
                                    ng = color.G;
                                    nb = color.G;
                                }
                                if (p == 3)
                                {
                                    nr = color.B;
                                    ng = color.B;
                                    nb = color.B;
                                }
                            }
                            bmp1.SetPixel(i, j, Color.FromArgb(na, nr, ng, nb));
                        }
                    }
                    bmp1.Save(apath + @"xshape2.png");
                    slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, pic.Left + pic.Width, pic.Top + pic.Height / 2 + (2 * p - 3) * npic.Height / 2, npic.Width, npic.Height);
                    File.Delete(apath + @"xshape2.png");
                }
                npic.Delete();
                bmp0.Dispose();
                bmp1.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button119_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PicMix = Properties.Settings.Default.PicMix;
                            if (PicMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R <= 128)
                                            {
                                                if (color2.R == 0)
                                                {
                                                    nr = color2.R;
                                                }
                                                else
                                                {
                                                    nr = color.R - (255 - color.R) * (255 - 2 * color2.R) / (2 * color2.R);
                                                }
                                            }
                                            else
                                            {
                                                if (color2.R == 255)
                                                {
                                                    nr = color2.R;
                                                }
                                                else
                                                {
                                                    nr = color.R + color.R * (2 * color2.R - 255) / (2 * (255 - color2.R));
                                                }
                                            }

                                            if (color2.G <= 128)
                                            {
                                                if (color2.G == 0)
                                                {
                                                    ng = color2.G;
                                                }
                                                else
                                                {
                                                    ng = color.G - (255 - color.G) * (255 - 2 * color2.G) / (2 * color2.G);
                                                }
                                            }
                                            else
                                            {
                                                if (color2.G == 255)
                                                {
                                                    ng = color2.G;
                                                }
                                                else
                                                {
                                                    ng = color.G + color.G * (2 * color2.G - 255) / (2 * (255 - color2.G));
                                                }
                                            }

                                            if (color2.B <= 128)
                                            {
                                                if (color2.B == 0)
                                                {
                                                    nb = color2.B;
                                                }
                                                else
                                                {
                                                    nb = color.B - (255 - color.B) * (255 - 2 * color2.B) / (2 * color2.B);
                                                }
                                            }
                                            else
                                            {
                                                if (color2.B == 255)
                                                {
                                                    nb = color2.B;
                                                }
                                                else
                                                {
                                                    nb = color.B + color.B * (2 * color2.B - 255) / (2 * (255 - color2.B));
                                                }
                                            }

                                            if (nr < 0)
                                            {
                                                nr = 0;
                                            }

                                            if (ng < 0)
                                            {
                                                ng = 0;
                                            }

                                            if (nb < 0)
                                            {
                                                nb = 0;
                                            }

                                            if (nr > 255)
                                            {
                                                nr = 255;
                                            }

                                            if (ng > 255)
                                            {
                                                ng = 255;
                                            }

                                            if (nb > 255)
                                            {
                                                nb = 255;
                                            }

                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na = color2.A;
                                        int na0 = color.A;
                                        int nr = 0, ng = 0, nb = 0;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            if (color2.R <= 128)
                                            {
                                                if (color2.R == 0)
                                                {
                                                    nr = color2.R;
                                                }
                                                else
                                                {
                                                    nr = color.R - (255 - color.R) * (255 - 2 * color2.R) / (2 * color2.R);
                                                }
                                            }
                                            else
                                            {
                                                if (color2.R == 255)
                                                {
                                                    nr = color2.R;
                                                }
                                                else
                                                {
                                                    nr = color.R + color.R * (2 * color2.R - 255) / (2 * (255 - color2.R));
                                                }
                                            }

                                            if (color2.G <= 128)
                                            {
                                                if (color2.G == 0)
                                                {
                                                    ng = color2.G;
                                                }
                                                else
                                                {
                                                    ng = color.G - (255 - color.G) * (255 - 2 * color2.G) / (2 * color2.G);
                                                }
                                            }
                                            else
                                            {
                                                if (color2.G == 255)
                                                {
                                                    ng = color2.G;
                                                }
                                                else
                                                {
                                                    ng = color.G + color.G * (2 * color2.G - 255) / (2 * (255 - color2.G));
                                                }
                                            }

                                            if (color2.B <= 128)
                                            {
                                                if (color2.B == 0)
                                                {
                                                    nb = color2.B;
                                                }
                                                else
                                                {
                                                    nb = color.B - (255 - color.B) * (255 - 2 * color2.B) / (2 * color2.B);
                                                }
                                            }
                                            else
                                            {
                                                if (color2.B == 255)
                                                {
                                                    nb = color2.B;
                                                }
                                                else
                                                {
                                                    nb = color.B + color.B * (2 * color2.B - 255) / (2 * (255 - color2.B));
                                                }
                                            }

                                            if (nr < 0)
                                            {
                                                nr = 0;
                                            }

                                            if (ng < 0)
                                            {
                                                ng = 0;
                                            }

                                            if (nb < 0)
                                            {
                                                nb = 0;
                                            }

                                            if (nr > 255)
                                            {
                                                nr = 255;
                                            }

                                            if (ng > 255)
                                            {
                                                ng = 255;
                                            }

                                            if (nb > 255)
                                            {
                                                nb = 255;
                                            }

                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button115_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请至少选择2个形状或1个文本框");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                float min = tr.Characters(1).Font.Size;
                float max = tr.Characters(1).Font.Size;
                for (int i = 2; i <= tr.Characters(tr.Text.Count()).Font.Size; i++)
                {
                    float osize = tr.Characters(i).Font.Size;
                    min = Math.Min(osize, min);
                    max = Math.Max(osize, max);
                }
                if (min == max)
                {
                    MessageBox.Show("请先改变一个字符的字号");
                }
                Random rand = new Random();
                for (int i = 1; i <= tr.Text.Count(); i++)
                {
                    int ran = rand.Next((int)min, (int)max);
                    tr.Characters(i).Font.Size = ran;
                }
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float minh = range[1].GroupItems[1].Height;
                        float maxh = range[1].GroupItems[1].Height;
                        float minw = range[1].GroupItems[1].Width;
                        float maxw = range[1].GroupItems[1].Width;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float oheight = range[1].GroupItems[i].Height;
                            float owidth = range[1].GroupItems[i].Width;
                            minh = Math.Min(oheight, minh);
                            maxh = Math.Max(oheight, maxh);
                            minw = Math.Min(owidth, minw);
                            maxw = Math.Max(owidth, maxw);
                        }
                        if (minh == maxh && minw == maxw)
                        {
                            MessageBox.Show("请先改变一个形状的大小");
                        }
                        else
                        {
                            Random rand = new Random();
                            for (int j = 1; j <= range[1].GroupItems.Count; j++)
                            {
                                float oh = range[1].GroupItems[j].Height;
                                float ow = range[1].GroupItems[j].Width;
                                float top = range[1].GroupItems[j].Top + oh / 2;
                                float left = range[1].GroupItems[j].Left + ow / 2;
                                int ran1 = rand.Next((int)minh, (int)maxh);
                                int ran2 = rand.Next((int)minw, (int)maxw);
                                if (minh == maxh)
                                {
                                    range[1].GroupItems[j].Width = ran2;
                                    range[1].GroupItems[j].Left = left - range[1].GroupItems[j].Width / 2;
                                    if (range[1].GroupItems[j].LockAspectRatio == Office.MsoTriState.msoFalse)
                                    {
                                        range[1].GroupItems[j].Height = ran1;
                                        range[1].GroupItems[j].Top = top - range[1].GroupItems[j].Height / 2;
                                    }
                                }
                                else
                                {
                                    range[1].GroupItems[j].Height = ran1;
                                    range[1].GroupItems[j].Top = top - range[1].GroupItems[j].Height / 2;
                                    if (range[1].GroupItems[j].LockAspectRatio == Office.MsoTriState.msoFalse)
                                    {
                                        range[1].GroupItems[j].Width = ran2;
                                        range[1].GroupItems[j].Left = left - range[1].GroupItems[j].Width / 2;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (count >= 2)
                {
                    float minh = range[1].Height;
                    float maxh = range[1].Height;
                    float minw = range[1].Width;
                    float maxw = range[1].Width;

                    for (int i = 2; i <= count; i++)
                    {
                        float oheight = range[i].Height;
                        float owidth = range[i].Width;
                        minh = Math.Min(oheight, minh);
                        maxh = Math.Max(oheight, maxh);
                        minw = Math.Min(owidth, minw);
                        maxw = Math.Max(owidth, maxw);
                    }
                    if (minh == maxh && minw == maxw)
                    {
                        MessageBox.Show("请先改变一个形状的大小");
                    }
                    else
                    {
                        Random rand = new Random();
                        for (int j = 1; j <= count; j++)
                        {
                            float oh = range[j].Height;
                            float ow = range[j].Width;
                            float top = range[j].Top + oh / 2;
                            float left = range[j].Left + ow / 2;
                            int ran1 = rand.Next((int)minh, (int)maxh);
                            int ran2 = rand.Next((int)minw, (int)maxw);
                            if (minh == maxh)
                            {
                                range[j].Width = ran2;
                                range[j].Left = left - range[j].Width / 2;
                                if (range[j].LockAspectRatio == Office.MsoTriState.msoFalse)
                                {
                                    range[j].Height = ran1;
                                    range[j].Top = top - range[j].Height / 2;
                                }
                            }
                            else
                            {
                                range[j].Height = ran1;
                                range[j].Top = top - range[j].Height / 2;
                                if (range[j].LockAspectRatio == Office.MsoTriState.msoFalse)
                                {
                                    range[j].Width = ran2;
                                    range[j].Left = left - range[j].Width / 2;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void button116_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Action != PowerPoint.PpActionType.ppActionNone)
                    {
                        shape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Hyperlink.Delete();
                    }
                    if (shape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver].Action != PowerPoint.PpActionType.ppActionNone)
                    {
                        shape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver].Hyperlink.Delete();
                    }
                    if (shape.TextFrame.HasText == Office.MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame.TextRange.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Action != PowerPoint.PpActionType.ppActionNone)
                        {
                            shape.TextFrame.TextRange.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Hyperlink.Delete();
                        }
                        if (shape.TextFrame.TextRange.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver].Action != PowerPoint.PpActionType.ppActionNone)
                        {
                            shape.TextFrame.TextRange.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver].Hyperlink.Delete();
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange srange = sel.SlideRange;
                for (int i = 1; i <= srange.Count; i++)
                {
                    int count = srange[i].Hyperlinks.Count;
                    if (count > 0)
                    {
                        for (int j = count; j >= 1; j--)
                        {
                            srange[i].Hyperlinks[j].Delete();
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                if (sel.TextRange.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Action != PowerPoint.PpActionType.ppActionNone)
                {
                    sel.TextRange.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick].Hyperlink.Delete();
                }
                if (sel.TextRange.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver].Action != PowerPoint.PpActionType.ppActionNone)
                {
                    sel.TextRange.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver].Hyperlink.Delete();
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除超链接的页面或图形");
            }
        }

        public void button67_Click(object sender, RibbonControlEventArgs e)
        {
            Picture_Assist Picture_Assist = null;
            if (Picture_Assist == null || Picture_Assist.IsDisposed)
            {
                Picture_Assist = new Picture_Assist();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Picture_Assist.Show();
                button67.Enabled = false;
            }
        }

        public void button94_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("选中文本框，本功能会将黑色文字透明化");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                int nc = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.TextFrame2 tf2 = sel.ShapeRange[i].TextFrame2;
                    int len1 = tf2.TextRange.Characters.Length;
                    for (int j = 1; j <= len1; j++)
                    {
                        if (tf2.TextRange.Characters[j, 1].Font.Fill.ForeColor.RGB == 0)
                        {
                            tf2.TextRange.Characters[j, 1].Font.Fill.Transparency = 1f;
                            nc += 1;
                        }
                    }
                }
                if (nc == 0)
                {
                    MessageBox.Show("没有黑色文字被处理");
                }
            }
        }

        public void button118_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("选中文本框，本功能会将黑色文字透明化");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                int nc = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.TextFrame2 tf2 = sel.ShapeRange[i].TextFrame2;
                    int len1 = tf2.TextRange.Characters.Length;
                    for (int j = 1; j <= len1; j++)
                    {
                        if (tf2.TextRange.Characters[j, 1].Font.Fill.ForeColor.RGB == 255 + 255 * 256 + 255 * 256 * 256)
                        {
                            tf2.TextRange.Characters[j, 1].Font.Fill.Transparency = 1f;
                            nc += 1;
                        }
                    }
                }
                if (nc == 0)
                {
                    MessageBox.Show("没有白色文字被处理");
                }
            }
        }

        public void button120_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://weibo.com/paralife");
        }

        public void button122_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform || shape.Type == Office.MsoShapeType.msoLine)
                    {
                        if (shape.Fill.Visible == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                            {
                                if (shape.Shadow.Visible == Office.MsoTriState.msoFalse)
                                {
                                    shape.Shadow.Visible = Office.MsoTriState.msoTrue;
                                }
                                shape.Shadow.ForeColor.RGB = shape.Fill.ForeColor.RGB;
                            }
                            else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                if (shape.Shadow.Visible == Office.MsoTriState.msoFalse)
                                {
                                    shape.Shadow.Visible = Office.MsoTriState.msoTrue;
                                }
                                shape.Shadow.ForeColor.RGB = shape.Fill.GradientStops[1].Color.RGB;
                            }
                            else
                            {
                                n += 1;
                            }
                        }
                        else if (shape.Fill.Visible == Office.MsoTriState.msoFalse && shape.Line.Visible == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Shadow.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Shadow.Visible = Office.MsoTriState.msoTrue;
                            }
                            shape.Shadow.ForeColor.RGB = shape.Line.ForeColor.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.Type == Office.MsoShapeType.msoAutoShape || gshape.Type == Office.MsoShapeType.msoFreeform)
                            {
                                if (gshape.Fill.Visible == Office.MsoTriState.msoTrue)
                                {
                                    if (gshape.Fill.Type == Office.MsoFillType.msoFillSolid)
                                    {
                                        if (gshape.Shadow.Visible == Office.MsoTriState.msoFalse)
                                        {
                                            gshape.Shadow.Visible = Office.MsoTriState.msoTrue;
                                        }
                                        gshape.Shadow.ForeColor.RGB = gshape.Fill.ForeColor.RGB;
                                    }
                                    else if (gshape.Fill.Type == Office.MsoFillType.msoFillGradient)
                                    {
                                        if (gshape.Shadow.Visible == Office.MsoTriState.msoFalse)
                                        {
                                            gshape.Shadow.Visible = Office.MsoTriState.msoTrue;
                                        }
                                        gshape.Shadow.ForeColor.RGB = gshape.Fill.GradientStops[1].Color.RGB;
                                    }
                                    else
                                    {
                                        n += 1;
                                    }
                                }
                            }
                            else if (gshape.Fill.Visible == Office.MsoTriState.msoFalse && gshape.Line.Visible == Office.MsoTriState.msoTrue)
                            {
                                if (gshape.Shadow.Visible == Office.MsoTriState.msoFalse)
                                {
                                    gshape.Shadow.Visible = Office.MsoTriState.msoTrue;
                                }
                                gshape.Shadow.ForeColor.RGB = gshape.Line.ForeColor.RGB;
                            }
                            else
                            {
                                n += 1;
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中纯色填充或纯色线条的形状");
                } 
            }
            else
            {
                MessageBox.Show("请先选中一个纯色填充或纯色线条的形状");
            }
        }

        public void button121_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform)
                    {
                        if (shape.Fill.Visible == Office.MsoTriState.msoTrue && shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                        {
                            if (shape.Line.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Line.Visible = Office.MsoTriState.msoTrue;
                                shape.Line.Weight = 2;
                            }
                            shape.Line.ForeColor.RGB = shape.Fill.ForeColor.RGB;
                        }
                        else if (shape.Fill.Visible == Office.MsoTriState.msoTrue && shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                        {
                            if (shape.Line.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Line.Visible = Office.MsoTriState.msoTrue;
                                shape.Line.Weight = 2;
                            }
                            shape.Line.ForeColor.RGB = shape.Fill.GradientStops[1].Color.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.Type == Office.MsoShapeType.msoAutoShape || gshape.Type == Office.MsoShapeType.msoFreeform)
                            {
                                if (gshape.Fill.Visible == Office.MsoTriState.msoTrue && gshape.Fill.Type == Office.MsoFillType.msoFillSolid)
                                {
                                    if (gshape.Line.Visible == Office.MsoTriState.msoFalse)
                                    {
                                        gshape.Line.Visible = Office.MsoTriState.msoTrue;
                                        gshape.Line.Weight = 2;
                                    }
                                    gshape.Line.ForeColor.RGB = gshape.Fill.ForeColor.RGB;
                                }
                                else if (shape.Fill.Visible == Office.MsoTriState.msoTrue && gshape.Fill.Type == Office.MsoFillType.msoFillGradient)
                                {
                                    if (gshape.Line.Visible == Office.MsoTriState.msoFalse)
                                    {
                                        gshape.Line.Visible = Office.MsoTriState.msoTrue;
                                        gshape.Line.Weight = 2;
                                    }
                                    gshape.Line.ForeColor.RGB = gshape.Fill.GradientStops[1].Color.RGB;
                                }
                                else
                                {
                                    n += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中有纯色填充的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个纯色填充的形状");
            }
        }

        public void button123_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform || shape.Type == Office.MsoShapeType.msoLine)
                    {
                        if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Fill.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Fill.Visible = Office.MsoTriState.msoTrue;
                            }
                            shape.Fill.ForeColor.RGB = shape.Line.ForeColor.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.Type == Office.MsoShapeType.msoAutoShape || gshape.Type == Office.MsoShapeType.msoFreeform)
                            {
                                if (gshape.Line.Visible == Office.MsoTriState.msoTrue)
                                {
                                    if (gshape.Fill.Visible == Office.MsoTriState.msoFalse)
                                    {
                                        gshape.Fill.Visible = Office.MsoTriState.msoTrue;
                                    }
                                    gshape.Fill.ForeColor.RGB = gshape.Line.ForeColor.RGB;
                                }
                                else
                                {
                                    n += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中纯色线条的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个纯色线条的形状");
            }
        }

        public void button124_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform)
                    {
                        if (shape.Shadow.Visible == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Fill.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Fill.Visible = Office.MsoTriState.msoTrue;
                            }
                            shape.Fill.ForeColor.RGB = shape.Shadow.ForeColor.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.Type == Office.MsoShapeType.msoAutoShape || gshape.Type == Office.MsoShapeType.msoFreeform)
                            {
                                if (gshape.Shadow.Visible == Office.MsoTriState.msoTrue)
                                {
                                    if (gshape.Fill.Visible == Office.MsoTriState.msoFalse)
                                    {
                                        gshape.Fill.Visible = Office.MsoTriState.msoTrue;
                                    }
                                    gshape.Fill.ForeColor.RGB = gshape.Shadow.ForeColor.RGB;
                                }
                                else
                                {
                                    n += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中带阴影的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个带阴影的形状");
            }
        }

        public void button125_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform || shape.Type == Office.MsoShapeType.msoLine)
                    {
                        if (shape.Shadow.Visible == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Line.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Line.Visible = Office.MsoTriState.msoTrue;
                                shape.Line.Weight = 2;
                            }
                            shape.Line.ForeColor.RGB = shape.Shadow.ForeColor.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.Type == Office.MsoShapeType.msoAutoShape || gshape.Type == Office.MsoShapeType.msoFreeform)
                            {
                                if (gshape.Shadow.Visible == Office.MsoTriState.msoTrue)
                                {
                                    if (gshape.Line.Visible == Office.MsoTriState.msoFalse)
                                    {
                                        gshape.Line.Visible = Office.MsoTriState.msoTrue;
                                        gshape.Line.Weight = 2;
                                    }
                                    gshape.Line.ForeColor.RGB = gshape.Shadow.ForeColor.RGB;
                                }
                                else
                                {
                                    n += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中有阴影的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个带阴影的形状");
            }
        }

        public void button127_Click(object sender, RibbonControlEventArgs e)
        {
            OK_Settings setting1 = null;
            if (setting1 == null || setting1.IsDisposed)
            {
                setting1 = new OK_Settings();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                setting1.Show();
                button127.Enabled = false;
            }
        }

        public void button128_Click(object sender, RibbonControlEventArgs e)
        {
            OK_FocusOn OK_FocusOn = null;
            if (OK_FocusOn == null || OK_FocusOn.IsDisposed)
            {
                OK_FocusOn = new OK_FocusOn();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                OK_FocusOn.Show();
            }
        }

        public void button129_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            int count3 = gshape.Nodes.Count;
                            for (int k = 1; k < count3; k++)
                            {
                                float x = gshape.Nodes[k].Points[1, 1];
                                float y = gshape.Nodes[k].Points[1, 2];
                                float x2 = gshape.Nodes[k + 1].Points[1, 1];
                                float y2 = gshape.Nodes[k + 1].Points[1, 2];
                                if (Math.Abs(y - y2) < 10)
                                {
                                    gshape.Nodes.SetPosition(k + 1, x2, y);
                                }
                            }
                        }
                    }
                    int count4 = shape.Nodes.Count;
                    for (int k = 1; k < count4; k++)
                    {
                        float x = shape.Nodes[k].Points[1, 1];
                        float y = shape.Nodes[k].Points[1, 2];
                        float x2 = shape.Nodes[k + 1].Points[1, 1];
                        float y2 = shape.Nodes[k + 1].Points[1, 2];
                        if (Math.Abs(y - y2) < 10)
                        {
                            shape.Nodes.SetPosition(k + 1, x2, y);
                        }
                    }
                }
            }
        }

        public void button130_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            int count3 = gshape.Nodes.Count;
                            for (int k = 1; k < count3; k++)
                            {
                                float x = gshape.Nodes[k].Points[1, 1];
                                float y = gshape.Nodes[k].Points[1, 2];
                                float x2 = gshape.Nodes[k + 1].Points[1, 1];
                                float y2 = gshape.Nodes[k + 1].Points[1, 2];
                                if (Math.Abs(x - x2) < 10)
                                {
                                    gshape.Nodes.SetPosition(k + 1, x, y2);
                                }
                            }
                        }
                    }
                    int count4 = shape.Nodes.Count;
                    for (int k = 1; k < count4; k++)
                    {
                        shape.Nodes.SetSegmentType(k + 1, Office.MsoSegmentType.msoSegmentLine);
                        float x = shape.Nodes[k].Points[1, 1];
                        float y = shape.Nodes[k].Points[1, 2];
                        float x2 = shape.Nodes[k + 1].Points[1, 1];
                        float y2 = shape.Nodes[k + 1].Points[1, 2];
                        if (Math.Abs(x - x2) < 10)
                        {
                            shape.Nodes.SetPosition(k + 1, x, y2);
                        }
                    }
                }
            }
        }

        public void button131_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                int scount = shape.Nodes.Count;
                if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform)
                {
                    PowerPoint.Shape nshape = shape.Duplicate()[1];
                    int count = nshape.Nodes.Count;

                    for (int j = count - 1; j >= 1; j--)
                    {
                        if (nshape.Nodes[j].SegmentType == Office.MsoSegmentType.msoSegmentCurve)
                        {
                            nshape.Nodes.SetSegmentType(j, Office.MsoSegmentType.msoSegmentLine);
                            count -= 1;
                        }
                    }
                    int count2 = nshape.Nodes.Count;
                    nshape.Delete();
                    MessageBox.Show("顶点数：" + count2);
                }
                else
                {
                    MessageBox.Show("只支持矢量形状");
                }
            }
        }

        public void button132_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    int count4 = shape.Nodes.Count;
                    float sq = (float)Math.Sqrt(12);
                    for (int k = 1; k < count4; k += 4)
                    {
                        shape.Nodes.SetSegmentType(k + 1, Office.MsoSegmentType.msoSegmentLine);
                        float x = shape.Nodes[k].Points[1, 1];
                        float y = shape.Nodes[k].Points[1, 2];
                        float x2 = shape.Nodes[k + 1].Points[1, 1];
                        float y2 = shape.Nodes[k + 1].Points[1, 2];
                        float a = x2 - x;
                        float b = y2 - y;
                        float a2 = (x2 + x) / 2;
                        float b2 = (y2 + y) / 2;
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, x + 2 * a / 3, y + 2 * b / 3);
                        float nx = (float)Math.Abs(b) / sq;
                        float ny = (float)Math.Abs(a) / sq;
                        if (x2 >= x)
                        {
                            if (y2 <= y)
                            {
                                nx = a2 - nx;
                                ny = b2 - ny;
                            }
                            else
                            {
                                nx = a2 + nx;
                                ny = b2 - ny;
                            }
                        }
                        else
                        {
                            if (y2 <= y)
                            {
                                nx = a2 - nx;
                                ny = b2 + ny;
                            }
                            else
                            {
                                nx = a2 + nx;
                                ny = b2 + ny;
                            }
                        }
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, nx, ny);
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, x + a / 3, y + b / 3);
                        count4 += 3;
                    }
                }
            }
        }

        public void button133_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    int count4 = shape.Nodes.Count;
                    for (int k = 1; k < count4; k += 5)
                    {
                        shape.Nodes.SetSegmentType(k + 1, Office.MsoSegmentType.msoSegmentLine);
                        float x = shape.Nodes[k].Points[1, 1];
                        float y = shape.Nodes[k].Points[1, 2];
                        float x2 = shape.Nodes[k + 1].Points[1, 1];
                        float y2 = shape.Nodes[k + 1].Points[1, 2];
                        float a = x2 - x;
                        float b = y2 - y;
                        float a2 = (2 * x2 + x) / 3;
                        float b2 = (2 * y2 + y) / 3;
                        float a3 = (2 * x + x2) / 3;
                        float b3 = (2 * y + y2) / 3;

                        float nx = (float)Math.Abs(b) / 3;
                        float ny = (float)Math.Abs(a) / 3;
                        float nx2 = (float)Math.Abs(b) / 3;
                        float ny2 = (float)Math.Abs(a) / 3;

                        if (x2 >= x)
                        {
                            if (y2 <= y)
                            {
                                nx = a2 - nx;
                                ny = b2 - ny;
                                nx2 = a3 - nx2;
                                ny2 = b3 - ny2;
                            }
                            else
                            {
                                nx = a2 + nx;
                                ny = b2 - ny;
                                nx2 = a3 + nx2;
                                ny2 = b3 - ny2;
                            }
                        }
                        else
                        {
                            if (y2 <= y)
                            {
                                nx = a2 - nx;
                                ny = b2 + ny;
                                nx2 = a3 - nx2;
                                ny2 = b3 + ny2;
                            }
                            else
                            {
                                nx = a2 + nx;
                                ny = b2 + ny;
                                nx2 = a3 + nx2;
                                ny2 = b3 + ny2;
                            }
                        }
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, a2, b2);
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, nx, ny);
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, nx2, ny2);
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, a3, b3);
                        count4 += 4;
                    }
                }
            }
        }

        public void button134_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    int count4 = shape.Nodes.Count;
                    float sq = (float)Math.Sqrt(12);
                    for (int k = 1; k < count4; k += 5)
                    {
                        shape.Nodes.SetSegmentType(k + 1, Office.MsoSegmentType.msoSegmentLine);
                        float x = shape.Nodes[k].Points[1, 1];
                        float y = shape.Nodes[k].Points[1, 2];
                        float x2 = shape.Nodes[k + 1].Points[1, 1];
                        float y2 = shape.Nodes[k + 1].Points[1, 2];
                        float a = x2 - x;
                        float b = y2 - y;
                        float a2 = (2 * x2 + x) / 3;
                        float b2 = (2 * y2 + y) / 3;
                        float a3 = (x2 + 2 * x) / 3;
                        float b3 = (y2 + 2 * y) / 3;

                        float nx = (float)Math.Abs(b) / sq;
                        float ny = (float)Math.Abs(a) / sq;
                        float nx2 = (float)Math.Abs(b) / sq;
                        float ny2 = (float)Math.Abs(a) / sq;

                        if (x2 >= x)
                        {
                            if (y2 <= y)
                            {
                                nx = a2 - nx;
                                ny = b2 - ny;
                                nx2 = a3 - nx2;
                                ny2 = b3 - ny2;
                            }
                            else
                            {
                                nx = a2 + nx;
                                ny = b2 - ny;
                                nx2 = a3 + nx2;
                                ny2 = b3 - ny2;
                            }
                        }
                        else
                        {
                            if (y2 <= y)
                            {
                                nx = a2 - nx;
                                ny = b2 + ny;
                                nx2 = a3 - nx2;
                                ny2 = b3 + ny2;
                            }
                            else
                            {
                                nx = a2 + nx;
                                ny = b2 + ny;
                                nx2 = a3 + nx2;
                                ny2 = b3 + ny2;
                            }
                        }

                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, (5 * x2 + x) / 6, (5 * y2 + y) / 6);
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, nx, ny);
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, nx2, ny2);
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, (x2 + 5 * x) / 6, (y2 + 5 * y) / 6);
                        count4 += 4;
                    }
                }
            }
        }

        public void button135_Click(object sender, RibbonControlEventArgs e)
        {
            Align_Adsorption Align_Adsorption = null;
            if (Align_Adsorption == null || Align_Adsorption.IsDisposed)
            {
                Align_Adsorption = new Align_Adsorption();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Align_Adsorption.Show();
                button135.Enabled = false;
            }
        }

        public void button136_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("选中设置了3D旋转的图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                string a = range[1].ThreeD.PresetCamera.ToString();
                MessageBox.Show(a);
            }
        }

        public void button138_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || (sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup) || (sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && sel.ShapeRange[1].GroupItems.Count < 3) || (sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup && sel.ShapeRange.Count < 3))
            {
                MessageBox.Show("请选择至少3个不同位置的形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float minl = range[1].GroupItems[1].Left + range[1].GroupItems[1].Width;
                        float maxl = range[1].GroupItems[1].Left + range[1].GroupItems[1].Width;
                        float mint = range[1].GroupItems[1].Top + range[1].GroupItems[1].Height;
                        float maxt = range[1].GroupItems[1].Top + range[1].GroupItems[1].Height;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float oleft = range[1].GroupItems[i].Left + range[1].GroupItems[i].Width;
                            float otop = range[1].GroupItems[i].Top + range[1].GroupItems[i].Height;
                            minl = Math.Min(oleft, minl);
                            maxl = Math.Max(oleft, maxl);
                            mint = Math.Min(otop, mint);
                            maxt = Math.Max(otop, maxt);
                        }
                        if (minl == maxl && mint == maxt)
                        {
                            MessageBox.Show("请先改变一个形状的位置");
                        }
                        else
                        {
                            Random rand = new Random();
                            for (int j = 2; j < range[1].GroupItems.Count; j++)
                            {
                                int ran1 = rand.Next((int)minl, (int)maxl);
                                int ran2 = rand.Next((int)mint, (int)maxt);
                                range[1].GroupItems[j].Left = (j - j + 1) * ran1 - range[1].GroupItems[j].Width;
                                range[1].GroupItems[j].Top = (j - j + 1) * ran2 - range[1].GroupItems[j].Height;
                            }
                        }
                    }
                }
                else if (count >= 2)
                {
                    float minl = range[1].Left + range[1].Width;
                    float maxl = range[1].Left + range[1].Width;
                    float mint = range[1].Top + range[1].Height;
                    float maxt = range[1].Top + range[1].Height;

                    for (int i = 2; i <= range.Count; i++)
                    {
                        float oleft = range[i].Left + range[i].Width;
                        float otop = range[i].Top + range[i].Height;
                        minl = Math.Min(oleft, minl);
                        maxl = Math.Max(oleft, maxl);
                        mint = Math.Min(otop, mint);
                        maxt = Math.Max(otop, maxt);
                    }
                    if (minl == maxl && mint == maxt)
                    {
                        MessageBox.Show("请先改变一个形状的位置");
                    }
                    else
                    {
                        Random rand = new Random();
                        for (int j = 2; j < range.Count; j++)
                        {
                            int ran1 = rand.Next((int)minl, (int)maxl);
                            int ran2 = rand.Next((int)mint, (int)maxt);
                            range[j].Left = (j - j + 1) * ran1 - range[j].Width;
                            range[j].Top = (j - j + 1) * ran2 - range[j].Height;
                        }
                    }
                }
            }
        }

        public void button140_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选择一个纯色或者渐变形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int scount = range.Count;
                for (int i = 1; i <= scount; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= shape.GroupItems.Count; j++)
                        {
                            PowerPoint.Shape nshape = shape.GroupItems[j];
                            if (nshape.Fill.Type == Office.MsoFillType.msoFillSolid)
                            {
                                int color = nshape.Fill.ForeColor.RGB;
                                float tr = nshape.Fill.Transparency;
                                nshape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1.0f);
                                nshape.Fill.GradientStops[1].Color.RGB = color;
                                nshape.Fill.GradientStops[1].Transparency = tr;
                                nshape.Fill.GradientStops[2].Color.RGB = color;
                                nshape.Fill.GradientStops[2].Transparency = 1f;
                            }
                            else if (nshape.Fill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                int gcnt = nshape.Fill.GradientStops.Count;
                                if (gcnt > 2)
                                {
                                    float[,] arr = new float[gcnt, 5];
                                    float[,] arr2 = new float[gcnt, 5];
                                    List<float> max = new List<float>();

                                    for (int k = 1; k <= gcnt; k++)
                                    {
                                        arr[k - 1, 0] = k;
                                        arr[k - 1, 1] = nshape.Fill.GradientStops[k].Position;
                                        arr[k - 1, 2] = nshape.Fill.GradientStops[k].Color.RGB;
                                        arr[k - 1, 3] = nshape.Fill.GradientStops[k].Transparency;
                                        arr[k - 1, 4] = nshape.Fill.GradientStops[k].Color.Brightness;
                                        max.Add(nshape.Fill.GradientStops[k].Position);
                                    }
                                    max.Sort();

                                    for (int m = 0; m < max.Count; m++)
                                    {
                                        for (int k = 0; k < arr.Length / 5; k++)
                                        {
                                            if (arr[k, 1] == max[m])
                                            {
                                                arr2[m, 0] = arr[k, 0];
                                                arr2[m, 1] = arr[k, 1];
                                                arr2[m, 2] = arr[k, 2];
                                                arr2[m, 3] = arr[k, 3];
                                                arr2[m, 4] = arr[k, 4];
                                                break;
                                            }
                                        }
                                    }

                                    nshape.Fill.GradientStops[gcnt].Color.RGB = nshape.Fill.GradientStops[1].Color.RGB;
                                    nshape.Fill.GradientStops[gcnt].Position = 1f;
                                    nshape.Fill.GradientStops[gcnt].Transparency = 1f;

                                    for (int k = gcnt - 1; k >= 2; k--)
                                    {
                                        nshape.Fill.GradientStops.Delete(k);
                                    }
                                }
                                else
                                {
                                    nshape.Fill.GradientStops[2].Color.RGB = nshape.Fill.GradientStops[1].Color.RGB;
                                    nshape.Fill.GradientStops[2].Transparency = 1f;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                        {
                            int color = shape.Fill.ForeColor.RGB;
                            float tr = shape.Fill.Transparency;
                            shape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1.0f);
                            shape.Fill.GradientStops[1].Color.RGB = color;
                            shape.Fill.GradientStops[1].Transparency = tr;
                            shape.Fill.GradientStops[2].Color.RGB = color;
                            shape.Fill.GradientStops[2].Transparency = 1f;
                        }
                        else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                        {
                            if (shape.Fill.GradientStops.Count > 2)
                            {
                                int gcnt = shape.Fill.GradientStops.Count;
                                float[,] arr = new float[gcnt, 5];
                                float[,] arr2 = new float[gcnt, 5];
                                List<float> max = new List<float>();

                                for (int k = 1; k <= gcnt; k++)
                                {
                                    arr[k - 1, 0] = k;
                                    arr[k - 1, 1] = shape.Fill.GradientStops[k].Position;
                                    arr[k - 1, 2] = shape.Fill.GradientStops[k].Color.RGB;
                                    arr[k - 1, 3] = shape.Fill.GradientStops[k].Transparency;
                                    arr[k - 1, 4] = shape.Fill.GradientStops[k].Color.Brightness;
                                    max.Add(shape.Fill.GradientStops[k].Position);
                                }
                                max.Sort();

                                for (int j = 0; j < max.Count; j++)
                                {
                                    for (int k = 0; k < arr.Length / 5; k++)
                                    {
                                        if (arr[k, 1] == max[j])
                                        {
                                            arr2[j, 0] = arr[k, 0];
                                            arr2[j, 1] = arr[k, 1];
                                            arr2[j, 2] = arr[k, 2];
                                            arr2[j, 3] = arr[k, 3];
                                            arr2[j, 4] = arr[k, 4];
                                            break;
                                        }
                                    }
                                }

                                for (int j = 0; j < arr2.Length / 5; j++)
                                {
                                    shape.Fill.GradientStops[j + 1].Position = arr2[j, 1];
                                    shape.Fill.GradientStops[j + 1].Color.RGB = (int)arr2[j, 2];
                                    shape.Fill.GradientStops[j + 1].Transparency = arr2[j, 3];
                                    shape.Fill.GradientStops[j + 1].Color.Brightness = arr2[j, 4];
                                }

                                shape.Fill.GradientStops[gcnt].Color.RGB = shape.Fill.GradientStops[1].Color.RGB;
                                shape.Fill.GradientStops[gcnt].Position = 1f;
                                shape.Fill.GradientStops[gcnt].Transparency = 1f;

                                for (int k = gcnt - 1; k >= 2; k--)
                                {
                                    shape.Fill.GradientStops.Delete(k);
                                }
                            }
                            else
                            {
                                shape.Fill.GradientStops[2].Color.RGB = shape.Fill.GradientStops[1].Color.RGB;
                                shape.Fill.GradientStops[2].Transparency = 1f;
                            }
                        }
                    }
                }
            }
        }

        public void button141_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请先选中一张图片");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                string apath = app.ActivePresentation.Path;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                for (int p = 1; p <= count; p++)
                {
                    PowerPoint.Shape pic = range[p];
                    pic.Copy();
                    PowerPoint.Shape npic = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                    if (npic.Width >= npic.Height)
                    {
                        pic.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp0 = new Bitmap(apath + @"xshape.png");
                        Graphics g = Graphics.FromImage(bmp0);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.DrawImage(bmp0, 0, 0);
                        g.Dispose();
                        int row = bmp0.Width;
                        int col = bmp0.Height;
                        Bitmap bmp1 = new Bitmap(col * 2, col * 2);
                        double mx = ((double)bmp1.Width - 1) / 2;
                        double my = ((double)bmp1.Height - 1) / 2;
                        double ppi = Math.PI / 180;
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                Color color = bmp0.GetPixel(i, j);
                                double a = (double)i / (double)row * 360 + 90;
                                double a2 = a * ppi;
                                double x = 0;
                                double y = 0;
                                double nx = (double)j * Math.Cos(a2);
                                double ny = (double)j * Math.Sin(a2);
                                x = mx + nx;
                                y = my - ny;
                                int ex = (int)x;
                                int ey = (int)y;
                                if (ex < x)
                                {
                                    ex = ex + 1;
                                    bmp1.SetPixel(ex, ey, color);
                                }
                                if (ey < y)
                                {
                                    ey = ey + 1;
                                    bmp1.SetPixel(ex, ey, color);
                                }
                                bmp1.SetPixel((int)x, (int)y, color);
                            }
                        }
                        int whn = (bmp1.Width + 1) / 2 - 1;
                        int hh = bmp1.Height * bmp1.Height / 4;
                        for (int i = 0; i < whn; i++)
                        {
                            for (int j = 0; j < whn; j++)
                            {
                                if (i * i + j * j <= hh)
                                {
                                    int x = (int)mx - i;
                                    int y = (int)my - j;
                                    Color color = bmp1.GetPixel(x, y);
                                    int a = color.A;
                                    if (a == 0)
                                    {
                                        Color color2 = bmp1.GetPixel(x + 1, y - 1);
                                        Color color3 = bmp1.GetPixel(x - 1, y + 1);
                                        Color ncolor = Pcut(color2, color3);
                                        bmp1.SetPixel(x, y, ncolor);
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < whn; i++)
                        {
                            for (int j = 0; j < whn; j++)
                            {
                                if (i * i + j * j <= hh)
                                {
                                    int x = (int)mx - i;
                                    int y = (int)my + j;
                                    Color color = bmp1.GetPixel(x, y);
                                    int a = color.A;
                                    if (a == 0)
                                    {
                                        Color color2 = bmp1.GetPixel(x + 1, y + 1);
                                        Color color3 = bmp1.GetPixel(x - 1, y - 1);
                                        Color ncolor = Pcut(color2, color3);
                                        bmp1.SetPixel(x, y, ncolor);
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < whn; i++)
                        {
                            for (int j = 0; j < whn; j++)
                            {
                                if (i * i + j * j <= hh)
                                {
                                    int x = (int)mx + i;
                                    int y = (int)my - j;
                                    Color color = bmp1.GetPixel(x, y);
                                    int a = color.A;
                                    if (a == 0)
                                    {
                                        Color color2 = bmp1.GetPixel(x - 1, y - 1);
                                        Color color3 = bmp1.GetPixel(x + 1, y + 1);
                                        Color ncolor = Pcut(color2, color3);
                                        bmp1.SetPixel(x, y, ncolor);
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < whn; i++)
                        {
                            for (int j = 0; j < whn; j++)
                            {
                                if (i * i + j * j <= hh)
                                {
                                    int x = (int)mx + i;
                                    int y = (int)my + j;
                                    Color color = bmp1.GetPixel(x, y);
                                    int a = color.A;
                                    if (a == 0)
                                    {
                                        Color color2 = bmp1.GetPixel(x - 1, y + 1);
                                        Color color3 = bmp1.GetPixel(x + 1, y - 1);
                                        Color ncolor = Pcut(color2, color3);
                                        bmp1.SetPixel(x, y, ncolor);
                                    }
                                }
                            }
                        }
                        bmp1.Save(apath + @"xshape2.png");
                        bmp1.Dispose();
                        PowerPoint.Shape pic2 = slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, pic.Left, pic.Top + pic.Height / 2 - npic.Height / 2, npic.Height, npic.Height);
                        npic.Delete();
                        bmp0.Dispose();
                        File.Delete(apath + @"xshape.png");
                        File.Delete(apath + @"xshape2.png");
                        pic.Delete();
                        pic2.Select();
                    }
                    else
                    {
                        npic.Delete();
                        MessageBox.Show("仅支持宽度大于高度的图片,可将图片旋转90°后再来尝试");
                    }
                }
            }
        }
        private int[] XTo(int i, int j, Bitmap bmp0)
        {
            double r = Math.Sqrt(i * i + j * j);
            double a = Math.Atan(j / i);
            int x = (int)(r * Math.Cos(a));
            int y = (int)(r * Math.Sin(a));
            int[] arr = new int[2];
            arr[0] = x;
            arr[1] = y;
            return arr;
        }

        public void button142_Click(object sender, RibbonControlEventArgs e)
        {
            ThreeD_Show ThreeD_Show = null;
            if (ThreeD_Show == null || ThreeD_Show.IsDisposed)
            {
                ThreeD_Show = new ThreeD_Show();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                ThreeD_Show.Show();
                button142.Enabled = false;
            }
        }

        private Color Pcut(Color color2, Color color3)
        {
            int r2 = color2.R;
            int g2 = color2.G;
            int b2 = color2.B;
            int r3 = color3.R;
            int g3 = color3.G;
            int b3 = color3.B;
            int ap2 = color2.A;
            int ap3 = color3.A;
            int nr = r2 * 9 / 10 + r3 * 1 / 10;
            int ng = g2 * 9 / 10 + g3 * 1 / 10;
            int nb = b2 * 9 / 10 + b3 * 1 / 10;
            int na = ap2 * 9 / 10 + ap3 * 1 / 10;
            Color ncolor = Color.FromArgb(na, nr, ng, nb);
            return ncolor;
        }

        public void button146_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同填充透明度的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        PowerPoint.Shape item = slide.Shapes[i];
                        if (item.Name == shape.Name && item.Id != shape.Id)
                        {
                            item.Name = item.Name + "_" + i;
                        }
                    }
                    List<string> list = new List<string>();
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == shape.Type && item.Fill.Type == shape.Fill.Type && item.Fill.Transparency == shape.Fill.Transparency)
                        {
                            list.Add(item.Name);
                        }
                    }
                    slide.Shapes.Range(list.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("形状不是纯色填充");
                }
            }
        }

        public void button147_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同类型的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                for (int i = 1; i <= slide.Shapes.Count; i++)
                {
                    PowerPoint.Shape item = slide.Shapes[i];
                    if (item.Name == shape.Name && item.Id != shape.Id)
                    {
                        item.Name = item.Name + "_" + i;
                    }
                }
                List<string> list = new List<string>();
                foreach (PowerPoint.Shape item in slide.Shapes)
                {
                    if (item.Type == shape.Type)
                    {
                        list.Add(item.Name);
                    }
                }
                slide.Shapes.Range(list.ToArray()).Select();
            }
        }

        public void button148_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同渐变光圈数的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        PowerPoint.Shape item = slide.Shapes[i];
                        if (item.Name == shape.Name && item.Id != shape.Id)
                        {
                            item.Name = item.Name + "_" + i;
                        }
                    }

                    List<string> list = new List<string>();
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == shape.Type && item.Fill.Type == shape.Fill.Type && item.Fill.GradientStops.Count == shape.Fill.GradientStops.Count)
                        {
                            list.Add(item.Name);
                        }
                    }
                    slide.Shapes.Range(list.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("所选形状不是渐变填充");
                }
            }
        }

        public void button149_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同填充颜色的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        PowerPoint.Shape item = slide.Shapes[i];
                        if (item.Name == shape.Name && item.Id != shape.Id)
                        {
                            item.Name = item.Name + "_" + i;
                        }
                    }
                    List<string> list = new List<string>();
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == shape.Type && item.Fill.Type == shape.Fill.Type && item.Fill.ForeColor.RGB == shape.Fill.ForeColor.RGB)
                        {
                            list.Add(item.Name);
                        }
                    }
                    slide.Shapes.Range(list.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("形状不是纯色填充");
                }
            }
        }

        public void button150_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同渐变颜色的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        PowerPoint.Shape item = slide.Shapes[i];
                        if (item.Name == shape.Name && item.Id != shape.Id)
                        {
                            item.Name = item.Name + "_" + i;
                        }
                    }

                    List<string> list = new List<string>();
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == shape.Type && item.Fill.Type == shape.Fill.Type && item.Fill.GradientStops.Count == shape.Fill.GradientStops.Count)
                        {
                            for (int i = 1; i < item.Fill.GradientStops.Count; i++)
                            {
                                if (item.Fill.GradientStops[i].Color.RGB == shape.Fill.GradientStops[i].Color.RGB)
                                {
                                    list.Add(item.Name);
                                }
                            }
                        }
                    }
                    slide.Shapes.Range(list.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("所选形状不是渐变填充");
                }
            }
        }

        public void button151_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同线条粗细的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        PowerPoint.Shape item = slide.Shapes[i];
                        if (item.Name == shape.Name && item.Id != shape.Id)
                        {
                            item.Name = item.Name + "_" + i;
                        }
                    }
                    List<string> list = new List<string>();
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == shape.Type && item.Line.Visible == Office.MsoTriState.msoTrue && item.Line.Weight == shape.Line.Weight)
                        {
                            list.Add(item.Name);
                        }
                    }
                    slide.Shapes.Range(list.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("形状无线条");
                }
            }
        }

        public void button152_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同线条颜色的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        PowerPoint.Shape item = slide.Shapes[i];
                        if (item.Name == shape.Name && item.Id != shape.Id)
                        {
                            item.Name = item.Name + "_" + i;
                        }
                    }
                    List<string> list = new List<string>();
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == shape.Type && item.Line.Visible == Office.MsoTriState.msoTrue && item.Line.ForeColor.RGB == shape.Line.ForeColor.RGB)
                        {
                            list.Add(item.Name);
                        }
                    }
                    slide.Shapes.Range(list.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("形状无线条");
                }
            }
        }

        public void button153_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同线条透明度的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Line.Visible == Office.MsoTriState.msoTrue)
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        PowerPoint.Shape item = slide.Shapes[i];
                        if (item.Name == shape.Name && item.Id != shape.Id)
                        {
                            item.Name = item.Name + "_" + i;
                        }
                    }
                    List<string> list = new List<string>();
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == shape.Type && item.Line.Visible == Office.MsoTriState.msoTrue && item.Line.Transparency == shape.Line.Transparency)
                        {
                            list.Add(item.Name);
                        }
                    }
                    slide.Shapes.Range(list.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("形状无线条");
                }
            }
        }

        public void button154_Click(object sender, RibbonControlEventArgs e)
        {
            Time_CountDown djs1 = null;
            if (djs1 == null || djs1.IsDisposed)
            {
                djs1 = new Time_CountDown();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                djs1.Show();
                button154.Enabled = false;
            }
        }

        public void button155_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = range.Count; i >= 1; i--)
                {
                    if (range[i].Type == Office.MsoShapeType.msoPicture)
                    {
                        range[i].Delete();
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = item.Shapes.Count; i >= 1; i--)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoPicture)
                        {
                            item.Shapes[i].Delete();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中图片或包含图片的幻灯片");
            }
        }

        public void button156_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中一个矢量正方形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    float nw = range[i].Width / 2;
                    float nh = range[i].Height / 2;
                    float min = Math.Min(nw, nh);
                    range[i].ThreeD.BevelBottomType = Office.MsoBevelType.msoBevelAngle;
                    range[i].ThreeD.BevelBottomDepth = min * 1.6f;
                    range[i].ThreeD.BevelBottomInset = min;
                    range[i].ThreeD.BevelTopType = Office.MsoBevelType.msoBevelAngle;
                    range[i].ThreeD.BevelTopDepth = min * 1.6f;
                    range[i].ThreeD.BevelTopInset = min;
                    if (range[i].ThreeD.RotationX == 0 && range[i].ThreeD.RotationY == 0 && range[i].ThreeD.RotationZ == 0)
                    {
                        range[i].ThreeD.SetPresetCamera(Office.MsoPresetCamera.msoCameraPerspectiveFront);
                        range[i].ThreeD.FieldOfView = 45;
                        range[i].ThreeD.RotationX = 90;
                        range[i].ThreeD.RotationY = 300;
                        range[i].ThreeD.RotationZ = 270;
                    }
                    range[i].ThreeD.Z = min * 1.6f;
                }
            }
        }

        public void button157_Click(object sender, RibbonControlEventArgs e)
        {
            Super_Chart Super_Chart = null;
            if (Super_Chart == null || Super_Chart.IsDisposed)
            {
                Super_Chart = new Super_Chart();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Super_Chart.Show();
                button157.Enabled = false;
            }
        }

        public void button158_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    int count2 = shape.Nodes.Count;
                    for (int k = 1; k < count2; k += 2)
                    {
                        shape.Nodes.SetSegmentType(k, Office.MsoSegmentType.msoSegmentLine);
                        shape.Nodes.SetSegmentType(k + 1, Office.MsoSegmentType.msoSegmentLine);
                        float x = shape.Nodes[k].Points[1, 1];
                        float y = shape.Nodes[k].Points[1, 2];
                        float x2 = shape.Nodes[k + 1].Points[1, 1];
                        float y2 = shape.Nodes[k + 1].Points[1, 2];
                        float a = (x2 - x) / 2;
                        float b = (y2 - y) / 2;
                        float nx = x + a;
                        float ny = y + b;
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, nx, ny);
                        count2 += 1;
                    }
                }
            }
        }

        public void button159_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    int count2 = shape.Nodes.Count;
                    for (int k = 1; k < count2; k += 3)
                    {
                        shape.Nodes.SetSegmentType(k, Office.MsoSegmentType.msoSegmentLine);
                        shape.Nodes.SetSegmentType(k + 1, Office.MsoSegmentType.msoSegmentLine);
                        float x = shape.Nodes[k].Points[1, 1];
                        float y = shape.Nodes[k].Points[1, 2];
                        float x2 = shape.Nodes[k + 1].Points[1, 1];
                        float y2 = shape.Nodes[k + 1].Points[1, 2];
                        float a = (x2 - x) / 3;
                        float b = (y2 - y) / 3;
                        float nx = x + a * 2;
                        float ny = y + b * 2;
                        float nx2 = x + a;
                        float ny2 = y + b;
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, nx, ny);
                        shape.Nodes.Insert(k, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, nx2, ny2);
                        count2 += 2;
                    }
                }
            }
        }

        public void button160_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    int count2 = shape.Nodes.Count;
                    for (int k = 1; k < count2 - 1; k++)
                    {
                        float x = shape.Nodes[k].Points[1, 1];
                        float y = shape.Nodes[k].Points[1, 2];
                        float x2 = shape.Nodes[k + 1].Points[1, 1];
                        float y2 = shape.Nodes[k + 1].Points[1, 2];
                        float x3 = shape.Nodes[k + 2].Points[1, 1];
                        float y3 = shape.Nodes[k + 2].Points[1, 2];
                        if (Math.Abs((x2 - x) / (y2 - y)) == Math.Abs((x3 - x) / (y3 - y)))
                        {
                            shape.Nodes.Delete(k + 1);
                            count2 -= 1;
                        }
                    }
                }
            }
        }

        public void button139_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            PowerPoint.Shape gshape = range[i].GroupItems[j];
                            if (gshape.LockAspectRatio == Office.MsoTriState.msoTrue)
                            {
                                gshape.LockAspectRatio = Office.MsoTriState.msoFalse;
                            }
                        }
                    }
                    else if (range[i].LockAspectRatio == Office.MsoTriState.msoTrue)
                    {
                        range[i].LockAspectRatio = Office.MsoTriState.msoFalse;
                    }
                }
            }
            else
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            for (int j = 1; j <= item.Shapes[i].GroupItems.Count; j++)
                            {
                                PowerPoint.Shape gshape = item.Shapes[i].GroupItems[j];
                                if (gshape.LockAspectRatio == Office.MsoTriState.msoTrue)
                                {
                                    gshape.LockAspectRatio = Office.MsoTriState.msoFalse;
                                }
                            }
                        }
                        else if (item.Shapes[i].LockAspectRatio == Office.MsoTriState.msoTrue)
                        {
                            item.Shapes[i].LockAspectRatio = Office.MsoTriState.msoFalse;
                        }
                    }
                }
            }
        }

        public void button78_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选择一个渐变形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int scount = range.Count;
                for (int m = 1; m <= scount; m++)
                {
                    PowerPoint.Shape shape = range[m];
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int n = 1; n <= range[1].GroupItems.Count; n++)
                        {
                            PowerPoint.Shape nshape = shape.GroupItems[n];
                            if (nshape.Fill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                int gcnt = nshape.Fill.GradientStops.Count;
                                float[,] arr = new float[gcnt, 5];
                                float[,] arr2 = new float[gcnt, 5];
                                List<float> max = new List<float>();

                                for (int k = 1; k <= gcnt; k++)
                                {
                                    arr[k - 1, 0] = k;
                                    arr[k - 1, 1] = nshape.Fill.GradientStops[k].Position;
                                    arr[k - 1, 2] = nshape.Fill.GradientStops[k].Color.RGB;
                                    arr[k - 1, 3] = nshape.Fill.GradientStops[k].Transparency;
                                    arr[k - 1, 4] = nshape.Fill.GradientStops[k].Color.Brightness;
                                    max.Add(nshape.Fill.GradientStops[k].Position);
                                }
                                max.Sort();

                                for (int j = 0; j < max.Count; j++)
                                {
                                    for (int k = 0; k < arr.Length / 5; k++)
                                    {
                                        if (arr[k, 1] == max[j])
                                        {
                                            arr2[j, 0] = arr[k, 0];
                                            arr2[j, 1] = arr[k, 1];
                                            arr2[j, 2] = arr[k, 2];
                                            arr2[j, 3] = arr[k, 3];
                                            arr2[j, 4] = arr[k, 4];
                                            break;
                                        }
                                    }
                                }

                                for (int j = 0; j < arr2.Length / 5; j++)
                                {
                                    nshape.Fill.GradientStops[j + 1].Position = arr2[j, 1];
                                    nshape.Fill.GradientStops[j + 1].Color.RGB = (int)arr2[j, 2];
                                    nshape.Fill.GradientStops[j + 1].Transparency = arr2[j, 3];
                                    nshape.Fill.GradientStops[j + 1].Color.Brightness = arr2[j, 4];
                                }

                                List<float> list = new List<float>();
                                for (int i = 1; i <= gcnt; i++)
                                {
                                    list.Add(nshape.Fill.GradientStops[i].Position);
                                }
                                list.Reverse();
                                for (int j = 1; j <= gcnt; j++)
                                {
                                    nshape.Fill.GradientStops[j].Position = list[j - 1];
                                }
                            }
                        }
                    }
                    else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                    {
                        int gcnt = shape.Fill.GradientStops.Count;
                        float[,] arr = new float[gcnt, 5];
                        float[,] arr2 = new float[gcnt, 5];
                        List<float> max = new List<float>();

                        for (int k = 1; k <= gcnt; k++)
                        {
                            arr[k - 1, 0] = k;
                            arr[k - 1, 1] = shape.Fill.GradientStops[k].Position;
                            arr[k - 1, 2] = shape.Fill.GradientStops[k].Color.RGB;
                            arr[k - 1, 3] = shape.Fill.GradientStops[k].Transparency;
                            arr[k - 1, 4] = shape.Fill.GradientStops[k].Color.Brightness;
                            max.Add(shape.Fill.GradientStops[k].Position);
                        }
                        max.Sort();

                        for (int j = 0; j < max.Count; j++)
                        {
                            for (int k = 0; k < arr.Length / 5; k++)
                            {
                                if (arr[k, 1] == max[j])
                                {
                                    arr2[j, 0] = arr[k, 0];
                                    arr2[j, 1] = arr[k, 1];
                                    arr2[j, 2] = arr[k, 2];
                                    arr2[j, 3] = arr[k, 3];
                                    arr2[j, 4] = arr[k, 4];
                                    break;
                                }
                            }
                        }

                        for (int j = 0; j < arr2.Length / 5; j++)
                        {
                            shape.Fill.GradientStops[j + 1].Position = arr2[j, 1];
                            shape.Fill.GradientStops[j + 1].Color.RGB = (int)arr2[j, 2];
                            shape.Fill.GradientStops[j + 1].Transparency = arr2[j, 3];
                            shape.Fill.GradientStops[j + 1].Color.Brightness = arr2[j, 4];
                        }

                        List<float> list = new List<float>();
                        for (int i = 1; i <= gcnt; i++)
                        {
                            list.Add(shape.Fill.GradientStops[i].Position);
                        }
                        list.Reverse();
                        for (int j = 1; j <= gcnt; j++)
                        {
                            shape.Fill.GradientStops[j].Position = list[j - 1];
                        }
                    }
                }
            }
        }

        public void button98_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选择一个纯色或渐变形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int scount = range.Count;
                for (int m = 1; m <= scount; m++)
                {
                    PowerPoint.Shape shape = range[m];
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int n = 1; n <= range[1].GroupItems.Count; n++)
                        {
                            PowerPoint.Shape nshape = shape.GroupItems[n];
                            if (nshape.Fill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                for (int i = 2; i <= nshape.Fill.GradientStops.Count; i++)
                                {
                                    float tr = nshape.Fill.GradientStops[i].Transparency;
                                    nshape.Fill.GradientStops[i].Color.RGB = nshape.Fill.GradientStops[1].Color.RGB;
                                    nshape.Fill.GradientStops[i].Transparency = tr;
                                }
                            }
                            else if (nshape.Fill.Type == Office.MsoFillType.msoFillSolid)
                            {
                                int color = nshape.Fill.ForeColor.RGB;
                                float tr = nshape.Fill.Transparency;
                                nshape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1.0f);
                                nshape.Fill.GradientStops[1].Color.RGB = color;
                                nshape.Fill.GradientStops[1].Transparency = tr;
                                nshape.Fill.GradientStops[2].Color.RGB = color;
                                nshape.Fill.GradientStops[2].Transparency = tr;
                            }
                        }
                    }
                    else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                    {
                        for (int i = 2; i <= shape.Fill.GradientStops.Count; i++)
                        {
                            float tr = shape.Fill.GradientStops[i].Transparency;
                            shape.Fill.GradientStops[i].Color.RGB = shape.Fill.GradientStops[1].Color.RGB;
                            shape.Fill.GradientStops[i].Transparency = tr;
                        }
                    }
                    else if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                    {
                        int color = shape.Fill.ForeColor.RGB;
                        float tr = shape.Fill.Transparency;
                        shape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1.0f);
                        shape.Fill.GradientStops[1].Color.RGB = color;
                        shape.Fill.GradientStops[1].Transparency = tr;
                        shape.Fill.GradientStops[2].Color.RGB = color;
                        shape.Fill.GradientStops[2].Transparency = tr;
                    }
                }
            }
        }

        public void button137_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            PowerPoint.Shape gshape = range[i].GroupItems[j];
                            if (gshape.LockAspectRatio == Office.MsoTriState.msoFalse)
                            {
                                gshape.LockAspectRatio = Office.MsoTriState.msoTrue;
                            }
                        }
                    }
                    else if (range[i].LockAspectRatio == Office.MsoTriState.msoFalse)
                    {
                        range[i].LockAspectRatio = Office.MsoTriState.msoTrue;
                    }
                }
            }
            else
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            for (int j = 1; j <= item.Shapes[i].GroupItems.Count; j++)
                            {
                                PowerPoint.Shape gshape = item.Shapes[i].GroupItems[j];
                                if (gshape.LockAspectRatio == Office.MsoTriState.msoFalse)
                                {
                                    gshape.LockAspectRatio = Office.MsoTriState.msoTrue;
                                }
                            }
                        }
                        else if (item.Shapes[i].LockAspectRatio == Office.MsoTriState.msoFalse)
                        {
                            item.Shapes[i].LockAspectRatio = Office.MsoTriState.msoTrue;
                        }
                    }
                }
            }
        }

        public void button143_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (range[1].Type != Office.MsoShapeType.msoGroup && range.Count == 1)
                {
                    MessageBox.Show("所选元素类型：" + range[1].Type.ToString() + Environment.NewLine + "元素名称：" + range[1].Name + Environment.NewLine + "元素ID：" + range[1].Id);
                }
                else
                {
                    int gcount = 0;
                    int mgcount = 0;
                    for (int i = 1; i <= range.Count; i++)
                    {
                        if (range[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            mgcount += 1;
                            gcount += range[i].GroupItems.Count;
                        }
                    }
                    MessageBox.Show("元素个数(不含组合内元素)：" + count + Environment.NewLine + "组合个数：" + mgcount + Environment.NewLine + "组合内元素个数：" + gcount);
                }

            }
            else
            {
                int count = 0;
                int gcount = 0;
                int scount = sel.SlideRange.Count;
                int mgcount = 0;
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    count += item.Shapes.Count;
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            mgcount += 1;
                            gcount += item.Shapes[i].GroupItems.Count;
                        }
                    }
                }
                MessageBox.Show("所选页面数量：" + scount + Environment.NewLine + "元素个数(不含组合内元素)：" + count + Environment.NewLine + "组合个数：" + mgcount + Environment.NewLine + "组合内元素个数：" + gcount);
            }
        }

        public void button144_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform)
                {
                    int count = shape.Nodes.Count;
                    for (int i = count - 1; i >= 1; i--)
                    {
                        if (shape.Nodes[i].SegmentType == Office.MsoSegmentType.msoSegmentCurve)
                        {
                            shape.Nodes.SetSegmentType(i, Office.MsoSegmentType.msoSegmentLine);
                            count -= 1;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("只支持矢量形状");
                }
            }
        }

        public void button145_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请选中带渐变光圈的形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        foreach (PowerPoint.Shape item in shape.GroupItems)
                        {
                            if (item.Fill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                int gcnt = item.Fill.GradientStops.Count;
                                float[,] arr = new float[gcnt, 5];
                                float[,] arr2 = new float[gcnt, 5];
                                List<float> max = new List<float>();

                                for (int k = 1; k <= gcnt; k++)
                                {
                                    arr[k - 1, 0] = k;
                                    arr[k - 1, 1] = item.Fill.GradientStops[k].Position;
                                    arr[k - 1, 2] = item.Fill.GradientStops[k].Color.RGB;
                                    arr[k - 1, 3] = item.Fill.GradientStops[k].Transparency;
                                    arr[k - 1, 4] = item.Fill.GradientStops[k].Color.Brightness;
                                    max.Add(item.Fill.GradientStops[k].Position);
                                }
                                max.Sort();

                                for (int j = 0; j < max.Count; j++)
                                {
                                    for (int k = 0; k < arr.Length / 5; k++)
                                    {
                                        if (arr[k, 1] == max[j])
                                        {
                                            arr2[j, 0] = arr[k, 0];
                                            arr2[j, 1] = arr[k, 1];
                                            arr2[j, 2] = arr[k, 2];
                                            arr2[j, 3] = arr[k, 3];
                                            arr2[j, 4] = arr[k, 4];
                                            break;
                                        }
                                    }
                                }

                                for (int j = 0; j < arr2.Length / 5; j++)
                                {
                                    item.Fill.GradientStops[j + 1].Position = arr2[j, 1];
                                    item.Fill.GradientStops[j + 1].Color.RGB = (int)arr2[j, 2];
                                    item.Fill.GradientStops[j + 1].Transparency = arr2[j, 3];
                                    item.Fill.GradientStops[j + 1].Color.Brightness = arr2[j, 4];
                                }

                                item.Fill.ForeColor.RGB = item.Fill.GradientStops[1].Color.RGB;
                                item.Fill.Solid();
                            }
                        }
                    }
                    else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                    {
                        int gcnt = shape.Fill.GradientStops.Count;
                        float[,] arr = new float[gcnt, 5];
                        float[,] arr2 = new float[gcnt, 5];
                        List<float> max = new List<float>();

                        for (int k = 1; k <= gcnt; k++)
                        {
                            arr[k - 1, 0] = k;
                            arr[k - 1, 1] = shape.Fill.GradientStops[k].Position;
                            arr[k - 1, 2] = shape.Fill.GradientStops[k].Color.RGB;
                            arr[k - 1, 3] = shape.Fill.GradientStops[k].Transparency;
                            arr[k - 1, 4] = shape.Fill.GradientStops[k].Color.Brightness;
                            max.Add(shape.Fill.GradientStops[k].Position);
                        }
                        max.Sort();

                        for (int j = 0; j < max.Count; j++)
                        {
                            for (int k = 0; k < arr.Length / 5; k++)
                            {
                                if (arr[k, 1] == max[j])
                                {
                                    arr2[j, 0] = arr[k, 0];
                                    arr2[j, 1] = arr[k, 1];
                                    arr2[j, 2] = arr[k, 2];
                                    arr2[j, 3] = arr[k, 3];
                                    arr2[j, 4] = arr[k, 4];
                                    break;
                                }
                            }
                        }

                        for (int j = 0; j < arr2.Length / 5; j++)
                        {
                            shape.Fill.GradientStops[j + 1].Position = arr2[j, 1];
                            shape.Fill.GradientStops[j + 1].Color.RGB = (int)arr2[j, 2];
                            shape.Fill.GradientStops[j + 1].Transparency = arr2[j, 3];
                            shape.Fill.GradientStops[j + 1].Color.Brightness = arr2[j, 4];
                        }

                        shape.Fill.ForeColor.RGB = shape.Fill.GradientStops[1].Color.RGB;
                        shape.Fill.Solid();
                    }
                }
            }
        }

        public void button161_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请选中至少两个图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                if (range.Count == 1)
                {
                    range[1].Top = 0;
                    range[1].Left = 0;
                }
                else
                {
                    range.Align(Office.MsoAlignCmd.msoAlignLefts, Office.MsoTriState.msoFalse);
                    range.Align(Office.MsoAlignCmd.msoAlignTops, Office.MsoTriState.msoFalse);
                }
            }
        }

        public void button162_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请选中至少两个图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                if (range.Count == 1)
                {
                    float w = app.ActivePresentation.PageSetup.SlideWidth;
                    float h = app.ActivePresentation.PageSetup.SlideHeight;
                    range[1].Top = h / 2 - range[1].Height / 2;
                    range[1].Left = w / 2 - range[1].Width / 2;
                }
                else
                {
                    range.Align(Office.MsoAlignCmd.msoAlignCenters, Office.MsoTriState.msoFalse);
                    range.Align(Office.MsoAlignCmd.msoAlignMiddles, Office.MsoTriState.msoFalse);
                }
            }
        }

        public void splitButton2_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中要导出的幻灯片");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的幻灯片\";
                float w = app.ActivePresentation.PageSetup.SlideWidth;
                float h = app.ActivePresentation.PageSetup.SlideHeight;
                float dpi = Properties.Settings.Default.dpi;
                int pw = Properties.Settings.Default.pwidth;
                int h2 = (int)(pw * h / w);

                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }

                for (int i = 1; i <= sel.SlideRange.Count; i++)
                {
                    PowerPoint.Slide nslide = sel.SlideRange[i];
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                    int k = dir.GetFiles().Length + (i - i + 1);
                    string shname = name + "_" + k;
                    nslide.Export(cPath + shname + "_1.jpg", "jpg", pw, h2);
                    Bitmap bmp0 = new Bitmap(cPath + shname + "_1.jpg");
                    bmp0.SetResolution(dpi, dpi);
                    bmp0.Save(cPath + shname + ".jpg");
                    bmp0.Dispose();
                    File.Delete(cPath + shname + "_1.jpg");
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
        }

        public void button163_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                PowerPoint.Slide slide = app.ActivePresentation.Slides[1];
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的幻灯片\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }
                slide.Export(cPath + name + "_微信.jpg", "jpg", 900, 500);
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的幻灯片\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }
                for (int i = 1; i <= sel.SlideRange.Count; i++)
                {
                    PowerPoint.Slide nslide = sel.SlideRange[i];
                    nslide.Export(cPath + name + "_微信_" + i + ".jpg", "jpg", 900, 500);
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }

        }

        private void button164_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= sel.SlideRange.Count; i++)
                    {
                        int count = item.Comments.Count;
                        for (int j = count; j >= 1; j--)
                        {
                            item.Comments[j].Delete();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中要删除批注的幻灯片页面");
            }
        }

        public void button165_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= sel.SlideRange.Count; i++)
                    {
                        int count = item.NotesPage.Count;
                        for (int j = 1; j <= count; j++)
                        {
                            if (item.NotesPage.Shapes.Placeholders[2].TextFrame.TextRange.Text != "")
                            {
                                item.NotesPage.Shapes.Placeholders[2].TextFrame.TextRange.Text = "";
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选中要删除备注的幻灯片页面");
            }
        }

        public void button166_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                string txt = "";
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    if (item.NotesPage.Shapes.Placeholders[2].TextFrame.TextRange.Text != "")
                    {
                        txt = txt + Environment.NewLine + item.NotesPage.Shapes.Placeholders[2].TextFrame.TextRange.Text.Trim();
                    }
                }
                if (txt == "")
                {
                    MessageBox.Show("所选页面中无备注文字");
                }
                else
                {
                    PowerPoint.Shape text = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, -300, 0, 300, 300);
                    text.TextFrame.AutoSize = PowerPoint.PpAutoSize.ppAutoSizeShapeToFitText;
                    text.Name = "notecount";
                    text.TextFrame.TextRange.Text = txt;
                }
            }
            else
            {
                MessageBox.Show("请选中需要合并备注的幻灯片页面");
            }
        }

        public void button167_Click(object sender, RibbonControlEventArgs e)
        {
            Notes_Import Notes_Import = null;
            if (Notes_Import == null || Notes_Import.IsDisposed)
            {
                Notes_Import = new Notes_Import();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Notes_Import.Show();
                button167.Enabled = false;
            }
        }

        public void button168_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                float w = app.ActivePresentation.PageSetup.SlideWidth;
                float h = app.ActivePresentation.PageSetup.SlideHeight;
                for (int i = 1; i <= count; i++)
                {
                    range[i].Top = range[i].Top + range[i].Height / 2 - h / 2;
                    range[i].Left = range[i].Left + range[i].Width / 2 - w / 2;
                    range[i].Height = h;
                    range[i].Width = w;
                }
            }
        }

        public void button169_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选择一个元素");
            }
            else
            {
                if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
                {
                    PowerPoint.ShapeRange range = sel.ShapeRange;
                    int count = range.Count;
                    string[] name = new string[count];
                    for (int i = 1; i <= count; i++)
                    {
                        PowerPoint.Shape shape = range[i];
                        PowerPoint.Shape cshape = shape.Duplicate()[1];
                        cshape.Left = shape.Left;
                        cshape.Top = shape.Top;
                        name[i - 1] = cshape.Name;
                    }
                    slide.Shapes.Range(name).Select();
                }
                if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
                {
                    PowerPoint.SlideRange slides = sel.SlideRange;
                    int count = slides.Count;
                    for (int i = 1; i <= count; i++)
                    {
                        PowerPoint.Slide slide0 = slides[i];
                        PowerPoint.Slide nslide = slide0.Duplicate()[1];
                    }
                }
            }
        }

        public void button170_Click(object sender, RibbonControlEventArgs e)
        {
            Picture_Jigsaw Picture_Jigsaw = null;
            if (Picture_Jigsaw == null || Picture_Jigsaw.IsDisposed)
            {
                Picture_Jigsaw = new Picture_Jigsaw();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Picture_Jigsaw.Show();
            }
            button170.Enabled = false;
        }

        public void button171_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中要导出的幻灯片");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的幻灯片\";
                float w = app.ActivePresentation.PageSetup.SlideWidth;
                float h = app.ActivePresentation.PageSetup.SlideHeight;
                int pw = Properties.Settings.Default.pwidth;
                float dpi = Properties.Settings.Default.dpi;
                int h2 = (int)(pw * h / w);
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }
                Bitmap bmp0 = new Bitmap(pw, h2 * sel.SlideRange.Count);
                bmp0.SetResolution(dpi, dpi);
                Graphics g = Graphics.FromImage(bmp0);
                for (int i = 1; i <= sel.SlideRange.Count; i++)
                {
                    PowerPoint.Slide nslide = sel.SlideRange[i];
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                    int k = dir.GetFiles().Length + (i - i + 1);
                    string shname = name + "_" + k;
                    nslide.Export(cPath + shname + ".jpg", "jpg", pw, h2);
                    Bitmap bmp1 = new Bitmap(cPath + shname + ".jpg");
                    g.DrawImage(bmp1, 0, (i - 1) * h2, pw, h2);
                    bmp1.Dispose();
                    File.Delete(cPath + shname + ".jpg");
                }
                System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(cPath);
                int k2 = dir2.GetFiles().Length + 1;
                bmp0.Save(cPath + name + "_" + k2 + ".jpg", ImageFormat.Jpeg);
                bmp0.Dispose();
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
        }

        public void button172_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type != Office.MsoShapeType.msoFreeform)
                    {
                        shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                        shape.Nodes.Delete(2);
                    }
                    int count2 = shape.Nodes.Count;
                    float x = shape.Left + shape.Width / 2;
                    float y = shape.Top + shape.Height / 2;
                    for (int k = 1; k <= count2; k++)
                    {
                        shape.Nodes.SetPosition(k, x, y);
                    }
                }
            }
        }

        public void button176_Click(object sender, RibbonControlEventArgs e)
        {
            ShapeToLine ShapeToLine = null;
            if (ShapeToLine == null || ShapeToLine.IsDisposed)
            {
                ShapeToLine = new ShapeToLine();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                ShapeToLine.Show();
                button176.Enabled = false;
            }
        }

        public void button177_Click(object sender, RibbonControlEventArgs e)
        {
            Points_Adjust Points_Adjust = null;
            if (Points_Adjust == null || Points_Adjust.IsDisposed)
            {
                Points_Adjust = new Points_Adjust();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Points_Adjust.Show();
                button177.Enabled = false;
            }
        }

        public void button179_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中图形");
            }
            else
            {
                string apath = app.ActivePresentation.Path;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                PowerPoint.Shape txt = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, range[1].Width, range[1].Height);
                txt.TextEffect.PresetShape = Office.MsoPresetTextEffectShape.msoTextEffectShapePlainText;
                txt.TextFrame2.TextRange.Text = new string(char.Parse("_"), count);
                for (int j = 1; j <= count; j++)
                {
                    PowerPoint.Shape shape = range[j];
                    shape.Export(apath + @"xshape_" + j + ".png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                    txt.TextFrame2.TextRange.Characters[j, 1].Font.Fill.UserPicture(apath + @"xshape_" + j + ".png");
                    File.Delete(apath + @"xshape_" + j + ".png");
                }
                txt.TextFrame2.TextRange.Characters.Font.BaselineOffset = 0;
                txt.TextFrame2.TextRange.Characters.Font.Spacing = -12;
                txt.TextFrame2.TextRange.Characters.Font.Kerning = 12;

                PowerPoint.TimeLine timeline = slide.TimeLine;
                PowerPoint.Sequence seq = timeline.MainSequence;
                PowerPoint.Effect xz = seq.AddEffect(txt, PowerPoint.MsoAnimEffect.msoAnimEffectFlashOnce, PowerPoint.MsoAnimateByLevel.msoAnimateTextByFirstLevel, PowerPoint.MsoAnimTriggerType.msoAnimTriggerOnPageClick, -1);
                seq.ConvertToTextUnitEffect(xz, PowerPoint.MsoAnimTextUnitEffect.msoAnimTextUnitEffectByCharacter);
                xz.Timing.Duration = 0.1f;
                MessageBox.Show("请手动修改动画的字母延迟为“100”，重复为“直到下一次单击”。这个功能PA插件可以完美实现。");
            }
        }

        public void button180_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.papocket.com");
        }

        public void button181_Click(object sender, RibbonControlEventArgs e)
        {
            Whiteboard Whiteboard = null;
            if (Whiteboard == null || Whiteboard.IsDisposed)
            {
                Whiteboard = new Whiteboard();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Whiteboard.Show();
            }
        }

        public void button182_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count == 1)
            {
                MessageBox.Show("同时选中要裁剪的图片和一个形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;

                List<PowerPoint.Shape> arr = new List<PowerPoint.Shape>();
                for (int i = 2; i <= count; i++)
                {
                    arr.Add(range[i]);
                }

                List<PowerPoint.Shape> arr0 = new List<PowerPoint.Shape>();
                arr0.Add(range[1]);
                for (int i = 1; i < range.Count; i++)
                {
                    PowerPoint.Shape nshape = range[1].Duplicate()[1 + (i - i)];
                    nshape.Left = range[1].Left;
                    nshape.Top = range[1].Top;
                    arr0.Add(nshape);
                }

                for (int i = 1; i < count ; i++)
                {
                    List<string> name = new List<string>();
                    name.Add(arr0[i - 1].Name);
                    name.Add(arr[i - 1].Name);
                    slide.Shapes.Range(name.ToArray()).Select();
                    string strCmd = "ShapesIntersect";
                    Globals.ThisAddIn.Application.CommandBars.ExecuteMso(strCmd);
                }

            }
        }

        public void button183_Click(object sender, RibbonControlEventArgs e)
        {
            Aniframe_Assist Aniframe_Assist = null;
            if (Aniframe_Assist == null || Aniframe_Assist.IsDisposed)
            {
                Aniframe_Assist = new Aniframe_Assist();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Aniframe_Assist.Show();
            }
        }

        public void button184_Click(object sender, RibbonControlEventArgs e)
        {
            Text_Split Text_Split = null;
            if (Text_Split == null || Text_Split.IsDisposed)
            {
                Text_Split = new Text_Split();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Text_Split.Show();
                button184.Enabled = false;
            }
        }

        public void button185_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("可选中形状和图片元素导出为JPG；选中多页幻灯片，只导出其中的图片元素");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的元素\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                    int k = dir.GetFiles().Length + (i - i + 1);
                    string shname = name + "_" + k;
                    shape.Export(cPath + shname + ".jpg", PowerPoint.PpShapeFormat.ppShapeFormatJPG);
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的元素\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }

                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        PowerPoint.Shape shape = item.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoPicture)
                        {
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                            int k = dir.GetFiles().Length + (i - i + 1);
                            string shname = name + "_" + k;
                            shape.Export(cPath + shname + ".jpg", PowerPoint.PpShapeFormat.ppShapeFormatJPG);
                        }
                    }
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
        }

        public void button188_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中要激活三维的图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.ThreeD.Visible == Office.MsoTriState.msoFalse)
                    {
                        shape.ThreeD.RotationX = 0;
                    }
                }
            }
        }

        public void button189_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选择一个渐变形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int scount = range.Count;
                for (int m = 1; m <= scount; m++)
                {
                    PowerPoint.Shape shape = range[m];
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int n = 1; n <= range[1].GroupItems.Count; n++)
                        {
                            PowerPoint.Shape nshape = shape.GroupItems[n];
                            if (nshape.Fill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                int gcnt = nshape.Fill.GradientStops.Count;
                                float[,] arr = new float[gcnt, 5];
                                float[,] arr2 = new float[gcnt, 5];
                                List<float> max = new List<float>();

                                for (int k = 1; k <= gcnt; k++)
                                {
                                    arr[k - 1, 0] = k;
                                    arr[k - 1, 1] = nshape.Fill.GradientStops[k].Position;
                                    arr[k - 1, 2] = nshape.Fill.GradientStops[k].Color.RGB;
                                    arr[k - 1, 3] = nshape.Fill.GradientStops[k].Transparency;
                                    arr[k - 1, 4] = nshape.Fill.GradientStops[k].Color.Brightness;
                                    max.Add(nshape.Fill.GradientStops[k].Position);
                                }
                                max.Sort();

                                for (int j = 0; j < max.Count; j++)
                                {
                                    for (int k = 0; k < arr.Length / 5; k++)
                                    {
                                        if (arr[k, 1] == max[j])
                                        {
                                            arr2[j, 0] = arr[k, 0];
                                            arr2[j, 1] = arr[k, 1];
                                            arr2[j, 2] = arr[k, 2];
                                            arr2[j, 3] = arr[k, 3];
                                            arr2[j, 4] = arr[k, 4];
                                            break;
                                        }
                                    }
                                }

                                for (int j = 0; j < arr2.Length / 5; j++)
                                {
                                    nshape.Fill.GradientStops[j + 1].Position = arr2[j, 1];
                                    nshape.Fill.GradientStops[j + 1].Color.RGB = (int)arr2[j, 2];
                                    nshape.Fill.GradientStops[j + 1].Transparency = arr2[j, 3];
                                    nshape.Fill.GradientStops[j + 1].Color.Brightness = arr2[j, 4];
                                }

                                float a = nshape.Fill.GradientStops[1].Position;
                                float c = nshape.Fill.GradientStops[gcnt].Position;
                                float gn = (c - a) / ((float)gcnt - 1);
                                if (gcnt > 2)
                                {
                                    for (int i = 2; i < gcnt; i++)
                                    {
                                        nshape.Fill.GradientStops[i].Position = a + gn * (i - 1);
                                    }
                                }
                                else
                                {
                                    nshape.Fill.GradientStops[1].Position = 0f;
                                    nshape.Fill.GradientStops[gcnt].Position = 1f;
                                }
                            }
                        }
                    }
                    else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                    {
                        int gcnt = shape.Fill.GradientStops.Count;
                        float[,] arr = new float[gcnt, 5];
                        float[,] arr2 = new float[gcnt, 5];
                        List<float> max = new List<float>();

                        for (int k = 1; k <= gcnt; k++)
                        {
                            arr[k - 1, 0] = k;
                            arr[k - 1, 1] = shape.Fill.GradientStops[k].Position;
                            arr[k - 1, 2] = shape.Fill.GradientStops[k].Color.RGB;
                            arr[k - 1, 3] = shape.Fill.GradientStops[k].Transparency;
                            arr[k - 1, 4] = shape.Fill.GradientStops[k].Color.Brightness;
                            max.Add(shape.Fill.GradientStops[k].Position);
                        }
                        max.Sort();

                        for (int j = 0; j < max.Count; j++)
                        {
                            for (int k = 0; k < arr.Length / 5; k++)
                            {
                                if (arr[k, 1] == max[j])
                                {
                                    arr2[j, 0] = arr[k, 0];
                                    arr2[j, 1] = arr[k, 1];
                                    arr2[j, 2] = arr[k, 2];
                                    arr2[j, 3] = arr[k, 3];
                                    arr2[j, 4] = arr[k, 4];
                                    break;
                                }
                            }
                        }

                        for (int j = 0; j < arr2.Length / 5; j++)
                        {
                            shape.Fill.GradientStops[j + 1].Position = arr2[j, 1];
                            shape.Fill.GradientStops[j + 1].Color.RGB = (int)arr2[j, 2];
                            shape.Fill.GradientStops[j + 1].Transparency = arr2[j, 3];
                            shape.Fill.GradientStops[j + 1].Color.Brightness = arr2[j, 4];
                        }

                        float a = shape.Fill.GradientStops[1].Position;
                        float c = shape.Fill.GradientStops[gcnt].Position;
                        float gn = (c - a) / ((float)gcnt - 1);
                        if (gcnt > 2)
                        {
                            for (int i = 2; i < gcnt; i++)
                            {
                                shape.Fill.GradientStops[i].Position = a + gn * (i - 1);
                            }
                        }
                        else
                        {
                            shape.Fill.GradientStops[1].Position = 0f;
                            shape.Fill.GradientStops[gcnt].Position = 1f;
                        }

                    }
                }
            }
        }

        private void splitButton1_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中一个组合或两个以上形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Microsoft.Office.Core.MsoShapeType.msoGroup)
                {
                    for (int j = 1; j <= range[1].GroupItems.Count; j++)
                    {
                        range[1].GroupItems[j].Rotation = range[1].GroupItems[1].Rotation;
                    }
                }
                else if (count > 1)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        range[i].Rotation = range[1].Rotation;
                    }
                }
                else
                {
                    MessageBox.Show("请选中一个组合或两个以上形状");
                }
            }
        }

        public void button187_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选中图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape pic = range[i];
                    if (pic.Type == Office.MsoShapeType.msoPicture)
                    {
                        if (pic.Fill.PictureEffects.Count != 0)
                        {
                            int en1 = -1;
                            int en2 = -1;
                            for (int j = 1; j <= pic.Fill.PictureEffects.Count; j++)
                            {
                                if (pic.Fill.PictureEffects[j].Type == Office.MsoPictureEffectType.msoEffectBrightnessContrast)
                                {
                                    Office.PictureEffect pics = pic.Fill.PictureEffects[j];
                                    pics.EffectParameters[1].Value = 0f;
                                    pics.EffectParameters[2].Value = 1.0f;
                                    en1 = 1;
                                }
                                else if (pic.Fill.PictureEffects[j].Type == Office.MsoPictureEffectType.msoEffectSaturation)
                                {
                                    Office.PictureEffect pics = pic.Fill.PictureEffects[j];
                                    pics.EffectParameters[1].Value = 0f;
                                    en2 = 1;
                                }
                            }
                            if (en2 == -1)
                            {
                                Office.PictureEffect pics2 = pic.Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectSaturation, 0);
                                pics2.EffectParameters[1].Value = 0f;
                            }
                            if(en1 == -1)
	                        {
                                Office.PictureEffect pics1 = pic.Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectBrightnessContrast, 0);
                                pics1.EffectParameters[1].Value = 0f;
                                pics1.EffectParameters[2].Value = 1.0f;
	                        }    
                        }
                        else
                        {
                            Office.PictureEffect pics2 = pic.Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectSaturation, 0);
                            pics2.EffectParameters[1].Value = 0f;
                            Office.PictureEffect pics1 = pic.Fill.PictureEffects.Insert(Office.MsoPictureEffectType.msoEffectBrightnessContrast, 0);
                            pics1.EffectParameters[1].Value = 0f;
                            pics1.EffectParameters[2].Value = 1.0f;
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个形状不是图片");
                }
            }
        }

        public void button186_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请选中两个圆。先选中大圆，同时选中要复制的小圆");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (range.Count >= 2)
                {
                    string[] sname = new string[range.Count - 1];
                    int ns = 0;
                    for (int i = 1; i < range.Count; i++)
                    {
                        PowerPoint.Shape oval1 = range[i];
                        PowerPoint.Shape oval2 = range[range.Count];
                        float R = oval1.Width / 2;
                        float r = oval2.Width / 2;
                        if (R > r)
                        {
                            double a = Math.Asin(r / R) * 360 / Math.PI;
                            double n = 360 / a;
                            double a2 = (double)(360) / (int)n;
                            float lm = oval1.Left + R;
                            float tm = oval1.Top + R;

                            for (int j = 0; j < (int)n; j++)
                            {
                                PowerPoint.Shape Noval = oval2.Duplicate()[1];

                                double na = j * a2;
                                double b;
                                double nt;
                                double nl;

                                if (na >= 0 && na < 90)
                                {
                                    na = j * a2;
                                    b = Math.Tan(na * Math.PI / 180);
                                    nt = R / Math.Sqrt(b * b + 1);
                                    nl = nt * b;
                                    Noval.Left = (float)(lm + nl - r);
                                    Noval.Top = (float)(tm - nt - r);
                                }
                                else if (na == 90)
                                {
                                    Noval.Left = lm + R - r;
                                    Noval.Top = tm - r; ;
                                }
                                else if (na < 180)
                                {
                                    na = 180 - j * a2;
                                    b = Math.Tan(na * Math.PI / 180);
                                    nt = R / Math.Sqrt(b * b + 1);
                                    nl = nt * b;
                                    Noval.Left = (float)(lm + nl - r);
                                    Noval.Top = (float)(tm + nt - r);
                                }
                                else if (na == 180)
                                {
                                    Noval.Left = lm - r;
                                    Noval.Top = tm + R - r;
                                }
                                else if (na < 270)
                                {
                                    na = j * a2 - 180;
                                    b = Math.Tan(na * Math.PI / 180);
                                    nt = R / Math.Sqrt(b * b + 1);
                                    nl = nt * b;
                                    Noval.Left = (float)(lm - nl - r);
                                    Noval.Top = (float)(tm + nt - r);
                                }
                                else if (na == 270)
                                {
                                    Noval.Left = lm - R - r;
                                    Noval.Top = tm - r;
                                }
                                else if (na < 360)
                                {
                                    na = 360 - j * a2;
                                    b = Math.Tan(na * Math.PI / 180);
                                    nt = R / Math.Sqrt(b * b + 1);
                                    nl = nt * b;
                                    Noval.Left = (float)(lm - nl - r);
                                    Noval.Top = (float)(tm - nt - r);
                                }
                                else if (na == 360)
                                {
                                    Noval.Left = lm - r;
                                    Noval.Top = tm - R - r;
                                }
                            }
                            sname[i - 1] = oval1.Name;
                        }
                        else
                        {
                            ns += 1;
                        }
                    }
                    if (ns != 0)
                    {
                        MessageBox.Show("有 " + ns + " 个圆的尺寸有误。请先选中大圆，同时选中要复制的小圆");
                    }
                    else
                    {
                        PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                        slide.Shapes.Range(sname).Select();
                    }
                }
                else
                {
                    MessageBox.Show("请先选中大圆，同时选中要复制的小圆");
                }
            }
        }

        private void splitButton6_Click(object sender, RibbonControlEventArgs e)
        {
            Copy_Rectangle Copy_Rectangle = null;
            if (Copy_Rectangle == null || Copy_Rectangle.IsDisposed)
            {
                Copy_Rectangle = new Copy_Rectangle();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Copy_Rectangle.Show();
                button29.Enabled = false;
            }
        }

        public void button190_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("先选中矢量的形状或线条，再选中准备复制的图形");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count >= 2 && (range[1].Type == Office.MsoShapeType.msoAutoShape || range[1].Type == Office.MsoShapeType.msoFreeform))
                {
                    string[] sname = new string[count - 1];
                    for (int i = 1; i < count; i++)
                    {
                        PowerPoint.Shape shape = range[i];
                        if (shape.Type == Office.MsoShapeType.msoAutoShape)
                        {
                            shape.Nodes.Insert(1, Office.MsoSegmentType.msoSegmentLine, Office.MsoEditingType.msoEditingCorner, 0f, 0f, 0f, 0f, 0f, 0f);
                            shape.Nodes.Delete(2);
                        }
                        PowerPoint.ShapeNodes nodes = shape.Nodes;
                        List<float> xlist = new List<float>();
                        List<float> ylist = new List<float>();

                        int ncount = nodes.Count;

                        for (int j = 1; j <= ncount; j++)
                        {
                            float x = shape.Nodes[j].Points[1, 1];
                            float y = shape.Nodes[j].Points[1, 2];
                            PowerPoint.Shape shape2 = range[count].Duplicate()[1];
                            shape2.Left = x - shape2.Width / 2;
                            shape2.Top = y - shape2.Height / 2;
                        }
                        sname[i - 1] = shape.Name;
                    }
                    PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                    slide.Shapes.Range(sname).Select();
                }
                else
                {
                    MessageBox.Show("先选中矢量的形状或线条，再选中准备复制的图形");
                }
            }
        }

        public void button191_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int count = tr.Text.Count();
                int rgb1 = tr.Characters(1).Font.Color.RGB;
                int rgb2 = tr.Characters(count).Font.Color.RGB;

                if (rgb1 != rgb2)
                {
                    int r1 = rgb1 % 256;
                    int g1 = (rgb1 / 256) % 256;
                    int b1 = (rgb1 / 256 / 256) % 256;
                    int r2 = rgb2 % 256;
                    int g2 = (rgb2 / 256) % 256;
                    int b2 = (rgb2 / 256 / 256) % 256;

                    int hsl1 = Rgb2Hsl(r1, g1, b1);
                    int hsl2 = Rgb2Hsl(r2, g2, b2);

                    int h1 = hsl1 % 256;
                    int s1 = (hsl1 / 256) % 256;
                    int l1 = (hsl1 / 256 / 256) % 256;
                    int h2 = hsl2 % 256;
                    int s2 = (hsl2 / 256) % 256;
                    int l2 = (hsl2 / 256 / 256) % 256;

                    Random rand = new Random();

                    int min1 = Math.Min(h1, h2);
                    int min2 = Math.Min(s1, s2);
                    int min3 = Math.Min(l1, l2);
                    int max1 = Math.Max(h1, h2);
                    int max2 = Math.Max(s1, s2);
                    int max3 = Math.Max(l1, l2);

                    for (int i = 2; i < count; i++)
                    {
                        int nh = rand.Next(min1, max1);
                        int ns = rand.Next(min2, max2);
                        int nl = rand.Next(min3, max3);
                        int nrgb = Hsl2Rgb(nh, ns, nl);
                        tr.Characters(i).Font.Color.RGB = nrgb;
                    }
                }
                else
                {
                    MessageBox.Show("所选的第一个和最后一个颜色的RGB值相同，不能进行随机补色");
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && (sel.ShapeRange.Count == 1 || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3)))
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    if (range[1].GroupItems.Count >= 3)
                    {
                        count = range[1].GroupItems.Count;
                        PowerPoint.Shape shape1 = range[1].GroupItems[1];
                        PowerPoint.Shape shape2 = range[1].GroupItems[count];
                        int rgb1 = 0;
                        int rgb2 = 0;
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            rgb1 = shape1.Fill.ForeColor.RGB;
                            rgb2 = shape2.Fill.ForeColor.RGB;
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            rgb1 = shape1.Line.ForeColor.RGB;
                            rgb2 = shape2.Line.ForeColor.RGB;
                        }

                        if (rgb2 == rgb1)
                        {
                            MessageBox.Show("所选的第一个和最后一个颜色的RGB值相同，不能进行随机补色");
                        }
                        else
                        {
                            int r1 = rgb1 % 256;
                            int g1 = (rgb1 / 256) % 256;
                            int b1 = (rgb1 / 256 / 256) % 256;
                            int r2 = rgb2 % 256;
                            int g2 = (rgb2 / 256) % 256;
                            int b2 = (rgb2 / 256 / 256) % 256;

                            int hsl1 = Rgb2Hsl(r1, g1, b1);
                            int hsl2 = Rgb2Hsl(r2, g2, b2);

                            int h1 = hsl1 % 256;
                            int s1 = (hsl1 / 256) % 256;
                            int l1 = (hsl1 / 256 / 256) % 256;
                            int h2 = hsl2 % 256;
                            int s2 = (hsl2 / 256) % 256;
                            int l2 = (hsl2 / 256 / 256) % 256;

                            Random rand = new Random();

                            int min1 = Math.Min(h1, h2);
                            int min2 = Math.Min(s1, s2);
                            int min3 = Math.Min(l1, l2);
                            int max1 = Math.Max(h1, h2);
                            int max2 = Math.Max(s1, s2);
                            int max3 = Math.Max(l1, l2);

                            if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nh = rand.Next(min1, max1);
                                    int ns = rand.Next(min2, max2);
                                    int nl = rand.Next(min3, max3);
                                    int nrgb = Hsl2Rgb(nh, ns, nl);
                                    range[1].GroupItems[i].Fill.ForeColor.RGB = nrgb;
                                }
                            }
                            else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                            {
                                for (int i = 2; i < count; i++)
                                {
                                    int nh = rand.Next(min1, max1);
                                    int ns = rand.Next(min2, max2);
                                    int nl = rand.Next(min3, max3);
                                    int nrgb = Hsl2Rgb(nh, ns, nl);
                                    range[1].GroupItems[i].Line.ForeColor.RGB = nrgb;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("组合内需有三个以上形状");
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    int rgb1 = 0;
                    int rgb2 = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        rgb1 = shape1.Fill.ForeColor.RGB;
                        rgb2 = shape2.Fill.ForeColor.RGB;
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        rgb1 = shape1.Line.ForeColor.RGB;
                        rgb2 = shape2.Line.ForeColor.RGB;
                    }

                    if (rgb2 == rgb1)
                    {
                        MessageBox.Show("所选的第一个和最后一个颜色的RGB值相同，不能进行随机补色");
                    }
                    else
                    {
                        int r1 = rgb1 % 256;
                        int g1 = (rgb1 / 256) % 256;
                        int b1 = (rgb1 / 256 / 256) % 256;
                        int r2 = rgb2 % 256;
                        int g2 = (rgb2 / 256) % 256;
                        int b2 = (rgb2 / 256 / 256) % 256;

                        int hsl1 = Rgb2Hsl(r1, g1, b1);
                        int hsl2 = Rgb2Hsl(r2, g2, b2);

                        int h1 = hsl1 % 256;
                        int s1 = (hsl1 / 256) % 256;
                        int l1 = (hsl1 / 256 / 256) % 256;
                        int h2 = hsl2 % 256;
                        int s2 = (hsl2 / 256) % 256;
                        int l2 = (hsl2 / 256 / 256) % 256;

                        Random rand = new Random();

                        int min1 = Math.Min(h1, h2);
                        int min2 = Math.Min(s1, s2);
                        int min3 = Math.Min(l1, l2);
                        int max1 = Math.Max(h1, h2);
                        int max2 = Math.Max(s1, s2);
                        int max3 = Math.Max(l1, l2);

                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform || shape1.Type == Office.MsoShapeType.msoPicture) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform || shape2.Type == Office.MsoShapeType.msoPicture) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 2; i < count; i++)
                            {
                                int nh = rand.Next(min1, max1);
                                int ns = rand.Next(min2, max2);
                                int nl = rand.Next(min3, max3);
                                int nrgb = Hsl2Rgb(nh, ns, nl);
                                range[i].Fill.ForeColor.RGB = nrgb;
                            }
                        }
                        else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                        {
                            for (int i = 2; i < count; i++)
                            {
                                int nh = rand.Next(min1, max1);
                                int ns = rand.Next(min2, max2);
                                int nl = rand.Next(min3, max3);
                                int nrgb = Hsl2Rgb(nh, ns, nl);
                                range[i].Line.ForeColor.RGB = nrgb;
                            }
                        }
                    }
                }
            } 
        }

        public void button192_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选择至少1个形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        Random rand = new Random();
                        for (int i = 1; i <= range[1].GroupItems.Count; i++)
                        {
                            int ran1 = rand.Next(0, 360);
                            range[1].GroupItems[i].Rotation = (i - i + 1) * ran1;
                        }
                    }
                    else
                    {
                        Random rand = new Random();
                        int ran1 = rand.Next(0, 360);
                        range[1].Rotation = ran1;
                    }
                }
                else if (count >= 2)
                {
                    Random rand = new Random();
                    for (int i = 1; i <= range.Count; i++)
                    {
                        int ran1 = rand.Next(0, 360);
                        range[i].Rotation = (i - i + 1) * ran1;
                    }
                }
            }
        }

        public void button193_Click(object sender, RibbonControlEventArgs e)
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slibe\OneKeyTools", false);
            string Location = path.GetValue("Path", "").ToString();
            System.Diagnostics.Process.Start("Explorer.exe", Location);
        }

        public void button126_Click(object sender, RibbonControlEventArgs e)
        {
            Picture_Settings Picture_Settings = null;
            if (Picture_Settings == null || Picture_Settings.IsDisposed)
            {
                Picture_Settings = new Picture_Settings();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Picture_Settings.Show();
            }
            button126.Enabled = false;
        }

        public void button171_Click_1(object sender, RibbonControlEventArgs e)
        {
            Picture_inPic Picture_inPic = null;
            if (Picture_inPic == null || Picture_inPic.IsDisposed)
            {
                Picture_inPic = new Picture_inPic();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Picture_inPic.Show();
            }
            button171.Enabled = false;
        }

        public void button173_Click(object sender, RibbonControlEventArgs e)
        {
            Notes_Add Notes_Add = null;
            if (Notes_Add == null || Notes_Add.IsDisposed)
            {
                Notes_Add = new Notes_Add();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Notes_Add.Show();
                button173.Enabled = false;
            }
        }

        public void button174_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    shape.TextFrame2.MarginLeft = 0f;
                    shape.TextFrame2.MarginRight = 0f;
                    shape.TextFrame2.MarginTop = 0f;
                    shape.TextFrame2.MarginBottom = 0f;
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        shape.TextFrame2.MarginLeft = 0f;
                        shape.TextFrame2.MarginRight = 0f;
                        shape.TextFrame2.MarginTop = 0f;
                        shape.TextFrame2.MarginBottom = 0f;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中文本框或包含文本框的幻灯片");
            }
        }

        public void button175_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int n = 0;
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    for (int i = slide.Shapes.Count; i >= 1; i--)
                    {
                        PowerPoint.Shape shape = slide.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoMedia && shape.MediaType == PowerPoint.PpMediaType.ppMediaTypeSound)
                        {
                            shape.Delete();
                            n += 1;
                        }
                    }
                }
                MessageBox.Show("已删除" + n + "个音频文件");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                int n = 0;
                foreach (PowerPoint.Shape shape in sel.ShapeRange)
                {
                    if (shape.Type == Office.MsoShapeType.msoMedia && shape.MediaType == PowerPoint.PpMediaType.ppMediaTypeSound)
                    {
                        shape.Delete();
                        n += 1;
                    }
                }
                MessageBox.Show("已删除" + n + "个音频文件");
            }
            else
            {
                MessageBox.Show("请先选中音频图标或包含音频的幻灯片");
            }
        }

        public void button194_Click(object sender, RibbonControlEventArgs e)
        {
            Align_Extended Align_Extended = null;
            if (Align_Extended == null || Align_Extended.IsDisposed)
            {
                Align_Extended = new Align_Extended();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Align_Extended.Show();
            }
            button194.Enabled = false;
        }

        public void button195_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PixMix = Properties.Settings.Default.PicMix;
                            if (PixMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int r0 = color.R;
                                        int g0 = color.G;
                                        int b0 = color.B;
                                        int na = color2.A;
                                        int r1 = color2.R;
                                        int g1 = color2.G;
                                        int b1 = color2.B;
                                        int nhsl0 = Rgb2Hsl(r0, g0, b0);
                                        int nhsl1 = Rgb2Hsl(r1, g1, b1);
                                        int nl = (nhsl1 / 256 / 256) % 256;
                                        int ns = (nhsl1 / 256) % 256;
                                        int nh = nhsl0 % 256;
                                        int nrgb = Hsl2Rgb(nh, ns, nl);
                                        int nr = nrgb % 256;
                                        int ng = (nrgb / 256) % 256;
                                        int nb = (nrgb / 256 / 256) % 256;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int r0 = color.R;
                                        int g0 = color.G;
                                        int b0 = color.B;
                                        int na = color2.A;
                                        int r1 = color2.R;
                                        int g1 = color2.G;
                                        int b1 = color2.B;
                                        int nhsl0 = Rgb2Hsl(r0, g0, b0);
                                        int nhsl1 = Rgb2Hsl(r1, g1, b1);
                                        int nl = (nhsl1 / 256 / 256) % 256;
                                        int ns = (nhsl1 / 256) % 256;
                                        int nh = nhsl0 % 256;
                                        int nrgb = Hsl2Rgb(nh, ns, nl);
                                        int nr = nrgb % 256;
                                        int ng = (nrgb / 256) % 256;
                                        int nb = (nrgb / 256 / 256) % 256;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button196_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slides slides = app.ActivePresentation.Slides;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中至少一个图形，注意不要选占位符");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int sid = sel.SlideRange.SlideNumber;
                int count = range.Count;
                List<string> oname = new List<string>();
                List<string> name = new List<string>();
                for (int i = 1; i <= range.Count; i++)
                {
                    oname.Add(range[i].Name);
                    range[i].Name = range[i].Name + "_" + i;
                    name.Add(range[i].Name);
                }
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = slides[sid].Shapes[name[i - 1]];
                    shape.Copy();
                    PowerPoint.Slide slide = null;
                    if (sid + i <= slides.Count)
                    {
                        slide = slides[sid + i];
                    }
                    else
                    {
                        PowerPoint.CustomLayout layout = slides[sid].CustomLayout;
                        slide = slides.AddSlide(sid + i, layout);
                    }
                    slide.Shapes.Paste();
                }
                for (int i = 0; i < oname.Count(); i++)
                {
                    slides[sid].Shapes[name[i]].Name = oname[i];
                }
            }
        }

        public void button197_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || ((sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup) || (sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup && sel.ShapeRange.Count < 2)))
            {
                MessageBox.Show("请选择至少2个不同宽度的线条");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float min = range[1].GroupItems[1].Line.Weight;
                        float max = range[1].GroupItems[1].Line.Weight;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float olinew = range[1].GroupItems[i].Line.Weight;
                            min = Math.Min(olinew, min);
                            max = Math.Max(olinew, max);
                        }
                        if (min == max)
                        {
                            MessageBox.Show("请先改变一个线条的宽度");
                        }
                        else
                        {
                            Random rand = new Random();
                            if (min == 0)
                            {
                                min = 0.5f;
                            }
                            for (int j = 1; j <= range[1].GroupItems.Count; j++)
                            {
                                float ran1 = rand.Next((int)(min * 100), (int)(max * 100));
                                if (range[1].GroupItems[j].Line.Visible == Office.MsoTriState.msoFalse)
                                {
                                    range[1].GroupItems[j].Line.Visible = Office.MsoTriState.msoTrue;
                                }
                                range[1].GroupItems[j].Line.Weight = (j - j + 1) * (ran1 / 100);
                            }
                        }
                    }
                }
                else if (count >= 2)
                {
                    float min = range[1].Line.Weight;
                    float max = range[1].Line.Weight;

                    for (int i = 2; i <= count; i++)
                    {
                        float olinew = range[i].Line.Weight;
                        min = Math.Min(olinew, min);
                        max = Math.Max(olinew, max);
                    }
                    if (min == max)
                    {
                        MessageBox.Show("请先改变一个线条的宽度");
                    }
                    else
                    {
                        Random rand = new Random();
                        if (min == 0)
                        {
                            min = 0.5f;
                        }
                        for (int j = 1; j <= count; j++)
                        {
                            float ran1 = rand.Next((int)(min * 100), (int)(max * 100));
                            if (range[j].Line.Visible == Office.MsoTriState.msoFalse)
                            {
                                range[j].Line.Visible = Office.MsoTriState.msoTrue;
                            }
                            range[j].Line.Weight = (j - j + 1) * (ran1 / 100);
                        }
                    }
                }
            }
        }

        public void button198_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("支持的情形有：" + Environment.NewLine + "1.选中至少3个纯色形状，且第1个形状不能是组合" + Environment.NewLine + "2.只选中一个组合，且组合内有三个形状" + Environment.NewLine + "3.选中一个组合内三个以上形状"+ Environment.NewLine + "4.选中文字");
            }
            else if ((sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes && sel.ShapeRange.Count == 1 && sel.ShapeRange.HasTextFrame == Office.MsoTriState.msoTrue && sel.ShapeRange.TextFrame.HasText == Office.MsoTriState.msoTrue) || sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextFrame2 tf2 = sel.ShapeRange[1].TextFrame2;
                int count = tf2.TextRange.Characters.Count;
                float min = tf2.TextRange.Characters[1].Font.Fill.Transparency;
                float max = tf2.TextRange.Characters[1].Font.Fill.Transparency;
                for (int i = 2; i <= count; i++)
                {
                    float otr = tf2.TextRange.Characters[i].Font.Fill.Transparency;
                    min = Math.Min(otr, min);
                    max = Math.Max(otr, max);
                }

                if (min == max)
                {
                    Random rand = new Random();
                    for (int j = 1; j <= count; j++)
                    {
                        float ran1 = rand.Next(0, 100);
                        tf2.TextRange.Characters[j].Font.Fill.Transparency = (j - j + 1) * (ran1 / 100);
                    }
                }
                else
                {
                    Random rand = new Random();
                    for (int j = 1; j <= count; j++)
                    {
                        float ran1 = rand.Next((int)(min * 100), (int)(max * 100));
                        tf2.TextRange.Characters[j].Font.Fill.Transparency = (j - j + 1) * (ran1 / 100);
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && sel.ShapeRange.Count == 1) || (sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && ((sel.ShapeRange[1].Type == Office.MsoShapeType.msoFreeform || sel.ShapeRange[1].Type == Office.MsoShapeType.msoAutoShape || sel.ShapeRange[1].Type == Office.MsoShapeType.msoLine) && sel.ShapeRange.Count >= 3)) || sel.ShapeRange[1].Type != Office.MsoShapeType.msoTable)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1 && range[1].Type == Office.MsoShapeType.msoGroup)
                {
                    count = range[1].GroupItems.Count;
                    PowerPoint.Shape shape1 = range[1].GroupItems[1];
                    float min = 0;
                    float max = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform) && shape1.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        min = range[1].GroupItems[1].Fill.Transparency;
                        max = range[1].GroupItems[1].Fill.Transparency;
                        for (int i = 2; i <= count; i++)
                        {
                            float otr = range[1].GroupItems[i].Fill.Transparency;
                            min = Math.Min(otr, min);
                            max = Math.Max(otr, max);
                        }
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        min = range[1].GroupItems[1].Line.Transparency;
                        max = range[1].GroupItems[1].Line.Transparency;
                        for (int i = 2; i <= count; i++)
                        {
                            float otr = range[1].GroupItems[i].Line.Transparency;
                            min = Math.Min(otr, min);
                            max = Math.Max(otr, max);
                        }
                    }

                    if (min == max)
                    {
                        Random rand = new Random();
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform) && shape1.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                float ran1 = rand.Next(0, 100);
                                range[1].GroupItems[i].Fill.Transparency = (i - i + 1) * (ran1 / 100);
                            }
                        }
                        else if (shape1.Type == Office.MsoShapeType.msoLine || (shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                float ran1 = rand.Next(0, 100);
                                range[1].GroupItems[i].Line.Transparency = (i - i + 1) * (ran1 / 100);
                            }
                        }
                    }
                    else
                    {
                        Random rand = new Random();
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform) && shape1.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                float ran1 = rand.Next((int)(min * 100), (int)(max * 100));
                                range[1].GroupItems[i].Fill.Transparency = (i - i + 1) * (ran1 / 100);
                            }
                        }
                        else if (shape1.Type == Office.MsoShapeType.msoLine || (shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                float ran1 = rand.Next((int)(min * 100), (int)(max * 100));
                                range[1].GroupItems[i].Line.Transparency = (i - i + 1) * (ran1 / 100);
                            }
                        }
                    }
                }
                else
                {
                    PowerPoint.Shape shape1 = range[1];
                    PowerPoint.Shape shape2 = range[count];
                    float min = 0;
                    float max = 0;
                    if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform) && shape1.Fill.Visible == Office.MsoTriState.msoTrue) && ((shape2.Type == Office.MsoShapeType.msoAutoShape || shape2.Type == Office.MsoShapeType.msoFreeform) && shape2.Fill.Visible == Office.MsoTriState.msoTrue))
                    {
                        min = range[1].Fill.Transparency;
                        max = range[1].Fill.Transparency;
                        for (int i = 2; i <= count; i++)
                        {
                            float otr = range[i].Fill.Transparency;
                            min = Math.Min(otr, min);
                            max = Math.Max(otr, max);
                        }
                    }
                    else if ((shape1.Type == Office.MsoShapeType.msoLine && shape2.Type == Office.MsoShapeType.msoLine) || ((shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue) && (shape2.Fill.Visible == Office.MsoTriState.msoFalse && shape2.Line.Visible == Office.MsoTriState.msoTrue)))
                    {
                        min = range[1].Line.Transparency;
                        max = range[1].Line.Transparency;
                        for (int i = 2; i <= count; i++)
                        {
                            float otr = range[i].Line.Transparency;
                            min = Math.Min(otr, min);
                            max = Math.Max(otr, max);
                        }
                    }

                    if (min == max)
                    {
                        Random rand = new Random();
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform) && shape1.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                float ran1 = rand.Next(0, 100);
                                range[i].Fill.Transparency = (i - i + 1) * (ran1 / 100);
                            }
                        }
                        else if (shape1.Type == Office.MsoShapeType.msoLine || (shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                float ran1 = rand.Next(0, 100);
                                range[i].Line.Transparency = (i - i + 1) * (ran1 / 100);
                            }
                        }
                    }
                    else
                    {
                        Random rand = new Random();
                        if (((shape1.Type == Office.MsoShapeType.msoAutoShape || shape1.Type == Office.MsoShapeType.msoFreeform) && shape1.Fill.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                float ran1 = rand.Next((int)(min * 100), (int)(max * 100));
                                range[i].Fill.Transparency = (i - i + 1) * (ran1 / 100);
                            }
                        }
                        else if (shape1.Type == Office.MsoShapeType.msoLine || (shape1.Fill.Visible == Office.MsoTriState.msoFalse && shape1.Line.Visible == Office.MsoTriState.msoTrue))
                        {
                            for (int i = 1; i <= count; i++)
                            {
                                float ran1 = rand.Next((int)(min * 100), (int)(max * 100));
                                range[i].Line.Transparency = (i - i + 1) * (ran1 / 100);
                            }
                        }
                    }
                }
            }
        }

        public void button200_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中至少2个形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            range[1].GroupItems[i].Line.Weight = range[1].GroupItems[1].Line.Weight;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一个组合或者两个以上形状");
                    }
                }
                else if (count >= 2)
                {
                    for (int i = 2; i <= count; i++)
                    {
                        range[i].Line.Weight = range[1].Line.Weight;
                    }
                }
            }
        }

        public void button201_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请至少选择2个形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float min = range[1].GroupItems[1].Line.Weight;
                        float max = range[1].GroupItems[1].Line.Weight;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float olinew = range[1].GroupItems[i].Line.Weight;
                            min = Math.Min(olinew, min);
                            max = Math.Max(olinew, max);
                        }

                        float n1 = (max - min) / (range[1].GroupItems.Count - 1);

                        for (int j = 1; j <= range[1].GroupItems.Count; j++)
                        {
                            range[1].GroupItems[j].Line.Weight = min + n1 * (j - 1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一个组合或者两个以上形状");
                    }
                }
                else if (count >= 2)
                {
                    float min = range[1].Line.Weight;
                    float max = range[1].Line.Weight;

                    for (int i = 2; i <= count; i++)
                    {
                        float olinew = range[i].Line.Weight;
                        min = Math.Min(olinew, min);
                        max = Math.Max(olinew, max);
                    }

                    float n1 = (max - min) / (count - 1);

                    for (int j = 1; j <= count; j++)
                    {
                        range[j].Line.Weight = min + n1 * (j - 1);
                    }
                }
            }
        }

        public void button199_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请至少选择2个形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float min = range[1].GroupItems[1].Line.Weight;
                        float max = range[1].GroupItems[1].Line.Weight;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float olinew = range[1].GroupItems[i].Line.Weight;
                            min = Math.Min(olinew, min);
                            max = Math.Max(olinew, max);
                        }

                        float n1 = (max - min) / (range[1].GroupItems.Count - 1);

                        for (int j = 1; j <= range[1].GroupItems.Count; j++)
                        {
                            range[1].GroupItems[j].Line.Weight = max - n1 * (j - 1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一个组合或者两个以上形状");
                    }
                }
                else if (count >= 2)
                {
                    float min = range[1].Line.Weight;
                    float max = range[1].Line.Weight;

                    for (int i = 2; i <= count; i++)
                    {
                        float olinew = range[i].Line.Weight;
                        min = Math.Min(olinew, min);
                        max = Math.Max(olinew, max);
                    }

                    float n1 = (max - min) / (count - 1);

                    for (int j = 1; j <= count; j++)
                    {
                        range[j].Line.Weight = max - n1 * (j - 1);
                    }
                }
            }
        }

        public void button202_Click(object sender, RibbonControlEventArgs e)
        {
            Align_Classics Align_Classics = null;
            if (Align_Classics == null || Align_Classics.IsDisposed)
            {
                Align_Classics = new Align_Classics();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Align_Classics.Show();
            }
            button202.Enabled = false;
        }

        public void button203_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count <= 1)
            {
                MessageBox.Show("请先选中至少两个元素，其中一个是形状，另一个是图片");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                string apath = app.ActivePresentation.Path;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                List<int> list1 = new List<int>();
                List<int> list2 = new List<int>();
                for (int i = 1; i <= range.Count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform)
                    {
                        list1.Add(i);
                    }
                    else if (shape.Type == Office.MsoShapeType.msoPicture)
                    {
                        list2.Add(i);
                    }
                }
                if (list2.Count == 0 && list1.Count != 0)
                {
                    MessageBox.Show("所选元素中没有图片或不能有组合");
                }
                else if (list1.Count == 0)
                {
                    MessageBox.Show("所选元素中没有形状或不能有组合");
                }
                else
                {
                    int ncount = 0;
                    if (list2.Count <= list1.Count)
                    {
                        ncount = list2.Count();
                    }
                    else
                    {
                        ncount = list1.Count();
                    }
                    float mw = 0;
                    for (int i = 0; i < ncount; i++)
                    {
                        PowerPoint.Shape pics = range[list2[i]];
                        float rt = pics.Rotation;
                        if (rt == 0)
                        {
                            pics.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                            PowerPoint.Shape shapes = range[list1[i]];
                            shapes.Fill.Visible = Office.MsoTriState.msoTrue;
                            shapes.Fill.UserPicture(apath + @"xshape.png");
                            if (!checkBox2.Checked)
                            {
                                mw = shapes.Left + shapes.Width / 2;
                                shapes.Width = pics.Width / pics.Height * shapes.Height;
                                shapes.Left = mw - shapes.Width / 2;
                            }
                            File.Delete(apath + @"xshape.png");
                        }
                        else
                        {
                            pics.Copy();
                            PowerPoint.Shape npics = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            npics.ScaleHeight(1f, Office.MsoTriState.msoFalse, Office.MsoScaleFrom.msoScaleFromTopLeft);
                            npics.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                            PowerPoint.Shape shapes = range[list1[i]];
                            shapes.Fill.Visible = Office.MsoTriState.msoTrue;
                            shapes.Fill.UserPicture(apath + @"xshape.png");
                            if (!checkBox2.Checked)
                            {
                                mw = shapes.Left + shapes.Width / 2;
                                shapes.Width = npics.Width / npics.Height * shapes.Height;
                                shapes.Left = mw - shapes.Width / 2;
                            }
                            File.Delete(apath + @"xshape.png");
                            npics.Delete();
                        }
                    }
                }
            }
        }

        public void button204_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count <= 1)
            {
                MessageBox.Show("请先选中至少两个元素，其中一个是形状，另一个是图片");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                string apath = app.ActivePresentation.Path;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                List<int> list1 = new List<int>();
                List<int> list2 = new List<int>();
                for (int i = 1; i <= range.Count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform)
                    {
                        list1.Add(i);
                    }
                    else if (shape.Type == Office.MsoShapeType.msoPicture)
                    {
                        list2.Add(i);
                    }
                }
                if (list2.Count == 0 && list1.Count != 0)
                {
                    MessageBox.Show("所选元素中没有图片或不能有组合");
                }
                else if (list1.Count == 0)
                {
                    MessageBox.Show("所选元素中没有形状或不能有组合");
                }
                else
                {
                    float mw = 0;
                    for (int i = 0; i < list1.Count(); i++)
                    {
                        int n = i % list2.Count();
                        PowerPoint.Shape pics = range[list2[n]];
                        float rt = pics.Rotation;
                        if (rt == 0)
                        {
                            pics.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                            PowerPoint.Shape shapes = range[list1[i]];
                            shapes.Fill.Visible = Office.MsoTriState.msoTrue;
                            shapes.Fill.UserPicture(apath + @"xshape.png");
                            if (!checkBox2.Checked)
                            {
                                mw = shapes.Left + shapes.Width / 2;
                                shapes.Width = pics.Width / pics.Height * shapes.Height;
                                shapes.Left = mw - shapes.Width / 2;
                            }
                            File.Delete(apath + @"xshape.png");
                        }
                        else
                        {
                            pics.Copy();
                            PowerPoint.Shape npics = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            npics.ScaleHeight(1f, Office.MsoTriState.msoFalse, Office.MsoScaleFrom.msoScaleFromTopLeft);
                            npics.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                            PowerPoint.Shape shapes = range[list1[i]];
                            shapes.Fill.Visible = Office.MsoTriState.msoTrue;
                            shapes.Fill.UserPicture(apath + @"xshape.png");
                            if (!checkBox2.Checked)
                            {
                                mw = shapes.Left + shapes.Width / 2;
                                shapes.Width = npics.Width / npics.Height * shapes.Height;
                                shapes.Left = mw - shapes.Width / 2;
                            }
                            File.Delete(apath + @"xshape.png");
                            npics.Delete();
                        }
                    }
                }
            }
        }

        public void button205_Click(object sender, RibbonControlEventArgs e)
        {
            Picture_Wave Picture_Wave = null;
            if (Picture_Wave == null || Picture_Wave.IsDisposed)
            {
                Picture_Wave = new Picture_Wave();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Picture_Wave.Show();
            }
            button205.Enabled = false;
        }
        
        string nfName = Properties.Settings.Default.GalleryPath;
        int gallerycan = 1;
        private void gallery1_Click(object sender, RibbonControlEventArgs e)
        {
            if (File.Exists(nfName))
            {
                int n = gallery1.SelectedItemIndex;
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.Application pptapp = new PowerPoint.Application();
                PowerPoint.Presentation pptpr = pptapp.Presentations.Open(nfName, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse);
                int sn = 0;
                if (pptpr.Slides.Count > 1)
                {
                    for (int i = 1; i <= pptpr.Slides.Count; i++)
                    {
                        PowerPoint.Slide oslide = pptpr.Slides[i];
                        sn += oslide.Shapes.Count;
                        if (n + 1 <= sn)
                        {
                            oslide.Shapes[oslide.Shapes.Count - sn + n + 1].Copy();
                            break;
                        }
                    }
                }
                else
                {
                    pptpr.Slides[1].Shapes[n + 1].Copy();
                }
                PowerPoint.Shape nshape = slide.Shapes.Paste()[1];
                pptpr.Close();
                nshape.Left = app.ActivePresentation.PageSetup.SlideWidth / 2 - nshape.Width / 2;
                nshape.Top = app.ActivePresentation.PageSetup.SlideHeight / 2 - nshape.Height / 2;
                nshape.Select();
            }
            else
            {
                MessageBox.Show("请重新加载库,如果加载库后还是有问题，请先给PPT获取管理员权限再打开");
                gallerycan = 0;
            }
        }

        private RibbonDropDownItem CreateRibbonDropDownItem()
        {
            return this.Factory.CreateRibbonDropDownItem();
        }

        private void gallery1_ItemsLoading(object sender, RibbonControlEventArgs e)
        {
            if (File.Exists(nfName) && nfName != "")
            {
                if (gallerycan == 1 || (gallerycan == 0 && Properties.Settings.Default.GalleryRefresh == 1))
                {
                    string Location = "";
                    RegistryKey path = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slibe\OneKeyTools", false);
                    if (Properties.Settings.Default.Galleryfolder == "")
                    {
                        Location = path.GetValue("Path", "").ToString();
                    }
                    else
                    {
                        Location = Properties.Settings.Default.Galleryfolder;
                    }
                    if (nfName.Contains("pptx"))
                    {
                        if (gallery1.Items.Count != 0)
                        {
                            for (int i = gallery1.Items.Count - 1; i >= 0; i--)
                            {
                                gallery1.Items[i].Image.Dispose();
                            }
                        }

                        if (!Directory.Exists(Location + @"temp_gallery\"))
                        {
                            Directory.CreateDirectory(Location + @"temp_gallery\");
                        }
                        
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Location + @"temp_gallery\");
                        gallery1.Items.Clear();

                        PowerPoint.Application pptapp = new PowerPoint.Application();
                        PowerPoint.Presentation pptpr = pptapp.Presentations.Open(nfName, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse);
                        int n = 0;
                        int error = 0;
                        try
                        {
                            foreach (PowerPoint.Slide oslide in pptpr.Slides)
                            {
                                if (oslide.Shapes.Count != 0)
                                {
                                    for (int i = 1; i <= oslide.Shapes.Count; i++)
                                    {
                                        PowerPoint.Shape oshape = oslide.Shapes[i];
                                        int k = dir.GetFiles().Length + 1;
                                        string npath = Location + @"temp_gallery\gshape_" + k + ".png";
                                        oshape.Export(npath, PowerPoint.PpShapeFormat.ppShapeFormatPNG, 300, 300);
                                        RibbonDropDownItem item = CreateRibbonDropDownItem();
                                        Image img = Image.FromFile(npath);
                                        Bitmap bmp = new Bitmap(img);
                                        img.Dispose();
                                        item.Image = bmp;
                                        gallery1.Items.Add(item);
                                    }
                                    n += 1;
                                }
                            }
                            Directory.Delete(Location + @"temp_gallery\", true);
                            pptpr.Close();
                            gallerycan = 0;
                            Properties.Settings.Default.GalleryRefresh = 0;
                            Properties.Settings.Default.Save();
                            if (n == 0)
                            {
                                MessageBox.Show("库目前为空，可添加图形到该库");
                            }
                        }
                        catch
                        {
                            error = 1;
                        }
                        if (error == 1)
                        {
                            gallerycan = 0;
                            Properties.Settings.Default.GalleryRefresh = 0;
                            Properties.Settings.Default.Save();
                            MessageBox.Show("发生错误，可能是图形库中有不能保存为图片的元素，或者组成一个图形的子形状太多。请直接用PPT（非图形库）打开库文件，检查库里的元素");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请重新加载库");
                    }
                }
            }
            else
            {
                MessageBox.Show("请先加载库");
            }
        }

        public void button206_Click(object sender, RibbonControlEventArgs e)
        {
            //此功能致敬PPT-VBA大神无极（朱建国）的PPT新视角工具
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                string Location = "";
                if (Properties.Settings.Default.Galleryfolder == "")
                {
                    RegistryKey path = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slibe\OneKeyTools", false);
                    Location = path.GetValue("Path", "").ToString();
                }
                else
                {
                    Location = Properties.Settings.Default.Galleryfolder;
                }
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Location;
                saveFileDialog1.Filter = "PowerPoint演示文稿|*.pptx";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = "temp_gallery";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string npath = saveFileDialog1.FileName;
                        string fopath = Path.GetDirectoryName(npath);
                        //SetFilesAccount(fopath);
                        PowerPoint.Application pptapp = new PowerPoint.Application();
                        PowerPoint.Presentation pptpr = pptapp.Presentations.Add(Office.MsoTriState.msoFalse);
                        pptpr.Slides.AddSlide(1, pptpr.SlideMaster.CustomLayouts[7]);

                        PowerPoint.ShapeRange range = sel.ShapeRange;
                        if (sel.HasChildShapeRange)
                        {
                            range = sel.ChildShapeRange;
                        }
                        int count = range.Count;
                        for (int i = 1; i <= count; i++)
                        {
                            PowerPoint.Shape shape = range[i];
                            shape.Copy();
                            PowerPoint.Shape nshape = pptpr.Slides[1].Shapes.Paste()[1];
                        }
                        pptpr.SaveAs(npath, PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Office.MsoTriState.msoTrue);
                        pptpr.Close();
                        nfName = npath;
                        gallerycan = 1;
                        Properties.Settings.Default.GalleryPath = nfName;
                        Properties.Settings.Default.Save();
                        MessageBox.Show("新建成功，请点击“图形库”进行查看");
                    }
                    catch
                    {
                        MessageBox.Show("好像出问题了，可以尝试：开始菜单→所有程序→Microsoft Office→PowerPoint上右键→以管理员身份运行");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中图形");
            }
        }

        public void button207_Click(object sender, RibbonControlEventArgs e)
        {
            string Location = "";
            if (Properties.Settings.Default.Galleryfolder == "")
            {
                RegistryKey path = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slibe\OneKeyTools", false);
                Location = path.GetValue("Path", "").ToString();
            }
            else
            {
                Location = Properties.Settings.Default.Galleryfolder;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Location;
            openFileDialog.Filter = "PowerPoint演示文稿|*.pptx";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
                if (fName.Contains("pptx"))
                {
                    PowerPoint.Application pptapp = new PowerPoint.Application();
                    PowerPoint.Presentation pptpr = pptapp.Presentations.Open(fName, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse);
                    int n = 0;
                    foreach (PowerPoint.Slide item in pptpr.Slides)
                    {
                        if (item.Shapes.Count != 0)
                        {
                            n += 1;
                        }
                    }
                    pptpr.Close();
                    if (n == 0)
                    {
                        MessageBox.Show("库目前为空，可添加图形到该库");
                    }
                    nfName = fName;
                    Properties.Settings.Default.GalleryPath = fName;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("加载成功，请点击“图形库”进行查看");
                }
                gallerycan = 1;
            }
        }

        public void button209_Click(object sender, RibbonControlEventArgs e)
        {
            if (nfName != "" && File.Exists(nfName))
            {
                PowerPoint.Selection sel = app.ActiveWindow.Selection;
                if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
                {
                    PowerPoint.Application pptapp = new PowerPoint.Application();
                    PowerPoint.Presentation pptpr = pptapp.Presentations.Open(nfName, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse);
                    if (pptpr.Slides.Count == 0 || pptpr.Slides[pptpr.Slides.Count].Shapes.Count != 0)
                    {
                        pptpr.Slides.AddSlide(pptpr.Slides.Count + 1, pptpr.SlideMaster.CustomLayouts[7]);
                    }

                    PowerPoint.ShapeRange range = sel.ShapeRange;
                    if (sel.HasChildShapeRange)
                    {
                        range = sel.ChildShapeRange;
                    }
                    int count = range.Count;
                    for (int i = 1; i <= count; i++)
                    {
                        PowerPoint.Shape shape = range[i];
                        shape.Copy();
                        PowerPoint.Shape nshape = pptpr.Slides[pptpr.Slides.Count].Shapes.Paste()[1];
                    }
                    pptpr.SaveAs(nfName, PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Office.MsoTriState.msoTrue);
                    pptpr.Close();
                    gallerycan = 1;
                    MessageBox.Show("添加成功，请点击“图形库”进行查看");
                }
                else
                {
                    MessageBox.Show("请选中图形");
                }
            }
            else
            {
                MessageBox.Show("请先加载或重新加载库");
            }
        }

        public void button208_Click(object sender, RibbonControlEventArgs e)
        {
            Gallery_Delete Gallery_Delete = null;
            if (Gallery_Delete == null || Gallery_Delete.IsDisposed)
            {
                Gallery_Delete = new Gallery_Delete();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Gallery_Delete.Show();
            }
        }

        public void button210_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请选中多个图形");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                float maxl = range[1].Left + range[1].Width;
                float minl = range[1].Left;
                float maxt = range[1].Top + range[1].Height;
                float mint = range[1].Top;

                for (int i = 2; i <= count; i++)
                {
                    minl = Math.Min(range[i].Left, minl);
                    mint = Math.Min(range[i].Top, mint);
                    maxl = Math.Max(range[i].Left + range[i].Width, maxl);
                    maxt = Math.Max(range[i].Top + range[i].Height, maxt);
                }

                string[] name = new string[count];
                for (int j = 1; j <= count; j++)
                {
                    name[j - 1] = range[j].Name;
                }

                for (int k = 1; k <= count; k++)
                {
                    string[] name2 = new string[2];
                    PowerPoint.Shape bw = slide.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, minl, mint, maxl - minl, maxt - mint);
                    bw.Fill.Transparency = 1f;
                    bw.Line.Visible = Office.MsoTriState.msoFalse;
                    bw.Name = "补位_" + k;
                    name2[0] = bw.Name;
                    name2[1] = name[k - 1];
                    slide.Shapes.Range(name2).Group();
                }
            }
        }

        public void button211_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int n = 0;
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    for (int i = slide.Shapes.Count; i >= 1; i--)
                    {
                        PowerPoint.Shape shape = slide.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoMedia && shape.MediaType == PowerPoint.PpMediaType.ppMediaTypeMovie)
                        {
                            shape.Delete();
                            n += 1;
                        }
                    }
                }
                MessageBox.Show("已删除" + n + "个视频文件");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                int n = 0;
                foreach (PowerPoint.Shape shape in sel.ShapeRange)
                {
                    if (shape.Type == Office.MsoShapeType.msoMedia && shape.MediaType == PowerPoint.PpMediaType.ppMediaTypeMovie)
                    {
                        shape.Delete();
                        n += 1;
                    }
                }
                MessageBox.Show("已删除" + n + "个视频文件");
            }
            else
            {
                MessageBox.Show("请选中视频或包含视频的幻灯片");
            }
        }

        public void button212_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                if (range.Count == 1)
                {
                    PowerPoint.Shape shape = range[1];
                    float osw = app.ActivePresentation.PageSetup.SlideWidth;
                    float osh = app.ActivePresentation.PageSetup.SlideHeight;
                    float ow = shape.Width;
                    float oh = shape.Height;
                    if (ow <= osw)
                    {
                        float n1 = osw / ow;
                        float n2 = osh / oh;
                        string[] index = new string[(int)n1 * (int)n2];
                        for (int i = 1; i <= n2; i++)
                        {
                            for (int j = 1; j <= n1; j++)
                            {
                                PowerPoint.Shape nshape = shape.Duplicate()[1];
                                nshape.Left = nshape.Width * (j - 1);
                                nshape.Top = nshape.Height * (i - 1);
                                index[(i - 1) * (int)n1 + j - 1] = nshape.Name;
                            }
                        }
                        slide.Shapes.Range(index).Group();
                    }
                    else
                    {
                        MessageBox.Show("图形超过了页面的尺寸");
                    }
                }
                else if (range.Count == 2)
                {
                    float osw = range[1].Width;
                    float osh = range[1].Height;
                    float ow = range[2].Width;
                    float oh = range[2].Height;
                    if (osw >= ow)
                    {
                        float n1 = osw / ow;
                        float n2 = osh / oh;
                        string[] index = new string[(int)n1 * (int)n2];
                        for (int i = 1; i <= n2; i++)
                        {
                            for (int j = 1; j <= n1; j++)
                            {
                                PowerPoint.Shape nshape = range[2].Duplicate()[1];
                                nshape.Left = range[1].Left + nshape.Width * (j - 1);
                                nshape.Top = range[1].Top + nshape.Height * (i - 1);
                                index[(i - 1) * (int)n1 + j - 1] = nshape.Name;
                            }
                        }
                        if (index.Count() >= 2)
                        {
                            slide.Shapes.Range(index).Group();
                        }
                    }
                    else
                    {
                        float n1 = ow / osw;
                        float n2 = oh / osh;
                        string[] index = new string[(int)n1 * (int)n2];
                        for (int i = 1; i <= n2; i++)
                        {
                            for (int j = 1; j <= n1; j++)
                            {
                                PowerPoint.Shape nshape = range[1].Duplicate()[1];
                                nshape.Left = range[2].Left + nshape.Width * (j - 1);
                                nshape.Top = range[2].Top + nshape.Height * (i - 1);
                                index[(i - 1) * (int)n1 + j - 1] = nshape.Name;
                            }
                        }
                        if (index.Count() >= 2)
                        {
                            slide.Shapes.Range(index).Group();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选中2个图形，第一个为大图形，第二个为小图形");
                }
            }
        }

        public void button213_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选择图形");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count >= 2)
                {
                    PowerPoint.Shape shape0 = range[count];
                    float lm0 = shape0.Left + shape0.Width / 2;
                    float tm0 = shape0.Top + shape0.Height / 2;
                    List<int> num = new List<int>();
                    for (int i = 1; i <= count; i++)
                    {
                        num.Add(range[i].ZOrderPosition);
                    }

                    string[] name = new string[count];
                    for (int i = 1; i < count; i++)
                    {
                        PowerPoint.Shape shape = range[i];
                        float lm = shape.Left + shape.Width / 2;
                        float tm = shape.Top + shape.Height / 2;
                        PowerPoint.Shape line = slide.Shapes.AddLine(lm0, tm0, lm, tm);
                        if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                        {
                            line.Line.ForeColor.RGB = shape.Fill.ForeColor.RGB;
                        }
                        else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                        {
                            line.Line.ForeColor.RGB = shape.Fill.GradientStops[1].Color.RGB;
                        }
                        name[i - 1] = line.Name;
                    }
                    PowerPoint.Shape group = slide.Shapes.Range(name).Group();
                    int nx = group.ZOrderPosition - num.Min();
                    for (int i = 0; i < nx; i++)
                    {
                        i += 0;
                        group.ZOrder(Office.MsoZOrderCmd.msoSendBackward);
                    }
                }
                else
                {
                    MessageBox.Show("请选中2个以上图形");
                }
            }
        }

        public void button214_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes || sel.ShapeRange.Count < 2)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int n = 0;
                for (int i = 1; i < range.Count; i++)
                {
                    PowerPoint.Shape groupn = sel.ShapeRange[i];
                    PowerPoint.Shape groupn2 = sel.ShapeRange[i + 1];
                    if (groupn.Type == Office.MsoShapeType.msoGroup && groupn2.Type == Office.MsoShapeType.msoGroup)
                    {
                        float[,] arrg1 = new float[groupn.GroupItems.Count, 3];
                        float[,] arrg2 = new float[groupn2.GroupItems.Count, 3];
                        for (int j = 1; j <= groupn.GroupItems.Count; j++)
                        {
                            arrg1[j - 1, 0] = groupn.GroupItems[j].Left + groupn.GroupItems[j].Width / 2;
                            arrg1[j - 1, 1] = groupn.GroupItems[j].Top + groupn.GroupItems[j].Height / 2;
                            arrg1[j - 1, 2] = groupn.GroupItems[j].Fill.ForeColor.RGB;
                        }
                        for (int j = 1; j <= groupn2.GroupItems.Count; j++)
                        {
                            arrg2[j - 1, 0] = groupn2.GroupItems[j].Left + groupn2.GroupItems[j].Width / 2;
                            arrg2[j - 1, 1] = groupn2.GroupItems[j].Top + groupn2.GroupItems[j].Height / 2;
                            arrg2[j - 1, 2] = groupn2.GroupItems[j].Fill.ForeColor.RGB;
                        }
                        List<string> name = new List<string>();
                        PowerPoint.Shape line = null;
                        if (arrg1.Length <= arrg2.Length)
                        {
                            for (int k = 0; k < arrg1.Length / 3; k++)
                            {
                                line = slide.Shapes.AddLine(arrg1[k, 0], arrg1[k, 1], arrg2[k, 0], arrg2[k, 1]);
                                line.Line.ForeColor.RGB = (int)arrg1[k, 2];
                                name.Add(line.Name);
                            }
                        }
                        else
                        {
                            for (int k = 0; k < arrg2.Length / 3; k++)
                            {
                                line = slide.Shapes.AddLine(arrg1[k, 0], arrg1[k, 1], arrg2[k, 0], arrg2[k, 1]);
                                line.Line.ForeColor.RGB = (int)arrg2[k, 2];
                                name.Add(line.Name);
                            }
                        }
                        slide.Shapes.Range(name.ToArray()).Group();
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("连线出错，所选的图形必须都是组合");
                }
            }
            else
            {
                MessageBox.Show("请选中两个子元素个数相同的组合");
            }
        }

        public void button216_Click(object sender, RibbonControlEventArgs e)
        {
            Picture_Leaned Picture_Leaned = null;
            if (Picture_Leaned == null || Picture_Leaned.IsDisposed)
            {
                Picture_Leaned = new Picture_Leaned();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Picture_Leaned.Show();
            }
            button216.Enabled = false;
        }

        public void button217_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog1.Filter = "JPG图片|*.jpg|JPEG图片|*.jpeg|PNG图片|*.png|BMP图片|*.bmp|GIF图片|*.gif|EMF图片|*.emf|WMF图片|*.wmf";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.AddExtension = true;
                openFileDialog1.Multiselect = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog1.FileNames.ToArray();
                    PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                    PowerPoint.ShapeRange range = sel.ShapeRange;
                    if (sel.HasChildShapeRange)
                    {
                        range = sel.ChildShapeRange;
                    }
                    int count = Math.Min(range.Count, files.Count());
                    string[] oshapes = new string[count];

                    Bitmap obmp = null;
                    for (int i = 1; i <= count; i++)
                    {
                        PowerPoint.Shape opic = sel.ShapeRange[i];
                        obmp = new Bitmap(files[i - 1]);
                        PowerPoint.Shape npic = null;
                        if (checkBox2.Checked)
                        {
                            npic = slide.Shapes.AddPicture(files[i - 1], Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, opic.Left, opic.Top, opic.Width, opic.Height);
                        }
                        else
                        {
                            float whn = (float)obmp.Width / (float)obmp.Height * opic.Height;
                            npic = slide.Shapes.AddPicture(files[i - 1], Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, opic.Left + opic.Width / 2 - whn / 2, opic.Top, whn, opic.Height);
                        }
                        if (checkBox1.Checked)
                        {
                            try
                            {
                                opic.PickUp();
                                npic.Apply();
                            }
                            catch { }
                            try
                            {
                                opic.PickupAnimation();
                                npic.ApplyAnimation();
                            }
                            catch { }
                        }
                        npic.Rotation = opic.Rotation;
                        oshapes[i - 1] = opic.Name;
                    }
                    obmp.Dispose();
                    slide.Shapes.Range(oshapes).Delete();
                }
            }
            else
            {
                MessageBox.Show("请先选中要替换的图片");
            }
        }

        public void button218_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("请先选中至少两个元素，先选中原形状，最后选中新形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                PowerPoint.Shape nshape1 = range[range.Count];
                if (nshape1.LockAspectRatio == Office.MsoTriState.msoFalse)
                {
                    nshape1.LockAspectRatio = Office.MsoTriState.msoTrue;
                }
                List<string> name = new List<string>();
                for (int i = 1; i < range.Count; i++)
                {
                    range[i].Name = range[i].Name + "_" + i;
                    name.Add(range[i].Name);
                }
                for (int i = 1; i < range.Count; i++)
                {
                    PowerPoint.Shape nshape = nshape1.Duplicate()[1];
                    PowerPoint.Shape oshape = slide.Shapes[name[i - 1]];
                    if (checkBox2.Checked)
                    {
                        if (nshape.LockAspectRatio == Office.MsoTriState.msoTrue)
                        {
                            nshape.LockAspectRatio = Office.MsoTriState.msoFalse;
                        }
                        nshape.Width = oshape.Width;
                        nshape.Height = oshape.Height;
                        nshape.Top = oshape.Top;
                        nshape.Left = oshape.Left;
                    }
                    else
                    {
                        nshape.Height = oshape.Height;
                        nshape.Left = oshape.Left + oshape.Width / 2 - nshape.Width / 2;
                        nshape.Top = oshape.Top;
                    }
                    nshape.Rotation = oshape.Rotation;
                    if (checkBox1.Checked)
                    {
                        try
                        {
                            oshape.PickUp();
                            nshape.Apply();
                        }
                        catch { }
                        try
                        {
                            oshape.PickupAnimation();
                            nshape.ApplyAnimation();
                        }
                        catch { }
                    }
                }
                slide.Shapes.Range(name.ToArray()).Delete();
            }
        }

        public void button215_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("请先选择图形");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count >= 2)
                {
                    List<string> name = new List<string>();
                    List<int> zp = new List<int>();
                    List<string> nname = new List<string>();
                    List<string> oname = new List<string>();
                    string[] lname = new string[count - 1];
                    for (int k = 1; k <= count; k++)
                    {
                        oname.Add(range[k].Name);
                        range[k].Name = range[k].Name + "_" + k;
                        nname.Add(range[k].Name);
                        name.Add(range[k].Name);
                        zp.Add(range[k].ZOrderPosition);
                    }
                    List<int> sid = new List<int>();
                    sid.Add(1);
                    for (int i = 1; i < count; i++)
                    {
                        PowerPoint.Shape shape = range[sid[i - 1]];
                        float lm0 = shape.Left + shape.Width / 2;
                        float tm0 = shape.Top + shape.Height / 2;
                        float lm; float tm;
                        float[,] num0 = new float[count, 4];
                        int n = 0;
                        for (int j = 1; j <= count; j++)
                        {
                            if (name.Contains(range[j].Name) && range[j].Name != range[sid[i - 1]].Name)
                            {
                                lm = range[j].Left + range[j].Width / 2;
                                tm = range[j].Top + range[j].Height / 2;
                                num0[j - 1, 0] = j;
                                num0[j - 1, 1] = (float)(Math.Pow(lm - lm0, 2) + Math.Pow(tm - tm0, 2));
                                num0[j - 1, 2] = lm;
                                num0[j - 1, 3] = tm;
                            }
                            else
                            {
                                n += 1;
                            }
                        }
                        float[,] num = new float[count - n, 4];
                        int n2 = 0;
                        for (int j2 = 0; j2 < count; j2++)
                        {
                            if (num0[j2, 0] == 0)
                            {
                                n2 += 1;
                            }
                            else
                            {
                                num[j2 - n2, 0] = num0[j2, 0];
                                num[j2 - n2, 1] = num0[j2, 1];
                                num[j2 - n2, 2] = num0[j2, 2];
                                num[j2 - n2, 3] = num0[j2, 3];
                            }
                        }
                        float nid = num[0, 0]; float mix = num[0, 1]; float nlm = num[0, 2]; float ntm = num[0, 3];
                        if (num.Length / 4 >= 2)
                        {
                            for (int k = 1; k < num.Length / 4; k++)
                            {
                                if (mix >= num[k, 1])
                                {
                                    nid = num[k, 0];
                                    mix = num[k, 1];
                                    nlm = num[k, 2];
                                    ntm = num[k, 3];
                                }
                            }
                        }
                        sid.Add((int)nid);
                        PowerPoint.Shape line = slide.Shapes.AddLine(lm0, tm0, nlm, ntm);
                        if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                        {
                            line.Line.ForeColor.RGB = shape.Fill.ForeColor.RGB;
                        }
                        else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                        {
                            line.Line.ForeColor.RGB = shape.Fill.GradientStops[1].Color.RGB;
                        }
                        lname[i - 1] = line.Name;
                        name.Remove(shape.Name);
                    }

                    PowerPoint.Shape group = slide.Shapes.Range(lname).Group();
                    int nx = group.ZOrderPosition - zp.Min();
                    for (int i = 0; i < nx; i++)
                    {
                        i += 0;
                        group.ZOrder(Office.MsoZOrderCmd.msoSendBackward);
                    }
                    for (int i = 0; i < oname.Count(); i++)
                    {
                        slide.Shapes[nname[i]].Name = oname[i];
                    }
                }
                else
                {
                    MessageBox.Show("请选中2个以上图形");
                }
            }
        }

        public void button219_Click(object sender, RibbonControlEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.Galleryfolder = fb.SelectedPath;
                Properties.Settings.Default.Save();
                MessageBox.Show("图形库默认目录设置成功");
            }
        }

        public void button220_Click(object sender, RibbonControlEventArgs e)
        {
            RegistryKey path = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slibe\OneKeyTools", false);
            Properties.Settings.Default.Galleryfolder = path.GetValue("Path", "").ToString();
            Properties.Settings.Default.Save();
            MessageBox.Show("图形库恢复为默认目录（OK安装文件夹）");
        }

        public void button221_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || (sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup) || (sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && sel.ShapeRange[1].GroupItems.Count < 3) || (sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup && sel.ShapeRange.Count < 3))
            {
                MessageBox.Show("请选择至少3个不同位置的形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float minl = range[1].GroupItems[1].Left + range[1].GroupItems[1].Width;
                        float maxl = range[1].GroupItems[1].Left + range[1].GroupItems[1].Width;
                        float mint = range[1].GroupItems[1].Top + range[1].GroupItems[1].Height;
                        float maxt = range[1].GroupItems[1].Top + range[1].GroupItems[1].Height;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float oleft = range[1].GroupItems[i].Left + range[1].GroupItems[i].Width;
                            float otop = range[1].GroupItems[i].Top + range[1].GroupItems[i].Height;
                            minl = Math.Min(oleft, minl);
                            maxl = Math.Max(oleft, maxl);
                            mint = Math.Min(otop, mint);
                            maxt = Math.Max(otop, maxt);
                        }
                        if (minl == maxl && mint == maxt)
                        {
                            MessageBox.Show("请先改变一个形状的位置");
                        }
                        else
                        {
                            Random rand = new Random();
                            float n1 = 0; float n2 = 0;
                            int gcount = range[1].GroupItems.Count;
                            for (int j = 2; j < gcount; j++)
                            {
                                int ran1 = rand.Next((int)minl, (int)(minl + n1));
                                int ran2 = rand.Next((int)mint, (int)(mint + n2));
                                range[1].GroupItems[j].Left = (j - j + 1) * ran1 - range[1].GroupItems[j].Width;
                                range[1].GroupItems[j].Top = (j - j + 1) * ran2 - range[1].GroupItems[j].Height;
                                n1 += (maxl - minl) / (float)gcount;
                                n2 += (maxt - mint) / (float)gcount;
                            }
                        }
                    }
                }
                else if (count >= 2)
                {
                    float minl = range[1].Left + range[1].Width;
                    float maxl = range[1].Left + range[1].Width;
                    float mint = range[1].Top + range[1].Height;
                    float maxt = range[1].Top + range[1].Height;

                    for (int i = 2; i <= range.Count; i++)
                    {
                        float oleft = range[i].Left + range[i].Width;
                        float otop = range[i].Top + range[i].Height;
                        minl = Math.Min(oleft, minl);
                        maxl = Math.Max(oleft, maxl);
                        mint = Math.Min(otop, mint);
                        maxt = Math.Max(otop, maxt);
                    }
                    if (minl == maxl && mint == maxt)
                    {
                        MessageBox.Show("请先改变一个形状的位置");
                    }
                    else
                    {
                        Random rand = new Random();
                        float n1 = 0; float n2 = 0;
                        for (int j = 2; j < range.Count; j++)
                        {
                            int ran1 = rand.Next((int)minl, (int)(minl + n1));
                            int ran2 = rand.Next((int)mint, (int)(mint + n2));
                            range[j].Left = (j - j + 1) * ran1 - range[j].Width;
                            range[j].Top = (j - j + 1) * ran2 - range[j].Height;
                            n1 += (maxl - minl) / (float)range.Count;
                            n2 += (maxt - mint) / (float)range.Count;
                        }
                    }
                }
            }
        }

        public void button222_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || (sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup) || (sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && sel.ShapeRange[1].GroupItems.Count < 3) || (sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup && sel.ShapeRange.Count < 3))
            {
                MessageBox.Show("请选择至少3个不同位置的形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float minl = range[1].GroupItems[1].Left + range[1].GroupItems[1].Width;
                        float maxl = range[1].GroupItems[1].Left + range[1].GroupItems[1].Width;
                        float mint = range[1].GroupItems[1].Top + range[1].GroupItems[1].Height;
                        float maxt = range[1].GroupItems[1].Top + range[1].GroupItems[1].Height;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float oleft = range[1].GroupItems[i].Left + range[1].GroupItems[i].Width;
                            float otop = range[1].GroupItems[i].Top + range[1].GroupItems[i].Height;
                            minl = Math.Min(oleft, minl);
                            maxl = Math.Max(oleft, maxl);
                            mint = Math.Min(otop, mint);
                            maxt = Math.Max(otop, maxt);
                        }
                        if (minl == maxl && mint == maxt)
                        {
                            MessageBox.Show("请先改变一个形状的位置");
                        }
                        else
                        {
                            Random rand = new Random();
                            float mn = (maxl - minl) / ((maxt - mint) + (maxl - minl)) * range[1].GroupItems.Count;
                            float n1 = (maxl - minl) / mn;
                            for (int j = 2; j < range[1].GroupItems.Count; j++)
                            {
                                int ran1 = rand.Next((int)minl, (int)(minl + (j % n1) * mn));
                                range[1].GroupItems[j].Left = ran1 - range[1].GroupItems[j].Width;
                            }
                        }
                    }
                }
                else if (count >= 2)
                {
                    float minl = range[1].Left + range[1].Width;
                    float maxl = range[1].Left + range[1].Width;
                    float mint = range[1].Top + range[1].Height;
                    float maxt = range[1].Top + range[1].Height;

                    for (int i = 2; i <= range.Count; i++)
                    {
                        float oleft = range[i].Left + range[i].Width;
                        float otop = range[i].Top + range[i].Height;
                        minl = Math.Min(oleft, minl);
                        maxl = Math.Max(oleft, maxl);
                        mint = Math.Min(otop, mint);
                        maxt = Math.Max(otop, maxt);
                    }
                    if (minl == maxl && mint == maxt)
                    {
                        MessageBox.Show("请先改变一个形状的位置");
                    }
                    else
                    {
                        Random rand = new Random();
                        float mn = (maxl - minl) / ((maxt - mint) + (maxl - minl)) * range.Count;
                        float n1 = (maxl - minl) / mn;
                        for (int j = 2; j < range.Count; j++)
                        {
                            int ran1 = rand.Next((int)minl, (int)(minl + (j % n1) * mn));
                            range[j].Left = ran1 - range[j].Width;
                        }
                    }
                }
            }
        }

        private void button223_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || (sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup) || (sel.ShapeRange.Count == 1 && sel.ShapeRange[1].Type == Office.MsoShapeType.msoGroup && sel.ShapeRange[1].GroupItems.Count < 3) || (sel.ShapeRange[1].Type != Office.MsoShapeType.msoGroup && sel.ShapeRange.Count < 3))
            {
                MessageBox.Show("请选择至少3个不同位置的形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                if (count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        float minl = range[1].GroupItems[1].Left + range[1].GroupItems[1].Width;
                        float maxl = range[1].GroupItems[1].Left + range[1].GroupItems[1].Width;
                        float mint = range[1].GroupItems[1].Top + range[1].GroupItems[1].Height;
                        float maxt = range[1].GroupItems[1].Top + range[1].GroupItems[1].Height;

                        for (int i = 2; i <= range[1].GroupItems.Count; i++)
                        {
                            float oleft = range[1].GroupItems[i].Left + range[1].GroupItems[i].Width;
                            float otop = range[1].GroupItems[i].Top + range[1].GroupItems[i].Height;
                            minl = Math.Min(oleft, minl);
                            maxl = Math.Max(oleft, maxl);
                            mint = Math.Min(otop, mint);
                            maxt = Math.Max(otop, maxt);
                        }
                        if (minl == maxl && mint == maxt)
                        {
                            MessageBox.Show("请先改变一个形状的位置");
                        }
                        else
                        {
                            Random rand = new Random();
                            float hn = (maxt - mint) / ((maxt - mint) + (maxl - minl)) * range[1].GroupItems.Count;
                            float n1 = (maxt - mint) / hn;
                            for (int j = 2; j < range[1].GroupItems.Count; j++)
                            {
                                int ran1 = rand.Next((int)mint, (int)(mint + (j % n1) * hn));
                                range[1].GroupItems[j].Top = ran1 - range[1].GroupItems[j].Height;
                            }
                        }
                    }
                }
                else if (count >= 2)
                {
                    float minl = range[1].Left + range[1].Width;
                    float maxl = range[1].Left + range[1].Width;
                    float mint = range[1].Top + range[1].Height;
                    float maxt = range[1].Top + range[1].Height;

                    for (int i = 2; i <= range.Count; i++)
                    {
                        float oleft = range[i].Left + range[i].Width;
                        float otop = range[i].Top + range[i].Height;
                        minl = Math.Min(oleft, minl);
                        maxl = Math.Max(oleft, maxl);
                        mint = Math.Min(otop, mint);
                        maxt = Math.Max(otop, maxt);
                    }
                    if (minl == maxl && mint == maxt)
                    {
                        MessageBox.Show("请先改变一个形状的位置");
                    }
                    else
                    {
                        Random rand = new Random();
                        float hn = (maxt - mint) / ((maxt - mint) + (maxl - minl)) * range.Count;
                        float n1 = (maxt - mint) / hn;
                        for (int j = 2; j < range.Count; j++)
                        {
                            int ran1 = rand.Next((int)mint, (int)(mint + (j % n1) * hn));
                            range[j].Top = ran1 - range[j].Height;
                        }
                    }
                }
            }
        }

        public void button224_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide=app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                List<string> oname = new List<string>();
                List<string> aname = new List<string>();
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                    foreach (PowerPoint.Shape shape in range)
                    {
                        oname.Add(shape.Name);
                    }
                    foreach (PowerPoint.Shape shape in range[1].ParentGroup.GroupItems)
                    {
                        aname.Add(shape.Name);
                    }
                    for (int i = 0; i < oname.Count(); i++)
                    {
                        if (aname.Contains(oname[i]))
                        {
                            aname.Remove(oname[i]);
                        }
                    }
                }
                else
                {
                    foreach (PowerPoint.Shape shape in range)
                    {
                        oname.Add(shape.Name);
                    }
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        aname.Add(shape.Name);
                    }
                    for (int i = 0; i < oname.Count(); i++)
                    {
                        if (aname.Contains(oname[i]))
                        {
                            aname.Remove(oname[i]);
                        }
                    }
                }
                if (aname.Count() != 0)
                {
                    slide.Shapes.Range(aname.ToArray()).Select();
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.Slides slides = app.ActivePresentation.Slides;
                PowerPoint.SlideRange srange = sel.SlideRange;
                List<int> oslides = new List<int>();
                List<int> aslides = new List<int>();
                foreach (PowerPoint.Slide slide in srange)
                {
                    oslides.Add(slide.SlideIndex);
                }
                foreach (PowerPoint.Slide slide in slides)
                {
                    aslides.Add(slide.SlideIndex);
                }
                for (int i = 0; i < oslides.Count(); i++)
                {
                    if (aslides.Contains(oslides[i]))
                    {
                        aslides.Remove(oslides[i]);
                    }
                }
                if (aslides.Count() != 0)
                {
                    slides.Range(aslides.ToArray()).Select();
                }
            }
            else
            {
                MessageBox.Show("请先选择对象");
            }
        }

        public void button225_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                List<string> aname = new List<string>();
                int n = 0;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                    n = range[1].ZOrderPosition % 2;
                    for (int i = 1; i <= range[1].ParentGroup.GroupItems.Count; i++)
                    {
                        if (range[1].ParentGroup.GroupItems[i].ZOrderPosition % 2 == n)
                        {
                            aname.Add(range[1].ParentGroup.GroupItems[i].Name);
                        }
                    }
                }
                else
                {
                    n = range[1].ZOrderPosition % 2;
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        if (slide.Shapes[i].ZOrderPosition % 2 == n)
                        {
                            aname.Add(slide.Shapes[i].Name);
                        }
                    }
                }
                slide.Shapes.Range(aname.ToArray()).Select();
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.Slides slides = app.ActivePresentation.Slides;
                List<int> aslides = new List<int>();
                int n = sel.SlideRange[1].SlideIndex % 2;
                for (int i = 1; i <= slides.Count; i++)
                {
                    if (slides[i].SlideIndex % 2 == n)
                    {
                        aslides.Add(slides[i].SlideIndex); 
                    }
                }
                slides.Range(aslides.ToArray()).Select();
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                List<string> aname = new List<string>();
                int n = 0;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                    n = range[1].ZOrderPosition % 2;
                    for (int i = 1; i <= range[1].ParentGroup.GroupItems.Count; i++)
                    {
                        if (range[1].ParentGroup.GroupItems[i].ZOrderPosition % 2 == n)
                        {
                            aname.Add(range[1].ParentGroup.GroupItems[i].Name);
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= slide.Shapes.Count; i++)
                    {
                        if (slide.Shapes[i].ZOrderPosition % 2 == 1)
                        {
                            aname.Add(slide.Shapes[i].Name);
                        }
                    }
                }
                slide.Shapes.Range(aname.ToArray()).Select();
            }
        }

        public void button226_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                List<string> aname = new List<string>();
                Random rand = new Random();
                PowerPoint.Shape gp = sel.ShapeRange[1];
                if (gp.Type == Office.MsoShapeType.msoGroup)
                {
                    int gn = sel.ShapeRange[1].GroupItems.Count;
                    if (gn >= 3)
                    {
                        int randn = rand.Next(2, gn + 1);
                        for (int i = 1; i <= randn; i++)
                        {
                            int rand1 = rand.Next(i, gn);
                            if (rand1 <= gn && !aname.Contains(gp.GroupItems[rand1].Name))
                            {
                                aname.Add(gp.GroupItems[rand1].Name);
                            }
                        }
                        slide.Shapes.Range(aname.ToArray()).Select();
                    }
                    else
                    {
                        MessageBox.Show("页面形状太少了，多加一些形状再试试");
                    }
                }
                else
                {
                    if (slide.Shapes.Count >= 3)
                    {
                        int randn = rand.Next(2, slide.Shapes.Count + 1);
                        for (int i = 1; i <= randn; i++)
                        {
                            int rand1 = rand.Next(i, slide.Shapes.Count);
                            if (rand1 <= slide.Shapes.Count && !aname.Contains(slide.Shapes[rand1].Name))
                            {
                                aname.Add(slide.Shapes[rand1].Name);
                            }
                        }
                        slide.Shapes.Range(aname.ToArray()).Select();
                    }
                    else
                    {
                        MessageBox.Show("页面形状太少了，多加一些形状再试试");
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.Slides slides = app.ActivePresentation.Slides;
                if (slides.Count >= 3)
                {
                    List<int> aslides = new List<int>();
                    Random rand = new Random();
                    int randn = rand.Next(2, slides.Count + 1);
                    for (int i = 1; i <= randn; i++)
                    {
                        int rand1 = rand.Next(i, slides.Count);
                        if (rand1 <= slides.Count && !aslides.Contains(slides[rand1].SlideIndex))
                        {
                            aslides.Add(slides[rand1].SlideIndex);
                        }
                    }
                    slides.Range(aslides.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("页面太少了，多加一些页面再试试");
                }
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                if (slide.Shapes.Count >= 3)
                {
                    List<string> aname = new List<string>();
                    Random rand = new Random();
                    int randn = rand.Next(2, slide.Shapes.Count + 1);
                    for (int i = 1; i <= randn; i++)
                    {
                        int rand1 = rand.Next(i, slide.Shapes.Count);
                        if (rand1 <= slide.Shapes.Count && !aname.Contains(slide.Shapes[rand1].Name))
                        {
                            aname.Add(slide.Shapes[rand1].Name);
                        }
                    }
                    slide.Shapes.Range(aname.ToArray()).Select();
                }
                else
                {
                    MessageBox.Show("页面形状太少了，多加一些形状再试试");
                }
            }
        }

        public void button227_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PixMix = Properties.Settings.Default.PicMix;
                            if (PixMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int r0 = color.R;
                                        int g0 = color.G;
                                        int b0 = color.B;
                                        int na = color2.A;
                                        int r1 = color2.R;
                                        int g1 = color2.G;
                                        int b1 = color2.B;
                                        int nhsl0 = Rgb2Hsl(r0, g0, b0);
                                        int nhsl1 = Rgb2Hsl(r1, g1, b1);
                                        int nl = (nhsl1 / 256 / 256) % 256;
                                        int ns = (nhsl0 / 256) % 256;
                                        int nh = nhsl1 % 256;
                                        int nrgb = Hsl2Rgb(nh, ns, nl);
                                        int nr = nrgb % 256;
                                        int ng = (nrgb / 256) % 256;
                                        int nb = (nrgb / 256 / 256) % 256;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int r0 = color.R;
                                        int g0 = color.G;
                                        int b0 = color.B;
                                        int na = color2.A;
                                        int r1 = color2.R;
                                        int g1 = color2.G;
                                        int b1 = color2.B;
                                        int nhsl0 = Rgb2Hsl(r0, g0, b0);
                                        int nhsl1 = Rgb2Hsl(r1, g1, b1);
                                        int nl = (nhsl1 / 256 / 256) % 256;
                                        int ns = (nhsl0 / 256) % 256;
                                        int nh = nhsl1 % 256;
                                        int nrgb = Hsl2Rgb(nh, ns, nl);
                                        int nr = nrgb % 256;
                                        int ng = (nrgb / 256) % 256;
                                        int nb = (nrgb / 256 / 256) % 256;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button228_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PixMix = Properties.Settings.Default.PicMix;
                            if (PixMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int r0 = color.R;
                                        int g0 = color.G;
                                        int b0 = color.B;
                                        int na = color2.A;
                                        int r1 = color2.R;
                                        int g1 = color2.G;
                                        int b1 = color2.B;
                                        int nhsl0 = Rgb2Hsl(r0, g0, b0);
                                        int nhsl1 = Rgb2Hsl(r1, g1, b1);
                                        int nl = (nhsl0 / 256 / 256) % 256;
                                        int ns = (nhsl1 / 256) % 256;
                                        int nh = nhsl1 % 256;
                                        int nrgb = Hsl2Rgb(nh, ns, nl);
                                        int nr = nrgb % 256;
                                        int ng = (nrgb / 256) % 256;
                                        int nb = (nrgb / 256 / 256) % 256;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int r0 = color.R;
                                        int g0 = color.G;
                                        int b0 = color.B;
                                        int na = color2.A;
                                        int r1 = color2.R;
                                        int g1 = color2.G;
                                        int b1 = color2.B;
                                        int nhsl0 = Rgb2Hsl(r0, g0, b0);
                                        int nhsl1 = Rgb2Hsl(r1, g1, b1);
                                        int nl = (nhsl0 / 256 / 256) % 256;
                                        int ns = (nhsl1 / 256) % 256;
                                        int nh = nhsl1 % 256;
                                        int nrgb = Hsl2Rgb(nh, ns, nl);
                                        int nr = nrgb % 256;
                                        int ng = (nrgb / 256) % 256;
                                        int nb = (nrgb / 256 / 256) % 256;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button229_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PixMix = Properties.Settings.Default.PicMix;
                            if (PixMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int na = color2.A;
                                        int nr = color.R;
                                        int ng = color2.G;
                                        int nb = color2.B;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int na = color2.A;
                                        int nr = color.R;
                                        int ng = color2.G;
                                        int nb = color2.B;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button230_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PixMix = Properties.Settings.Default.PicMix;
                            if (PixMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int na = color2.A;
                                        int nr = color2.R;
                                        int ng = color.G;
                                        int nb = color2.B;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int na = color2.A;
                                        int nr = color2.R;
                                        int ng = color.G;
                                        int nb = color2.B;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button231_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            string apath = app.ActivePresentation.Path;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone || sel.ShapeRange.Count < 2)
            {
                MessageBox.Show("至少选择两张图片");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                int count = range.Count;
                Bitmap bmp0 = null;
                PowerPoint.Shape pic0 = null;
                float mw0 = 0; float mh0 = 0;
                for (int p = 1; p <= count; p++)
                {
                    if (p == 1)
                    {
                        pic0 = range[p];
                        if (pic0.Rotation != 0)
                        {
                            mw0 = pic0.Left + pic0.Width / 2;
                            mh0 = pic0.Top + pic0.Height / 2;
                            pic0.Copy();
                            pic0 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic0.Left = mw0 - pic0.Width / 2;
                            pic0.Top = mh0 - pic0.Height / 2;
                        }
                        pic0.Export(apath + @"xshape.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        bmp0 = new Bitmap(apath + @"xshape.png");
                        bmp0 = ResizeImage(bmp0, pic0.Width, pic0.Height);
                    }
                    else
                    {
                        PowerPoint.Shape pic1 = range[p];
                        float mw1 = pic1.Left + pic1.Width / 2;
                        float mh1 = pic1.Top + pic1.Height / 2;
                        if (pic1.Rotation != 0)
                        {
                            pic1.Copy();
                            pic1 = slide.Shapes.PasteSpecial(PowerPoint.PpPasteDataType.ppPastePNG)[1];
                            pic1.Left = mw1 - pic1.Width / 2;
                            pic1.Top = mh1 - pic1.Height / 2;
                            range[p].Delete();
                        }
                        pic1.Export(apath + @"xshape_1.png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                        Bitmap bmp1 = new Bitmap(apath + @"xshape_1.png");
                        bmp1 = ResizeImage(bmp1, pic1.Width, pic1.Height);

                        int[] arr = ImageSize(pic0, pic1, bmp0, bmp1);
                        if (arr[0] == -1)
                        {
                            if (count < 3)
                            {
                                MessageBox.Show("两张照片没有重合部分");
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                        }
                        else
                        {
                            int w = arr[0];
                            int h = arr[1];
                            int x = arr[2];
                            int y = arr[3];
                            int l = arr[4];
                            int t = arr[5];

                            int PixMix = Properties.Settings.Default.PicMix;
                            if (PixMix == 1)
                            {
                                bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int na = color2.A;
                                        int nr = color2.R;
                                        int ng = color2.G;
                                        int nb = color.B;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp2.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp2.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                                bmp2.Dispose();
                            }
                            else
                            {
                                for (int i = 0; i < w; i++)
                                {
                                    for (int j = 0; j < h; j++)
                                    {
                                        Color color = bmp0.GetPixel(x + i, y + j);
                                        Color color2 = bmp1.GetPixel(l + i, t + j);
                                        int na0 = color.A;
                                        int na = color2.A;
                                        int nr = color2.R;
                                        int ng = color2.G;
                                        int nb = color.B;
                                        if (na != 0 && na0 != 0)
                                        {
                                            na = (color2.A * color.A) / 255;
                                            bmp1.SetPixel(l + i, t + j, Color.FromArgb(na, nr, ng, nb));
                                        }
                                    }
                                }
                                bmp1.Save(apath + @"xshape2.png");
                                slide.Shapes.AddPicture(apath + @"xshape2.png", Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, mw1 - pic1.Width / 2, mh1 - pic1.Height / 2, pic1.Width, pic1.Height);
                            }
                            bmp1.Dispose();
                            File.Delete(apath + @"xshape_1.png");
                            File.Delete(apath + @"xshape2.png");
                            pic1.Delete();
                        }
                    }
                }
                bmp0.Dispose();
                File.Delete(apath + @"xshape.png");
            }
        }

        public void button232_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slides slides = app.ActivePresentation.Slides;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                float mw = shape.Left + shape.Width / 2;
                float mh = shape.Top + shape.Height / 2;
                int sid = sel.SlideRange.SlideIndex;
                int dn = 0;
                foreach (PowerPoint.Slide slide in slides)
                {
                    if (slide.SlideIndex != sid)
                    {
                        for (int i = slide.Shapes.Count; i >= 1; i--)
                        {
                            float mw2 = slide.Shapes[i].Left + slide.Shapes[i].Width / 2;
                            float mh2 = slide.Shapes[i].Top + slide.Shapes[i].Height / 2;
                            if ((mw2 >= mw - 10 && mw2 <= mw + 10) && (mh2 >= mh - 10 && mh2 <= mh + 10))
                            {
                                slide.Shapes[i].Delete();
                                dn += 1;
                            }
                        }
                    }
                }
                shape.Delete();
                MessageBox.Show("已删除 "+ dn + "个与所选图形相同位置的图形");
            }
            else
            {
                MessageBox.Show("请选中1个图形");
            }
        }

        public void button234_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            for (int i = 1; i <= slide.Shapes.Count; i++)
            {
                PowerPoint.Shape vshape = slide.Shapes[i];
                if (vshape.Visible == Office.MsoTriState.msoFalse)
                {
                    vshape.Visible = Office.MsoTriState.msoTrue;
                }
            }
        }

        public void button235_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = range.Count; i >= 1; i--)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        range[i].Ungroup();
                    }
                }
            }
            else
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = item.Shapes.Count; i >= 1; i--)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            item.Shapes[i].Ungroup();
                        }
                    }
                }
            }
        }

        public void button236_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("选中至少1个纯色矢量形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            int r = range[i].GroupItems[j].Fill.ForeColor.RGB % 256;
                            int g = (range[i].GroupItems[j].Fill.ForeColor.RGB / 256) % 256;
                            int b = (range[i].GroupItems[j].Fill.ForeColor.RGB / 256 / 256) % 256;
                            string nc = ColorTranslator.ToHtml(Color.FromArgb(255, r, g, b));
                            range[i].GroupItems[j].TextFrame2.DeleteText();
                            range[i].GroupItems[j].TextFrame2.TextRange.Characters.Text = nc;
                        }
                    }
                    else
                    {
                        int r = range[i].Fill.ForeColor.RGB % 256;
                        int g = (range[i].Fill.ForeColor.RGB / 256) % 256;
                        int b = (range[i].Fill.ForeColor.RGB / 256 / 256) % 256;
                        string nc = ColorTranslator.ToHtml(Color.FromArgb(255, r, g, b));
                        range[i].TextFrame2.DeleteText();
                        range[i].TextFrame2.TextRange.Characters.Text = nc;
                    }
                }
            }
        }

        public void button238_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type != PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                MessageBox.Show("本功能可同时选中当前页面中与所选形状相同类型的形状");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                PowerPoint.Shape shape = range[1];
                for (int i = 1; i <= slide.Shapes.Count; i++)
                {
                    PowerPoint.Shape item = slide.Shapes[i];
                    if (item.Name == shape.Name && item.Id != shape.Id)
                    {
                        item.Name = item.Name + "_" + i;
                    }
                }
                List<string> list = new List<string>();
                foreach (PowerPoint.Shape item in slide.Shapes)
                {
                    if (item.Type == Office.MsoShapeType.msoAutoShape)
                    {
                        if (item.AutoShapeType == shape.AutoShapeType)
                        {
                            list.Add(item.Name);
                        }
                    }
                    else if (item.Type == Office.MsoShapeType.msoFreeform)
                    {
                        if (item.Type == Office.MsoShapeType.msoFreeform)
                        {
                            list.Add(item.Name);
                        }
                    }
                }
                slide.Shapes.Range(list.ToArray()).Select();
            }
        }

        public void checkBox1_Click(object sender, RibbonControlEventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.Replace = 1;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Replace = 0;
                Properties.Settings.Default.Save();
            }
        }

        public void checkBox2_Click(object sender, RibbonControlEventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
            }
            else
            {
                checkBox2.Checked = true;
            }
        }

        public void button233_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int num = sel.SlideRange[sel.SlideRange.Count].SlideNumber;
                PowerPoint.CustomLayout layout = app.ActivePresentation.Slides[num].CustomLayout;
                PowerPoint.Slide nslide = app.ActivePresentation.Slides.AddSlide(num + 1, layout);
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        if (shape.Type == Office.MsoShapeType.msoPicture)
                        {
                            shape.Copy();
                            nslide.Shapes.Paste();
                        }
                    }
                }
                if (nslide.Shapes.Count <= 2)
                {
                    nslide.Delete();
                    MessageBox.Show("所选页面中没有图片");
                }
            }
            else
            {
                MessageBox.Show("请选中包含图片的多页幻灯片");
            }
        }

        public void button239_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int num = sel.SlideRange[sel.SlideRange.Count].SlideNumber;
                PowerPoint.CustomLayout layout = app.ActivePresentation.Slides[num].CustomLayout;
                PowerPoint.Slide nslide = app.ActivePresentation.Slides.AddSlide(num + 1, layout);
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        if (shape.Type ==  Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform || shape.Type == Office.MsoShapeType.msoLine || shape.Type == Office.MsoShapeType.msoGroup)
                        {
                            shape.Copy();
                            nslide.Shapes.Paste();
                        }
                    }
                }
                if (nslide.Shapes.Count <= 2)
                {
                    nslide.Delete();
                    MessageBox.Show("所选页面中没有自选图形/自绘图形/线条/组合");
                }
            }
            else
            {
                MessageBox.Show("请选中包含自选图形/自绘图形/线条/组合的多页幻灯片");
            }
        }

        public void button237_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int num = sel.SlideRange[sel.SlideRange.Count].SlideNumber;
                PowerPoint.CustomLayout layout = app.ActivePresentation.Slides[num].CustomLayout;
                PowerPoint.Slide nslide = app.ActivePresentation.Slides.AddSlide(num + 1, layout);
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        if (shape.Type == Office.MsoShapeType.msoTextBox || shape.TextFrame.HasText== Office.MsoTriState.msoTrue || shape.TextFrame2.HasText == Office.MsoTriState.msoTrue)
                        {
                            shape.Copy();
                            nslide.Shapes.Paste();
                        }
                    }
                }
                if (nslide.Shapes.Count <= 2)
                {
                    nslide.Delete();
                    MessageBox.Show("所选页面中没有文本框");
                }
            }
            else
            {
                MessageBox.Show("请选中包含文本框的多页幻灯片");
            }
        }

        public void button240_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int num = sel.SlideRange[sel.SlideRange.Count].SlideNumber;
                PowerPoint.CustomLayout layout = app.ActivePresentation.Slides[num].CustomLayout;
                PowerPoint.Slide nslide = app.ActivePresentation.Slides.AddSlide(num + 1, layout);
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        try
                        {
                            shape.Copy();
                            nslide.Shapes.Paste();
                        }
                        catch
                        {
                            continue;
                        }

                    }
                }
                if (nslide.Shapes.Count <= 2)
                {
                    nslide.Delete();
                    MessageBox.Show("所选页面为空");
                }
            }
        }

        public void button241_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                List<string> list = new List<string>();
                int scount = sel.SlideRange.Count;
                for (int i = 1; i <= scount; i++)
                {
                    PowerPoint.Slide slide = sel.SlideRange[i];
                    int count = slide.Shapes.Count;
                    string[] name = new string[count];
                    for (int j = 1; j <= count; j++)
                    {
                        if (slide.Shapes[j].Type != Office.MsoShapeType.msoPlaceholder)
                        {
                            name[j - 1] = slide.Shapes[j].Name;
                        }
                    }
                    if (name.Count() != 0)
                    {
                        slide.Shapes.Range(name).Group();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中要组合的页面");
            }
        }

        public void button10_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoAutoShape || shape.Type == Office.MsoShapeType.msoFreeform || shape.Type == Office.MsoShapeType.msoLine)
                    {
                        if (shape.Fill.Visible == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                            {
                                shape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = shape.Fill.ForeColor.RGB;
                            }
                            else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                shape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = shape.Fill.GradientStops[1].Color.RGB;
                            }
                            else
                            {
                                n += 1;
                            }
                        }
                        else if (shape.Fill.Visible == Office.MsoTriState.msoFalse && shape.Line.Visible == Office.MsoTriState.msoTrue)
                        {
                            shape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = shape.Line.ForeColor.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.Type == Office.MsoShapeType.msoAutoShape || gshape.Type == Office.MsoShapeType.msoFreeform)
                            {
                                if (gshape.Fill.Visible == Office.MsoTriState.msoTrue)
                                {
                                    if (gshape.Fill.Type == Office.MsoFillType.msoFillSolid)
                                    {
                                        gshape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = gshape.Fill.ForeColor.RGB;
                                    }
                                    else if (gshape.Fill.Type == Office.MsoFillType.msoFillGradient)
                                    {
                                        gshape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = gshape.Fill.GradientStops[1].Color.RGB;
                                    }
                                    else
                                    {
                                        n += 1;
                                    }
                                }
                            }
                            else if (gshape.Fill.Visible == Office.MsoTriState.msoFalse && gshape.Line.Visible == Office.MsoTriState.msoTrue)
                            {
                                gshape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = gshape.Line.ForeColor.RGB;
                            }
                            else
                            {
                                n += 1;
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中纯色填充或纯色线条的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个纯色填充或纯色线条的形状");
            }
        }

        public void button11_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.HasTextFrame == Office.MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame2.HasText == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Fill.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Fill.Visible = Office.MsoTriState.msoTrue;
                            }
                            shape.Fill.ForeColor.RGB = shape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.HasTextFrame == Office.MsoTriState.msoTrue)
                            {
                                if (gshape.TextFrame2.HasText == Office.MsoTriState.msoTrue)
                                {
                                    if (gshape.Fill.Visible == Office.MsoTriState.msoFalse)
                                    {
                                        gshape.Fill.Visible = Office.MsoTriState.msoTrue;
                                    }
                                    gshape.Fill.ForeColor.RGB = gshape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB;
                                }
                                else
                                {
                                    n += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中有纯色文字的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个纯色文字的形状");
            }
        }

        public void button242_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.HasTextFrame == Office.MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame2.HasText == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Line.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Line.Visible = Office.MsoTriState.msoTrue;
                            }
                            shape.Line.ForeColor.RGB = shape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.HasTextFrame == Office.MsoTriState.msoTrue)
                            {
                                if (gshape.TextFrame2.HasText == Office.MsoTriState.msoTrue)
                                {
                                    if (gshape.Line.Visible == Office.MsoTriState.msoFalse)
                                    {
                                        gshape.Line.Visible = Office.MsoTriState.msoTrue;
                                    }
                                    gshape.Line.ForeColor.RGB = gshape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB;
                                }
                                else
                                {
                                    n += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中有纯色文字的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个纯色文字的形状");
            }
        }

        public void button243_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.HasTextFrame == Office.MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame2.HasText == Office.MsoTriState.msoTrue)
                        {
                            if (shape.Shadow.Visible == Office.MsoTriState.msoFalse)
                            {
                                shape.Shadow.Visible = Office.MsoTriState.msoTrue;
                            }
                            shape.Shadow.ForeColor.RGB = shape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB;
                        }
                        else
                        {
                            n += 1;
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.HasTextFrame == Office.MsoTriState.msoTrue)
                            {
                                if (gshape.TextFrame2.HasText == Office.MsoTriState.msoTrue)
                                {
                                    if (gshape.Shadow.Visible == Office.MsoTriState.msoFalse)
                                    {
                                        gshape.Shadow.Visible = Office.MsoTriState.msoTrue;
                                    }
                                    gshape.Shadow.ForeColor.RGB = gshape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB;
                                }
                                else
                                {
                                    n += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中有纯色文字的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个纯色文字的形状");
            }
        }

        public void button244_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                int n = 0;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        int count2 = shape.GroupItems.Count;
                        for (int j = 1; j <= count2; j++)
                        {
                            PowerPoint.Shape gshape = shape.GroupItems[j];
                            if (gshape.Shadow.Visible == Office.MsoTriState.msoTrue)
                            {
                                gshape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = gshape.Fill.ForeColor.RGB;
                            }
                        }
                    }
                    else if (shape.Shadow.Visible == Office.MsoTriState.msoTrue)
                    {
                        shape.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = shape.Shadow.ForeColor.RGB;
                    }
                    else
                    {
                        n += 1;
                    }
                }
                if (n != 0)
                {
                    MessageBox.Show("有" + n + "个图形不符合要求，请选中带阴影的形状");
                }
            }
            else
            {
                MessageBox.Show("请先选中一个带阴影的形状");
            }
        }

        public void button245_Click(object sender, RibbonControlEventArgs e)
        {
            SuperLine SuperLine = null;
            if (SuperLine == null || SuperLine.IsDisposed)
            {
                SuperLine = new SuperLine();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                SuperLine.Show();
                button245.Enabled = false;
            }
        }

        private void button246_Click(object sender, RibbonControlEventArgs e)
        {
            tab2.Visible = false;
            Properties.Settings.Default.tab2 = 0;
            Properties.Settings.Default.Save();
        }

        public void button247_Click(object sender, RibbonControlEventArgs e)
        {
            if (Properties.Settings.Default.tab1 == 1)
            {
                Properties.Settings.Default.tab1 = 0;
                Properties.Settings.Default.Save();
                tab1.Visible = false;
                button247.Label = "显示主卡";
            }
            else
            {
                Properties.Settings.Default.tab1 = 1;
                Properties.Settings.Default.Save();
                tab1.Visible = true;
                button247.Label = "隐藏主卡";
            }
        }

        public void button248_Click(object sender, RibbonControlEventArgs e)
        {
            Table_Color Table_Color = null;
            if (Table_Color == null || Table_Color.IsDisposed)
            {
                Table_Color = new Table_Color();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Table_Color.Show();
                button248.Enabled = false;
            }
        }

        public void button249_Click(object sender, RibbonControlEventArgs e)
        {
            Table_Add Table_Add = null;
            if (Table_Add == null || Table_Add.IsDisposed)
            {
                Table_Add = new Table_Add();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Table_Add.Show();
                button249.Enabled = false;
            }
        }

        public void splitButton8_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            float pw = app.ActivePresentation.PageSetup.SlideWidth;
            float ph = app.ActivePresentation.PageSetup.SlideHeight;
            int row = Properties.Settings.Default.table_addr;
            int column = Properties.Settings.Default.table_addc;
            PowerPoint.Shape table = slide.Shapes.AddTable(row, column, pw / 4, ph / 4, pw / 2, ph / 2);
        }

        public void button251_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                foreach (PowerPoint.Shape shape in range)
                {
                    if (shape.Type == Office.MsoShapeType.msoTable)
                    {
                        float sw = shape.Left + shape.Width;
                        float st = shape.Top;
                        for (int i = 1; i <= shape.Table.Rows.Count; i++)
                        {
                            for (int j = 1; j <= shape.Table.Columns.Count; j++)
                            {
                                if (shape.Table.Rows[i].Cells[j].Selected && shape.Table.Rows[i].Cells[j].Shape.TextFrame.TextRange.Text.Trim() != "")
                                {
                                    string txt = shape.Table.Rows[i].Cells[j].Shape.TextFrame.TextRange.Text.Trim();
                                    PowerPoint.Shape tshape = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, sw + 150 * (j - 1), st + 56 * (i - 1), 150, 56);
                                    tshape.TextFrame.TextRange.Text = txt;
                                }
                            }
                        }
                    }
                    else if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        foreach (PowerPoint.Shape item in shape.GroupItems)
                        {
                            if(item.HasTextFrame== Office.MsoTriState.msoTrue && item.TextFrame.HasText== Office.MsoTriState.msoTrue && item.TextFrame.TextRange.Text != "")
                            {
                                float sw = item.Left + item.Width;
                                float st = item.Top;
                                string txt = item.TextFrame.TextRange.Text.Trim();
                                slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, sw, st, item.Width, item.Height).TextFrame.TextRange.Text = txt;
                            }
                        }
                    }
                    else if(shape.HasTextFrame== Office.MsoTriState.msoTrue && shape.TextFrame.HasText== Office.MsoTriState.msoTrue && shape.TextFrame.TextRange.Text != "")
                    {
                        float sw = shape.Left + shape.Width;
                        float st = shape.Top;
                        string txt = shape.TextFrame.TextRange.Text.Trim();
                        slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, sw, st, shape.Width, shape.Height).TextFrame.TextRange.Text = txt;
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.TextRange tr = sel.TextRange;
                string txt = tr.Text;
                PowerPoint.Shape tb = slide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, -100, 0, 100, 10);
                tb.TextFrame.TextRange.Text = txt;
                tb.TextFrame.AutoSize = PowerPoint.PpAutoSize.ppAutoSizeShapeToFitText;
            }
            else
            {
                MessageBox.Show("请选中表格、单元格或文字");
            }
        }

        public void button252_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Shape shape = sel.ShapeRange[1];
                if (shape.Type == Office.MsoShapeType.msoTable && shape.Table.Rows.Count > 2)
                {
                    List<int> numi = new List<int>();
                    List<int> numj = new List<int>();

                    for (int i = 1; i <= shape.Table.Columns.Count; i++)
                    {
                        for (int j = 1; j <= shape.Table.Rows.Count; j++)
                        {
                            if (shape.Table.Columns[i].Cells[j].Selected)
                            {
                                numi.Add(i);
                                numj.Add(j);
                            }
                        }
                    }

                    numi = numi.Distinct().ToList();
                    numj = numj.Distinct().ToList();
                    int clcnt = numi.Count();
                    int rwcnt = numj.Count();

                    for (int i = 0; i < clcnt; i++)
			        {
                        double value = 0;
                        for (int j = 0; j < rwcnt - 1; j++)
                        {
                            try
                            {
                                value += double.Parse(shape.Table.Columns[numi[i]].Cells[numj[j]].Shape.TextFrame.TextRange.Text.Trim());
                            }
                            catch
                            {
                                continue;
                            } 
                        }
                        shape.Table.Columns[numi[i]].Cells[numj[rwcnt - 1]].Shape.TextFrame.TextRange.Text = value.ToString();
			        }

                }
                else
                {
                    MessageBox.Show("请选中一列或多列表格中的单元格，并且每列底部的最后一个单元格为空");
                }
            }
            else
            {
                MessageBox.Show("请选中一列或多列表格中的单元格，并且每列底部的最后一个单元格为空");
            }
        }

        public void button253_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Shape shape = sel.ShapeRange[1];
                if (shape.Type == Office.MsoShapeType.msoTable && shape.Table.Columns.Count > 2)
                {
                    List<int> numi = new List<int>();
                    List<int> numj = new List<int>();

                    for (int i = 1; i <= shape.Table.Rows.Count; i++)
                    {
                        for (int j = 1; j <= shape.Table.Columns.Count; j++)
                        {
                            if (shape.Table.Rows[i].Cells[j].Selected)
                            {
                                numi.Add(i);
                                numj.Add(j);
                            }
                        }
                    }

                    numi = numi.Distinct().ToList();
                    numj = numj.Distinct().ToList();
                    int rwcnt = numi.Count();
                    int clcnt = numj.Count();

                    for (int i = 0; i < rwcnt; i++)
                    {
                        double value = 0;
                        for (int j = 0; j < clcnt - 1; j++)
                        {
                            try
                            {
                                value += double.Parse(shape.Table.Rows[numi[i]].Cells[numj[j]].Shape.TextFrame.TextRange.Text.Trim());
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        shape.Table.Rows[numi[i]].Cells[numj[clcnt - 1]].Shape.TextFrame.TextRange.Text = value.ToString();
                    }

                }
                else
                {
                    MessageBox.Show("请选中一行或多行表格中的单元格，并且每行右侧的最后一个单元格为空");
                }
            }
            else
            {
                MessageBox.Show("请选中一行或多行表格中的单元格，并且每行右侧的最后一个单元格为空");
            }
        }

        public void button254_Click(object sender, RibbonControlEventArgs e)
        {
            Table_Calculation Table_Calculation = null;
            if (Table_Calculation == null || Table_Calculation.IsDisposed)
            {
                Table_Calculation = new Table_Calculation();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Table_Calculation.Show();
                button254.Enabled = false;
            }
        }

        public void button255_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Shape shape = sel.ShapeRange[1];
                if (shape.Type == Office.MsoShapeType.msoTable)
                {
                    double max = 0;
                    int begin = 0;
                    double value = 0;
                    int maxi = 0;
                    int maxj = 0;
                    for (int i = 1; i <= shape.Table.Columns.Count; i++)
                    {
                        for (int j = 1; j <= shape.Table.Rows.Count; j++)
                        {
                            if (shape.Table.Columns[i].Cells[j].Selected)
                            {
                                if (begin == 0)
                                {
                                    try
                                    {
                                        max = double.Parse(shape.Table.Columns[i].Cells[j].Shape.TextFrame.TextRange.Text.Trim());
                                        maxi = i;
                                        maxj = j;
                                        begin = 1;
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    try 
	                                {	        
		                                value = double.Parse(shape.Table.Columns[i].Cells[j].Shape.TextFrame.TextRange.Text.Trim());
                                        if (value > max)
                                        {
                                            max = value;
                                            maxi = i;
                                            maxj = j;
                                        }
	                                }
	                                catch
	                                {
                                        continue;
	                                }
                                }
                            }
                        }
                    }
                    if (maxi != 0)
                    {
                        shape.Table.Columns[maxi].Cells[maxj].Select();
                    }
                    else
                    {
                        MessageBox.Show("没有找到合适的数值");
                    }
                }
                else
                {
                    MessageBox.Show("请先选中 整个表格 或 指定区域 的单元格");
                }
            }
            else
            {
                MessageBox.Show("请先选中 整个表格 或 指定区域 的单元格");
            }
        }

        public void button256_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Shape shape = sel.ShapeRange[1];
                if (shape.Type == Office.MsoShapeType.msoTable)
                {
                    double min = 0;
                    int begin = 0;
                    double value = 0;
                    int mini = 0;
                    int minj = 0;
                    for (int i = 1; i <= shape.Table.Columns.Count; i++)
                    {
                        for (int j = 1; j <= shape.Table.Rows.Count; j++)
                        {
                            if (shape.Table.Columns[i].Cells[j].Selected)
                            {
                                if (begin == 0)
                                {
                                    try
                                    {
                                        min = double.Parse(shape.Table.Columns[i].Cells[j].Shape.TextFrame.TextRange.Text.Trim());
                                        mini = i;
                                        minj = j;
                                        begin = 1;
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        value = double.Parse(shape.Table.Columns[i].Cells[j].Shape.TextFrame.TextRange.Text.Trim());
                                        if (value < min)
                                        {
                                            min = value;
                                            mini = i;
                                            minj = j;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    if (mini != 0)
                    {
                        shape.Table.Columns[mini].Cells[minj].Select();
                    }
                    else
                    {
                        MessageBox.Show("没有找到合适的数值");
                    }
                }
                else
                {
                    MessageBox.Show("请先选中 整个表格 或 指定区域 的单元格");
                }
            }
            else
            {
                MessageBox.Show("请先选中 整个表格 或 指定区域 的单元格");
            }
        }

        public void button257_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Shape shape = sel.ShapeRange[1];
                if (shape.Type == Office.MsoShapeType.msoTable)
                {
                    List<int> numi = new List<int>();
                    List<int> numj = new List<int>();

                    for (int i = 1; i <= shape.Table.Columns.Count; i++)
                    {
                        for (int j = 1; j <= shape.Table.Rows.Count; j++)
                        {
                            if (shape.Table.Columns[i].Cells[j].Selected)
                            {
                                numi.Add(i);
                                numj.Add(j);
                            }
                        }
                    }

                    numi = numi.Distinct().ToList();
                    numj = numj.Distinct().ToList();
                    int clcnt = numi.Count();
                    int rwcnt = numj.Count();
                    double value = 0;

                    for (int i = 0; i < clcnt; i++)
                    {
                        for (int j = 0; j < rwcnt; j++)
                        {
                            try
                            {
                                value = double.Parse(shape.Table.Columns[numi[i]].Cells[numj[j]].Shape.TextFrame.TextRange.Text.Trim());
                                value = Math.Floor(value);
                                shape.Table.Columns[numi[i]].Cells[numj[j]].Shape.TextFrame.TextRange.Text = value.ToString();
                                value = 0;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选中表格、单元格区域");
                }
            }
            else
            {
                MessageBox.Show("请选中表格、单元格区域");
            }
        }

        public void button258_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Shape shape = sel.ShapeRange[1];
                if (shape.Type == Office.MsoShapeType.msoTable)
                {
                    List<int> numi = new List<int>();
                    List<int> numj = new List<int>();

                    for (int i = 1; i <= shape.Table.Columns.Count; i++)
                    {
                        for (int j = 1; j <= shape.Table.Rows.Count; j++)
                        {
                            if (shape.Table.Columns[i].Cells[j].Selected)
                            {
                                numi.Add(i);
                                numj.Add(j);
                            }
                        }
                    }

                    numi = numi.Distinct().ToList();
                    numj = numj.Distinct().ToList();
                    int clcnt = numi.Count();
                    int rwcnt = numj.Count();
                    double value = 0;

                    for (int i = 0; i < clcnt; i++)
                    {
                        for (int j = 0; j < rwcnt; j++)
                        {
                            try
                            {
                                value = double.Parse(shape.Table.Columns[numi[i]].Cells[numj[j]].Shape.TextFrame.TextRange.Text.Trim());
                                value = Math.Ceiling(value);
                                shape.Table.Columns[numi[i]].Cells[numj[j]].Shape.TextFrame.TextRange.Text = value.ToString();
                                value = 0;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选中表格、单元格区域");
                }
            }
            else
            {
                MessageBox.Show("请选中表格、单元格区域");
            }
        }

        public void button259_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Shape shape = sel.ShapeRange[1];
                if (shape.Type == Office.MsoShapeType.msoTable)
                {
                    List<int> numi = new List<int>();
                    List<int> numj = new List<int>();

                    for (int i = 1; i <= shape.Table.Columns.Count; i++)
                    {
                        for (int j = 1; j <= shape.Table.Rows.Count; j++)
                        {
                            if (shape.Table.Columns[i].Cells[j].Selected)
                            {
                                numi.Add(i);
                                numj.Add(j);
                            }
                        }
                    }

                    numi = numi.Distinct().ToList();
                    numj = numj.Distinct().ToList();
                    int clcnt = numi.Count();
                    int rwcnt = numj.Count();
                    double value = 0;

                    for (int i = 0; i < clcnt; i++)
                    {
                        for (int j = 0; j < rwcnt; j++)
                        {
                            try
                            {
                                value = double.Parse(shape.Table.Columns[numi[i]].Cells[numj[j]].Shape.TextFrame.TextRange.Text.Trim());
                                value = Math.Abs(value);
                                shape.Table.Columns[numi[i]].Cells[numj[j]].Shape.TextFrame.TextRange.Text = value.ToString();
                                value = 0;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选中表格、单元格区域");
                }
            }
            else
            {
                MessageBox.Show("请选中表格、单元格区域");
            }
        }

        public void button260_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选择一个纯色或者渐变形状");
            }
            else
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int scount = range.Count;
                for (int i = 1; i <= scount; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= shape.GroupItems.Count; j++)
                        {
                            PowerPoint.Shape nshape = shape.GroupItems[j];
                            if (nshape.Fill.Type == Office.MsoFillType.msoFillSolid)
                            {
                                int color = nshape.Fill.ForeColor.RGB;
                                float tr = nshape.Fill.Transparency;
                                nshape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1.0f);
                                nshape.Fill.GradientStops[1].Color.RGB = color;
                                nshape.Fill.GradientStops[1].Transparency = tr;
                                nshape.Fill.GradientStops[1].Position = 0.5f;
                                nshape.Fill.GradientStops[2].Color.RGB = color;
                                nshape.Fill.GradientStops[2].Transparency = tr;
                                nshape.Fill.GradientStops[2].Position = 0.5f;
                            }
                            else if (nshape.Fill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                int gcnt = nshape.Fill.GradientStops.Count;
                                float[,] arr = new float[gcnt, 5];
                                float[,] arr2 = new float[gcnt, 5];
                                List<float> max = new List<float>();

                                for (int k = 1; k <= gcnt; k++)
                                {
                                    arr[k - 1, 0] = k;
                                    arr[k - 1, 1] = nshape.Fill.GradientStops[k].Position;
                                    arr[k - 1, 2] = nshape.Fill.GradientStops[k].Color.RGB;
                                    arr[k - 1, 3] = nshape.Fill.GradientStops[k].Transparency;
                                    arr[k - 1, 4] = nshape.Fill.GradientStops[k].Color.Brightness;
                                    max.Add(nshape.Fill.GradientStops[k].Position);
                                }
                                max.Sort();

                                for (int m = 0; m < max.Count; m++)
                                {
                                    for (int n = 0; n < arr.Length / 5; n++)
                                    {
                                        if (arr[n, 1] == max[m])
                                        {
                                            arr2[m, 0] = arr[n, 0];
                                            arr2[m, 1] = arr[n, 1];
                                            arr2[m, 2] = arr[n, 2];
                                            arr2[m, 3] = arr[n, 3];
                                            arr2[m, 4] = arr[n, 4];
                                            break;
                                        }
                                    }
                                }

                                for (int m = 0; m < arr2.Length / 5; m++)
                                {
                                    nshape.Fill.GradientStops[m + 1].Position = arr2[m, 1];
                                    nshape.Fill.GradientStops[m + 1].Color.RGB = (int)arr2[m, 2];
                                    nshape.Fill.GradientStops[m + 1].Transparency = arr2[m, 3];
                                    nshape.Fill.GradientStops[m + 1].Color.Brightness = arr2[m, 4];
                                }

                                int arrcnt = (gcnt - 2) * 2 + 2;
                                float[,] narr = new float[arrcnt, 4];

                                narr[0, 0] = (nshape.Fill.GradientStops[2].Position + nshape.Fill.GradientStops[1].Position) / 2f;
                                narr[0, 1] = (nshape.Fill.GradientStops[1].Color.RGB);
                                narr[0, 2] = (nshape.Fill.GradientStops[1].Transparency);
                                narr[0, 3] = (nshape.Fill.GradientStops[1].Color.Brightness);

                                narr[arrcnt - 1, 0] = (nshape.Fill.GradientStops[gcnt].Position + nshape.Fill.GradientStops[gcnt - 1].Position) / 2f;
                                narr[arrcnt - 1, 1] = (nshape.Fill.GradientStops[gcnt].Color.RGB);
                                narr[arrcnt - 1, 2] = (nshape.Fill.GradientStops[gcnt].Transparency);
                                narr[arrcnt - 1, 3] = (nshape.Fill.GradientStops[gcnt].Color.Brightness);

                                if (arrcnt > 2)
                                {
                                    for (int k = 2; k < gcnt; k++)
                                    {
                                        narr[k * 2 - 3, 0] = (nshape.Fill.GradientStops[k].Position + nshape.Fill.GradientStops[k - 1].Position) / 2f;
                                        narr[k * 2 - 3, 1] = (nshape.Fill.GradientStops[k].Color.RGB);
                                        narr[k * 2 - 3, 2] = (nshape.Fill.GradientStops[k].Transparency);
                                        narr[k * 2 - 3, 3] = (nshape.Fill.GradientStops[k].Color.Brightness);

                                        narr[(k - 1) * 2, 0] = (nshape.Fill.GradientStops[k + 1].Position + nshape.Fill.GradientStops[k].Position) / 2f;
                                        narr[(k - 1) * 2, 1] = (nshape.Fill.GradientStops[k].Color.RGB);
                                        narr[(k - 1) * 2, 2] = (nshape.Fill.GradientStops[k].Transparency);
                                        narr[(k - 1) * 2, 3] = (nshape.Fill.GradientStops[k].Color.Brightness);
                                    }
                                }

                                for (int k = 0; k < arrcnt; k++)
                                {
                                    nshape.Fill.GradientStops.Insert2((int)narr[k, 1], narr[k, 0], narr[k, 2], -1, narr[k, 3]);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (shape.Fill.Type == Office.MsoFillType.msoFillSolid)
                        {
                            int color = shape.Fill.ForeColor.RGB;
                            float tr = shape.Fill.Transparency;
                            shape.Fill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1.0f);
                            shape.Fill.GradientStops[1].Color.RGB = color;
                            shape.Fill.GradientStops[1].Transparency = tr;
                            shape.Fill.GradientStops[1].Position = 0.5f;
                            shape.Fill.GradientStops[2].Color.RGB = color;
                            shape.Fill.GradientStops[2].Transparency = tr;
                            shape.Fill.GradientStops[2].Position = 0.5f;
                        }
                        else if (shape.Fill.Type == Office.MsoFillType.msoFillGradient)
                        {
                            int gcnt = shape.Fill.GradientStops.Count;
                            float[,] arr = new float[gcnt, 5];
                            float[,] arr2 = new float[gcnt, 5];
                            List<float> max = new List<float>();

                            for (int k = 1; k <= gcnt; k++)
                            {
                                arr[k - 1, 0] = k;
                                arr[k - 1, 1] = shape.Fill.GradientStops[k].Position;
                                arr[k - 1, 2] = shape.Fill.GradientStops[k].Color.RGB;
                                arr[k - 1, 3] = shape.Fill.GradientStops[k].Transparency;
                                arr[k - 1, 4] = shape.Fill.GradientStops[k].Color.Brightness;
                                max.Add(shape.Fill.GradientStops[k].Position);
                            }
                            max.Sort();

                            for (int j = 0; j < max.Count; j++)
                            {
                                for (int k = 0; k < arr.Length / 5; k++)
                                {
                                    if (arr[k, 1] == max[j])
                                    {
                                        arr2[j, 0] = arr[k, 0];
                                        arr2[j, 1] = arr[k, 1];
                                        arr2[j, 2] = arr[k, 2];
                                        arr2[j, 3] = arr[k, 3];
                                        arr2[j, 4] = arr[k, 4];
                                        break;
                                    }
                                }
                            }

                            for (int j = 0; j < arr2.Length / 5; j++)
                            {
                                shape.Fill.GradientStops[j + 1].Position = arr2[j, 1];
                                shape.Fill.GradientStops[j + 1].Color.RGB = (int)arr2[j, 2];
                                shape.Fill.GradientStops[j + 1].Transparency = arr2[j, 3];
                                shape.Fill.GradientStops[j + 1].Color.Brightness = arr2[j, 4];
                            }

                            int arrcnt = (gcnt - 2) * 2 + 2;
                            float[,] narr = new float[arrcnt, 4];

                            narr[0, 0] = (shape.Fill.GradientStops[2].Position + shape.Fill.GradientStops[1].Position) / 2f;
                            narr[0, 1] = (shape.Fill.GradientStops[1].Color.RGB);
                            narr[0, 2] = (shape.Fill.GradientStops[1].Transparency);
                            narr[0, 3] = (shape.Fill.GradientStops[1].Color.Brightness);

                            narr[arrcnt - 1, 0] = (shape.Fill.GradientStops[gcnt].Position + shape.Fill.GradientStops[gcnt - 1].Position) / 2f;
                            narr[arrcnt - 1, 1] = (shape.Fill.GradientStops[gcnt].Color.RGB);
                            narr[arrcnt - 1, 2] = (shape.Fill.GradientStops[gcnt].Transparency);
                            narr[arrcnt - 1, 3] = (shape.Fill.GradientStops[gcnt].Color.Brightness);

                            if (arrcnt > 2)
                            {
                                for (int k = 2; k < gcnt; k++)
                                {
                                    narr[k * 2 - 3, 0] = (shape.Fill.GradientStops[k].Position + shape.Fill.GradientStops[k - 1].Position) / 2f;
                                    narr[k * 2 - 3, 1] = (shape.Fill.GradientStops[k].Color.RGB);
                                    narr[k * 2 - 3, 2] = (shape.Fill.GradientStops[k].Transparency);
                                    narr[k * 2 - 3, 3] = (shape.Fill.GradientStops[k].Color.Brightness);

                                    narr[(k - 1) * 2, 0] = (shape.Fill.GradientStops[k + 1].Position + shape.Fill.GradientStops[k].Position) / 2f;
                                    narr[(k - 1) * 2, 1] = (shape.Fill.GradientStops[k].Color.RGB);
                                    narr[(k - 1) * 2, 2] = (shape.Fill.GradientStops[k].Transparency);
                                    narr[(k - 1) * 2, 3] = (shape.Fill.GradientStops[k].Color.Brightness);
                                }
                            }
		                    
                            for (int k = 0; k < arrcnt; k++)
                            {
                                shape.Fill.GradientStops.Insert2((int)narr[k, 1], narr[k, 0], narr[k, 2], -1, narr[k, 3]);
                            }
                        }
                    }
                }
            }
        }

        public void button261_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中要替换的图形，本功能会将所有页面中与所选图形名称相同的图形进行替换");
            }
            else
            {
                PowerPoint.Slides slides = app.ActivePresentation.Slides;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                string name = range[1].Name;
                if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    openFileDialog1.Filter = "JPG图片|*.jpg|JPEG图片|*.jpeg|PNG图片|*.png|BMP图片|*.bmp|GIF图片|*.gif|EMF图片|*.emf|WMF图片|*.wmf";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.RestoreDirectory = true;
                    openFileDialog1.AddExtension = true;
                    openFileDialog1.Multiselect = true;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string[] files = openFileDialog1.FileNames.ToArray();
                        int n = 0;
                        if (files.Count() == 1)
                        {
                            Bitmap bmp = new Bitmap(files[0]);
                            foreach (PowerPoint.Slide slide in slides)
                            {
                                List<PowerPoint.Shape> oshapes = new List<PowerPoint.Shape>();
                                foreach (PowerPoint.Shape oshape in slide.Shapes)
                                {
                                    if (oshape.Name == name)
                                    {
                                        oshapes.Add(oshape);
                                    }
                                }
                                for (int i = 0; i < oshapes.Count(); i++)
                                {
                                    PowerPoint.Shape pic = null;
                                    if (checkBox2.Checked)
                                    {
                                        pic = slide.Shapes.AddPicture(files[0], Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, oshapes[i].Left, oshapes[i].Top, oshapes[i].Width, oshapes[i].Height);
                                    }
                                    else
                                    {
                                        pic = slide.Shapes.AddPicture(files[0], Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, oshapes[i].Left + oshapes[i].Width / 2 - bmp.Width / 2, oshapes[i].Top + oshapes[i].Height / 2 - bmp.Height / 2, bmp.Width, bmp.Height);
                                    }
                                    pic.Name = name;
                                    if (checkBox1.Checked)
                                    {
                                        try
                                        {
                                            oshapes[i].PickUp();
                                            pic.Apply();
                                        }
                                        catch{}
                                        try
                                        {
                                            oshapes[i].PickupAnimation();
                                            pic.ApplyAnimation();
                                        }
                                        catch{}
                                    }
                                    pic.Rotation = oshapes[i].Rotation;
                                    oshapes[i].Delete();
                                    n += 1;
                                }
                            }
                            bmp.Dispose();
                        }
                        else
                        {
                            List<Bitmap> bmps = new List<Bitmap>();
                            for (int i = 0; i < files.Count(); i++)
                            {
                                bmps.Add(new Bitmap(files[i]));
                            }
                            int n2 = 0;
                            foreach (PowerPoint.Slide slide in slides)
                            {
                                List<PowerPoint.Shape> oshapes = new List<PowerPoint.Shape>();
                                foreach (PowerPoint.Shape oshape in slide.Shapes)
                                {
                                    if (oshape.Name == name)
                                    {
                                        oshapes.Add(oshape);
                                    }
                                }

                                for (int i = 0; i < oshapes.Count(); i++)
                                {
                                    if (n2 + i < files.Count())
                                    {
                                        PowerPoint.Shape pic = null;
                                        if (checkBox2.Checked)
                                        {
                                            pic = slide.Shapes.AddPicture(files[n2 + i], Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, oshapes[i].Left, oshapes[i].Top, oshapes[i].Width, oshapes[i].Height);
                                        }
                                        else
                                        {
                                            pic = slide.Shapes.AddPicture(files[n2 + i], Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue, oshapes[i].Left + oshapes[i].Width / 2 - bmps[n2 + i].Width / 2, oshapes[i].Top + oshapes[i].Height / 2 - bmps[n2 + i].Height / 2, bmps[n2 + i].Width, bmps[n2 + i].Height);
                                        }
                                        pic.Name = name;
                                        if (checkBox1.Checked)
                                        {
                                            try
                                            {
                                                oshapes[i].PickUp();
                                                pic.Apply();
                                            }
                                            catch { }
                                            try
                                            {
                                                oshapes[i].PickupAnimation();
                                                pic.ApplyAnimation();
                                            }
                                            catch { }
                                        }
                                        pic.Rotation = oshapes[i].Rotation;
                                        oshapes[i].Delete();
                                        n += 1;
                                    }
                                }      
                            }
                        }
                        MessageBox.Show("替换了 " + n + " 个图形");
                    }
                }
                else
                {
                    MessageBox.Show("请先选中要替换的图形");
                }
            }
        }

        public void button262_Click(object sender, RibbonControlEventArgs e)
        {
            Table_Borders Table_Borders = null;
            if (Table_Borders == null || Table_Borders.IsDisposed)
            {
                Table_Borders = new Table_Borders();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Table_Borders.Show();
                Globals.Ribbons.Ribbon1.button262.Enabled = false;
            }
        }

        string chartpath;
        public void button178_Click(object sender, RibbonControlEventArgs e)
        {
            chartpath = Properties.Settings.Default.ChartPath;
            if (chartpath == "")
            {
                RegistryKey rpath = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Slibe\OneKeyTools", false);
                Properties.Settings.Default.ChartPath = rpath.GetValue("Path", "").ToString();
                Properties.Settings.Default.Save();
            }
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "图表模板(*.crtx)|*.crtx";
            sf.InitialDirectory = chartpath;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string name0 = System.IO.Path.GetDirectoryName(sf.FileName) + @"\";
                string name1 = System.IO.Path.GetFileNameWithoutExtension(sf.FileName);
                string name = name0 + name1;

                PowerPoint.Selection sel = app.ActiveWindow.Selection;
                if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
                {
                    PowerPoint.ShapeRange range = sel.ShapeRange;
                    if (sel.HasChildShapeRange)
                    {
                        range = sel.ChildShapeRange;
                    }
                    int n = 0;
                    for (int i = 1; i <= range.Count; i++)
                    {
                        PowerPoint.Shape shape = range[i];
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            if (n == 0)
                            {
                                shape.Chart.SaveChartTemplate(name);
                                n += 1;
                            }
                            else
                            {
                                shape.Chart.SaveChartTemplate(name + "_" + n);
                                n += 1;
                            }
                        }
                    }
                    MessageBox.Show("已保存 " + n + " 个图表模板");
                }
                else
                {
                    MessageBox.Show("请选中图表");
                }
            }
 
        }

        public void button263_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                chartpath = Properties.Settings.Default.ChartPath;
                OpenFileDialog of = new OpenFileDialog();
                of.Multiselect = false;
                of.InitialDirectory = chartpath;
                of.Filter = "图表模板(*.crtx)|*.crtx";

                if(of.ShowDialog() == DialogResult.OK)
                {
                    PowerPoint.ShapeRange range = sel.ShapeRange;
                    if (sel.HasChildShapeRange)
                    {
                        range = sel.ChildShapeRange;
                    }
                    string name = of.FileName;
                    int n = 0;
                    for (int i = 1; i <= range.Count; i++)
                    {
                        if (range[i].Type == Office.MsoShapeType.msoChart)
                        {
                            range[i].Chart.ApplyChartTemplate(name);
                            n += 1;
                        }
                    }
                    MessageBox.Show("已给 " + n + " 个图表套用了模板");
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                chartpath = Properties.Settings.Default.ChartPath;
                OpenFileDialog of = new OpenFileDialog();
                of.Multiselect = false;
                of.InitialDirectory = chartpath;
                of.Filter = "图表模板(*.crtx)|*.crtx";

                if (of.ShowDialog() == DialogResult.OK)
                {
                    string name = of.FileName;
                    PowerPoint.SlideRange slides = sel.SlideRange;
                    int n1 = 0; int n2 = 0;
                    foreach (PowerPoint.Slide slide in slides)
                    {
                        foreach (PowerPoint.Shape shape in slide.Shapes)
                        {
                            if (shape.Type == Office.MsoShapeType.msoChart)
                            {
                                shape.Chart.ApplyChartTemplate(name);
                                n1 += 1;
                            }
                        }
                        n2 += 1;
                    }
                    MessageBox.Show("已给 " + n2 + " 页中的" + n1 + " 个图表套用了模板");
                }
            }
            else
            {
                MessageBox.Show("请先选用要套用模板的图表或包含图表的页面");
            }
        }

        public void button264_Click(object sender, RibbonControlEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.ChartPath = fb.SelectedPath;
                Properties.Settings.Default.Save();
                MessageBox.Show("图表库默认目录设置成功");
            }
        }

        public void button265_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                OpenFileDialog of = new OpenFileDialog();
                of.Multiselect = true;
                of.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003 工作簿(*.xls)|*.xls";

                if (of.ShowDialog() == DialogResult.OK)
                {
                    string[] names = of.FileNames;
                    float sw = app.ActivePresentation.PageSetup.SlideWidth / 2;
                    float sh = app.ActivePresentation.PageSetup.SlideHeight / 2;
                    Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;

                    PowerPoint.Shape shape = null;
                    Excel.Application eapp = null;
                    Excel.Workbook wb = null;
                    Excel.Worksheet ws = null;
                    Excel.ChartObjects crts = null;
                    Excel.ChartObject crt = null;

                    int n = 0;
                    int ns = 0;

                    for (int i = 0; i < names.Count(); i++)
                    {
                        eapp = new Excel.Application();
                        eapp.Workbooks.Open(names[i], Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        wb = eapp.Workbooks[1];
                        for (int j = 1; j <= wb.Worksheets.Count; j++)
                        {
                            ws = wb.Worksheets[j];
                            crts = (Excel.ChartObjects)ws.ChartObjects(Type.Missing);
                            for (int k = 1; k <= crts.Count; k++)
                            {
                                try
                                {
                                    crt = crts.Item(k);
                                    crt.Select();
                                    crt.Copy();
                                    shape = slide.Shapes.Paste()[1];
                                    shape.Width = sw;
                                    shape.Height = sh;
                                    shape.Left = sw / 2 + ns;
                                    shape.Top = sh / 2 + ns;
                                    n += 1;
                                    ns += 20;
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                        wb.Close(false, Type.Missing, Type.Missing);
                        eapp.Quit();
                    }
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)crt);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)crts);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)ws);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)wb);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)eapp);
                    System.GC.Collect();
                    wb = null;
                    eapp = null;
                    app.Activate();
                    app.ActiveWindow.Selection.Unselect();
                    cursor = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("已导入 " + n + " 个图表");
                }   
            }
            catch
            {
                MessageBox.Show("出现错误，请先选中一张幻灯片；若反复出现本提示，请尝试只打开一个Excel工作簿");
            }   
        }

        public void button266_Click(object sender, RibbonControlEventArgs e)
        {
            if (Clipboard.ContainsData("Text"))
            {
                Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                float sw = app.ActivePresentation.PageSetup.SlideWidth;
                float sh = app.ActivePresentation.PageSetup.SlideHeight;
                PowerPoint.Shape chart = slide.Shapes.AddChart(Office.XlChartType.xlColumnClustered, sw / 4, sh / 4, sw / 2, sh / 2);
                PowerPoint.ChartData cd = chart.Chart.ChartData;
                cd.Activate();
                Excel.Workbook wb = cd.Workbook;
                Excel.Worksheet ws = wb.Worksheets[1];
                Excel.Range range = ws.get_Range("A1", "D5");
                range.ClearContents();
                ws.Range["A1"].Select();
                try
                {
                    ws.Paste();
                    int nr = 1; int nc = 1;
                    for (int i = 1; i <= nr; i++)
                    {
                        Excel.Range range2 = ws.Cells[1, nr];
                        if ((string)range2.Text == "")
                        {
                            nr -= 1;
                            break;
                        }
                        else
                        {
                            nr += 1;
                        }
                    }
                    for (int i = 1; i <= nc; i++)
                    {
                        Excel.Range range3 = ws.Cells[nc, 1];
                        if ((string)range3.Text == "")
                        {
                            nc -= 1;
                            break;
                        }
                        else
                        {
                            nc += 1;
                        }
                    }
                    Excel.Range range4 = ws.Cells[nc, nr];
                    string col = (string)range4.get_Address(nc, nr);
                    chart.Chart.SetSourceData("Sheet1!$A$1:" + col, Excel.XlRowCol.xlColumns);
                    wb.Close();
                    chart.Select();
                    cursor = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("导入成功，可根据实际需求修改图表类型");
                }
                catch
                {
                    wb.Close();
                    chart.Delete();
                    MessageBox.Show("出现未知错误！ 请重新复制源数据，Ctrl+V粘贴到PPT中，然后使用OK插件“图格互转”菜单中的“表格转图表”功能", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
            else
            {
                MessageBox.Show("请先复制EXCEL中的数据");
            }
        }

        public void button267_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int n1 = 0; int n2 = 0;
                foreach (PowerPoint.Shape shape in range)
                {
                    if (shape.Type == Office.MsoShapeType.msoChart)
                    {
                        n1 += 1;
                        if (shape.Chart.ChartData.IsLinked)
                        {
                            shape.Chart.ChartData.BreakLink();
                            n2 += 1;
                        }
                    }
                }
                MessageBox.Show("共发现 "+ n1+" 个图表，成功断开 "+ n2 + " 个图表的链接，修改图表将不会影响外部EXCEL中的数据或图表");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int n1 = 0; int n2 = 0;
                PowerPoint.SlideRange srange = sel.SlideRange;
                foreach (PowerPoint.Slide slide in srange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            n1 += 1;
                            if (shape.Chart.ChartData.IsLinked)
                            {
                                shape.Chart.ChartData.BreakLink();
                                n2 += 1;
                            }
                        }
                    }
                }
                MessageBox.Show("共发现 " + n1 + " 个图表，成功断开 " + n2 + " 个图表的链接，修改图表将不会影响外部EXCEL中的数据或图表");
            }
            else
            {
                MessageBox.Show("请先选中要断开外部链接的图表或包含图表的幻灯片");
            }
        }

        private void button268_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            float sw = app.ActivePresentation.PageSetup.SlideWidth / 2;
            float sh = app.ActivePresentation.PageSetup.SlideHeight / 2;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                int n1 = 0; int n2 = 0;
                int nr = 1; int nc = 1;
                PowerPoint.ChartData cd = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                PowerPoint.Shape table = null;

                foreach (PowerPoint.Shape shape in range)
                {
                    if (shape.Type == Office.MsoShapeType.msoChart)
                    {
                        n1 += 1;
                        cd = shape.Chart.ChartData;
                        cd.Activate();
                        wb = cd.Workbook;
                        ws = wb.Worksheets[1];

                        for (int i = 1; i <= nr; i++)
                        {
                            Excel.Range range2 = ws.Cells[1, nr];
                            if ((string)range2.Text == "")
                            {
                                nr -= 1;
                                break;
                            }
                            else
                            {
                                nr += 1;
                            }
                        }
                        for (int i = 1; i <= nc; i++)
                        {
                            Excel.Range range3 = ws.Cells[nc, 1];
                            if ((string)range3.Text == "")
                            {
                                nc -= 1;
                                break;
                            }
                            else
                            {
                                nc += 1;
                            }
                        }

                        Excel.Range erange = ws.Cells[nc, nr];
                        string col = (string)erange.get_Address(nc, nr);
                        erange = ws.get_Range("$A$1", col);
                        erange.Copy();

                        table = slide.Shapes.Paste()[1];
                        wb.Close();

                        table.Width = sw;
                        table.Height = sh;
                        table.Left = sw * 2;
                        table.Top = 0;
                        n2 += 1;
                        app.Activate();
                    }
                }
                cursor = System.Windows.Forms.Cursors.Default;
                MessageBox.Show("共发现 " + n1 + " 个图表，成功将 " + n2 + " 个图表转换为表格");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                PowerPoint.SlideRange srange = sel.SlideRange;
                int n1 = 0; int n2 = 0;
                int nr = 1; int nc = 1;
                PowerPoint.ChartData cd = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                PowerPoint.Shape table = null;

                Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                foreach (PowerPoint.Slide slide in srange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            n1 += 1;
                            cd = shape.Chart.ChartData;
                            cd.Activate();
                            wb = cd.Workbook;
                            ws = wb.Worksheets[1];

                            for (int i = 1; i <= nr; i++)
                            {
                                Excel.Range range2 = ws.Cells[1, nr];
                                if ((string)range2.Text == "")
                                {
                                    nr -= 1;
                                    break;
                                }
                                else
                                {
                                    nr += 1;
                                }
                            }
                            for (int i = 1; i <= nc; i++)
                            {
                                Excel.Range range3 = ws.Cells[nc, 1];
                                if ((string)range3.Text == "")
                                {
                                    nc -= 1;
                                    break;
                                }
                                else
                                {
                                    nc += 1;
                                }
                            }

                            Excel.Range erange = ws.Cells[nc, nr];
                            string col = (string)erange.get_Address(nc, nr);
                            erange = ws.get_Range("$A$1", col);
                            erange.Copy();

                            table = slide.Shapes.Paste()[1];
                            wb.Close();

                            table.Width = sw;
                            table.Height = sh;
                            table.Left = sw * 2;
                            table.Top = 0;
                            n2 += 1;
                            app.Activate();
                        }
                    }
                }
                cursor = System.Windows.Forms.Cursors.Default;
                MessageBox.Show("共发现 " + n1 + " 个图表，成功将 " + n2 + " 个图表转换为表格");
            }
            else
            {
                MessageBox.Show("请选中图表或包含图表的幻灯片");
            }
        }

        private void button269_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                float sw = app.ActivePresentation.PageSetup.SlideWidth / 2;
                float sh = app.ActivePresentation.PageSetup.SlideHeight / 2;

                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                PowerPoint.Shape chart = null;
                PowerPoint.ChartData cd = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                Excel.Range erange = null;
                int n = 0; int nr = 0; int nc = 0;

                foreach (PowerPoint.Shape shape in range)
                {
                    if (shape.Type == Office.MsoShapeType.msoTable)
                    {
                        n += 1;
                        shape.Copy();
                        nr = shape.Table.Rows.Count;
                        nc = shape.Table.Columns.Count;

                        try { wb.Close(); }
                        catch { }
                        chart = slide.Shapes.AddChart(Office.XlChartType.xlColumnClustered, sw * 2, 0, sw, sh);
                        cd = chart.Chart.ChartData;
                        cd.Activate();
                        wb = cd.Workbook;
                        ws = wb.Worksheets[1];
                        erange = ws.get_Range("A1", "D5");
                        erange.ClearContents();
                        ws.Range["A1"].Select();
                        ws.Paste();
                        
                        Excel.Range range4 = ws.Cells[nr, nc];
                        string col = (string)range4.get_Address(nr, nc);
                        erange = ws.get_Range("$A$1", col);
                        erange.ClearFormats();
                        chart.Chart.SetSourceData("Sheet1!$A$1:" + col, Excel.XlRowCol.xlColumns);
                        wb.Close();
                        app.Activate();
                    }
                }
                cursor = System.Windows.Forms.Cursors.Default;
                MessageBox.Show("已将 " + n + " 个表格转换为图表");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                float sw = app.ActivePresentation.PageSetup.SlideWidth / 2;
                float sh = app.ActivePresentation.PageSetup.SlideHeight / 2;
                Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                PowerPoint.Shape chart = null;
                PowerPoint.ChartData cd = null;
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;
                Excel.Range erange = null;
                int n = 0; int nr = 0; int nc = 0;

                PowerPoint.SlideRange srange = sel.SlideRange;
                foreach (PowerPoint.Slide slide in srange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        if (shape.Type == Office.MsoShapeType.msoTable)
                        {
                            n += 1;
                            shape.Copy();
                            nr = shape.Table.Rows.Count;
                            nc = shape.Table.Columns.Count;

                            try { wb.Close(); }
                            catch { }
                            chart = slide.Shapes.AddChart(Office.XlChartType.xlColumnClustered, sw * 2, 0, sw, sh);
                            cd = chart.Chart.ChartData;
                            cd.Activate();
                            wb = cd.Workbook;
                            ws = wb.Worksheets[1];
                            erange = ws.get_Range("A1", "D5");
                            erange.ClearContents();
                            ws.Range["A1"].Select();
                            ws.Paste();
                        
                            Excel.Range range4 = ws.Cells[nr, nc];
                            string col = (string)range4.get_Address(nr, nc);
                            erange = ws.get_Range("$A$1", col);
                            erange.ClearFormats();
                            chart.Chart.SetSourceData("Sheet1!$A$1:" + col, Excel.XlRowCol.xlColumns);
                            wb.Close();
                            app.Activate();
                        }
                    }
                }
                cursor = System.Windows.Forms.Cursors.Default;
                MessageBox.Show("已将 " + n + " 个表格转换为图表");
            }
            else
            {
                MessageBox.Show("请选中表格或包含表格的幻灯片");
            }
        }

        private void button270_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("可将所选的图表导出为PNG；选中多页幻灯片时，只导出其中的图表为PNG");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的元素\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoChart)
                    {
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                        int k = dir.GetFiles().Length + (i - i + 1);
                        string shname = name + "_" + k;
                        shape.Export(cPath + shname + ".png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                    } 
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int n = 0;
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的元素\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }

                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        PowerPoint.Shape shape = item.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                            int k = dir.GetFiles().Length + (i - i + 1);
                            string shname = name + "_" + k;
                            shape.Export(cPath + shname + ".png", PowerPoint.PpShapeFormat.ppShapeFormatPNG);
                            n += 1;
                        }
                    }
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
                MessageBox.Show("已将 " + n + "个图表导出为PNG图片");
            }
        }

        private void button271_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("可将所选的图表导出为JPG；选中多页幻灯片时，只导出其中的图表为JPG");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的元素\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    if (shape.Type == Office.MsoShapeType.msoChart)
                    {
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                        int k = dir.GetFiles().Length + (i - i + 1);
                        string shname = name + "_" + k;
                        shape.Export(cPath + shname + ".jpg", PowerPoint.PpShapeFormat.ppShapeFormatJPG);
                    }
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int n = 0;
                string name = app.ActivePresentation.Name;
                if (name.Contains(".pptx"))
                {
                    name = name.Replace(".pptx", "");
                }
                if (name.Contains(".ppt"))
                {
                    name = name.Replace(".ppt", "");
                }
                string cPath = app.ActivePresentation.Path + @"\" + name + @" 的元素\";
                if (!Directory.Exists(cPath))
                {
                    Directory.CreateDirectory(cPath);
                }

                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        PowerPoint.Shape shape = item.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(cPath);
                            int k = dir.GetFiles().Length + (i - i + 1);
                            string shname = name + "_" + k;
                            shape.Export(cPath + shname + ".jpg", PowerPoint.PpShapeFormat.ppShapeFormatJPG);
                        }
                    }
                }
                System.Diagnostics.Process.Start("Explorer.exe", cPath);
                MessageBox.Show("已将 " + n + "个图表导出为JPG图片");
            }
        }

        private void button272_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                string chartpath = app.ActivePresentation.Path;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = chartpath;
                sf.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003 工作簿(*.xls)|*.xls";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string name = sf.FileName;
                    Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                    Excel.Application eapp = new Excel.Application();
                    eapp.Workbooks.Add(Type.Missing);
                    eapp.Workbooks[1].SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);

                    Excel.Workbook wb = null;
                    Excel.Worksheet ws = null;
                    PowerPoint.ChartData cd = null;
                    Excel.Worksheet nws = null;
                    Excel.Range erange = null;
                    Excel.Range orange = null;
                    Excel.ChartObject cob = null;
                    string col = "";
                    int n = 0;

                    PowerPoint.ShapeRange range = sel.ShapeRange;
                    if (sel.HasChildShapeRange)
                    {
                        range = sel.ChildShapeRange;
                    }
                    foreach (PowerPoint.Shape shape in range)
                    {
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            try
                            { wb.Close(); }
                            catch { }
                            cd = shape.Chart.ChartData;
                            cd.Activate();
                            wb = cd.Workbook;
                            ws = wb.Worksheets[1];
                            ws.Name = "Chart_" + (n + 1).ToString();
                            orange = ws.Cells[ws.Rows.Count, ws.Columns.Count];
                            col = (string)orange.get_Address(ws.Rows.Count, ws.Columns.Count);
                            erange = ws.get_Range("A1", col);
                            erange.Copy();
                            nws = eapp.Workbooks[1].Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
                            nws.Paste();
                            nws.Name = "Chart_" + (n + 1).ToString();
                            shape.Copy();
                            nws.Paste();
                            cob = nws.ChartObjects(1);
                            cob.Width = cob.Width / 2;
                            cob.Height = cob.Height / 2;
                            cob.Left = 50;
                            cob.Top = 50;
                            eapp.Workbooks[1].Save();
                            wb.Close();
                            n += 1;
                            app.Activate();
                        }
                    }
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)cd);
                    cd = null;
                    cursor = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("已成功导出 " + n + " 个图表到Excel中"); 
                    eapp.Visible = true;
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                string chartpath = app.ActivePresentation.Path;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = chartpath;
                sf.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003 工作簿(*.xls)|*.xls";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string name = sf.FileName;
                    Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                    Excel.Application eapp = new Excel.Application();
                    eapp.Workbooks.Add(Type.Missing);
                    eapp.Workbooks[1].SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);

                    Excel.Workbook wb = null;
                    Excel.Worksheet ws = null;
                    PowerPoint.ChartData cd = null;
                    Excel.Worksheet nws = null;
                    Excel.Range erange = null;
                    Excel.Range orange = null;
                    Excel.ChartObject cob = null;
                    string col = "";
                    int n = 0;

                    PowerPoint.SlideRange srange = sel.SlideRange;
                    foreach (PowerPoint.Slide slide in srange)
                    {
                        foreach (PowerPoint.Shape shape in slide.Shapes)
                        {
                            if (shape.Type == Office.MsoShapeType.msoChart)
                            {
                                try
                                { wb.Close(); }
                                catch { }
                                cd = shape.Chart.ChartData;
                                cd.Activate();
                                wb = cd.Workbook;
                                ws = wb.Worksheets[1];
                                ws.Name = "Chart_" + (n + 1).ToString();
                                orange = ws.Cells[ws.Rows.Count, ws.Columns.Count];
                                col = (string)orange.get_Address(ws.Rows.Count, ws.Columns.Count);
                                erange = ws.get_Range("A1", col);
                                erange.Copy();
                                nws = eapp.Workbooks[1].Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
                                nws.Paste();
                                nws.Name = "Chart_" + (n + 1).ToString();
                                shape.Copy();
                                nws.Paste();
                                cob = nws.ChartObjects(1);
                                cob.Width = cob.Width / 2;
                                cob.Height = cob.Height / 2;
                                cob.Left = 50;
                                cob.Top = 50;
                                eapp.Workbooks[1].Save();
                                wb.Close();
                                n += 1;
                                app.Activate();
                            }
                        }
                    }
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)cd);
                    cd = null;
                    cursor = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("已成功导出 " + n + " 个图表到Excel中");
                    eapp.Visible = true;
                }
            }
        }

        public void button273_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int num = sel.SlideRange[sel.SlideRange.Count].SlideNumber;
                PowerPoint.CustomLayout layout = app.ActivePresentation.Slides[num].CustomLayout;
                PowerPoint.Slide nslide = app.ActivePresentation.Slides.AddSlide(num + 1, layout);
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            shape.Copy();
                            nslide.Shapes.Paste();
                        }
                    }
                }
                if (nslide.Shapes.Count <= 2)
                {
                    nslide.Delete();
                    MessageBox.Show("所选页面中没有图表");
                }
            }
            else
            {
                MessageBox.Show("请选中包含图表的多页幻灯片");
            }
        }

        public void button274_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int num = sel.SlideRange[sel.SlideRange.Count].SlideNumber;
                PowerPoint.CustomLayout layout = app.ActivePresentation.Slides[num].CustomLayout;
                PowerPoint.Slide nslide = app.ActivePresentation.Slides.AddSlide(num + 1, layout);
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    foreach (PowerPoint.Shape shape in slide.Shapes)
                    {
                        if (shape.Type == Office.MsoShapeType.msoTable)
                        {
                            shape.Copy();
                            nslide.Shapes.Paste();
                        }
                    }
                }
                if (nslide.Shapes.Count <= 2)
                {
                    nslide.Delete();
                    MessageBox.Show("所选页面中没有表格");
                }
            }
            else
            {
                MessageBox.Show("请选中包含表格的多页幻灯片");
            }
        }

        public void button275_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int n = 0;
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    for (int i = slide.Shapes.Count; i >= 1; i--)
                    {
                        PowerPoint.Shape shape = slide.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            shape.Delete();
                            n += 1;
                        }
                    }
                }
                MessageBox.Show("已删除" + n + "个图表");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                int n = 0;
                foreach (PowerPoint.Shape shape in sel.ShapeRange)
                {
                    if (shape.Type == Office.MsoShapeType.msoChart)
                    {
                        shape.Delete();
                        n += 1;
                    }
                }
                MessageBox.Show("已删除" + n + "个图表");
            }
            else
            {
                MessageBox.Show("请选中图表或包含图表的幻灯片");
            }
        }

        public void button276_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                int n = 0;
                foreach (PowerPoint.Slide slide in sel.SlideRange)
                {
                    for (int i = slide.Shapes.Count; i >= 1; i--)
                    {
                        PowerPoint.Shape shape = slide.Shapes[i];
                        if (shape.Type == Office.MsoShapeType.msoTable)
                        {
                            shape.Delete();
                            n += 1;
                        }
                    }
                }
                MessageBox.Show("已删除" + n + "个表格");
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                int n = 0;
                foreach (PowerPoint.Shape shape in sel.ShapeRange)
                {
                    if (shape.Type == Office.MsoShapeType.msoTable)
                    {
                        shape.Delete();
                        n += 1;
                    }
                }
                MessageBox.Show("已删除" + n + "个表格");
            }
            else
            {
                MessageBox.Show("请选中表格或包含表格的幻灯片");
            }
        }

        private void button277_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                string chartpath = app.ActivePresentation.Path;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = chartpath;
                sf.Filter = "Word 文档(*.docx)|*.docx|Word 97-2003 文档(*.doc)|*.doc";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string name = sf.FileName;
                    Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                    Word.Application wapp = new Word.Application();
                    wapp.Documents.Add(Type.Missing,Type.Missing,Type.Missing,Type.Missing);
                    wapp.Documents[1].SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);

                    int n = 0;
                    Word.Paragraph para = null;

                    PowerPoint.ShapeRange range = sel.ShapeRange;
                    if (sel.HasChildShapeRange)
                    {
                        range = sel.ChildShapeRange;
                    }
                    foreach (PowerPoint.Shape shape in range)
                    {
                        if (shape.Type == Office.MsoShapeType.msoChart)
                        {
                            shape.Copy();
                            para = wapp.Documents[1].Content.Paragraphs.Add(Type.Missing);
                            try
                            {
                                para.Range.Paste();
                                para.Range.InsertParagraphAfter();
                                para.Range.InsertParagraphAfter();
                                wapp.Documents[1].Save();
                                n += 1;
                                app.Activate();
                            }
                            catch
                            {
                                app.Activate();
                                continue;
                            }
                        }
                    }
                    cursor = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("已成功导出 " + n + " 个图表到Word中");
                    wapp.Visible = true;
                    wapp.Activate();
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                string chartpath = app.ActivePresentation.Path;
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = chartpath;
                sf.Filter = "Word 文档(*.docx)|*.docx|Word 97-2003 文档(*.doc)|*.doc";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string name = sf.FileName;
                    Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;
                    Word.Application wapp = new Word.Application();
                    wapp.Documents.Add(Type.Missing,Type.Missing,Type.Missing,Type.Missing);
                    wapp.Documents[1].SaveAs(name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);

                    int n = 0;
                    Word.Paragraph para = null;

                    PowerPoint.SlideRange srange = sel.SlideRange;
                    foreach (PowerPoint.Slide slide in srange)
                    {
                        foreach (PowerPoint.Shape shape in slide.Shapes)
                        {
                            if (shape.Type == Office.MsoShapeType.msoChart)
                            {
                                shape.Copy();
                                para = wapp.Documents[1].Content.Paragraphs.Add(Type.Missing);
                                try
                                {
                                    para.Range.Paste();
                                    para.Range.InsertParagraphAfter();
                                    para.Range.InsertParagraphAfter();
                                    wapp.Documents[1].Save();
                                    n += 1;
                                    app.Activate();
                                }
                                catch
                                {
                                    app.Activate();
                                    continue;
                                }
                            }
                        }
                    }
                    cursor = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("已成功导出 " + n + " 个图表到Word中");
                    wapp.Visible = true;
                    wapp.Activate();
                }
            }
        }

        public void button278_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                for (int i = 1; i <= range.Count; i++)
                {
                    if (range[i].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[i].GroupItems.Count; j++)
                        {
                            if (range[i].GroupItems[j].Type == Office.MsoShapeType.msoTable)
                            {
                                foreach (PowerPoint.Row row in range[i].GroupItems[j].Table.Rows)
                                {
                                    for (int k = 1; k <= range[i].GroupItems[j].Table.Columns.Count; k++)
                                    {
                                        row.Cells[k].Shape.TextFrame.DeleteText();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (range[i].Type == Office.MsoShapeType.msoTable)
                        {
                            foreach (PowerPoint.Row row in range[i].Table.Rows)
                            {
                                for (int k = 1; k <= range[i].Table.Columns.Count; k++)
                                {
                                    row.Cells[k].Shape.TextFrame.DeleteText();
                                }
                            }
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides)
            {
                foreach (PowerPoint.Slide item in sel.SlideRange)
                {
                    for (int i = 1; i <= item.Shapes.Count; i++)
                    {
                        if (item.Shapes[i].Type == Office.MsoShapeType.msoGroup)
                        {
                            for (int j = 1; j <= item.Shapes[i].GroupItems.Count; j++)
                            {
                                if (item.Shapes[i].GroupItems[j].Type == Office.MsoShapeType.msoTable)
                                {
                                    foreach (PowerPoint.Row row in item.Shapes[i].GroupItems[j].Table.Rows)
                                    {
                                        for (int k = 1; k <= item.Shapes[i].GroupItems[j].Table.Columns.Count; k++)
                                        {
                                            row.Cells[k].Shape.TextFrame.DeleteText();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (item.Shapes[i].Type == Office.MsoShapeType.msoTable)
                            {
                                foreach (PowerPoint.Row row in item.Shapes[i].Table.Rows)
                                {
                                    for (int k = 1; k <= item.Shapes[i].Table.Columns.Count; k++)
                                    {
                                        row.Cells[k].Shape.TextFrame.DeleteText();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中表格或包含表格的幻灯片");
            }
        }

        public void button279_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                OpenFileDialog of = new OpenFileDialog();
                of.Multiselect = true;
                of.Filter = "Word 文档(*.docx)|*.docx|Word 97-2003 文档(*.doc)|*.doc";

                if (of.ShowDialog() == DialogResult.OK)
                {
                    string[] names = of.FileNames;
                    float sw = app.ActivePresentation.PageSetup.SlideWidth / 2;
                    float sh = app.ActivePresentation.PageSetup.SlideHeight / 2;
                    Cursor cursor = System.Windows.Forms.Cursors.WaitCursor;

                    PowerPoint.Shape shape = null;
                    Word._Application wapp = new Word.Application();
                    Word._Document dm = null;
                    Word.InlineShape wishape = null;
                    Word.Shape wshape = null;

                    int ns = 0;
                    int n = 0;

                    for (int i = 0; i < names.Count(); i++)
                    {
                        wapp.Documents.Open(names[i], Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        dm = wapp.Documents[1];
                        for (int j = 1; j <= dm.InlineShapes.Count; j += 0)
                        {
                            j = 1;
                            wishape = dm.InlineShapes[j];
                            if (wishape.Type == Word.WdInlineShapeType.wdInlineShapeChart)
                            {
                                wshape = wishape.ConvertToShape();
                                wshape.Chart.Copy();
                                shape = slide.Shapes.Paste()[1];
                                shape.Width = sw;
                                shape.Height = sh;
                                shape.Left = sw / 2 + ns;
                                shape.Top = sh / 2 + ns;
                                n += 1;
                                ns += 20;
                            }
                        }
                    }
                    dm.Close(false, Type.Missing, Type.Missing);
                    wapp.Quit(false, Type.Missing, Type.Missing);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)dm);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject((object)wapp);
                    System.GC.Collect();
                    dm = null;
                    wapp = null;
                    app.Activate();
                    cursor = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("已导入 " + n + " 个图表");
                }
            }
            catch
            {
                MessageBox.Show("出现错误，请先选中一张幻灯片重试；若反复出现本提示，请尝试只打开一个word文档");
            }
        }

        public void button280_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    PowerPoint.TextRange tr = shape.TextFrame.TextRange;
                    int tcnt = tr.Text.Count();
                    if (tcnt != 0)
                    {
                        for (int j = 1; j < tcnt; j ++)
                        {
                            if (tr.Characters(j).Text != " ")
                            {
                                tr.Characters(j).Text = tr.Characters(j).Text + " ";
                                tcnt += 1;
                            }           
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int tcnt = tr.Text.Count();
                if (tcnt != 0)
                {
                    for (int j = 1; j < tcnt; j ++)
                    {
                        if (tr.Characters(j).Text != " ")
                        {
                            tr.Characters(j).Text = tr.Characters(j).Text + " ";
                            tcnt += 1;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中文本框或文本");
            }
        }

        public void button281_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                int count = range.Count;
                for (int i = 1; i <= count; i++)
                {
                    PowerPoint.Shape shape = range[i];
                    PowerPoint.TextRange tr = shape.TextFrame.TextRange;
                    int tcnt = tr.Text.Count();
                    int n = 0;
                    if (tcnt != 0)
                    {
                        for (int j = 2 + n; j < tcnt; j++)
                        {
                            if (tr.Characters(j).Text == " " && tr.Characters(j - 1).Text != " ")
                            {
                                tr.Characters(j).Delete();
                                n += 1;
                            }
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.TextRange tr = sel.TextRange;
                int tcnt = tr.Text.Count();
                if (tcnt != 0)
                {
                    int n = 0;
                    for (int j = 2 + n; j < tcnt; j++)
                    {
                        if (tr.Characters(j).Text == " " && tr.Characters(j - 1).Text != " ")
                        {
                            tr.Characters(j).Delete();
                            n += 1;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中文本框或文本");
            }
        }

        public void splitButton9_Click(object sender, RibbonControlEventArgs e)
        {
            Text_ToTable Text_ToTable = null;
            if (Text_ToTable == null || Text_ToTable.IsDisposed)
            {
                Text_ToTable = new Text_ToTable();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Text_ToTable.Show();
                Globals.Ribbons.Ribbon1.splitButton9.Enabled = false;
            }
        }

        public void button250_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionSlides || sel.Type == PowerPoint.PpSelectionType.ppSelectionNone)
            {
                MessageBox.Show("请选中文本框");
            }
            else
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                float pw = app.ActivePresentation.PageSetup.SlideWidth;
                float ph = app.ActivePresentation.PageSetup.SlideHeight;
                if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
                {
                    PowerPoint.ShapeRange range = sel.ShapeRange;
                    if (sel.HasChildShapeRange)
                    {
                        range = sel.ChildShapeRange;
                    }
                    for (int i = 1; i <= range.Count; i++)
                    {
                        PowerPoint.Shape shape = range[i];
                        string txt = shape.TextEffect.Text;
                        String[] arr = txt.Split(char.Parse("\r"), char.Parse("\v")).ToArray();
                        int tcount = arr.Count();
                        int max = 1;
                        for (int j = 0; j < tcount; j++)
                        {
                            String[] arr2 = arr[j].Split(char.Parse(" ")).ToArray();
                            max = Math.Max(max, arr2.Count());
                        }
                        PowerPoint.Shape table = slide.Shapes.AddTable(tcount, max, pw / 4, ph / 4, pw / 2, ph / 2);
                        table.Table.FirstRow = false;
                        for (int j = 0; j < tcount; j++)
                        {
                            String[] arr2 = arr[j].Split(char.Parse(" ")).ToArray();
                            for (int k = 0; k < arr2.Count(); k++)
                            {
                                table.Table.Columns[k + 1].Cells[j + 1].Shape.TextFrame.TextRange.Text = arr2[k];
                            }
                        }
                    }
                }
                else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
                {
                    string txt = sel.TextRange.Text;
                    String[] arr = txt.Split(char.Parse("\r"), char.Parse("\v")).ToArray();
                    int tcount = arr.Count();
                    int max = 1;
                    for (int j = 0; j < tcount; j++)
                    {
                        String[] arr2 = arr[j].Split(char.Parse(" ")).ToArray();
                        max = Math.Max(max, arr2.Count());
                    }
                    PowerPoint.Shape table = slide.Shapes.AddTable(tcount, max, pw / 4, ph / 4, pw / 2, ph / 2);
                    table.Table.FirstRow = false;
                    for (int j = 0; j < tcount; j++)
                    {
                        String[] arr2 = arr[j].Split(char.Parse(" ")).ToArray();
                        for (int k = 0; k < arr2.Count(); k++)
                        {
                            table.Table.Columns[k + 1].Cells[j + 1].Shape.TextFrame.TextRange.Text = arr2[k];
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选中文本框或文本");
                }
            }
        }

        public void button282_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.CustomLayouts cLayouts = app.ActivePresentation.SlideMaster.CustomLayouts;
            int n = 0;
            for (int i = cLayouts.Count; i >= 1; i--)
            {
                try
                {
                    app.ActivePresentation.SlideMaster.CustomLayouts[i].Delete();
                    n += 1;
                }
                catch
                {
                    continue;
                }
            }
            MessageBox.Show("已删除 " + n + "张未使用版式");
        }

        public void button283_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Slides slides = app.ActivePresentation.Slides;
            foreach (PowerPoint.Slide slide in slides)
            {
                foreach (PowerPoint.Shape shape in slide.Shapes)
                {
                    if (shape.HasTextFrame == Office.MsoTriState.msoTrue)
                    {
                        if (shape.TextFrame.HasText == Office.MsoTriState.msoFalse && shape.TextFrame2.HasText == Office.MsoTriState.msoFalse)
                        {
                            shape.TextFrame.DeleteText();
                        }
                    }
                }
            }
        }

        public void button284_Click(object sender, RibbonControlEventArgs e)
        {
            Audio_Split Audio1 = null;
            if (Audio1 == null || Audio1.IsDisposed)
            {
                Audio1 = new Audio_Split();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Audio1.Show();
                Globals.Ribbons.Ribbon1.button284.Enabled = false;
            }  
        }

        public void button285_Click(object sender, RibbonControlEventArgs e)
        {
            Audio_TTS Audio_TTS = null;
            if (Audio_TTS == null || Audio_TTS.IsDisposed)
            {
                Audio_TTS = new Audio_TTS();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Audio_TTS.Show();
                Globals.Ribbons.Ribbon1.button285.Enabled = false;
            }
        }

        public void button286_Click(object sender, RibbonControlEventArgs e)
        {
            Audio_Record Audio_Record = null;
            if (Audio_Record == null || Audio_Record.IsDisposed)
            {
                Audio_Record = new Audio_Record();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Audio_Record.Show();
                Globals.Ribbons.Ribbon1.button286.Enabled = false;
            }
        }

        private void button287_Click(object sender, RibbonControlEventArgs e)
        {
            OK_Command OK_Command = null;
            if (OK_Command == null || OK_Command.IsDisposed)
            {
                OK_Command = new OK_Command();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                OK_Command.Show();
                Globals.Ribbons.Ribbon1.button287.Enabled = false;
            }
        }

        public void button288_Click(object sender, RibbonControlEventArgs e)
        {
            Audio_Mix Audio_Mix = null;
            if (Audio_Mix == null || Audio_Mix.IsDisposed)
            {
                Audio_Mix = new Audio_Mix();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Audio_Mix.Show();
                Globals.Ribbons.Ribbon1.button288.Enabled = false;
            }  
        }

        public void button289_Click(object sender, RibbonControlEventArgs e)
        {
            Audio_Convert Audio_Convert = null;
            if (Audio_Convert == null || Audio_Convert.IsDisposed)
            {
                Audio_Convert = new Audio_Convert();
                IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                NativeWindow win = NativeWindow.FromHandle(handle);
                Audio_Convert.Show();
                Globals.Ribbons.Ribbon1.button289.Enabled = false;
            }
        }

        public void button290_Click(object sender, RibbonControlEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            of.Filter = "PowerPoint 演示文稿(*.pptx)|*.pptx|PowerPoint 97-2003 演示文稿(*.ppt)|*.ppt";

            if (of.ShowDialog() == DialogResult.OK)
            {
                List<string> Files = of.FileNames.ToList();
                PowerPoint.Application pptapp = new PowerPoint.Application();
                PowerPoint.Slides oslides = app.ActivePresentation.Slides;
                string oname = app.ActivePresentation.FullName;
                PowerPoint.Presentation pptpr;

                int n = 0;
                for (int i = 0; i < Files.Count; i++)
                {
                    if (Files[i] != oname && !Files[i].Contains("~$"))
                    {
                        pptpr = pptapp.Presentations.Open(Files[i], Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse);
                        foreach (PowerPoint.Slide oslide in pptpr.Slides)
                        {
                            oslide.Copy();
                            PowerPoint.Slide nslide = oslides.Paste()[1];
                            nslide.Design = oslide.Design;
                            nslide.ColorScheme = oslide.ColorScheme;
                            nslide.ApplyTheme(Files[i]);
                            PowerPoint.FillFormat oFill = oslide.Background.Fill;
                            PowerPoint.FillFormat nFill = nslide.Background.Fill;

                            if (oslide.DisplayMasterShapes == Office.MsoTriState.msoTrue)
                            {
                                nslide.DisplayMasterShapes = Office.MsoTriState.msoTrue;
                            }

                            if (oslide.FollowMasterBackground == Office.MsoTriState.msoFalse)
                            {
                                nslide.FollowMasterBackground = Office.MsoTriState.msoFalse;
                                if (oFill.Type == Office.MsoFillType.msoFillSolid)
                                {
                                    nFill.ForeColor.RGB = oFill.ForeColor.RGB;
                                    nFill.Transparency = oFill.Transparency;
                                    nFill.BackColor = oFill.BackColor;
                                }
                                else if (oFill.Type == Office.MsoFillType.msoFillGradient)
                                {
                                    if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientDiagonalDown)
                                    {
                                        nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalDown, 1, 1);
                                        nFill.GradientAngle = oFill.GradientAngle;
                                    }
                                    else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientDiagonalUp)
                                    {
                                        nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalUp, 1, 1);
                                        nFill.GradientAngle = oFill.GradientAngle;
                                    }
                                    else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromCenter)
                                    {
                                        nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromCenter, 1, 1);
                                    }
                                    else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromCorner)
                                    {
                                        nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromCorner, 1, 1);
                                    }
                                    else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientHorizontal)
                                    {
                                        nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1);
                                        nFill.GradientAngle = oFill.GradientAngle;
                                    }
                                    else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientVertical)
                                    {
                                        nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientVertical, 1, 1);
                                        nFill.GradientAngle = oFill.GradientAngle;
                                    }
                                    else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromTitle)
                                    {
                                        nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromTitle, 1, 1);
                                    }
                                    else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientMixed)
                                    {
                                        nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalDown, 1, 1);
                                    }

                                    int count = nFill.GradientStops.Count;

                                    if (count != 2)
                                    {
                                        for (int j = 1; j <= count; j++)
                                        {
                                            nFill.GradientStops.Insert(j - j, 0, 0, -1);
                                        }
                                    }
                                    for (int j = 1; j <= count; j++)
                                    {
                                        nFill.GradientStops[j].Color.RGB = oFill.GradientStops[j].Color.RGB;
                                        nFill.GradientStops[j].Position = oFill.GradientStops[j].Position;
                                        nFill.GradientStops[j].Transparency = oFill.GradientStops[j].Transparency;
                                        nFill.GradientStops[j].Color.Brightness = oFill.GradientStops[j].Color.Brightness;
                                    }
                                }
                                else if (oFill.Type == Office.MsoFillType.msoFillPicture)
                                {
                                    if (oslide.Shapes.Count != 0)
                                    {
                                        foreach (PowerPoint.Shape item in oslide.Shapes)
                                        {
                                            item.Visible = Office.MsoTriState.msoFalse;
                                        }
                                        oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                        foreach (PowerPoint.Shape item in oslide.Shapes)
                                        {
                                            item.Visible = Office.MsoTriState.msoTrue;
                                        }
                                    }
                                    else
                                    {
                                        oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                    }
                                    nFill.UserPicture(pptpr.Path + oslide.Name + ".jpg");
                                    File.Delete(pptpr.Path + oslide.Name + ".jpg");
                                }
                                else if (oFill.Type == Office.MsoFillType.msoFillPatterned)
                                {
                                    nFill.Patterned(oFill.Pattern);
                                }
                                else if (oFill.Type == Office.MsoFillType.msoFillTextured)
                                {

                                    if (oFill.TextureType == Office.MsoTextureType.msoTexturePreset)
                                    {
                                        nFill.PresetTextured(oFill.PresetTexture);
                                    }
                                    else if (oFill.TextureType == Office.MsoTextureType.msoTextureUserDefined || oFill.TextureType == Office.MsoTextureType.msoTextureTypeMixed)
                                    {
                                        if (oslide.Shapes.Count != 0)
                                        {
                                            foreach (PowerPoint.Shape item in oslide.Shapes)
                                            {
                                                item.Visible = Office.MsoTriState.msoFalse;
                                            }
                                            oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                            foreach (PowerPoint.Shape item in oslide.Shapes)
                                            {
                                                item.Visible = Office.MsoTriState.msoTrue;
                                            }
                                        }
                                        else
                                        {
                                            oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                        }
                                        nFill.UserTextured(pptpr.Path + oslide.Name + ".jpg");
                                        File.Delete(pptpr.Path + oslide.Name + ".jpg");
                                    }

                                    if (oFill.TextureTile == Office.MsoTriState.msoTrue)
                                    {
                                        nFill.TextureTile = Office.MsoTriState.msoTrue;
                                    }
                                    else
                                    {
                                        nFill.TextureTile = Office.MsoTriState.msoFalse;
                                    }

                                    nFill.TextureAlignment = oFill.TextureAlignment;
                                    nFill.TextureHorizontalScale = oFill.TextureHorizontalScale;
                                    nFill.TextureVerticalScale = oFill.TextureVerticalScale;
                                    nFill.TextureOffsetX = oFill.TextureOffsetX;
                                    nFill.TextureOffsetY = oFill.TextureOffsetY;
                                }
                            }
                        }
                        pptpr.Close();
                        n += 1;
                    }

                }
                if (n == 0)
                {
                    MessageBox.Show("没有找到PPT文档");
                }
                else
                {
                    MessageBox.Show("已合并 " + n + " 个PPT文档");
                }
            }
        }

        public void button291_Click(object sender, RibbonControlEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            of.Filter = "PowerPoint 演示文稿(*.pptx)|*.pptx|PowerPoint 97-2003 演示文稿(*.ppt)|*.ppt";

            if (of.ShowDialog() == DialogResult.OK)
            {
                List<string> Files = of.FileNames.ToList();

                PowerPoint.Slides oslides = app.ActivePresentation.Slides;
                string oname = app.ActivePresentation.FullName;
                int n = 0;
                for (int i = 0; i < Files.Count; i++)
                {
                    if (Files[i] != oname && !Files[i].Contains("~$"))
                    {
                        oslides.InsertFromFile(Files[i], oslides.Count, 1, -1);
                        n += 1;
                    }
                }
                if (n == 0)
                {
                    MessageBox.Show("没有找到PPT文档");
                }
                else
                {
                    MessageBox.Show("已合并 " + n + " 个PPT文档");
                }
            }
        }

        public void button292_Click(object sender, RibbonControlEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            of.Filter = "PowerPoint 演示文稿(*.pptx)|*.pptx|PowerPoint 97-2003 演示文稿(*.ppt)|*.ppt";

            if (of.ShowDialog() == DialogResult.OK)
            {
                List<string> Files = of.FileNames.ToList();
                
                PowerPoint.Application pptapp = new PowerPoint.Application();
                PowerPoint.Slides oslides = app.ActivePresentation.Slides;
                string oname = app.ActivePresentation.FullName;
                PowerPoint.Presentation pptpr;

                int n = 0;
                for (int i = 0; i < Files.Count; i++)
                {
                    if (Files[i] != oname && !Files[i].Contains("~$"))
                    {
                        pptpr = pptapp.Presentations.Open(Files[i], Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse);
                        PowerPoint.Slide oslide = pptpr.Slides[1];
                        oslide.Copy();
                        PowerPoint.Slide nslide = oslides.Paste()[1];
                        nslide.Design = oslide.Design;
                        nslide.ColorScheme = oslide.ColorScheme;
                        nslide.ApplyTheme(Files[i]);
                        PowerPoint.FillFormat oFill = oslide.Background.Fill;
                        PowerPoint.FillFormat nFill = nslide.Background.Fill;

                        if (oslide.DisplayMasterShapes == Office.MsoTriState.msoTrue)
                        {
                            nslide.DisplayMasterShapes = Office.MsoTriState.msoTrue;
                        }

                        if (oslide.FollowMasterBackground == Office.MsoTriState.msoFalse)
                        {
                            nslide.FollowMasterBackground = Office.MsoTriState.msoFalse;
                            if (oFill.Type == Office.MsoFillType.msoFillSolid)
                            {
                                nFill.ForeColor.RGB = oFill.ForeColor.RGB;
                                nFill.Transparency = oFill.Transparency;
                                nFill.BackColor = oFill.BackColor;
                            }
                            else if (oFill.Type == Office.MsoFillType.msoFillGradient)
                            {
                                if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientDiagonalDown)
                                {
                                    nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalDown, 1, 1);
                                    nFill.GradientAngle = oFill.GradientAngle;
                                }
                                else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientDiagonalUp)
                                {
                                    nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalUp, 1, 1);
                                    nFill.GradientAngle = oFill.GradientAngle;
                                }
                                else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromCenter)
                                {
                                    nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromCenter, 1, 1);
                                }
                                else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromCorner)
                                {
                                    nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromCorner, 1, 1);
                                }
                                else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientHorizontal)
                                {
                                    nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1);
                                    nFill.GradientAngle = oFill.GradientAngle;
                                }
                                else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientVertical)
                                {
                                    nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientVertical, 1, 1);
                                    nFill.GradientAngle = oFill.GradientAngle;
                                }
                                else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromTitle)
                                {
                                    nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromTitle, 1, 1);
                                }
                                else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientMixed)
                                {
                                    nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalDown, 1, 1);
                                }

                                int count = nFill.GradientStops.Count;

                                if (count != 2)
                                {
                                    for (int j = 1; j <= count; j++)
                                    {
                                        nFill.GradientStops.Insert(j - j, 0, 0, -1);
                                    }
                                }
                                for (int j = 1; j <= count; j++)
                                {
                                    nFill.GradientStops[j].Color.RGB = oFill.GradientStops[j].Color.RGB;
                                    nFill.GradientStops[j].Position = oFill.GradientStops[j].Position;
                                    nFill.GradientStops[j].Transparency = oFill.GradientStops[j].Transparency;
                                    nFill.GradientStops[j].Color.Brightness = oFill.GradientStops[j].Color.Brightness;
                                }
                            }
                            else if (oFill.Type == Office.MsoFillType.msoFillPicture)
                            {
                                if (oslide.Shapes.Count != 0)
                                {
                                    foreach (PowerPoint.Shape item in oslide.Shapes)
                                    {
                                        item.Visible = Office.MsoTriState.msoFalse;
                                    }
                                    oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                    foreach (PowerPoint.Shape item in oslide.Shapes)
                                    {
                                        item.Visible = Office.MsoTriState.msoTrue;
                                    }
                                }
                                else
                                {
                                    oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                }
                                nFill.UserPicture(pptpr.Path + oslide.Name + ".jpg");
                                File.Delete(pptpr.Path + oslide.Name + ".jpg");
                            }
                            else if (oFill.Type == Office.MsoFillType.msoFillPatterned)
                            {
                                nFill.Patterned(oFill.Pattern);
                            }
                            else if (oFill.Type == Office.MsoFillType.msoFillTextured)
                            {

                                if (oFill.TextureType == Office.MsoTextureType.msoTexturePreset)
                                {
                                    nFill.PresetTextured(oFill.PresetTexture);
                                }
                                else if (oFill.TextureType == Office.MsoTextureType.msoTextureUserDefined || oFill.TextureType == Office.MsoTextureType.msoTextureTypeMixed)
                                {
                                    if (oslide.Shapes.Count != 0)
                                    {
                                        foreach (PowerPoint.Shape item in oslide.Shapes)
                                        {
                                            item.Visible = Office.MsoTriState.msoFalse;
                                        }
                                        oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                        foreach (PowerPoint.Shape item in oslide.Shapes)
                                        {
                                            item.Visible = Office.MsoTriState.msoTrue;
                                        }
                                    }
                                    else
                                    {
                                        oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                    }
                                    nFill.UserTextured(pptpr.Path + oslide.Name + ".jpg");
                                    File.Delete(pptpr.Path + oslide.Name + ".jpg");
                                }

                                if (oFill.TextureTile == Office.MsoTriState.msoTrue)
                                {
                                    nFill.TextureTile = Office.MsoTriState.msoTrue;
                                }
                                else
                                {
                                    nFill.TextureTile = Office.MsoTriState.msoFalse;
                                }

                                nFill.TextureAlignment = oFill.TextureAlignment;
                                nFill.TextureHorizontalScale = oFill.TextureHorizontalScale;
                                nFill.TextureVerticalScale = oFill.TextureVerticalScale;
                                nFill.TextureOffsetX = oFill.TextureOffsetX;
                                nFill.TextureOffsetY = oFill.TextureOffsetY;
                            }
                        }
                        pptpr.Close();
                        n += 1;
                    }
                }
                if (n == 0)
                {
                    MessageBox.Show("没有找到PPT文档");
                }
                else
                {
                    MessageBox.Show("已合并 " + n + " 个PPT文档");
                }
            }
        }

        public void button293_Click(object sender, RibbonControlEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PowerPoint 演示文稿（*.pptx）|*.pptx|PowerPoint 97-2003 演示文稿（*.ppt）|*.ppt";
            sfd.FileName = app.ActivePresentation.Name + "_1";
            sfd.RestoreDirectory = true;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PowerPoint.Selection sel = app.ActiveWindow.Selection;
                string filename = sfd.FileName;
                FileStream nf = File.Create(filename);
                nf.Dispose();

                PowerPoint.Application pptapp = new PowerPoint.Application();
                PowerPoint.Presentation pptpr = pptapp.Presentations.Open(filename, Office.MsoTriState.msoFalse, Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue);
                pptpr.ApplyTheme(filename);
                foreach (PowerPoint.Slide oslide in sel.SlideRange)
                {
                    oslide.Copy();
                    PowerPoint.Slide nslide = pptpr.Slides.Paste()[1];
                    nslide.Design = oslide.Design;
                    nslide.ColorScheme = oslide.ColorScheme;
                    PowerPoint.FillFormat oFill = oslide.Background.Fill;
                    PowerPoint.FillFormat nFill = nslide.Background.Fill;

                    if (oslide.DisplayMasterShapes == Office.MsoTriState.msoTrue)
                    {
                        nslide.DisplayMasterShapes = Office.MsoTriState.msoTrue;
                    }

                    if (oslide.FollowMasterBackground == Office.MsoTriState.msoFalse)
                    {
                        nslide.FollowMasterBackground = Office.MsoTriState.msoFalse;
                        if (oFill.Type == Office.MsoFillType.msoFillSolid)
                        {
                            nFill.ForeColor.RGB = oFill.ForeColor.RGB;
                            nFill.Transparency = oFill.Transparency;
                            nFill.BackColor = oFill.BackColor;
                        }
                        else if (oFill.Type == Office.MsoFillType.msoFillGradient)
                        {
                            if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientDiagonalDown)
                            {
                                nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalDown, 1, 1);
                                nFill.GradientAngle = oFill.GradientAngle;
                            }
                            else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientDiagonalUp)
                            {
                                nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalUp, 1, 1);
                                nFill.GradientAngle = oFill.GradientAngle;
                            }
                            else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromCenter)
                            {
                                nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromCenter, 1, 1);
                            }
                            else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromCorner)
                            {
                                nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromCorner, 1, 1);
                            }
                            else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientHorizontal)
                            {
                                nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientHorizontal, 1, 1);
                                nFill.GradientAngle = oFill.GradientAngle;
                            }
                            else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientVertical)
                            {
                                nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientVertical, 1, 1);
                                nFill.GradientAngle = oFill.GradientAngle;
                            }
                            else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientFromTitle)
                            {
                                nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientFromTitle, 1, 1);
                            }
                            else if (oFill.GradientStyle == Office.MsoGradientStyle.msoGradientMixed)
                            {
                                nFill.OneColorGradient(Office.MsoGradientStyle.msoGradientDiagonalDown, 1, 1);
                            }

                            int count = nFill.GradientStops.Count;

                            if (count != 2)
                            {
                                for (int j = 1; j <= count; j++)
                                {
                                    nFill.GradientStops.Insert(j - j, 0, 0, -1);
                                }
                            }
                            for (int j = 1; j <= count; j++)
                            {
                                nFill.GradientStops[j].Color.RGB = oFill.GradientStops[j].Color.RGB;
                                nFill.GradientStops[j].Position = oFill.GradientStops[j].Position;
                                nFill.GradientStops[j].Transparency = oFill.GradientStops[j].Transparency;
                                nFill.GradientStops[j].Color.Brightness = oFill.GradientStops[j].Color.Brightness;
                            }
                        }
                        else if (oFill.Type == Office.MsoFillType.msoFillPicture)
                        {
                            if (oslide.Shapes.Count != 0)
                            {
                                foreach (PowerPoint.Shape item in oslide.Shapes)
                                {
                                    item.Visible = Office.MsoTriState.msoFalse;
                                }
                                oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                foreach (PowerPoint.Shape item in oslide.Shapes)
                                {
                                    item.Visible = Office.MsoTriState.msoTrue;
                                }
                            }
                            else
                            {
                                oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                            }
                            nFill.UserPicture(pptpr.Path + oslide.Name + ".jpg");
                            File.Delete(pptpr.Path + oslide.Name + ".jpg");
                        }
                        else if (oFill.Type == Office.MsoFillType.msoFillPatterned)
                        {
                            nFill.Patterned(oFill.Pattern);
                        }
                        else if (oFill.Type == Office.MsoFillType.msoFillTextured)
                        {

                            if (oFill.TextureType == Office.MsoTextureType.msoTexturePreset)
                            {
                                nFill.PresetTextured(oFill.PresetTexture);
                            }
                            else if (oFill.TextureType == Office.MsoTextureType.msoTextureUserDefined || oFill.TextureType == Office.MsoTextureType.msoTextureTypeMixed)
                            {
                                if (oslide.Shapes.Count != 0)
                                {
                                    foreach (PowerPoint.Shape item in oslide.Shapes)
                                    {
                                        item.Visible = Office.MsoTriState.msoFalse;
                                    }
                                    oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                    foreach (PowerPoint.Shape item in oslide.Shapes)
                                    {
                                        item.Visible = Office.MsoTriState.msoTrue;
                                    }
                                }
                                else
                                {
                                    oslide.Export(pptpr.Path + oslide.Name + ".jpg", "jpg", (int)pptpr.PageSetup.SlideWidth, (int)pptpr.PageSetup.SlideHeight);
                                }
                                nFill.UserTextured(pptpr.Path + oslide.Name + ".jpg");
                                File.Delete(pptpr.Path + oslide.Name + ".jpg");
                            }

                            if (oFill.TextureTile == Office.MsoTriState.msoTrue)
                            {
                                nFill.TextureTile = Office.MsoTriState.msoTrue;
                            }
                            else
                            {
                                nFill.TextureTile = Office.MsoTriState.msoFalse;
                            }

                            nFill.TextureAlignment = oFill.TextureAlignment;
                            nFill.TextureHorizontalScale = oFill.TextureHorizontalScale;
                            nFill.TextureVerticalScale = oFill.TextureVerticalScale;
                            nFill.TextureOffsetX = oFill.TextureOffsetX;
                            nFill.TextureOffsetY = oFill.TextureOffsetY;
                        }
                    }
                }
                pptpr.Save();
            }
        }

        public void button111_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                string txt = "";
                if (range.Count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[1].GroupItems.Count; j++)
                        {
                            for (int i = 1; i <= range.Count; i++)
                            {
                                if (range[1].GroupItems[i].HasTextFrame == Office.MsoTriState.msoTrue && range[1].GroupItems[i].TextFrame.HasText == Office.MsoTriState.msoTrue && range[1].GroupItems[i].TextFrame.TextRange.Text != "")
                                {
                                    txt += range[1].GroupItems[i].TextFrame.TextRange.Text + Environment.NewLine;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (range[1].HasTextFrame == Office.MsoTriState.msoTrue && range[1].TextFrame.HasText == Office.MsoTriState.msoTrue && range[1].TextFrame.TextRange.Text != "")
                        {
                            txt += range[1].TextFrame.TextRange.Text;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= range.Count; i++)
                    {
                        if (range[i].HasTextFrame == Office.MsoTriState.msoTrue && range[i].TextFrame.HasText == Office.MsoTriState.msoTrue && range[i].TextFrame.TextRange.Text != "")
                        {
                            txt += range[i].TextFrame.TextRange.Text + Environment.NewLine;
                        }
                    }
                }

                if (txt == "")
                {
                    MessageBox.Show("所选形状无文本？");
                }
                else
                {
                    PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                    slide.NotesPage.Shapes.Placeholders[2].TextFrame.TextRange.Text = txt;
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                slide.NotesPage.Shapes.Placeholders[2].TextFrame.TextRange.Text = sel.TextRange.Text;
            }
            else
            {
                MessageBox.Show("请选中文字或带文字的形状");
            }
        }

        public void button112_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                string txt = "";
                if (range.Count == 1)
                {
                    if (range[1].Type == Office.MsoShapeType.msoGroup)
                    {
                        for (int j = 1; j <= range[1].GroupItems.Count; j++)
                        {
                            for (int i = 1; i <= range.Count; i++)
                            {
                                if (range[1].GroupItems[i].HasTextFrame == Office.MsoTriState.msoTrue && range[1].GroupItems[i].TextFrame.HasText == Office.MsoTriState.msoTrue && range[1].GroupItems[i].TextFrame.TextRange.Text != "")
                                {
                                    txt += range[1].GroupItems[i].TextFrame.TextRange.Text + Environment.NewLine;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (range[1].HasTextFrame == Office.MsoTriState.msoTrue && range[1].TextFrame.HasText == Office.MsoTriState.msoTrue && range[1].TextFrame.TextRange.Text != "")
                        {
                            txt += range[1].TextFrame.TextRange.Text;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= range.Count; i++)
                    {
                        if (range[i].HasTextFrame == Office.MsoTriState.msoTrue && range[i].TextFrame.HasText == Office.MsoTriState.msoTrue && range[i].TextFrame.TextRange.Text != "")
                        {
                            txt += range[i].TextFrame.TextRange.Text + Environment.NewLine;
                        }
                    }
                }

                if (txt == "")
                {
                    MessageBox.Show("所选形状无文本？");
                }
                else
                {
                    PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                    foreach (PowerPoint.Shape item in slide.Shapes)
                    {
                        if (item.Type == Office.MsoShapeType.msoPlaceholder)
                        {
                            item.TextFrame.TextRange.Text = txt;
                            break;
                        }
                    }
                }
            }
            else if (sel.Type == PowerPoint.PpSelectionType.ppSelectionText)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                foreach (PowerPoint.Shape item in slide.Shapes)
                {
                    if (item.Type == Office.MsoShapeType.msoPlaceholder)
                    {
                        item.TextFrame.TextRange.Text = sel.TextRange.Text;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选中文字或带文字的形状");
            }
        }

        public void button113_Click(object sender, RibbonControlEventArgs e)
        {
            PowerPoint.Selection sel = app.ActiveWindow.Selection;
            if (sel.Type == PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                PowerPoint.Slide slide = app.ActiveWindow.View.Slide;
                PowerPoint.ShapeRange range = sel.ShapeRange;
                if (sel.HasChildShapeRange)
                {
                    range = sel.ChildShapeRange;
                }
                range.Copy();
                slide.Master.Shapes.Paste();
            }
            else
            {
                MessageBox.Show("请选中形状");
            }
        }

    }
}