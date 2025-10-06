﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TestingPlatform.Models
{
    public class UserSelectedOption
    {
        public int Id { get; set; }

        public int UserAttemptAnswerId { get; set; }

        public int AnswerId { get; set; }


        //навигация
        public UserAttemptAnswer UserAttemptAnswer { get; set; }
        public Answer Answer { get; set; }
    }
}
