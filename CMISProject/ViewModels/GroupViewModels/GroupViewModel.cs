using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.ViewModels
{
    //public enum Status
    //{
    //    active, inactive
    //}

    public class GroupViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Group name must be between 2 and 30 characters")]
        [UIHint("Group Name")]
        public string GroupName { get; set; }

        //[Required]
        //[ScaffoldColumn(false)]
        //[DataType(DataType.DateTime)]
        //public DateTime CreatedDate { get; set; }

        //public string CreatedBy { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        //public DateTime? ModifiedDate { get; set; }

        //public string ModifiedBy { get; set; }

        //[StringLength(30, MinimumLength= 2, ErrorMessage="SubgroupName must be between 2 and 30 characters")]
        //[UIHint("Sub-Group Name")]
        //public string Subgroup { get; set; }

        [Required]
        public Status Status { get; set; }
    }

    public class ChangeStatusViewModel
    {
        public string GroupName { get; set; }
        public Status Status { get; set; }
    }

    public class AddMemberViewModel
    {
        public List<SelectMemberViewModel> members { get; set; }
        public Group Group { get; set; }

        public AddMemberViewModel(int id)
        {
            var db = new CMISProject.DAL.CIMSEntities();
            var u = db.Users;
            Group = db.Groups.Find(id);
            foreach (var user in u)
            {
                this.members.Add(new SelectMemberViewModel() { user = user });
            }
            foreach (var groupUser in db.GroupUserRelations.Where(s => s.GroupId == Group.GroupId).ToList())
            {
                var mem = this.members.Find(s => s.user == groupUser.User);
                mem.selected = true;
            }
        }
    }
    public class SelectMemberViewModel
    {
        public User user { get; set; }
        public bool selected { get; set; }
    }
}