namespace NextwoIdentity.Models.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public List <string>? Users { get; set;}
    }
}
