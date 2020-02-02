using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Akavache.Sqlite3;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ReactiveUIDemo.Droid
{
    [Preserve]
    public static class LinkerPreserve
    {
        [SuppressMessage("Design", "CA1065: .cctor creates an exception of type Exception.", Justification = "Deliberate usage")]
        static LinkerPreserve()
        {
            throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
        }
    }
}