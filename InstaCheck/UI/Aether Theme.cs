using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Threading;
using System.ComponentModel;
using System.Collections;

//Aether Theme made by AeroRev9
//07/10/2015.
//Import Microsoft.VisualBasic Reference

internal sealed class Helpers
{
    public enum MouseState : byte
    {
        None,
        Over,
        Down
    }

    public enum Direction : byte
    {
        Up,
        Down,
        Left,
        Right
    }

    public static Rectangle FullRectangle(Size S, bool Subtract)
    {
        Rectangle result;
        if (Subtract)
        {
            result = checked(new Rectangle(0, 0, S.Width - 1, S.Height - 1));
        }
        else
        {
            result = new Rectangle(0, 0, S.Width, S.Height);
        }
        return result;
    }

    public static Color GreyColor(uint G)
    {
        return checked(Color.FromArgb((int)G, (int)G, (int)G));
    }

    public static void CenterString(Graphics G, string T, Font F, Color C, Rectangle R)
    {
        SizeF sizeF = G.MeasureString(T, F);
        using (SolidBrush solidBrush = new SolidBrush(C))
        {
            G.DrawString(T, F, solidBrush, checked(new Point((int)Math.Round(unchecked((double)R.Width / 2.0 - (double)(sizeF.Width / 2f))), (int)Math.Round(unchecked((double)R.Height / 2.0 - (double)(sizeF.Height / 2f))))));
        }
    }

    public static void FillRoundRect(Graphics G, Rectangle R, int Curve, Brush B)
    {
        G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90);
        checked
        {
            G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
            G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
            G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
            G.FillRectangle(B, (int)Math.Round(unchecked((double)R.X + (double)Curve / 2.0)), R.Y, R.Width - Curve, (int)Math.Round((double)Curve / 2.0));
            G.FillRectangle(B, R.X, (int)Math.Round(unchecked((double)R.Y + (double)Curve / 2.0)), R.Width, R.Height - Curve);
            G.FillRectangle(B, (int)Math.Round(unchecked((double)R.X + (double)Curve / 2.0)), (int)Math.Round(unchecked((double)(checked(R.Y + R.Height)) - (double)Curve / 2.0)), R.Width - Curve, (int)Math.Round((double)Curve / 2.0));
        }
    }

    public static void DrawRoundRect(Graphics G, Rectangle R, int Curve, Pen PP)
    {
        G.DrawArc(PP, R.X, R.Y, Curve, Curve, 180, 90);
        checked
        {
            G.DrawLine(PP, (int)Math.Round(unchecked((double)R.X + (double)Curve / 2.0)), R.Y, (int)Math.Round(unchecked((double)(checked(R.X + R.Width)) - (double)Curve / 2.0)), R.Y);
            G.DrawArc(PP, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
            G.DrawLine(PP, R.X, (int)Math.Round(unchecked((double)R.Y + (double)Curve / 2.0)), R.X, (int)Math.Round(unchecked((double)(checked(R.Y + R.Height)) - (double)Curve / 2.0)));
            G.DrawLine(PP, R.X + R.Width, (int)Math.Round(unchecked((double)R.Y + (double)Curve / 2.0)), R.X + R.Width, (int)Math.Round(unchecked((double)(checked(R.Y + R.Height)) - (double)Curve / 2.0)));
            G.DrawLine(PP, (int)Math.Round(unchecked((double)R.X + (double)Curve / 2.0)), R.Y + R.Height, (int)Math.Round(unchecked((double)(checked(R.X + R.Width)) - (double)Curve / 2.0)), R.Y + R.Height);
            G.DrawArc(PP, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
            G.DrawArc(PP, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
        }
    }

    public static void DrawTriangle(Graphics G, Rectangle Rect, Helpers.Direction D, Color C)
    {
        checked
        {
            int num = (int)Math.Round((double)Rect.Width / 2.0);
            int num2 = (int)Math.Round((double)Rect.Height / 2.0);
            Point empty = Point.Empty;
            Point empty2 = Point.Empty;
            Point empty3 = Point.Empty;
            switch (D)
            {
                case Helpers.Direction.Up:
                    empty = new Point(Rect.Left + num, Rect.Top);
                    empty2 = new Point(Rect.Left, Rect.Bottom);
                    empty3 = new Point(Rect.Right, Rect.Bottom);
                    break;
                case Helpers.Direction.Down:
                    empty = new Point(Rect.Left + num, Rect.Bottom);
                    empty2 = new Point(Rect.Left, Rect.Top);
                    empty3 = new Point(Rect.Right, Rect.Top);
                    break;
                case Helpers.Direction.Left:
                    empty = new Point(Rect.Left, Rect.Top + num2);
                    empty2 = new Point(Rect.Right, Rect.Top);
                    empty3 = new Point(Rect.Right, Rect.Bottom);
                    break;
                case Helpers.Direction.Right:
                    empty = new Point(Rect.Right, Rect.Top + num2);
                    empty2 = new Point(Rect.Left, Rect.Bottom);
                    empty3 = new Point(Rect.Left, Rect.Top);
                    break;
            }
            using (SolidBrush solidBrush = new SolidBrush(C))
            {
                G.FillPolygon(solidBrush, new Point[]
                {
                        empty,
                        empty2,
                        empty3
                });
            }
        }
    }

    public static Color ColorFromHex(string Hex)
    {
        Hex = Strings.Replace(Hex, "#", "", 1, -1, CompareMethod.Binary);
        string value = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(Hex, 1, 2)));
        string value2 = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(Hex, 3, 2)));
        string value3 = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(Hex, 5, 2)));
        return Color.FromArgb(Conversions.ToInteger(value), Conversions.ToInteger(value2), Conversions.ToInteger(value3));
    }
}
public class AetherTabControl : TabControl
{
    private Graphics G;

