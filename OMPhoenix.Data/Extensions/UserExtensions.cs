using OMPhoenix.Data.Repositories;
using OMPhoenix.Entity;
﻿using System.Linq;

namespace OMPhoenix.Data.Extensions
{
    public static class UserExtensions
    {
        /// <summary>
        /// Gets the single by username.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="username">The username.</param>
        /// <returns>User.</returns>
        public static User GetSingleByUsername(this IEntityBaseRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Username == username);
        }
        /// <summary>
        /// Gets the single by usernameor email.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="username">The username.</param>
        /// <param name="email">The email.</param>
        /// <returns>User.</returns>
        public static User GetSingleByUsernameorEmail(this IEntityBaseRepository<User> userRepository, string username, string email)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Username == username || x.Email==email);
        } 
    }
}