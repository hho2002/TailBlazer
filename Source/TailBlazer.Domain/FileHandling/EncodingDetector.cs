using Ude;
using System.Text;
using System.Diagnostics;

namespace TailBlazer.Domain.FileHandling
{
    public class EncodingDetector
    {
        public static void DebugOut(string msg)
        {
            StackTrace st = new StackTrace(false);
            string caller = st.GetFrame(1).GetMethod().Name;
            Debug.WriteLine(caller + ": " + msg);
        }

        public static string Detect(byte[] byteBuffer)
        {
            var detector = new CharsetDetector();
            detector.Feed(byteBuffer, 0, byteBuffer.Length);
            detector.DataEnd();

            var charset = detector.Charset;
            if(charset.ToLower() == "big-5")
            {
                charset = charset.Replace("-", "");
            }
            DebugOut(charset);
            return charset;
        }
    }
}
