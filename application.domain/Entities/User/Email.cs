using application.domain.Common.Abstractions;
using System.Text.RegularExpressions;

namespace application.domain.Entities.User
{
    public sealed class Email : ValueObject
    {
        private static readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        public string Value { get; } = string.Empty;

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            
            if (!_emailRegex.IsMatch(email))
                throw new ArgumentException("Invalid email format.", nameof(email));
            
            return new Email(email);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
