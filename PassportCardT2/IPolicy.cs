using System;

namespace TestRating
{

    public interface IPolicy
    {
        public PolicyType PolicyType { get; }
        #region General Policy Prop
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public decimal Rating {  get; set; }
        #endregion

        public void Rate();
       

     
    }
}
