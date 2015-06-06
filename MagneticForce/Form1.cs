using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagneticForce
{
    public partial class Form1 : Form
    {
        //30fps で固定
        const float deltaTime = 1.0f / 30.0f;

        class Magnet
        {
            public PointF pos { get; private set; }

            public Rectangle rect { get; private set; }

            public PointF Left
            {
                get
                {
                    return new PointF(rect.Left, rect.Top + rect.Height / 2);
                }
            }

            public PointF Right
            {
                get
                {
                    return new PointF(rect.Right, rect.Top + rect.Height / 2);
                }
            }

            public Rectangle LeftRect { get { return new Rectangle(rect.Left, rect.Top, rect.Width / 2, rect.Height); } }
            public Rectangle RightRect { get { return new Rectangle(rect.Left + rect.Width/2, rect.Top, rect.Width / 2, rect.Height); } }

            public float M { get; set; }

            public Magnet(Rectangle a, float m) 
            {
                rect = a;
                M = m;
            }

            public PointF GetForce(Soul p)
            {
                var attraction = GetVector(p, Left);
                var repulsion = GetVector(p, Right, false);

                return Physics.Add(attraction, repulsion);
            }

            public PointF GetVector(Soul p, PointF p2, bool attract = true)
            {
                var v = Physics.Sub(p2, p.pos);
                var lenSqr = Physics.LengthSqr(v);

                var coef = p.weight * M / lenSqr;

                if (attract)
                {
                    if (Physics.Dot(v, p.vec) < 0)
                        coef *= 2;

                    return Physics.Mul(v, coef);
                }
                else
                {
                    return Physics.Mul(v, -coef);
                }
            }

        }

        class Soul
        {
            //位置ベクトル
            public PointF pos { get; private set; }
            
            //方向ベクトル
            public PointF vec { get; private set; }

            //重さ
            public float weight{get; private set;}

            //経過時間
            public float elapsedTime { get; private set; }

            //速度
            public float speed = 600.0f;

            //加速度
            public static float accel = 800.0f;

            //最初のポップアニメーションの時間
            const float popUpTime = 0.15f;

            const float popStopTime = 0.1f;


            public Soul(PointF a, float s, float w = 1.0f)
            {
                pos = a;
                speed = s;
                weight = w;
                vec = new PointF();
                elapsedTime = 0;
            }

            public void Update(PointF v)
            {
                elapsedTime += deltaTime;

                if(elapsedTime < popUpTime + popStopTime)
                {
                    //var move = (float)Math.Cos(Math.PI * 0.5 * elapsedTime / popUpTime);  //処理は重いが,非線形
                    var move = -(float)Math.Pow( (elapsedTime - popUpTime) / popUpTime, 1); //処理は早いが線形
                    pos = new PointF(pos.X, pos.Y - speed * deltaTime * move );
                    return;
                }

            
                vec = Physics.Normalize(Physics.Add(vec, Physics.Mul(weight, v) ));
                pos = Physics.Add(pos, Physics.Mul(speed * deltaTime, vec));

                speed += accel * deltaTime;
            }

            public bool Reach(PointF p)
            {
                return Physics.Distance(p, pos) < speed * deltaTime;
            }
        }


        class SoulGroup
        {
            public List<Soul> particles { get; private set; }

            public Color color { get; private set; }

            public SoulGroup(List<Soul> list)
            {
                particles = list;

                color = GetColor(particles.Count);
            }

            static Color GetColor(int particleNum)
            {
                int n = particleNum / 10;

                int coef = 155;
                return Color.FromArgb(255, coef * (n & 1), coef * ((n >> 1) & 1), coef * ((n >> 2) & 1));
            }
        }


        //シミュレーション中
        bool underSimulating = false;
        public bool UnderSimulating 
        { 
            get{return underSimulating;}
            set
            {
                underSimulating = value;
                controlPanel.Visible = !underSimulating;
                magBar.M = (float)attractivePower.Value;
            }
        }

        Rectangle Square(PointF p, int size = 15)
        {
            return new Rectangle((int)(p.X - size / 2), (int)(p.Y - size / 2), size, size);
        }

        Magnet magBar;

        
        List<SoulGroup> soulGroups = new List<SoulGroup>();


        Rectangle windowRect = new Rectangle(1, 1, 960, 640);

        public Form1()
        {
            InitializeComponent();
            magBar = new Magnet(new Rectangle(300, 50, 800, 50), (float)attractivePower.Value);
            UnderSimulating = false;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(Color.White);

            //磁石の描画
            g.FillRectangle(Brushes.Red, magBar.LeftRect);
            g.FillRectangle(Brushes.Blue, magBar.RightRect);

            //吸い込み位置の描画
            g.DrawEllipse(Pens.Black, Square(magBar.Left, 50));

            //魂の描画
            foreach (var group in soulGroups)
            {
                var brush = new SolidBrush(group.color);

                foreach (var p in group.particles)
                {
                    g.FillEllipse(brush, Square(p.pos));
                }
            }

            //iPhone画面の描画
            g.DrawRectangle(Pens.Black, windowRect);
        }

        void UpdateTick()
        {
            string num = "";
            foreach (var group in soulGroups)
            {
                group.particles.RemoveAll((Soul p) => { return p.Reach(magBar.Left); });
                foreach (var p in group.particles)
                {
                    var v = magBar.GetForce(p);
                    p.Update(v);
                }
                num += group.particles.Count.ToString() + "\n";
            }
            soulGroups.RemoveAll((SoulGroup l) => { return l.particles.Count == 0; });

            particleNumLabel.Text = num;


            if (allCheck)
                AllDispersal();

            UnderSimulating = soulGroups.Count > 0;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!UnderSimulating)
                return;

            UpdateTick();
            Canvas.Invalidate();
        }

        private void randomPlacementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            List<Soul> particles = new List<Soul>();
            var num = r.Next((int)( maxKill.Value - minKill.Value)) + (int)minKill.Value;
            foreach(var i in Enumerable.Range(0, num))
            {

                var x = r.Next(windowRect.Width) + windowRect.X;
                var y = r.Next(windowRect.Height) + windowRect.Y;

                particles.Add(new Soul(new PointF(x, y), (float)soulSpeed.Value));
            }

            soulGroups.Add( new SoulGroup(particles));

            UnderSimulating = true;

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soulGroups.Clear();
        }

        private void soulAccel_ValueChanged(object sender, EventArgs e)
        {
            Soul.accel = (float)soulAccel.Value;
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            List<Soul> particles = new List<Soul>();
            particles.Add(new Soul(e.Location, (float)soulSpeed.Value));
            soulGroups.Add(new SoulGroup(particles));

            UnderSimulating = true;
        }

        bool allCheck = false;
        int nowWidth = 0;
        void AllDispersal()
        {
            if( soulGroups.Count == 0 )
            {
                int row = 10;
                List<Soul> souls = new List<Soul>();
                foreach (var i in Enumerable.Range(0, row))
                {


                    foreach (var j in Enumerable.Range(0, windowRect.Height))
                    {
                        souls.Add(new Soul(new PointF(i + nowWidth + windowRect.X, j + windowRect.Y), (float)soulSpeed.Value));
                    }
                }
                soulGroups.Add(new SoulGroup(souls));
                nowWidth+=row;
            }
        }

        private void allDispersalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //allCheck = true;            
            //underSimulating = true;       
        }

        private void minKill_ValueChanged(object sender, EventArgs e)
        {
            if (minKill.Value > maxKill.Value)
                maxKill.Value = minKill.Value;
        }

        private void maxKill_ValueChanged(object sender, EventArgs e)
        {
            if (minKill.Value > maxKill.Value)
                minKill.Value = maxKill.Value;
        }


    }
}
