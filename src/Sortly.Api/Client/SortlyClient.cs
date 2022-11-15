using Sortly.Api.Common.Util;
using Sortly.Api.Http;

namespace Sortly.Api.Client
{
    /// <summary>
    /// Facilitate API interactions with Sortly's API
    /// </summary>
    public interface ISortlyClient
    {
        /// <summary>
        /// Instance of IAlertClient that manages requests with the "Default" service.
        /// </summary>
        IAlertClient Alert { get; }

        /// <summary>
        /// Instance of ICustomFieldClient that manages requests with the "Default" service.
        /// </summary>
        ICustomFieldClient CustomField { get; }

        /// <summary>
        /// Instance of IItemClient that manages requests with the "Default" service.
        /// </summary>
        IItemClient Item { get; }

        /// <summary>
        /// Instance of IItemGroupClient that manages requests with the "Default" service.
        /// </summary>
        IItemGroupClient ItemGroup { get; }

        /// <summary>
        /// Instance of IUnitsOfMeasureClient that manages requests with the "Default" service.
        /// </summary>
        IUnitsOfMeasureClient UnitsOfMeasure { get; }
    }

    public class SortlyClient : ISortlyClient
    {
        public SortlyClient(ISortlyApiAdapter api) 
        {
            Guard.ArgumentsAreNotNull(api);

            Alert = new AlertClient(api);
            CustomField = new CustomFieldClient(api);
            Item = new ItemClient(api);
            ItemGroup = new ItemGroupClient(api);
            UnitsOfMeasure = new UnitsOfMeasureClient(api);
        }

        /// <summary>
        /// Instance of IAlertClient that manages requests with the "Default" service.
        /// </summary>
        public IAlertClient Alert { get; }

        /// <summary>
        /// Instance of ICustomFieldClient that manages requests with the "Default" service.
        /// </summary>
        public ICustomFieldClient CustomField { get; }

        /// <summary>
        /// Instance of IItemClient that manages requests with the "Default" service.
        /// </summary>
        public IItemClient Item { get; }

        /// <summary>
        /// Instance of IItemGroupClient that manages requests with the "Default" service.
        /// </summary>
        public IItemGroupClient ItemGroup { get; }

        /// <summary>
        /// Instance of IUnitsOfMeasureClient that manages requests with the "Default" service.
        /// </summary>
        public IUnitsOfMeasureClient UnitsOfMeasure { get; }
    }
}
