namespace Sortly.Api.Common.Constants
{
    /// <summary>
    /// Values allowed currently as per Sortly's API spec.
    /// 
    /// org.gs1.UPC-E, org.iso.Code39, org.iso.Code39Mod43, org.gs1.EAN-13, org.gs1.EAN-8, com.intermec.Code93, org.iso.Code128, org.iso.PDF417, org.iso.Aztec, org.iso.QRCode, org.ansi.Interleaved2of5, org.iso.DataMatrix
    /// </summary>
    public static class ScannerCodeTypes
    {
        public static string ANSI_Interleaved2of5 = "org.ansi.Interleaved2of5";
        public static string GS1_UPC_E = "org.gs1.UPC-E";
        public static string GS1_EAN_13 = "org.gs1.EAN-13";
        public static string GS1_EAN_8 = "org.gs1.EAN-8";
        public static string INTERMEC_Code93 = "org.intermec.Code93";
        public static string ISO_Code128 = "org.iso.Code128";
        public static string ISO_PDF417 = "org.iso.PDF417";
        public static string ISO_Aztec = "org.iso.Aztec";
        public static string ISO_DataMatrix = "org.iso.DataMatrix";
        public static string ISO_QRCode = "org.iso.QRCode";
        public static string ISO_Code39 = "org.iso.Code39";
        public static string ISO_Code39Mod43 = "org.iso.Code39Mod43";
    }
}
