namespace Authy.Models
{
    public class VaultItem
    {
        public string Name { get; set; }
        public string Resource { get; set; }

        public VaultItem(string name, string resource)
        {
            Name = name;
            Resource = resource;
        }
    }
}
