using System.Text.Json.Serialization;

namespace Basket.Api.Dtos
{
    public class BasketDto
    {
        
        [JsonIgnore]
        public string? UserId { get; set; }
        public List<BasketItemDto> basketItems { get; set; }
    }
}