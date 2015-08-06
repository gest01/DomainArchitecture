using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Domain.ValueObjects
{
    public class UserInfo
    {
        public String UserId { get; set; }

        public String Email { get; set; }

        public String Language { get; set; }

        public String DisplayName { get; set; }
    }
}
