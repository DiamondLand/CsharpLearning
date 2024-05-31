using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeGame
{
    public partial class MainWindow : Window
    {
        private const int CellSize = 20;
        private const int BoardWidth = 20;
        private const int BoardHeight = 20;
        private readonly SolidColorBrush _snakeColor = Brushes.Green;
        private readonly SolidColorBrush _foodColor = Brushes.Red;
        private readonly SolidColorBrush _boardColor = Brushes.LightGray;
        private readonly List<Point> _snake = new List<Point>();
        private Point _food;
        private enum Direction { Up, Down, Left, Right }
        private Direction _snakeDirection = Direction.Right;
        private readonly DispatcherTimer _gameTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
            _gameTimer.Tick += GameTick;
            _gameTimer.Interval = TimeSpan.FromMilliseconds(100);
            _gameTimer.Start();
        }

        private void InitializeGame()
        {
            DrawBoard();
            ResetSnake();
            GenerateFood();
            DrawSnake();
            DrawFood();
        }

        private void DrawBoard()
        {
            for (int x = 0; x < BoardWidth; x++)
            {
                for (int y = 0; y < BoardHeight; y++)
                {
                    var rectangle = new Rectangle
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Fill = _boardColor,
                        Stroke = Brushes.White
                    };
                    Canvas.SetLeft(rectangle, x * CellSize);
                    Canvas.SetTop(rectangle, y * CellSize);
                    GameCanvas.Children.Add(rectangle);
                }
            }
        }

        private void ResetSnake()
        {
            _snake.Clear();
            _snake.Add(new Point(5, 5));
            _snake.Add(new Point(4, 5));
            _snake.Add(new Point(3, 5));
        }

        private void DrawSnake()
        {
            foreach (var segment in _snake)
            {
                DrawCell(segment, _snakeColor);
            }
        }

        private void DrawFood()
        {
            DrawCell(_food, _foodColor);
        }

        private void DrawCell(Point cell, SolidColorBrush color)
        {
            var rectangle = new Rectangle
            {
                Width = CellSize,
                Height = CellSize,
                Fill = color
            };
            Canvas.SetLeft(rectangle, cell.X * CellSize);
            Canvas.SetTop(rectangle, cell.Y * CellSize);
            GameCanvas.Children.Add(rectangle);
        }

        private void GenerateFood()
        {
            var random = new Random();
            do
            {
                _food = new Point(random.Next(BoardWidth), random.Next(BoardHeight));
            } while (_snake.Contains(_food));
        }

        private void GameTick(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            DrawSnake();
            DrawFood();
        }

        private void MoveSnake()
        {
            var head = _snake[0];
            switch (_snakeDirection)
            {
                case Direction.Up:
                    head.Y--;
                    break;
                case Direction.Down:
                    head.Y++;
                    break;
                case Direction.Left:
                    head.X--;
                    break;
                case Direction.Right:
                    head.X++;
                    break;
            }

            _snake.Insert(0, head);
            if (head != _food)
            {
                _snake.RemoveAt(_snake.Count - 1);
            }
            else
            {
                GenerateFood();
            }
        }

        private void CheckCollision()
        {
            var head = _snake[0];
            if (head.X < 0 || head.X >= BoardWidth || head.Y < 0 || head.Y >= BoardHeight || _snake.IndexOf(head, 1) != -1)
            {
                _gameTimer.Stop();
                MessageBox.Show("Game Over!");
                InitializeGame();
                _gameTimer.Start();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (_snakeDirection != Direction.Down)
                        _snakeDirection = Direction.Up;
                    break;
                case Key.Down:
                    if (_snakeDirection != Direction.Up)
                        _snakeDirection = Direction.Down;
                    break;
                case Key.Left:
                    if (_snakeDirection != Direction.Right)
                        _snakeDirection = Direction.Left;
                    break;
                case Key.Right:
                    if (_snakeDirection != Direction.Left)
                        _snakeDirection = Direction.Right;
                    break;
            }
        }
    }
}