    private Rectangle Rect;

    private SizeF MS1;

    private SizeF MS2;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private bool _UpperText;

    public bool UpperText
    {
        get;
        set;
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams createParams = base.CreateParams;
            createParams.ExStyle |= 33554432;
            return createParams;
        }
    }

    public AetherTabControl()
    {
        this.UpperText = true;
        this.DoubleBuffered = true;
        base.Alignment = TabAlignment.Left;
        base.SizeMode = TabSizeMode.Fixed;
        base.ItemSize = new Size(40, 190);
        this.Dock = DockStyle.Fill;
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        base.SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        base.OnControlAdded(e);
        e.Control.BackColor = Color.White;
        e.Control.ForeColor = Helpers.ColorFromHex("#343843");
        using (Font font = new Font("Segoe UI", 9f))
        {
            e.Control.Font = font;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        this.G.Clear(Helpers.ColorFromHex("#343843"));
        checked
        {
            int num = base.TabPages.Count - 1;
            for (int i = 0; i <= num; i++)
            {
                this.Rect = base.GetTabRect(i);
                bool flag = base.SelectedIndex == i;
                if (flag)
                {
                    using (SolidBrush solidBrush = new SolidBrush(Helpers.ColorFromHex("#3A3E49")))
                    {
                        this.G.FillRectangle(solidBrush, new Rectangle(this.Rect.X - 4, this.Rect.Y + 1, this.Rect.Width + 6, this.Rect.Height));
                    }
                }
                using (SolidBrush solidBrush2 = new SolidBrush(Helpers.ColorFromHex("#737A8A")))
                {
                    bool upperText = this.UpperText;
                    if (upperText)
                    {
                        using (Font font = new Font("Segoe UI", 7.75f, FontStyle.Bold))
                        {
                            this.G.DrawString(base.TabPages[i].Text.ToUpper(), font, solidBrush2, new Point(this.Rect.X + 50, this.Rect.Y + 13));
                        }
                    }
                    else
                    {
                        using (Font font2 = new Font("Segoe UI semibold", 9f))
                        {
                            this.G.DrawString(base.TabPages[i].Text, font2, solidBrush2, new Point(this.Rect.X + 50, this.Rect.Y + 11));
                        }
                    }
                }
                bool flag2 = !string.IsNullOrEmpty(Conversions.ToString(base.TabPages[i].Tag));
                if (flag2)
                {
                    bool upperText2 = this.UpperText;
                    if (upperText2)
                    {
                        using (Font font3 = new Font("Segoe UI", 7.75f, FontStyle.Bold))
                        {
                            this.MS1 = this.G.MeasureString(base.TabPages[i].Text, font3);
                        }
                    }
                    else
                    {
                        using (Font font4 = new Font("Segoe UI semibold", 9f))
                        {
                            this.MS1 = this.G.MeasureString(base.TabPages[i].Text, font4);
                        }
                    }
                    using (Font font5 = new Font("Segoe UI", 9f))
                    {
                        this.MS2 = this.G.MeasureString(Conversions.ToString(base.TabPages[i].Tag), font5);
                    }
                    using (SolidBrush solidBrush3 = new SolidBrush(Helpers.ColorFromHex("#424452")))
                    {
                        using (Pen pen = new Pen(Helpers.ColorFromHex("#323541")))
                        {
                            using (SolidBrush solidBrush4 = new SolidBrush(Helpers.ColorFromHex("#737A8A")))
                            {
                                this.G.FillRectangle(solidBrush3, new Rectangle((int)Math.Round((double)(unchecked((float)this.Rect.X + this.MS1.Width + 72f))), this.Rect.Y + 13, (int)Math.Round((double)(unchecked(this.MS2.Width + 5f))), 15));
                                Helpers.DrawRoundRect(this.G, new Rectangle((int)Math.Round((double)(unchecked((float)this.Rect.X + this.MS1.Width + 72f))), this.Rect.Y + 13, (int)Math.Round((double)(unchecked(this.MS2.Width + 5f))), 15), 3, pen);
                                bool flag3 = Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(base.TabPages[i].Tag));
                                if (flag3)
                                {
                                    using (Font font6 = new Font("Segoe UI", 8f, FontStyle.Bold))
                                    {
                                        this.G.DrawString(Conversions.ToString(base.TabPages[i].Tag), font6, solidBrush4, new Point((int)Math.Round((double)(unchecked((float)this.Rect.X + this.MS1.Width + 75f))), this.Rect.Y + 14));
                                    }
                                }
                                else
                                {
                                    using (Font font7 = new Font("Segoe UI", 7f, FontStyle.Bold))
                                    {
                                        this.G.DrawString(base.TabPages[i].Tag.ToString().ToUpper(), font7, solidBrush4, new Point((int)Math.Round((double)(unchecked((float)this.Rect.X + this.MS1.Width + 75f))), this.Rect.Y + 14));
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag4 = i != 0;
                if (flag4)
                {
                    using (Pen pen2 = new Pen(Helpers.ColorFromHex("#3B3D49")))
                    {
                        using (Pen pen3 = new Pen(Helpers.ColorFromHex("#2F323C")))
                        {
                            this.G.DrawLine(pen2, new Point(this.Rect.X - 4, this.Rect.Y + 1), new Point(this.Rect.Width + 4, this.Rect.Y + 1));
                            this.G.DrawLine(pen3, new Point(this.Rect.X - 4, this.Rect.Y + 2), new Point(this.Rect.Width + 4, this.Rect.Y + 2));
                        }
                    }
                }
                bool flag5 = !Information.IsNothing(base.ImageList);
                if (flag5)
                {
                    bool flag6 = base.TabPages[i].ImageIndex >= 0;
                    if (flag6)
                    {
                        this.G.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Rectangle(this.Rect.X + 18, (int)Math.Round(unchecked((double)this.Rect.Y + ((double)this.Rect.Height / 2.0 - 8.0))), 16, 16));
                    }
                }
            }
        }
    }
}
public class AetherButton : Control
{
    public delegate void ClickEventHandler(object sender, EventArgs e);

    private Graphics G;

    private Helpers.MouseState State;

    private bool _EnabledCalc;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private AetherButton.ClickEventHandler ClickEvent;

    public new event AetherButton.ClickEventHandler Click
    {
        [CompilerGenerated]
        add
        {
            AetherButton.ClickEventHandler clickEventHandler = this.ClickEvent;
            AetherButton.ClickEventHandler clickEventHandler2;
            do
            {
                clickEventHandler2 = clickEventHandler;
                AetherButton.ClickEventHandler value2 = (AetherButton.ClickEventHandler)Delegate.Combine(clickEventHandler2, value);
                clickEventHandler = Interlocked.CompareExchange<AetherButton.ClickEventHandler>(ref this.ClickEvent, value2, clickEventHandler2);
            }
            while (clickEventHandler != clickEventHandler2);
        }
        [CompilerGenerated]
        remove
        {
            AetherButton.ClickEventHandler clickEventHandler = this.ClickEvent;
            AetherButton.ClickEventHandler clickEventHandler2;
            do
            {
                clickEventHandler2 = clickEventHandler;
                AetherButton.ClickEventHandler value2 = (AetherButton.ClickEventHandler)Delegate.Remove(clickEventHandler2, value);
                clickEventHandler = Interlocked.CompareExchange<AetherButton.ClickEventHandler>(ref this.ClickEvent, value2, clickEventHandler2);
            }
            while (clickEventHandler != clickEventHandler2);
        }
    }

    public new bool Enabled
    {
        get
        {
            return this.EnabledCalc;
        }
        set
        {
            this._EnabledCalc = value;
            base.Invalidate();
        }
    }

    [DisplayName("Enabled")]
    public bool EnabledCalc
    {
        get
        {
            return this._EnabledCalc;
        }
        set
        {
            this.Enabled = value;
            base.Invalidate();
        }
    }

    public AetherButton()
    {
        this.DoubleBuffered = true;
        this.Enabled = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        bool enabled = this.Enabled;
        checked
        {
            if (enabled)
            {
                Helpers.MouseState state = this.State;
                if (state != Helpers.MouseState.Over)
                {
                    if (state != Helpers.MouseState.Down)
                    {
                        using (SolidBrush solidBrush = new SolidBrush(Helpers.ColorFromHex("#F6F6F6")))
                        {
                            Helpers.FillRoundRect(this.G, new Rectangle(0, 0, base.Width - 1, base.Height - 1), 3, solidBrush);
                        }
                    }
                    else
                    {
                        using (SolidBrush solidBrush2 = new SolidBrush(Helpers.ColorFromHex("#F0F0F0")))
                        {
                            Helpers.FillRoundRect(this.G, new Rectangle(0, 0, base.Width - 1, base.Height - 1), 3, solidBrush2);
                        }
                    }
                }
                else
                {
                    using (SolidBrush solidBrush3 = new SolidBrush(Helpers.ColorFromHex("#FDFDFD")))
                    {
                        Helpers.FillRoundRect(this.G, new Rectangle(0, 0, base.Width - 1, base.Height - 1), 3, solidBrush3);
                    }
                }
                using (Font font = new Font("Segoe UI", 9f))
                {
                    using (Pen pen = new Pen(Helpers.ColorFromHex("#C3C3C3")))
                    {
                        Helpers.DrawRoundRect(this.G, new Rectangle(0, 0, base.Width - 1, base.Height - 1), 3, pen);
                        Helpers.CenterString(this.G, this.Text, font, Helpers.ColorFromHex("#343843"), Helpers.FullRectangle(base.Size, false));
                    }
                }
            }
            else
            {
                using (SolidBrush solidBrush4 = new SolidBrush(Helpers.ColorFromHex("#F2F2F2")))
                {
                    using (Pen pen2 = new Pen(Helpers.ColorFromHex("#DCDCDC")))
                    {
                        using (Font font2 = new Font("Segoe UI", 9f))
                        {
                            Helpers.FillRoundRect(this.G, new Rectangle(0, 0, base.Width - 1, base.Height - 1), 6, solidBrush4);
                            Helpers.DrawRoundRect(this.G, new Rectangle(0, 0, base.Width - 1, base.Height - 1), 6, pen2);
                            Helpers.CenterString(this.G, this.Text, font2, Helpers.ColorFromHex("#989CA7"), Helpers.FullRectangle(base.Size, false));
                        }
                    }
                }
            }
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        this.State = Helpers.MouseState.Over;
        base.Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        this.State = Helpers.MouseState.None;
        base.Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            AetherButton.ClickEventHandler clickEvent = this.ClickEvent;
            if (clickEvent != null)
            {
                clickEvent(this, e);
            }
        }
        this.State = Helpers.MouseState.Over;
        base.Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        this.State = Helpers.MouseState.Down;
        base.Invalidate();
    }
}
[DefaultEvent("CheckedChanged")]
public class AetherCheckBox : Control
{
    public delegate void CheckedChangedEventHandler(object sender, EventArgs e);

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private AetherCheckBox.CheckedChangedEventHandler CheckedChangedEvent;

    private bool _Checked;

    private bool _EnabledCalc;

    private Graphics G;

    private Helpers.MouseState State;

    public event AetherCheckBox.CheckedChangedEventHandler CheckedChanged
    {
        [CompilerGenerated]
        add
        {
            AetherCheckBox.CheckedChangedEventHandler checkedChangedEventHandler = this.CheckedChangedEvent;
            AetherCheckBox.CheckedChangedEventHandler checkedChangedEventHandler2;
            do
            {
                checkedChangedEventHandler2 = checkedChangedEventHandler;
                AetherCheckBox.CheckedChangedEventHandler value2 = (AetherCheckBox.CheckedChangedEventHandler)Delegate.Combine(checkedChangedEventHandler2, value);
                checkedChangedEventHandler = Interlocked.CompareExchange<AetherCheckBox.CheckedChangedEventHandler>(ref this.CheckedChangedEvent, value2, checkedChangedEventHandler2);
            }
            while (checkedChangedEventHandler != checkedChangedEventHandler2);
        }
        [CompilerGenerated]
        remove
        {
            AetherCheckBox.CheckedChangedEventHandler checkedChangedEventHandler = this.CheckedChangedEvent;
            AetherCheckBox.CheckedChangedEventHandler checkedChangedEventHandler2;
            do
            {
                checkedChangedEventHandler2 = checkedChangedEventHandler;
                AetherCheckBox.CheckedChangedEventHandler value2 = (AetherCheckBox.CheckedChangedEventHandler)Delegate.Remove(checkedChangedEventHandler2, value);
                checkedChangedEventHandler = Interlocked.CompareExchange<AetherCheckBox.CheckedChangedEventHandler>(ref this.CheckedChangedEvent, value2, checkedChangedEventHandler2);
            }
            while (checkedChangedEventHandler != checkedChangedEventHandler2);
        }
    }

    public bool Checked
    {
        get
        {
            return this._Checked;
        }
        set
        {
            this._Checked = value;
            base.Invalidate();
        }
    }

    public new bool Enabled
    {
        get
        {
            return this.EnabledCalc;
        }
        set
        {
            this._EnabledCalc = value;
            bool enabled = this.Enabled;
            if (enabled)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
            base.Invalidate();
        }
    }

    [DisplayName("Enabled")]
    public bool EnabledCalc
    {
        get
        {
            return this._EnabledCalc;
        }
        set
        {
            this.Enabled = value;
            base.Invalidate();
        }
    }

    public AetherCheckBox()
    {
        this.DoubleBuffered = true;
        this.Enabled = true;
        this.Cursor = Cursors.Hand;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            using (Pen pen = new Pen(Helpers.ColorFromHex("#D2D2D2")))
            {
                using (SolidBrush solidBrush = new SolidBrush(Helpers.ColorFromHex("#343843")))
                {
                    using (Font font = new Font("Segoe UI", 9f))
                    {
                        Helpers.DrawRoundRect(this.G, new Rectangle(0, 0, 18, 18), 6, pen);
                        this.G.DrawString(this.Text, font, solidBrush, new Point(25, 1));
                    }
                }
            }
            bool flag = this.State == Helpers.MouseState.Over | this.State == Helpers.MouseState.Down;
            if (flag)
            {
                using (Pen pen2 = new Pen(Helpers.ColorFromHex("#8C92A1")))
                {
                    Helpers.DrawRoundRect(this.G, new Rectangle(0, 0, 18, 18), 6, pen2);
                }
            }
        }
        else
        {
            using (Pen pen3 = new Pen(Helpers.ColorFromHex("#DCDCDC")))
            {
                using (SolidBrush solidBrush2 = new SolidBrush(Helpers.ColorFromHex("#989CA7")))
                {
                    using (Font font2 = new Font("Segoe UI", 9f))
                    {
                        Helpers.DrawRoundRect(this.G, new Rectangle(0, 0, 18, 18), 6, pen3);
                        this.G.DrawString(this.Text, font2, solidBrush2, new Point(25, 1));
                    }
                }
            }
        }
        bool @checked = this.Checked;
        if (@checked)
        {
            bool enabled2 = this.Enabled;
            if (enabled2)
            {
                using (HatchBrush hatchBrush = new HatchBrush(HatchStyle.WideUpwardDiagonal, Helpers.ColorFromHex("#5B606F"), Helpers.ColorFromHex("#525766")))
                {
                    using (Pen pen4 = new Pen(Helpers.ColorFromHex("#474C5A")))
                    {
                        this.G.FillRectangle(hatchBrush, new Rectangle(4, 4, 10, 10));
                        Helpers.DrawRoundRect(this.G, new Rectangle(4, 4, 10, 10), 3, pen4);
                    }
                }
            }
            else
            {
                using (HatchBrush hatchBrush2 = new HatchBrush(HatchStyle.WideUpwardDiagonal, Helpers.ColorFromHex("#8C92A1"), Helpers.ColorFromHex("#7A7F8E")))
                {
                    using (Pen pen5 = new Pen(Helpers.ColorFromHex("#797E8C")))
                    {
                        this.G.FillRectangle(hatchBrush2, new Rectangle(4, 4, 10, 10));
                        Helpers.DrawRoundRect(this.G, new Rectangle(4, 4, 10, 10), 3, pen5);
                    }
                }
            }
        }
    }


    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        base.Size = new Size(base.Width, 19);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            this.State = Helpers.MouseState.Over;
            this.Checked = !this.Checked;
            AetherCheckBox.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
            if (checkedChangedEvent != null)
            {
                checkedChangedEvent(this, e);
            }
            base.Invalidate();
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            this.State = Helpers.MouseState.Down;
            base.Invalidate();
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            this.State = Helpers.MouseState.Over;
            base.Invalidate();
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            this.State = Helpers.MouseState.None;
            base.Invalidate();
        }
    }
}
public class AetherCircular : Control
{
    private Graphics G;

    private float ProgressAngle;

    private float RemainderAngle;

    private bool ExceedingLimits;

    private string ExceedingSign;

    private float _Progress;

    private float _Max;

    private float _Min;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private bool _Percent;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private Color _Border;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private Color _HatchPrimary;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private Color _HatchSecondary;

    public bool Percent
    {
        get;
        set;
    }

    public float Progress
    {
        get
        {
            return this._Progress;
        }
        set
        {
            float num = value;
            bool flag = num > this.Max;
            if (flag)
            {
                value = this.Max;
                this.ExceedingSign = "+";
                this.ExceedingLimits = true;
                base.Invalidate();
            }
            else
            {
                flag = (num < this.Min);
                if (flag)
                {
                    value = this.Min;
                    this.ExceedingSign = "-";
                    this.ExceedingLimits = true;
                    base.Invalidate();
                }
            }
            this._Progress = value;
            base.Invalidate();
        }
    }

    public float Max
    {
        get
        {
            return this._Max;
        }
        set
        {
            bool flag = value < this._Progress;
            if (flag)
            {
                this._Progress = value;
            }
            this._Max = value;
            base.Invalidate();
        }
    }

    public float Min
    {
        get
        {
            return this._Min;
        }
        set
        {
            bool flag = value > this._Progress;
            if (flag)
            {
                this._Progress = value;
            }
            this._Min = value;
            base.Invalidate();
        }
    }

    public Color Border
    {
        get;
        set;
    }

    public Color HatchPrimary
    {
        get;
        set;
    }

    public Color HatchSecondary
    {
        get;
        set;
    }

    public AetherCircular()
    {
        this._Max = 100f;
        this._Min = 0f;
        this.Percent = true;
        this.Border = Color.LightGray;
        this.HatchPrimary = Color.Green;
        this.HatchSecondary = Color.Red;
        this.DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        this.ProgressAngle = 360f / this.Max * this.Progress;
        this.RemainderAngle = 360f - this.ProgressAngle;
        checked
        {
            using (Pen pen = new Pen(new HatchBrush(HatchStyle.LightUpwardDiagonal, this.HatchPrimary, this.HatchSecondary), 4f))
            {
                using (Pen pen2 = new Pen(this.Border, 4f))
                {
                    this.G.DrawArc(pen, new Rectangle(2, 2, base.Width - 5, base.Height - 5), -90f, this.ProgressAngle);
                    this.G.DrawArc(pen2, new Rectangle(2, 2, base.Width - 5, base.Height - 5), unchecked(this.ProgressAngle - 90f), this.RemainderAngle);
                }
            }
            bool percent = this.Percent;
            if (percent)
            {
                using (Font font = new Font("Segoe UI", 9f, FontStyle.Bold))
                {
                    bool exceedingLimits = this.ExceedingLimits;
                    if (exceedingLimits)
                    {
                        Helpers.CenterString(this.G, Conversions.ToString(this.Progress) + "%" + this.ExceedingSign, font, Color.FromArgb(100, 100, 100), new Rectangle(1, 1, base.Width, base.Height + 1));
                    }
                    else
                    {
                        Helpers.CenterString(this.G, Conversions.ToString(this.Progress) + "%", font, Color.FromArgb(100, 100, 100), new Rectangle(1, 1, base.Width, base.Height + 1));
                    }
                }
            }
            else
            {
                bool exceedingLimits2 = this.ExceedingLimits;
                if (exceedingLimits2)
                {
                    Helpers.CenterString(this.G, Conversions.ToString(this.Progress) + this.ExceedingSign, new Font("Segoe UI", 9f, FontStyle.Bold), Color.FromArgb(100, 100, 100), new Rectangle(1, 1, base.Width, base.Height + 1));
                }
                else
                {
                    Helpers.CenterString(this.G, Conversions.ToString(this.Progress), new Font("Segoe UI", 9f, FontStyle.Bold), Color.FromArgb(100, 100, 100), new Rectangle(1, 1, base.Width, base.Height + 1));
                }
            }
            this.ExceedingLimits = false;
            Helpers.CenterString(this.G, this.Text.ToUpper(), new Font("Segoe UI", 6f, FontStyle.Bold), Color.FromArgb(170, 170, 170), new Rectangle(2, 2, base.Width, base.Height + 27));
        }
    }
}

public class AetherGroupBox : ContainerControl
{
    private Graphics G;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private bool _Footer;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private string _FooterText;

    public bool Footer
    {
        get;
        set;
    }

    public string FooterText
    {
        get;
        set;
    }

    public AetherGroupBox()
    {
        this.DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        this.G.Clear(Color.White);
        using (Pen pen = new Pen(Helpers.ColorFromHex("#F1F5FC")))
        {
            using (SolidBrush solidBrush = new SolidBrush(Helpers.ColorFromHex("#343843")))
            {
                using (Font font = new Font("Segoe UI", 9f))
                {
                    Helpers.DrawRoundRect(this.G, Helpers.FullRectangle(base.Size, true), 6, pen);
                    this.G.DrawString(this.Text, font, solidBrush, new Point(12, 10));
                    this.G.DrawLine(pen, new Point(0, 36), new Point(base.Width, 36));
                }
            }
        }
        bool footer = this.Footer;
        checked
        {
            if (footer)
            {
                using (Pen pen2 = new Pen(Helpers.ColorFromHex("#F5F5F5")))
                {
                    using (SolidBrush solidBrush2 = new SolidBrush(Helpers.ColorFromHex("#7A7E89")))
                    {
                        using (Font font2 = new Font("Segoe UI", 9f))
                        {
                            this.G.DrawLine(pen2, new Point(0, base.Height - 35), new Point(base.Width, base.Height - 35));
                            this.G.DrawString(this.FooterText, font2, solidBrush2, new Point(12, base.Height - 27));
                        }
                    }
                }
            }
        }
    }
}

[DefaultEvent("CheckedChanged")]
public class AetherRadioButton : Control
{
    public delegate void CheckedChangedEventHandler(object sender, EventArgs e);

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private AetherRadioButton.CheckedChangedEventHandler CheckedChangedEvent;

    private Graphics G;

    private Helpers.MouseState State;

    private bool _Checked;

    private bool _EnabledCalc;

    public event AetherRadioButton.CheckedChangedEventHandler CheckedChanged
    {
        [CompilerGenerated]
        add
        {
            AetherRadioButton.CheckedChangedEventHandler checkedChangedEventHandler = this.CheckedChangedEvent;
            AetherRadioButton.CheckedChangedEventHandler checkedChangedEventHandler2;
            do
            {
                checkedChangedEventHandler2 = checkedChangedEventHandler;
                AetherRadioButton.CheckedChangedEventHandler value2 = (AetherRadioButton.CheckedChangedEventHandler)Delegate.Combine(checkedChangedEventHandler2, value);
                checkedChangedEventHandler = Interlocked.CompareExchange<AetherRadioButton.CheckedChangedEventHandler>(ref this.CheckedChangedEvent, value2, checkedChangedEventHandler2);
            }
            while (checkedChangedEventHandler != checkedChangedEventHandler2);
        }
        [CompilerGenerated]
        remove
        {
            AetherRadioButton.CheckedChangedEventHandler checkedChangedEventHandler = this.CheckedChangedEvent;
            AetherRadioButton.CheckedChangedEventHandler checkedChangedEventHandler2;
            do
            {
                checkedChangedEventHandler2 = checkedChangedEventHandler;
                AetherRadioButton.CheckedChangedEventHandler value2 = (AetherRadioButton.CheckedChangedEventHandler)Delegate.Remove(checkedChangedEventHandler2, value);
                checkedChangedEventHandler = Interlocked.CompareExchange<AetherRadioButton.CheckedChangedEventHandler>(ref this.CheckedChangedEvent, value2, checkedChangedEventHandler2);
            }
            while (checkedChangedEventHandler != checkedChangedEventHandler2);
        }
    }

    public bool Checked
    {
        get
        {
            return this._Checked;
        }
        set
        {
            this._Checked = value;
            base.Invalidate();
        }
    }

    public new bool Enabled
    {
        get
        {
            return this.EnabledCalc;
        }
        set
        {
            this._EnabledCalc = value;
            bool enabled = this.Enabled;
            if (enabled)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
            base.Invalidate();
        }
    }

    [DisplayName("Enabled")]
    public bool EnabledCalc
    {
        get
        {
            return this._EnabledCalc;
        }
        set
        {
            this.Enabled = value;
            base.Invalidate();
        }
    }

    public AetherRadioButton()
    {
        this.DoubleBuffered = true;
        this.Enabled = true;
        this.Cursor = Cursors.Hand;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            using (Pen pen = new Pen(Helpers.ColorFromHex("#C8C8C8")))
            {
                this.G.DrawEllipse(pen, new Rectangle(0, 0, 18, 18));
            }
            using (SolidBrush solidBrush = new SolidBrush(Helpers.ColorFromHex("#343843")))
            {
                this.G.DrawString(this.Text, new Font("Segoe UI", 9f), solidBrush, new Point(25, 1));
            }
            bool flag = this.State == Helpers.MouseState.Over | this.State == Helpers.MouseState.Down;
            if (flag)
            {
                using (Pen pen2 = new Pen(Helpers.ColorFromHex("#8C92A1")))
                {
                    this.G.DrawEllipse(pen2, new Rectangle(0, 0, 18, 18));
                }
            }
        }
        else
        {
            using (Pen pen3 = new Pen(Helpers.ColorFromHex("#DCDCDC")))
            {
                this.G.DrawEllipse(pen3, new Rectangle(0, 0, 18, 18));
            }
            using (SolidBrush solidBrush2 = new SolidBrush(Helpers.ColorFromHex("#989CA7")))
            {
                this.G.DrawString(this.Text, new Font("Segoe UI", 9f), solidBrush2, new Point(25, 1));
            }
        }
        bool @checked = this.Checked;
        if (@checked)
        {
            bool enabled2 = this.Enabled;
            if (enabled2)
            {
                using (HatchBrush hatchBrush = new HatchBrush(HatchStyle.WideUpwardDiagonal, Helpers.ColorFromHex("#5B606F"), Helpers.ColorFromHex("#525766")))
                {
                    using (Pen pen4 = new Pen(Helpers.ColorFromHex("#474C5A")))
                    {
                        this.G.FillEllipse(hatchBrush, new Rectangle(4, 4, 10, 10));
                        this.G.DrawEllipse(pen4, new Rectangle(4, 4, 10, 10));
                    }
                }
            }
            else
            {
                using (HatchBrush hatchBrush2 = new HatchBrush(HatchStyle.WideUpwardDiagonal, Helpers.ColorFromHex("#8C92A1"), Helpers.ColorFromHex("#7A7F8E")))
                {
                    using (Pen pen5 = new Pen(Helpers.ColorFromHex("#797E8C")))
                    {
                        this.G.FillEllipse(hatchBrush2, new Rectangle(4, 4, 10, 10));
                        this.G.DrawEllipse(pen5, new Rectangle(4, 4, 10, 10));
                    }
                }
            }
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        base.Size = new Size(base.Width, 19);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            try
            {
                IEnumerator enumerator = base.Parent.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Control control = (Control)enumerator.Current;
                    bool flag = control is AetherRadioButton;
                    if (flag)
                    {
                        ((AetherRadioButton)control).Checked = false;
                    }
                }
            }
            finally
            {

            }
            this.Checked = !this.Checked;
            AetherRadioButton.CheckedChangedEventHandler checkedChangedEvent = this.CheckedChangedEvent;
            if (checkedChangedEvent != null)
            {
                checkedChangedEvent(this, e);
            }
            this.State = Helpers.MouseState.Over;
            base.Invalidate();
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            this.State = Helpers.MouseState.Down;
            base.Invalidate();
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            this.State = Helpers.MouseState.Over;
            base.Invalidate();
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        bool enabled = this.Enabled;
        if (enabled)
        {
            this.State = Helpers.MouseState.None;
            base.Invalidate();
        }
    }
}
public class AetherTag : Control
{
    private Graphics G;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private Color _Background;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private Color _Border;

