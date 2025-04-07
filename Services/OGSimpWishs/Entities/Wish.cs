using OGSimpSharedTypes;
using OGSimpWishs.Enums;

namespace OGSimpWishs.Entities;

public class Wish : Entity
{
    public double Value { get; set; }
    public virtual Item Item { get; set; }
    public int Amount { get; set; }
    public TypeValue TypeValue { get; set; }
    public WishStatus WishStatus { get; set; } 
}

