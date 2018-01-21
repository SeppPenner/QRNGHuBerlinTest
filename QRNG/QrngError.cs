// import external dll functions


namespace QRNG
{
    public partial class Qrng
    {
        // ReSharper disable once UnusedMember.Global
        public enum QrngError {
            // ReSharper disable UnusedMember.Global
            QrngSuccess, // = 0 
            QrngErrFailedToBaseInit, 
            QrngErrFailedToInitSock, 
            QrngErrFailedToInitSsl, 
            QrngErrFailedToConnect, 
            QrngErrServerFailedToInitSsl, 
            QrngErrFailedSslHandshake, 
            QrngErrDuringUserAuth, 
            QrngErrUserConnectionQuotaExceeded, 
            QrngErrBadCredentials, 
            QrngErrNotConnected,
            QrngErrBadBytesCount,
            QrngErrBadBufferAddress,
            QrngErrPasswordCharlistTooLong,
            QrngErrReadingRandomDataFailedZero,
            QrngErrReadingRandomDataFailedIncomplete,
            QrngErrReadingRandomDataOverflow,
            QrngErrFailedToReadWelcomemsg,
            QrngErrFailedToReadAuthReply,
            QrngErrFailedToReadUserReply,
            QrngErrFailedToReadPassReply,
            QrngErrFailedToSendCommand
            // you may obtain between 1 to 2147483647 bytes with one get_random_bytes() call*/  });    
        }
    }
}