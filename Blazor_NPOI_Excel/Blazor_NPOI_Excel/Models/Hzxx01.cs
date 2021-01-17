using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_NPOI_Excel.Models
{
    public class Hzxx01
    {
        public string name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int age { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string identity_number { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone_number { get; set; }
        /// <summary>
        /// 现住址
        /// </summary>
        public string current_address { get; set; }
        /// <summary>
        /// 是否去过高风险地区
        /// </summary>
        public int is_high_risk_areas { get; set; }
        /// <summary>
        /// 是否发热
        /// </summary>
        public int is_heat_up { get; set; }
    }
}
