using System.Net.Http;

namespace eSportSchool.Tests {
    public class HostTests : TestAsserts {
        internal static readonly TestHost<Program> host;
        internal static readonly HttpClient client;
        static HostTests() {
            host = new TestHost<Program>();
            client = host.CreateClient();
        }
    }
}