using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyWithMe.Entity;

namespace StudyWithMe.WebUI.ViewModels
{
    public class GroupVideoViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<GroupVideoDetail> GroupVideos { get; set; }
    }
}