﻿using System.ComponentModel.DataAnnotations;

namespace TestingPlatform.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public int QuestionId  {  get; set; } 

        //навгиация
        public Question Question {  get; set; }
        public List<UserSelectedOption> UserSelectedOptions {  get; set; }


    }
}
