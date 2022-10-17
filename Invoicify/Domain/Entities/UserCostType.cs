namespace Domain.Entities;

public class UserCostType
{
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public UserCostType CostType { get; set; }
}