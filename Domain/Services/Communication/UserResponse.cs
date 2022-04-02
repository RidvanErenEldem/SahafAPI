using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User user { get; set; }
        
        private UserResponse(bool success, string message, User usere) :base(success, message)
        {
            this.user = user;
        }

        public UserResponse(User user) : this(true, string.Empty, user)
        {}

        public UserResponse(string message) : this(false, message, null)
        {}
    }
}