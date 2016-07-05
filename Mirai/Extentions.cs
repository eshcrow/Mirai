﻿using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Mirai
{
    static class Extentions
    {
        public static string Substring(this string Source, string Trim)
        {
            return Source.Substring(Trim.Length);
        }

        public static async Task WaitAllAsync(this Task[] Tasks)
        {
            for (int i = 0; i < Tasks.Length; i++)
            {
                if (Tasks[i] != null)
                {
                    await Tasks[i];
                }
            }
        }

        public static bool IsValidUrl(this string Text)
        {
            Uri WebRes;
            return Uri.TryCreate(Text, UriKind.Absolute, out WebRes);
        }

        public static string WebResponse(this string Url, WebHeaderCollection Headers = null)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    WebRequest Request = WebRequest.Create(Url);
                    if (Headers != null)
                    {
                        Request.Headers = Headers;
                    }

                    return new StreamReader(Request.GetResponse().GetResponseStream()).ReadToEnd();
                }
                catch
                {
                }
            }

            return string.Empty;
        }

        public static T Dequeue<T>(this ConcurrentQueue<T> Queue)
        {
            T Result = default(T);
            while (Queue.Count > 0 && !Queue.TryDequeue(out Result)) ;
            return Result;
        }
    }
}