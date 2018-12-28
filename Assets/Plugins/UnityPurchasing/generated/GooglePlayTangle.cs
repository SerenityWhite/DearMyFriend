#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("FQnTogUOLtT/OS7o07r+xJWKmv71b545jmX4UsYcaMmFZ2dMEMD5CAuEOfbbzSJ9f6zeUoDdBvzY7sz3jgrN1N6PA0hpL/PkrJMitmpLpmc4igkqOAUOASKOQI7/BQkJCQ0IC7BGD1I9PZNsQkMrew56KOtJITnG6e65oClbQMnD9R6Zywf5CeJk8anjgl2FzJ3wyElc8LOd/oZYMXbJz4oJBwg4igkCCooJCQizx9kHNDAjUPFl9teBxMqfM51CRcfblfzN5nmY7Ua7kqjObpKlEGxG5WxP25Njj1TmT02VSumEahZjhDP16PXjLs+Y8sjEpaXolNCuqonlM7Rwrye/NXO4o7wVlTKsEnud2PQkQjOVyWFHvNnSIBvTtw7z9QoLCQgJ");
        private static int[] order = new int[] { 13,12,10,7,13,9,10,10,12,11,12,13,13,13,14 };
        private static int key = 8;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
