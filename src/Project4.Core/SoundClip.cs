using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Threading.Channels;

namespace Project4.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class SoundClip
    {
        private double defaultChance = 0;
        private Random randomPicker;
        public string name { get; private set; } = "";
        public string path { get; private set; } = "";
        public string time { get; private set; } = "";
        public int timesPlayed { get; private set; } = 0;
        public double percentage { get; private set; }
        private double chance;
        public string timesetType { get; private set; } = "";
        public int timeset { get; private set; } // Default time is 100 deciseconds per sec, 6.000 for min, 360.000 hour

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="percentage"></param>
        /// <param name="timeset"></param>
        public SoundClip(string name, string path, double percentage, int timeset)
        {
            this.name = name;
            this.path = path;
            this.randomPicker = new Random();
            this.percentage = percentage;
            this.timeset = timeset;
            if (timeset == 100)
                timesetType = "sec";
            if (timeset == 6000)
                timesetType = "min";
            if (timeset == 360000)
                timesetType = "hour";
            this.chance = this.percentage / timeset;
            this.defaultChance = 1 / timeset;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start(CancellationTokenSource stopToken)
        {
            int miliSecond = 0;
            int second = 0;
            int minute = 0;
            int hour = 0;
            int amountInSecond = 0;
            int totalAmount = 0;

            while (!stopToken.IsCancellationRequested)
            {
                miliSecond++;
                Thread.SpinWait(250000); // Ensures decisecond wait time
                //Thread.Sleep(1);

                double chanceCheck = randomPicker.NextDouble();

                // Over time change the adjustment to make it harder if sound has been played but weaker if it has not
                if (chanceCheck <= chance)
                {
                    PlaySoundTest.PlaySound(this.path);
                    this.timesPlayed++;
                    amountInSecond++;
                    totalAmount++;
                    chance = chance - (defaultChance * randomPicker.NextDouble()); // Lower the fract, the lower the standard dev
                }
                else
                    chance = chance + (defaultChance / 10 * randomPicker.NextDouble()); // Lower the fract, the lower the average

                // Time handling
                if (miliSecond == 100)
                {
                    second++;
                    miliSecond = 0;
                    amountInSecond = 0;
                }
                if (second == 60)
                {
                    minute++;
                    second = 0;
                }
                if (minute == 60)
                {
                    hour++;
                    minute = 0;
                }

                // Update time
                this.time = $"{hour}:{minute}:{second}";
            }
        }

        public override string ToString()
        {
            return $"|| {this.name} || {this.time} || {this.timesPlayed} || {this.percentage} || {this.timesetType} || {this.path} ||";
        }
    }
}
