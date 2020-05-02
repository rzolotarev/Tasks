using System;
using System.Collections.Generic;
using System.Security;

namespace Meetings
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstCalendar = new List<Tuple<TimeSpan, TimeSpan>>()
            {
                Tuple.Create(TimeSpan.Parse("9:00"), TimeSpan.Parse("10:30")),
                Tuple.Create(TimeSpan.Parse("12:00"), TimeSpan.Parse("13:00")),
                Tuple.Create(TimeSpan.Parse("16:00"), TimeSpan.Parse("18:00"))
            };
            var firstBound = Tuple.Create(TimeSpan.Parse("9:00"), TimeSpan.Parse("20:00"));
            var secondCalendar = new List<Tuple<TimeSpan, TimeSpan>>()
            {
                Tuple.Create(TimeSpan.Parse("10:00"), TimeSpan.Parse("11:30")),
                Tuple.Create(TimeSpan.Parse("12:30"),  TimeSpan.Parse("14:30")),
                Tuple.Create(TimeSpan.Parse("14:30"), TimeSpan.Parse("15:00")),
                Tuple.Create(TimeSpan.Parse("16:00"), TimeSpan.Parse("17:00"))
            };
            var secondBound = Tuple.Create(TimeSpan.Parse("10:00"), TimeSpan.Parse("18:30"));
            var oneBookedList = GetOneBookedList(firstBound, secondBound, firstCalendar, secondCalendar);
            var mergedBook = GetMergedBookedList(oneBookedList);
            var freeSlots = GetNotOccupiedSegments(mergedBook, TimeSpan.Parse("0:30"), 3);
            foreach (var freeSlot in freeSlots)
            {
                Console.WriteLine($"[{freeSlot.Item1}, {freeSlot.Item2}]");
            }
        }

        private static List<Tuple<TimeSpan, TimeSpan>> GetOneBookedList
            (Tuple<TimeSpan, TimeSpan> firstBound, Tuple<TimeSpan, TimeSpan> secondBound,
            List<Tuple<TimeSpan, TimeSpan>> firstCalendar, List<Tuple<TimeSpan, TimeSpan>> secondCalendar)
        {
            var oneBookedList = new List<Tuple<TimeSpan, TimeSpan>>();

            oneBookedList.Add(firstBound.Item1.TotalMinutes < secondBound.Item1.TotalMinutes
                ? Tuple.Create(firstBound.Item1, secondBound.Item1)
                : Tuple.Create(secondBound.Item1, firstBound.Item1));


            var fi = 0;
            var si = 0;
            while (fi < firstCalendar.Count || si < secondCalendar.Count)
            {
                if (firstCalendar[fi].Item1 == secondCalendar[si].Item1)
                {
                    oneBookedList.Add(firstCalendar[fi++]);
                    oneBookedList.Add(secondCalendar[si++]);
                    continue;
                }

                if (firstCalendar[fi].Item1 >= secondCalendar[si].Item1)
                    oneBookedList.Add(secondCalendar[si++]);
                else
                    oneBookedList.Add(firstCalendar[fi++]);
            }

            oneBookedList.Add(firstBound.Item2.TotalMinutes > secondBound.Item2.TotalMinutes
                ? Tuple.Create(secondBound.Item2, firstBound.Item2)
                : Tuple.Create(firstBound.Item2, secondBound.Item2));

            return oneBookedList;
        }

        private static List<Tuple<TimeSpan, TimeSpan>> GetMergedBookedList(List<Tuple<TimeSpan, TimeSpan>> oneBookedList)
        {
            var mergeBookedList = new List<Tuple<TimeSpan, TimeSpan>>() { Tuple.Create(oneBookedList[0].Item1, oneBookedList[0].Item2)};
            var iteration = 0;
            for (var bookItemIndex = 0; bookItemIndex < oneBookedList.Count - 1; bookItemIndex++)
            {
                if (oneBookedList[bookItemIndex + 1].Item1 <= oneBookedList[bookItemIndex].Item2)
                {
                    mergeBookedList[iteration] = Tuple.Create(mergeBookedList[iteration].Item1,
                        oneBookedList[bookItemIndex].Item2 > oneBookedList[bookItemIndex + 1].Item2 ? oneBookedList[bookItemIndex].Item2 :
                            oneBookedList[bookItemIndex + 1].Item2);

                    continue;
                }
                
                if (oneBookedList[bookItemIndex + 1].Item1 > oneBookedList[bookItemIndex].Item2)
                {
                    mergeBookedList.Add(oneBookedList[bookItemIndex + 1]);
                    iteration++;
                }
            }

            return mergeBookedList;
        }

        private static List<Tuple<TimeSpan, TimeSpan>> GetNotOccupiedSegments(List<Tuple<TimeSpan, TimeSpan>> merged, TimeSpan interval, int times)
        {
            var notOccupied = new List<Tuple<TimeSpan, TimeSpan>>();
            for (var i = 0; i < merged.Count - 1; i++)
            {
                if (merged[i + 1].Item1 - merged[i].Item2 >= interval)
                {
                    notOccupied.Add(Tuple.Create(merged[i].Item2, merged[i+1].Item1));
                    if (notOccupied.Count == times)
                        break;
                }
            }

            return notOccupied;
        }
    }
}
