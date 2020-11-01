using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    public struct CreateQuestionCmd
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Description { get; private set; }
        public List<string> Tags { get; private set; }
        public int Vote { get; private set; }

        public CreateQuestionCmd(string Title, string Description, List<string> Tags,int Vote)
        {
            this.Title = Title;
            this.Description = Description;
            this.Tags = Tags;
            this.Vote = Vote;
        }
    }
}
