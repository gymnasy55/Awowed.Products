namespace Products.Domain.Models
{
    public interface IRole
    { 
        Permissions[] Permissions { get; }
    }
}