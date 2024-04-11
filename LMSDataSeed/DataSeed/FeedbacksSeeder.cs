using LMSDataSeed.Models;

namespace LMSDataSeed.DataSeed
{
    public class FeedbacksSeeder : IEntitySeeder
    {
        public bool run(LmsContext context)
        {
            if (!context.Feedbacks.Any())
            {
                var courses = context.Courses.ToList();
                var users = context.Users.ToList();

                if (courses.Count == 0 || users.Count == 0)
                {
                    // No courses or users available, cannot create feedback
                    return false;
                }
                foreach (var course in courses)
                {
                    context.Feedbacks.AddRange(GenerateFeedbacks(context, course));
                }
                context.SaveChanges();
                return true;
            }

            return false;
        }



        public List<Feedback> GenerateFeedbacks(LmsContext context,Course course)
        {
            List<Feedback> feedbacks = new List<Feedback>();
            Random random = new Random();

            List<User> users = context.Users.ToList();

            for (int i = 1; i <= 40; i++)
            {
                string template = feedbackTemplates[random.Next(feedbackTemplates.Count)];
                string topic = topics[random.Next(topics.Count)];

                Feedback feedback = new Feedback
                {
                    Course = course,
                    UserId = random.Next(1, users.Count + 1), // Randomly assign a user ID
                    FeedbackText = String.Format(template, topic),
                    RatingScore = random.Next(1, 6), 
                    User = users.FirstOrDefault(a => a.UserId == random.Next(1, users.Count)),
                    CreateDate = getDateTime()

                };

                feedbacks.Add(feedback);
            }

            return feedbacks;
        }


        private List<string> feedbackTemplates = new List<string>
                                                    {
                                                        "The course content was comprehensive, especially the section on {0}. It covered all the essential topics.",
                                                        "I found the explanations regarding {0} to be clear and concise. It helped me grasp the concepts easily.",
                                                        "The {0} module was informative, but I would have liked more real-world examples to better understand the application.",
                                                        "The course structure was well-designed, but I felt that the {0} section could be expanded to provide more depth.",
                                                        "The instructor's teaching style was engaging, especially in the {0} lectures. I appreciated the enthusiasm.",
                                                        "I enjoyed the practical exercises in the {0} lessons. They helped reinforce the theoretical concepts.",
                                                        "The course provided valuable insights into {0}, but I would suggest adding supplementary reading materials for further exploration.",
                                                        "The {0} topic was intriguing, but I struggled to grasp some of the advanced concepts. Additional resources would be beneficial.",
                                                        "The course forum was helpful for discussing {0} related queries with fellow students and the instructor.",
                                                        "I found the self-assessment quizzes in the {0} module to be helpful in gauging my understanding of the material.",
                                                    };


        private List<string> topics = new List<string>
                                            {
                                                "object-oriented programming",
                                                "data structures",
                                                "algorithm complexity",
                                                "design patterns",
                                                "software testing"
                                            };


        private DateTime getDateTime()
        {
            DateTime startDate = new DateTime(2021, 1, 1);
            DateTime endDate = new DateTime(2023, 12, 31);

            // Generate a random number of days to add to the start date
            Random random = new Random();
            int range = (endDate - startDate).Days;
            DateTime randomDate = startDate.AddDays(random.Next(range));
            return randomDate;
        }
    }

}
