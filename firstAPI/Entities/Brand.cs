using firstAPI.Entities.Base;

namespace firstAPI.Entities
{
    public class Brand : BaseEntity
    {

        
        public string brandName { get; set; }
        public List<Car> brands { get;set; }

    }
}
