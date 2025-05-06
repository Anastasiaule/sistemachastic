using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace система_частиц
{
    class Particle
    {
        public int Radius; // радуис частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве

        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y
        public float Life; // запас здоровья частицы

        public static Random rand = new Random();

        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            // рассчитываем вектор скорости
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            // а это не трогаем
            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);

        }

        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            // рассчитываем значение альфа канала в шкале от 0 до 255
            // по аналогии с RGB, он используется для задания прозрачности
            int alpha = (int)(k * 255);

            // создаем цвет из уже существующего, но привязываем к нему еще и значение альфа канала
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            // остальное все так же
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public class ParticleColorful : Particle
        {
            public Color FromColor;
            public Color ToColor;

            public static Color MixColor(Color color1, Color color2, float k)
            {
                return Color.FromArgb(
                    (int)(color2.A * k + color1.A * (1 - k)),
                    (int)(color2.R * k + color1.R * (1 - k)),
                    (int)(color2.G * k + color1.G * (1 - k)),
                    (int)(color2.B * k + color1.B * (1 - k))
                );
            }

            public override void Draw(Graphics g)
            {
                // Добавляем расчет прозрачности
                float k = Math.Min(1f, Life / 100);
                int alpha = (int)(k * 255);

                // Смешиваем цвета с учетом альфа-канала
                Color color = MixColor(
                    Color.FromArgb(alpha, FromColor),
                    Color.FromArgb(alpha, ToColor),
                    k
                );

                var b = new SolidBrush(color);
                g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
                b.Dispose();
            }
        }
        public abstract class IImpactPoint
        {
            public float X; // ну точка же, вот и две координаты
            public float Y;

            // абстрактный метод с помощью которого будем изменять состояние частиц
            // например притягивать
            public abstract void ImpactParticle(Particle particle);

            // базовый класс для отрисовки точечки
            public virtual void Render(Graphics g)
            {
                g.FillEllipse(
                        new SolidBrush(Color.Red),
                        X - 5,
                        Y - 5,
                        10,
                        10
                    );
              
            }
        }
       
        public class ColorImpactPoint : IImpactPoint
        {
            public int Radius { get; set; } = 50;
            public Color PointColor { get; set; } = Color.White;

            public override void ImpactParticle(Particle particle)
            {
                float dx = X - particle.X;
                float dy = Y - particle.Y;
                float distance = (float)Math.Sqrt(dx * dx + dy * dy);

                if (distance < Radius && particle is ParticleColorful colorful)
                {
                    colorful.FromColor = PointColor;
                    colorful.ToColor = PointColor;
                }
            }

            public override void Render(Graphics g)
            {
                g.DrawEllipse(new Pen(PointColor), X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
}
