using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSDataSeed.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__19093A2BA508823B", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    UserType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__1788CCACCFD56CE4", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    InstructorID = table.Column<int>(type: "int", nullable: true),
                    InstructorName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__C92D71878AC8F4D7", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK__Course__Category__7A3223E8",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK__Course__Instruct__3F466844",
                        column: x => x.InstructorID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserActivityLog",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActivityType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ActivityDetails = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserActi__5E5499A85E897BAE", x => x.LogID);
                    table.ForeignKey(
                        name: "FK__UserActiv__UserI__2B0A656D",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    PreferenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Theme = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Language = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserPref__E228490FA5BFCA85", x => x.PreferenceID);
                    table.ForeignKey(
                        name: "FK__UserPrefe__UserI__3E1D39E1",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRole__3D978A55F36E6A56", x => x.UserRoleID);
                    table.ForeignKey(
                        name: "FK__UserRole__UserID__17F790F9",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    AnnouncementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    AnnouncementText = table.Column<string>(type: "text", nullable: true),
                    NotificationType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Announce__9DE445545CCBA3E5", x => x.AnnouncementID);
                    table.ForeignKey(
                        name: "FK__Announcem__Cours__1DB06A4F",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Announcem__UserI__1EA48E88",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "DiscussionForum",
                columns: table => new
                {
                    ForumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    ForumName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ModeratorID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discussi__E210AC4F792C10AD", x => x.ForumID);
                    table.ForeignKey(
                        name: "FK__Discussio__Cours__0A9D95DB",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Discussio__Moder__0B91BA14",
                        column: x => x.ModeratorID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enrollme__7F6877FB6A9BD524", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK__Enrollmen__Cours__44FF419A",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Enrollmen__UserI__440B1D61",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    FeedbackText = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    RatingScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__6A4BEDF6934A39D8", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK__Feedback__Course__6442E2C9",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Feedback__UserID__65370702",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    LessonName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ContentType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lesson__B084ACB04D4D10C9", x => x.LessonID);
                    table.ForeignKey(
                        name: "FK__Lesson__CourseID__4D5F7D71",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    ModuleName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Module__2B7477870971D4C0", x => x.ModuleID);
                    table.ForeignKey(
                        name: "FK__Module__CourseID__66603565",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    QuizName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quiz__8B42AE6EF9B1A206", x => x.QuizID);
                    table.ForeignKey(
                        name: "FK__Quiz__CourseID__71D1E811",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "ForumPost",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostContent = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ForumPos__AA12603815D3DB81", x => x.PostID);
                    table.ForeignKey(
                        name: "FK__ForumPost__Forum__114A936A",
                        column: x => x.ForumID,
                        principalTable: "DiscussionForum",
                        principalColumn: "ForumID");
                    table.ForeignKey(
                        name: "FK__ForumPost__UserI__123EB7A3",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    AssessmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    AssessmentName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AssessmentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assessme__3D2BF83E1CFE8C04", x => x.AssessmentID);
                    table.ForeignKey(
                        name: "FK__Assessmen__Cours__30C33EC3",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Assessmen__Modul__31B762FC",
                        column: x => x.ModuleID,
                        principalTable: "Module",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    AssignmentName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assignme__32499E57F27E7EEC", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK__Assignmen__Cours__7D439ABD",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Assignmen__Modul__7E37BEF6",
                        column: x => x.ModuleID,
                        principalTable: "Module",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    ResourceName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__4ED1814F2B313C3D", x => x.ResourceID);
                    table.ForeignKey(
                        name: "FK__Resource__Course__245D67DE",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Resource__Module__25518C17",
                        column: x => x.ModuleID,
                        principalTable: "Module",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizID = table.Column<int>(type: "int", nullable: true),
                    QuestionText = table.Column<string>(type: "text", nullable: true),
                    Options = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__0DC06F8C69A51E48", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK__Question__QuizID__778AC167",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "QuizID");
                });

            migrationBuilder.CreateTable(
                name: "UserProgress",
                columns: table => new
                {
                    UserProgressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    LessonID = table.Column<int>(type: "int", nullable: true),
                    QuizID = table.Column<int>(type: "int", nullable: true),
                    ProgressPercentage = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CourseName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserProg__DD2907C60DB6D93E", x => x.UserProgressID);
                    table.ForeignKey(
                        name: "FK__UserProgr__Cours__44CA3770",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__UserProgr__Modul__45BE5BA9",
                        column: x => x.ModuleID,
                        principalTable: "Module",
                        principalColumn: "ModuleID");
                    table.ForeignKey(
                        name: "FK__UserProgr__QuizI__47A6A41B",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "QuizID");
                    table.ForeignKey(
                        name: "FK__UserProgr__UserI__43D61337",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    AssessmentID = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grade__54F87A3769AA87FD", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK__Grade__Assessmen__3864608B",
                        column: x => x.AssessmentID,
                        principalTable: "Assessment",
                        principalColumn: "AssessmentID");
                    table.ForeignKey(
                        name: "FK__Grade__UserID__37703C52",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    SubmissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    AssignmentID = table.Column<int>(type: "int", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SubmittedFileName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Grade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Submissi__449EE105E7F5E9AA", x => x.SubmissionID);
                    table.ForeignKey(
                        name: "FK__Submissio__Assig__04E4BC85",
                        column: x => x.AssignmentID,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentID");
                    table.ForeignKey(
                        name: "FK__Submissio__UserI__03F0984C",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_CourseID",
                table: "Announcement",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_UserID",
                table: "Announcement",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_CourseID",
                table: "Assessment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_ModuleID",
                table: "Assessment",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_CourseID",
                table: "Assignment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ModuleID",
                table: "Assignment",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryID",
                table: "Course",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstructorID",
                table: "Course",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionForum_CourseID",
                table: "DiscussionForum",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionForum_ModeratorID",
                table: "DiscussionForum",
                column: "ModeratorID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_UserID",
                table: "Enrollment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CourseID",
                table: "Feedback",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserID",
                table: "Feedback",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPost_ForumID",
                table: "ForumPost",
                column: "ForumID");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPost_UserID",
                table: "ForumPost",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_AssessmentID",
                table: "Grade",
                column: "AssessmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_UserID",
                table: "Grade",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_CourseID",
                table: "Lesson",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Module_CourseID",
                table: "Module",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizID",
                table: "Question",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_CourseID",
                table: "Quiz",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_CourseID",
                table: "Resource",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ModuleID",
                table: "Resource",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_AssignmentID",
                table: "Submission",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_UserID",
                table: "Submission",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityLog_UserID",
                table: "UserActivityLog",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserID",
                table: "UserPreferences",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgress_CourseID",
                table: "UserProgress",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgress_ModuleID",
                table: "UserProgress",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgress_QuizID",
                table: "UserProgress",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgress_UserID",
                table: "UserProgress",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID",
                table: "UserRole",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "ForumPost");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "UserActivityLog");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "UserProgress");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "DiscussionForum");

            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
