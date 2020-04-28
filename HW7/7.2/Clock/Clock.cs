using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    /// <summary>
    /// Analg circle clock, that displays system time of your PC
    /// </summary>
    public partial class Clock : Form
    {
        private Timer timer = new Timer();

        private const int width = 300;
        private const int height = 300;
        private const int lenghtOfSecondHand = 140;
        private const int lengthOfMinuteHand = 110;
        private const int lengthOfHourHand = 80;

        private int[] centerCoordinate = new int[2] { width / 2, height / 2}; 

        Bitmap bitmap;
        Graphics graphics;

        public Clock()
        {
            InitializeComponent();
            bitmap = new Bitmap(width + 1, height + 1);
            BackGroundInitialize();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        /// <summary>
        /// Draws clock face
        /// </summary>
        private void BackGroundInitialize()
        {
            graphics = Graphics.FromImage(bitmap);
            graphics.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, width, height);

            graphics.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(140, 2));
            graphics.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(286, 140));
            graphics.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(142, 282));
            graphics.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, 140));

            for (int i = 0; i < 12; ++i)
            {
                if (i % 3 == 0)
                {
                    continue;
                }

                int[] coordinateOfStartPoint = CoordinateOfMinuteOrSecondHand(5 * i, 150);
                int[] coordinateOfEndPoint = CoordinateOfMinuteOrSecondHand(5* i, 140);
                graphics.DrawLine(new Pen(Color.Red, 1f), new Point(coordinateOfStartPoint[0], coordinateOfStartPoint[1]), new Point(coordinateOfEndPoint[0], coordinateOfEndPoint[1]));
            }
        }

        /// <summary>
        /// Handler of events by timer, causes each 1000 milliseconds
        /// </summary>
        private void TimerTick(object sender, EventArgs e)
        {
            var newBitmap = (Bitmap)bitmap.Clone();
            graphics = Graphics.FromImage(newBitmap);

            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;


            int[] handCoordinate = new int[2];

            handCoordinate = CoordinateOfMinuteOrSecondHand(second, lenghtOfSecondHand);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(centerCoordinate[0], centerCoordinate[1]), new Point(handCoordinate[0], handCoordinate[1]));

            handCoordinate = CoordinateOfMinuteOrSecondHand(minute, lengthOfMinuteHand);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(centerCoordinate[0], centerCoordinate[1]), new Point(handCoordinate[0], handCoordinate[1]));

            handCoordinate = CoordinateOfHourHand(hour % 12, minute, lengthOfHourHand);
            graphics.DrawLine(new Pen(Color.Gray, 3f), new Point(centerCoordinate[0], centerCoordinate[1]), new Point(handCoordinate[0], handCoordinate[1]));

            Front.Image = newBitmap;
        }

        /// <summary>
        /// Calculates coordinate for minute and second hands
        /// </summary>
        /// <param name="value">Number of minute if seconds</param>
        /// <param name="lengthOfHand">Length of hand</param>
        /// <returns>Coordinate of end point of hands</returns>
        private int[] CoordinateOfMinuteOrSecondHand(int value, int lengthOfHand)
        {
            int[] coordinate = new int[2];
            value *= 6;

            if (value >= 0 && value <= 180)
            {
                coordinate[0] = centerCoordinate[0] + (int)(lengthOfHand * Math.Sin(Math.PI * value / 180));
                coordinate[1] = centerCoordinate[1] - (int)(lengthOfHand * Math.Cos(Math.PI * value / 180));
                return coordinate;
            }

            coordinate[0] = centerCoordinate[0] - (int)(lengthOfHand * -Math.Sin(Math.PI * value / 180));
            coordinate[1] = centerCoordinate[1] - (int)(lengthOfHand * Math.Cos(Math.PI * value / 180));
            return coordinate;
        }

        /// <summary>
        /// Calculates coordinate for hour hand
        /// </summary>
        /// <param name="hourValue">Number of hours</param>
        /// <param name="minuteValue">Number of minutes</param>
        /// <param name="lengthOfHand">Length of hour hand</param>
        /// <returns>Coordinate of end point of hour hand</returns>
        private int[] CoordinateOfHourHand(int hourValue, int minuteValue, int lengthOfHand)
        {
            int[] coordinate = new int[2];

            int value = (int)((hourValue * 30) + (minuteValue * 0.5));

            if (value >= 0 && value <= 180)
            {
                coordinate[0] = centerCoordinate[0] + (int)(lengthOfHand * Math.Sin(Math.PI * value / 180));
                coordinate[1] = centerCoordinate[1] - (int)(lengthOfHand * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                coordinate[0] = centerCoordinate[0] - (int)(lengthOfHand * -Math.Sin(Math.PI * value / 180));
                coordinate[1] = centerCoordinate[1] - (int)(lengthOfHand * Math.Cos(Math.PI * value / 180));
            }
            return coordinate;
        }

    }
}
