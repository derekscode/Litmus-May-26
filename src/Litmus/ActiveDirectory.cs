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
        //var test = User.IsInRole(ActiveDirectory.ecoATMLitmusUser);

        // put this above controller action:
        //[Authorize(Roles = ActiveDirectory.CORPecoQADBRead_G)]

        // reference
        public const string CORPecoQADBRead_G = "S-1-5-21-102932503-109117628-3773961456-41001";
        private const string ecoATMLitmusUser = "S-1-5-21-102932503-109117628-3773961456-56053";
        private const string ecoATMLitmusAdmin = "";

        private const string GroupIAmIn = "S-1-5-21-102932503-109117628-3773961456-56053";
        private const string GroupIAmNotIn = "S-0";

        // maybe I shouldn't even have a User group, but just an Admin group
        public const string LitmusUser = GroupIAmIn;
        public const string LitmusAdmin = GroupIAmNotIn;

       






        // returns all AD groups with corresponding SIDs
        public static Dictionary<string, string> GetGroups()
        {
            var dictionary = new Dictionary<string, string>();

            var groups = WindowsIdentity.GetCurrent().Groups;


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
