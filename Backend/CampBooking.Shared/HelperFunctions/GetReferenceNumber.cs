namespace CampBooking.Shared.HelperFunctions
{
    public class GetReferenceNumber
    {
        public static string RandomNumber(Guid _id,string _cellPhone,string _zipCode)
        {
            var strID = _id.ToString();
            var refNum = _zipCode[^1..] + _cellPhone[^2..] + strID[^5..];
            return refNum.ToUpper();
        }

    }
}
