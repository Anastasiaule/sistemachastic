using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static система_частиц.Emitter;
using static система_частиц.Particle;

namespace система_частиц
{
    public partial class Form1 : Form
    {
        private Bitmap backgroundImage;
        private List<ColorImpactPoint> colorPoints = new List<ColorImpactPoint>();
        private Emitter emitter;
        private ColorImpactPoint draggedPoint;
       
        public Form1()
        {


            InitializeComponent();
            emitter = new TopEmitter { /* инициализация */ };
            emitter.impactPoints = colorPoints.Cast<IImpactPoint>().ToList();
            // Инициализация изображения
            backgroundImage = new Bitmap(picDisplay.BackgroundImage);

            // Настройка эмиттера для снега
            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                ParticlesPerTick = 20,
                SpeedMin = 1,
                SpeedMax = 3,
                ColorFrom = Color.White,
                ColorTo = Color.Black,
                X = picDisplay.Width / 2,
                Y = 0
            };

            // Создание 7 точек радуги
            Color[] rainbowColors = {
                Color.Red, Color.Orange, Color.Yellow,
                Color.Green, Color.Blue, Color.Indigo, Color.Violet
            };

            int step = picDisplay.Width / 8;
            for (int i = 1; i <= 7; i++)
            {
                var point = new ColorImpactPoint
                {
                    X = step * i,
                    Y = picDisplay.Height - 300,
                    PointColor = rainbowColors[i - 1],
                    Radius = 30
                };
                colorPoints.Add(point);
                emitter.impactPoints.Add(point);
            }

            // Настройка TrackBar для радиуса
            tbSize.Minimum = 10;
            tbSize.Maximum = 100;
            tbSize.Value = 30;
            tbSize.Scroll += (s, e) =>
                colorPoints.ForEach(p => p.Radius = tbSize.Value);

            // Настройка кнопки для смены цветов

            btnChange.Text = "Случайные цвета";
            btnChange.Click += (s, e) =>
            {
                Random rand = new Random();
                colorPoints.ForEach(p =>
                    p.PointColor = Color.FromArgb(
                        rand.Next(256),
                        rand.Next(256),
                        rand.Next(256))
                );
            };

            btnRainbow.Text = "Вернуться к радуге";
            btnRainbow.Click += (s, e) =>
            {
                for (int i = 0; i < colorPoints.Count; i++)
                {
                    // Присваиваем цвет из массива радуги по порядку
                    colorPoints[i].PointColor = rainbowColors[i];
                }
            };

            picDisplay.MouseDown += PicDisplay_MouseDown;
            picDisplay.MouseMove += PicDisplay_MouseMove;
            picDisplay.MouseUp += PicDisplay_MouseUp;

            btnToggleMode.Text = "Режим фонтана";
            btnToggleMode2.Text = "Режим снега";
        }

        // Таймер для обновления частиц
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // <- ЭТА СТРОКА ОБЯЗАТЕЛЬНА!

            using (var tempBitmap = new Bitmap(backgroundImage))
            using (var g = Graphics.FromImage(tempBitmap))
            {
                emitter.Render(g);
                picDisplay.Image?.Dispose();
                picDisplay.Image = (Bitmap)tempBitmap.Clone();
            }

            picDisplay.Invalidate();
        }

        // Обработчики событий мыши
        private void PicDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var point in colorPoints)
            {
                float dx = e.X - point.X;
                float dy = e.Y - point.Y;
                if (dx * dx + dy * dy < point.Radius * point.Radius)
                {
                    draggedPoint = point;
                    break;
                }
            }
        }

        private void PicDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedPoint != null)
            {
                draggedPoint.X = e.X;
                draggedPoint.Y = e.Y;
            }
        }

        private void PicDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            draggedPoint = null;
        }

        private void tbSize_Scroll(object sender, EventArgs e)
        {

        }



        private void btnToggleMode_Click(object sender, EventArgs e)
        {
            emitter.particles.Clear();
            emitter = new CenterEmitter
            {
                Width = picDisplay.Width,
                ParticlesPerTick = 20,
                SpeedMin = 1,
                SpeedMax = 3,
                ColorFrom = Color.White, // Явно задаём цвет
                ColorTo = Color.Black,
                impactPoints = new List<IImpactPoint>()
            };
           
            emitter.UpdateState();
            // Важно обновить точки воздействия для нового эмиттера
            emitter.impactPoints = colorPoints.Cast<IImpactPoint>().ToList();
        }

        private void btnToggleMode2_Click(object sender, EventArgs e)
        {
            emitter.particles.Clear();
            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                ParticlesPerTick = 20,
                SpeedMin = 1,
                SpeedMax = 3,
              
                X = picDisplay.Width / 2,
                Y = 0,
                impactPoints = new List<IImpactPoint>()
            };
            btnToggleMode.Text = "Режим фонтана";

            emitter.UpdateState();
            // Важно обновить точки воздействия для нового эмиттера
            emitter.impactPoints = colorPoints.Cast<IImpactPoint>().ToList();
        }

        private void picDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}