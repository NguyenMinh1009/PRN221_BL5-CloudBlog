﻿namespace CloudBlog.Models.ViewModels
{
    public class AddUser
    {
        public string UserName { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AdminCheckBox { get; set; }
    }
}
