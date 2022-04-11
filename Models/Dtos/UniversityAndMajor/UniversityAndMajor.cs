using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.UniversityAndMajor
{
    public class Enlist_typeItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 在校期间入伍
        /// </summary>
        public string name { get; set; }
    }

    public class OtherPlanMajorItem
    {
        /// <summary>
        /// 经济学
        /// </summary>
        public string majorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string majorId { get; set; }
    }

    public class Examinee_typeItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 普通考生
        /// </summary>
        public string name { get; set; }
    }

    public class Politic_countenanceItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 中共党员
        /// </summary>
        public string name { get; set; }
    }

    public class EnlistPlanItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string universityId { get; set; }
        /// <summary>
        /// 经济学
        /// </summary>
        public string majorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string majorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string majorId { get; set; }
    }

    public class UniversityItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 长江大学
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 本科
        /// </summary>
        public string level { get; set; }
    }

    public class ApplyPlanMajorItem
    {
        /// <summary>
        /// 经济学
        /// </summary>
        public string majorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long majorId { get; set; }
    }

    public class ParamsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string value { get; set; }
    }

    public class Graduate_typeItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 应届毕业生
        /// </summary>
        public string name { get; set; }
    }

    public class CollegeMajorItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 作物生产技术
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
    }

    public class ApplyPlanItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string universityId { get; set; }
        /// <summary>
        /// 经济学
        /// </summary>
        public string majorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string majorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string majorId { get; set; }
    }

    public class National_standardItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 汉族
        /// </summary>
        public string name { get; set; }
    }

    public class OtherPlanItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long universityId { get; set; }
        /// <summary>
        /// 经济学
        /// </summary>
        public string majorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string majorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long majorId { get; set; }
    }

    public class OtherUniversityItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string universityId { get; set; }
        /// <summary>
        /// 长江大学
        /// </summary>
        public string universityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string universityCode { get; set; }
    }

    public class EnlistUniversityItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string universityId { get; set; }
        /// <summary>
        /// 长江大学
        /// </summary>
        public string universityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string universityCode { get; set; }
    }

    public class AnnouncementItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 考生须知（请考生在填报前务必阅读！）
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
    }

    public class ApplyUniversityItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string universityId { get; set; }
        /// <summary>
        /// 长江大学
        /// </summary>
        public string universityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string universityCode { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Enlist_typeItem> enlist_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OtherPlanMajorItem> otherPlanMajor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Examinee_typeItem> examinee_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Politic_countenanceItem> politic_countenance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<EnlistPlanItem> enlistPlan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<UniversityItem> university { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ApplyPlanMajorItem> applyPlanMajor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ParamsItem> @params { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Graduate_typeItem> graduate_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CollegeMajorItem> collegeMajor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ApplyPlanItem> applyPlan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<National_standardItem> national_standard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OtherPlanItem> otherPlan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OtherUniversityItem> otherUniversity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<EnlistUniversityItem> enlistUniversity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AnnouncementItem> announcement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ApplyUniversityItem> applyUniversity { get; set; }
    }


}