    [DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
    private Color _TextColor;

    public Color Background
    {
        get;
        set;
    }

    public Color Border
    {
        get;
        set;
    }

    public Color TextColor
    {
        get;
        set;
    }

    public AetherTag()
    {
        this.Background = Helpers.ColorFromHex("#424452");
        this.Border = Helpers.ColorFromHex("#323541");
        this.TextColor = Helpers.ColorFromHex("#7C8290");
        this.DoubleBuffered = true;
        this.Text = "Tag";
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        using (SolidBrush solidBrush = new SolidBrush(this.Background))
        {
            using (Pen pen = new Pen(this.Border))
            {
                using (SolidBrush solidBrush2 = new SolidBrush(this.TextColor))
                {
                    this.G.FillRectangle(solidBrush, Helpers.FullRectangle(base.Size, true));
                    Helpers.DrawRoundRect(this.G, Helpers.FullRectangle(base.Size, true), 3, pen);
                    bool flag = Versioned.IsNumeric(this.Text);
                    if (flag)
                    {
                        using (Font font = new Font("Segoe UI", 8f, FontStyle.Bold))
                        {
                            this.G.DrawString(this.Text, font, solidBrush2, new Point(2, 0));
                        }
                    }
                    else
                    {
                        using (Font font2 = new Font("Segoe UI", 7f, FontStyle.Bold))
                        {
                            this.G.DrawString(this.Text.ToUpper(), font2, solidBrush2, new Point(2, 1));
                        }
                    }
                }
            }
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        base.Size = new Size(base.Width, 15);
    }
}

[DefaultEvent("TextChanged")]
public class AetherTextbox : Control
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never), AccessedThroughProperty("TB"), CompilerGenerated]
    private TextBox _TB;


    private Graphics G;

    private Helpers.MouseState State;

    private bool IsDown;

    private bool _EnabledCalc;

    private bool _allowpassword;

    private int _maxChars;

    private HorizontalAlignment _textAlignment;

    private bool _multiLine;

    private bool _readOnly;

    public virtual TextBox TB
    {
        [CompilerGenerated]
        get
        {
            return this._TB;
        }
        [CompilerGenerated]
        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            EventHandler value2 = delegate(object a0, EventArgs a1)
            {
                this.TextChangeTb();
            };
            TextBox tB = this._TB;
            if (tB != null)
            {
                tB.TextChanged -= value2;
            }
            this._TB = value;
            tB = this._TB;
            if (tB != null)
            {
                tB.TextChanged += value2;
            }
        }
    }

    public new bool Enabled
    {
        get
        {
            return this.EnabledCalc;
        }
        set
        {
            this.TB.Enabled = value;
            this._EnabledCalc = value;
            base.Invalidate();
        }
    }

    [DisplayName("Enabled")]
    public bool EnabledCalc
    {
        get
        {
            return this._EnabledCalc;
        }
        set
        {
            this.Enabled = value;
            base.Invalidate();
        }
    }

    public bool UseSystemPasswordChar
    {
        get
        {
            return this._allowpassword;
        }
        set
        {
            this.TB.UseSystemPasswordChar = this.UseSystemPasswordChar;
            this._allowpassword = value;
            base.Invalidate();
        }
    }

    public int MaxLength
    {
        get
        {
            return this._maxChars;
        }
        set
        {
            this._maxChars = value;
            this.TB.MaxLength = this.MaxLength;
            base.Invalidate();
        }
    }

    public HorizontalAlignment TextAlign
    {
        get
        {
            return this._textAlignment;
        }
        set
        {
            this._textAlignment = value;
            base.Invalidate();
        }
    }

    public bool MultiLine
    {
        get
        {
            return this._multiLine;
        }
        set
        {
            this._multiLine = value;
            this.TB.Multiline = value;
            this.OnResize(EventArgs.Empty);
            base.Invalidate();
        }
    }

    public bool ReadOnly
    {
        get
        {
            return this._readOnly;
        }
        set
        {
            this._readOnly = value;
            bool flag = this.TB != null;
            if (flag)
            {
                this.TB.ReadOnly = value;
            }
        }
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        base.Invalidate();
    }

    protected override void OnBackColorChanged(EventArgs e)
    {
        base.OnBackColorChanged(e);
        base.Invalidate();
    }

    protected override void OnForeColorChanged(EventArgs e)
    {
        base.OnForeColorChanged(e);
        this.TB.ForeColor = this.ForeColor;
        base.Invalidate();
    }

    protected override void OnFontChanged(EventArgs e)
    {
        base.OnFontChanged(e);
        this.TB.Font = this.Font;
    }

    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
        this.TB.Focus();
    }

    private void TextChangeTb()
    {
        this.Text = this.TB.Text;
    }

    private void TextChng()
    {
        this.TB.Text = this.Text;
    }

    public void NewTextBox()
    {
        TextBox tB = this.TB;
        tB.Text = string.Empty;
        tB.BackColor = Color.White;
        tB.ForeColor = Helpers.ColorFromHex("#343843");
        tB.TextAlign = HorizontalAlignment.Left;
        tB.BorderStyle = BorderStyle.None;
        tB.Location = new Point(3, 3);
        tB.Font = new Font("Segoe UI", 9f);
        tB.Size = checked(new Size(base.Width - 3, base.Height - 3));
        tB.UseSystemPasswordChar = this.UseSystemPasswordChar;
    }

    public AetherTextbox()
    {
        base.TextChanged += delegate(object a0, EventArgs a1)
        {
            this.TextChng();
        };
        this.TB = new TextBox();
        this._allowpassword = false;
        this._maxChars = 32767;
        this._multiLine = false;
        this._readOnly = false;
        this.NewTextBox();
        base.Controls.Add(this.TB);
        base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
        this.DoubleBuffered = true;
        this.TextAlign = HorizontalAlignment.Left;
        this.ForeColor = Helpers.ColorFromHex("#343843");
        this.Font = new Font("Segoe UI", 9f);
        base.Size = new Size(130, 29);
        this.Enabled = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        this.G.Clear(Color.White);
        bool enabled = this.Enabled;
        if (enabled)
        {
            this.TB.ForeColor = Helpers.ColorFromHex("#343843");
            bool flag = this.State == Helpers.MouseState.Down;
            if (flag)
            {
                using (Pen pen = new Pen(Helpers.ColorFromHex("#5B606F")))
                {
                    Helpers.DrawRoundRect(this.G, Helpers.FullRectangle(base.Size, true), 3, pen);
                }
            }
            else
            {
                using (Pen pen2 = new Pen(Helpers.ColorFromHex("#C8C8C8")))
                {
                    Helpers.DrawRoundRect(this.G, Helpers.FullRectangle(base.Size, true), 3, pen2);
                }
            }
        }
        else
        {
            this.TB.ForeColor = Helpers.ColorFromHex("#DCDCDC");
            using (Pen pen3 = new Pen(Helpers.ColorFromHex("#E6E6E6")))
            {
                Helpers.DrawRoundRect(this.G, Helpers.FullRectangle(base.Size, true), 3, pen3);
            }
        }
        this.TB.TextAlign = this.TextAlign;
        this.TB.UseSystemPasswordChar = this.UseSystemPasswordChar;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        bool flag = !this.MultiLine;
        checked
        {
            if (flag)
            {
                int height = this.TB.Height;
                this.TB.Location = new Point(10, (int)Math.Round(unchecked((double)base.Height / 2.0 - (double)height / 2.0 - 0.0)));
                this.TB.Size = new Size(base.Width - 20, height);
            }
            else
            {
                this.TB.Location = new Point(10, 10);
                this.TB.Size = new Size(base.Width - 20, base.Height - 20);
            }
        }
    }

    protected override void OnEnter(EventArgs e)
    {
        base.OnEnter(e);
        this.State = Helpers.MouseState.Down;
        base.Invalidate();
    }

    protected override void OnLeave(EventArgs e)
    {
        base.OnLeave(e);
        this.State = Helpers.MouseState.None;
        base.Invalidate();
    }
}