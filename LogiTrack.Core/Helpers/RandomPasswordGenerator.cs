using System.Text;

namespace LogiTrack.Core.Helpers
{
    public static class RandomPasswordGenerator
    {
        private const string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string Digits = "0123456789";
        private static readonly string SpecialCharacters = "!@#$%^&*()-_=+<>?";

        public static string GenerateRandomPassword()
        {
            int length = 12;
            var random = new Random();
            var password = new StringBuilder();
            password.Append(UppercaseCharacters[random.Next(UppercaseCharacters.Length)]);
            password.Append(LowercaseChars[random.Next(LowercaseChars.Length)]);
            password.Append(Digits[random.Next(Digits.Length)]);
            password.Append(SpecialCharacters[random.Next(SpecialCharacters.Length)]);

            string allChars = UppercaseCharacters + LowercaseChars + Digits + SpecialCharacters;
            for (int i = 4; i < length; i++)
            {
                password.Append(allChars[random.Next(allChars.Length)]);
            }

            return new string(password.ToString().ToCharArray().OrderBy(c => random.Next()).ToArray());
        }
    }
}

