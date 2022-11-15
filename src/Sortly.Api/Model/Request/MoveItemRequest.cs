using Sortly.Api.Common.Exceptions;
using Sortly.Api.Model.Abstractions;
using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Request body parameters for moving an item
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/move-an-item"/>
    /// </summary>
    public class MoveItemRequest : IValidatable
    {
        /// <summary>
        /// Move quantity of item
        /// </summary>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Target folder ID. If not defined then will be moved to root
        /// </summary>
        [JsonPropertyName("folder_id")]
        public int? FolderId { get; set; }

        /// <summary>
        /// Determines wether items with zero quantity are kept or not. Default is false.
        /// </summary>
        [JsonPropertyName("leave_zero_quantity")]
        public bool? LeaveZeroQuantity { get; set; }

        public void Validate()
        {
            if (Quantity == null)
                throw new SortlyValidationException("Quantity is required");
        }
    }
}
