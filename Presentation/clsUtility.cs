using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD
{
    public static class clsUtility
    {
        // =====================================================
// PLACEHOLDER TESTS (SHOULD BE FILTERED)
// =====================================================

string placeholder1 = "your_api_key";
string placeholder2 = "insert_key_here";
string placeholder3 = "changeme";
string placeholder4 = "your_token";
string placeholder5 = "my_secret";
string placeholder6 = "example";

        // =====================================================
// FALSE POSITIVE TESTS (SHOULD NOT TRIGGER)
// =====================================================

string city = "Nablus";
string country = "Palestine";
string username = "Khaled";
string project = "GitGuard";
string userId = "12345678901234567890";
string orderNumber = "98765432109876543210";
string version = "1.0.0";
string greeting = "HelloWorld";
string course = "CENG3544";
        public static string ToSpacedString(this Enum value)
        {
            return Regex.Replace(value.ToString(), "(\\B[A-Z])", " $1");
        }
    }

    
}
