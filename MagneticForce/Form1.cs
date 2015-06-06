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

            public float M { get; private set; }

            public Magnet(Rectangle a, float m = 90) 
            {
                rect = a;
                M = m;
            }

            public PointF GetForce(Particle p)
            {
                var attraction = GetVector(p, Left);
                var repulsion = GetVector(p, Right, false);

                return Physics.Add(attraction, repulsion);
            }

            public PointF GetVector(Particle p, PointF p2, bool attract = true)
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

        class Particle
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
            float speed = 600.0f;

            //加速度
            const float accel = 800.0f;

            //最初のポップアニメーションの時間
            const float popUpTime = 0.15f;

            const float popStopTime = 0.1f;

            bool flg;

            public Particle(PointF a, bool f, float w = 1.0f)
            {
                pos = a;
                flg = f;
                weight = w;
                vec = new PointF();
                elapsedTime = 0;
            }

            public void Update(PointF v)
            {
                elapsedTime += deltaTime;

                if(elapsedTime < popUpTime + popStopTime)
                {
                    pos = new PointF(pos.X, pos.Y - speed * deltaTime * (float)Math.Cos(Math.PI * 0.5 * elapsedTime / popUpTime) );
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


        public bool Simulating { get; set; }
        Rectangle Square(PointF p)
        {
            var size = 10;
            return new Rectangle((int)(p.X - size / 2), (int)(p.Y - size / 2), size, size);
        }

        Magnet magBar = new Magnet(new Rectangle (300, 50, 800, 50));


        List<Particle> particles = new List<Particle>();

        public Form1()
        {
            InitializeComponent();
            Simulating = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(Color.White);

            g.FillRectangle(Brushes.Red, magBar.LeftRect);
            g.FillRectangle(Brushes.Blue, magBar.RightRect);
            foreach(var p in particles)
            {
                g.FillEllipse(Brushes.Black, Square(p.pos));
            }
        }

        void UpdateTick()
        {
            particles.RemoveAll((Particle p) => { return p.Reach(magBar.Left); });
            foreach(var p in particles)
            {
                var v = magBar.GetForce(p);
                p.Update(v);
            }

            particleNumLabel.Text = particles.Count.ToString();
            Simulating = particles.Count > 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Simulating)
                return;

            UpdateTick();
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Simulating)
                return;

            particles.Add(new Particle(e.Location, e.X < magBar.pos.X));
            Invalidate();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulating = true;
        }

        private void randomPlacementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Simulating)
                return;

            Random r = new Random();
            foreach(var i in Enumerable.Range(0, 100))
            {

                var x = r.Next(this.Width);
                var y = r.Next(this.Height);

                particles.Add(new Particle(new PointF(x, y), x < magBar.pos.X));
            }

            Invalidate();
        }
    }
}
