// import external dll functions

using System.Runtime.InteropServices;
using System.Text;

namespace QRNG
{
    public partial class Qrng
    {
        public static readonly string[] QrngErrorStrings = {
            "QRNG_SUCCESS",
            "QRNG_ERR_FAILED_TO_BASE_INIT",
            "QRNG_ERR_FAILED_TO_INIT_SOCK",
            "QRNG_ERR_FAILED_TO_INIT_SSL",
            "QRNG_ERR_FAILED_TO_CONNECT",
            "QRNG_ERR_SERVER_FAILED_TO_INIT_SSL",
            "QRNG_ERR_FAILED_SSL_HANDSHAKE",
            "QRNG_ERR_DURING_USER_AUTH",
            "QRNG_ERR_USER_CONNECTION_QUOTA_EXCEEDED",
            "QRNG_ERR_BAD_CREDENTIALS",
            "QRNG_ERR_NOT_CONNECTED",
            "QRNG_ERR_BAD_BYTES_COUNT",
            "QRNG_ERR_BAD_BUFFER_ADDRESS",
            "QRNG_ERR_PASSWORD_CHARLIST_TOO_LONG",
            "QRNG_ERR_READING_RANDOM_DATA_FAILED_ZERO",
            "QRNG_ERR_READING_RANDOM_DATA_FAILED_INCOMPLETE",
            "QRNG_ERR_READING_RANDOM_DATA_OVERFLOW",
            "QRNG_ERR_FAILED_TO_READ_WELCOMEMSG",
            "QRNG_ERR_FAILED_TO_READ_AUTH_REPLY",
            "QRNG_ERR_FAILED_TO_READ_USER_REPLY",
            "QRNG_ERR_FAILED_TO_READ_PASS_REPLY",
            "QRNG_ERR_FAILED_TO_SEND_COMMAND"
        };

        public bool CheckDll()
        {
            _qrngdllLoaded = true;
            return _qrngdllLoaded;
        }

        //{+// All library functions (except disconnect()) return 0 (= QRNG_SUCCESS) if }
        //{-the command succeeded, otherwise an error taken from enum _qrng_error. }
        //{=Use the qrng_error_strings array to output the error code as a string. }

        //{+// connect to QRNG service first, by default no ssl will be used*/ }
        [DllImport("libQRNG.dll")]
        public static extern int Qrng_connect(StringBuilder username,
            StringBuilder password);

        [DllImport("libQRNG.dll")]
        public static extern int Qrng_connect_SSL(StringBuilder username,
            StringBuilder password);

        //{+// read bytes / double(s) / int(s) (requires an established connection) }
        //{-make sure your program allocated the value / array beforehand }
        //{=if connected via SSL, the data will be also encrypted }
        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_get_byte_array(ref byte byteArray,
            int byteArraySize,
            ref int actualBytesRcvd);

        //{+// returns double value(s) within range [0, 1)*/ }
        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_get_double(double value);

        [DllImport("libQRNG.dll")]
        public static extern int Qrng_get_double_array(ref double doubleArray,
            int doubleArraySize,
            ref int actualDoublesRcvd);

        //{+// returns integer value(s)*/ }
        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_get_int(ref int value);

        [DllImport("libQRNG.dll")]
        public static extern int Qrng_get_int_array(ref int intArray,
            int intArraySize,
            ref int actualIntsRcvd);

        //{+// this function will return a random string containing the characters a-zA-Z0-9 }
        //{=of length password_length terminated by a null character }
        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_generate_password(StringBuilder tobeusedPasswordChars,
            StringBuilder generatedPassword,
            int passwordLength);

        //{+// here are some handy one-liner functions which automatically a) connect to the QRNG service, }
        //{-b) retrieve the requested data and c) disconnect again. }
        //{-You can use them, if you retrieve data only once in a while. }
        //{=(By default no SSL will be used.) }
        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_byte_array(StringBuilder username,
            StringBuilder password,
            ref byte byteArray,
            int byteArraySize,
            ref int actualBytesRcvd);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_byte_array_SSL(StringBuilder username,
            StringBuilder password,
            ref byte byteArray,
            int byteArraySize,
            ref int actualBytesRcvd);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_double_array(StringBuilder username,
            StringBuilder password,
            ref double doubleArray,
            int doubleArraySize,
            ref int actualDoublesRcvd);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_double_array_SSL(StringBuilder username,
            StringBuilder password,
            ref double doubleArray,
            int doubleArraySize,
            ref int actualDoublesRcvd);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_int_array(StringBuilder username,
            StringBuilder password,
            ref int intArray,
            int intArraySize,
            ref int actualIntsRcvd);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_int_array_SSL(StringBuilder username,
            StringBuilder password,
            ref int intArray,
            int intArraySize,
            ref int actualIntsRcvd);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_double(StringBuilder username,
            StringBuilder password,
            double value);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_double_SSL(StringBuilder username,
            StringBuilder password,
            double value);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_int(StringBuilder username,
            StringBuilder password,
            int value);

        [DllImport("libQRNG.dll")]
        // ReSharper disable once UnusedMember.Global
        public static extern int Qrng_connect_and_get_int_SSL(StringBuilder username,
            StringBuilder password,
            int value);

        //{+// disconnect*/ }
        [DllImport("libQRNG.dll")]
        public static extern int Qrng_disconnect();

        private bool _qrngdllLoaded;
    }
}



