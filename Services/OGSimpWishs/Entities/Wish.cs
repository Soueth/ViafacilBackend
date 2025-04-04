using OGSimpWishs.Enums;

namespace OGSimpWishs.Entities;

public class Wish : Entity
{
    public int value { get; set; }
    public virtual ICollection<Item>
    public TypeValue TypeValue { get; set; }
    public WishStatus WishStatus { get; set; } 
}

