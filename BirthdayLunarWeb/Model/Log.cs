using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthdayLunarWeb.Model {
    public class Log {
        public Log() {
            this.SendTime = DateTime.Now;
        }
        public int ID { set; get; }
        public DateTime SendTime { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }
    }
}