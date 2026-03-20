namespace CampBooking.Shared.Helpers;

/// <summary>
/// Provides functionality to generate a reference number based on a GUID,
/// a cell‑phone string, and a ZIP code.
/// </summary>
public class GetReferenceNumber
{
    /// <summary>
    /// Generates a reference string by concatenating the last character of the ZIP code,
    /// the last two digits of the cell phone number, and the last five characters of the GUID,
    /// then returns the result in uppercase.
    /// </summary>
    /// <param name="id">The GUID used as part of the reference.</param>
    /// <param name="cellPhone">The cell phone number; its last two characters are used.</param>
    /// <param name="zipCode">The ZIP code; its last character is used.</param>
    /// <returns>An uppercase reference string composed of parts of the inputs.</returns>
    public static string RandomNumber(Guid id, string cellPhone, string zipCode)
    {
        var strID = id.ToString();
        var refNum = zipCode[^1..] + cellPhone[^2..] + strID[^5..];
        return refNum.ToUpper();
    }
}