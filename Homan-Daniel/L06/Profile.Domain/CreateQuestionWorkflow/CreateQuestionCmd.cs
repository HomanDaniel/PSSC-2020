using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Profile.Domain.CreateQuestionWorkflow
{
    public struct CreateQuestionCmd
    {
        public CreateQuestionCmd(string title, string body, List<string> tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }

        [Required]
        [DataType(DataType.Text)]        
        [MinLength(15)]
        public string Title { get; private set; }

        [Required]
        [DataType(DataType.MultilineText)]
        
        public string Body { get; private set; }

        [Required]        
        public List<string> Tags { get; private set; }
    }
}
