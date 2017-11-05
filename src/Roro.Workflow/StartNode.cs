﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Roro.Workflow
{
    public sealed class StartNode : Node
    {
        public Guid Next { get; set; }

        public StartNode()
        {
            this.Activity = new StartNodeActivity();
        }

        public override Guid Execute()
        {
            Console.WriteLine("Execute: {0} {1}", this.Id, this.GetType().Name);
            return this.Next;
        }

        public override void SetNextTo(Guid id)
        {
            this.Next = id;
        }

        public override GraphicsPath Render(Graphics g, Rectangle r, DefaultNodeStyle o)
        {
            var leftRect = new Rectangle(
                r.X,
                r.Y,
                r.Height,
                r.Height);
            var rightRect = new Rectangle(
                r.Right - r.Height,
                r.Y,
                r.Height,
                r.Height);
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftRect, 90, 180);
            path.AddArc(rightRect, -90, 180);
            path.CloseFigure();
            //
            g.FillPath(o.BackBrush, path);
            g.DrawPath(o.BorderPen, path);
            return path;
        }
    }
}
