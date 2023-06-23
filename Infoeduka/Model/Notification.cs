using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoeduka.Model
{
    internal class Notification
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Course { get; set; }
        public string Message { get; set; }

        public static string setForFileLine(Notification notification)
            => notification.Title + "|" + notification.DateTime.ToString() + "|"
            + notification.Course + "|" + notification.Message;

        public override string ToString() => $"{Title}";
    }
}
