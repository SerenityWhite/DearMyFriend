#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("jD6XlU2SMVyyzrtc6y0wLTv2F0BonteK5eVLtJqb86PWovAzkfnhHjtahV0URSgQkYQoa0UmXoDprhEXUtHf0OBS0drSUtHR0GsfAd/s6PvTXOEuAxX6pad0BopYBd4kADYUL0A1nmNKcBa2Sn3ItJ49tJcDS7tXYHtkzU3qdMqjRQAs/JrrTRG5n2SIKb0uD1kcEkfrRZqdHwNNJBU+oeBS0fLg3dbZ+laYVifd0dHR1dDTKhAcfX0wTAh2clE962yod/9n7atW0hUMBlfbkLH3Kzx0S/puspN+v83RC3rd1vYMJ+H2MAtiJhxNUkImMTZhePGDmBEbLcZBE98h0Tq8KXEtt0bhVr0gih7EsBFdv7+UyBgh0AEK+MMLb9YrLdLT0dDR");
        private static int[] order = new int[] { 4,9,6,9,10,8,9,11,10,10,11,13,13,13,14 };
        private static int key = 208;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
