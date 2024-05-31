using System;
using System.Windows;
using System.Windows.Shapes;

namespace SierpinskiTriangle
{
    public partial class MainWindow : Window
    {
        private int actionsCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            actionsCount = 0; // Сбрасываем счетчик перед новой отрисовкой
            canvas.Children.Clear(); // Очищаем Canvas перед новой отрисовкой
            DrawSierpinskiTriangle(0, 0, 500, 6);
            actionsCountTextBlock.Text = actionsCount.ToString();
        }

        private void DrawSierpinskiTriangle(double x, double y, double size, int depth)
        {
            actionsCount++; // Увеличиваем счетчик при каждом рекурсивном вызове

            if (depth == 0)
                return;

            double halfSize = size / 2;

            // Вершины треугольника
            Point p1 = new Point(x, y);
            Point p2 = new Point(x + size, y);
            Point p3 = new Point(x + halfSize, y + size * Math.Sqrt(3) / 2);

            // Находим середины сторон треугольника
            Point middle1 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            Point middle2 = new Point((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);
            Point middle3 = new Point((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);

            // Рекурсивно рисуем три подтреугольника
            DrawSierpinskiTriangle(p1.X, p1.Y, halfSize, depth - 1);
            DrawSierpinskiTriangle(middle1.X, middle1.Y, halfSize, depth - 1);
            DrawSierpinskiTriangle(p2.X, p2.Y, halfSize, depth - 1);
            DrawSierpinskiTriangle(middle2.X, middle2.Y, halfSize, depth - 1);
            DrawSierpinskiTriangle(p3.X, p3.Y, halfSize, depth - 1);
            DrawSierpinskiTriangle(middle3.X, middle3.Y, halfSize, depth - 1);

            // Рисуем текущий треугольник
            Polygon triangle = new Polygon();
            triangle.Points.Add(p1);
            triangle.Points.Add(p2);
            triangle.Points.Add(p3);
            triangle.Stroke = System.Windows.Media.Brushes.Black;
            triangle.Fill = System.Windows.Media.Brushes.White;

            canvas.Children.Add(triangle);
        }
    }
}
