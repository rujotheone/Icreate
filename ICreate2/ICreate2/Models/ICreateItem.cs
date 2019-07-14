using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ICreate2.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }

        public List<Users> Users { get; set; }

    }
    public class IdeaStatus
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }        
    }    

    public class IdeaMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdeaTypeId { get; set; }
        public IdeaType IdeaType { get; set; }
        public string RenewedBy { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateRenewed { get; set; }
        public string DelFlg { get; set; }
        public string DelBy { get; set; }
        public string Notification { get; set; }
        public string Responsible { get; set; }
        public string ITUnit { get; set; }
        public string SubmittedBy { get; set; }
        public string Attached { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public IdeaStatusList IdeaStatus { get; set; }
        public int ForwardDate { get; set; }
        public string CCAddress { get; set; }
        public string CommentReview { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int BatchNumber { get; set; }
        public string MetricScore { get; set; }
        public double TotalScore { get; set; }

        public ICollection<IdeaAudittrail> IdeaAudittrail { get; set; }
    }

    public class IdeaAudittrail
    {
        [Key]
        public int Id { get; set; }
        public int IdeaId { get; set; }
        public IdeaMaster IdeaMaster { get; set; }
        public string ActionDesc { get; set; }
        public int Actor { get; set; }
        public int Received { get; set; }
        public DateTime AuditDate { get; set; }
    }

    public enum IdeaStatusList
    { submitted, underreview, pending, accepted}

    
    public class Metric
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
    }

    public class IdeaMetric
    {
        [Key]
        public int Idea { get; set; }
        public List <Metric> Metric { get; set; }        
    }

    public class IdeaType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<IdeaMaster> IdeaMaster { get; set; }
    }
    public class BatchHistory
    {
        [Key]
        public int Id { get; set; }
        public int BatchNumber { get; set; }
        public DateTime BatchDateBegin { get; set; }
        public DateTime BatchDateEnd { get; set; }
        public string DelFlg { get; set; }
    }
}