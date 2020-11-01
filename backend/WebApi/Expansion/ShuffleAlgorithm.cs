// <copyright file="ShuffleAlgorithm.cs" company="Nilorn Group">
// Copyright (c) Nilorn Group. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Expansion
{
    /// <summary>
    /// Перемещать коллекцию используя алгоритм Фишера и Йейтса
    /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
    /// https://stackoverflow.com/questions/273313/randomize-a-listt
    /// </summary>
    internal static class ShuffleAlgorithm
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
