using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace MouseKeyVisualizer
{
    public static class ConcurrentFile
    {
        private static readonly ConcurrentDictionary<string, ReaderWriterLockSlim> LockDic =
            new ConcurrentDictionary<string, ReaderWriterLockSlim>();

        public static int Count => LockDic.Count;

        public static byte[] ReadAllBytes(string path)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterReadLock();
            try
            {
                return System.IO.File.ReadAllBytes(path);
            }
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

        public static string[] ReadAllLines(string path)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterReadLock();
            try
            {
                return System.IO.File.ReadAllLines(path);
            }
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

        public static string ReadAllText(string path)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterReadLock();
            try
            {
                return System.IO.File.ReadAllText(path);
            }
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

        public static void WriteAllBytes(string path, byte[] bytes)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterWriteLock();
            try
            {
                System.IO.File.WriteAllBytes(path, bytes);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public static void WriteAllLines(string path, IEnumerable<string> contents)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterWriteLock();
            try
            {
                System.IO.File.WriteAllLines(path, contents);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public static void WriteAllText(string path, string contents)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterWriteLock();
            try
            {
                System.IO.File.WriteAllText(path, contents);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public static void AppendAllLines(string path, IEnumerable<string> contents)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterWriteLock();
            try
            {
                System.IO.File.AppendAllLines(path, contents);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public static void AppendAllText(string path, string contents)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterWriteLock();
            try
            {
                System.IO.File.AppendAllText(path, contents);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public static void Delete(string path)
        {
            path = GetFormattedPath(path);
            var cacheLock = LockDic.GetOrAdd(path, new ReaderWriterLockSlim());
            cacheLock.EnterWriteLock();
            try
            {
                System.IO.File.Delete(path);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        private static string GetFormattedPath(string path) => new System.IO.FileInfo(path).FullName;
    }
}
