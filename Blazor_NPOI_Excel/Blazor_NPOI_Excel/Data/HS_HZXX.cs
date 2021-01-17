using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_NPOI_Excel.Data
{
    public class HS_HZXX
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
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
        /// <summary>
        /// 人员类型
        /// </summary>
        public string persionnel_type { get; set; }
        /// <summary>
        /// id号或住院号
        /// </summary>
        public string id_number_or_hospitalization_number { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string bed_number { get; set; }
        /// <summary>
        /// 送检科室
        /// </summary>
        public string inspection_department { get; set; }
        /// <summary>
        /// 申请医生
        /// </summary>
        public string apply_physician { get; set; }
        /// <summary>
        /// 标本类型
        /// </summary>
        public string specimen_type { get; set; }
        /// <summary>
        /// 标本编号
        /// </summary>
        public string specimen_number { get; set; }
        /// <summary>
        /// 标本状态
        /// </summary>
        public string specimen_status { get; set; }
        /// <summary>
        /// 检验结果
        /// </summary>
        public string test_result { get; set; }
        /// <summary>
        /// 签发时间
        /// </summary>
        public DateTime issuance_time { get; set; }
        /// <summary>
        /// 采样时间
        /// </summary>
        public DateTime sampling_time { get; set; }
        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime receive_time { get; set; }
        /// <summary>
        /// 检验人
        /// </summary>
        public string inspector { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string reviewer { get; set; }
    }
}
