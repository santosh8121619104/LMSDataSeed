using System;
using System.Collections.Generic;

namespace LMSDataSeed.Models;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int? CourseId { get; set; }

    public string? LessonName { get; set; }

    public string? Content { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool IsPaid { get; set; }

    public int? ContentType { get; set; }

    public virtual Course? Course { get; set; }
}
