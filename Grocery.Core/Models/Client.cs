namespace Grocery.Core.Models
{
    public partial class Client : Model
    {
        public readonly string emailAddress;
        public readonly string password;
        public Client(int id, string name, string emailAddress, string password) : base(id, name)
        {
            this.emailAddress=emailAddress;
            this.password=password;
        }
    }
}
