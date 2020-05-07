using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Clock
{
    /// <summary>
    /// Analog circle clock, that displays system time of your PC
    /// </summary>
    public partial class Clock : Form
    {
        private Timer timer = new Timer();

        private const int width = 300;
        private const int height = 300;
        private const int lenghtOfSecondHand = 140;
        private const int lengthOfMinuteHand = 110;
        private const int lengthOfHourHand = 80;

        private Coordinate centerCoordinate; 

        private Bitmap bitmap;
        private Graphics graphics;

        private struct Coordinate
        {
            public int xCoordinate;
            public int yCoordinate;

            public Coordinate(int xCoordinate, int yCoordinate)
            {
                this.xCoordinate = xCoordinate;
                this.yCoordinate = yCoordinate;
            }
        }


        /// <summary>
        /// Basic constructor
        /// </summary>
        public Clock()
        {
            InitializeComponent();
            bitmap = new Bitmap(width + 1, height + 1);
            centerCoordinate = new Coordinate();
            centerCoordinate.xCoordinate = width / 2;
            centerCoordinate.yCoordinate = height / 2;
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

                var coordinateOfStartPoint = CoordinateOfMinuteOrSecondHand(5 * i, 150);
                var coordinateOfEndPoint = CoordinateOfMinuteOrSecondHand(5 * i, 140);
                graphics.DrawLine(new Pen(Color.Red, 1f), new Point(coordinateOfStartPoint.xCoordinate, coordinateOfStartPoint.yCoordinate), new Point(coordinateOfEndPoint.xCoordinate, coordinateOfEndPoint.yCoordinate));
            }

            TimerTick(timer, EventArgs.Empty);
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


            var handCoordinate = new Coordinate();

            handCoordinate = CoordinateOfMinuteOrSecondHand(second, lenghtOfSecondHand);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(centerCoordinate.xCoordinate, centerCoordinate.yCoordinate), new Point(handCoordinate.xCoordinate, handCoordinate.yCoordinate));

            handCoordinate = CoordinateOfMinuteOrSecondHand(minute, lengthOfMinuteHand);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(centerCoordinate.xCoordinate, centerCoordinate.yCoordinate), new Point(handCoordinate.xCoordinate, handCoordinate.yCoordinate));

            handCoordinate = CoordinateOfHourHand(hour % 12, minute, lengthOfHourHand);
            graphics.DrawLine(new Pen(Color.Gray, 3f), new Point(centerCoordinate.xCoordinate, centerCoordinate.yCoordinate), new Point(handCoordinate.xCoordinate, handCoordinate.yCoordinate));

            Front.Image = newBitmap;
        }

        /// <summary>
        /// Calculates coordinate for minute and second hands
        /// </summary>
        /// <param name="value">Number of minute if seconds</param>
        /// <param name="lengthOfHand">Length of hand</param>
        /// <returns>Coordinate of end point of hands</returns>
        private Coordinate CoordinateOfMinuteOrSecondHand(int value, int lengthOfHand)
        {
            var coordinate = new Coordinate();
            value *= 6;

            if (value >= 0 && value <= 180)
            {
                coordinate.xCoordinate = centerCoordinate.xCoordinate + (int)(lengthOfHand * Math.Sin(Math.PI * value / 180));
                coordinate.yCoordinate = centerCoordinate.yCoordinate- (int)(lengthOfHand * Math.Cos(Math.PI * value / 180));
                return coordinate;
            }

            coordinate.xCoordinate = centerCoordinate.xCoordinate - (int)(lengthOfHand * -Math.Sin(Math.PI * value / 180));
            coordinate.yCoordinate = centerCoordinate.yCoordinate - (int)(lengthOfHand * Math.Cos(Math.PI * value / 180));
            return coordinate;
        }

        /// <summary>
        /// Calculates coordinate for hour hand
        /// </summary>
        /// <param name="hourValue">Number of hours</param>
        /// <param name="minuteValue">Number of minutes</param>
        /// <param name="lengthOfHand">Length of hour hand</param>
        /// <returns>Coordinate of end point of hour hand</returns>
        private Coordinate CoordinateOfHourHand(int hourValue, int minuteValue, int lengthOfHand)
        {
            var coordinate = new Coordinate();

            int value = (int)((hourValue * 30) + (minuteValue * 0.5));

            if (value >= 0 && value <= 180)
            {
                coordinate.xCoordinate = centerCoordinate.xCoordinate + (int)(lengthOfHand * Math.Sin(Math.PI * value / 180));
                coordinate.yCoordinate = centerCoordinate.yCoordinate - (int)(lengthOfHand * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                coordinate.xCoordinate = centerCoordinate.xCoordinate - (int)(lengthOfHand * -Math.Sin(Math.PI * value / 180));
                coordinate.yCoordinate = centerCoordinate.yCoordinate - (int)(lengthOfHand * Math.Cos(Math.PI * value / 180));
            }
            return coordinate;
        }

    }
}
