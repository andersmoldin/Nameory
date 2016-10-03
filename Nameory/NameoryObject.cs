using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameory
{
    public class NameoryObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PicUrl { get; private set; }
        public string Bio { get; private set; }
        public string Gender { get; private set; }

        public NameoryObject(string firstname, string lastname, string picUrl, string bio, string gender)
        {
            FirstName = firstname;
            LastName = lastname;
            PicUrl = picUrl;
            Bio = bio;
            Gender = gender;
        }
    }
}