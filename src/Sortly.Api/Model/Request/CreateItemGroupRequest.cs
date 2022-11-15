using Sortly.Api.Common.Exceptions;
using Sortly.Api.Model.Abstractions;
using Sortly.Api.Model.Sortly;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Request
{
    public class CreateItemGroupRequest : IValidatable
    {
        [JsonPropertyName("item_group")]
        public ItemGroup ItemGroup { get; set; }

        public void Validate()
        {
            if (ItemGroup == null)
                throw new SortlyValidationException("ItemGroup must be defined");

            ItemGroup.Validate();
        }
    }
}
