using System.Text.Json.Serialization;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Request body parameters for cloning an item
    /// <see cref="https://sortlyapi.docs.apiary.io/#reference/0/items/clone-an-item"/>
    /// </summary>
    public class CloneItemRequest
    {
        /// <summary>
        /// Copy item and set this quantity
        /// </summary>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Target folder ID. If not defined then will be moved to root
        /// </summary>
        [JsonPropertyName("folder_id")]
        public int? FolderId { get; set; }

        /// <summary>
        /// Copy with nested items or not
        /// </summary>
        [JsonPropertyName("include_sub_tree")]
        public bool? IncludeSubTree { get; set; }

        /// <summary>
        /// Copy with new SID generation or not
        /// </summary>
        [JsonPropertyName("new_sid")]
        public bool? NewSortlyId { get; set; }
    }
}
