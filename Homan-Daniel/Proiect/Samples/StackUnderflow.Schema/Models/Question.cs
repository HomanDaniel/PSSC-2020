using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.DatabaseModel.Models
{
    public partial class Question
    {
        public Question()
        {
            Tag = new HashSet<Tag>();
        }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public Guid? OrganisationId { get; set; }
        public Guid? QuestionId { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
    }
}
