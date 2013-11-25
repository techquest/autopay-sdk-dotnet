using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.interswitchng.techquest.autopay.sdk.lib.dto
{
    public class Errors : RestResponse
    {
        public Error []errors { get; set; }

        public Errors()
        {
            successful = false;
        }
    }
}
