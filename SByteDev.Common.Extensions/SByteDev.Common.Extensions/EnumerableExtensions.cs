using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SByteDev.Common.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence in a collection.
        /// </summary>
        /// <param name="enumerable">The collection to search.</param>
        /// <param name="value">The object to locate.</param>
        /// <returns>The index of the first occurrence of value in array, if found;
        /// otherwise, the lower bound of the array minus 1.</returns>
        /// <exception cref="ArgumentNullException">enumerable is null.</exception>
        public static int IndexOf(this IEnumerable enumerable, object value)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            return enumerable.IndexOf(value, EqualityComparer<object>.Default);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence in a collection.
        /// </summary>
        /// <param name="enumerable">The collection to search.</param>
        /// <param name="value">The object to locate.</param>
        /// <param name="comparer">The comparer to use when locating.</param>
        /// <returns>The index of the first occurrence of value in array, if found;
        /// otherwise, the lower bound of the array minus 1.</returns>
        /// <exception cref="ArgumentNullException">enumerable is null.</exception>
        public static int IndexOf(this IEnumerable enumerable, object value, IEqualityComparer comparer)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            var enumerator = enumerable.GetEnumerator();

            for (var index = 0;; index++)
            {
                if (!enumerator.MoveNext())
                {
                    return -1;
                }

                if (enumerator.Current == null && value == null)
                {
                    return index;
                }

                if (comparer.Equals(enumerator.Current, value))
                {
                    return index;
                }
            }
        }

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence in a collection.
        /// </summary>
        /// <param name="enumerable">The collection to search.</param>
        /// <param name="value">The object to locate.</param>
        /// <typeparam name="T">The collection item type.</typeparam>
        /// <returns>The index of the first occurrence of value in array, if found;
        /// otherwise, the lower bound of the array minus 1.</returns>
        /// <exception cref="ArgumentNullException">enumerable is null.</exception> 
        public static int IndexOf<T>(this IEnumerable<T> enumerable, T value)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            return enumerable.IndexOf(value, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence in a collection.
        /// </summary>
        /// <param name="enumerable">The collection to search.</param>
        /// <param name="value">The object to locate.</param>
        /// <param name="comparer">The comparer to use when locating.</param>
        /// <typeparam name="T">The collection item type.</typeparam>
        /// <returns>The index of the first occurrence of value in array, if found;
        /// otherwise, the lower bound of the array minus 1.</returns>
        /// <exception cref="ArgumentNullException">enumerable is null.</exception>
        public static int IndexOf<T>(this IEnumerable<T> enumerable, T value, IEqualityComparer<T> comparer)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            return enumerable
                       .Select((item, index) => new {Item = item, Index = index})
                       .FirstOrDefault(item => comparer.Equals(item.Item, value))?.Index ?? -1;
        }

        /// <summary>
        /// Returns a specified number of contiguous elements from the specified index.
        /// </summary>
        /// <param name="enumerable">The collection to take.</param>
        /// <param name="index">The starting index.</param>
        /// <param name="length">The count of elements to take.</param>
        /// <typeparam name="T">The collection item type</typeparam>
        /// <returns>A collection that contains the specified number of elements from the starting index.</returns>
        /// <exception cref="ArgumentNullException">enumerable is null.</exception>
        public static IEnumerable<T> Take<T>(this IEnumerable<T> enumerable, int index, int length)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            if (enumerable is List<T> list)
            {
                return list.GetRange(index, length);
            }

            return enumerable.Skip(index).Take(length);
        }

        /// <summary>
        /// Indicates whether the specified enumerable is <c>null</c> or has a length of zero.
        /// </summary>
        /// <param name="enumerable">The enumerable to check.</param>
        /// <returns><c>True</c> if the enumerable is <c>null</c> or has a zero length.</returns>
        public static bool IsNullOrEmpty(this IEnumerable enumerable)
        {
            return enumerable?.Count().Equals(0) ?? true;
        }

        /// <summary>
        /// Returns the number of elements in a sequence.
        /// </summary>
        /// <param name="enumerable">A sequence that contains elements to be counted.</param>
        /// <returns>The number of elements in the input sequence.</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        /// <exception cref="OverflowException">The number of elements in source is larger than MaxValue.</exception>
        public static int Count(this IEnumerable enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            if (enumerable is ICollection collection)
            {
                return collection.Count;
            }

            var enumerator = enumerable.GetEnumerator();
            var count = 0;

            while (enumerator.MoveNext())
            {
                count++;
            }

            return count;
        }
    }
}