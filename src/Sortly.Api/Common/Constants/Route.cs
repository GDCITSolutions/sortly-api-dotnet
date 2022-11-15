namespace Sortly.Api.Common.Constants
{
    internal class Route
    {
        private static readonly string Base = "/api/v1";

        public static readonly string CustomFields = $"{Base}/custom_fields";
        public static readonly string Items = $"{Base}/items";
        public static readonly string RecentItems = $"{Items}/recent";
        public static readonly string SearchItems = $"{Items}/search";
        public static readonly string ItemGroups = $"{Base}/item_groups";
        public static readonly string UnitsOfMeasure = $"{Base}/units";
        public static readonly string Alerts = $"{Base}/alerts";
    }
}
