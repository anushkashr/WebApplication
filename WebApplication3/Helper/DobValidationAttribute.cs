namespace WebApplication3.Helper
{
    public class DobValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime _dob=Convert.ToDateTime(value);
            if(_dob.Date==DateTime.Today.Date)
            {
                return false;
            }
            return true;
        }
    }
}
