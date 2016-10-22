using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string d1 = "1967-02-29".Remove(0,5);
            string d2 = "2016-02-29".Remove(0,5);
            MessageBox.Show(d1 + "|" + d2);
            MessageBox.Show((d1 == d2).ToString()); 
            //MessageBox.Show(calendarChineseLunisolarToSolar("1967-02-29"));
        }
        /// <summary>
        /// 将  农历(阴历)   转换为   公历(阳历,西历)
        ///    如果传入的参数中的年份是润年，需要另外进行加上润月的天数，简单测试，但没有做过多的测试，不知是否完全正确 
        /// 
        ///    DateTime dt = Convert.ToDateTime("2010-05-21 00:00:00");
        ///    MessageBox.Show(calendarChineseLunisolarToSolar(dt).ToString());
        ///    
        /// </summary>
        /// 
        public static DateTime calendarChineseLunisolarToSolar(DateTime ChineseLunisolarDateTime) {
            System.Globalization.ChineseLunisolarCalendar cal = new System.Globalization.ChineseLunisolarCalendar();

            if (ChineseLunisolarDateTime.Year < 1902 || ChineseLunisolarDateTime.Year > 2100)
                throw new Exception("只支持1902〜2100期间的农历年");

            DateTime dt = cal.ToDateTime(ChineseLunisolarDateTime.Year, ChineseLunisolarDateTime.Month, ChineseLunisolarDateTime.Day, 0, 0, 0, 0);

            //检测是否含有润月
            int leapMonth = cal.GetLeapMonth(ChineseLunisolarDateTime.Year);

            int leapMonthInDays = 0;
            if (leapMonth > 0) {
                //有润月，则读到这个润月里面的天数
                leapMonthInDays = cal.GetDaysInMonth(ChineseLunisolarDateTime.Year, ChineseLunisolarDateTime.Month);
            }

            dt = dt.AddDays(leapMonthInDays);

            return dt;
        }









        /// <summary>
        /// 将公历(阳历,西历) 转换为 农历(阴历) 
        /// 
        ///    DateTime dt = Convert.ToDateTime("2010-07-2 00:00:00");
        ///    MessageBox.Show(calendarSolarToChineseLunisolar(dt).ToString());
        ///    
        /// </summary>
        /// 

        public static DateTime calendarSolarToChineseLunisolar(DateTime SolarDateTime) {
            System.Globalization.ChineseLunisolarCalendar cal = new System.Globalization.ChineseLunisolarCalendar();

            int cYear = cal.GetYear(SolarDateTime);
            int cMonth = cal.GetMonth(SolarDateTime);
            int cDay = cal.GetDayOfMonth(SolarDateTime);

            DateTime dt = Convert.ToDateTime(
                                                Convert.ToString(cYear) + "-" +
                                                Convert.ToString(cMonth) + "-" +
                                                Convert.ToString(cDay)
                                            + " 00:00:00");
            return dt;

        }




    }

}
