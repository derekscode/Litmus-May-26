using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace Litmus
{
    public class ActiveDirectory
    {
        //var test = User.IsInRole("S-1-1-0");

        // put this above controller action:
        //[Authorize(Roles = ActiveDirectory.CORPecoQADBRead_G)]

        public const string CORPecoQADBRead_G = "S-1-5-21-102932503-109117628-3773961456-41001";
        public const string ecoATMLitmusUser = "";
        public const string ecoATMLitmusAdmin = "";


        // returns all AD groups with corresponding SIDs
        public static Dictionary<string, string> GetGroups(HttpContext context)
        {

            var dictionary = new Dictionary<string, string>();
            var groups = ((WindowsIdentity)context.User.Identity).Groups;

            foreach (var group in groups)
            {
                dictionary.Add(group.Value, ConvertSidToGroup(group.Value));
            }

            return dictionary;
        }


        private static string ConvertSidToGroup(string sid)
        {
            string group = new SecurityIdentifier(sid).Translate(typeof(NTAccount)).ToString();
            return group;
        }
    }
}
