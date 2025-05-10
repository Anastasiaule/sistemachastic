using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static система_частиц.Particle;

namespace система_частиц
{
    class Emitter
    {
        public int Width { get; set; }
        public int ParticlesCount = 00;
        public List<Particle> particles = new List<Particle>();
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 1;
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();
        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 90; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 20; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы


        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;
            foreach (var particle in particles)
            {
                
                // если здоровье кончилось
                if (particle.Life < 1)
                {

                    ResetParticle(particle);
                    if (particlesToCreate > 1)
                    {
                        /* у нас как сброс частицы равносилен созданию частицы */
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {
                    /* теперь двигаю вначале */
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    particle.Life -= 1;
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;


                }
            }
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }


        public virtual void Render(Graphics g)
        {
            // ну тут так и быть уж сам впишу...
            // это то же самое что на форме в методе Render
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach (var point in impactPoints) // тут теперь  impactPoints
            {

                point.Render(g); // это добавили
            }
        }
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }
        public class TopEmitter : Emitter
        {

            public override void ResetParticle(Particle particle)
            {
                base.ResetParticle(particle);

                // 4. Жесткая установка белого цвета
                if (particle is ParticleColorful colorful)
                {
                    particle.X = Particle.rand.Next(Width); // спаун по всей ширине
                    particle.Y = 0; // сверху
                    particle.SpeedY = 1 + Particle.rand.Next(3); // падение вниз
                    colorful.FromColor = Color.White;
                    colorful.ToColor = Color.Black;
                    particle.Life = 100;
                }
            }
           

        }
        public class CenterEmitter : Emitter
        {
            public override void ResetParticle(Particle particle)
            {
                if (impactPoints.Count == 0) return;

                // Берём случайную точку из списка
                var point = impactPoints[Particle.rand.Next(impactPoints.Count)] as ColorImpactPoint;
                if (point == null) return;

                // Спауним частицу в центре точки
                particle.X = point.X;
                particle.Y = point.Y;

                // Задаём движение вверх
                particle.SpeedY = 0;
                particle.Life = 100;

                // Если частица цветная, красим её
                if (particle is ParticleColorful colorful)
                {
                    colorful.FromColor = point.PointColor;
                    colorful.ToColor = Color.FromArgb(0, point.PointColor);
                }
            }
        }


    }
}
