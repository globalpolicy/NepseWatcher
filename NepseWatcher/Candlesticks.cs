using System;
using System.Collections.Generic;
using System.Text;


namespace NepseWatcher
{
    public class Candlesticks
    {

        /// <summary>
        /// Checks if candle2 is bullishly engulfing candle1
        /// </summary>
        /// <param name="candle1">First candle</param>
        /// <param name="candle2">Second candle</param>
        /// <returns></returns>
        public static bool IsBullishEngulfing(Candle candle1, Candle candle2)
        {
            bool retVal = false;
            if (candle2.IsBullish() && candle1.IsBearish())
            {
                if (candle2.Close > candle1.Open)
                {
                    if (candle2.Open < candle1.Close || candle2.Body > 2 * candle1.Body)
                    {
                        retVal = true;
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// Checks if candle1, candle2 and candle3 form a Morning Star pattern
        /// </summary>
        /// <param name="candle1"></param>
        /// <param name="candle2"></param>
        /// <param name="candle3"></param>
        /// <returns></returns>
        public static bool IsMorningStar(Candle candle1, Candle candle2, Candle candle3)
        {
            bool retVal = false;
            if (candle1.IsBearish() && candle2.IsDoji() && candle3.IsBullish())
            {
                if (candle3.Close > 0.5 * (candle1.Open + candle1.Close)) //if third candle's close is higher than first candle's midpoint. ref: https://tlc.thinkorswim.com/center/reference/Patterns/candlestick-patterns-library/bullish-only/MorningStar
                    retVal = true;
            }
            return retVal;
        }

        /// <summary>
        /// Checks if candle is a hammer or inverted hammer or hanging man or shooting star (all variants of hammer)
        /// </summary>
        /// <param name="candle"></param>
        /// <returns></returns>
        public static bool IsHammer(Candle candle)
        {
            bool retVal = false;

            if (candle.Body <= 0.3 * candle.TotalHeight && (candle.Wick <= candle.Tail / 6 || candle.Tail <= candle.Wick / 6)) //my own definition of a hammer/inverted hammer
                retVal = true;

            return retVal;
        }

        /// <summary>
        /// Checks if candle2 is bearishly engulfing candle1
        /// </summary>
        /// <param name="candle1">First candle</param>
        /// <param name="candle2">Second candle</param>
        /// <returns></returns>
        public static bool IsBearishEngulfing(Candle candle1, Candle candle2)
        {
            bool retVal = false;
            if (candle2.IsBearish() && candle1.IsBullish())
            {
                if (candle2.Open > candle1.Close)
                {
                    if (candle2.Close < candle1.Open || candle2.Body > 2 * candle1.Body)
                    {
                        retVal = true;
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// Checks if candle1, candle2 and candle3 form an Evening Star pattern
        /// </summary>
        /// <param name="candle1"></param>
        /// <param name="candle2"></param>
        /// <param name="candle3"></param>
        /// <returns></returns>
        public static bool IsEveningStar(Candle candle1, Candle candle2, Candle candle3)
        {
            bool retVal = false;
            if (candle1.IsBullish() && candle2.IsDoji() && candle3.IsBearish())
            {
                if (candle3.Close < 0.5 * (candle1.Open + candle1.Close)) //if third candle's close is lower than first candle's midpoint. ref: https://tlc.thinkorswim.com/center/reference/Patterns/candlestick-patterns-library/bearish-only/EveningStar
                    retVal = true;
            }
            return retVal;
        }
    }


    public class Candle
    {
        public float Open { get; set; }
        public float Close { get; set; }
        public float High { get; set; }
        public float Low { get; set; }


        public float Wick
        {
            get
            {
                if (IsBearish())
                    return High - Open;
                else
                    return High - Close;
            }
        }

        public float Tail
        {
            get
            {
                if (IsBearish())
                    return Close - Low;
                else
                    return Open - Low;
            }
        }

        public float Body
        {
            get
            {
                return Math.Abs(Open - Close);
            }
        }

        public float TotalHeight
        {
            get
            {
                return High - Low;
            }
        }

        public Candle(float open, float close, float high, float low)
        {
            Open = open;
            Close = close;
            High = high;
            Low = low;
        }

        public bool IsDoji()
        {
            if (Body < 0.2 * TotalHeight)
                return true;
            else
                return false;
        }

        public bool IsBullish()
        {
            return Open < Close;
        }

        public bool IsBearish()
        {
            return Close < Open;
        }


    }
}
