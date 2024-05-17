namespace TestRating
{

    public interface IPolicy
    {
        #region General Policy Prop
        public PolicyType PolicyType { get; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Rating {  get; set; }
        #endregion

        public decimal Rate();
       

     
    }
}
