namespace Forum.API.Models.Domain
{
	public class Role
	{
        public int Id { get; set; }
		public string Name { get; set; }

        // Navigational properties
        public List<User> Users { get; set; }
    }
}