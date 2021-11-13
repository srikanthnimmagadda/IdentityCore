using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityPractice.Authorization
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public CustomAuthorizationRequirement(int probationPeriod)
        {
            ProbationPeriod = probationPeriod;
        }

        /// <summary>
        /// Probation Period In Months
        /// </summary>
        public int ProbationPeriod { get; set; }
    }
}
