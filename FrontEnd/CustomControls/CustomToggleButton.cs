﻿using Amazon.Runtime.Internal.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Do_An.FrontEnd.CustomControls
{
    public class CustomToggleButton : CheckBox
    {
        // Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OnBackColor { get => onBackColor; set {onBackColor = value; this.Invalidate(); }}
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OnToggleColor { get => onToggleColor; set { onToggleColor = value; this.Invalidate(); }}
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OffBackColor { get => offBackColor; set { offBackColor = value; this.Invalidate(); } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color OffToggleColor { get => offToggleColor; set { offToggleColor = value; this.Invalidate(); } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SolidStyle { get => solidStyle; set { solidStyle = value; this.Invalidate(); } }

        // constructor
        public CustomToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        // Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(this.onBackColor), GetFigurePath());
                else 
                    pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(this.onToggleColor),
                        new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else
            {
                if (solidStyle)
                    pevent.Graphics.FillPath(new SolidBrush(this.offBackColor), GetFigurePath());
                else
                    pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(this.offToggleColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
