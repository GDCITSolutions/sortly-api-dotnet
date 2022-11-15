namespace Sortly.Api.Common.Constants
{
    /// <summary>
    /// https://sortlyapi.docs.apiary.io/#reference/0/units-of-measure/create-an-alert
    /// </summary>
    public static class AlertThresholdMethods
    {
        public static string DateReminderBefore = "before";
        public static string DateReminderAfter = "after";
        public static string DateReminderSameDay = "same_day";
        public static string QuantityGreaterThan = "quantity_greater_than";
        public static string QuantityGreaterThanEqualTo = "quantity_greater_than_equal_to";
        public static string QuantityLessThan = "quantity_less_than";
        public static string QuantityLessThanEqualTo = "quantity_less_than_equal_to";
        public static string QuantityLessThanOrEqualToMinQuantity = "less_than_or_equal_to_min_quantity";
    }
}
