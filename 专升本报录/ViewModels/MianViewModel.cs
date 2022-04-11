using HttpRequest.APICrawler;
using Models.Dtos.UniversityAndMajor;
using Models.Dtos.UniversityDetail;
using Models.Respond;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 专升本报录.ViewModels
{
    public class MianViewModel : BindableBase
    {
        public MianViewModel(CrawlerHelper crawlerHelper)
        {
            this.crawlerHelper = crawlerHelper;

            InitControls();
            InitCommand();
        }

        #region field
        private string search = "";
        private readonly CrawlerHelper crawlerHelper;
        private UniversityAndMajorRespond universityAndMajorRespond;
        private ObservableCollection<ApplyPlanMajorItem> majorList = new();
        private ObservableCollection<UniversityItem> universityList = new();
        private List<RecordsItem> allDataList = new();
        private ObservableCollection<RecordsItem> dataListShow = new();
        private ApplyPlanMajorItem currentSelectedMajor = new();
        private UniversityItem currentSelectedUniversity = new();
        private List<OtherPlanItem> universityToMajor = new();
        #endregion

        #region property

        public DelegateCommand SelectCommand { get; set; }
        public DelegateCommand UpdateDataCommand { get; set; }
        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<RecordsItem> DataListShow
        {
            get { return dataListShow; }
            set { dataListShow = value;RaisePropertyChanged(); }
        }

        public UniversityItem CurrentSelectedUniversity
        {
            get { return currentSelectedUniversity; }
            set { currentSelectedUniversity = value; ShowMajorCombox(); RaisePropertyChanged();}
        }


        public ApplyPlanMajorItem CurrentSelectedMajor
        {
            get { return currentSelectedMajor; }
            set { currentSelectedMajor = value;RaisePropertyChanged(); }
        }


        public ObservableCollection<UniversityItem> UniversityList
        {
            get { return universityList; }
            set { universityList = value;RaisePropertyChanged(); }
        }


        public ObservableCollection<ApplyPlanMajorItem> MajorList
        {
            get { return majorList; }
            set { majorList = value; RaisePropertyChanged(); }
        }
        #endregion
        private void InitCommand()
        {
            SelectCommand = new DelegateCommand(() =>
            {
                ShowData();
            });

            UpdateDataCommand = new DelegateCommand(() =>
            {
                this.allDataList = crawlerHelper.UpdataData();
                ShowData();
            });
        }
        private void InitControls()
        {
            //给两个下拉列表添加全部选择框
            UniversityList.Add(new UniversityItem
            {
                name = "全部",
                id = -1
            });

            MajorList.Add(new ApplyPlanMajorItem
            {
                majorName = "全部",
                majorId = -1
            });

            //获取所有的university对应major信息
            universityToMajor = crawlerHelper.UniversityAndMajorRespond.data.otherPlan;
            //获取所有的院校与专业信息
            universityAndMajorRespond = crawlerHelper.UniversityAndMajorRespond;
            InitUniversityCombox();
            ShowMajorCombox();
            //所有的报录信息
            this.allDataList = crawlerHelper.DataList;
            ShowData();
        }

        private void InitUniversityCombox()
        {
            List<UniversityItem> allUniversity = universityAndMajorRespond.data.university;
            
            List<UniversityItem> tempUniversity = new();
            //universityToMajor

            foreach (var university in allUniversity)
            {
                if(universityToMajor.Find(x => x.universityId == university.id) is not null)
                {
                    tempUniversity.Add(university);
                }
            }

            UniversityList.AddRange(tempUniversity);
            //当前选择的院校
            CurrentSelectedUniversity = UniversityList.FirstOrDefault();
        }

        private void ShowMajorCombox()
        {
            List<ApplyPlanMajorItem> allMajor = universityAndMajorRespond.data.applyPlanMajor;
            List<ApplyPlanMajorItem> tempMajor = new();
            tempMajor.Add(new ApplyPlanMajorItem
            {
                majorName = "全部",
                majorId = -1
            });
            if (CurrentSelectedUniversity.id > 0)
            {
                //根据所学院校招到所有的专业Id
                var majorIds = universityToMajor.FindAll(x => x.universityId == currentSelectedUniversity.id).Select(x=>x.majorId);
                //遍历ids
                tempMajor.AddRange(allMajor.FindAll(x => majorIds.Contains(x.majorId)));
            }
            else
            {
                //选择了全部院校
                tempMajor.AddRange(allMajor);
            }
            MajorList.Clear();
            MajorList.AddRange(tempMajor);
            //当前选择的专业
            CurrentSelectedMajor = MajorList.FirstOrDefault();
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            this.DataListShow.Clear();
            if (!string.IsNullOrEmpty(Search))
            {
                var aboutSearch = allDataList.FindAll(x => x.universityName.Contains(Search) || x.majorName.Contains(Search));
                this.dataListShow.AddRange(aboutSearch);
                if (aboutSearch != null && allDataList.Count is not 0)
                    return;
            }
            //院校下拉框选中全部
            if (CurrentSelectedUniversity.id < 0)
            {
                List<RecordsItem> aboutUniversity = new();
                if (CurrentSelectedMajor.majorId < 0)
                {
                    //专业下拉框选中全部
                    aboutUniversity = allDataList;
                }
                else
                {
                    //选中某个专业
                    aboutUniversity = allDataList.FindAll(x => x.majorId == CurrentSelectedMajor.majorId);
                }
                this.DataListShow.AddRange(aboutUniversity);
                return;
            }
            else
            {
                List<RecordsItem> aboutMajor = allDataList.FindAll(x => x.universityId == CurrentSelectedUniversity.id);
                if (CurrentSelectedMajor.majorId > 0)
                    aboutMajor = aboutMajor.FindAll(x => x.majorId == CurrentSelectedMajor.majorId);
                this.DataListShow.AddRange(aboutMajor);
                return;
            }


            //var aboutUniversity = allDataList.FindAll(x => x.universityName == CurrentSelectedUniversity.name).ToList();
            //var aboutMajor = aboutUniversity.FindAll(x => x.majorName == CurrentSelectedMajor.majorName).ToList();

            //this.DataListShow.AddRange(aboutMajor);
            //this.DataListShow.AddRange(aboutUniversity);
        }
    }
}
